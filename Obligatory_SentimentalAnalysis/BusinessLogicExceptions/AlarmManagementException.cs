using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicExceptions
{
	public class AlarmManagementException : Exception
	{
		public AlarmManagementException() : base()
		{

		}

		public AlarmManagementException(String message) : base(message)
		{

		}

		public AlarmManagementException(String message, Exception exception) : base(message, exception)
		{

		}

	}
}
