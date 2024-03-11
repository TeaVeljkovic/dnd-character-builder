using AutoMapper;
using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Common.Enums;
using DnDCharacterBuilder.Common.Helpers;
using DnDCharacterBuilder.Domain.Entities;
using Microsoft.Identity.Client;

namespace DnDCharacterBuilder.Application.Mappers
{
    public class SkillMappings : Profile
    {
        public SkillMappings()
        {
            CreateMap<ApiSkill, Skill>()
                .ForMember(x => x.RelatedAbility, y => y.MapFrom(x => EnumHelpers.MapAbility(x.Ability_Score.Index)))
                .ForMember(x => x.Description, y => y.MapFrom(x => x.Desc.FirstOrDefault()));
        }
    }
}
