using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Services
{
    public interface IEquipmentService
    {
        Task<List<Equipment>> GetAllAsync();
        Task<Equipment> GetAsync(int id);
    }
}