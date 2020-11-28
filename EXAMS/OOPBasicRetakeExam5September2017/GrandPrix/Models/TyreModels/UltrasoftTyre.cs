using System;

public class UltrasoftTyre : Tyre
{
    private const string TyreName = "Ultrasoft";

    public UltrasoftTyre(double hardness, float grip)
        : base(hardness)
    {
        this.Grip = grip;
    }
    public double Grip { get; private set; }
    public override string Name => TyreName;

    public override double Degradation
    {
        get => base.Degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("The tyre blows up!");
            }
        }
    }
}

