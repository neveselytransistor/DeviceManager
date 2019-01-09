using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Services
{
    public class ToolService : IToolService
    {
        public async Task<List<Tool>> GetAllAsync()
        {
            using (var restClient = new RestClient())
            {
                return await restClient.GetAsync<List<Tool>>("/Tool/GetAll");
            }
        }

        public async Task<Tool> GetAsync(int id)
        {
            using (var restClient = new RestClient())
            {
                return await restClient.GetAsync<Tool>($"/Tool/{id}");
            }
        }

        public async Task UpdateAsync(Tool entity)
        {
            using (var restClient = new RestClient())
            {
                await restClient.PostAsync<object>("/Tool/Update", entity);
            }
        }

        public async Task CreateAsync(Tool entity)
        {
            using (var restClient = new RestClient())
            {
                await restClient.PostAsync<object>("/Tool/Create", entity);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var restClient = new RestClient())
            {
                await restClient.DeleteAsync($"/Tool/{id}");
            }
        }

        public async Task<string> Export()
        {
            using (var restClient = new RestClient())
            {
                return await restClient.PostAsync("/Tool/Export");
            }
        }
    }
}
