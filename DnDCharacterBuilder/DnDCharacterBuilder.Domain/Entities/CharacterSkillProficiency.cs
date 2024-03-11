namespace DnDCharacterBuilder.Domain.Entities
{
    public class CharacterSkillProficiency
    {
        public Guid CharacterId { get; set; }
        public Guid SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
