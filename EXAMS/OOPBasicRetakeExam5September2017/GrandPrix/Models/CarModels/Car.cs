﻿using System;

public class Car : ICar
{
    private const int MaximumCapacity = 160;
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
            if (value > MaximumCapacity)
            {
                this.fuelAmount = MaximumCapacity;
                return;
            }
            if (value < 0)
            {
                throw new ArgumentException("FuelAmount cannot be negative!");
            }

            this.fuelAmount = value;
        }
    }

    public Tyre Tyre { get; private set; }
}

