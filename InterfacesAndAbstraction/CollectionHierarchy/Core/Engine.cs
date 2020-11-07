using System.Collections.Generic;
using System.Linq;
using CollectionHierarchy.IO.Contracts;
using CollectionHierarchy.Models;

namespace CollectionHierarchy.Core
{
   public class Engine
    {
        private IReadable reader;
        private IWritable writer;

        private AddCollection addCollection;
        private AddRemoveCollection addRemoveCollection;
        private MyList myList;
        public Engine()
        {
            this.addCollection = new AddCollection();
            this.addRemoveCollection = new AddRemoveCollection();
            this.myList = new MyList();
        }
        public Engine(IReadable reader, IWritable writer)
            :this()
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string[] elementsToAdd = this.reader.ReadLine()
                .Split()
                .ToArray();

            List<int> elmtsToAddCollection = new List<int>();
            List<int> elmtsToAddRemoveCollection = new List<int>();
            List<int> elmtsToMyList = new List<int>();

            AddElementsToCollections(elementsToAdd, elmtsToAddCollection, elmtsToAddRemoveCollection, elmtsToMyList);

            int elementsToRemove = int.Parse(this.reader.ReadLine());

            List<string> removedElmntsFromAddRemoveCollection = new List<string>();
            List<string> removedElmntsFromMyList = new List<string>();

            RemoveElementsFromCollections(elementsToRemove, removedElmntsFromAddRemoveCollection, removedElmntsFromMyList);

            WriteResults(elmtsToAddCollection, elmtsToAddRemoveCollection, elmtsToMyList, removedElmntsFromAddRemoveCollection, removedElmntsFromMyList);
        }

        private void WriteResults(List<int> elmtsToAddCollection, List<int> elmtsToAddRemoveCollection, List<int> elmtsToMyList, List<string> removedElmntsFromAddRemoveCollection, List<string> removedElmntsFromMyList)
        {
            WriteAddedElements(elmtsToAddCollection);
            WriteAddedElements(elmtsToAddRemoveCollection);
            WriteAddedElements(elmtsToMyList);
            WriteRemovedElements(removedElmntsFromAddRemoveCollection);
            WriteRemovedElements(removedElmntsFromMyList);
        }

        private void WriteRemovedElements(List<string> elements)
        {
            this.writer.WriteLine(string.Join(" ", elements));
        }

        private void RemoveElementsFromCollections(int elementsToRemove, List<string> removedElmntsFromAddRemoveCollection, List<string> removedElmntsFromMyList)
        {
            for (int i = 0; i < elementsToRemove; i++)
            {
                removedElmntsFromAddRemoveCollection.Add(this.addRemoveCollection.Remove());
                removedElmntsFromMyList.Add(this.myList.Remove());
            }
        }

        private void WriteAddedElements(List<int> addedElements)
        {
            this.writer.WriteLine(string.Join(" ", addedElements));
        }

        private void AddElementsToCollections(string[] elementsToAdd, List<int> elmtsToAddCollection, List<int> elmtsToAddRemoveCollection, List<int> elmtsToMyList)
        {
            foreach (var item in elementsToAdd)
            {
                elmtsToAddCollection.Add(this.addCollection.Add(item));
                elmtsToAddRemoveCollection.Add(this.addRemoveCollection.Add(item));
                elmtsToMyList.Add(this.myList.Add(item));

            }
        }
    }
}
