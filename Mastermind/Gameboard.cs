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
            GuessAnalysis = new int[3];
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
            int[] filler = { 0, 0, 0, 0 };
            return new Code(filler);
        }

        /*
         * Take the entered Code to  return an array for GuessAnalysis
         * Return format is a size 3 array representing
         * [Correct placements, Correct colors in wrong places, Completely wrong placements]
         */
        private int[] GetFeedback(Code guess)
        {
            int[] info = new int[3];
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
