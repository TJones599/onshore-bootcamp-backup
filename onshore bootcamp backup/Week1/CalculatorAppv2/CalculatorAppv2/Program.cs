using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAppv2
{
    class Program
    {
        static void Main(string[] args)
        {
            Decimal Answer = 0;
            char Operation = ' ';
            bool RunCalculation = true;
            while (RunCalculation)
            {
                Console.Clear();
                Console.WriteLine("Enter first number: ");
                Decimal num1 = Convert.ToDecimal(Console.ReadLine());
                Console.Clear();

                Console.WriteLine("Enter second number: ");
                Decimal num2 = Convert.ToDecimal(Console.ReadLine());
                Console.Clear();

                bool loopExit = false;
                bool operationFailure = false;
                while (!loopExit)
                {
                    loopExit = true;
                    Console.WriteLine("What operation do you require? Please choose a number");
                    Console.WriteLine("1) Addition \n2) Subtraction \n3) Multiplication \n4) Division");

                    int Choice = Convert.ToInt32(Console.ReadLine());

                    switch (Choice)
                    {
                        case 1:
                            {
                                Operation = '+';
                                Answer = (num1 + num2);
                                break;
                            }
                        case 2:
                            {
                                Operation = '-';
                                Answer = (num1 - num2);
                                break;
                            }
                        case 3:
                            {
                                Operation = '*';
                                Answer = (num1 * num2);
                                break;
                            }
                        case 4:
                            {
                                Operation = '/';
                                if (num2 != 0)
                                {
                                    Answer = (num1 / num2);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid operation. Cannot divide by 0!");
                                    operationFailure = true;
                                }   
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid operation selected.\nPlease choose one of the provided options");
                                loopExit = false;
                                break;
                            }
                    }
                    if (operationFailure == false)
                    {
                        Console.Clear();
                        Console.WriteLine("{0} {1} {2} = {3}", num1, Operation, num2, Answer);

                    }
                    
                }

                loopExit = false;
                while (!loopExit)
                {
                Console.WriteLine("\nWould you like to perform another operation?");
                Console.WriteLine("Yes");
                Console.WriteLine("No\n");

                string reply = Console.ReadLine();

                    switch (reply.ToLower())
                    {
                        case "no":
                            {
                                RunCalculation = false;
                                loopExit = true;
                                break;
                            }
                        case "yes":
                            {
                                loopExit = true;
                                break;
                            }
                        default:
                            {
                                Console.Clear();
                                Console.WriteLine("\n\"{0}\" Is an invalid option, please say \"Yes\" or \"No\"", reply);
                                break;
                            }
                    }
                }

            }

        }
    }
}
