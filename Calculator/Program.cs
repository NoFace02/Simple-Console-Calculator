using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            char[] op = new char[4]; // declaring the type of operation
            op[0] = 'a';
            op[1] = 's';
            op[2] = 'm';
            op[3] = 'd';
            double num1 = 0; double num2 = 0; double result = 0; //declaring numbers and the result

            Console.WriteLine("Simple Console Calculator\r"); //just to look at little bit better
            Console.WriteLine("-------------------------\n");

            Console.Write("Type a number: ");
            num1 = Convert.ToDouble(Console.ReadLine()); //getting the first number

            Console.WriteLine("Choose an option from the following list:"); //found this on internet and i like the model so i just copy it, it let the user chose wich type of operation he wants to do
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");
            /* i wasted like one hour becouse of the error CS1501 searching everywhere what is the error, but ChatGPT came to save me 
             The Console.ReadLine dosent accept argumets it just reads and prints it as a string at first i tried Console.ReadLine(op[0], op[1], op[2], op[3] */
            char operation = Console.ReadLine()[0]; 


            Console.Write("Type another number: ");
            num2 = Convert.ToDouble(Console.ReadLine()); //getting second number

            switch (operation) //simple switch, at first i tried if but switch was more simple for me :)
            {
                // add
                case 'a':
                    result = num1 + num2;
                    Console.WriteLine($"Your result: {num1} + {num2} = {result}");
                    break;
                // substract
                case 's':
                    result = num1 - num2;
                    Console.WriteLine($"Your result: {num1} - {num2} = {result}");
                    break;
                // multiplies
                case 'm':
                    result = num1 * num2;
                    Console.WriteLine($"Your result: {num1} * {num2} = {result}");
                    break;
                // divides
                case 'd':
                    if (num2 != 0) //checking if user typed 0 becouse u cant divide by 0, duhh
                    {
                        result = num1 / num2;
                        Console.WriteLine($"Your result: {num1} / {num2} = {result}");
                    }
                    else
                    {
                        Console.WriteLine("Error: U cant divide by 0."); //made an error confirmation for user to let them know
                    }
                    break;
                default:
                    Console.WriteLine("Error, invalid option."); //and here if they chose anything than a,s,m or d, made an error confirmation for user to let them know
                    break;
            }

            Console.WriteLine("\nPress any key to close the calculator..."); // a way to close the console for the user
            Console.ReadKey();

        }
    }
}
