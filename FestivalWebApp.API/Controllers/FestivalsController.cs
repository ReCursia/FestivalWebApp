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
        public async Task<ActionResult> CreateFestival([FromBody] FestivalCreateRequestBody festivalCreateRequestBody)
        {
            var mappedValue = _mapper.Map<Festival>(festivalCreateRequestBody);
            await _service.AddFestival(mappedValue);
            return Ok(mappedValue);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFestival(int id,
            [FromBody] FestivalUpdateRequestBody festivalUpdateRequestBody)
        {
            var festival = _mapper.Map<Festival>(festivalUpdateRequestBody);
            if (id != festival.Id) return BadRequest();
            await _service.UpdateFestival(festival);
            return Ok(festivalUpdateRequestBody);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFestival(int id)
        {
            await _service.RemoveFestival(id);
            return NoContent();
        }
    }
}