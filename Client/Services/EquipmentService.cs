﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Services
{
    public class EquipmentService : IEquipmentService
    {

        public async Task<List<Equipment>> GetAllAsync()
        {
            using (var restClient = new RestClient())
            {
                return await restClient.GetAsync<List<Equipment>>("/Equipment/GetAll");
            }
        }

        public async Task<Equipment> GetAsync(int id)
        {
            using (var restClient = new RestClient())
            {
                return await restClient.GetAsync<Equipment>($"/Equipment/{id}");
            }
        }

        public async Task UpdateAsync(Equipment entity)
        {
            using (var restClient = new RestClient())
            {
                await restClient.PostAsync<object>("/Equipment/Update", entity);
            }
        }

        public async Task CreateAsync(Equipment entity)
        {
            using (var restClient = new RestClient())
            {
                await restClient.PostAsync<object>("/Equipment/Create", entity);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var restClient = new RestClient())
            {
                await restClient.DeleteAsync($"/Equipment/{id}");
            }
        }

        public async Task<string> Export()
        {
            using (var restClient = new RestClient())
            {
                return await restClient.PostAsync("/Equipment/Export");
            }
        }
    }
}
