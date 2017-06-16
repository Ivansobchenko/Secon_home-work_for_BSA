using System;

namespace ZooEmulator.Commands
{
    public class ShowAnimalsWithMaxAndMinHealth : ICommand
    {

        private LinqRequests _linqRequests;

        public ShowAnimalsWithMaxAndMinHealth(LinqRequests linqRequests)
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
            else _linqRequests.MaxAndMinHealth();
        }
    }
}
