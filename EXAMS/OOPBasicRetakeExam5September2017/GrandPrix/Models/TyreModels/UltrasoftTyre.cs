using System;

public class UltrasoftTyre : Tyre
{
    private const string TyreName = "Ultrasoft";
    private double degradation;
    public UltrasoftTyre(double hardness, double grip)
        : base(TyreName, hardness)
    {
        this.Grip = grip;
    }
    public double Grip { get; private set; }

    public override double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("The tyre blows up!");
            }
            this.degradation = value;
        }
    }
    public override void ReduceDegradation()
    {
        this.Degradation-=(this.Hardness+this.Grip);
    }
}

