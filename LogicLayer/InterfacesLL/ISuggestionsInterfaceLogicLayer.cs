using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.InterfacesLL
{
    public interface ISuggestionsInterfaceLogicLayer
    {
        List<Vehicle> GetSuggestionsForPerson(int personId, int pageNum); 
    }
}
