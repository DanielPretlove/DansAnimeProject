using AnimeList.Data.Entities.AnimeSeries;
using Azure.Core.Pipeline;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Data.Access.Repositories.AnimeList
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly ApplicationDataContext _context;

        public AnimeRepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public async Task<IList<Anime>> GetAllAsync()
        {
            return await _context.Set<Anime>().ToListAsync();
        }

        public async Task<Anime> GetById(Guid id)
        {
            return await _context.Set<Anime>().FindAsync(id);
        }

        public async Task<Anime> InsertAsync(Anime data)
        {
            var result = await _context.AddAsync(data);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task UpdateAsync(Anime data)
        {
            _context.Set<Anime>().Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Anime> DeleteAsync(Guid id)
        {
            var result = await _context.Set<Anime>().FindAsync(id);
            _context.Set<Anime>().Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
