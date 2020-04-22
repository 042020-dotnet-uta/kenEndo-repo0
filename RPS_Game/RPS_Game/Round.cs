using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace RPS_Game
{
    class Round
    {
        int RoundNumber = 1; // int to store and update round number.
        public int ties = 0; // int to store and update the number of ties between players.
        public ArrayList roundResuelt = new ArrayList(); // arraylist to store all the round result of players.
        public Player player1;
        public Player player2;


        public void roundCalc()
        {

            while (player1.score != 2 && player2.score != 2)// using while loop to run the rounds until one player reaches a score of 2.
            {
                player1.playerRPS = RPSGenerator(); // generate r/p/s to store into playerRPS.
                player2.playerRPS = RPSGenerator();
                if (player1.playerRPS == "rock")// conditionals to check who won each round. If player one has a "rock"
                {
                    if (player2.playerRPS == "paper")// nested if statements to compare different result player2 will have with player1 having "rock"
                    {
                        roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose rock, {player2.name} chose paper. - Player2 won"); // adds winner of the round to the array.
                        player2.score++; // adds a win count to player 2
                    }
                    else if (player2.playerRPS == "scissor")
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
                else if (player1.playerRPS == "paper")
                {
                    if (player2.playerRPS == "rock")
                    {
                        roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose paper, {player2.name} chose rock. - Player1 won");
                        player1.score++;
                    }
                    else if (player2.playerRPS == "scissor")
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
                    if (player2.playerRPS == "rock")
                    {
                        roundResuelt.Add($"Round {RoundNumber} - {player1.name} chose scissor, {player2.name} chose paper. - Player1 won");
                        player1.score++;
                    }
                    else if (player2.playerRPS == "scissor")
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

        }

        #region Rock paper scissor generator
        public string RPSGenerator() // method to generate rock, paper, or scissor for each player.
        {
            Random rnd = new Random(); // object class created to generate random number.
            switch (rnd.Next(3)) // generate random number from 0 - 2 and returning rock, paper, or scissor based off of what random number you generate.
            {
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
        #endregion






    }
}
