using DnDCharacterBuilder.Domain.Entities;

namespace DnDCharacterBuilder.API.Models
{
    public class ClassApiModel
    {
        public string Name { get; set; }
        public string ProficiencyDescription { get; set; }
        public string HitDie { get; set; }
        public IEnumerable<string> Abilities { get; set; }
        public int ProficiencyChoiceCount { get; set; }
        public IEnumerable<string> SkillProficiencies { get; set; }
    }
}
