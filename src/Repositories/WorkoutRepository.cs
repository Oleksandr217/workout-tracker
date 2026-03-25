using src.Interfaces;
using src.Models.Domain;

namespace src.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        

        public async Task<bool> AddExercises(List<Exercise> exercise, int workoutId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Create(Workout workout)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        { 
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteExercise(int workoutId, int exerciseId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Workout>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Workout>> GetByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<Workout> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateDate(int workoutId, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
