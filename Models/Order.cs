using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using storeapp.Data.Enums;

namespace storeapp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public string UserId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public Status Status { get; set; }

    }
}
