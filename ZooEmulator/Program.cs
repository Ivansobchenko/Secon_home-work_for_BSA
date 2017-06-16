using System;
using ZooEmulator.ZooStructure;

namespace ZooEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            UserInterface ui = new UserInterface(zoo);

            Console.WriteLine("Welcome to ZooEmulator!!!\n\n");
            ui.Help();
            ui.ReadConsoleCommand();

            Console.WriteLine("\n\nType any key to exit");
            Console.ReadKey();
        }
    }
}
