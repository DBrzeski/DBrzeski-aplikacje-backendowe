using Microsoft.EntityFrameworkCore;
using storeapp.Controllers;
using storeapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Data.Services
{
    public class ManufacturerService : IManufacturerService
    {

        private readonly AppDbContext _context;
        public ManufacturerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Manufacturer manufacturer)
        {
            await _context.Manufacturer.AddAsync(manufacturer);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Manufacturer>> GetAllAsync()
        {
            var result = await _context.Manufacturer.ToListAsync();
            return result;
        }

        public async Task<Manufacturer> GetByIdAsync(int id)
        {
            var result = await _context.Manufacturer.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public Manufacturer Update(int id, Manufacturer newActor)
        {
            throw new NotImplementedException();
        }
    }
}
