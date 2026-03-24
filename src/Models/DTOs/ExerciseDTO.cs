using System.ComponentModel.DataAnnotations;

namespace src.Models.DTOs
{
    public class ExerciseDTO
    {
        [Required(ErrorMessage ="Ім'я є обов'язковим")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Кількість підходів є обов'язковим")]
        [Range(1, 20, ErrorMessage ="Кількість підходів некоректна")]
        public int CountApproaches { get; set; }

        [Required(ErrorMessage = "Кількість повторень є обов'язковим")]
        [Range(1, 100, ErrorMessage = "Кількість повторень некоректна")]
        public int CountRepeats { get; set; }
    }
}
