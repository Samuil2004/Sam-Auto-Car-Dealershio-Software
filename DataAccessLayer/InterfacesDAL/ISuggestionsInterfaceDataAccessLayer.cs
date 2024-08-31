using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.InterfacesDAL
{
    public interface ISuggestionsInterfaceDataAccessLayer
    {
        Dictionary<int, int> CalculateCommonBookmarks(int personId);
        List<int> GetDistinctVehiclesFromOtherUsers(int currentUserId, int secondUserId);
    }
}
