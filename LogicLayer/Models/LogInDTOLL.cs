using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    public class LogInDTOLL
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [MaxLength(80)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [PasswordPropertyText]
        [MaxLength(14)]
        public string Password { get; set; }

    }
}
