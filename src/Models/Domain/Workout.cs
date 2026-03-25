using System.ComponentModel.DataAnnotations;

namespace src.Models.Domain
{
    public class Workout
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
