using System.Collections.Generic;
using System.Threading.Tasks;
using FestivalWebApp.Domain.Models;

namespace FestivalWebApp.Domain.Repositories
{
    public interface IFestivalRepository
    {
        Task<Festival> GetFestivalById(int id);
        Task<IEnumerable<Festival>> GetAllFestivals();
        Task<Festival> AddFestival(Festival festival);
        Task UpdateFestival(Festival festival);
        Task RemoveFestival(Festival festival);
    }
}