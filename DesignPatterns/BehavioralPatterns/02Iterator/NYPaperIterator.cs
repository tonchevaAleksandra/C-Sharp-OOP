using System.Collections.Generic;

namespace Iterator.Iterator
{
    public class NYPaperIterator : IIterator
    {
        private readonly List<string> reporters;
        private int current;

        public NYPaperIterator(List<string> reporters)
        {
            this.reporters = reporters;
          
            this.current = 0;
        }

        public string CurrentItem()
        {
            return this.reporters[this.current];
        }

        public void First()
        {
            this.current = 0;
        }

        public bool IsDone()
        {
            return this.current >= this.reporters.Count;
        }

        public string Next()
        {
            return this.reporters[this.current++];
        }
    }
}
