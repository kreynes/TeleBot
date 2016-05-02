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
            var photoMsg = bot.SendAudio("chat_id", new InputFile("file_name.mp3", new FileStream(@"/path/to/file_name.mp3", FileMode.Open)), 151, "performer", "title").Result;
            Console.ReadLine();
        }
    }
}
