using System;
using System.Collections;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel;

namespace RPS_Game
{
    public class Game
    {
        private readonly ILogger _logger;
        public Game(ILogger<Game> logger)
        {
            _logger = logger;
        }


        public List<Round> Rounds = new List<Round>();
        private Player p1;
        public Player P1
        {
            get { return p1; }
            set { p1 = value; }
        }
        private Player p2;
        public Player P2
        {
            get { return p2; }
            set { p2 = value; }
        }

        private Player winner;
        public Player Winner
        {
            get { return winner; }
            set { winner = value; }
        }
        private int roundNumber;
        public int RoundNumber
        {
            get { return roundNumber; }
            set { roundNumber = value; }
        }
        public void loggingTest()
        {
            _logger.LogInformation("LogInformation = Hello. My name is Log LogInformation");
            _logger.LogWarning("LogWarning = At {time} Now I'm Loggy McLoggerton", DateTime.Now);
            _logger.LogCritical("LogCritical = As of now, I'm Scrog McLog");
            _logger.LogDebug("Log Debug");//not printed to console
            _logger.LogError("LogError");
            _logger.LogTrace("Log Trace = Tracing my way back home.");//not printed to console

        }
        public void playAGame(Player P1, Player P2)
        {

            Round round = null;
            while (P1.Wins != 2 && P2.Wins != 2)
            { // using while loop to run the rounds until one player reaches a score of 2.
                round = new Round();
                round.P1Choice = round.RPSGenerator(); // generate r/p/s to store into playerCurntround.
                round.P2Choice = round.RPSGenerator();
                if (round.P1Choice == "rock")
                { // conditionals to check who won each round. If player one has a "rock"
                    if (round.P2Choice == "paper")
                    { // nested if statements to compare different result P2 will have with P1 having "rock"
                        Console.WriteLine($"Round {RoundNumber} - {P1.Name} chose rock, {P2.Name} chose paper. - P2 won"); // adds winner of the round to the array.
                        P2.Wins++; // adds a win count to player 2
                        P1.Losses++;
                    }
                    else if (round.P2Choice == "scissor")
                    {
                        Console.WriteLine($"Round {RoundNumber} - {P1.Name} chose rock, {P2.Name} chose scissor. - P1 won");
                        P1.Wins++;
                        P2.Losses++;
                    }
                    else
                    {
                        Console.WriteLine($"Round {RoundNumber} - {P1.Name} chose rock, {P2.Name} chose rock. - it is a ties");
                        P1.Ties++; // adds a tie count 
                        P2.Ties++;
                    }
                }
                else if (round.P1Choice == "paper")
                {
                    if (round.P2Choice == "rock")
                    {
                        Console.WriteLine($"Round {RoundNumber} - {P1.Name} chose paper, {P2.Name} chose rock. - P1 won");
                        P1.Wins++;
                        P2.Losses++;
                    }
                    else if (round.P2Choice == "scissor")
                    {
                        Console.WriteLine($"Round {RoundNumber} - {P1.Name} chose paper, {P2.Name} chose scissor. - P2 won");
                        P2.Wins++;
                        P1.Losses++;
                    }
                    else
                    {
                        Console.WriteLine($"Round {RoundNumber} - {P1.Name} chose paper, {P2.Name} chose paper. - it is a ties");
                        P1.Ties++; // adds a tie count 
                        P2.Ties++;
                    }
                }
                else
                {
                    if (round.P2Choice == "rock")
                    {
                        Console.WriteLine($"Round {RoundNumber} - {P1.Name} chose scissor, {P2.Name} chose paper. - P1 won");
                        P1.Wins++;
                        P2.Losses++;
                    }
                    else if (round.P2Choice == "scissor")
                    {
                        Console.WriteLine($"Round {RoundNumber} - {P1.Name} chose scissor, {P2.Name} chose rock. - P2 won");
                        P2.Wins++;
                        P1.Losses++;
                    }
                    else
                    {
                        Console.WriteLine($"Round {RoundNumber} - {P1.Name} chose scissor, {P2.Name} chose scissor. - it is a ties");
                        P1.Ties++; // adds a tie count 
                        P2.Ties++;
                    }
                }
                RoundNumber++; // updates the round number each loop.
                Rounds.Add(round);

            }
        }
    }
}