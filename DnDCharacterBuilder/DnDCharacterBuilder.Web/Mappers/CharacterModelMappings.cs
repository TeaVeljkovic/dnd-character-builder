using AutoMapper;
using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Web.Models;

namespace DnDCharacterBuilder.Web.Mappers
{
    public class CharacterModelMappings : Profile
    {
        public CharacterModelMappings()
        {
            CreateMap<CreateCharacterViewModel, CreateCharacterModel>();
        }
    }
}
