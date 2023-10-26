namespace ConsoleApp_07_Struct
{
    internal class Program
    {
        struct Books
        {
            public string title;
            public string description;
            public string author;
            public string subject;
            public int book_id;
        }

        static void Main(string[] args)
        {
            Books book1;

            book1.title = "test1";
            book1.description = "test1 description";
            book1.author = "test1 author";
            book1.subject = "test1 subject";
            book1.book_id = 1;

            Console.WriteLine("title:{0}", book1.title);
            Console.WriteLine("description:{0}", book1.description);
            Console.WriteLine("author:{0}", book1.author);
            Console.WriteLine("subject:{0}", book1.subject);
            Console.WriteLine("book_id:{0}", book1.book_id);

            Console.ReadKey();
        }
    }
}