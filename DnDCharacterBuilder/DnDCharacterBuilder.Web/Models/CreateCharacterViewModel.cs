using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DnDCharacterBuilder.Web.Models
{
    public class CreateCharacterViewModel
    {
        [MaxLength(50)]
        public string CharacterName { get; set; }

        public IEnumerable<SelectListItem> ClassToSelect { get;set; }
        public Guid ClassId { get; set; }
        public IEnumerable<SelectListItem> RaceToSelect { get;set; }
        public Guid RaceId { get; set; }
        public bool IsInspired { get; set; }
        public int PassivePerception { get; set; }
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
        public List<Skill> Skills { get; set; }
        public List<string> SelectedSkills { get; set; }
        //public ClassSkillSelection SelectedClassAttributes { get; set; }
    }
}
