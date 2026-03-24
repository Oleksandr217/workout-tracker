using src.Models.Domain;

namespace src.Interfaces
{
    public interface IWorkoutRepository
    {
        Task<bool> Create(Workout workout);
        Task<bool> AddExercises(List<Exercise> exercise, int workoutId);
        Task<bool> DeleteExercise(int workoutId, int exerciseId);
        Task<bool> UpdateDate(int workoutId, DateTime date);
        Task<bool> Delete(int id);
        Task<List<Workout>> GetAll();
        Task<Workout> GetById(int id);
        Task<List<Workout>> GetByDate(DateTime date);
    }
}
