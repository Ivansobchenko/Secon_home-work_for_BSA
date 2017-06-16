namespace ZooEmulator.Commands
{
    public interface ICommand
    {
        void Execute(string[] data);
    }
}
