﻿
public abstract class Driver : IDriver
{

    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.TotalTime = 0;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;

    }
    public string Name { get; private set; }

    public double TotalTime { get; private set; }

    public Car Car { get; private set; }

    public double FuelConsumptionPerKm { get; private set; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
}

