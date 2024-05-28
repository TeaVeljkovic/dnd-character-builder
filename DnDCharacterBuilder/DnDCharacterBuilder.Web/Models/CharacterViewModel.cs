using DnDCharacterBuilder.Common.Enum;
using DnDCharacterBuilder.Domain.Entities;

namespace DnDCharacterBuilder.Web.Models
{
    public class CharacterViewModel
    {
        public string Name { get; set; }
        public Guid RaceId { get; set; }
        public Class Class { get; set; }
        public Guid ClassId { get; set; }
        public Race Race { get; set; }
        public List<Skill> Skills { get; set; }
        public bool IsInspired { get; set; }
        public Alignment Alignment { get; set; }
        public string Background { get; set; }
        public int ExpPoints { get; set; }
        public virtual IEnumerable<CharacterAbility> CharacterAbilities { get; set; }
        public virtual IEnumerable<CharacterSkillProficiency> CharacterSkillProficiencies { get; set; }
        public string PersonalityTraits { get; set; }
        public string Ideals { get; set; }
        public string Bonds { get; set; }
        public string Flaws { get; set; }
        public int ArmorClass { get; set; }
        public int HitPointsMax { get; set; }
        public int CurrentHitPoints { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
    }
}
