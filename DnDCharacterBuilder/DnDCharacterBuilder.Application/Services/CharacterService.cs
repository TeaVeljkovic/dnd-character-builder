using AutoMapper;
using DnDCharacterBuilder.Application.Interfaces;
using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Data.Interfaces;
using DnDCharacterBuilder.Domain.Entities;

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

        public async Task SaveCharacter(CreateCharacterModel characterToSave, string userId)
        {
            var character = _mapper.Map<Character>(characterToSave);

            character.UserId = new Guid(userId);

            _characterRepository.Add(character);
        }

        public void DeleteCharacter(Guid characterId)
        {
            _characterRepository.Delete(characterId);
        }

        public void RaceBonusCalculator(Character character)
        {
            //character.Class.ClassSkillProficiencieBonus
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
    }
}
