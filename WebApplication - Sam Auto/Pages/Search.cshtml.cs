using Classes;
using DataAccessLayer;
using DataAccessLayer.CustomExceptions;
using Logic_layer.Enumerations;
using LogicLayer.InterfacesLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Security.Claims;

namespace WebApplication___Sam_Auto.Pages
{
    public class SearchModel : PageModel
    {
        private IVehicleBasicInterfaceLogicLayer _vehicleManager;
        private IPeopleInterfaceLogicLayer _peopleManager;
        public List<Vehicle> listToUse { get; set; }
        public int numOfPages;
        [BindProperty(SupportsGet = true)]
        public string Category { get; set; }
        [BindProperty(SupportsGet = true)]

        public string year { get; set; }
        [BindProperty(SupportsGet = true)]

        public string engine { get; set; }
        [BindProperty(SupportsGet = true)]
        public int maxPrice { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int UserId { get; private set; }


        public SearchModel(IVehicleBasicInterfaceLogicLayer vehicleManager, IPeopleInterfaceLogicLayer peopleManager)
        {
            _vehicleManager = vehicleManager;
            _peopleManager = peopleManager;
        }
        public void OnGet(string category, string year, string engine, int maxPrice = 10000, int currentPage = 1)
        {
            try
            {
                this.Category = category;
                this.year = year;
                this.engine = engine;
                this.maxPrice = maxPrice;
                this.CurrentPage = currentPage;
                if (CurrentPage < 1)
                {
                    CurrentPage = 1;
                    category = null;
                    year = null;
                    engine = null;
                }
                
                if (!string.IsNullOrEmpty(category) || !string.IsNullOrEmpty(year) || !string.IsNullOrEmpty(engine) || CurrentPage != 1)
                {
                    this.numOfPages = CalculateNumOfPages();
                    if (CurrentPage > numOfPages)
                    {
                        CurrentPage = numOfPages;
                    }
                    listToUse = new List<Vehicle>();
                    listToUse = _vehicleManager.FindSearchResults(category, year, engine, maxPrice, CurrentPage, 10);
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

        public IActionResult OnPostSearch()
        {
            try
            {
                listToUse = new List<Vehicle>();
                listToUse = _vehicleManager.FindSearchResults(Category, year, engine, maxPrice, CurrentPage, 10);
                this.numOfPages = CalculateNumOfPages();
                CurrentPage = 1;
                return Page();
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
            catch (DALException ex)
            {
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return null;
            }
        }
        private int CalculateNumOfPages()
        {
            int pageSize = 10;
            return (int)Math.Ceiling((double)_vehicleManager.CountResults(Category, year, engine, maxPrice) / pageSize);
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
        public IActionResult OnPostUnBookmarkVehicle(int vehicleId, int currentPage, string category,string year, string engine, int maxPrice)
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
                    return RedirectToPage("/Search", new { CurrentPage = currentPage, category = category, year = year, engine = engine, maxPrice = maxPrice });

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

        public IActionResult OnPostBookmarkVehicle(int vehicleId, int currentPage, string category, string year, string engine, int maxPrice)
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
                    return RedirectToPage("/Search", new { CurrentPage = currentPage, category = category, year = year, engine = engine, maxPrice = maxPrice });
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

        public List<string> GetEngineTypes()
        {
            List<string> engineTypes = new List<string>();
            foreach(EngineType engine in Enum.GetValues(typeof(EngineType)))
            {
                engineTypes.Add(engine.ToString());
            }
            return engineTypes;
        }
    }
}
