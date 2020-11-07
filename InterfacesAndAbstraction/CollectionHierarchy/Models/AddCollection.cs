using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class AddCollection :Collection, IAddCollection
    {
        public AddCollection()
        {
        }
        public int Add(string element)
        {
            if (this.collection.Count < 100)
                this.collection.Add(element);
            return this.collection.Count - 1;
        }
    }
}
