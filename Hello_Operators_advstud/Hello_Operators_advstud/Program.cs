using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Operators_advstud
{
    class Program
    {
        const int MyMax = 10;

        private static bool ReadUserNumber(out int user_number)
        {
            user_number = 0;

            bool correct_input = false;
            string input_string  = "";

            while (!correct_input)
            {
                input_string = Console.ReadLine();

                if (input_string == "quit")
                {
                    break;
                }
                else
                {
                    if (int.TryParse(input_string, out user_number))
                        if ((user_number >= 0) && (user_number <= MyMax))
                            correct_input = true;
                        else
                            Console.WriteLine("Input error, try again.");
                    else
                        Console.WriteLine("Input error, try again.");
                }

            }

            return correct_input;
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            // random.Next(MaxValue) returns a 32-bit signed integer that is greater than or equal to 0 and less than MaxValue
            int guess_number = random.Next(MyMax) + 1;
            // implement input of number and comparison result message in the while circle with  comparison condition

            int user_number = guess_number + 1;
            bool success = false;
            bool first_message = true;

            while (!success)
            {
                Console.WriteLine((first_message) ? "Guess number from 0 to {0} (for exit type \"quit\")" : "No. Try again (for exit type \"quit\")", MyMax);

                first_message = false;

                if (ReadUserNumber(out user_number))
                {
                    if (user_number == guess_number)
                        success = true;
                }
                else
                    break;

            }

            if (success)
                Console.WriteLine("Congratulations!!!");

            
        }
    }
}
