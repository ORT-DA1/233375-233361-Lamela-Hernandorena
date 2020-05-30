using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicExceptions
{
    public class AuthorException : Exception
    {
        public AuthorException() : base()
        {

        }

        public AuthorException(String message) : base(message)
        {

        }

        public AuthorException(String message, Exception exception) : base(message, exception)
        {

        }

    }
}
