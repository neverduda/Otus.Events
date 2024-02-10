using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Events
{
    public class FileSearcher
    {
        public event EventHandler<FileArgs> FileFound;

        public void SearchFiles(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Console.WriteLine($"Каталог '{directory}' не найден.");
                return;
            }

            try
            {
                foreach (var file in Directory.GetFiles(directory))
                {
                    OnFileFound(new FileArgs(file));

                    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("Поиск отменен пользователем.");
                        return;
                    }
                }               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошбика во время поиска файлов: {ex.Message}");
            }
        }

        protected virtual void OnFileFound(FileArgs e)
        {
            FileFound?.Invoke(this, e);
        }
    }
}
