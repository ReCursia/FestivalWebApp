using System.Threading.Tasks;
using AutoMapper;
using FestivalWebApp.API.Models;
using FestivalWebApp.BLL.Contracts;
using FestivalWebApp.Core.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FestivalWebApp.API.Controllers
{
    [Route("api/participants")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IValidator<ParticipantCreateRequestBody> _createValidator;
        private readonly IMapper _mapper;
        private readonly IParticipantService _service;
        private readonly IValidator<ParticipantUpdateRequestBody> _updateValidator;

        public ParticipantsController(IMapper mapper, IParticipantService service,
            IValidator<ParticipantCreateRequestBody> validator,
            IValidator<ParticipantUpdateRequestBody> updateValidator)
        {
            _mapper = mapper;
            _service = service;
            _createValidator = validator;
            _updateValidator = updateValidator;
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
            var validationResult = await _createValidator.ValidateAsync(createRequestBody);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var mappedValue = _mapper.Map<Participant>(createRequestBody);
            await _service.AddParticipant(mappedValue);
            return Ok(mappedValue);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateParticipant(int id,
            [FromBody] ParticipantUpdateRequestBody updateRequestBody)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateRequestBody);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

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