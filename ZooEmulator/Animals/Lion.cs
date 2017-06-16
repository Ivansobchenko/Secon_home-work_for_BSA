namespace ZooEmulator.Animals
{
    public class Lion : AnimalBase
    {
        public Lion(string name):base(name, 5)
        {                       
        }

        public override string GetType()
        {
            return "Lion";
        }
    }
}
