using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection :Collection, IAddRemovableCollection
    {

        public AddRemoveCollection()
        {
        }
        public int Add(string element)
        {
           if(this.collection.Count<100)
            {
                this.collection.Insert(0, element);
            }
            return 0;
        }

        public string Remove()
        {
            string element = this.collection[this.collection.Count - 1];
                this.collection.RemoveAt(this.collection.Count - 1);
            return element;
        }

    }
}
