using AnimeList.Data.Entities.AnimeSeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Data.Access.Repositories.AnimeSeason
{
    public interface ISeasonRepository
    {
        Task<IList<Seasons>> GetAllAsync();
        Task<Seasons> GetById(Guid id);
        Task<Seasons> InsertAsync(Seasons data);
        Task UpdateAsync(Seasons data);
        Task<Seasons> DeleteAsync(Guid id);
    }
}
