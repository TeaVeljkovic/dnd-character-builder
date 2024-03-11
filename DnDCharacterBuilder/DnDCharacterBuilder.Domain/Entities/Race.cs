namespace DnDCharacterBuilder.Domain.Entities
{
    public class Race : BaseClass
    {
        public string Name { get; set; }
        public virtual IEnumerable<Character> Characters { get; set; }
        public int BonusAbilities { get; set; }
        public virtual IEnumerable<RaceAbilityBonus> RaceAbilities { get; set; }
        public string AgeInfo { get; set; }
        public string Size { get; set; }
        public string SizeInfo { get; set; }
        public string AlignmentInfo { get; set; }
        public int Speed { get; set; }
    }
}
