using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//pseudo code.

//2 players. when one turn is made turn increases
//turn = 1;
//or can have option for player 2 to go first. same logic
//if(last_player_chose)
//turn ++;
//if(turn == 3)
//turn == 1)
//************

//Game board
//7 across 6 down
//could be represented by a single array with line breaks, or multiple arrays
//user selects number between 1 and 7 to indicate which row they wish to put piece in.
//will go higher up if that slot is already occupied.
//if(array_spot == X || 0){
//Move to another array that is above, or subtract from the current spot to have it land above.
//if(is_top_array){
//console.log("cannot put piece in full slot. please try again.
//when user makes selection, foreach loop will be ran to show the updated array.
//set within a do while loop. While(victory == false);
//need to check win condition with each loop. If 4 in a row are found. Victory
//have to set win condition array parameters.

//*******
//possible ai
//easy ai:places pieces randomly with random range between 1 to 7.
//hard ai:before moving, a random range function is called. If it's say between 1 and 7, it makes a smart move.
//if its between 7 to 10, it makes a random move. Making it smarter but not always perfect.

//*********

//Classes
//Public Gameboard
//Public Player1, can have the turn counter in the class
//Public Player2, same as 1
//Public ai. If we get there.
//Public scoreboard? to count victories of each player or ai

//*******
//functions

//CanMove()
//if it's the players turn canPlace = true;
//if player can place, creates that players icon on the slot, then moves up a turn

//checkVictory()
//used to check if a player won

//reset()
//reset gameboard between plays

//createPvp()
//creates 2 player game

//createPvc()
//creates player vs computer game

//Gameboard gameboard = new Gameboard;

namespace Connect4Project
{

    public class TurnCounter
    {

        public int Turn = 0;
        public char CurrentPlayer;

        public TurnCounter(int turn, char currentPlayer)
        {
            Turn = turn;
            CurrentPlayer = currentPlayer;
        }


        public void IncreaseTurn()
        {
            ++Turn;
            if (Turn == 3)
            {
                Turn = 1;
            }
            if (Turn == 1)
            {
                CurrentPlayer = 'R';

            }
            if (Turn == 2)
            {
                CurrentPlayer = 'Y';
            }

        }
    }

   /* public class PiecePlacement : TurnCounter
    {
        public PiecePlacement(int turn, char currentPlayer) : base(turn, currentPlayer)
        {
           
        }

        public void PlacePiece()
        {
            IncreaseTurn();

        }
    }*/

   /* public class CheckVictory : TurnCounter
    {
        public CheckVictory(int turn, char currentPlayer) : base(turn, currentPlayer)
        {
            
            IncreaseTurn();
        }
    }*/


    public static class DisplayGameBoard
    {

        public static void DisplayBoard(char[,] board)
        {
            //defining board parameters
            int rows = 6;
            int cols = 7;

            //populating the game board
            for (int i = 1; i <= rows; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("| " + " ");
                for (int j = 1; j <= cols; j++)
                {
                    if (board[i, j] != 'R' && board[i, j] != 'Y')
                    {
                        board[i, j] = 'O';

                    }
                    /*    else
                            {
                                board[i, j] = 'U';
                            }*/
                    Console.Write(board[i, j]);
                    Console.Write("  ");


                }
                Console.Write("|\n");

            }
        }


        class Program
        {

            static void Main(string[] args)
            {
                ResetGame();
                void ResetGame() //Initializes current game, and also resets game after if player chooses to. Whole program is wrapped around this to restart.
                {

                    char[,] board = new char[9, 9];
                    DisplayGameBoard.DisplayBoard(board);
                    bool victory = false;
                    TurnCounter turncounter = new TurnCounter(1, 'R');
                    int command;
                    char[,] gameBoard = board;

                    bool hasWonHorizontally(char piecePlacement)
                    {

                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                if (
                                    board[i, j] == piecePlacement &&
                                    board[i, j + 1] == piecePlacement &&
                                    board[i, j + 2] == piecePlacement &&
                                    board[i, j + 3] == piecePlacement)
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Win horizontally at Row {0}, column {1} for player " + turncounter.CurrentPlayer, i, j);

                                    victory = true;
                                }
                            }
                        }
                        return victory;
                    }

