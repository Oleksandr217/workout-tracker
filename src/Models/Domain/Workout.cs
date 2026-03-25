using System.ComponentModel.DataAnnotations;

namespace src.Models.Domain
{
    public class Workout
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
        public Workout() { }
        public Workout(string name, DateTime start)
        {
            Name = name;
            Start = start;
        }
    }
}
