using System;

namespace Command
{
    public class Calculator
    {
        private int current;

        public void Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+': current += operand; break;
                case '-': current -= operand; break;
                case '*': current *= operand; break;
                case '/': current /= operand; break;
            }

            Console.WriteLine(
                "Current value = {0,3} (following {1} {2})",
                current, @operator, operand);
        }
    }
}