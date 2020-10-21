
namespace RawData
{
   public class Engine
    {
        public int Speed { get;  }
        public int Power { get; }

        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }
    }
}
