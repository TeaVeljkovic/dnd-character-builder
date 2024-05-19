using AutoMapper;
using DnDCharacterBuilder.Application.Interfaces;
using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Common.Constants;
using DnDCharacterBuilder.Data.Interfaces;
using DnDCharacterBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

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
            var classes = _classReopository.GetAsQueryable()
                .Include(x => x.ClassSavingThrows)
                .Include(x => x.ClassSkillProficiencieBonus);
            return classes.FirstOrDefault(x => x.Id == Id);
        }

        public ClassSkillSelection GetClassAttributesById(Guid Id)
        {
            var classes = GetClassById(Id);
            //Console.WriteLine("class is: ", classes);
            //var selected = _mapper.Map<ClassSkillSelection>(classes);
            //Console.WriteLine("selected are: ", selected);
            // savingthrows i profs se null, shto znachi od baza ne se zemeni ko shto treba ???
            var selected = new ClassSkillSelection
            {
                ClassSavingThrows = classes.ClassSavingThrows.Select(x => x.Ability.ToString().Substring(0, 3).ToUpper()).ToList(),
                ClassSkillProficiencieBonus = classes.ClassSkillProficiencieBonus.Select(x => x.ClassId).ToList(),
                ProficiencyChoiceCount = classes.ProficiencyChoiceCount,
                ProficiencyDescription = classes.ProficiencyDescription,
            };
            return selected;
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
