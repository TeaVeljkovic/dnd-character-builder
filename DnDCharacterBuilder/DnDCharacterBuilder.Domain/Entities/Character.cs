using DnDCharacterBuilder.Common.Enum;

namespace DnDCharacterBuilder.Domain.Entities
{
    public class Character : BaseClass
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public Guid RaceId { get; set; }
        public virtual Race Race { get; set; }
        public Guid ClassId { get; set; }
        public virtual Class Class { get; set; }
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
    }
}
