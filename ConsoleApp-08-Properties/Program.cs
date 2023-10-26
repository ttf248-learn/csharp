namespace ConsoleApp_08_Properties
{
    public class  Person
    {
        // 声明属性
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();

            person.Name = "Test";

            string name = person.Name;

            Console.WriteLine("Name:{0}", name);
        }
    }
}