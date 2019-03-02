using System;
using System.Collections.Generic;

namespace Delegates
{
    public class Program
    {
        private delegate decimal Operation(decimal number1, decimal number2);

        public static void Main()
        {
            var operations = new List<Operation> { Divide, Multiply, Subtract, Sum };

            foreach (var operation in operations)
            {
                var result = operation(100, 50);

                Console.WriteLine($"{ operation.Method.Name }: { result }");
            }

            Console.ReadKey();
        }

        private static decimal Divide(decimal number1, decimal number2)
        {
            return number1 / number2;
        }

        private static decimal Multiply(decimal number1, decimal number2)
        {
            return number1 * number2;
        }

        private static decimal Subtract(decimal number1, decimal number2)
        {
            return number1 - number2;
        }

        private static decimal Sum(decimal number1, decimal number2)
        {
            return number1 + number2;
        }
    }
}
