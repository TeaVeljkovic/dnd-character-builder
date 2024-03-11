using DnDCharacterBuilder.Application.Interfaces;
using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Data.Interfaces;
using DnDCharacterBuilder.Domain.Entities;
using DnDCharacterBuilder.Common.Constants;
using Newtonsoft.Json;
using AutoMapper;

namespace DnDCharacterBuilder.Application.Services
{
    public class SkillService : ISkillService
    {
        private readonly IRepository<Skill> _skillRepository;
        private readonly IMapper _mapper;
        public SkillService(IRepository<Skill> skillRepository, IMapper mapper) { 
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task SeedSkills()
        {
            if (_skillRepository.GetAll().Count() != 0)
            {
                return;
            }
            
            using var client = new HttpClient();
            var response = await client.GetAsync(ApiRoutesExternal.Skills);

            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            var responseProperties = JsonConvert.DeserializeObject<ListResponse>(responseJson);
                
            foreach (var skill in responseProperties.Results)
            {
                await AddSkill(client, skill);
            }
        }

        private async Task AddSkill(HttpClient client, ListResult skill)
        {
            var skillResponse = await client.GetAsync(ApiRoutesExternal.Skills + "/" + skill.Index);
            skillResponse.EnsureSuccessStatusCode();

            var skillJson = await skillResponse.Content.ReadAsStringAsync();
            var skillProperties = JsonConvert.DeserializeObject<ApiSkill>(skillJson);

            if (skillProperties != null)
            {
                var convertedSkill = _mapper.Map<Skill>(skillProperties);

                _skillRepository.Add(convertedSkill);
            }
        }

        public void Foo()
        {
            //get all classes
            //foreach
            //var class = map(ova sto sum go zemal od api)
            //var skills = _skillsContext.GetAll()
            //map class
            //foreach prof_choice
            //var currentSkill = skills.FirstOrDefault(x => profChoice.Name.Contains(x.name))
            // class.ClassSkillProficiencieBonus.Add(new ClassSkillProficiencieBonus{
            //      skillId = currentSkill.Id
            // })

        }
    }
}
