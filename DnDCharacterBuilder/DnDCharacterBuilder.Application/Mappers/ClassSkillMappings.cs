using AutoMapper;
using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Domain.Entities;

namespace DnDCharacterBuilder.Application.Mappers
{
    public class ClassSkillMappings : Profile
    {
        public ClassSkillMappings()
        {
            CreateMap<Class, ClassSkillSelection>()
                .ForMember(x => x.ClassSavingThrows, y => y.MapFrom(x => x.ClassSavingThrows.Select(st => st.Ability).ToList()))
                .ForMember(x => x.ClassSkillProficiencieBonus, y => y.MapFrom(x => x.ClassSkillProficiencieBonus.Select(cspb => cspb.SkillId).ToList()));
        }
    }
}
