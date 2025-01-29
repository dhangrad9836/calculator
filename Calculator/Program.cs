using CalculatorLibrary;
using System.Text.RegularExpressions;


class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        //Display title as the C# console calculator app
        Console.WriteLine("Console Calculator in c#\r");
        Console.WriteLine("-------------------------\n");

        //Create Calculator object
        Calculator calculator = new Calculator();

        while(!endApp)
        {
            // Declare variables and set to empty
            // Use Nullable types (with ?) to match type of System.Readline
            string? numInput1 = "";
            string? numInput2 = "";
            double result = 0;

            // Ask the user to type the first number.
            Console.WriteLine("Type a number, and then press Enter: ");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput1 = Console.ReadLine();
            }

            // Ask the user to type the second number.
            Console.WriteLine("Type a number, and then press Enter: ");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput2 = Console.ReadLine();
            }

            // Ask user to choose an operator
            Console.WriteLine("Choose an operator from the following list: ");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtraction");
            Console.WriteLine("\tm - Multiplication");
            Console.WriteLine("\td - Division");
            Console.WriteLine("Your option?");

            //get user option
            string? op = Console.ReadLine();

            // Validate input is not null, and matches the pattern
            // this regex is to match up the add/subtract/multiply/divide
            if(op == null || ! Regex.IsMatch(op, "[a|s|m|d]"))
            {
                Console.WriteLine("Error: Unrecognized input.");
            }
            else
            {
                try
                {   //we modified code and now we use the calculator object from Calculator class
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else
                    {
                        Console.WriteLine("Your result: {0:0.##}\n", result);
                    }               
                } // end try
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                } // end catch
            }
            Console.WriteLine("-------------------------\n");

            // Wait for the user to respond before closing.
            Console.Write("Press 'n' and Enter to close  the app, or press any other key and Enter to continue: ");
            //end the app
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n"); //just whitespace

        }// end while
        return;
    } //end main
} // end class Program