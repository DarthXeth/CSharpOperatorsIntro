using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpOperatorsIntro
{
    class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            int userChoice = 0; 

            while (userChoice != 99)
            {
                userChoice = RunMainMenu();
                switch (userChoice)
                {
                    case 1: //odd or even
                        RunOddOrEven();
                        break;
                    case 2: //div by
                        RunDivBy();
                        break;
                    case 3: //nth digit of i
                        RunGetNthDigit();
                        break;
                    case 4: //nth bit of i
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                        break;
                }
            }

            
        }

        /// <summary>
        /// Prints out the main menu for the CSharpOperators tutorial and handles the user response
        /// </summary>
        /// <returns> an integer that corresponds to the user's selection</returns>
        private static int RunMainMenu()
        {
            //init scope variables
            bool isValid = false;
            int retVal = 99;

            while (!isValid)
            {
                //print out menu
                Console.WriteLine("Choose an option from the menu below, or type 'Exit'");
                Console.WriteLine("");
                Console.WriteLine("01) Use modulus to determine whether a number is odd or even");
                Console.WriteLine("02) use modulus to determine if x is divisible by y");
                Console.WriteLine("03) Check and see if the x digit of y right-to-left is z ");
                Console.WriteLine("04) Check and reply whether the xth bit of y is 1 or 0");
                Console.WriteLine("05) Find the area of a trapezoid with sides x, y and height h");
                Console.WriteLine("06) Find the are and perimeter of a rectangle with length l and height h");
                Console.WriteLine("07) Find the weight of a man on the moon in lbs who weighs x lbs on Earth");
                Console.WriteLine("08) Determine if point {x, y} is inside circle [{0, 0}, K = R]");
                Console.WriteLine("09) Determine if point {x, y} is inside circle [{0, 0}, K = R]");
                Console.WriteLine("    but not rectangle [{-1, -1}, K = 5]");
                Console.WriteLine("10) Different format foo with a four-digit number");
                Console.WriteLine("11) Report what the value of bit in position p is of number n");
                Console.WriteLine("12) Report if the value of bit in position p of number n is value v");
                Console.WriteLine("13) given number n, position p, and value v, change the value of p = v");
                Console.WriteLine("    and print out new n");
                Console.WriteLine("14) determine whether number n is prime or not");
                Console.WriteLine("15) given 32-bit unsigned int i, swap bits at position p1, p2, and p3");
                Console.WriteLine("    with 33-p1, 33-p2, and 33-p3");
                Console.WriteLine("");
                Console.Write("Enter your option: ");
                
                //get response
                string response = Console.ReadLine().Trim();
                int x;

                //is response a number?
                bool isNum = int.TryParse(response, out x);

                if (isNum)  //if the response is a number
                {
                    if (x >= 1 && x <= 15)
                    {
                        //then this is a valid number
                        retVal = x;
                        isValid = true;
                    }
                }
                else
                {
                    //if the response is not a number
                    if (response.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                        //if we reach here, return with 99, as the user typed 'exit'
                        isValid = true;
                }

                if (!isValid)
                {
                    //if we reach here the user needs prompted again
                    Console.Clear();
                    Console.WriteLine("Invalid entry - Please enter a valid entry from the list below");
                }
            }

            return retVal;
        }

        /// <summary>
        /// Asks the user for a number and uses modulus operator to determine
        /// if number is odd or even
        /// </summary>
        private static void RunOddOrEven()
        {
            //clear the console
            Console.Clear();

            //set your looping variable - we loop until the user is done
            bool inLoop = true;

            //tell the user what you want them to do
            Console.WriteLine("This module asks for a number and then uses the modulus operator (%)");
            Console.WriteLine("To get the remainder of dividing by 2.  7 / 2 = 3 remainder 1, so 7 % 2 = 1");
            Console.WriteLine("Knowing this, anything mod 2 = zero is by definition an even number");
            Console.WriteLine("and anything mod 2 = 1 is an odd number. Modulus operations come");
            Console.WriteLine("up very often in programming");
            Console.WriteLine("");

            while (inLoop)  //this could theoiretically be while(true), but I reject that type of shenanigan out-of-hand
            {
                Console.Write("Enter a number and I'll tell you if it's odd or even (type 'exit' to quit): ");
                string response = Console.ReadLine();
                int numResponse;

                //can we turn their response into a number?
                bool isNumber = int.TryParse(response, out numResponse);

                if (isNumber)
                {
                    int mod = numResponse % 2;
                    string numberIs = "odd";

                    if (mod == 0)
                        numberIs = "even";

                    Console.WriteLine("");
                    Console.WriteLine("{0} is {1}", numResponse, numberIs);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (response.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                {
                    inLoop = false; //this isn't even really necessary, but be a good citizen
                    Console.Clear();
                    return;
                } else
                {
                    //these are all invalid entries
                    Console.Clear();
                    Console.WriteLine("{0} is an invalid entry...", response);
                }
            }
            
        }

        /// <summary>
        /// takes three numbers from user (x, y, and z) and checks to see if x%y = 0 and x%z = 0
        /// </summary>
        private static void RunDivBy()
        {
            int main, divOne, divTwo;

            //clear the console
            Console.Clear();
            Console.WriteLine("This module will collect three numbers from you - the 'Main'");
            Console.WriteLine("number, and two smaller 'divide by' numbers. It will then tell");
            Console.WriteLine("you if the numbers are divisible");
            Console.WriteLine("");

            string continueVal = "Y";

            while (continueVal.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
            {
                main = LoopForNumericInput("Enter your main number (best if fairly large): ");
                divOne = LoopForNumericInput("Enter your first divisor: ");
                divTwo = LoopForNumericInput("Enter your second divisor: ");

                int modOne = main % divOne;
                int modTwo = main % divTwo;

                if (modOne == 0 && modTwo == 0)
                {
                    //then we got a divisible number
                    Console.WriteLine("Congratulations! {0} is divisible by {1} AND {2}!", main, divOne, divTwo);
                } else if (modOne == 0 && modTwo == 1)
                {
                    Console.WriteLine("Hmmm, {0} is divisible by {1} but not by {2}", main, divOne, divTwo);
                } else if (modOne == 1 && modTwo == 0)
                {
                    Console.WriteLine("Hmmm, {0} is divisible by {2} but not by {1}", main, divOne, divTwo);
                } else
                {
                    //neither
                    Console.WriteLine(":-/ {0} is not divisible by {1} or {2}. Try harder.", main, divOne, divTwo);
                }
                continueVal = GetUserContinueChoice();
                Console.Clear();
            }
            
            

        }

        /// <summary>
        /// Gives the user a Y/N continue prompt and returns the choice
        /// </summary>
        /// <returns></returns>
        private static string GetUserContinueChoice()
        {
            Console.Write("Continue [Y/N]? ");
            string continueVal = Console.ReadKey().KeyChar.ToString();
            return continueVal;
        }

        /// <summary>
        /// This will create a loop that displays the passed prompt message until the user
        /// enters a valid integer-parseable value. Note this only works for integers!
        /// </summary>
        /// <param name="promptMsg">The message you want to use to prompt the user for input</param>
        /// <returns>an integer parsed from standard input</returns>
        private static int LoopForNumericInput(string promptMsg)
        {
            int numValue = 0;
            bool isNum = false;

            //main number
            while (true)  
            {
                Console.Write(promptMsg);
                string response = Console.ReadLine();
                isNum = int.TryParse(response, out numValue);

                if (!isNum)
                {
                    //invalid entry
                    Console.Clear();
                    Console.WriteLine("'{0}' is an invalid entry", response);
                }
                else
                {
                    break;
                }
            }

            return numValue;
        }

        /// <summary>
        /// This function asks the user for two inputs: i, an integer, and n,
        /// which represents the digit of i (from right to left). For example, 
        /// the nth digit of i, where i is 1234, and n is 3, is 2
        /// the nth digit of i, where i is 1234 and n is 1, is 4
        /// </summary>
        private static void RunGetNthDigit()
        {
            //run the intro message
            Console.Clear();
            Console.WriteLine("This module asks for 2 numbers, an integer i and a number n");
            Console.WriteLine("We will then find the nth digit of i");
            Console.WriteLine("Remember, the nth digit is counted rightward; ones to tens to hundreds to ... n");
            Console.WriteLine("");

            string continueVal = "Y";

            while (continueVal.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
            {
                //get i
                int i = LoopForNumericInput("Enter a large integer: ");
                int n = -1;

                //n must be <= the number of placesof i, so while it
                while (true)
                {
                    n = LoopForNumericInput("Enter an int for n; n must be less than the number of digits in i: ");
                    if (n <= i.ToString().ToCharArray().Length)
                    {   //we're good
                        break;
                    }   //keep looping...
                    Console.WriteLine("it is impossible to find the {0} of {1}", n, i);
                    Console.WriteLine("Remember that n must be less than the number of digits in i");
                }

                char[] iChars = i.ToString().ToCharArray();

                //we're going from right to left...
                char selected = iChars[iChars.Length - n];

                Console.WriteLine("The {0}th digit of {1} is {2}", n, i, selected);

                continueVal = GetUserContinueChoice();
                Console.Clear();
            }
        }
    }
}
