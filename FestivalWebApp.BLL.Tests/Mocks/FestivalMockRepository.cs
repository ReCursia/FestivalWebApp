using System.Collections.Generic;
using System.Threading.Tasks;
using FestivalWebApp.Core.Models;
using FestivalWebApp.DAL.Contracts;

namespace FestivalWebApp.BLL.Tests.Mocks
{
    public class FestivalMockRepository : IFestivalRepository
    {
        private readonly Dictionary<int, Festival> _dict = new Dictionary<int, Festival>();

        public Task<Festival> GetFestivalById(int id)
        {
            return Task.FromResult(_dict[id]);
        }

        public Task RemoveFestival(Festival festival)
        {
            return Task.FromResult(_dict.Remove(festival.Id));
        }

        public Task<bool> IsExist(int id)
        {
            return Task.FromResult(_dict.ContainsKey(id));
        }

        public Task<IEnumerable<Festival>> GetAllFestivals()
        {
            return Task.FromResult<IEnumerable<Festival>>(_dict.Values);
        }

        public Task<Festival> AddFestival(Festival festival)
        {
            _dict[festival.Id] = festival;
            return Task.FromResult(festival);
        }

        public Task UpdateFestival(Festival festival)
        {
            return Task.FromResult(_dict[festival.Id] = festival);
        }
    }
}