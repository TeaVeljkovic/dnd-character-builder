using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilder.Application.Models
{
    public class ApiClass
    {
        public string Name { get; set; }
        public int Hit_Die { get; set; }
        public IEnumerable<ApiProficiencyChoices> Proficiency_Choices { get; set; }
        public IEnumerable<ListResult> Saving_Throws { get; set; }
    }
}
