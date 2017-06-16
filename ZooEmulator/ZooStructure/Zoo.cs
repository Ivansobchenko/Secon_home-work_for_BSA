using System;
using System.Collections.Generic;
using ZooEmulator.Animals;

namespace ZooEmulator.ZooStructure
{
    public class Zoo
    {
        private Dictionary<string, AnimalBase> _animals;

        public Dictionary<string, AnimalBase> Animals {
            get { return _animals;}
        }

        private ZooLifeCycle _lifeCycle;
        public bool IsAllAnimalsDied
        {
            get { return _lifeCycle.IsAllAnimalsDied(); }
        }

        public Zoo()
        {
            _animals = new Dictionary<string, AnimalBase>();
            _lifeCycle = new ZooLifeCycle(_animals);
        }

        public void AddAnimal(AnimalBase animal)
        {
            _animals.Add(animal.Nickname.ToLower(),animal);
        }

        public void RemoveAnimal(string name)
        {
            _animals.Remove(name.ToLower());
        }

        public void Feed(string name)
        {
            _animals[name.ToLower()].Feed();
        }

        public void Treat(string name)
        {
            _animals[name.ToLower()].Treet();
        }

        public override string ToString()
        {
            Console.WriteLine("Name: \t\t HP: \t\t State:");
            foreach (var animal in _animals.Values)
            {
                Console.WriteLine("{0} \t\t {1} \t\t {2}", animal.Nickname, animal.Health, animal.State);
            }
            return "";

        }


    }
}
