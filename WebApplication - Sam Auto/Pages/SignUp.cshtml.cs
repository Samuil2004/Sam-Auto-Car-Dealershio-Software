using Classes;
using DataAccessLayer.CustomExceptions;
using LogicLayer.InterfacesLL;
using LogicLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Office.SharePoint.Tools;
using Microsoft.SharePoint.Client;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using WebApplication___Sam_Auto.Models;


namespace WebApplication___Sam_Auto.Pages
{

    public class SignUpModel : PageModel
    {
        [BindProperty]
        public SignUpDTOLL SignUpDTO { get; set; }

        private readonly IPeopleInterfaceLogicLayer _peopleManager;
        public SignUpModel(IPeopleInterfaceLogicLayer peopleManager)
        {
            this._peopleManager = peopleManager;
        }

        public void OnGet()
        {
        }
        public List<string> GetSecretQuestions()
        {
            try
            {
                return _peopleManager.ReadSecretQuestions().Values.ToList();
            }
            catch(DALException ex)
            {
                TempData["ErrorMessage"] = $"{ex.Message}";
                return null;
            }
        }
        public IActionResult OnPost()

        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else { 
                List<Claim> claims = new List<Claim>();

                try
                {
                    int personId = _peopleManager.CreatePerson(new Customer(SignUpDTO.FirstName, SignUpDTO.LastName, SignUpDTO.Email, SignUpDTO.PhoneNumber.ToString(), false), SignUpDTO.Password,SignUpDTO.SecretQuestion,SignUpDTO.SecretQuestionAnswer);
                    
                    claims.Add(new Claim("Id", personId.ToString()));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                    return new RedirectToPageResult("/Index");
                }
                catch (ArgumentNullException ex)
                {
                    TempData["ErrorMessage"] = $"{ex.Message}";
                }
                catch (DALException ex)
                {
                    TempData["ErrorMessage"] = $"{ex.Message}";
                }
            }
            return Page();            
        }
    }
}
