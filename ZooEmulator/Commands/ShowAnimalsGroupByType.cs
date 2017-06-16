using System;

namespace ZooEmulator.Commands
{
    public class ShowAnimalsGroupByType: ICommand
    {
        private LinqRequests _linqRequests;

        public ShowAnimalsGroupByType(LinqRequests linqRequests)
        {
            _linqRequests = linqRequests;
        }

        public void Execute(string[] data)
        {

            if (data.Length != 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong command format!");
            }
            else if (_linqRequests.IsZooEmpty())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Zoo is empty! Please, add animals.");
            }
            else _linqRequests.AnimalsGroupByType();
        }
    }
}
