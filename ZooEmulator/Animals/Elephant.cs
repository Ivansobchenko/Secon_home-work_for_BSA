namespace ZooEmulator.Animals
{
    public class Elephant : AnimalBase 
    {
        public Elephant(string name) : base(name, 7)
        {
        }
        public override string GetType()
        {
            return "Elephant";
        }
    }
}
