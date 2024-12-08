using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace Calculator
{
    internal class Program
    {

        // Util function to safely get a double from stdin
        static double GetDoubleFromStdin(string prompt)
        {
            double num;
            Console.Write(prompt);

            while (true)
            {
                string input = Console.ReadLine();

                try
                {
                    num = Convert.ToDouble(input);
                    break;
                }
                catch
                {
                    Console.Clear(); // Keep stdout clean
                    Console.WriteLine("Invalid number, please try again.");
                    Console.Write(prompt);
                }
            }

            return num;
        }

        // Util function to safely get a char from stdin
        static char GetCharFromStdin(string prompt, char[] validChars)
        {
            char result;
            Console.Write(prompt);

            while (true)
            {
                string input = Console.ReadLine();

                // Input should not be null or empty, be of length 1 and be valid
                if (!string.IsNullOrEmpty(input) && input.Length == 1 && validChars.Contains(input[0]))
                {
                    result = input[0];
                    break;
                }
                else
                {
                    Console.Clear(); // Keep stdout clean
                    Console.WriteLine("Invalid option, please try again.");
                    Console.Write(prompt);
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            // Title :)
            Console.WriteLine("+---------------------------+");
            Console.WriteLine("| Simple Console Calculator |");
            Console.WriteLine("+---------------------------+");


            // Getting numbers
            double num1 = 0;

            if (args.Length > 0)
            {
                try
                {
                    Console.WriteLine($"Your first number was received from a previous run: {args[0]}");
                    num1 = Convert.ToDouble(args[0]);
                } catch
                {
                    Console.WriteLine("Something went wrong, please try again.");
                    Console.WriteLine("Press any key to exit...\n");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            } else
            {
                num1 = GetDoubleFromStdin("What is the first number?\n> ");
            }

            double num2 = GetDoubleFromStdin("What is the second number?\n> ");

            // Define supported operations
            Dictionary<string, (string name, char shortcut, char symbol)> operations = new Dictionary<string, (string name, char shortcut, char symbol)>
            {
                { "add", ("Add", 'a', '+') },
                { "sub", ("Subtract", 's', '-') },
                { "mul", ("Multiply", 'm', '*') },
                { "div", ("Divide", 'd', '/') },
                { "pow", ("Power", 'p', '^') }
            };

            string operationPrompt = "Supported operations:\n";

            // List supported operations in the prompt
            foreach (string key in operations.Keys)
            {
                (string, char, char) op = operations[key];

                operationPrompt += $"{op.Item2} - {op.Item1}\n";
            }

            operationPrompt += "Choose an operation.\n> ";

            char[] validOptions = operations.Values.Select(op => op.shortcut).ToArray();
            char chosenOperationShortcut = GetCharFromStdin(operationPrompt, validOptions);

            (string, char, char) chosenOperation = operations.Values.FirstOrDefault(o => o.shortcut == chosenOperationShortcut);

            // Initialize result
            double result = 0;

            // Calculate result based on chosen operation
            if (chosenOperation == operations["add"])
            {
                result = num1 + num2;
            }

            if (chosenOperation == operations["sub"])
            {
                result = num1 - num2;
            }

            if (chosenOperation == operations["mul"])
            {
                result = num1 * num2;
            }

            if (chosenOperation == operations["div"])
            {
                result = num1 / num2;
            }

            if (chosenOperation == operations["pow"])
            {
                result = Math.Pow(num1, num2);
            }

            // Print the result and wait for exit
            Console.WriteLine($"{num1} {chosenOperation.Item3} {num2} = {result}\n");

            char[] opts = { 'y', 'n' };
            char shouldRestart = GetCharFromStdin("Would you like to use the result for another operation? y/n\n> ", opts);

            if (shouldRestart == 'y')
            {
                Process.Start(Environment.GetCommandLineArgs()[0], result.ToString());
                Environment.Exit(0);
            } else
            {
                Console.WriteLine("Press any key to exit...\n");
                Console.ReadKey();
            }
        }
    }
}
