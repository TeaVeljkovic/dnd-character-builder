using AutoMapper;
using DnDCharacterBuilder.API.Models;
using DnDCharacterBuilder.Common.Helpers;
using DnDCharacterBuilder.Domain.Entities;

namespace DnDCharacterBuilder.API.Mappers
{
    public class ClassApiMappings : Profile
    {
        public ClassApiMappings()
        {
            CreateMap<ClassApiModel, Class>()
                .AfterMap((src, dest) => dest.ClassSavingThrows = src.SkillProficiencies.Select(st => new ClassSavingThrow { Ability = EnumHelpers.MapAbility(st)}).ToList());
        }

        //private ICollection<ClassSkillProficiencieBonus> AddSkills(ClassApiModel model)
        //{
        //    foreach (var skill in model.SkillProficiencies)
        //    {

        //    }
        //}
    }
}
