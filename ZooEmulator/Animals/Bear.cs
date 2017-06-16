namespace ZooEmulator.Animals
{
    public class Bear : AnimalBase
    {
        public Bear(string name) : base(name, 6)
        {
        }

        public override string GetType()
        {
            return "Bear";
        }

    }
}
