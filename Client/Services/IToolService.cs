using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Services
{
    public interface IToolService
    {
        Task<List<Tool>> GetAllAsync();
        Task<Tool> GetAsync(int id);
        Task UpdateAsync(Tool entity);
        Task CreateAsync(Tool entity);
        Task DeleteAsync(int id);
        Task<string> Export();
    }
}