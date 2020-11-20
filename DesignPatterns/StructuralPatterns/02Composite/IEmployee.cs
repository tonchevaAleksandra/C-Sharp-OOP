namespace Composite
{
    public interface IEmployee
    {
        int EmployeeID { get; set; }
       
        string Name { get; set; }
        
        int Rating { get; set; }
        
        void PerformanceSummary();
    }
}