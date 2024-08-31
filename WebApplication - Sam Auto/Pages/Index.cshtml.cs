using Classes;
using DataAccessLayer;
using DataAccessLayer.CustomExceptions;
using LogicLayer.InterfacesLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.BusinessData.MetadataModel;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Security.Claims;

namespace WebApplication___Sam_Auto.Pages
{
    public class IndexModel : PageModel
    {
        private IVehicleBasicInterfaceLogicLayer _vehicleManager;
        private IPeopleInterfaceLogicLayer _peopleManager;
        private ISuggestionsInterfaceLogicLayer _suggestionsManager;
        public List<Vehicle> listToUse;
        public int numOfPages;
        public int UserId { get; private set; }


        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public string SelectedFilter { get; set; }
        public IndexModel(IVehicleBasicInterfaceLogicLayer vehicleManager, IPeopleInterfaceLogicLayer peopleManager,ISuggestionsInterfaceLogicLayer suggstionsManger)
        {
            _vehicleManager = vehicleManager;
            _peopleManager = peopleManager;
            _suggestionsManager = suggstionsManger;
        }
        private int CalculateNumOfPages()
        {
            int pageSize = 10;
            return (int)Math.Ceiling((double)_vehicleManager.ReadNumberOfVehicles() / pageSize);
        }

        public IActionResult OnPostRecentlyAdded(string filter)
        {
            try
            {
                listToUse = _vehicleManager.InsertionSortByPublicationDate();
                CurrentPage = 0;
                return Page();
            }
            catch (DALException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return null;
            }
            catch (VehicleNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return null;
            }
            catch (ArgumentNullException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return null;
            }
        }
        public IActionResult OnPostTopRated(string filter)
        {
            try
            {
                listToUse = _vehicleManager.InsertionSortByRating();
                CurrentPage = 0;
                return Page();
            }
            catch (DALException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return null;
            }
            catch (VehicleNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return null;
            }
            catch (ArgumentNullException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return null;
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

                    return RedirectToPage(new { CurrentPage, SelectedFilter });
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
                    this.numOfPages = 2;
                }
                else
                {
                    UserId = -1;
                    this.numOfPages = CalculateNumOfPages();
                }
                if (CurrentPage < 1)
                {
                    CurrentPage = 1;
                }
                else if (CurrentPage > numOfPages)
                {
                    CurrentPage = numOfPages;
                }
                if (string.IsNullOrEmpty(SelectedFilter))
                {
                    listToUse = _suggestionsManager.GetSuggestionsForPerson(UserId, CurrentPage);
                }
                else
                {
                    switch (SelectedFilter)
                    {
                        case "RecentlyAdded":
                            listToUse = _vehicleManager.InsertionSortByPublicationDate();
                            this.numOfPages = 1;
                            break;
                        case "TopRated":
                            listToUse = _vehicleManager.InsertionSortByRating();
                            this.numOfPages = 1;
                            break;
                        default:
                            listToUse = _suggestionsManager.GetSuggestionsForPerson(UserId, CurrentPage);
                            numOfPages = CalculateNumOfPages();
                            break;
                    }
                }
            }
            catch (VehicleNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                listToUse = null;
            }
            catch (DALException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                listToUse = null;
            }
            catch (UserNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                listToUse = null;
            }
            catch (ArgumentNullException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                listToUse = null;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                listToUse = null;
            }
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
                    foreach (Vehicle vEhicle in bookmarkedVehicles)
                    {
                        if (vEhicle.GetVehicleId == vehicle.GetVehicleId)
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
            catch (VehicleNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return false;
            }
            catch (DALException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return false;
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
                    return RedirectToPage(new { CurrentPage, SelectedFilter });

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
