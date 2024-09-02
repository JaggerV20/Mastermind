using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    internal class Gameboard
    {
        //Fields
        const int NORMALGAMELENGTH = 12;
        public Code[] Board
        {
            get; private set;
        }
        //Format : [Correct, Wrong Place, Completely Wrong]
        public int[][] GuessAnalysis
        {
            get;
            private set;
        }
        public int GuessesRemaining
        {
            get; private set;
        }
        public Code MasterCode
        {
            get; private set;
        }

        //Constructor
        public Gameboard()
        {
            Board = new Code[NORMALGAMELENGTH];
            GuessAnalysis = new int[NORMALGAMELENGTH][];
            GuessesRemaining = NORMALGAMELENGTH;

        }

        //Methods
        /*
         * Returns true to end game
         * Game loop method that calls other methods to run the game.
         * Main method won't do much except possibly selecting a game mode.
         * Generate a master code, prompt the user for guesses, analyze guesses,
         * and return results. Provide a visual representation of the game state
         */
        public bool GameLoop()
        {
            return true;
        }

        //Return an int array to be used in a Code constructor
        private int[] GenerateCode()
        {
            int[] GeneratedCode = new int[4];
            Random rand = new Random();
            for (int i = 0; i < GeneratedCode.Length; i++)
            {
                GeneratedCode[i] = rand.Next(0, 6);
            }
            return GeneratedCode;
        }
        /*
         * Prompt the player to enter a guess. 
         * Allow the user to select a hole/index and select a color.
         * When guess is valid and player is satisfied, they can enter an escape value to end
         * and return a new Code
         */
        private Code GetGuess()
        {
            int[] codeBase = {0, 0, 0, 0 };
            int selectedSlot = -1;
            int selectedColor = -1;
            bool validEntry = false;
            while (selectedSlot != 0)
            {
                validEntry = false;
                selectedSlot = -1;
                //Select slot loop
                while (!validEntry)
                {
                    Console.WriteLine("Please select a slot (1, 2, 3, 4). Enter 0 to quit: ");
                    try
                    {
                        selectedSlot = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid entry");
                    }
                    if (selectedSlot < 0 || selectedSlot > 4)
                    {
                        Console.WriteLine("Invalid entry");
                    }
                    else
                    {
                        validEntry = true;
                        if (selectedSlot == 0)
                        {
                            for (int i = 0; i < codeBase.Length; i++)
                            {
                                if (codeBase[i] == 0)
                                {
                                    Console.WriteLine($"No color entered for {i + 1}. " +
                                        "Please enter one before exiting.");
                                    validEntry = false;
                                }
                            }
                        }
                    }
                }
                //Select color peg loop
                validEntry = false;
                selectedColor = -1;
                while (selectedSlot != 0 && !validEntry)
                {
                    Console.WriteLine($"Please select a color for slot {selectedSlot} " +
                        $"(1 - Red, 2 - Orange, 3 - Yellow, 4 - Green, 5 - Blue, 6 - Purple). " +
                        $"Enter 0 to quit: ");
                    try
                    {
                        selectedColor = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid entry");
                    }
                    if (selectedColor < 0 || selectedColor > 6)
                    {
                        Console.WriteLine("Invalid entry");
                    }
                    else
                    {
                        validEntry = true;
                        codeBase[selectedSlot - 1] = selectedColor;
                    }
                }
            }
            return new Code(codeBase);
        }

        /*
         * Take the entered Code to return an array for GuessAnalysis
         * Return format is a size 3 array representing
         * [Correct placements, Correct colors in wrong places, Completely wrong placements]
         * Completely wrong placements isn't exactly needed. Keep this in mind if it can 
         * streamline the code. It might be helpful for debugging at least.
         */
        private int[] GetFeedback(Code guess)
        {
            //pegsListed will be info[2]
            int pegsListed = 4;
            int[] info = new int[3];
            int[] guessColorsRemaining = guess.ColorCount;
            int[] masterColorsRemaining = MasterCode.ColorCount;
            //Checking exact placements
            for(int i = 0; i < guess.colorCode.Length; i++ )
            {
                //If color is in correct spot, increment info[0] and decrement colorsRemaining
                //Used to show what colors need to be guessed for info[1];
                if (guess.colorCode[i] == MasterCode.colorCode[i])
                {
                    info[0]++;
                    guessColorsRemaining[guess.colorCode[i]]--;
                    masterColorsRemaining[guess.colorCode[i]]--;
                    pegsListed--;
                }
            }
            //checking correct colors in wrong places
            for(int i = 0; i < guessColorsRemaining.Length; i++)
            {
                if (guessColorsRemaining[i] == masterColorsRemaining[i])
                {
                    info[1] += guessColorsRemaining[i];
                    pegsListed -= guessColorsRemaining[i];
                }
            }
            info[2] = pegsListed;
            return info;
        }

        /*
         * Display the game board using Board, GuessAnalysis, and MasterCode
         * Format Idea:
         * R . . . . . . . . . . . ?
         * R . . . . . . . . . . . ?
         * R . . . . . . . . . . . ?
         * R . . . . . . . . . . . ?
         * 
         * W 
         * R
         * .
         * .
         * 
         * Top - Gameboard showing guesses. '?' represents unknown master code.
         * Shown at end. Letters are colors
         * Bottom - Feedback of the code above. 
         * W - Completely correct
         * R - Right color, wrong spot
         * . - Incorrect
         */
        private void DisplayBoard()
        {

        }

    }
}
