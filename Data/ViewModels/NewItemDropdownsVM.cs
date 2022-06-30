using storeapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Data.ViewModels
{
    public class NewItemDropdownsVM
    {
        public NewItemDropdownsVM()
        {
            Manufacturer = new List<Manufacturer>();
        }
        public List<Manufacturer> Manufacturer { get; set; }
    }
}
