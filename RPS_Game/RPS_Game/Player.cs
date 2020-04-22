using System;
using System.Collections.Generic;
using System.Text;

namespace RPS_Game
{
    class Player// creating a player class to store player information.
    {
        public string name { get; set; }//string to store player name.
        public string playerRPS; // string to store what player got from RPSGenerator(r/p/s).
        public int score = 0;// int to store player wint count.
        public Player(string name)// constructor to assign player name to the string.
        {
            this.name = name;
        }
    }
}

