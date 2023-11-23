using AnimeList.Data.Access.Repositories;
using AnimeList.Data.Access.Repositories.AnimeSeason;
using AnimeList.Data.Entities.AnimeSeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Services.AnimeList
{
    public class SeasonService
    {
        private readonly ISeasonRepository _seasonRepository;

        public SeasonService(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public async Task<IList<Seasons>> GetAll()
        {
            return await _seasonRepository.GetAllAsync();
        }

        public async Task<Seasons> GetById(Guid id)
        {
            return await _seasonRepository.GetById(id);
        }

        public async Task<Seasons> Insert(Seasons data)
        {
            return await _seasonRepository.InsertAsync(data);
        }

        public async Task Update(Seasons data)
        {
            await _seasonRepository.UpdateAsync(data);
        }

        public async Task<Seasons> Delete(Guid id)
        {
            return await _seasonRepository.DeleteAsync(id);
        }
    }
}
