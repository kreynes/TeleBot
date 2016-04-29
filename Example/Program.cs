using System;
using System.Net.Http;
using TeleBot;

namespace Example
{
    class MainClass
    {
        public static Bot bot;
        public static void Main()
        {
            bot = new Bot("token");
            var userbot = bot.SendGetMeAsync().Result;
            Console.WriteLine($"{userbot.FirstName} {userbot.LastName} {userbot.Username} {userbot.Id}");
            Console.ReadLine();
        }
    }
}
