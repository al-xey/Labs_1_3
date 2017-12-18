using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloOperators_stud
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Please,  type the number:
            1. Game Bulls and Cows
            2. Console calculator
            3. Factirial calculation
            4. Exit
            ");

            int a = GetIntegerNumber(1, 4);

            switch (a)
            {
                case 1:
                    BullsAndCows();
                    Console.WriteLine("");
                    break;
                case 2:
                    Calculator();
                    Console.WriteLine("");
                    break;
                case 3:
                    Factorial_calculation();
                    Console.WriteLine("");
                    break;
                default:
                    Console.WriteLine("Exit");
                    break;
            }
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
        #region BullsAndCows
        static void BullsAndCows()
        {
            //Key sequence: 3817283 or 3827183
            // Declare 7 int variables for the input numbers and other variables
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"Bulls and Cows.
Remember the four-digit number, and I'm try to guess it:)
If the matching digits are in their right positions, they are Bulls, if in different positions, they are Cows\n");
            Console.ForegroundColor = ConsoleColor.White;


            //set array of all possible numbers
            byte[][] possible_numbers = new byte[10000][];

            int count = 0;

            for (byte d1 = 0; d1 < 10; d1++)
            {
                for (byte d2 = 0; d2 < 10; d2++)
                {
                    for (byte d3 = 0; d3 < 10; d3++)
                    {
                        for (byte d4 = 0; d4 < 10; d4++)
                        {
                            possible_numbers[count] = new byte[4] { d1, d2, d3, d4 };

                            count++;
                        }
                    }
                }
            }

            int bulls = 0;
            int cows  = 0;
            bool success = false;

            byte[] current_number;

            while (true)
            {
                Random random = new Random();
                int current_index = random.Next(possible_numbers.Length - 1);

                current_number = possible_numbers[current_index];

                Console.WriteLine("May be your number is {0}?", GetNumberFromArray(current_number));

                Console.WriteLine("How many bulls?");
                bulls = GetIntegerNumber(0, 4);

                if (bulls == 4)
                {
                    success = true;
                    break;
                }

                Console.WriteLine("How many cows?");
                cows = GetIntegerNumber(0, 4);

                //set new array of all possible numbers
                byte[][] new_possible_numbers = new byte[0][];

                if (bulls + cows == 0)
                {
                    foreach (byte[] possible_number in possible_numbers)
                    {
                        bool add_number = true;

                        for (int i = 0; i < 4; i++)
                        {
                            // bulls
                            for (int j = 0; j < 4; j++)
                            {
                                if (current_number[i] == possible_number[j])
                                {
                                    add_number = false;
                                    i = 4;
                                    j = 4;
                                }
                            }
                        }

                        if (add_number)
                        {
                            Array.Resize(ref new_possible_numbers, new_possible_numbers.Length + 1);

                            new_possible_numbers[new_possible_numbers.Length - 1] = possible_number;
                        }
                    }
                }
                else
                {
                    foreach (byte[] possible_number in possible_numbers)
                    {
                        //compare current number and possible
                        bool equal = true;
                        for (int i = 0; i < 4; i++)
                        {
                            if (!(current_number[i] == possible_number[i]))
                            {
                                equal = false;
                                break;
                            }
                        }

                        if (equal)
                            continue;

                        byte b = 0;
                        byte c = 0;

                        byte?[] temp_number = new byte?[4];

                        for (int i = 0; i < 4; i++)
                        {
                            temp_number[i] = possible_number[i];
                        }

                        for (int i = 0; i < 4; i++)
                        {
                            bool found_bull = false;

                            // bulls
                            for (int j = 0; j < 4; j++)
                            {
                                if ((current_number[i] == temp_number[j]) && (i == j))
                                {
                                    b++;
                                    found_bull = true;
                                    temp_number[j] = null;

                                    break;
                                }

                            }

                            if (found_bull)
                                continue;
                        
                            // cows
                            for (int j = 0; j < 4; j++)
                            {
                                if ((current_number[i] == temp_number[j]) && !(i == j))
                                {
                                    c++;

                                    temp_number[j] = null;

                                    break;
                                }

                            }
                        }

                        if (bulls == b && cows == c)
                        {
                            Array.Resize(ref new_possible_numbers, new_possible_numbers.Length + 1);

                            new_possible_numbers[new_possible_numbers.Length - 1] = possible_number;
                        }
                    }
                }

                possible_numbers = new_possible_numbers;

                if (possible_numbers.Length < 2)
                {
                    if (possible_numbers.Length == 1)
                    {
                        current_number = possible_numbers[0];
                        success = true;
                    }

                    break;
                }
            }

            if (success)
                Console.WriteLine("Your number is {0}!", GetNumberFromArray(current_number));
            else
                Console.WriteLine("Error of counting bills or cows. Not possible to guess the number");

        }
        #endregion

        #region calculator
        static void Calculator()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"Select the arithmetic operation:
