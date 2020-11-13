
using System.Linq;

namespace TestDemos
{
   public class Calculator
    {
        public int CalculateSum(params int[] numbaers)
            => numbaers.Sum();

        public int Product(params int[] numbers)
        {
            int result = 1;
            foreach (int num in numbers)
            {
                result *= num;
            }

            return result;
        }
   
    }
}
