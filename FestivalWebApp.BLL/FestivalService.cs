using System.Collections.Generic;
using System.Threading.Tasks;
using FestivalWebApp.Core.Models;
using FestivalWebApp.Core.Repositories;
using FestivalWebApp.Core.Services;

namespace FestivalWebApp.BLL
{
    public class FestivalService : IFestivalService
    {
        private readonly IFestivalRepository _repository;

        public FestivalService(IFestivalRepository repository)
        {
            _repository = repository;
        }

        public async Task<Festival> GetFestivalById(int id)
        {
            return await _repository.GetFestivalById(id);
        }

        public async Task<IEnumerable<Festival>> GetAllFestivals()
        {
            return await _repository.GetAllFestivals();
        }

        public async Task<Festival> AddFestival(Festival festival)
        {
            return await _repository.AddFestival(festival);
        }

        public async Task UpdateFestival(int id, Festival festival)
        {
            await _repository.UpdateFestival(festival);
        }

        public async Task RemoveFestival(int id)
        {
            var festival = await _repository.GetFestivalById(id);
            await _repository.RemoveFestival(festival);
        }
    }
}