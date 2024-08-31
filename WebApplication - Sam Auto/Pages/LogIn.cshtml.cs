using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using WebApplication___Sam_Auto.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.SharePoint.Client;
using Microsoft.AspNetCore.Http;
using Classes;
using DataAccessLayer.CustomExceptions;
using LogicLayer.Models;
using LogicLayer.InterfacesLL;

namespace WebApplication___Sam_Auto.Pages
{
    public class LogInModel : PageModel
    {

        [BindProperty]
                
        public LogInDTOLL LogInDTO { get; set; }
        private readonly IPeopleInterfaceLogicLayer _peopleManager;
        public LogInModel(IPeopleInterfaceLogicLayer peopleManager)
        {
            this._peopleManager = peopleManager;
        }
        public void OnGet()
        {

            string email = HttpContext.Session.GetString(nameof(LogInDTO.Email));
            if (email != null)
            {
                if (LogInDTO == null)
                {
                    LogInDTO = new LogInDTOLL();
                }
                LogInDTO.Email = email;
            }
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
                    Person? user = _peopleManager.CheckForUserWeb(LogInDTO.Email, LogInDTO.Password);
                    if (user != null)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("Id", user.GetId.ToString()));

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
                        HttpContext.Session.SetString(nameof(LogInDTO.Email), LogInDTO.Email);

                        return new RedirectToPageResult("/Index");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "User with provided username and password \ndoes not exist";
                        return Page();
                    }
                }
                catch (UserNotFound ex)
                {
                    TempData["ErrorMessage"] = $"{ex.Message}";
                    return Page();
                }
                catch (ArgumentNullException ex)
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
        }
    }
}
