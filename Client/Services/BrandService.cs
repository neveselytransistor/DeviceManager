using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Services
{
    public class BrandService : IBrandService
    {

        public async Task<List<Brand>> GetAllAsync()
        {
            using (var restClient = new RestClient())
            {
                return await restClient.GetAsync<List<Brand>>("/Brand/GetAll");
            }
        }

        public async Task<Brand> GetAsync(int id)
        {
            using (var restClient = new RestClient())
            {
                return await restClient.GetAsync<Brand>($"/Brand/{id}");
            }
        }

        public async Task UpdateAsync(Brand entity)
        {
            using (var restClient = new RestClient())
            {
                await restClient.PostAsync<object>("/Brand/Update", entity);
            }
        }

        public async Task CreateAsync(Brand entity)
        {
            using (var restClient = new RestClient())
            {
                await restClient.PostAsync<object>("/Brand/Create", entity);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var restClient = new RestClient())
            {
                await restClient.DeleteAsync($"/Brand/{id}");
            }
        }

        public async Task<string> Export()
        {
            using (var restClient = new RestClient())
            {
                //await restClient.PostAsync()
                return null;
            }
        }
    }
}
