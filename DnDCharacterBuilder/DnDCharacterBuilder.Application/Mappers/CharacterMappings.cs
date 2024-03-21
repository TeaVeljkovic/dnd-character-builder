using AutoMapper;
using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Common.Enum;
using DnDCharacterBuilder.Common.Helpers;
using DnDCharacterBuilder.Domain.Entities;
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
                .ForMember(x => x.Name, y => y.MapFrom(x => x.CharacterName));
        }
    }
}
