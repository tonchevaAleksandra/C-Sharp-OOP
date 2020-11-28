
namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int BulletsAtATime = 1;
        public Pistol(string name, int bulletsCount) 
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount < BulletsAtATime)
                return 0;

            this.BulletsCount -= BulletsAtATime;
            return BulletsAtATime;
        }
    }
}
