using System.Threading.Tasks;
using AutoMapper;
using FestivalWebApp.API.Models;
using FestivalWebApp.Core.Models;
using FestivalWebApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FestivalWebApp.API.Controllers
{
    [Route("api/festival")]
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
        public async Task<ActionResult> CreateFestival([FromBody] FestivalCreateRequestBody createRequestBody)
        {
            var mappedValue = _mapper.Map<Festival>(createRequestBody);
            await _service.AddFestival(mappedValue);
            return Ok(mappedValue);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFestival(int id,
            [FromBody] FestivalUpdateRequestBody updateRequestBody)
        {
            var festival = _mapper.Map<Festival>(updateRequestBody);
            if (id != festival.Id) return BadRequest();
            await _service.UpdateFestival(festival);
            return Ok(festival);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFestival(int id)
        {
            await _service.RemoveFestival(id);
            return NoContent();
        }
    }
}