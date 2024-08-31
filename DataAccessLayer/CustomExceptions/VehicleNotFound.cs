using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.CustomExceptions
{
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