                    bool hasWonVertically(char piecePlacement)
                    {

                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                if (
                                    board[i, j] == piecePlacement &&
                                    board[i + 1, j] == piecePlacement &&
                                    board[i + 2, j] == piecePlacement &&
                                    board[i + 3, j] == piecePlacement)
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Win vertically at Row {0}, column {1}!", i, j);

                                    victory = true;
                                }
                            }
                        }
                        return victory;
                    }

                    bool hasWonDiagonallyDown(char piecePlacement)
                    {

                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                if (
                                    board[i, j] == piecePlacement &&
                                    board[i + 1, j + 1] == piecePlacement &&
                                    board[i + 2, j + 2] == piecePlacement &&
                                    board[i + 3, j + 3] == piecePlacement)
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Win diagonally at Row {0}, column {1}!", i, j);

                                    victory = true;
                                }
                            }
                        }
                        return victory;
                    }


                    bool hasWonDiagonallyUp(char piecePlacement)
                    {

                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                if (
                                    board[i, j] == piecePlacement &&
                                    board[i + 1, j - 1] == piecePlacement &&
                                    board[i + 2, j - 2] == piecePlacement &&
                                    board[i + 3, j - 3] == piecePlacement)
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Win diagonally at Row {0}, column {1}!", i, j);

                                    victory = true;
                                }
                            }
                        }
                        return victory;
                    }

                   /* while (victory == false)
                    {*/

                        


                        Console.WriteLine("Current player is " + turncounter.CurrentPlayer);

                    /*    foreach (var slot in gameBoard)
                        {
                            Console.Write("{0} ", slot);
                        }*/
                    while (victory == false)
                    {
                        Console.WriteLine("press slot to fill between 1 and 7");
                        try
                        {
                            command = Int32.Parse(Console.ReadLine());
                            /*   if (command > 7 && command < 1)
                               {
                                   Console.WriteLine("Please enter a column between 1 and 7.");
                               }
                               else
                               {*/
                            int rows = 6;
                            char piecePlacement;

                            piecePlacement = gameBoard[rows, command];//places in according column with command.

                            if (turncounter.CurrentPlayer == 'Y')
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            if (turncounter.CurrentPlayer == 'R')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }


                            Console.WriteLine(turncounter.CurrentPlayer + " chooses column " + command);

                            /*         Console.WriteLine("Current player is " + turncounter.CurrentPlayer--);*/



                            /* Console.WriteLine( "position is " + board[rows, command]);*/

                            while ((piecePlacement != 'O') && rows > 0 && command > 0 && command < 8)
                            {



                                /*gameBoard[rows, command] = turncounter.CurrentPlayer;*/
                                rows--; //if the row is occupied, we move up a space.
                                if (rows >= 0) piecePlacement = gameBoard[rows, command];
                                if (rows <= 0)
                                {

                                    Console.WriteLine("Column full. Please choose again");
                                    Console.WriteLine("Current player is " + turncounter.CurrentPlayer);
                                    turncounter.Turn--; //lowers the turn so if column is full and they choose this, they don't lose a turn.
                                }
                            }

                            gameBoard[rows, command] = turncounter.CurrentPlayer;

                            hasWonHorizontally(turncounter.CurrentPlayer);
                            hasWonVertically(turncounter.CurrentPlayer);
                            hasWonDiagonallyDown(turncounter.CurrentPlayer);
                            hasWonDiagonallyUp(turncounter.CurrentPlayer);

                            DisplayGameBoard.DisplayBoard(gameBoard);

                            turncounter.IncreaseTurn();


                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Please enter a correct value"); //catch if incorrect numbers or letters are entered. Don't increase turn.
                        }
                    }

                    while (victory == true)
                    {
                        Console.WriteLine("Play again? Y/N");
                        string answer = Console.ReadLine();
                        if (answer == "Y" || answer == "y") {
                            victory = false;
                            ResetGame();
                        }
                            
                        if (answer == "N" || answer == "n")
                        {
                            Environment.Exit(0);
                        }
                    }
                    Console.Read();
                }
            }
        }
    }
}



