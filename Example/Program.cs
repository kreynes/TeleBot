using System;
using System.Net.Http;
using System.IO;
using TeleBot;

namespace Example
{
    class MainClass
    {
        public static Bot bot;
        public static void Main()
        {
            bot = new Bot("");
            var userbot = bot.SendGetMeAsync().Result;
            Console.WriteLine($"{userbot.FirstName} {userbot.LastName} {userbot.Username} {userbot.Id}");
            //var testMsg = bot.SendMessageAsync("-119425511", "Test").Result;
            var photoMsg = bot.SendPhoto("chatid", new InputFile("file.png", new FileStream(@"/path/to/file/2ueo1w5.png", FileMode.Open))).Result;
            foreach (PhotoSize photo in photoMsg.Photo)
            {
                Console.WriteLine(photo.FileSize);
            }
            Console.ReadLine();
        }
    }
}
