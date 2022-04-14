using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4Project
{
    internal class Program
    {
        static void DisplayBoard(char [,] board)
        {
            //defining board parameters
            int rows = 6;
            int cols = 7;
            //populating the game board
            for(int i = 1; i <= rows; i++)
            {
                Console.Write("|");
                for(int j = 1; j<=cols; j++)
                {
                    if(board[i,j] != 'X' && board[i,j] != 'O')
                    {
                        board[i, j] = '*';
                        Console.Write(board[i, j]);
                    }
                    
                }
                Console.Write("| \n");
            }
        }
        static void Main(string[] args)
        {
            char[,] board = new char[9, 9];
            DisplayBoard(board);


            Console.Read();
        }
    }
}
