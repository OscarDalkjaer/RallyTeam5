﻿using Core.Domain.Entities;

namespace Core.Domain.Services
{
    public interface IExerciseRepository
    {
        Task AddExercise(Exercise exercise);
        Task<Exercise?> GetExercise(int exerciseId);
        Task<IEnumerable<Exercise>> GetAllExercises();
        Task UpdateExercise(Exercise exercise);
        Task DeleteExercise(int exerciseId);
        Task<(List<Exercise>, List<string>)> GetExercisesFromNumbers(List<int> exerciseNumbers);
        //Task<Exercise> GetNullExercise();
    }
}
