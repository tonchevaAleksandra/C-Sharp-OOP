namespace SimpleFactory
{
    public class CeilingFan : IFan
    {
        private string fanDefaultState = "Ceiling On";

        public void SwitchOn()
        {
            this.fanDefaultState = "Ceiling On";
        }

        public void SwitchOff()
        {
            this.fanDefaultState = "Ceiling Off";
        }

        public string GetState()
        {
            return "Ceiling fan state " + fanDefaultState;
        }
    }
}