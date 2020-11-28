
public class EnduranceDriver : Driver
{
    private const double FuelConsumption = 1.5;
    public EnduranceDriver(string name,  ICar car)
        : base(name, car, FuelConsumption)
    {
    }

}

