using storeapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Data.Services
{
    public interface IManufacturerService
    {
        Task<IEnumerable<Manufacturer>> GetAllAsync();
        Task<Manufacturer> GetByIdAsync(int id);
        Task AddAsync(Manufacturer manufacturer);
        Task<Manufacturer> UpdateAsync(int id, Manufacturer newManufacturer);
        Task DeleteAsync(int id);
    }
}
