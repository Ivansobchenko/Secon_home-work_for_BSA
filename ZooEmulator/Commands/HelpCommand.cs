using System;

namespace ZooEmulator.Commands
{
    public class HelpCommand : ICommand
    {
        private UserInterface _ui;

        public HelpCommand(UserInterface ui)
        {
            _ui = ui;
        }
        public void Execute(string[] data)
        {
            if (data.Length != 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong command format!");
            }
            else _ui.Help();
        }
    }
}
