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
            var festivals = await _interactor.GetAllFestivals();
            return Ok(festivals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetFestivalById(int id)
        {
            var festival = await _interactor.GetFestivalById(id);
            return Ok(festival);
        }

        [HttpPost]
        public async Task<ActionResult> CreateFestival([FromBody] FestivalRequestBody festivalRequestBody)
        {
            var mappedValue = _mapper.Map<Festival>(festivalRequestBody);
            await _interactor.AddFestival(mappedValue);
            return Ok(mappedValue);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFestival(int id, [FromBody] FestivalRequestBody festivalRequestBody)
        {
            //TODO is it ok?
            var mappedValue = _mapper.Map<Festival>(festivalRequestBody);
            mappedValue.Id = id;
            await _interactor.UpdateFestival(mappedValue);
            return Ok(festivalRequestBody);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFestival(int id)
        {
            var festivalToRemove = await _interactor.GetFestivalById(id);
            await _interactor.RemoveFestival(festivalToRemove);
            return NoContent();
        }
    }
}