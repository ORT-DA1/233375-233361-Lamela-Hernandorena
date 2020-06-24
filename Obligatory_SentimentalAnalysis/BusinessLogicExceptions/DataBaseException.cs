using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicExceptions
{
    public class DataBaseException : Exception
    {
        public DataBaseException() : base()
        {

        }

        public DataBaseException(String message) : base(message)
        {

        }

        public DataBaseException(String message, Exception exception) : base(message, exception)
        {

        }
    }
}
