using DnDCharacterBuilder.Common.Enums;

namespace DnDCharacterBuilder.Domain.Entities
{
    public class CharacterAbility
    {
        public Guid CharacterId { get; set; }
        public virtual Ability Ability { get; set; }
        public bool ProficiencyBonus { get; set; }
        public int Value { get; set; }
    }
}
