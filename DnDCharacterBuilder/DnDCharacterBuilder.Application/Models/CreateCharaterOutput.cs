using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilder.Application.Models
{
    public class CreateCharaterOutput
    {
        public bool IsSuccessful { get => string.IsNullOrEmpty(ErrorMessage); }
        public string ErrorMessage { get; set; }
        public Guid CharacterId { get; set; }
    }
}
