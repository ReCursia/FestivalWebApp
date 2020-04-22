using System.Collections.Generic;
using System.Threading.Tasks;
using FestivalWebApp.BLL.Contracts;
using FestivalWebApp.BLL.Exceptions;
using FestivalWebApp.Core.Models;
using FestivalWebApp.DAL.Contracts;

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

        public async Task UpdateFestival(Festival festival)
        {
            var isExist = await _repository.IsExist(festival.Id);
            if (!isExist) throw new ElementNotFoundException(festival);

            await _repository.UpdateFestival(festival);
        }

        public async Task RemoveFestival(int id)
        {
            var isExist = await _repository.IsExist(id);
            if (!isExist) throw new ElementNotFoundException(id);

            var festival = await GetFestivalById(id);
            await _repository.RemoveFestival(festival);
        }
    }
}