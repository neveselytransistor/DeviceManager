using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Services
{
    public interface IBrandService
    {
        Task<List<Brand>> GetAllAsync();
        Task<Brand> GetByIdAsync(int id);
        Task AddAsync(Brand entity);
        Task UpdateAsync(Brand entity);
        Task DeleteAsync(int id);
    }
}