using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Operators_lect
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
             try
            {
                do
                {
//do something
                        Console.WriteLine(@"Please,  type the number:
                        1.  Remainder operator
                        2.  Increment and decrement operatorss
                        3.  Logical operators
                        4.  Short-circuit logical operators
                        5.  Bitwise operators
                        6.  Shift operators
                        7.  if_else construct
                        8.  for construct
                        9.  do_while construct
                        10. while construct
                        ");
                        try
                        {
                            a = int.Parse(Console.ReadLine());
                            switch (a)
                            {
                                case 1:
                                    Remainder_oprtr();
                                    Console.WriteLine("");
                                    break;
                                case 2:
                                    Incr_Decr_oprtr();
                                    Console.WriteLine("");
                                    break;
                                case 3:
                                    Logical_oprtr();
                                    Console.WriteLine("");
                                    break;
                                case 4:
                                    Log_shrt_oprtr();
                                    Console.WriteLine("");
                                    break;
                                case 5:
                                    Bitwise_oprtr();
                                    Console.WriteLine("");
                                    break;
                                case 6:
                                    LeftShift_oprt();
                                    Console.WriteLine("");
                                    break;
                                case 7:
                                    if_else_constr();
                                    Console.WriteLine("");
                                    break;
                                case 8:
                                    for_constr();
                                    Console.WriteLine("");
                                    break;
                                case 9:
                                    do_while_constr();
                                    Console.WriteLine("");
                                    break;
                                case 10:
                                    while_constr();
                                    Console.WriteLine("");
                                    break;
                                default:
                                    Console.WriteLine("Exit");
                                    break;
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error");
                        }
                        finally
                        {
                            //Console.WriteLine("Press any key");
                            //Console.ReadLine();
                        }

                        //end do something
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Press Spacebar to exit; press any key to continue");
                        Console.ForegroundColor = ConsoleColor.White;
                }
                while (Console.ReadKey().Key != ConsoleKey.Spacebar);
            }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }

        }
        #region Remainder
        static void Remainder_oprtr()
        {
            Console.WriteLine(7 % 3);       // int
            Console.WriteLine(-7 % 3);      // int
            Console.WriteLine(7.0 % 3.2);   // double
            Console.WriteLine(7.0m % 3.2m); // decimal
            Console.WriteLine(-7.2 % 3.0);  // double         
        }
        #endregion

        #region Incr_Decr
        static void Incr_Decr_oprtr()
        {
            int i = 0, j = 0; i = i + 1;
            Console.WriteLine("Addition i = " + i);

            i = 0; j = 0; i = i++; //postfix
            Console.WriteLine("Incrementing (postfix, i = i++) i = " + i);

            i = 0; j = 0; i = ++i; //prefix
            Console.WriteLine("Incrementing (prefix, i = ++i) i = " + i);

            i = 0; j = 0; j = i + 1;
            Console.WriteLine("Addition j = i+1 =" + j + ", i = " + i);

            i = 0; j = 0; j = i++;
            Console.WriteLine("Incrementing (postfix) j = i++ =" + j + ", i = " + i);

            i = 0; j = 0; j = ++i;
            Console.WriteLine("Incrementing (prefix) j = ++i =" + j + ", i = " + i);
        }

        #endregion

        #region Log_shrt
        static void Log_shrt_oprtr()
        {

            Console.WriteLine("&");
            if (Lgcl_shrt_1() & Lgcl_shrt_2())
                Console.WriteLine("Dual");
            else
                Console.WriteLine("One method returns false");

            Console.WriteLine("\n&&");
            if (Lgcl_shrt_1() && Lgcl_shrt_2())
                Console.WriteLine("Dual");
            else
                Console.WriteLine("One method returns false");
        }

        static bool Lgcl_shrt_1()
        {
            Console.WriteLine("Hello Mary!");
            return false;
        }

        static bool Lgcl_shrt_2()
        {
            Console.WriteLine("Hello John!");
            return true;
        }
        #endregion

        #region Logical
        static void Logical_oprtr()
        {
            short i = 10, j = 12;
            bool flag1 = true, flag2 = false;

            Console.WriteLine("i = " + i + ", j = " + j);
            if (i < j)
                Console.WriteLine("i < j");
            if (i <= j)
                Console.WriteLine("i <= j");
            if (i != j)
                Console.WriteLine("i != j");
            Console.WriteLine();
            // Compare i and j
            if (i > j)
                Console.WriteLine("i > j");

            Console.WriteLine("flag1 = " + flag1 + ", flag2 = " + flag2);
            // Compare flag1 and flag2
            if (flag1 & flag2)
                Console.WriteLine("flag1 & flag2 - no data");
            if (!(flag1 & flag2))
                Console.WriteLine("!(flag1 & flag2) = true");
            if (flag1 | flag2)
                Console.WriteLine("flag1 | flag2 = true");
            if (flag1 ^ flag2)
                Console.WriteLine("flag1 ^ flag2 = true");

            Console.ReadLine();
        }
        #endregion

        #region Bitwise
        static void Bitwise_oprtr()
        {
            {
                even(12);
                check_even(6);
                odd(12);

                Console.ReadLine();
            }
        }
        // Transform odd to even
        static void even(int n)
        {
            int result;
            Console.WriteLine("Even numbers from 0 to {0}:\n", n);
            for (int i = 0; i <= n; i++)
            {
                // turning off bit zero
                result = i & 0xFFFE;
                Console.Write("{0}\t", result);
            }
        }

        // Check even
        static void check_even(int j)
        {
            Console.WriteLine("\n\nCheck parity from 1 to {0}\n", j);
            for (int i = 1; i <= j; i++)
            {
                if ((i & 1) == 0)
                    Console.WriteLine("Number {0} is even", i);
                else
                    Console.WriteLine("Number {0} is odd", i);
            }
        }

        // Transform even to odd
        static void odd(int n)
        {
            int result;
            Console.WriteLine("\nOdd numbers from 0 to {0}:\n", n);
            for (int i = 0; i <= n; i++)
            {
                result = i | 1;
                Console.Write("{0}\t", result);
            }


        }
        #endregion

        #region Shift
        static void LeftShift_oprt()
        {
            System.Diagnostics.Stopwatch tm = new System.Diagnostics.Stopwatch();
            tm.Start();
            byte pow = 1 << 5;
            tm.Stop();
            Console.WriteLine("Left-shift time = "+tm.Elapsed.TotalMilliseconds); // first time
            tm.Reset();
            tm.Start();
            byte mathPow = (byte)Math.Pow(2, 5);
            tm.Stop();
            Console.WriteLine("Math time = "+tm.Elapsed.TotalMilliseconds); // second time (for first probe is best)
        }
        #endregion

        #region If_else_constr
        static void if_else_constr()
        { 
            int i=4;
        if (6 < 4 * 3)
        Console.WriteLine ("6 < 4 * 3 - true"); // true
            if (6 < 4 * 3)
            {
                Console.WriteLine ("6 < 4 * 3 - true"); // true
                Console.WriteLine("...");
            }

        if (6 < 4 * 3)
            if (6 > i * 3)
                Console.WriteLine();
            else
                Console.WriteLine ("executes");
        // equivalent 
        if (6 < 4 * 3)
        {
            if (6 > i * 3)
                Console.WriteLine();
            else
                Console.WriteLine ("executes");
        }
        if (6 < i * 3)
        {
            if (6 > i * 3)
                Console.WriteLine();
        }
        else
            Console.WriteLine("does not execute");
        }
        #endregion

        #region For_constr
        static void for_constr()
        {
            //For construct #1
            Console.WriteLine("For construct #1");
            int res = 1, lim = 10;
            for (int j = 2; j <= lim; )
            {
                //multiplication
                res *= j;
                Console.WriteLine("j = "+j+" res = res*j = "+res);
                j++;
            }
            Console.WriteLine("End res = "+res +" . Press any key");
            Console.ReadKey();


            //For construct #2
            Console.WriteLine();
            Console.WriteLine("For construct #2");
                char opt;
                for (; ; )
                {
                    do
                    {
                        Console.WriteLine("Help on:");
                        Console.WriteLine("  1. operator");
                        Console.WriteLine("  2. statement");
                        Console.WriteLine("  3. label");
                        Console.WriteLine("  4. expression");
                        Console.Write("Choose number (q to quit): ");
                        do
                        {
                            opt = (char)Console.Read();
                        } while (opt == '\n' | opt == '\r');
                    } while (opt < '1' | opt > '4' & opt != 'q');

                    if (opt == 'q') break;

                    Console.WriteLine("\n");
                    Console.WriteLine("Come back to menu press any key");
                    Console.ReadKey();
                }
        }
        #endregion

        #region do_while_constr
        static void do_while_constr()
        {
            int m;

            m = -5;
            do
            {
                if (m > 0) break;
                Console.Write(m + "  ");
                m++;
            } while (m <= 10);

            Console.WriteLine("Done m = "+m); 
        }
        #endregion

        #region while_constr
        static void while_constr()
        {
            while_Continue();
            while_Break();
            while_Goto();
        }

            static void while_Continue()
            {
                //while construct #1
                Console.WriteLine("while construct #1 with continue");
                int i = 0;
                while (i < 8)
                {
                    i++;
                    if (i == 4)
                    {
                        i++;
                        Console.WriteLine(" i = " + i);
                        continue;
                    }
                }
                Console.WriteLine("Done. i = "+i + ".  Press any key");
                Console.ReadKey();
                Console.WriteLine();

            }

            static void while_Break()
            {
                //while construct #2
                Console.WriteLine("while construct #2 with break");
                int i = 0;
                while (i < 8)
                {
                    i++;
                    Console.WriteLine(" i = " + i);
                    if (i == 4)
                        break;
                }
                i++;
                Console.WriteLine("Done. i = " + i + ".  Press any key");
                Console.ReadKey();
                Console.WriteLine();
            }

            static void while_Goto()
            {
                //while construct #3
                Console.WriteLine("while construct #3 with goto");
                int i = 0;
                while (i < 8)
                {
                    Console.WriteLine(" i = " + i);
                    i++;
                    if (i == 4)
                        goto fin;
                }
            fin:
                Console.WriteLine("Done. i = " + i + ".  Press any key");
                Console.ReadKey();
                Console.WriteLine();
            }
        #endregion
    }
}

