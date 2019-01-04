﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly ApplicationContext _context;

        public EquipmentService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Equipment>> GetAllAsync()
        {
            return await _context.Equipment.ToListAsync();
        }

        public async Task<Equipment> GetByIdAsync(int id)
        {
            return await _context.Equipment.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Equipment entity)
        {
            await _context.Equipment.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Equipment entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).Property(u => u.BrandId).IsModified = true;
            _context.Entry(entity).Property(u => u.ToolId).IsModified = true;
            _context.Entry(entity).Property(u => u.Info).IsModified = true;
            _context.Entry(entity).Property(u => u.Price).IsModified = true;


            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Equipment.FindAsync(id);
            _context.Equipment.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}