using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.CustomExceptions;
using LogicLayer.InterfacesLL;

namespace LogicLayer.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IsEmailExistingAttributeLL : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var peopleManager = (IPeopleInterfaceLogicLayer)validationContext.GetService(typeof(IPeopleInterfaceLogicLayer));
                if (peopleManager == null)
                {
                    peopleManager = validationContext.Items["PeopleManager"] as IPeopleInterfaceLogicLayer;
                }
                if (peopleManager == null)
                {
                    return new ValidationResult("People manager service is not available.");
                }

                string email = (string)value;

                if (string.IsNullOrEmpty(email))
                {
                    return new ValidationResult("Email is required");
                }

                else if (!peopleManager.IsEmailAvailable(email))
                {
                    return new ValidationResult(ErrorMessage);
                }

                return ValidationResult.Success;
            }
            catch (ArgumentNullException ex)
            {
                return new ValidationResult(ex.Message);
            }
            catch (DALException ex)
            {
                return new ValidationResult(ex.Message);
            }
        }
    }
}