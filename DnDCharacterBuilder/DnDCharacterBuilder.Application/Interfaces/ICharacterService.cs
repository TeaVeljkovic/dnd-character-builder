using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilder.Application.Interfaces
{
    public interface ICharacterService
    {
        Task<CreateCharaterOutput> SaveCharacter(CreateCharacterModel characterToSave, string userId);
        void DeleteCharacter(Guid characterId);
        IEnumerable<Character> GetCharacters();
        IEnumerable<Character> GetCharactersByUserId(string userId);
    }
}
