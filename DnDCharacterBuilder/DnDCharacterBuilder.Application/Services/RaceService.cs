using AutoMapper;
using DnDCharacterBuilder.Application.Interfaces;
using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Common.Constants;
using DnDCharacterBuilder.Common.Helpers;
using DnDCharacterBuilder.Data.Entities;
using DnDCharacterBuilder.Data.Interfaces;
using DnDCharacterBuilder.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilder.Application.Services
{
    public class RaceService : IRaceService
    {
        private readonly IRepository<Race> _raceRepository;
        private readonly IMapper _mapper;

        public RaceService(IRepository<Race> raceRepository, IMapper mapper)
        {
            _raceRepository=raceRepository;
            _mapper=mapper;
        }

        public async Task SeedRaces()
        {
            if (_raceRepository.GetAll().Count != 0)
            {
                return;
            }

            using var client = new HttpClient();
            var response = await client.GetAsync(ApiRoutesExternal.Races);

            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            var responseProperties = JsonConvert.DeserializeObject<ListResponse>(responseJson);

            foreach (var race in responseProperties.Results)
            {
                var raceResponse = await client.GetAsync(ApiRoutesExternal.Races + "/" + race.Index);
                raceResponse.EnsureSuccessStatusCode();

                var raceJson = await raceResponse.Content.ReadAsStringAsync();
                var raceProperties = JsonConvert.DeserializeObject<ApiRace>(raceJson);

                var raceToAdd = _mapper.Map<Race>(raceProperties);
                var abilityProficencies = new List<RaceAbilityBonus>();

                foreach (var ability in raceProperties.Ability_Bonuses)
                {
                    abilityProficencies.Add(new RaceAbilityBonus
                    {
                        Ability = EnumHelpers.MapAbility(ability.Ability_Score.Name),
                        Value = ability.Bonus
                    });

                    raceToAdd.RaceAbilities = abilityProficencies;
                }

                _raceRepository.Add(raceToAdd);

            }
        }
    }
}
