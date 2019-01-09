using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Services
{
    public class BrandService : IBrandService
    {
        private readonly ApplicationContext _context;

        public BrandService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            return await _context.Brand.ToListAsync();
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            return await _context.Brand.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Brand entity)
        {
            await _context.Brand.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Brand entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).Property(u => u.Name).IsModified = true;
            _context.Entry(entity).Property(u => u.Info).IsModified = true;


            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Brand.FindAsync(id);
            _context.Brand.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<string> ExportToCsv()
        {
            var dbData = await GetAllAsync();

            var columnHeaders = new string[]
            {
                "Name",
                "Info"
            };
            var csvData = new StringBuilder();

            csvData.AppendJoin(";", columnHeaders);
            csvData.AppendLine();

            dbData.ForEach(row => csvData.AppendJoin(";", row.Name, row.Info).AppendLine());
            
            return csvData.ToString();
        }
    }
}