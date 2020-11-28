
public interface IDriver
{
    string Name { get; }
    double TotalTime { get; }
    ICar Car { get; }
    double FuelConsumptionPerKm { get; }
    double Speed { get; }

}

