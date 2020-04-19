using System.Threading.Tasks;
using AutoMapper;
using FestivalWebApp.API.Models;
using FestivalWebApp.Core.Models;
using FestivalWebApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FestivalWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FestivalsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFestivalService _service;

        public FestivalsController(IFestivalService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllFestivals()
        {
            var festivals = await _service.GetAllFestivals();
            return Ok(festivals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetFestivalById(int id)
        {
            var festival = await _service.GetFestivalById(id);
            return Ok(festival);
        }

        [HttpPost]
        public async Task<ActionResult> CreateFestival([FromBody] FestivalRequestBody festivalRequestBody)
        {
            var mappedValue = _mapper.Map<Festival>(festivalRequestBody);
            await _service.AddFestival(mappedValue);
            return Ok(mappedValue);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFestival(int id, [FromBody] FestivalRequestBody festivalRequestBody)
        {
            //TODO is it ok?
            var mappedValue = _mapper.Map<Festival>(festivalRequestBody);
            mappedValue.Id = id;
            await _service.UpdateFestival(id, mappedValue);
            return Ok(festivalRequestBody);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFestival(int id)
        {
            var festivalToRemove = await _service.GetFestivalById(id);
            await _service.RemoveFestival(festivalToRemove);
            return NoContent();
        }
    }
}