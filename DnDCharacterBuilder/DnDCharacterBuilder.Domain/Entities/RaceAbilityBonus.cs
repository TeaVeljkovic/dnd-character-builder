using DnDCharacterBuilder.Common.Enums;

namespace DnDCharacterBuilder.Domain.Entities
{
    public class RaceAbilityBonus
    {
        public Guid RaceId { get; set; }
        public Ability Ability { get; set; }
        public int Value { get; set; }
    }
}
