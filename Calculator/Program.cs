using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Nums nums = new Nums();
                Ops ops = new Ops();

                Color("=================", ConsoleColor.Red);
                Console.WriteLine("Simple Calculator");
                Color("=================", ConsoleColor.Red);

                while (true)
                {
                    Console.WriteLine("\n");
                    Color2("Your first number: ", ConsoleColor.Green);
                    string num1 = Console.ReadLine();


                    try
                    {
                        nums.Num1 = Convert.ToDecimal(num1);
                        break;
                    }
                    catch (FormatException)
                    {
                        Color("ERROR, Please use numbers!", ConsoleColor.Red);
                        Console.ReadLine();
                        Console.Clear();
                        Color("=================", ConsoleColor.Red);
                        Console.WriteLine("Simple Calculator");
                        Color("=================", ConsoleColor.Red);
                    }
                }




                while (true)
                {
                    while (true)
                    {
                        Color2("Write an operation: ", ConsoleColor.Green);
                        ops.op = Console.ReadLine();
                        if (ops.op != "+" && ops.op != "-" && ops.op != "*" && ops.op != "/")
                        {
                            Color("Please write a valid operation", ConsoleColor.Red);
                            Console.ReadLine();
                            Console.Clear();
                            Color("=================", ConsoleColor.Red);
                            Console.WriteLine("Simple Calculator");
                            Color("=================\n\n", ConsoleColor.Red);
                            Color2("Your first number: ", ConsoleColor.Green);
                            Console.Write(nums.Num1 + "\n");


                        }
                        else
                        {
                            break;
                        }
                    }
                    while (true)
                    {
                        Color2("Your second number: ", ConsoleColor.Green);
                        string num2 = Console.ReadLine();
                        try
                        {
                            nums.Num2 = Convert.ToDecimal(num2);
                            break;
                        }
                        catch (FormatException)
                        {
                            Color("ERROR, Please use numbers!", ConsoleColor.Red);
                            Console.ReadLine();
                            Console.Clear();
                            Color("=================", ConsoleColor.Red);
                            Console.WriteLine("Simple Calculator");
                            Color("=================\n\n", ConsoleColor.Red);
                            Color2("Your first number: ", ConsoleColor.Green);
                            Console.Write(nums.Num1 + "\n");
                            Color2("Write an operation: ", ConsoleColor.Green);
                            Console.Write(ops.op + "\n");
                        }
                    }

                    switch (ops.op)
                    {
                        case "+":
                            nums.Num3 = nums.Num1 + nums.Num2;
                            Color2($"Your result: ", ConsoleColor.Green);
                            Console.Write($"{nums.Num3}\n");
                            nums.Num1 = nums.Num3;

                            break;
                        case "-":
                            nums.Num3 = nums.Num1 - nums.Num2;
                            Color2($"Your result: ", ConsoleColor.Green);
                            Console.Write($"{nums.Num3} \n");
                            nums.Num1 = nums.Num3;

                            break;
                        case "*":
                            nums.Num3 = nums.Num1 * nums.Num2;
                            Color2($"Your result: ", ConsoleColor.Green);
                            Console.Write($"{nums.Num3}\n");
                            nums.Num1 = nums.Num3;

                            break;
                        case "/":
                            try
                            {
                                nums.Num3 = nums.Num1 / nums.Num2;
                                Color2($"Your result: ", ConsoleColor.Green);
                                Console.Write($"{nums.Num3}\n");
                                nums.Num1 = nums.Num3;

                            }
                            catch (DivideByZeroException)
                            {
                                Color("You cant divide by 0", ConsoleColor.Red);
                            }
                            break;
                    }
                    Console.WriteLine("\n");
                    Color2("Do you want to continue? y/n: ", ConsoleColor.Green);
                    string yesno = Console.ReadLine().ToLower();
                    Console.Clear();
                    Color("=================", ConsoleColor.Red);
                    Console.WriteLine("Simple Calculator");
                    Color("=================\n\n", ConsoleColor.Red);
                    Color2("Your first number: ", ConsoleColor.Green);
                    Console.Write(nums.Num1 + "\n");
                    if (yesno == "n")
                    {
                        Console.Clear();
                        break;
                    }
                }
                Color2("Do you want to close the console?: Y/N ", ConsoleColor.Green);
                string yesno2 = Console.ReadLine().ToLower();
                if (yesno2 == "y")
                {
                    break;
                }
                Console.Clear();

            }





        }
        static void Color(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        static void Color2(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
