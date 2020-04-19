using System.Collections.Generic;
using System.Threading.Tasks;
using FestivalWebApp.Domain.Interactors;
using FestivalWebApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestivalWebApp.Presentation.Controllers
{
    public class FestivalsController : ControllerBase
    {
        private readonly IFestivalInteractor _interactor;

        public FestivalsController(IFestivalInteractor interactor)
        {
            _interactor = interactor;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllFestivals()
        {
            return await Task.Run(() => Ok(_interactor.GetAllFestivals()));
        }

        [HttpGet("{id")]
        public async Task<ActionResult> GetFestivalById(int id)
        {
            return await Task.Run(() => Ok(_interactor.GetFestivalById(id)));
        }
    }
}

// Festival GetFestivalById(int id);
// IEnumerable<Festival> GetAllFestivals();
// void AddFestival(Festival festival);
// void UpdateFestival(Festival festival);
// void RemoveFestival(Festival festival);