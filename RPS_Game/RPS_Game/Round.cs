using System;
using System.Collections;

namespace RPS_Game
{
    public class Round
    {
        public int RoundId { get; set; }
        private Player winnner;
        public Player Winnner
        {
            get { return winnner; }
            set { winnner = value; }
        }
        private string p1Choice;
        public string P1Choice
        {
            get { return p1Choice; }
            set { p1Choice = value; }
        }
        private string p2Choice;
        public string P2Choice
        {
            get { return p2Choice; }
            set { p2Choice = value; }
        }
        public Round() { }
        public string RPSGenerator()
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