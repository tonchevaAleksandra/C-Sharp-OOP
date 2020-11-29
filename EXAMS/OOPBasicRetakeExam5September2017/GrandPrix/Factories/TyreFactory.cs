
public class TyreFactory
{
    public Tyre CreateTyre(string type,double hardness,double grip)
    {

        Tyre tyre = null;
        if(type=="Ultrasoft")
        {
            tyre = new UltrasoftTyre(hardness, grip);
        }
        else if(type=="Hard")
        {
            tyre = new HardTyre(hardness);
        }

        return tyre;
    }
}

