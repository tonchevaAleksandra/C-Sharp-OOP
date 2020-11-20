using System.Collections.Generic;
using Iterator.Iterator;

namespace Iterator
{
    public class NYPaper : INewspaper
    {
        private readonly List<string> reporters;

        public NYPaper()
        {
            this.reporters = new List<string>
            {
                "John Mesh - NY", 
                "Susanna Lee - NY", 
                "Paul Randy - NY", 
                "Kim Fields - NY", 
                "Sky Taylor - NY"
            };
        }

        public IIterator CreateIterator()
        {
            return new NYPaperIterator(reporters);
        }
    }
}
