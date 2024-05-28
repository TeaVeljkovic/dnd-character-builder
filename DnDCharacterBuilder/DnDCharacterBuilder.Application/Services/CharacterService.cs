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
            var characterClass = _classRepository.GetById(characterToSave.ClassId);
            var numberOfSelectedSkills = characterToSave.SelectedSkills.Count;

            if (numberOfSelectedSkills > characterClass.ProficiencyChoiceCount)
            {
                return new CreateCharaterOutput { ErrorMessage = "Cannot select more than " + numberOfSelectedSkills + " skills."};
            }

            foreach (var skill in characterToSave.SelectedSkills)
            {
                if (characterClass.ClassSkillProficiencieBonus.Select(x => x.SkillId == skill) == null)
                {
                    return new CreateCharaterOutput { ErrorMessage = "Cannot select unavailable skills." };
                }
            }

            var character = _mapper.Map<Character>(characterToSave);

            character.UserId = userId;
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
                .Include(x => x.Class)
                .Include(x => x.Race)
                .ToList();
        }

        public IEnumerable<Character> GetCharactersByUserId(string userId)
        {
            return GetCharacters().Where(x => x.UserId == userId);
        }
    }
}
