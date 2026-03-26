using System.ComponentModel.DataAnnotations;

namespace src.Models.DTOs
{
    public class WorkoutDTO
    {
        [Required(ErrorMessage = "Ім'я є обов'язковим")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Дата є обов'язковою")]
        //[Range(typeof(DateTime), "1/1/2026", "12/31/2100")]
        public DateTime Start {  get; set; }

        public List<ExerciseDTO> Exercises { get; set; } = new();
    }
}
