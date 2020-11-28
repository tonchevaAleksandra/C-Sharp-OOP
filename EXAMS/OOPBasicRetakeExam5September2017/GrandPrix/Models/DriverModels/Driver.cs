
public abstract class Driver : IDriver
{

    protected Driver(string name, ICar car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;

    }
    public string Name { get;  }

    public double TotalTime { get; protected set; }

    public ICar Car { get; }

    public  double FuelConsumptionPerKm { get; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
}

