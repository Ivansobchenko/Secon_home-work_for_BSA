using System;
using ZooEmulator.Factory;
using ZooEmulator.ZooStructure;

namespace ZooEmulator.Commands
{
    public class AddAnimalCommand : ICommand
    {
        private Zoo _zoo;
        AnimalFactory factory = new AnimalFactory();

        public AddAnimalCommand(Zoo zoo)
        {
            _zoo = zoo;
        }

        public void Execute(string[] data)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            if (data.Length!=3)
                Console.WriteLine("Wrong command format!");
            else if (_zoo.Animals.ContainsKey(data[2].ToLower()))
                Console.WriteLine("Animal with such nickname already exist.");
            else
            {
                try
                {
                _zoo.AddAnimal(factory.GetAnimal(data[1], data[2]));

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Animal added.");
                }
                catch (Exceptions.InvalidAnimalTypeException)
                {
                    
                    Console.WriteLine("Invalid animal type.");
                }

            }

        }
    }
}
