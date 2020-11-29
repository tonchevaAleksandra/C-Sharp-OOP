using System;

public class Car : ICar
{
    private const double MaximumCapacity = 160;
    private double fuelAmount;
    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }
    public int Hp { get; private set; }

    public double FuelAmount
    {
        get => this.fuelAmount;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
            if (value > MaximumCapacity)
            {
                this.fuelAmount = MaximumCapacity;
               
            }

            else
            {
                this.fuelAmount = value;
            }
            
        }
    }

    public Tyre Tyre { get; private set; }

    public void FuelReducer(int trackLength,double fuelConsumptionPerKm)
    { 
        this.FuelAmount -= (trackLength * fuelConsumptionPerKm);
    }

    public void Refuel(double fuel)
    {
        this.FuelAmount += fuel;
    }

    public void ChageTyre(Tyre tyre)
    {
        this.Tyre = tyre;
    }
}

