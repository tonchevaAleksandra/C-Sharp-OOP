using System;
using System.Linq;

namespace JediGalaxy
{
   public class Program
    {
        private static int[,] matrix;
        private static long sum;
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new string[] { " " },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int r = dimensions[0];
            int c = dimensions[1];

            InitializeField(r, c);

            sum = 0;
            string command = Console.ReadLine();
            while (command != "Let the Force be with you")
            {
                ProcessCoordinates(command);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static void ProcessCoordinates(string command)
        {
            int[] ivosCoordinates = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] evilCoordinates = Console.ReadLine()
                .Split(new string[] { " " }, 
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            MoveEvilPlayer(evilCoordinates);

            MoveIvo(ivosCoordinates);
        }

        private static void MoveIvo(int[] ivosCoordinates)
        {
            int ivoRow = ivosCoordinates[0];
            int ivoCol = ivosCoordinates[1];

            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (IsInsideTheField(ivoRow, ivoCol))
                {
                    sum += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }
        }

        private static void MoveEvilPlayer(int[] evilCoordinates)
        {
            int evilRow = evilCoordinates[0];
            int evilCol = evilCoordinates[1];

            while (evilRow >= 0 && evilCol >= 0)
            {
                if (IsInsideTheField(evilRow, evilCol))
                {
                    matrix[evilRow, evilCol] = 0;
                }
                evilRow--;
                evilCol--;
            }
        }

        private static bool IsInsideTheField(int row, int col)
        {
            if (row < matrix.GetLength(0) && row > 0 && col < matrix.GetLength(1) && col >= 0)
                return true;
            return false;
        }
        private static void InitializeField(int r, int c)
        {
            matrix = new int[r, c];

            int currentNum = 0;
            for (int row = 0; row < r; row++)
            {
                for (int col = 0; col < c; col++)
                {
                    matrix[row, col] = currentNum;
                    currentNum++;
                }
            }
        }
    }
}
