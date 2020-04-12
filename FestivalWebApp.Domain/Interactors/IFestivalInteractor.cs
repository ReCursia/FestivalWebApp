using System.Collections.Generic;
using FestivalWebApp.Domain.Models;

namespace FestivalWebApp.Domain.Interactors
{
    public interface IFestivalInteractor
    {
        Festival GetFestivalById(int id);
        IEnumerable<Festival> GetAllFestivals();
        void AddFestival(Festival festival);
        void UpdateFestival(Festival festival);
        void RemoveFestival(Festival festival);
    }
}