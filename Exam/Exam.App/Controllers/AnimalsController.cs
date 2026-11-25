using Exam.App.Services;
using Exam.App.Services.Dtos.Animals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exam.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int? animalSpeciesId,
            [FromQuery] int? cageId,
            [FromQuery] bool unassigned = false)
        {
            return Ok(await _animalService.GetAllAsync(animalSpeciesId, cageId, unassigned));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _animalService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAnimalDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _animalService.CreateAsync(dto);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAnimalDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest (ModelState);
            }

            var updated = await _animalService.UpdateAsync(id, dto);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete (int id)
        {
            await _animalService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("species")]
        public async Task <IActionResult> GetAllSpecies ()
        {
            return Ok (await _animalService.GetSpeciesAsync());
        }

        [HttpGet("cages")]
        public async Task <IActionResult> GetCagesAsync ()
        {
            return Ok (await _animalService.GetCagesAsync());
        }
    }
}
