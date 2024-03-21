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

        public CharacterService(IRepository<Character> characterRepository, IMapper mapper, IRepository<Class> classRepository, IRepository<Race> raceRepository)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
            _classRepository = classRepository;
            _raceRepository = raceRepository;
        }

        public async Task SaveCharacter(CreateCharacterModel characterToSave, string userId)
        {
            var character = _mapper.Map<Character>(characterToSave);
            var classToAdd = _classRepository.GetAll().Where(x => x.Id == characterToSave.ClassId).FirstOrDefault();
            var raceToAdd = _raceRepository.GetAll().Where(x => x.Id == characterToSave.RaceId).FirstOrDefault();

            character.Class = classToAdd;
            character.Race = raceToAdd;
            character.UserId = new Guid(userId);

            _characterRepository.Update(character);
        }


    }
}
