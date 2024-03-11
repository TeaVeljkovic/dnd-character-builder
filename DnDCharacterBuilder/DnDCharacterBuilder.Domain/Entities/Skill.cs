using DnDCharacterBuilder.Common.Enums;

namespace DnDCharacterBuilder.Domain.Entities
{
    public class Skill : BaseClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Ability RelatedAbility { get; set; }
    }
}
