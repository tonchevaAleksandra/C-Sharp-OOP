
using System;

public abstract class Tyre : ITyre
{
    private const double InitialDegradation = 100;
    private double degradation;

    protected Tyre( string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = InitialDegradation;
    }
    public  string Name { get; private set; }

    public double Hardness { get; private set; }


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

    public virtual void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}

