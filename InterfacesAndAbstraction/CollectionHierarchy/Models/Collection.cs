using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
   public abstract class Collection
    {
        private const int SIZE = 100;

        protected List<string> collection;

        public Collection()
        {
            this.collection = new List<string>();
        }
    }
}
