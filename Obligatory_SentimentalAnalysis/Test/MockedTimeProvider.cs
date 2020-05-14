using System;


namespace BusinessLogic
{
    public class MockedTimeProvider : ITimeProvider
    {
        public DateTime MockedDateTime { get; set; }
        
        public DateTime Now()
        {
            return MockedDateTime;
        }
    }
}
