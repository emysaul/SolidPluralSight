using DataConstract.Services;
using System;

namespace LogImplementation
{
    public class ConsoleMessagingServiceImplementation : MessagingService
    {
        public void LogMessages(params string[] messages)
        {
            foreach (var message in messages)
            {
                Console.WriteLine(message);
            }
        }
    }
}
