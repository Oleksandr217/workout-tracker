using System.ComponentModel.DataAnnotations;

namespace src.Models.Domain
{
    public class Exercise
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; set; }
        public int CountApproaches { get; set; }
        public int CountRepeats { get; set; }
        public int WorkoutId { get; set; }
        public Exercise(string name, int approaches, int repeats, int workoutId)
        {
            Name = name;
            CountApproaches = approaches;
            CountRepeats = repeats;
            WorkoutId = workoutId;
        }
    }
}
