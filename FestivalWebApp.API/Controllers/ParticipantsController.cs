using System.Threading.Tasks;
using AutoMapper;
using FestivalWebApp.API.Models;
using FestivalWebApp.Core.Models;
using FestivalWebApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FestivalWebApp.API.Controllers
{
    [Route("api/participant")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IParticipantService _service;

        public ParticipantsController(IMapper mapper, IParticipantService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllParticipants()
        {
            var participants = await _service.GetAllParticipants();
            return Ok(participants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetParticipantById(int id)
        {
            var participant = await _service.GetParticipantById(id);
            return Ok(participant);
        }

        [HttpGet("festival/{id}")]
        public async Task<ActionResult> GetParticipantsByFestivalId(int id)
        {
            var participants = await _service.GetParticipantsByFestivalId(id);
            return Ok(participants);
        }

        [HttpPost]
        public async Task<ActionResult> CreateParticipant([FromBody] ParticipantCreateRequestBody createRequestBody)
        {
            var mappedValue = _mapper.Map<Participant>(createRequestBody);
            await _service.AddParticipant(mappedValue);
            return Ok(mappedValue);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateParticipant(int id,
            [FromBody] ParticipantUpdateRequestBody updateRequestBody)
        {
            var participant = _mapper.Map<Participant>(updateRequestBody);
            if (id != participant.Id) return BadRequest();

            await _service.UpdateParticipant(participant);
            return Ok(participant);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteParticipant(int id)
        {
            await _service.RemoveParticipant(id);
            return NoContent();
        }
    }
}