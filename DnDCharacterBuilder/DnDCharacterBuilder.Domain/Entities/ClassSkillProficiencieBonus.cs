namespace DnDCharacterBuilder.Domain.Entities
{
    public class ClassSkillProficiencieBonus
    {
        public Guid ClassId { get; set; }
        public Guid SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
