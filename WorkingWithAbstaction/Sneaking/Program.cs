using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;

namespace Sneaking
{
    public class Sneaking
    {
        public static char[][] matrix;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n][];

            FillTheMatrix(n);

            char[] moves = Console.ReadLine().ToCharArray();
            int[] nikolazPosition = new int[2];
            List<Enemy> enemies = new List<Enemy>();
            Sam sam = new Sam(0, 0);
            FindPositionsOfPlayers(enemies, sam,  nikolazPosition);

            for (int i = 0; i < moves.Length; i++)
            {

                MoveEnemies(enemies);
                if(IsSamDied(enemies, sam))
                {
                    matrix[sam.Row][sam.Col] = 'X';
                    break;
                }
                MoveSam(moves[i], sam);
                if (IsSamDied(enemies, sam))
                {
                    matrix[sam.Row][sam.Col] = 'X';
                    break;
                }
                if (enemies.Any(e => e.Row == sam.Row && e.Col == sam.Col))
                {
                    Enemy currentEnemy = enemies.FirstOrDefault(e => e.Row == sam.Row && e.Col == sam.Col);
                    matrix[currentEnemy.Row][currentEnemy.Col] = sam.Character;
                    enemies.Remove(currentEnemy);

                }
                else if (sam.Row == nikolazPosition[0])
                {
                    Console.WriteLine($"Nikoladze killed!");
                    matrix[sam.Row][sam.Col] = sam.Character;
                    matrix[nikolazPosition[0]][nikolazPosition[1]] = 'X';
                    break;
                }
                else
                    matrix[sam.Row][sam.Col] = sam.Character;
                continue;

            }
            PrintMatrixFinalState();
        }

        private static void PrintMatrixFinalState()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }
        }
        private static bool IsSamDied(List<Enemy> enemies, Sam sam)
        {
            if (enemies.Any(e => e.Row == sam.Row))
            {
                Enemy currentEnemy = enemies.FirstOrDefault(e => e.Row == sam.Row);
                if (currentEnemy.Character == 'b' && sam.Col > currentEnemy.Col ||
                    currentEnemy.Character == 'd' && sam.Col < currentEnemy.Col)
                {
                    Console.WriteLine($"Sam died at {sam.Row}, {sam.Col}");
                    matrix[sam.Row][sam.Col] = 'X';
                    return true;
                }
            }
            return false;
        }
        private static void MoveSam(char movement, Sam sam)
        {
            matrix[sam.Row][sam.Col] = '.';
            switch (movement)
            {
                case 'U':
                    sam.Row--;
                    break;
                case 'D':
                    sam.Row++;
                    break;
                case 'L':
                    sam.Col--;
                    break;
                case 'R':
                    sam.Col++;
                    break;
                default:
                    break;
            }

        }
        private static void MoveEnemies(List<Enemy> enemies)
        {
            foreach (Enemy enemy in enemies)
            {
                matrix[enemy.Row][enemy.Col] = '.';
                enemy.Move();
                if (!CheckValidityOfCell(enemy.Row, enemy.Col))
                {
                    enemy.ChangeCharacter();
                    if (enemy.Character == 'b')
                        enemy.Col = 0;
                    else
                        enemy.Col = matrix.Length - 1;

                }
                matrix[enemy.Row][enemy.Col] = enemy.Character;
            }
        }
        private static bool CheckValidityOfCell(int row, int col)
        {
            if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length) return true;
            return false;
        }
        private static void FindPositionsOfPlayers(List<Enemy> enemies, Sam sam, int[] nikolazPosition)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'S')
                    {
                        sam.Row = row;
                        sam.Col = col;
                    }
                    else if (matrix[row][col] == 'b')
                    {
                        enemies.Add(new Enemy(row, col, 'b', "right"));
                    }
                    else if (matrix[row][col] == 'd')
                    {
                        enemies.Add(new Enemy(row, col, 'd', "left"));
                    }
                    else if(matrix[row][col]=='N')
                    {
                        nikolazPosition[0] = row;
                        nikolazPosition[1] = col;
                    }
                }
            }
        }

        private static void FillTheMatrix(int n)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                matrix[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col];
                }
            }
        }
    }
}
