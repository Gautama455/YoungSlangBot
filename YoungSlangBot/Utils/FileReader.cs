using System;
using System.IO;

namespace YoungSlangBot
{
    internal class FileReader
    {
        private string _filePath;

        public FileReader(string filePath)
        {
            _filePath = filePath;
        }

        public string GetContent()
        {
            if (File.Exists(_filePath))
            {
                return File.ReadAllText(_filePath);
            }
            else
            {
                throw new FileNotFoundException($"Файл, имеющий путь {_filePath}, не найден!");
            }
        }
    }
}
