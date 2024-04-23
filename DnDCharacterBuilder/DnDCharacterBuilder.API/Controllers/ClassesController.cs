using DnDCharacterBuilder.API.Models;
using DnDCharacterBuilder.Application.Interfaces;
using DnDCharacterBuilder.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DnDCharacterBuilder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public IActionResult GetClasses()
        {
            var classes = _classService.GetAllClasses();

            if (classes == null)
            {
                return NotFound();
            }

            return Ok(classes);
        }

        [HttpGet("{id}")]
        public IActionResult GetClass(Guid id)
        {
            var classById = _classService.GetClassById(id);

            if (classById == null)
            {
                return NotFound();
            }

            return Ok(classById);
        }

        [HttpPost]
        public IActionResult CreateClass(ClassApiModel newClass)
        {
            if (newClass == null)
            {
                return BadRequest("Class model empty, please provide the neccessary information");
            }

            _classService.UpdateClasses(newClass);

            return Ok("New HomeBrew Class created successfully");
        }
    }
}
