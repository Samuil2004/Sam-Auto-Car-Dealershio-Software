using Classes;
using LogicLayer.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using LogicLayer.InterfacesLL;
using DataAccessLayer.CustomExceptions;
using Microsoft.SharePoint.Client;

namespace WebApplication___Sam_Auto.Pages
{
    public class ForgotPasswordModel : PageModel
    {
        [BindProperty]
        public ForgotPasswordDTOLL ForgotPasswordDTO { get; set; }
        private readonly IPeopleInterfaceLogicLayer _peopleManager;

        public ForgotPasswordModel(IPeopleInterfaceLogicLayer peopleManager)
        {
            this._peopleManager = peopleManager;
        }
        public List<string> GetSecretQuestions()
        {
            try
            {
                return _peopleManager.ReadSecretQuestions().Values.ToList();
            }
            catch (DALException ex)
            {
                TempData["ErrorMessage"] = $"Database error: {ex.Message}";
                return null;
            }
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                try
                {
                    Person? person = _peopleManager.CheckUserSecretQuestionForForgottenPassword(ForgotPasswordDTO.Email, ForgotPasswordDTO.SecretQuestion, ForgotPasswordDTO.SecretQuestionAnswer);
                    if (person != null && person is Customer customer)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("Id", person.GetId.ToString()));

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
                        return new RedirectToPageResult("/UserProfile");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Incorrect data is provided";
                        return Page();
                    }
                }
                catch (ArgumentNullException ex)
                {
                    TempData["ErrorMessage"] = $"{ex.Message}";
                    return Page();
                }
                catch (UserNotFound ex)
                {
                    TempData["ErrorMessage"] = $"{ex.Message}";
                    return Page();
                }
                catch (VehicleNotFound ex)
                {
                    TempData["ErrorMessage"] = $"{ex.Message}";
                    return Page();
                }
                catch (DALException ex)
                {
                    TempData["ErrorMessage"] = $"Database error: {ex.Message}";
                    return Page();
                }
            }
            return Page();
        }
    }
}
