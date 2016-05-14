using System;
using System.IO;

namespace TeleBot
{
    public class InputFile
    {
        public string Filename { get; set; }
        public Stream FileData { get; set; }

        public InputFile(string filename, Stream fileDataStream)
        {
            Filename = filename;
            FileData = fileDataStream;
        }
    }
}

