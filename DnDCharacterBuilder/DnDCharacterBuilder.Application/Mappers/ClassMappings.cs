using AutoMapper;
using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Common.Helpers;
using DnDCharacterBuilder.Domain.Entities;

namespace DnDCharacterBuilder.Application.Mappers
{
    public class ClassMappings : Profile
    {
        public ClassMappings()
        {
            CreateMap<ApiClass, Class>()
                .ForMember(x => x.ProficiencyDescription, y => y.MapFrom(x => x.Proficiency_Choices.FirstOrDefault().Desc))
                .ForMember(x => x.HitDie, y => y.MapFrom(x => x.Hit_Die))
                .ForMember(x => x.ProficiencyChoiceCount, y => y.MapFrom(x => x.Proficiency_Choices.FirstOrDefault().Choose))
                .AfterMap((src,dest) => dest.ClassSavingThrows = src.Saving_Throws.Select(st => new ClassSavingThrow { Ability = EnumHelpers.MapAbility(st.Index)}).ToList());
        }
    }
}
