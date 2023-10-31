using AnimeList.Data.Entities.AnimeSeries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Data.Access.Repositories
{
    public interface IAnimeRepository
    {
        Task<IList<Anime>> GetAllAsync();
        Task<Anime> GetById(Guid id);
        Task<Anime> InsertAsync(Anime data);
        Task UpdateAsync(Anime data);
        Task<Anime> DeleteAsync(Guid id);
    }
}
