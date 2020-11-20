namespace Builder
{
    public class NotSoSuperCarBuilder : CarBuilder
    {
        public override void SetHorsePower()
        {
            car.HorsePower = 120;
        }

        public override void SetTopSpeed()
        {
            car.TopSpeedMPH = 70;
        }

        public override void SetImpressiveFeature()
        {
            car.MostImpressiveFeature = "Has Air Conditioning";
        }
    }
}