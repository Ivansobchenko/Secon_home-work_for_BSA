using System;
using ZooEmulator.Animals;
using ZooEmulator.ZooStructure;

namespace ZooEmulator.Commands
{
    public class TreatAnimalCommand : ICommand
    {
        private Zoo _zoo;

        public TreatAnimalCommand(Zoo zoo)
        {
            _zoo = zoo;
        }
        public void Execute(string[] data)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            if (data.Length != 2)
                Console.WriteLine("Wrong command format!");
            else if (!_zoo.Animals.ContainsKey(data[1].ToLower()))
                Console.WriteLine("Animal with such nickname not found.");
            else if (_zoo.Animals[data[1].ToLower()].State == AnimalState.Dead)
                Console.WriteLine("Animal is dead.");
            else if (_zoo.Animals[data[1].ToLower()].IsHealthIsMax)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Animal is healthy.");
            }
            else
            {
                _zoo.Treat(data[1].ToLower());

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(data[1] + " was treated.");
            }
        }
    }
}
