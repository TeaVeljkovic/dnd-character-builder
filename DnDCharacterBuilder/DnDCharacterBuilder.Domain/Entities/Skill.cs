using DnDCharacterBuilder.Common.Enums;

namespace DnDCharacterBuilder.Domain.Entities
{
    public class Skill : BaseClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Ability RelatedAbility { get; set; }
        public string TruncatedName => RelatedAbility.ToString().Substring(0, 3).ToUpper();
    }
}
