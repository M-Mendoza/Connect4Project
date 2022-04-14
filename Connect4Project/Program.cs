using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
