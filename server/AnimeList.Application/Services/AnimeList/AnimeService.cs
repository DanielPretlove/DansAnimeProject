using AnimeList.Data.Access.Repositories;
using AnimeList.Data.Entities.AnimeSeries;
using AnimeList.Web.Shared.Models.AnimeSeries.Anime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Services.AnimeList
{
    public class AnimeService
    {
        private readonly IAnimeRepository _animeRepository;

        public AnimeService(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<IList<Anime>> GetAll()
        {
            return await _animeRepository.GetAllAsync();
        }

        public async Task<Anime> GetById(Guid id)
        {
            return await _animeRepository.GetById(id);
        }

        public async Task<Anime> Insert(Anime data)
        {
            return await _animeRepository.InsertAsync(data);
        }

        public async Task Update(Anime data)
        {
            await _animeRepository.UpdateAsync(data);
        }

        public async Task<Anime> Delete(Guid id)
        {
            return await _animeRepository.DeleteAsync(id);
        }
    }
}
