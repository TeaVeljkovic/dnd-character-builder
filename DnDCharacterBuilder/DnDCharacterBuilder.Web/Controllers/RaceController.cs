using AutoMapper;
using DnDCharacterBuilder.Application.Interfaces;
using DnDCharacterBuilder.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DnDCharacterBuilder.Web.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceService _raceService;
        private readonly IMapper _mapper;

        public RaceController(IRaceService raceService, IMapper mapper)
        {
            _raceService = raceService;
            _mapper = mapper;
        }

        public IActionResult ListRaces()
        {
            var races = _raceService?.GetAllRaces();

            var model = _mapper.Map<List<RaceViewModel>>(races);

            return View(model);
        }
    }
}
