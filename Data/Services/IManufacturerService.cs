using storeapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Data.Services
{
    public interface IManufacturerService
    {
        Task<IEnumerable<Manufacturer>> GetAll();
        Manufacturer GetById(int id);
        void Add(Manufacturer manufacturer);
        Manufacturer Update(int id, Manufacturer manufacturer);
        void Delete(int id);
    }
}
