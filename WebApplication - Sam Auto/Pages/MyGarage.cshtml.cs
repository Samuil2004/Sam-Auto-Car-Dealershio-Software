using Classes;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using DataAccessLayer.CustomExceptions;
using System.Net;
using Microsoft.AspNetCore.Http;
using LogicLayer.InterfacesLL;

namespace WebApplication___Sam_Auto.Pages
{
    [Authorize]
    public class MyGarageModel : PageModel
    {
        private IPeopleInterfaceLogicLayer _peopleManager;
        private IVehicleBasicInterfaceLogicLayer _vehicleManager;

        public List<Vehicle> listToUse { get; set; }
        public int numOfPages;
        [BindProperty(SupportsGet = true)]
        public string FilterOption { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int UserId { get; private set; }

        public MyGarageModel(IPeopleInterfaceLogicLayer peopleManager, IVehicleBasicInterfaceLogicLayer vehicleManager)
        {
            _peopleManager = peopleManager;
            _vehicleManager = vehicleManager;
        }
        private int CalculateNumOfPages()
        {
            int pageSize = 10;
            return (int)Math.Ceiling((double)listToUse.Count / pageSize);
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
                    listToUse = new List<Vehicle>();
                    if (string.IsNullOrEmpty(FilterOption))
                    {
                        FilterOption = "bookmarked";
                    }

                    if (FilterOption == "bookmarked")
                    {
                        foreach (Vehicle vehicle in _vehicleManager.GetCustomerBookmarkedVehicles(UserId))
                        {
                            listToUse.Add(vehicle);
                        }
                    }
                    else if (FilterOption == "saved")
                    {
                        foreach (Vehicle vehicle in _vehicleManager.GetCustomerSavedVehicles(UserId))
                        {
                            listToUse.Add(vehicle);
                        }
                    }

                    this.numOfPages = CalculateNumOfPages();
                    if (CurrentPage < 1)
                    {
                        CurrentPage = 1;
                    }
                    if (CurrentPage > numOfPages)
                    {
                        CurrentPage = numOfPages;
                    }
                    listToUse = listToUse.Skip((CurrentPage - 1) * 10).Take(10).ToList();
                }
                else
                {
                    TempData["ErrorMessage"] = $"User was not found";
                }
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

        public IActionResult OnPostFilter()
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
                    listToUse = new List<Vehicle>();

                    if (FilterOption == "bookmarked")
                    {
                        foreach (Vehicle vehicle in _vehicleManager.GetCustomerBookmarkedVehicles(UserId))
                        {
                            listToUse.Add(vehicle);
                        }
                    }
                    else if (FilterOption == "saved")
                    {
                        foreach (Vehicle vehicle in _vehicleManager.GetCustomerSavedVehicles(UserId))
                        {
                            listToUse.Add(vehicle);
                        }
                    }

                    this.numOfPages = CalculateNumOfPages();
                    listToUse = listToUse.Skip((CurrentPage - 1) * 10).Take(10).ToList();
                }

                return RedirectToPage(new { FilterOption });
            }
            catch (UserNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return Page();
            } 
            catch (VehicleNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return Page();
            }
            catch (DALException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return Page();
            }
        }

        public List<Vehicle> GetBookmarkedVehicles()
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
                    listToUse = new List<Vehicle>();

                    foreach (Vehicle vehicle in _vehicleManager.GetCustomerBookmarkedVehicles(UserId))
                    {
                        listToUse.Add(vehicle);
                    }
                    this.numOfPages = CalculateNumOfPages();
                    return listToUse.Skip((CurrentPage - 1) * 10).Take(10).ToList();
                }
                else
                {
                    TempData["ErrorMessage"] = $"User was not found";
                    return null;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return null;
            }
            catch (VehicleNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return null;
            }
            catch (UserNotFound ex)
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
        public IActionResult OnPostUnBookmarkVehicle(int vehicleId, string filterOption, int currentPage)
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
                    return RedirectToPage("/MyGarage", new { FilterOption = filterOption, CurrentPage = currentPage });
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
                return false;
            }
            return false;
        }


        public IActionResult OnPostBookmarkVehicle(int vehicleId, string filterOption, int currentPage)
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
                    return RedirectToPage("/MyGarage", new { FilterOption = filterOption, CurrentPage = currentPage });
                }
                return Page();
            }
            catch (UserNotFound ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return null;
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
    }
}

