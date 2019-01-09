using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Services
{
    public class ToolService : IToolService
    {
        private readonly ApplicationContext _context;

        public ToolService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Tool>> GetAllAsync()
        {
            return await _context.Tool.ToListAsync();
        }

        public async Task<Tool> GetByIdAsync(int id)
        {
            return await _context.Tool.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Tool entity)
        {
            await _context.Tool.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tool entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).Property(u => u.Name).IsModified = true;
            _context.Entry(entity).Property(u => u.Application).IsModified = true;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Tool.FindAsync(id);
            _context.Tool.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<string> ExportToCsv()
        {
            var dbData = await GetAllAsync();

            var columnHeaders = new string[]
            {
                "Name",
                "Application"
            };
            var csvData = new StringBuilder();

            csvData.AppendJoin(";", columnHeaders);
            csvData.AppendLine();

            dbData.ForEach(row => csvData.AppendJoin(";", row.Name, row.Application));
            
            return csvData.ToString();
        }
    }
}