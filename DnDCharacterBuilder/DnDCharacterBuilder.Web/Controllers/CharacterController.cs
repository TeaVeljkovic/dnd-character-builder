using AutoMapper;
using DnDCharacterBuilder.Application.Interfaces;
using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Domain.Entities;
using DnDCharacterBuilder.Web.Models;
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

        public CharacterController(IClassService classService, IMapper mapper, ICharacterService characterService, IRaceService raceService)
        {
            _classService = classService;
            _mapper = mapper;
            _characterService = characterService;
            _raceService = raceService;
        }

        [HttpGet]
        public IActionResult CreateCharacter()
        {
            var classes = _classService?.GetAllClasses();
            var races = _raceService?.GetAllRaces();

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
                Flaws = ""
            };
            
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateCharacter(CreateCharacterViewModel model)
        {
            var characterUserInput = _mapper.Map<CreateCharacterModel>(model);
            //get userId from context
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var newCharacter = _characterService.SaveCharacter(characterUserInput, userId);
            return Ok();
        }
    }
}
