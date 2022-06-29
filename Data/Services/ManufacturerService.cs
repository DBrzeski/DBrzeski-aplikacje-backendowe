using Microsoft.EntityFrameworkCore;
using storeapp.Controllers;
using storeapp.Data.Base;
using storeapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Data.Services
{
    public class ManufacturerService : EntityBaseRepository<Manufacturer>, IManufacturerService
    {

        public ManufacturerService(AppDbContext context) : base(context)
        {

        }
    }
}
