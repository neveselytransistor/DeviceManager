using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Services
{
    public interface IToolService
    {
        Task<List<Tool>> GetAllAsync();
        Task<Tool> GetByIdAsync(int id);
        Task AddAsync(Tool entity);
        Task UpdateAsync(Tool entity);
        Task DeleteAsync(int id);
        Task<string> ExportToCsv();
    }
}