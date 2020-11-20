namespace Builder
{
    public class SuperCarBuilder : CarBuilder
    {
        public override void SetHorsePower()
        {
            car.HorsePower = 1640;
        }

        public override void SetTopSpeed()
        {
            car.TopSpeedMPH = 600;
        }

        public override void SetImpressiveFeature()
        {
            car.MostImpressiveFeature = "Can Fly";
        }
    }
}