using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilder.Application.Interfaces
{
    public interface IRaceService
    {
        Task SeedRaces();
        IEnumerable<Race> GetAllRaces();
        Race GetRaceById(Guid Id);
        RaceSelection GetRaceAttributesById(Guid Id);
    }
}
