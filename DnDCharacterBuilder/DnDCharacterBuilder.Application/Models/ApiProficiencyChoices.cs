using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilder.Application.Models
{
    public class ApiProficiencyChoices
    {
        public string Desc { get; set; }
        public int Choose { get; set; }
        public ClassProficienciesOptions From { get; set; }
    }

    public class ClassProficienciesOptions
    {
        public IEnumerable<ClasProficienciesItems> Options { get; set; }
    }

    public class ClasProficienciesItems
    {
        public ListResult Item { get; set; }
    }
}
