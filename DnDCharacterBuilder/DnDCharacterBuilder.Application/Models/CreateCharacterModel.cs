using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilder.Application.Models
{
    public class CreateCharacterModel
    {
        public string CharacterName { get; set; }
        public Guid ClassId { get; set; }
        public Guid RaceId { get; set; }
        public string Alignment { get; set; }
        public string Background { get; set; }
        public int ExpPoints { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public string PersonalityTraits { get; set; }
        public string Ideals { get; set; }
        public string Bonds { get; set; }
        public string Flaws { get; set; }
        public int ArmorClass { get; set; }
        public int HitPointsMax { get; set; }
        public int CurrentHitPoints { get; set; }
    }
}
