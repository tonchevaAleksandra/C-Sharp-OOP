using System;
using System.Collections.Generic;

namespace Strategy
{
    public class SortedList
    {
        private List<string> list;
        private SortStrategy sortStrategy;

        public void SetSortStrategy(SortStrategy sortsSrategy)
        {
            this.sortStrategy = sortsSrategy;

            this.list = new List<string>();
        }

        public void Add(string name)
        {
            this.list.Add(name);
        }

        public void Sort()
        {
            sortStrategy.Sort(this.list);

            foreach (string name in this.list)
            {
                Console.WriteLine(" " + name);
            }

            Console.WriteLine();
        }
    }
}