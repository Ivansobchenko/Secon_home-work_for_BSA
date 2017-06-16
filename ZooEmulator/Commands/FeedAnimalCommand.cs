using System;
using ZooEmulator.Animals;
using ZooEmulator.ZooStructure;

namespace ZooEmulator.Commands
{
    public class FeedAnimalCommand : ICommand
    {
        private Zoo _zoo;

        public FeedAnimalCommand(Zoo zoo)
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
            else if (_zoo.Animals[data[1].ToLower()].State == AnimalState.Sick)
                Console.WriteLine("First treat the animal.");
            else if (_zoo.Animals[data[1].ToLower()].State == AnimalState.Dead)
                Console.WriteLine("Animal is dead.");
            else
            {
                _zoo.Feed(data[1].ToLower());

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(data[1] + " was fed.");
            }
        }
    }
}
