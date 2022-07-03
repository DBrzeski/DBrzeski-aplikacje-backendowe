using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Models
{
    public class User
    {
        public string Phone { get; set; }
        public string Street { get; set; }
        [StringLength(9)]
        public string Number { get; set; }
        public string Postal { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User_ { get; set; }
    }
}
