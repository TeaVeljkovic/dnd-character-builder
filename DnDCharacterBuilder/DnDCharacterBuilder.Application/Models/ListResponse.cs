using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilder.Application.Models
{
    public class ListResponse
    {
        public int Count { get; set; }
        public List<ListResult> Results { get; set; }
    }
}
