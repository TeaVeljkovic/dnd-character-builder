using DnDCharacterBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilder.Application.Interfaces
{
    public interface IClassService
    {
        Task SeedClasses();
        IEnumerable<Class> GetAllClasses();
    }
}
