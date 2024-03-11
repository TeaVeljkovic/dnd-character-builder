using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilder.Application.Models
{
    public class ApiRace
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public IEnumerable<ApiAbilityBonus> Ability_Bonuses { get; set; }
        public string Age { get; set; }
        public string Alignment { get; set; }
        public string Size { get; set; }
        public string Size_Description { get; set; }
    }
}
