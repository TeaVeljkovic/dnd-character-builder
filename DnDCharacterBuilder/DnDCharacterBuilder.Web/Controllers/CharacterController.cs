using AutoMapper;
using DnDCharacterBuilder.Application.Interfaces;
using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Domain.Entities;
using DnDCharacterBuilder.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace DnDCharacterBuilder.Web.Controllers
{
    public class CharacterController : Controller
    {
        private readonly IClassService _classService;
        private readonly IRaceService _raceService;
        private readonly IMapper _mapper;
        private readonly ICharacterService _characterService;
        private readonly ISkillService _skillService;

        public CharacterController(IClassService classService, IMapper mapper, ICharacterService characterService, IRaceService raceService, ISkillService skillService)
        {
            _classService = classService;
            _mapper = mapper;
            _characterService = characterService;
            _raceService = raceService;
            _skillService = skillService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateCharacter()
        {
            var classes = _classService?.GetAllClasses();
            var races = _raceService?.GetAllRaces();
            var skills = _skillService?.GetAllSkills();

            var model = new CreateCharacterViewModel
            {
                ClassToSelect = classes.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),

                RaceToSelect = races.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),

                Alignment = "",
                Background = "",

                Strength = 0,
                Dexterity = 0,
                Constitution = 0,
                Intelligence = 0,
                Wisdom = 0,
                Charisma = 0,

                PersonalityTraits = "",
                Ideals = "",
                Bonds = "",
                Flaws = "",

                Skills = skills.ToList()
            };
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCharacter(CreateCharacterViewModel model)
        {
            var characterUserInput = _mapper.Map<CreateCharacterModel>(model);
            //get userId from context
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var newCharacter = await _characterService.SaveCharacter(characterUserInput, userId);

            if (!newCharacter.IsSuccessful)
            {
                return BadRequest(newCharacter.ErrorMessage);
            }
            
            return RedirectToAction("CreateCharacter");
        }

        [Authorize]
        public IActionResult ListCharacters()
        {
            var characters = _characterService.GetCharactersByUserId(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var model = _mapper.Map<List<CharacterViewModel>>(characters);

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ShowCharacter(Guid id)
        {
            var characters = _characterService.GetCharactersByUserId(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var characterById = characters.Where(x => x.Id == id).FirstOrDefault();

            var model = _mapper.Map<CharacterViewModel>(characterById);
            model.Skills = _skillService.GetAllSkills().ToList();

            return View(model);
        }
    }
}
