namespace ZooEmulator.Animals
{
    public class Fox : AnimalBase
    {
        public Fox(string name) : base(name, 3)
        {
        }
        public override string GetType()
        {
            return "Fox";
        }
    }
}
