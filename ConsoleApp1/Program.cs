using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // create random number generator
            Random r = new Random();

            // Keep track of both dice
            int roll1 = 0;
            int roll2 = 0;

            //keep track of the total rolls
            int totalRoll = 0;

            //create output string
            string output = "";

            //store the double before rounding to an int
            double tempDoubleStorage = 0.0;

            //store the number of *
            int numAst = 0;


            //changing the console color so the output matches the example in the project
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            //clear out the previous colors to create a solid consistant background and font color
            //(I'm ashamed to admit that I went to stack overflow for this line :'( )
            Console.Clear();

            // store the number of dice
            int[] dice = new int[11];

            // set all values to 0. I think this is defaulted to 0 but we'll do it to be safe
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = 0;
            }

            //welcome the user
            Console.Write("Welcome to the dice throwing simulator! \n\nHow many dice rolls would you like to simulate?  ");

            // Get dice roll
            int numDieRolls = Convert.ToInt32(Console.ReadLine());
            
            //start filling out the output string
            output += "\nDICE ROLLING SIMULATION RESULTS\n" +
                    "Each \"*\" represents 1 % of the total number of rolls.\n" +
                    "Total number of rolls = " + numDieRolls.ToString() + ".\n\n";
            

            //roll the prompted number of dice
            for (int i = 0; i<numDieRolls; i++)
            {
                //set die one and two. add the two together to get the total. The total will vary from 2 - 12
                // The array has positions 0-11. 0 = 2, 1 = 3, 2 = 4... etc. Increase the count of each number
                roll1 = r.Next(1, 7);
                roll2 = r.Next(1, 7);

                //sum the two rolls
                totalRoll = roll1 + roll2;

                //increment the appropriate postition
                dice[(totalRoll - 2)] += 1;
                //Console.WriteLine(dice[totalRoll - 2]);
            }

            //loop through the count of each number rolled by the dice
            for (int i = 0; i<dice.Length;i++)
            {
                //add to the output string by creating a number: and padding with spaces so the histogram lines up
                output += ((i + 2).ToString() + ": ").PadRight(4, ' ');

                //C# was yelling at me about not diffrenciating between double and decimal
                //for the round function so I made this double var so it will stop
                tempDoubleStorage = ((double)dice[i] / numDieRolls) * 100;

                //this represents the number of * to add to the histogram.
                numAst = Convert.ToInt32(Math.Round(tempDoubleStorage));

                //concat on an * for each pct
                for(int j = 0; j<numAst; j++)
                {
                    output += "*";
                }

                //add a new line
                output += "\n";
            }

            //finish the output
            output += "\nThank you for using the dice throwing simulator. Goodbye!";

            //write the output
            Console.WriteLine(output);

            //listen so that the terminal stays open
            Console.Read();
        }
    }
}
