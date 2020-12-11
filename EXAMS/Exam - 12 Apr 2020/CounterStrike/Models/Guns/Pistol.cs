using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int BulletsShot = 1;
        public Pistol(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount < BulletsShot)
                return 0;
            else
            {
                this.BulletsCount -= BulletsShot;
            }

            return BulletsShot;

        }
    }
}
