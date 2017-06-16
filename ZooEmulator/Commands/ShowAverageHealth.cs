using System;

namespace ZooEmulator.Commands
{
    public class ShowAverageHealth : ICommand
    {
        private LinqRequests _linqRequests;

        public ShowAverageHealth(LinqRequests linqRequests)
        {
            _linqRequests = linqRequests;
        }

        public void Execute(string[] data)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (data.Length != 1)
                Console.WriteLine("Wrong command format!");
            else if (_linqRequests.IsZooEmpty())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Zoo is empty! Please, add animals.");
            }
            else _linqRequests.AverageHealth();
        }
    }
}
