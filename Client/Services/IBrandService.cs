using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Services
{
    public interface IBrandService
    {
        Task<List<Brand>> GetAllAsync();
        Task<Brand> GetAsync(int id);
        Task UpdateAsync(Brand entity);
        Task CreateAsync(Brand entity);
        Task DeleteAsync(int id);
    }
}