1. Multiplication 
2. Divide 
3. Addition 
4. Subtraction
5. Exponentiation ");

            Console.ForegroundColor = ConsoleColor.White;

            int a = GetIntegerNumber(1, 5);
            int n1, n2;

            switch (a)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nMultiplication");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("Enter first number a: ");

                    n1 = GetIntegerNumber();

                    Console.Write("Enter second number b: ");

                    n2 = GetIntegerNumber();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n{0} * {1} = {2}", n1, n2, n1 * n2);
                    Console.ForegroundColor = ConsoleColor.White;

                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nDivide");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("Enter first number a: ");

                    n1 = GetIntegerNumber();

                    Console.Write("Enter second number b: ");

                    n2 = GetIntegerNumber(0);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n{0} / {1} = {2}", n1, n2, n1 / n2);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nAddition");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("Enter first number a: ");

                    n1 = GetIntegerNumber();

                    Console.Write("Enter second number b: ");

                    n2 = GetIntegerNumber(0);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n{0} + {1} = {2}", n1, n2, n1 + n2);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nSubtraction");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("Enter first number a: ");

                    n1 = GetIntegerNumber();

                    Console.Write("Enter second number b: ");

                    n2 = GetIntegerNumber(0);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n{0} - {1} = {2}", n1, n2, n1 - n2);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nExponentiation");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("Enter first number (base): ");

                    n1 = GetIntegerNumber();

                    Console.Write("Enter second number (exponent): ");

                    n2 = GetIntegerNumber(1, 16);

                    int result = 0;
                    if (n1 == 0)
                        result = 1;
                    else
                    {
                        result = n1;

                        for (int i = 1; i < n2; i++)
                            result *= n1;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n{0}^{1} = {2}", n1, n2, result);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.WriteLine("Exit");
                    break;
            }
        }
        #endregion

        #region Factorial
        static void Factorial_calculation()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nFactirial calculation");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter a number: ");

            int n1 = GetIntegerNumber(1, 100);

            int result = 0;
            if (n1 == 1)
                result = 1;
            else
            {
                result = n1;

                for (int i = 1; i < n1; i++)
                    result *= i;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n{0}! = {1}", n1, result);
            Console.ForegroundColor = ConsoleColor.White;

        }
        #endregion

        static int GetIntegerNumber()
        {
            int input_number = 0;
            bool correct_input = false;

            while (!correct_input)
            {
                string input_string = Console.ReadLine();

                correct_input = int.TryParse(input_string, out input_number);

                if (!correct_input)
                    Console.WriteLine("Error input. Try again.");
            }

            return input_number;
        }

        static int GetIntegerNumber(int min_value, int max_value)
        {
            int input_number = 0;
            bool correct_input = false;

            while (!correct_input)
            {
                input_number = GetIntegerNumber();

                correct_input = ((input_number >= min_value) && (input_number <= max_value));

                if (!correct_input)
                    Console.WriteLine("Error input. Try again.");
            }

            return input_number;
        }

        static int GetIntegerNumber(int err_value)
        {
            int input_number = 0;
            bool correct_input = false;

            while (!correct_input)
            {
                input_number = GetIntegerNumber();

                correct_input = !(input_number == err_value);

                if (!correct_input)
                    Console.WriteLine("Error input. Try again.");
            }

            return input_number;
        }

        static string GetNumberFromArray(int[] mass_digits)
        {
            string strNumber = "";

            for (int i = 0; i < mass_digits.Length; i++)
                strNumber += mass_digits[i];

            return strNumber;

        }

        static string GetNumberFromArray(byte[] mass_digits)
        {
            string strNumber = "";

            for (int i = 0; i < mass_digits.Length; i++)
                strNumber += mass_digits[i];

            return strNumber;

        }

        static int[] ShiftArrayToLeft(int[] mass_digits)
        {
            if (mass_digits.Length < 2)
                return mass_digits;

            int k = mass_digits[0];

            for (int i = 1; i < mass_digits.Length; i++)
                mass_digits[i - 1] = mass_digits[i];

            mass_digits[mass_digits.Length - 1] = k;

            return mass_digits;
        }

        static int[] ShiftArrayToRight(int[] mass_digits)
        {
            if (mass_digits.Length < 2)
                return mass_digits;

            int k = mass_digits[mass_digits.Length - 1];

            for (int i = mass_digits.Length-1; i > 0; i--)
                mass_digits[i - 1] = mass_digits[i];

            mass_digits[0] = k;

            return mass_digits;
        }
    }
}
