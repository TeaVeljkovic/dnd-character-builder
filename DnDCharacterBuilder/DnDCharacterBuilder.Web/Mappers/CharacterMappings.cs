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
                .ForMember(x => x.Wisdom, y => y.MapFrom(x => x.CharacterAbilities.Where(ca => ca.Ability == Ability.Wisdom).FirstOrDefault().Value))
                .ForMember(x => x.StrengthProficiency, y => y.MapFrom(x => x.Class.ClassSavingThrows.Any(ca => ca.Ability == Ability.Strength)))
                .ForMember(x => x.DexterityProficiency, y => y.MapFrom(x => x.Class.ClassSavingThrows.Any(ca => ca.Ability == Ability.Dexterity)))
                .ForMember(x => x.CharismaProficiency, y => y.MapFrom(x => x.Class.ClassSavingThrows.Any(ca => ca.Ability == Ability.Charisma)))
                .ForMember(x => x.IntelligenceProficiency, y => y.MapFrom(x => x.Class.ClassSavingThrows.Any(ca => ca.Ability == Ability.Intelligence)))
                .ForMember(x => x.ConstitutionProficiency, y => y.MapFrom(x => x.Class.ClassSavingThrows.Any(ca => ca.Ability == Ability.Constitution)))
                .ForMember(x => x.WisdomProficiency, y => y.MapFrom(x => x.Class.ClassSavingThrows.Any(ca => ca.Ability == Ability.Wisdom)))
                .ForMember(x => x.Class, y => y.MapFrom(x => x.Class.Name))
                .ForMember(x => x.Race, y => y.MapFrom(x => x.Race.Name))
                .ForMember(x => x.HitDIe, y => y.MapFrom(x => x.Class.HitDie))
                .AfterMap(MapSkills);
        }

        private void MapSkills (Character src, CharacterViewModel dest)
        {
            dest.Skills = src.CharacterSkillProficiencies.Select(x =>
                new SkillViewModel
                {
                    Name = x.Skill.Name,
                    ShortenedAbility = x.Skill.RelatedAbility.ToString().Substring(0, 3).ToUpper(),
                    IsProficient = x.isProficient,
                    AbilityValue = src.CharacterAbilities.FirstOrDefault(ca => ca.Ability == x.Skill.RelatedAbility).Value,
                }
            ).ToList();
        }
    }
}
