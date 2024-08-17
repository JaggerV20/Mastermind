using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    internal class Code
    {
        //Fields
        private static string[] pegColors = { "Red", "Orange", "Yellow", "Green", "Blue", "Purple" };
        public int[] colorCode = new int[4];
        public int[] ColorCode
        {
            get { return colorCode; }
            private set { colorCode = value; }
        }
        public int[] colorCount = new int[6];
        public int[] ColorCount
        {
            get { return colorCount; }
        }

        //Constructor
        public Code(int[] colorCode)
        {
            this.ColorCode = colorCode;
            for (int i = 0; i < colorCode.Length; i++)
            {
                ++colorCount[colorCode[i]];
            }
        }
    }
}
