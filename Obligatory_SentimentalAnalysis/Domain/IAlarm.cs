using System;


namespace Domain
{
    public interface IAlarm
    {
        void UpdateState(Phrase[] phrases, DateTime date);
        void VerifyFormatAlarm();
        string Show();
    }
}
