using DnDCharacterBuilder.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilder.Common.Helpers
{
    public static class EnumHelpers
    {
        public static Ability MapAbility(string ability) => ability.ToLower() switch
        {
            "str" => Ability.Strength,
            "dex" => Ability.Dexterity,
            "con" => Ability.Constitution,
            "int" => Ability.Intelligence,
            "wis" => Ability.Wisdom,
            "cha" => Ability.Charisma,
            _ => throw new ArgumentOutOfRangeException(nameof(ability), $"Not expected ability value: {ability}")
        };
    }
}
