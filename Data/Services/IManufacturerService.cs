using storeapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Controllers
{
    public interface IManufacturerService
    {
        IEnumerable<Manufacturer> GetAll();
        Manufacturer GetById(int id);
        void Add(Manufacturer manufacturer);
        Manufacturer Update(int id, Manufacturer manufacturer);
        void Delete(int id);
    }
}
