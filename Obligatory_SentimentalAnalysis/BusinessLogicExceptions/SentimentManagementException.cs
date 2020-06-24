using System;


namespace BusinessLogicExceptions
{
	public class SentimentManagementException: Exception
	{
		public SentimentManagementException() : base()
		{

		}

		public SentimentManagementException(String message) : base(message)
		{

		}

		public SentimentManagementException(String message, Exception exception) : base(message, exception)
		{

		} 
	}
}
