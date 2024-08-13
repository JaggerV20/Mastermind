# Mastermind

C# program of the game "Mastermind"

8/9/2024 Jagger Vicente jagger04@icloud.com

Overview This is a program to practice writing C# programs. I will attempt to program the game "Mastermind". The goal of the game is to guess a 4 peg code where each peg can be one of 6 colors. The user will be the guesser, and the computer will generate a code and provide feedback to refine guesses. Upon entering a guess, the user receives two pieces of information: number of correct pegs and number of pegs that are the correct color, but the peg is in the wrong location. The user has 12 attempts to correctly guess the code.

Design Ideas Attempt 1: The game will utilize a "code" class to store pegs. Pegs will be ints with an array to show them as colors. Each "code" will contain the code itself in a array of length 4 and a secondary array that contains the number of each colors in the array. The "codes" will then be used in a "board" class that analyzes the entered codes and keeps track of game elements such as remaining turns and previous code as a visual element. The main method will be a basic game loop that initializes the board and each code.
