using System;
using System.Collections.Generic;
using System.Linq;
using ZooEmulator.Animals;

namespace ZooEmulator
{
    public class LinqRequests
    {
        private Dictionary<string, AnimalBase> _animals;

        public LinqRequests(Dictionary<string, AnimalBase> animals)
        {
            _animals = animals;
        }

        public bool IsZooEmpty()
        {
            return _animals.Count == 0 ? true : false;
        }

        public void AnimalListToString(IEnumerable<KeyValuePair<string,AnimalBase>> animals)
        {
            Console.ResetColor();
            Console.WriteLine("Name: \t\t HP: \t\t State:");
            foreach (var animal in animals)
                Console.WriteLine("{0} \t\t {1} \t\t {2}", animal.Value.Nickname, animal.Value.Health, animal.Value.State);
        }

        public void AnimalsGroupByType()
        {
            var groupAnimals = _animals.GroupBy(animal => animal.Value.GetType(), animal => animal);
            foreach (var Animals in groupAnimals)
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n" + Animals.Key + ":");
                Console.ResetColor();
                AnimalListToString(Animals);
            }
        }

        public void AnimalsWithSomeState(string state)
        {

            var animals = _animals.Where(animal => animal.Value.State.ToString().ToLower() == state.ToLower());
            if (animals.Count() == 0)
                Console.WriteLine("No animals with such state.");
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n{0} animals:", state);
                Console.ResetColor();
                AnimalListToString(animals);
            }
        }

        public void SickTigers()
        {
            var sickTigers =
                _animals.Where(
                    animal => animal.Value.GetType().ToLower() == "tiger" && animal.Value.State == AnimalState.Sick);
            if (sickTigers.Count() == 0)
                Console.WriteLine("No sick tigers.");
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSick tigers:");
                Console.ResetColor();
                AnimalListToString(sickTigers);
            }
        }


        public void ElephantByName(string name)
        {
            var elephant = _animals.Where(animal => animal.Key == name.ToLower() && animal.Value.GetType() == "Elephant");

            if (elephant.Count() == 0)
                Console.WriteLine("Elephant with such Nickname not exist!");
            else
            {
                Console.ResetColor();
                AnimalListToString(elephant);
            }

        }

        public void HungryAnimals()
        {
            if (_animals.Any(animal => animal.Value.State == AnimalState.Hungry))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hungry animals:");
                Console.ResetColor();
                _animals.Where(animal => animal.Value.State == AnimalState.Hungry).Select(animal => animal.Key).ToList().ForEach(item => Console.WriteLine(item));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hungry animals.");
            }

        }

        public void MostHealthyAnimals()
        {
            var healthyAnimals =
                _animals.GroupBy(animals => animals.Value.GetType(), animals => animals)
                    .Select(group => group.OrderByDescending(animals => animals.Value.Health).First());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nMost healthy animals:");
            foreach (var animal in healthyAnimals)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n" + animal.Value.GetType() + ":");
                Console.ResetColor();
                Console.WriteLine("Name: \t\t HP: \t\t State:");
                Console.WriteLine("{0} \t\t {1} \t\t {2}", animal.Value.Nickname, animal.Value.Health, animal.Value.State);
            }
        }


        public void CountOfDeadAnimals()
        {
            var deadAnimalsCount =
                _animals.GroupBy(animals => animals.Value.GetType(), animals => animals)
                    .Select(
                        group =>
                            new
                            {
                                type = group.Key,
                                count = group.Count(animal => animal.Value.State == AnimalState.Dead)
                            });
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nCount of dead animals of each type:");
            foreach (var group in deadAnimalsCount)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n" + group.type + ":");
                Console.ResetColor();
                Console.WriteLine(group.count);
            }
        }

        public void WolfsAndBearsWithSomeHealth()
        {
            var animals =
                _animals.Where(
                    animal =>
                        animal.Value.GetType() == "Bear" || animal.Value.GetType() == "Wolf" && animal.Value.Health > 3);
            if (animals.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNo bears or wolfs");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nWolfs and bears with heal>3:");
                AnimalListToString(animals);
            }
        }

        public void MaxAndMinHealth()
        {
            var maxAndMinHealth =
                _animals.Where(
                    animal =>
                        animal.Value.Health == _animals.Max(animals => animals.Value.Health) ||
                        animal.Value.Health == _animals.Min(animals => animals.Value.Health))
                    .OrderByDescending(animal => animal.Value.Health);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nAnimals with Max and Min health:");
            AnimalListToString(maxAndMinHealth);
        }

        public void AverageHealth()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nAverage health is: " +_animals.Average(animals => animals.Value.Health));
        }





    }
}
