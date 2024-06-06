using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilder.Application.Models
{
    public class ClassSkillSelection
    {
        public string ProficiencyDescription { get; set; }
        public int ProficiencyChoiceCount { get; set; }
        public List<string> ClassSavingThrows { get; set; }
        public List<Guid> ClassSkillProficiencieBonus { get; set; }
        public string HitDie { get; set; }
    }
}
