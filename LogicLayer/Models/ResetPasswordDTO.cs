using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    /// <summary>
    /// A DTO for setting password. The given password must match certain condition for security reasons
    /// </summary>
    public class ResetPasswordDTO
    {
        [Required(ErrorMessage = "Password is required")]
        [PasswordPropertyText]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@#$&_-]).*$",
        ErrorMessage = "At least one lower case letter, one upper case letter, digit and  special symbol are required")]
        [MaxLength(14)]
        [MinLength(7, ErrorMessage = "Password should be at least 7 characters long")]
        public string Password { get; set; }

    }
}
