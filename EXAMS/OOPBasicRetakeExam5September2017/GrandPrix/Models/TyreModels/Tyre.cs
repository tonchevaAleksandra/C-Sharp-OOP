
using System;

public abstract class Tyre : ITyre
{
    private const double InitialDegradation = 100;
    private double degradation;

    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = InitialDegradation;
    }
    public abstract string Name { get; }

    public double Hardness { get; }


    public virtual double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("The tyre blows up!");
            }

            this.degradation = value;
        }
    }
}

