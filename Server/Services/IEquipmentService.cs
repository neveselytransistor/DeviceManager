using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Services
{
    public interface IEquipmentService
    {
        Task<List<Equipment>> GetAllAsync();
        Task<Equipment> GetByIdAsync(int id);
        Task AddAsync(Equipment entity);
        Task UpdateAsync(Equipment entity);
        Task DeleteAsync(int id);
        Task<string> ExportToCsv();
    }
}