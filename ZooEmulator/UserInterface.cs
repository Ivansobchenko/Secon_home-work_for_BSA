using System;
using System.Collections.Generic;
using ZooEmulator.Commands;
using ZooEmulator.ZooStructure;

namespace ZooEmulator
{
    public class UserInterface
    {
        private Zoo _zoo;
        private Dictionary<string, ICommand> _commands;
        private LinqRequests _linqRequests;


        public UserInterface(Zoo zoo)
        {
            _zoo = zoo;
            _linqRequests = new LinqRequests(_zoo.Animals);

            _commands = new Dictionary<string, ICommand>();
            _commands.Add("add", new AddAnimalCommand(_zoo));
            _commands.Add("feed", new FeedAnimalCommand(_zoo));
            _commands.Add("treat", new TreatAnimalCommand(_zoo));
            _commands.Add("remove", new RemoveAnimalCommand(_zoo));
            _commands.Add("help", new HelpCommand(this));
            _commands.Add("status", new ViewStatusCommand(_zoo));

            _commands.Add("1", new ShowAnimalsGroupByType(_linqRequests));
            _commands.Add("2", new ShowAnimalsWithSomeState(_linqRequests));
            _commands.Add("3", new ShowSickTigers(_linqRequests));
            _commands.Add("4", new ShowElephantByName(_linqRequests));
            _commands.Add("5", new ShowHungryAnimals(_linqRequests));
            _commands.Add("6", new ShowMostHealthyAnimals(_linqRequests));
            _commands.Add("7", new ShowCountOfDeadAnimals(_linqRequests));
            _commands.Add("8", new ShowWolfsAndBears(_linqRequests));
            _commands.Add("9", new ShowAnimalsWithMaxAndMinHealth(_linqRequests));
            _commands.Add("10", new ShowAverageHealth(_linqRequests));
        }

        public void ReadConsoleCommand()
        {
            while (!_zoo.IsAllAnimalsDied)
            {
                Console.ResetColor();
                Console.WriteLine("\nType a command: ");
                string[] command = Console.ReadLine().Split(' ');
                if (!_zoo.IsAllAnimalsDied)
                {
                    if (_commands.ContainsKey(command[0].ToLower()))
                    {
                        _commands[command[0].ToLower()].Execute(command);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong command! Type \"help\" for help.");

                    }
                }
                else
                {
                Console.Clear();
                _commands["status"].Execute(new string[1]);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nAll animals in zoo have had died!");
                }

                

            }

        }

        public void Help()
        {
            Console.WriteLine("Commands list:\n");
            Console.WriteLine("add  <Animal Type> <Animal Name>");
            Console.WriteLine("feed <Animal Name>");
            Console.WriteLine("treat <Animal Name>");
            Console.WriteLine("remove <Animal Name>");
            Console.WriteLine("status");
            Console.WriteLine("help");
            Console.WriteLine("\nAnimal types: bear | elephant | fox | lion | tiger | wolf\n");
            Console.WriteLine("\n\nLINQ requests:\n");
            Console.WriteLine("1 - Show all animals grouped by animal type");
            Console.WriteLine("2 <state> - Show animals by state: sated | hungry | sick | dead");
            Console.WriteLine("3 - Show all tigers who are sick");
            Console.WriteLine("4 <Nickname> - Show an elephant by Nickname");
            Console.WriteLine("5 - Show a list of nicknames of all hungry animal");
            Console.WriteLine("6 - Show the healthiest animals of each type");
            Console.WriteLine("7 - Show the number of dead animals of each type");
            Console.WriteLine("8 - Show all wolves and bears who have health above 3");
            Console.WriteLine("9 - Show the animals with maximum and minimal health");
            Console.WriteLine("10 - Show the average health of animals in the zoo");
        }

    }
}
