namespace SimpleFactory
{
    public class TableFan : IFan
    {
        private string fanDefaultState = "Table On";

        public void SwitchOn()
        {
            this.fanDefaultState = "Table On";
        }

        public void SwitchOff()
        {
            this.fanDefaultState = "Table Off";
        }

        public string GetState()
        {
            return "Table fan state " +  fanDefaultState;
        }
    }
}