using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.CustomExceptions
{
    public class UserNotFound : Exception
    {
        public UserNotFound()
        {
        }

        public UserNotFound(string message)
            : base(message)
        {
        }

        public UserNotFound(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
