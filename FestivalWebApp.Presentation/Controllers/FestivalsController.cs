using System.Threading.Tasks;
using AutoMapper;
using FestivalWebApp.Domain.Interactors;
using FestivalWebApp.Domain.Models;
using FestivalWebApp.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestivalWebApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FestivalsController : ControllerBase
    {
        private readonly IFestivalInteractor _interactor;
        private readonly IMapper _mapper;

        public FestivalsController(IFestivalInteractor interactor, IMapper mapper)
        {
            _interactor = interactor;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllFestivals()
        {
            return await Task.Run(() => Ok(_interactor.GetAllFestivals()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetFestivalById(int id)
        {
            return await Task.Run(() => Ok(_interactor.GetFestivalById(id)));
        }

        [HttpPost]
        public async Task<ActionResult> CreateFestival([FromBody] FestivalRequestBody festivalRequestBody)
        {
            return await Task.Run(() =>
            {
                var mappedValue = _mapper.Map<Festival>(festivalRequestBody);
                _interactor.AddFestival(mappedValue);
                return Ok(mappedValue);
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFestival(int id, [FromBody] FestivalRequestBody festivalRequestBody)
        {
            return await Task.Run(() =>
            {
                var festivalToUpdate = _interactor.GetFestivalById(id);
                festivalToUpdate.Date = festivalRequestBody.Date;
                festivalToUpdate.Description = festivalRequestBody.Description;
                festivalToUpdate.Name = festivalRequestBody.Name;
                _interactor.UpdateFestival(festivalToUpdate);
                return Ok(festivalRequestBody);
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFestival(int id)
        {
            return await Task.Run(() =>
            {
                var festival = _interactor.GetFestivalById(id);
                _interactor.RemoveFestival(festival);
                return NoContent();
            });
        }
    }
}