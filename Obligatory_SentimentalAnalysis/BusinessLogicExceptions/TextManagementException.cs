using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class TextManagementException: Exception
	{
		public TextManagementException() : base()
		{

		}

		public TextManagementException(String message) : base(message)
		{

		}

		public TextManagementException(String message, Exception exception) : base(message, exception)
		{

		} 
	}
}
