using AutoMapper;
using DnDCharacterBuilder.Domain.Entities;
using DnDCharacterBuilder.Web.Models;

namespace DnDCharacterBuilder.Web.Mappers
{
    public class RaceModelMappings : Profile
    {
        public RaceModelMappings()
        {
            CreateMap<Race, RaceViewModel>();
        }
    }
}
