
public abstract class Driver : IDriver
{

    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.TotalTime = 0;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.IsRacing = true;

    }
    public string Name { get; private set; }

    public double TotalTime { get;  set; }

    public Car Car { get; private set; }

    public double FuelConsumptionPerKm { get; private set; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public string FailureReason { get; set; }

    public bool IsRacing { get; set; }

    public string Status => this.IsRacing ? this.TotalTime.ToString("f3") : this.FailureReason;

    public void TotalTimeIncreaser(int trackLength)
    {
        //“60 / (trackLength / driver’s Speed)”
        this.TotalTime += 60 / (trackLength / this.Speed);
    }

    public void AddBoxTimeToTotal()
    {
        this.TotalTime += 20;
    }
}

