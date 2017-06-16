using System;

namespace ZooEmulator.Animals
{
    public class Tiger : AnimalBase
    {
        public Tiger(string name):base(name, 4)
        {
        }

        public override string GetType()
        {
            return "Tiger";
        }
    }
}
