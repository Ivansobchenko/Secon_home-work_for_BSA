using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using ZooEmulator.Animals;
using Timer = System.Timers.Timer;

namespace ZooEmulator.ZooStructure
{
    class ZooLifeCycle
    {
        private Dictionary<string, AnimalBase> _animals;
        private Timer timer;
        private static Random rnd;

        public ZooLifeCycle(Dictionary<string, AnimalBase> animals)
        {
            _animals = animals;
            
            rnd = new Random();

            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(ChangeState);
            timer.Interval = 5000;
            timer.Start();

        }

        private void ChangeState(object sender, ElapsedEventArgs e)
        {
            
            if (_animals.Count != 0)
            {
                bool success = false;
                while (!success)
                {
                    int animalIndex = rnd.Next(0, _animals.Count);
                    if (_animals.ElementAt(animalIndex).Value.State != AnimalState.Dead)
                    {
                        _animals.ElementAt(animalIndex).Value.ChangeState();
                        success = true;
                    }
                }
            }
            if (IsAllAnimalsDied())
            {
                timer.Stop();
                System.Windows.Forms.MessageBox.Show("All animals in zoo have had died!");
            }


        }

        public bool IsAllAnimalsDied()
        {
            if (_animals.Count > 0)
            {
                bool result = true;
                foreach (var animal in _animals.Values)
                    if (animal.State != AnimalState.Dead)
                        result = false;
                return result;
            }
            else return false;

        }



    }
}
