using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilder.Application.Models
{
    public class ApiSkill
    {
        public string Name { get; set; }
        public string[] Desc { get; set; }
        public ListResult Ability_Score { get; set; }
    }
}
