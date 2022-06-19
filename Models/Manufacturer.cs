using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        public List<Item> Items { get; set; }
    }
}
