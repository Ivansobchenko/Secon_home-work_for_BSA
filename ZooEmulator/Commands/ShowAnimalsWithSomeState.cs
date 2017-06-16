using System;
using System.Collections.Generic;

namespace ZooEmulator.Commands
{
    public class ShowAnimalsWithSomeState: ICommand
    {
        private LinqRequests _linqRequests;

        public ShowAnimalsWithSomeState(LinqRequests linqRequests)
        {
            _linqRequests = linqRequests;
        }

        public void Execute(string[] data)
        {
            List<string> states = new List<string> { "sated", "hungry", "sick", "dead" };

            Console.ForegroundColor = ConsoleColor.Red;
            if (data.Length != 2)
                Console.WriteLine("Wrong command format!");
            else if (_linqRequests.IsZooEmpty())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Zoo is empty! Please, add animals.");
            }
            else if (!states.Contains(data[1].ToLower()))
                Console.WriteLine("Wrong state!");
            else _linqRequests.AnimalsWithSomeState(data[1]);
        }


        
}
}
