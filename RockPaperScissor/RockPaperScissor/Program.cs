﻿using System;

namespace RockPaperScissor
{

    class Program
    {
        /*
        <--global field-->
        -Round number 
        -roundArrayList
        */
        static void Main(string[] args)
        {
            /*
            < --main function-- >
            - prompt user for first player, second player
            - run loop using while until one of the player reaches the score of 2
            - call the rpsGenerator method for the two players
            - compare the two players last round by using if statement. if statement----will have player1's result(r/p/s) with nested if statement comparing it to -player2's result(r/ p / s).


            Example:
            if (player1.rpsGenerator() == "rock")
            {
                if (player2.rpsGenerator() == "paper")
                {
                    $"Round {roundNumber} - {player2.name} chose rock, {player1.name} chose rock. - Player2 won";
                    "It is a tie ";
                }


            -within the same if statement which ever player wins add 1(playerScore++) to the player score. 
            -within the same if statement which ever player wins/ lose / tie add the string into the the roundArrayList with the updated Round number.

            -once a player reaches 2 on their player score we get out of the loop.
            -loop through the roundArrayList, that stored all the round information, to display on the console.
            -if statement to see which player has the score of 2 and display the winner and final score on console.
            */
    }
}
    class Player
    {
        /*
        <--Player class-->
        -player have name, player have score
        -player gets rpsGenerator { creating random number bwteen 0-2
        and then changing the number to["rock", "paper", "scissor"]}
        */
}
}
