using storeapp.Data.Base;
using storeapp.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Models
{
    public class NewItemVM
    {
        [Required(ErrorMessage = "This field is required")]
        public string PictureUrl { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public ItemCategory ItemCategory { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int ManufacturerId { get; set; }

    }
}
