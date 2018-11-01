
namespace AdvCalc
{
    using System;
    using System.Media;
    using System.Reflection;
    using System.Threading;

    class Program
    {
        //finds filepath to sound resource directory
        private static string soundFolderPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+@"\sound";

        private static void WriteDateAt(int left, int top)
        {
            //checks for console size and providing and error code if cursor position is outside of the console

            //saving starting cursor position
            int oldLeft = Console.CursorLeft;
            int oldTop = Console.CursorTop;

            string time = string.Format("{0:t}", DateTime.Now);

            //setting cursor to target position,outputing the Time of Day, and resetting the cursor to starting position
            Console.SetCursorPosition(left, top);
            Console.WriteLine(time);
            Console.SetCursorPosition(oldLeft, oldTop);
        }

        ///Input Response

        //plays a sound if input was not acccepted
        public static void SoundFailure()
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = soundFolderPath + @"\smb3_bump.wav";
            sp.Load();
            sp.Play();
            Thread.Sleep(150);
        }

        //plays a sound if input was accepted
        public static void SoundSuccess()
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = soundFolderPath + @"\smb3_fireball.wav";
            sp.Load();
            sp.Play();
            Thread.Sleep(150);
        }

        //If input is not accepted, displays input rejection message
        public static void InvalidInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid entry, please try again!");
            Console.ResetColor();
        }

        //turns entered text green, and return input
        public static string Input()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string input = Console.ReadLine();
            Console.ResetColor();

            return input;
        }

        ///Math

        //adds 2 given numbers and returns total.
        public static decimal AddNumbers(decimal firstNum, decimal secondNum)
        {
            decimal total = firstNum + secondNum;
            return total;
        }

        //subtracts 2 given numbers and returns total.
        public static decimal SubtractNumbers(decimal firstNum, decimal secondNum)
        {
            decimal total = firstNum - secondNum;
            return total;
        }

        //multiply 2 given numbers and returns total.
        public static decimal MultiplyNumbers(decimal firstNum, decimal secondNum)
        {
            decimal total = firstNum * secondNum;
            return total;
        }

        //divide 2 given numbers and returns total. does not check for zero.
        public static decimal DivideNumbers(decimal firstNum, decimal secondNum)
        {
            decimal total = firstNum / secondNum;
            return total;
        }

        //sets total to number given. loops (exponent-1) number of times, multiplying total by number given each time through.
        //returns total after loop completes.
        public static decimal Exponent(decimal number, int exponent)
        {
            decimal total = number;
            for(int i = 1; i<=exponent-1;i++)
            {
                total = total * number;
            }
            return total;
        }

        ///Recieve Input

        //retrieves input and checks if it can be decimal parsed. if not, loops until success
        public static decimal ObtainDecimalInput(string message)
        {
            decimal input=0;
            bool validInput = false;
            do
            {
                Console.WriteLine(message);
                string textInput = Input();
                
                validInput = decimal.TryParse(textInput, out input);

                if(!validInput)
                {
                    Console.Clear();
                    InvalidInput();
                    SoundFailure();
                }
                else
                {
                    SoundSuccess();
                }

            } while (!validInput);

            return input;
        }

        //retrieves input and checks if it can be int parsed. if not, loops until success
        public static int ObtainIntInput(string message)
        {
            int input = 0;
            bool validInput = false;

            do
            {
                Console.WriteLine(message);
                string textInput = Input();
                
                validInput = int.TryParse(textInput, out input);

                if (!validInput)
                {
                    Console.Clear();
                    InvalidInput();
                    SoundFailure();
                }
                else
                    SoundSuccess();


            } while (!validInput);



            return input;
        }

        //retrieves yes or no input and varifies "yes" or "no" were entered. not case sensitive. loops until success
        public static bool ObtainBoolInput(string message)
        {
            bool response = false;
            string input = "";
            bool validInput;

            do
            {
                validInput = true;
                Console.WriteLine(message);
                
                input = Input();

                if (input.ToLower() == "yes")
                {
                    validInput = true;
                    response = true;
                }
                else if (input.ToLower() == "no")
                {
                    response = false;
                }
                else
                {
                    validInput = false;
                }

                if (!validInput)
                {
                    InvalidInput();
                    SoundFailure();
                }

            } while (!validInput);

            return response;
        }

        //retrieves input and checks against available operands. loops until successful match
        public static string GetOperand()
        {
            string input="";
            bool validInput = false;
            do
            {
                Console.WriteLine("\nPlease choose an operator:\n" +
                    "Add      - +\n" +
                    "Subtract - -\n" +
                    "Multiply - *\n" +
                    "Divide   - /\n" +
                    "Exponent - ^\n");

                input = Input();

                if (input == "+" || input == "-" || input == "*" || input == "/" || input == "^")
                {
                    validInput = true;
                    SoundSuccess();
                }
                else
                {
                    InvalidInput();
                    SoundFailure();
                }

            } while (!validInput);

            return input;
        }

        ///Main Program
        private static void Main(string[] args)
        {
            SoundPlayer sp = new SoundPlayer();

            Console.SetWindowSize(40, 25);

            decimal total = 0;
            decimal lastTotal = 0;

            int problemNumber = 1;

            string operand="";

            //used to ensure that the math is possible. i.e. cannot divide by zero
            bool operandFailure = false;

            bool nextProblem = true;
            bool continueThisProblem = false;

            //loops endlessly until user decides to quit.
            //prompted at end of each problem
            do
            {
                decimal inputOne=0;
                decimal inputTwo=0;

                int exponent=1;

                Console.Clear();
                WriteDateAt(30, 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Problem {0}: ",problemNumber);
                Console.ResetColor();

                //only shows up if part of a continuous problem
                if (continueThisProblem)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Last answer was : {0}", lastTotal);
                    Console.ResetColor();
                }
                
                //only asks for first number if not a continuous problem
                if(!continueThisProblem)
                    inputOne = ObtainDecimalInput("Please enter a number: ");
                else
                {
                    continueThisProblem = false;
                    inputOne = lastTotal;
                }

                operand = GetOperand();

                //If exponent is selected, requests an integer input
                //otherwise requests a decimal input
                if (operand == "^")
                    exponent = ObtainIntInput("\nPlease enter a whole number:");
                else
                    inputTwo = ObtainDecimalInput("\nPlease enter the second number");

                //checks operator and call associated method to perform the math
                switch (operand)
                {
                    case "+":
                        {
                            total = AddNumbers(inputOne,inputTwo);
                            break;
                        }
                    case "-":
                        {
                            total = SubtractNumbers(inputOne, inputTwo);
                            break;
                        }
                    case "*":
                        {
                            total = MultiplyNumbers(inputOne, inputTwo);
                            break;
                        }
                    case "/":
                        {
                            //if second number is zero, operation is not possible.
                            //set operandFialure to true and skip the method call.
                            if (inputTwo == 0)
                                operandFailure = true;
                            else
                                total = DivideNumbers(inputOne, inputTwo);
                            break;
                        }
                    case "^":
                        {
                            total = Exponent(inputOne, exponent);
                            break;
                        }
                }

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Problem number: {0}", problemNumber);
                Console.ResetColor();

                if (operandFailure)
                {
                    Console.WriteLine("Cannot Divide by Zero!");
                    operandFailure = false;
                    continueThisProblem = ObtainBoolInput("\nContinue this problem?\n" + "Yes\n" + "No\n");
                }
                else
                {
                    if (operand == "^")
                        Console.WriteLine("{0} {1} {2} = {3}\n", inputOne, operand, exponent, total);
                    else
                        Console.WriteLine("{0} {1} {2} = {3}\n", inputOne, operand, inputTwo, total);

                    WriteDateAt(30, 1);

                    sp.SoundLocation = soundFolderPath + @"\smb3_1-up.wav";
                    sp.Load();
                    sp.Play();

                    continueThisProblem = ObtainBoolInput("\nContinue this problem?\n" + "Yes\n" + "No\n");
                }

                if (!continueThisProblem)
                {
                    nextProblem = ObtainBoolInput("\nDo you want to work on another problem?\n" + "Yes\n" + "No\n");
                    problemNumber++;
                }
                else
                    lastTotal = total;

                if (!nextProblem)
                {
                    sp.SoundLocation = soundFolderPath + @"\LTTP_Link_Fall.wav";
                    sp.Load();
                    sp.Play();
                    Thread.Sleep(850);
                }

            } while (nextProblem);
        }
    }
}
