using AutoMapper;
using DnDCharacterBuilder.Common.Enums;
using DnDCharacterBuilder.Domain.Entities;
using DnDCharacterBuilder.Web.Models;

namespace DnDCharacterBuilder.Web.Mappers
{
    public class CharacterMappings : Profile
    {
        public CharacterMappings()
        {
            CreateMap<Character, CharacterViewModel>()
                .ForMember(x => x.Strength, y => y.MapFrom(x => x.CharacterAbilities.Where(ca => ca.Ability == Ability.Strength).FirstOrDefault().Value))
                .ForMember(x => x.Dexterity, y => y.MapFrom(x => x.CharacterAbilities.Where(ca => ca.Ability == Ability.Dexterity).FirstOrDefault().Value))
                .ForMember(x => x.Charisma, y => y.MapFrom(x => x.CharacterAbilities.Where(ca => ca.Ability == Ability.Charisma).FirstOrDefault().Value))
                .ForMember(x => x.Intelligence, y => y.MapFrom(x => x.CharacterAbilities.Where(ca => ca.Ability == Ability.Intelligence).FirstOrDefault().Value))
                .ForMember(x => x.Constitution, y => y.MapFrom(x => x.CharacterAbilities.Where(ca => ca.Ability == Ability.Constitution).FirstOrDefault().Value))
                .ForMember(x => x.Wisdom, y => y.MapFrom(x => x.CharacterAbilities.Where(ca => ca.Ability == Ability.Wisdom).FirstOrDefault().Value));
        }
    }
}
