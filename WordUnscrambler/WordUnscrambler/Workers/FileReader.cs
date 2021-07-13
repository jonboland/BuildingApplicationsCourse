using System.IO;

namespace WordUnscrambler.Workers
{
    class FileReader
    {
        public string[] Read(string fileName)
        {
            return File.ReadAllLines(fileName);
        }
    }
}
