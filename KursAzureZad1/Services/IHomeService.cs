using KursAzureZad1.BindingModels;
using KursAzureZad1.ReadModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KursAzureZad1.Services
{
    public interface IHomeService
    {
        public Task<ExerciseReadModel> GetExercise(Guid Id);
        public Task AddExercise(ExerciseBindingModel model);
        public Task<IEnumerable<ExerciseReadModel>> GetAllExercises();
    }
}
