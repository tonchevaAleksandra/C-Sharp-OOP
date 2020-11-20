namespace Strategy
{
    public class Client
    {
        public static void Main()
        {
            SortedList studentRecord = new SortedList();

            studentRecord.Add("Ronny");
            studentRecord.Add("Bobby");
            studentRecord.Add("Kate");
            studentRecord.Add("Mike");
            studentRecord.Add("Ricky");

            studentRecord.SetSortStrategy(new QuickSort());
            studentRecord.Sort();

            studentRecord.SetSortStrategy(new ShellSort());
            studentRecord.Sort();

            studentRecord.SetSortStrategy(new MergeSort());
            studentRecord.Sort();
        }
    }
}