using Otus.Events;

namespace Events
{

    internal class Program
    {
        private static readonly List<MyClass> _myClasses = new()
            {
               new MyClass(){ Word = "Hello" },
               new MyClass(){ Word = "world!" },
               new MyClass(){ Word = "!!!" }
            };

        static void Main(string[] args)
        {
            string directoryPath = "C:\\temp\\TestFolder";

            FileSearcher searcher = new FileSearcher();
            searcher.FileFound += (sender, e) =>
            {
                Console.WriteLine($"Файл найден: {e.FileName}");
            };

            Console.WriteLine("Поиск файлов...");
            searcher.SearchFiles(directoryPath);

            Console.WriteLine("Поиск завершен.");


            var max = _myClasses.GetMax<MyClass>(x => x.Word.Length);
            Console.WriteLine($"Максимум: {max.Word}");
            Console.ReadLine();
        }
    }
}
