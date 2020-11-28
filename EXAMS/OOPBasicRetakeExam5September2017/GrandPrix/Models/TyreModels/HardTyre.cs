
public class HardTyre : Tyre
{
    private const string TyreName = "HardTyre";
    public HardTyre(double hardness)
        : base(hardness)
    {
    }

    public override string Name => TyreName;
}

