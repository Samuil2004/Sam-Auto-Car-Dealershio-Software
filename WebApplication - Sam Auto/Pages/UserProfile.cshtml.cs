using Classes;
using DataAccessLayer;
using DataAccessLayer.CustomExceptions;
using LogicLayer.InterfacesLL;
using LogicLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using WebApplication___Sam_Auto.Models;

namespace WebApplication___Sam_Auto.Pages
{
    [Authorize]

    public class UserProfileModel : PageModel
    {
        [BindProperty]
        public AccountUpdateDTOLL AccountUpdateDTO { get; set; }
        private IPeopleInterfaceLogicLayer _peopleManager;
        public int UserId { get; private set; }
        public UserProfileModel(IVehicleBasicInterfaceLogicLayer vehicleManager, IPeopleInterfaceLogicLayer peopleManager)
        {
            _peopleManager = peopleManager;
        }
        public void OnGet()
        {
            try
            {
                var userClaims = User.Claims;
                string userId = null;

                foreach (var claim in userClaims)
                {
                    if (claim.Type == "Id")
                    {
                        userId = claim.Value;
                        break;
                    }
                }
                if (userId != null)
                {
                    UserId = Convert.ToInt32(userId);

                    Person loggedInPerson = _peopleManager.GetUserById(UserId);
                    AccountUpdateDTO = new AccountUpdateDTOLL
                    {
                        FirstName = loggedInPerson.GetFirstName,
                        LastName = loggedInPerson.GetLastName,
                        Email = loggedInPerson.GetEmail,
                        PhoneNumber = loggedInPerson.GetPhoneNumber,
                    };
                }
            }
            catch (ArgumentNullException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
            }
            catch (UserNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
            }
            catch (DALException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
            }
            catch (VehicleNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
            }
        }

        public IActionResult OnPostLogOut()
        {
            HttpContext.SignOutAsync();

            return RedirectToPage("/LogIn");
        }
        public List<string> GetSecretQuestions()
        {
            try
            {
                return _peopleManager.ReadSecretQuestions().Values.ToList();
            }
            catch(DALException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return null;
            }
        }
        public IActionResult OnPostUpdate()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                var userClaims = User.Claims;
                string userId = null;

                foreach (var claim in userClaims)
                {
                    if (claim.Type == "Id")
                    {
                        userId = claim.Value;
                        break;
                    }
                }
                if (userId != null)
                {
                    UserId = Convert.ToInt32(userId);

                    Person loggedInPerson = _peopleManager.GetUserById(UserId);
                    if (!AccountUpdateDTO.Email.Equals(loggedInPerson.GetEmail, StringComparison.OrdinalIgnoreCase))
                    {
                        if (!_peopleManager.IsEmailAvailable(AccountUpdateDTO.Email))
                        {
                            ModelState.AddModelError("AccountUpdateDTO.Email", "Email already exists.");
                            return Page();
                        }
                    }
                    _peopleManager.UpdatePerson(loggedInPerson.GetId, AccountUpdateDTO.Email, AccountUpdateDTO.PhoneNumber, AccountUpdateDTO.Password, AccountUpdateDTO.SecretQuestion, AccountUpdateDTO.SecretQuestionAnswer);
                    HttpContext.SignOutAsync();
                    return RedirectToPage("/LogIn");
                }
            }
            catch (ArgumentNullException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
            }
            catch (DALException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
            }
            catch (UserNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
            }
            catch (VehicleNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
            }
            return Page();
        }
    }
}

