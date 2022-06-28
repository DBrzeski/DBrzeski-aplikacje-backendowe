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

        public void Add(Manufacturer manufacturer)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Manufacturer>> GetAll()
        {
            var result = await _context.Manufacturer.ToListAsync();
            return result;
        }

        public Manufacturer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Manufacturer Update(int id, Manufacturer manufacturer)
        {
            throw new NotImplementedException();
        }
    }
}
