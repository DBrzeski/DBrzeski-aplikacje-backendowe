using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="Email address")]
        [Required(ErrorMessage ="Email address is required")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
