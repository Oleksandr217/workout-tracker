using Microsoft.AspNetCore.Mvc;
using src.Interfaces;
using src.Models.DTOs;

namespace src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;
        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var workout = await _workoutService.GetById(id);
            if (workout == null)
            {
                return NotFound(new { Message = $"Тренування з id {id} не знайдено" });
            }
            return Ok(workout);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var workouts = await _workoutService.GetAll();
            return Ok(workouts);
        }

        [HttpGet("by-date")]
        public async Task<IActionResult> GetByDate([FromQuery] DateTime date)
        {
            var result = await _workoutService.GetByDate(date);
            if (result == null || !result.Any())
                return NotFound(new { Message = "Не знайдено тренувань за вказаною датою" });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WorkoutDTO workoutDTO)
        {
            if (workoutDTO == null)
                return BadRequest();

            var result = await _workoutService.Create(workoutDTO);
            if (result)
            {
                return StatusCode(StatusCodes.Status201Created, workoutDTO);
            }
            return BadRequest("Не вдалося створити тренування");
        }

        [HttpPatch("{workoutId}/exercises")]
        public async Task<IActionResult> AddExercises([FromBody] List<ExerciseDTO> exercise, int workoutId)
        {
            var result = await _workoutService.AddExercises(exercise, workoutId);
            if (result)
            {
                return Ok(new { Message = "Вправи додано." });
            }
            return BadRequest();
        }

        [HttpPatch("{workoutId}/date")]
        public async Task<IActionResult> UpdateDate(int workoutId, [FromBody] DateTime newDate)
        {
            var result = await _workoutService.UpdateDate(workoutId, newDate);
            if (result)
            {
                return Ok(new { Message = "Дату тренування успішно оновлено." });
            }
            return NotFound(new { Message = "Тренування не знайдено або не вдалося оновити дату." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _workoutService.Delete(id);
            if (result)
            {
                return Ok(new { Message = "Видалено успішно" });
            }
            return BadRequest();
        }

        [HttpDelete("{workoutId}/exercise/{exerciseId}")]
        public async Task<IActionResult> DeleteExercise(int workoutId, int exerciseId)
        {
            var result = await _workoutService.DeleteExercise(workoutId, exerciseId);
            if (result)
            {
                return Ok(new { Message = "Вправу видалено" });
            }
            return BadRequest();
        }
    }
}