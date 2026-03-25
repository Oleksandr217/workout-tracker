using src.Interfaces;
using src.Models.Domain;
using src.Models.DTOs;

namespace src.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;
        public WorkoutService(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }
        public async Task<bool> AddExercises(List<ExerciseDTO> exercise, int workoutId)
        {
            List<Exercise> exercises = new List<Exercise>();
            foreach(var exercisesDTO in exercise)
            {
                exercises.Add(new Exercise(exercisesDTO.Name, exercisesDTO.CountApproaches, exercisesDTO.CountRepeats, workoutId));
            }

            return await _workoutRepository.AddExercises(exercises, workoutId);
        }

        public async Task<bool> Create(WorkoutDTO workoutDTO)
        {
            var workout = new Workout(workoutDTO.Name, workoutDTO.Start);
            return await _workoutRepository.Create(workout);
        }

        public async Task<bool> Delete(int id)
        {
            return await _workoutRepository.Delete(id);
        }

        public async Task<bool> DeleteExercise(int workoutId, int exerciseId)
        {
            return await _workoutRepository.DeleteExercise(workoutId, exerciseId);
        }

        public async Task<List<WorkoutDTO>> GetAll()
        {
            List<Workout> workouts = await _workoutRepository.GetAll();
            List<WorkoutDTO> workoutDTOs = new List<WorkoutDTO>();

            foreach(var workout in workouts)
            {
                var dto = new WorkoutDTO
                {
                    Name = workout.Name,
                    Start = workout.Start,
                    Exercises = new List<ExerciseDTO>()
                };

                foreach(var exercise in workout.Exercises)
                {
                    dto.Exercises.Add(new ExerciseDTO
                    {
                        Name = exercise.Name,
                        CountApproaches = exercise.CountApproaches,
                        CountRepeats = exercise.CountRepeats
                    });
                }

                workoutDTOs.Add(dto);
            }
            return workoutDTOs;
        }

        public async Task<List<WorkoutDTO>> GetByDate(DateTime date)
        {
            List<Workout> workouts = await _workoutRepository.GetByDate(date);
            List<WorkoutDTO> workoutDTOs = new List<WorkoutDTO>();

            foreach (var workout in workouts)
            {
                var dto = new WorkoutDTO
                {
                    Name = workout.Name,
                    Start = workout.Start
                };

                foreach (var exercise in workout.Exercises)
                {
                    dto.Exercises.Add(new ExerciseDTO
                    {
                        Name = exercise.Name,
                        CountApproaches = exercise.CountApproaches,
                        CountRepeats = exercise.CountRepeats
                    });
                }

                workoutDTOs.Add(dto);
            }
            return workoutDTOs;
        }

        public async Task<WorkoutDTO> GetById(int id)
        {
            Workout workout = await _workoutRepository.GetById(id);
            
            if (workout == null) return null;

            WorkoutDTO dto = new WorkoutDTO()
            {
                Name = workout.Name,
                Start = workout.Start
            };

            foreach(var exercise in workout.Exercises)
            {
                dto.Exercises.Add(new ExerciseDTO
                {
                    Name = exercise.Name,
                    CountApproaches = exercise.CountApproaches,
                    CountRepeats = exercise.CountRepeats
                });
            }

            return dto;
        }

        public async Task<bool> UpdateDate(int workoutId, DateTime date)
        {
            return await _workoutRepository.UpdateDate(workoutId, date);
        }
    }
}
