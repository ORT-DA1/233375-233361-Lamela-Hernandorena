using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IAlarm
    {
        void UpdateState(Phrase[] phrases, DateTime date);

        void VerifyFormatAlarm();
        string Show();
    }
}
