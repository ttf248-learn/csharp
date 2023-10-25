namespace ConsoleApp_06_ConstTest
{
    class SampleClass
    {
        public int x;
        public int y;
        public const int c1 = 5;
        public const int c2 = c1 + 5;

        public SampleClass(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SampleClass sampleClass = new SampleClass(11, 22);

            Console.WriteLine("x = {0}, y = {1}", sampleClass.x, sampleClass.y);
            
            // 访问常量，还不能直接使用实例化的对象，需要用到 class name 来访问常量
            Console.WriteLine("c1 = {0}, c2 = {1}", SampleClass.c1, SampleClass.c2);
        }
    }
}