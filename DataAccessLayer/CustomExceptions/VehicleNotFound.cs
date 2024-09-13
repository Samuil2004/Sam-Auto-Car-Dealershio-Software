using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.CustomExceptions
{
    /// <summary>
    /// A custom exception thrown by the Data Access Layer and the Logic Layer in case a vehicle can not be found
    /// </summary>
    public class VehicleNotFound : Exception
    {
        public VehicleNotFound()
        {
        }

        public VehicleNotFound(string message)
            : base(message)
        {
        }

        public VehicleNotFound(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
