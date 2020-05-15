using System;


namespace BusinessLogicExceptions
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
