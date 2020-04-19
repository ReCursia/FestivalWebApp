using System.Threading.Tasks;
using AutoMapper;
using FestivalWebApp.API.Models;
using FestivalWebApp.Core.Models;
using FestivalWebApp.Core.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FestivalWebApp.API.Controllers
{
    [Route("api/festivals")]
    [ApiController]
    public class FestivalsController : ControllerBase
    {
        private readonly IValidator<FestivalCreateRequestBody> _createValidator;
        private readonly IMapper _mapper;
        private readonly IFestivalService _service;
        private readonly IValidator<FestivalUpdateRequestBody> _updateValidator;

        public FestivalsController(IMapper mapper, IFestivalService service,
            IValidator<FestivalCreateRequestBody> validator,
            IValidator<FestivalUpdateRequestBody> updateValidator)
        {
            _mapper = mapper;
            _service = service;
            _createValidator = validator;
            _updateValidator = updateValidator;
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
            var validationResult = await _createValidator.ValidateAsync(createRequestBody);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var mappedValue = _mapper.Map<Festival>(createRequestBody);
            await _service.AddFestival(mappedValue);
            return Ok(mappedValue);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFestival(int id,
            [FromBody] FestivalUpdateRequestBody updateRequestBody)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateRequestBody);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);


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