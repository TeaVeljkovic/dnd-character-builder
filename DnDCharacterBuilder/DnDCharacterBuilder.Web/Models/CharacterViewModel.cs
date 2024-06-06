using DnDCharacterBuilder.Common.Enum;
using DnDCharacterBuilder.Domain.Entities;

namespace DnDCharacterBuilder.Web.Models
{
    public class CharacterViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        //public Guid RaceId { get; set; }
        public string Class { get; set; }
        //public Guid ClassId { get; set; }
        //public Race Race { get; set; }
        public List<SkillViewModel> Skills { get; set; }
        public bool IsInspired { get; set; }
        public string HitDIe { get; set; }
        public Alignment Alignment { get; set; }
        public string Background { get; set; }
        public int ExpPoints { get; set; }
        public string PersonalityTraits { get; set; }
        public string Ideals { get; set; }
        public string Bonds { get; set; }
        public string Flaws { get; set; }
        public int ArmorClass { get; set; }
        public int Speed { get; set; }
        public int HitPointsMax { get; set; }
        public int CurrentHitPoints { get; set; }
        public int Strength { get; set; }
        public bool StrengthProficiency { get; set; }
        public int StrengthModifier { get => ((int)Math.Floor((Strength - 10) / 2.0)); }
        public int StrengthSavingThrowModifier { get => ((int)Math.Floor((Strength - 10) / 2.0) + (StrengthProficiency ? 1 : 0)); }
        public int Dexterity { get; set; }
        public bool DexterityProficiency { get; set; }
        public int DexterityModifier { get => ((int)Math.Floor((Dexterity - 10) / 2.0)); }
        public int DexteritySavingThrowModifier { get => ((int)Math.Floor((Dexterity - 10) / 2.0) + (DexterityProficiency ? 1 : 0)); }
        public int Constitution { get; set; }
        public bool ConstitutionProficiency { get; set; }
        public int ConstitutionModifier { get => ((int)Math.Floor((Constitution - 10) / 2.0)); }
        public int ConstitutionSavingThrowModifier { get => ((int)Math.Floor((Constitution - 10) / 2.0) + (ConstitutionProficiency ? 1 : 0)); }
        public int Intelligence { get; set; }
        public bool IntelligenceProficiency { get; set; }
        public int IntelligenceModifier { get => ((int)Math.Floor((Intelligence - 10) / 2.0)); }
        public int IntelligenceSavingThrowModifier { get => ((int)Math.Floor((Intelligence - 10) / 2.0) + (IntelligenceProficiency ? 1 : 0)); }
        public int Wisdom { get; set; }
        public bool WisdomProficiency { get; set; }
        public int WisdomModifier { get => ((int)Math.Floor((Wisdom - 10) / 2.0)); }
        public int WisdomSavingThrowModifier { get => ((int)Math.Floor((Wisdom - 10) / 2.0) + (WisdomProficiency ? 1 : 0)); }
        public int Charisma { get; set; }
        public bool CharismaProficiency { get; set; }
        public int CharismaModifier { get => ((int)Math.Floor((Charisma - 10) / 2.0)); }
        public int CharismaSavingThrowModifier { get => ((int)Math.Floor((Charisma - 10) / 2.0) + (CharismaProficiency ? 1 : 0)); }
        public string GetStringModifier(int mod)
        {
            var predicate = mod < 0 ? mod.ToString() : "+" + mod.ToString();
            return $"{predicate}";
        }
    }
}
