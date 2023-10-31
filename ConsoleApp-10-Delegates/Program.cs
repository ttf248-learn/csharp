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

//这个示例演示了如何使用委托来引用不同的方法。在这里，我们定义了一个 Calculator 类，其中包含了 Add 和 Subtract 两个方法，然后创建了一个委托 BinaryOperation，用于引用这两个方法。

//我们创建了委托实例 add 和 subtract，并分别将它们分配给 Add 和 Subtract 方法。然后，我们可以使用这些委托实例来调用相应的方法，从而实现动态方法调用。