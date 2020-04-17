using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicExceptions
{
	public class EntityManagementException : Exception
	{
		public EntityManagementException() : base()
		{

		}

		public EntityManagementException(String message) : base(message)
		{

		}

		public EntityManagementException(String message, Exception exception) : base(message, exception)
		{

		}
	}
}
