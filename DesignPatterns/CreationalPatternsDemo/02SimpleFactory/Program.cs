namespace SimpleFactory
{
    public class Program
    {
        public static void Main()
        {
            FanFactory fanFactory = new FanFactory();
            IFan ceilingFan = fanFactory.CreateFan(FanType.CeilingFan);
            IFan tableFan = fanFactory.CreateFan(FanType.TableFan);

            ceilingFan.SwitchOn();
            tableFan.SwitchOff();

            System.Console.WriteLine(ceilingFan.GetState());
            System.Console.WriteLine(tableFan.GetState());

        }
    }
}