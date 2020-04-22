using System;
using System.Collections;
namespace RPS_Game
{
    public class Player
    { // creating a player class to store player information.
        public string name; //string to store player name.
        public int score = 0; // int to store player wint count.
        public Player(string name)
        { // constructor to assign player name to the string.
            this.name = name;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int RoundNumber = 1; // int to store and update round number.
            int ties = 0; // int to store and update the number of ties between players.
            ArrayList roundResuelt = new ArrayList(); // arraylist to store all the round result of players.
            string player1CurntRound, player2CurntRound; // string to store what player got from RPSGenerator(r/p/s).
            Console.WriteLine("Enter Player one name"); // prompting user to enter the player name on console.
            Player player1 = new Player(Console.ReadLine()); // storing the entered player name into player obj.
            Console.WriteLine("Enter Player two name");
            Player player2 = new Player(Console.ReadLine());
            while (player1.score != 2 && player2.score != 2)
            { // using while loop to run the rounds until one player reaches a score of 2.
                player1CurntRound = RPSGenerator(); // generate r/p/s to store into playerCurntround.
                player2CurntRound = RPSGenerator();
                if (player1CurntRound == "rock")
                { // conditionals to check who won each round. If player one has a "rock"
                    if (player2CurntRound == "paper")
                    { // nested if statements to compare different result player2 will have with player1 having "rock"
                        roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose rock, {player2.name} chose paper. - Player2 won"); // adds winner of the round to the array.
                        player2.score++; // adds a win count to player 2
                    }
                    else if (player2CurntRound == "scissor")
                    {
                        roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose rock, {player2.name} chose scissor. - Player1 won");
                        player1.score++;
                    }
                    else
                    {
                        roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose rock, {player2.name} chose rock. - it is a ties");
                        ties++; // adds a tie count 
                    }
                }
                else if (player1CurntRound == "paper")
                {
                    if (player2CurntRound == "rock")
                    {
                        roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose paper, {player2.name} chose rock. - Player1 won");
                        player1.score++;
                    }
                    else if (player2CurntRound == "scissor")
                    {
                        roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose paper, {player2.name} chose scissor. - Player2 won");
                        player2.score++;
                    }
                    else
                    {
                        roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose paper, {player2.name} chose paper. - it is a ties");
                        ties++;
                    }
                }
                else
                {
                    if (player2CurntRound == "rock")
                    {
                        roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose scissor, {player2.name} chose paper. - Player1 won");
                        player1.score++;
                    }
                    else if (player2CurntRound == "scissor")
                    {
                        roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose scissor, {player2.name} chose rock. - Player2 won");
                        player2.score++;
                    }
                    else
                    {
                        roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose scissor, {player2.name} chose scissor. - it is a ties");
                        ties++;
                    }
                }
                RoundNumber++; // updates the round number each loop.
            }
            for (int i = 0; i < roundResuelt.Count; i++)
            { // after we get out of the loop, this for loop is ran to display result of all the rounds on console.
                Console.WriteLine(roundResuelt[i]);
            }
            if (player1.score == 2)
            { // display whichever player that has 2 wins and display the winner on console.
                Console.WriteLine($"{player1.name} wins 2-{player2.score} with {ties} ties.");
            }
            else
            {
                Console.WriteLine($"{player2.name} wins 2-{player1.score} with {ties} ties.");
            }
        }
        static string RPSGenerator()
        { // method to generate rock, paper, or scissor for each player.
            Random rnd = new Random(); // object class created to generate random number.
            int rundomNum = rnd.Next(3); // generate random number from 0 - 2.
            switch (rundomNum)
            { // returning rock, paper, or scissor based off of what random number you generate.
                case 0:
                    return "rock";

                case 1:
                    return "paper";

                case 2:
                    return "scissor";
                default:
                    return "Default case";
            }
        }
    }
}



/*
using System;

namespace RockPaperScissor
{

    class Program
    {
        
        <--global field-->
        -Round number 
        -roundArrayList
        
        static void Main(string[] args)
        {
            
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
            
    }
        
        <--Player class-->
        -player have name, player have score
        -player gets rpsGenerator { creating random number bwteen 0-2
        and then changing the number to["rock", "paper", "scissor"]}
        

*/
