
namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int BulletsAtATime = 10;
        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount < BulletsAtATime)
            {
                return 0;
            }

            this.BulletsCount -= BulletsAtATime;


            return BulletsAtATime;
        }
    }
}
