using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.CustomExceptions
{
    /// <summary>
    /// A custom exception thrown every time an issue occurs within the Data Access Layer
    /// </summary>
    public class DALException : Exception
    {
        public DALException()
        {
        }

        public DALException(string message)
            : base(message)
        {
        }

        public DALException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
