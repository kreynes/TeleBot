using System;
using System.Threading.Tasks;
using TeleBot;
using TeleBot.API.Message;

namespace Example
{
    class MainClass
    {
        public static Bot bot;
        public static void Main()
        {
            InitializeBot().Wait();
        }

        public static async Task InitializeBot()
        {
            bot = new Bot("token");
            var userbot = await bot.SendGetMeAsync();
            Console.WriteLine($"{userbot.FirstName} {userbot.LastName} {userbot.Username} {userbot.Id}");
            await bot.SendMessageAsync(new TextMessage("chatid", "testtext"));

            Console.ReadLine();
        }
    }
}
