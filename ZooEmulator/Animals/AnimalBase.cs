namespace ZooEmulator.Animals
{
    public enum AnimalState
    {
        Sated = 3,
        Hungry = 2,
        Sick = 1,
        Dead = 0
    }


    public abstract class AnimalBase
    {
        private int MaxHealth;
        public int Health { get; set; }
        public AnimalState State { get; set; }
        public string Nickname { get; set; }

        public bool IsHealthIsMax
        {
            get { return Health == MaxHealth ? true : false; }
        }


        public AnimalBase(string name, int maxHealth)
        {
            MaxHealth = maxHealth;
            Health = MaxHealth;
            State = AnimalState.Sated;
            Nickname = name;
        }

        public void Feed()
        {
                State = State==AnimalState.Hungry ? AnimalState.Sated:State;
        }

        public void Treet()
        {
            if (Health > 0 && Health < MaxHealth)
                Health++;
            State = State == AnimalState.Sick ? AnimalState.Hungry : State;
        }

        public void ChangeState()
        {
            if (State == AnimalState.Sick)
                Health--;
            else if ((int) State > 1)
                State--;

            if(Health == 0)
                State= AnimalState.Dead;

        }

        public new abstract string GetType();




    }
}
