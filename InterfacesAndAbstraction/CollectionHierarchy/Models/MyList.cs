using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class MyList : Collection, IMyList
    {
        public int Used => this.collection.Count;

        public int Add(string element)
        {
            this.collection.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            string element = this.collection[0];
            this.collection.RemoveAt(0);
            return element;

        }

    }
}
