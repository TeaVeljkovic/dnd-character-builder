using AutoMapper;
using DnDCharacterBuilder.Application.Interfaces;
using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Common.Constants;
using DnDCharacterBuilder.Data.Interfaces;
using DnDCharacterBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DnDCharacterBuilder.Application.Services
{
    public class ClassService : IClassService
    {
        private readonly IRepository<Class> _classReopository;
        private readonly IMapper _mapper;
        private readonly IRepository<Skill> _skillRepository;

        public ClassService(IRepository<Class> classReopository, IMapper mapper, IRepository<Skill> skillRepository)
        {
            _classReopository = classReopository;
            _mapper = mapper;
            _skillRepository = skillRepository;
        }

        public IEnumerable<Class> GetAllClasses()
        {
            return _classReopository.GetAll();
        }

        public Class GetClassById(Guid Id)
        {
            return _classReopository.GetAll().FirstOrDefault(x => x.Id == Id);
        }

        public void UpdateClasses(Class newClass)
        {
            _classReopository.Add(newClass);
        }

        public async Task SeedClasses()
        {
            //var class1 = _classReopository.GetAsQueryable().Include(x => x.ClassSkillProficiencieBonus).ThenInclude(x => x.Skill).Include(x => x.ClassSavingThrows).FirstOrDefault();
            
            if (_classReopository.GetAll().Count != 0) 
            {
                return;
            }

            using var client = new HttpClient();
            var response = await client.GetAsync(ApiRoutesExternal.Classes);

            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            var responseProperties = JsonConvert.DeserializeObject<ListResponse>(responseJson);

            var allSkills = _skillRepository.GetAll();

            foreach (var classes in responseProperties.Results)
            {
                await AddClass(client, allSkills, classes);

            }
        }

        private async Task AddClass(HttpClient client, List<Skill> allSkills, ListResult classes)
        {
            var classResponse = await client.GetAsync(ApiRoutesExternal.Classes + "/" + classes.Index);
            classResponse.EnsureSuccessStatusCode();

            var classJson = await classResponse.Content.ReadAsStringAsync();
            var classProperties = JsonConvert.DeserializeObject<ApiClass>(classJson);

            var classToAdd = _mapper.Map<Class>(classProperties);

            var skills = classProperties.Proficiency_Choices.FirstOrDefault().From.Options.Select(x => x.Item.Name);
            var skillProficencies = new List<ClassSkillProficiencieBonus>();

            foreach (var skill in skills)
            {
                var currentSkill = allSkills.FirstOrDefault(x => skill.Contains(x.Name));
                skillProficencies.Add(new ClassSkillProficiencieBonus
                {
                    SkillId = currentSkill.Id
                });
            }
            classToAdd.ClassSkillProficiencieBonus = skillProficencies;

            _classReopository.Add(classToAdd);
        }
    }
}
