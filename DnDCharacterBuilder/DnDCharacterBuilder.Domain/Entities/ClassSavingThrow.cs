using DnDCharacterBuilder.Common.Enums;

namespace DnDCharacterBuilder.Domain.Entities
{
    public class ClassSavingThrow
    {
        public Guid ClassId { get; set; }
        public Ability Ability { get; set; }
    }
}
