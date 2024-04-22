using AutoMapper;
using DnDCharacterBuilder.Domain.Entities;
using DnDCharacterBuilder.Web.Models;

namespace DnDCharacterBuilder.Web.Mappers
{
    public class ClassModelMappings : Profile
    {
        public ClassModelMappings()
        {
            CreateMap<Class, ClassViewModel>();
        }
    }
}
