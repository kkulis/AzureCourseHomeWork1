using KursAzureZad1.BindingModels;
using KursAzureZad1.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KursAzureZad1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> GetExerciseInfo(Guid Id)
        {
            var result = await _homeService.GetExercise(Id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddExerciseInfo(ExerciseBindingModel model)
        {
            await _homeService.AddExercise(model);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExercises()
        {
            var result = await _homeService.GetAllExercises();

            return Ok(result);
        }
    }
}
