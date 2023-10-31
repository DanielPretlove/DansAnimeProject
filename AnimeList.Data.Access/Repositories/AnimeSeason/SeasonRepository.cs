using AnimeList.Data.Entities.AnimeSeries;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimeList.Data.Access.Repositories.AnimeSeason
{
    public class SeasonRepository : ISeasonRepository
    {
        private readonly ApplicationDataContext _context;

        public SeasonRepository(ApplicationDataContext context)
        {
            _context = context;
        }
        public async Task<IList<Seasons>> GetAllAsync()
        {
            return await _context.Set<Seasons>().ToListAsync();
        }

        public async Task<Seasons> GetById(Guid id)
        {
            return await _context.Set<Seasons>().FindAsync(id);
        }

        public async Task<Seasons> InsertAsync(Seasons data)
        {
            var result = await _context.AddAsync(data);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task UpdateAsync(Seasons data)
        {
            _context.Set<Seasons>().Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<Seasons> DeleteAsync(Guid id)
        {
            var result = await _context.Set<Seasons>().FindAsync(id);
            _context.Set<Seasons>().Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
