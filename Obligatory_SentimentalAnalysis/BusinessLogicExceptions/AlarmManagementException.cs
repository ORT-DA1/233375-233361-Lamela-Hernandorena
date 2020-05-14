using System;


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
