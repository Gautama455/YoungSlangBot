using System;

namespace YoungSlangBot
{
    internal class FilePathEditor
    {
        private string _filePath;

        public FilePathEditor(string fileName)
        {
            string path = Environment.CurrentDirectory.Replace("\\bin\\Debug\\net6.0", "\\Resourse\\");
            _filePath = Path.Combine(path, fileName);
        }

        public string GetModifiedPath()
        {
            return _filePath;
        }
    }
}
