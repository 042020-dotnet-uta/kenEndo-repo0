using System;
using System.Collections;
namespace RPS_Game
{
    public class Player
    { // creating a player class to store player information.
        private string name; //string to store player name.
        public String Name
        {
            get { return name; }
            set { Name = value; }
        }

        private int wins;
        public int Wins
        {
            get { return wins; }
            set { wins = value; }
        }

        private int losses;
        public int Losses
        {
            get { return losses; }
            set { losses = value; }
        }
        private int ties;
        public int Ties
        {
            get { return ties; }
            set { ties = value; }
        }
        // public string curntRound; // string to store what player got from RPSGenerator(r/p/s)
        // public int score = 0; // int to store player wint count.
        public Player(string name)
        { // constructor to assign player name to the string.
            this.name = name;
        }

    }
}