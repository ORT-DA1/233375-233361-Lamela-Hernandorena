using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
