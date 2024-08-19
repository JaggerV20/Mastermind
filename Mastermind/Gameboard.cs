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
            GuessesRemaining = NORMALGAMELENGTH;

        }

        //Methods

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

    }
}
