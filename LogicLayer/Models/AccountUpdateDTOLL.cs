using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    public class AccountUpdateDTOLL
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [MaxLength(80)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{7,14}$", ErrorMessage = "Phone number must contain at between 7 and 14 digits")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [PasswordPropertyText]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@#$&_-]).*$",
        ErrorMessage = "At least one lower case letter, one upper case letter, digit and  special symbol are required")]
        [MaxLength(14)]
        [MinLength(7, ErrorMessage = "Password should be at least 7 characters long")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please confirm your password")]
        [PasswordPropertyText]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Please add a secret question")]
        public string SecretQuestion { get; set; }


        [Required(ErrorMessage = "Please add an asnwer")]
        public string SecretQuestionAnswer { get; set; }
    }
}