/*       if(gameBoard[rows, command] == 'Y')
       {
           rows -= 1;
       }
       if(gameBoard[rows,command] == 'R')
       {
           rows -= 1;
       }*/


/*      Console.Write("Choice 0" + "\n");

      if (command == "0")
      {

          int rows = 6;
          int cols = 7;

          gameBoard[6, 1] = turncounter.CurrentPlayer;

          if (gameBoard[6, 1] != " O ")
          {
              gameBoard[5, 1] = turncounter.CurrentPlayer;
          }
*/




/*int i = 1; 
int j = 1;*/

/* switch (choice)
 {
     case "0":

         Console.Write("Choice 0" + "\n");

         if (command == "0")
         {

             int rows = 6;
             int cols = 7;

             gameBoard[6,1] = turncounter.CurrentPlayer;

             if (gameBoard[6, 1] != " O ")
             {
                 gameBoard[5, 1] = turncounter.CurrentPlayer;
             }


             for (i = 1; i <= rows; i++)
             {   
                 Console.Write("|");
                 for (j = 1; j <= cols; j++)
                 {
                     if (board[i, j] != " R " && board[i, j] != " Y ")
                     {
                         board[i, j] = " O ";
                     }

                     Console.Write(board[i, j]);
                     *//*      }*//*

                 }
                 Console.Write("| \n");


             }

             turncounter.IncreaseTurn();

             Console.WriteLine("players turn is " + turncounter.CurrentPlayer);

         }

         break;




     case "1":

         Console.Write("Choice 1" + "\n");

         if (command == "1")
         {

             gameBoard[0,1] = turncounter.CurrentPlayer;
             foreach (var slot in gameBoard)
             {
                 Console.Write(" {0} ", slot);
             }
             turncounter.IncreaseTurn();
             Console.WriteLine("players turn is " + turncounter.CurrentPlayer);

         }
         else
         {
             Console.WriteLine("input not detected properly");
         }
         break;



     case "2":

         Console.Write("Choice 2" + "\n");

         if (command == "2")
         {

             gameBoard[0,2] = turncounter.CurrentPlayer;
             foreach (var slot in gameBoard)
             {
                 Console.Write("{0} ", slot);
             }
             turncounter.IncreaseTurn();
             Console.WriteLine("players turn is " + turncounter.CurrentPlayer);

         }
         else
         {
             Console.WriteLine("input not detected properly");
         }
         break;

     case "3":

         Console.Write("Choice 3" + "\n");

         if (command == "3")
         {

             gameBoard[0,3] = turncounter.CurrentPlayer;
             foreach (var slot in gameBoard)
             {
                 Console.Write("{0} ", slot);
             }
             turncounter.IncreaseTurn();
             Console.WriteLine("players turn is " + turncounter.CurrentPlayer);

         }
         else
         {
             Console.WriteLine("input not detected properly");
         }
         break;
 }*/



/*      }*/



/*    static void Main(string[] args)
    {
        char[,] board = new char[9, 9];
        DisplayBoard(board);


        Console.Read();
    }
}*/


/*           while(victory == 0)
           {

               Console.WriteLine("Press 4 to increase turn");*/

/*  Console.WriteLine("press 4 to increase turn");
  Console.ReadLine();

  if(turncounter.Turn == 0)
  turncounter.IncreaseTurn();
  Console.WriteLine(turncounter.Turn);
  Console.WriteLine("current player is " + turncounter.CurrentPlayer);
  turncounter.IncreaseTurn();*/
/*Console.WriteLine("current player is " + turncounter.CurrentPlayer);*/















