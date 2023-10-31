using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp_09_Delegates
{
    public class Calculator
    {
        // 定义委托
        public delegate int BinaryOperation(int a, int b);

        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Substrace(int a, int b)
        {
            return a - b;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            Calculator.BinaryOperation add = calculator.Add;
            Calculator.BinaryOperation substrace = calculator.Substrace;

            int result1 = add(1, 2);
            int result2 = substrace(1, 2);

            Console.WriteLine("add: {0}", result1);
            Console.WriteLine("substrace: {0}", result2);
        }
    }
}