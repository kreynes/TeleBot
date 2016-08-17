using System.IO;

namespace TeleBot.API.Types
{
    public class InputFile
    {
        public InputFile(string filename, Stream fileDataStream)
        {
            Filename = filename;
            FileData = fileDataStream;
        }

        public string Filename { get; set; }
        public Stream FileData { get; set; }
    }
}