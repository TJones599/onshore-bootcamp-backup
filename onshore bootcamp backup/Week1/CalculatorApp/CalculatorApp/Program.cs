namespace CalculatorApp
{
    using System;

    class Program
    {

        static void Main(string[] args)
        {

            Decimal Answer = 0;
            string Operation = "null";
            bool Run = true;
            while (Run)
            {
                Console.WriteLine("Enter first number:");
                Decimal firstNum = Convert.ToDecimal(Console.ReadLine());
                Console.Clear();

                Console.WriteLine("Enter second number:");
                Decimal secondNum = Convert.ToDecimal(Console.ReadLine());
                Console.Clear();

                bool invalidInput = true;
                while (invalidInput)
                {

                    Console.WriteLine("What operation do you require? Please choose a number.");
                    Console.WriteLine("1) Addition");
                    Console.WriteLine("2) Subtraction");
                    Console.WriteLine("3) Multiplication");
                    Console.WriteLine("4) Division");
                    Console.WriteLine("5) Exit");

                    int Choice = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();


                    //decimal num1 = 5;

                    //decimal num2 = 10;

                    //string operation = " + ";

                    //decimal answer = 15;
                    
                    ////Way 1 - Primitive way, string concatenation
                    //string sentence = num1 + operation + num2 + " = " + answer;

                    ////Way 2 - String formatting
                    //string otherSentence = String.Format("{0}{1}{2} = {3}", num1, operation, num2, answer);

                    ////Way 3 - String Interpolation
                    //string lastSentence = $"{ num1 }{ operation }{num2} = { answer}";

                    //Console.WriteLine(sentence);
                    //Console.WriteLine(otherSentence);
                    //Console.WriteLine(lastSentence);

                    //ctrl+r+r to quickly rename all instances of a variable name

                    if (Choice == 1)
                    {
                        Operation = " + ";
                        Console.Write(firstNum);
                        Console.Write(Operation);
                        Console.Write(secondNum);
                        Console.Write(" = ");
                        Console.WriteLine((firstNum + secondNum));
                        Answer = (firstNum + secondNum);

                        invalidInput = false;
                    }
                    else if (Choice == 2)
                    {   Operation = " - ";
                        Console.Write(firstNum);
                        Console.Write(Operation);
                        Console.Write(secondNum);
                        Console.Write(" = ");
                        Console.WriteLine((firstNum - secondNum));
                        Answer = (firstNum - secondNum);

                        invalidInput = false;
                    }
                    else if (Choice == 3)
                    {   Operation = " * ";
                        Answer = (firstNum * secondNum);
                        Console.Write(firstNum);
                        Console.Write(Operation);
                        Console.Write(secondNum);
                        Console.Write(" = ");
                        Console.WriteLine();

                        invalidInput = false;
                    }
                    else if (Choice == 4)
                    {
                        Operation = " / ";
                        Console.Write(firstNum);
                        Console.Write(Operation);
                        Console.Write(secondNum);
                        Console.Write(" = ");
                        Console.WriteLine((firstNum / secondNum));
                        Answer = (firstNum / secondNum);
                        invalidInput = false;
                    }
                    else if (Choice == 5)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Operation Selected");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        invalidInput = true;
                    }
                    if (!invalidInput)
                       {
                        Console.ReadKey();

                        Console.Clear();
                        Console.Write("Last operation was: ");
                        Console.Write(firstNum);
                        Console.Write(Operation);
                        Console.Write(secondNum);
                        Console.Write(" = ");
                        Console.WriteLine(Answer);
                        Console.SetCursorPosition(0, Console.CursorTop + 1);
                    }
                }

                Console.ReadKey(true);
            }
        }
    }
}
