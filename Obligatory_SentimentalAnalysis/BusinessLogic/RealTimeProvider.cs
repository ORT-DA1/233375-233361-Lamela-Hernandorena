using System;


namespace BusinessLogic
{
    public class RealTimeProvider : ITimeProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
