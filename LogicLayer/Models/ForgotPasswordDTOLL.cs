using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    /// <summary>
    /// DTO model used for updating user account password
    /// </summary>
    public class ForgotPasswordDTOLL
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [MaxLength(80)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please add a secret question")]
        public string SecretQuestion { get; set; }


        [Required(ErrorMessage = "Please add an asnwer")]
        public string SecretQuestionAnswer { get; set; }

    }
}
