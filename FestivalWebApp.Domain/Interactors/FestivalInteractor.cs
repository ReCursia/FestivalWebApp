using System.Collections.Generic;
using FestivalWebApp.Domain.Models;
using FestivalWebApp.Domain.Repositories;

namespace FestivalWebApp.Domain.Interactors
{
    public class FestivalInteractor : IFestivalInteractor
    {
        private readonly IFestivalRepository _repository;

        public FestivalInteractor(IFestivalRepository repository)
        {
            _repository = repository;
        }

        public Festival GetFestivalById(int id)
        {
            return _repository.GetFestivalById(id);
        }

        public IEnumerable<Festival> GetAllFestivals()
        {
            return _repository.GetAllFestivals();
        }

        public void AddFestival(Festival festival)
        {
            _repository.AddFestival(festival);
        }

        public void UpdateFestival(Festival festival)
        {
            _repository.UpdateFestival(festival);
        }

        public void RemoveFestival(Festival festival)
        {
            _repository.RemoveFestival(festival);
        }
    }
}