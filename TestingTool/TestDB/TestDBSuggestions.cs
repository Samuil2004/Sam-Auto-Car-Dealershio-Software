using Classes;
using DataAccessLayer.InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestingTool.TestDB
{
    public class TestDBSuggestions : ISuggestionsInterfaceDataAccessLayer
    {

        private Dictionary<int, List<int>> bookmarks = new Dictionary<int, List<int>>();
        public TestDBSuggestions()
        {
            bookmarks.Add(1, new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            bookmarks.Add(2, new List<int>() { 2, 3, 4, 5, 11, 12, 14 });
            bookmarks.Add(3, new List<int>() { 9, 10, 18, 20, 17, 19 });
            bookmarks.Add(4, new List<int>() { 2, 15, 16, 21, 22, 23, 24 });
        }
        public Dictionary<int, int> CalculateCommonBookmarks(int personId)
        {
            Dictionary<int, int> commonBookmarksCount = new Dictionary<int, int>();
            List<int> myBookmarks = bookmarks[personId];

            foreach (var userBookmarks in bookmarks)
            {
                int userId = userBookmarks.Key;
                List<int> userVehicleIds = userBookmarks.Value;
                if (userId == personId)
                    continue;

                int commonCount = 0;
                foreach (int vehicleId in userVehicleIds)
                {
                    if (myBookmarks.Contains(vehicleId))
                    {
                        commonCount++;
                    }
                }
                commonBookmarksCount.Add(userId, commonCount);
            }

            Dictionary<int, int> sortedCommonBookmarksCount = new Dictionary<int, int>();
            while (commonBookmarksCount.Count > 0)
            {
                int maxUserId = -1;
                int maxCount = -1;

                foreach (var item in commonBookmarksCount)
                {
                    if (item.Value > maxCount)
                    {
                        maxUserId = item.Key;
                        maxCount = item.Value;
                    }
                }
                sortedCommonBookmarksCount.Add(maxUserId, maxCount);
                commonBookmarksCount.Remove(maxUserId);
            }

            return sortedCommonBookmarksCount;
        }
        public List<int> GetDistinctVehiclesFromOtherUsers(int currentUserId, int secondUserId)
        {
            List<int> currentUserBookmarkedVehicles = new List<int>();
            foreach (var item in bookmarks)
            {
                if (item.Key == currentUserId)
                {
                    currentUserBookmarkedVehicles = item.Value;
                }
            }

            List<int> otherUserBookmarkedVehicles = new List<int>();
            foreach (var item in bookmarks)
            {
                if (item.Key == secondUserId)
                {
                    otherUserBookmarkedVehicles = item.Value;
                }
            }

            List<int> distinctVehicles = new List<int>();
            foreach (int vehicleId in otherUserBookmarkedVehicles)
            {
                if (!currentUserBookmarkedVehicles.Contains(vehicleId))
                {
                    distinctVehicles.Add(vehicleId);
                }
            }
            return distinctVehicles;
        }
    }
}
