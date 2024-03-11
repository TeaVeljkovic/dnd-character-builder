namespace DnDCharacterBuilder.Domain.Entities
{
    public class Class : BaseClass
    {
        public string Name { get; set; }
        public string ProficiencyDescription { get; set; }
        public string HitDie { get; set; }
        public virtual ICollection<ClassSavingThrow> ClassSavingThrows { get; set; }
        public int ProficiencyChoiceCount { get; set; }
        public virtual ICollection<ClassSkillProficiencieBonus> ClassSkillProficiencieBonus { get; set; }
    }
}
