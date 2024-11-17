using Number_Guessing_Game;
using System;

public class NumberGuessingGame
{   
    public static void Main(string[] args){
        Game game = new Game();

        game.SelectDifficulty();
        game.StartGame();
    }
}

