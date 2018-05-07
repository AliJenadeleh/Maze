using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Program
    {
        char[,] maze = {
                            {'.','.','.','.','#','#','#','#','#','#'},
                            {'.','#','#','.','#','#','.','.','.','#'},
                            {'.','#','#','.','#','#','.','#','.','#'},
                            {'.','#','#','.','.','.','.','#','.','.'},
                            {'.','#','.','#','.','#','.','#','#','.'},
                            {'#','#','.','#','.','#','.','#','#','.'},
                            {'#','#','.','#','.','#','.','#','#','.'},
                            {'#','#','.','#','.','#','.','.','#','.'},
                            {'#','#','.','.','.','#','.','#','*','.'},
                            {'#','.','.','.','#','#','#','#','#','#'}
                        };

        private void PrintMaze()
        {
            Console.Clear();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (maze[i, j] == '@')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (maze[i, j] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (maze[i, j] == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.Red; ;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write("{0:2}", maze[i, j]);
                }
                Console.WriteLine();
            }
        }

        private bool checkstep(int x, int y)
        {
            bool result = true;
            if (x < 0 || x > 9)
            {
                result = false;
            }
            else if (y < 0 || y > 9)
            {
                result = false;
            }
            else if (maze[x, y] == '#')
            {
                result = false;
            }
            else if (maze[x, y] == '@')
            {
                result = false;
            }
            return result;
        }

        private bool ISEndPoint(int x, int y)
        {
            if (maze[x, y] == '*')
            {
                return true;
            }
            return false;
        }

        private bool goswhay(int x, int y)
        {
            if (ISEndPoint(x, y))
            {
                PrintMaze();

                return true;
            }
            else
            {
                maze[x, y] = '@';
                PrintMaze();
                System.Threading.Thread.Sleep(400);
                if (checkstep(x, y - 1))
                {
                    if (goswhay(x, y - 1))
                    {
                        return true;
                    }
                }
                if (checkstep(x + 1, y))
                {
                    if (goswhay(x + 1, y))
                    {
                        return true;
                    }
                }
                if (checkstep(x, y + 1))
                {
                    if (goswhay(x, y + 1))
                    {
                        return true;
                    }
                }
                if (checkstep(x - 1, y))
                {
                    if (goswhay(x - 1, y))
                    {
                        return true;
                    }
                }
                maze[x, y] = '.';
                PrintMaze();
                System.Threading.Thread.Sleep(200);
            }
            return false;
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.PrintMaze();
            if (p.goswhay(0, 0))
            {
                Console.WriteLine("AI Find Whay . ");
            }
            else
            {
                Console.WriteLine("AI Cant Find Whay . ");
            }
            Console.ReadKey();

        }
    }
}
