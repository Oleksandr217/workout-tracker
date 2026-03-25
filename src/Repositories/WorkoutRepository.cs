using Microsoft.EntityFrameworkCore;
using src.Interfaces;
using src.Models.Domain;

namespace src.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly AppDbContext _context;
        public WorkoutRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddExercises(List<Exercise> exercise)
        {
            await _context.Exercises.AddRangeAsync(exercise);
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> Create(Workout workout)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
                return false;
            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteExercise(int workoutId, int exerciseId)
        {
            var workout = await _context.Workouts.FindAsync(workoutId);
            if (workout == null)
                return false;
            var exercise = await _context.Exercises.FindAsync(exerciseId);
            if(exercise == null)
                return false;
            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Workout>> GetAll()
        {
            return await _context.Workouts
                .Include(w => w.Exercises)
                .ToListAsync();
        }

        public async Task<List<Workout>> GetByDate(DateTime date)
        {
            return await _context.Workouts
                .Include(w => w.Exercises)
                .Where(w => w.Start.Date == date.Date)
                .ToListAsync();
        }

        public async Task<Workout> GetById(int id)
        {
            return await _context.Workouts
                .Include(w => w.Exercises)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<bool> UpdateDate(int workoutId, DateTime date)
        {
            var workout = await _context.Workouts.FindAsync(workoutId);
            if (workout == null) return false;

            workout.Start = date;

            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}
