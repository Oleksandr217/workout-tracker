using src.Models.Domain;
using src.Models.DTOs;

namespace src.Interfaces
{
    public interface IWorkoutService
    {
        Task<bool> Create(WorkoutDTO workout);
        Task<bool> AddExercises(List<ExerciseDTO> exercise, int workoutId);
        Task<bool> DeleteExercise(int workoutId, int exerciseId);
        Task<bool> UpdateDate(int workoutId, DateTime date);
        Task<bool> Delete(int id);
        Task<List<WorkoutDTO>> GetAll();
        Task<WorkoutDTO> GetById(int id);
        Task<List<WorkoutDTO>> GetByDate(DateTime date);
    }
}
