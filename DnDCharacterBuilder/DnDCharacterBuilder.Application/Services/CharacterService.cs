using AutoMapper;
using DnDCharacterBuilder.Application.Interfaces;
using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Data.Interfaces;
using DnDCharacterBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DnDCharacterBuilder.Application.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IRepository<Character> _characterRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Class> _classRepository;
        private readonly IRepository<Race> _raceRepository;
        private readonly IRepository<Skill> _skillRepository;

        public CharacterService(IRepository<Character> characterRepository, IMapper mapper, IRepository<Class> classRepository, IRepository<Race> raceRepository, IRepository<Skill> skillRepository)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
            _classRepository = classRepository;
            _raceRepository = raceRepository;
            _skillRepository = skillRepository;
        }

        public async Task<CreateCharaterOutput> SaveCharacter(CreateCharacterModel characterToSave, string userId)
        {
            var characterClass = _classRepository.GetAsQueryable()
                .Include(x => x.ClassSkillProficiencieBonus)
                .Include(x => x.ClassSavingThrows)
                .FirstOrDefault(x => x.Id == characterToSave.ClassId);
            var characterRace = _raceRepository.GetAsQueryable()
                .Include(x => x.RaceAbilities)
                .FirstOrDefault(x => x.Id == characterToSave.RaceId);
            var allSkills = _skillRepository.GetAll();
            var selectedSkills = characterToSave.SelectedSkills;

            var numberOfSelectedSkills = characterToSave.SelectedSkills.Count;

            if (numberOfSelectedSkills > characterClass.ProficiencyChoiceCount)
            {
                return new CreateCharaterOutput { ErrorMessage = "Cannot select more than " + numberOfSelectedSkills + " skills."};
            }

            foreach (var skill in selectedSkills)
            {
                if (characterClass.ClassSkillProficiencieBonus.Select(x => x.SkillId == skill) == null)
                {
                    return new CreateCharaterOutput { ErrorMessage = "Cannot select unavailable skills." };
                }


            }

            foreach (var skillProficiency in characterRace.RaceAbilities)
            {
                switch (skillProficiency.Ability)
                {
                    case Common.Enums.Ability.Strength:
                        characterToSave.Strength += skillProficiency.Value;
                        break;
                    case Common.Enums.Ability.Dexterity:
                        characterToSave.Dexterity += skillProficiency.Value;
                        break;
                    case Common.Enums.Ability.Constitution:
                        characterToSave.Constitution += skillProficiency.Value;
                        break;
                    case Common.Enums.Ability.Intelligence:
                        characterToSave.Intelligence += skillProficiency.Value;
                        break;
                    case Common.Enums.Ability.Wisdom:
                        characterToSave.Wisdom += skillProficiency.Value;
                        break;
                    case Common.Enums.Ability.Charisma:
                        characterToSave.Charisma += skillProficiency.Value;
                        break;
                }
            }

            var character = _mapper.Map<Character>(characterToSave);
            character.CharacterSkillProficiencies = allSkills.Select(skill => new CharacterSkillProficiency
            {
                SkillId = skill.Id,
                isProficient = selectedSkills.Any(x => x == skill.Id)
            }).ToList();

            foreach (var ability in character.CharacterAbilities)
            {
                if(characterClass.ClassSavingThrows.Select(x => x.Ability).Contains(ability.Ability))
                {
                    ability.ProficiencyBonus = true;
                }
            }

            character.UserId = userId;
            character.Speed = characterRace.Speed;

            try
            {
                _characterRepository.Add(character);
                return new CreateCharaterOutput { CharacterId = character.Id };
            } catch (Exception ex)
            {
                return new CreateCharaterOutput { ErrorMessage = ex.Message };
            }
        }

        public void DeleteCharacter(Guid characterId)
        {
            _characterRepository.Delete(characterId);
        }

        public int GetValueForSkill(Guid skillId, Character character)
        {
            var skill = _skillRepository.GetAsQueryable().FirstOrDefault(x => x.Id == skillId);
            var ability = skill.RelatedAbility;
            
            var characterAbility = character.CharacterAbilities.Where(x => x.Ability == ability).FirstOrDefault();

            if (characterAbility.ProficiencyBonus)
            {
                return characterAbility.Value + 1;
            }

            return characterAbility.Value;
        }

        public IEnumerable<Character> GetCharacters()
        {
            return _characterRepository.GetAsQueryable()
                .Include(x => x.CharacterAbilities)
                .Include(x => x.CharacterSkillProficiencies)
                .ThenInclude(x => x.Skill)
                .Include(x => x.Class)
                .ThenInclude(x => x.ClassSavingThrows)
                .Include(x => x.Race)
                .ToList();
        }

        public IEnumerable<Character> GetCharactersByUserId(string userId)
        {
            return GetCharacters().Where(x => x.UserId == userId);
        }


    }
}
