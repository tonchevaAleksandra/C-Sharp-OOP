namespace Iterator
{
    public class LAPaperIterator : IIterator
    {
        private string[] reporters;
        private int current;

        public LAPaperIterator(string[] reporters)
        {
            this.reporters = reporters;

            this.current = 0;
        }

        public string CurrentItem()
        {
            return this.reporters[current];
        }

        public void First()
        {
            this.current = 0;
        }

        public bool IsDone()
        {
            return this.current >= this.reporters.Length;
        }

        public string Next()
        {
            return this.reporters[this.current++];
        }
    }
}
