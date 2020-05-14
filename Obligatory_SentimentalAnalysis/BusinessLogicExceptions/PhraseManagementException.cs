using System;


namespace BusinessLogicExceptions
{
	public class PhraseManagementException : Exception
	{

		public PhraseManagementException() : base()
		{

		}

		public PhraseManagementException(String message) : base(message)
		{

		}

		public PhraseManagementException(String message, Exception exception) : base(message, exception)
		{

		}

	}
}
