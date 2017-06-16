using System;

namespace ZooEmulator.Animals
{
    public class Wolf : AnimalBase
    {
        public Wolf(string name) : base(name, 4)
        {
        }

        public override string GetType()
        {
            return "Wolf";
        }
    }
}
