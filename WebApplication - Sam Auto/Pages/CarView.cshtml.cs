using Classes;
using DataAccessLayer;
using DataAccessLayer.CustomExceptions;
using LogicLayer.InterfacesLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Security.Claims;

namespace WebApplication___Sam_Auto.Pages
{
    public class CarViewModel : PageModel
    {
        private IVehicleBasicInterfaceLogicLayer _vehicleManager;
        private IPeopleInterfaceLogicLayer _peopleManager;
        private Vehicle selectedVehicle;
        public int UserId { get; private set; }

        public CarViewModel(IVehicleBasicInterfaceLogicLayer vehicleManager, IPeopleInterfaceLogicLayer peopleManager)
        {

            _vehicleManager = vehicleManager;
            _peopleManager = peopleManager;

        }

        public void OnGet(int id)
        {
            try
            {
                if(id < 1)
                {
                    throw new VehicleNotFound($"Vehicle {id} was not found");
                }
                this.selectedVehicle = _vehicleManager.ReadVehicle(id);
                if(this.selectedVehicle.GetIsBought)
                {
                    throw new VehicleNotFound("Vehicle is not available. Please choose another one!");
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
            }
            catch (VehicleNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
            }
            catch (DALException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
            }
        }
        public Vehicle GetSelectedVehicle()
        {

            return this.selectedVehicle;
        }
        public bool IsVehicleAlreadyBookmarked(Vehicle vehicle)
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
                    List<Vehicle> bookmarkedVehicles = _vehicleManager.GetCustomerBookmarkedVehicles(UserId);
                    foreach(Vehicle vEhicle in bookmarkedVehicles)
                    {
                        if(vEhicle.GetVehicleId == vehicle.GetVehicleId)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                return true;
            }
            catch (UserNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return false;
            }
            catch (DALException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return false;
            }
            catch (VehicleNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return false;
            }
        }
        public IActionResult OnPostBookmarkVehicle(int vehicleId)
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

                    _peopleManager.BookmarkVehicle(vehicleId, UserId);
                    return RedirectToPage("/CarView", new { id = vehicleId });
                }
                return Page();
            }
            catch (UserNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return RedirectToPage("/CarView", new { id = vehicleId });
            }
            catch (VehicleNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return RedirectToPage("/CarView", new { id = vehicleId });
            }
            catch (DALException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return RedirectToPage("/CarView", new { id = vehicleId });
            }
        }
        public IActionResult OnPostUnBookmarkVehicle(int vehicleId)
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

                    _peopleManager.UnBookmarkVehicle(UserId, vehicleId);
                    return RedirectToPage("/CarView", new { id = vehicleId });
                }
                return Page();
            }
            catch (UserNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return null;
            }
            catch (VehicleNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return null;
            }
            catch (DALException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return null;
            }
        }

        public string GetSavingDeadline()
        {
            return DateTime.Today.AddDays(3).ToString("dd/MM/yyyy");
        }

        public IActionResult OnPostSaveVehicleForBuying(int vehicleId)
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

                    _vehicleManager.ReserveVehicle(vehicleId, UserId);
                    return RedirectToPage("/CarView", new { id = vehicleId });
                }
                return Page();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return null;
            }
            catch (DALException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return null;
            }
        }

        public IActionResult OnPostRate(int rating, int vehicleId)
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

                    _vehicleManager.RateVehicle(vehicleId, UserId, rating);
                    return RedirectToPage("/CarView", new { id = vehicleId });
                }
                return Page();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return null;
            }
            catch (DALException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return null;
            }
        }

        public bool IsImageUrlAccessible(string imageUrl)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(imageUrl);
                request.Method = "HEAD";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        if (response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
            }
            
            }
            catch (WebException ex)
            {

            }
            return false;
        }
    }
}
