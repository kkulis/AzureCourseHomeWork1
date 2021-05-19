using KursAzureZad1.BindingModels;
using KursAzureZad1.Entities;
using KursAzureZad1.Entities.Models;
using KursAzureZad1.ReadModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KursAzureZad1.Services
{
    public class HomeService : IHomeService
    {
        private readonly AppDbContext _context;

        public HomeService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddExercise(ExerciseBindingModel model)
        {
            var exercise = new Exercise
            {
                Id = Guid.NewGuid(),
                Distance = model.Distance,
                Minutes = model.Minutes,
                Name = model.Name
            };

            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExerciseReadModel>> GetAllExercises()
        {
            var exercises = await _context.Exercises.ToListAsync();
            var exercisesReadModel = new  List<ExerciseReadModel>();
            foreach (var exercise in exercises)
            {
                var mappedExercise = new ExerciseReadModel
                {
                    Id = exercise.Id,
                    Name = exercise.Name,
                    Distance = exercise.Distance,
                    Minutes = exercise.Minutes
                };
                exercisesReadModel.Add(mappedExercise);
            }
            return exercisesReadModel;
        }

        public async Task<ExerciseReadModel> GetExercise(Guid Id)
        {
            var exercise =  await _context.Exercises.FindAsync(Id);

            return new ExerciseReadModel
            {
                Id = exercise.Id,
                Name = exercise.Name,
                Distance = exercise.Distance,
                Minutes = exercise.Minutes
            };
        }
    }
}
