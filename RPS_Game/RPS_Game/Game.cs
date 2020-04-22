using System;

namespace RPS_Game
{
    class Game
    {
        Round x = new Round();

        public Game()
        {
            gameStartUp();
            x.roundCalc();
            displayResult();
        }

        public void gameStartUp()
        {
            Console.WriteLine("Enter Player one name"); // prompting user to enter the player name on console.
            x.player1 = new Player(Console.ReadLine()); // storing the entered player name into player obj.
            Console.WriteLine("Enter Player two name");
            x.player2 = new Player(Console.ReadLine());
        }

        public void displayResult()
        {
            foreach (string result in x.roundResuelt)// after we get out of the loop, this for loop is ran to display result of all the rounds on console.
            {
                Console.WriteLine(result);
            }
            if (x.player1.score == 2) // display whichever player that has 2 wins and display the winner on console.
            {
                Console.WriteLine($"{x.player1.name} wins 2-{x.player2.score} with {x.ties} ties.");
            }
            else
            {
                Console.WriteLine($"{x.player2.name} wins 2-{x.player1.score} with {x.ties} ties.");
            }
        }




    }
}
