using System;
using ZooEmulator.ZooStructure;

namespace ZooEmulator.Commands
{
    public class ViewStatusCommand : ICommand
    {
        private Zoo _zoo;

        public ViewStatusCommand(Zoo zoo)
        {
            _zoo = zoo;
        }
        public void Execute(string[] data)
        {
            if (data.Length != 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong command format!");
            }
            else _zoo.ToString();
        }
    }
}
