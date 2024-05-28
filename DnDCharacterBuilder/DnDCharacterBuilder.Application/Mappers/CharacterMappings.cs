using AutoMapper;
using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Common.Enum;
using DnDCharacterBuilder.Common.Enums;
using DnDCharacterBuilder.Common.Helpers;
using DnDCharacterBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilder.Application.Mappers
{
    public class CharacterMappings : Profile
    {
        public CharacterMappings()
        {
            CreateMap<CreateCharacterModel, Character>()
                .ForMember(x => x.Alignment, y => y.MapFrom(x => EnumHelpers.MapAlignment(x.Alignment)))
                .ForMember(x => x.Name, y => y.MapFrom(x => x.CharacterName))
                //.ForMember(x => x.CharacterSkillProficiencies, y => y.MapFrom(x => x.SelectedSkills.Select(s => new CharacterSkillProficiency { SkillId = s }).ToList()))
                .AfterMap(MapAbilities)
                .AfterMap((src, dest) => dest.CharacterSkillProficiencies = src.SelectedSkills.Select(st => new CharacterSkillProficiency { SkillId = st }).ToList());    
        }
        private void MapAbilities(CreateCharacterModel src, Character dest)
        {
            dest.CharacterAbilities = new List<CharacterAbility>()
            {
                new CharacterAbility
                {
                    Ability = Common.Enums.Ability.Strength,
                    Value = src.Strength
                },
                new CharacterAbility
                {
                    Ability = Common.Enums.Ability.Dexterity,
                    Value = src.Dexterity
                },
                new CharacterAbility
                {
                    Ability = Common.Enums.Ability.Constitution,
                    Value = src.Constitution
                },
                new CharacterAbility
                {
                    Ability = Common.Enums.Ability.Intelligence,
                    Value = src.Intelligence
                },
                new CharacterAbility
                {
                    Ability = Common.Enums.Ability.Wisdom,
                    Value = src.Wisdom
                },
                new CharacterAbility
                {
                    Ability = Common.Enums.Ability.Charisma,
                    Value = src.Charisma
                }
            };

        }
    }
}
