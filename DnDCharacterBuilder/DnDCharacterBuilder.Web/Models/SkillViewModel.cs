namespace DnDCharacterBuilder.Web.Models
{
    public class SkillViewModel
    {
        public string Name { get; set; }
        public int AbilityValue { get; set; }
        public bool IsProficient { get; set; }
        public string ShortenedAbility { get; set; }
        public string Modifier { get => ((int)Math.Floor((AbilityValue - 10) / 2.0) + (IsProficient ? 1 : 0)) < 0 ? ((int)Math.Floor((AbilityValue - 10) / 2.0) + (IsProficient ? 1 : 0)).ToString() : "+" + ((int)Math.Floor((AbilityValue - 10) / 2.0) + (IsProficient ? 1 : 0)).ToString(); }

    }
}
