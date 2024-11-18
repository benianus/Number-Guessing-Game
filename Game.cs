using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Guessing_Game
{
    internal class Game
    {
        public enDifficultyLevel difficulty { get; set; }
        public int randomNumber { get; set; }
        public int chances { get; set; }    

        public void SelectDifficulty()
        {
            Console.WriteLine("Please select Difficulty:");
            Console.WriteLine("1. Easy (10 chances)");
            Console.WriteLine("2. Medium (5 chances)");
            Console.WriteLine("3. Hard (3 Chances)");
            Console.Write("Enter your choice: ");

            int choice = GetChoice();

            // choose the difficulty level of the game
            SetDifficulty(choice);

            Console.WriteLine($"Greate, you select the {difficulty.ToString().ToLower()} difficulty level");
        }
        private void SetDifficulty(int choice)
        {
            switch (choice)
            {
                case 1:
                    chances = 10;
                    difficulty = enDifficultyLevel.EASY;
                    break;
                case 2:
                    chances = 5;
                    difficulty = enDifficultyLevel.MEDIUM;
                    break;
                case 3:
                    chances = 3;
                    difficulty = enDifficultyLevel.HARD;
                    break;
            }
        }
        private int GetChoice()
        {
            int choice = Convert.ToInt32(Console.ReadLine());

            while (choice > 3)
            {
                Console.Write("Great number! Enter number between 1 to 3: ");
                choice = Convert.ToInt32(Console.ReadLine());
            }

            return choice;
        }
        public void StartGame()
        {
            // generate random number using Random class
            var random = new Random();
            int yourChoice = 0;
            int attempts = 0;

            // choose random number from 1 to 100
            randomNumber = random.Next(1, 100);

            // enter your choice
            Console.WriteLine("Let's start the game!");

            for (int i = 0; i < chances; i++)
            {
                Console.Write("\nEnter your guess from[1] to to [100]: ");
                yourChoice = Convert.ToInt32(Console.ReadLine());

                // the number of the attemeption you get the correct answer
                attempts++;
                
                if (yourChoice == randomNumber)
                {
                    Console.WriteLine($"Congratulations! You guessed the correct number in {attempts} attempts.");
                    return;
                }
                else if (yourChoice > randomNumber)
                {
                    Console.WriteLine($"Incorrect! the number is greater then {yourChoice}");
                }
                else if(yourChoice < randomNumber)
                {
                    Console.WriteLine($"Incorrect! the number is less then {yourChoice}");
                }
            }

            // show message chances finished if the player didn't
            // guess the number correctly during number of chances
            Console.WriteLine($"Game over! you didn't get the correct answer, you just blown all {chances} chances, you can't guess again");
            
            // repeat the game again if the player choose yes
            RepeatGame();
        }
        private void RepeatGame()
        {
            string? answer = string.Empty;

            Console.Write("\nDo you want to play again Yes [Y] No [N]: ");
            answer = Console.ReadLine();
            if (answer?.ToUpper() == "Y")
            {
                Console.Clear();
                SelectDifficulty();
                StartGame();
                return;
            }

            Console.WriteLine("Thanks! Good luck, have a nice day");
            return;
        }
    }
}
