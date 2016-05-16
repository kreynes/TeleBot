# TeleBot .NET

TeleBot is a lightweight asynchronous wrapper for the Telegram API written in C# for the .NET platform. TeleBot has a focus on ease-of-use and attempts to abstract away the difficulties of communicating with a web service, allowing you to focus on building your applications.

|         | Appveyor                                                                                                                                                                | Travis-CI                                                                                                          |
|---------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------|
| Master  | [![Build status](https://ci.appveyor.com/api/projects/status/g5q95c3wt7f1xqm1?svg=true)](https://ci.appveyor.com/project/kreynes/telebot)                               | [![Build Status](https://travis-ci.org/kreynes/TeleBot.svg?branch=master)](https://travis-ci.org/kreynes/TeleBot)  |
| Develop | [![Build status](https://ci.appveyor.com/api/projects/status/g5q95c3wt7f1xqm1/branch/develop?svg=true)](https://ci.appveyor.com/project/kreynes/telebot/branch/develop) | [![Build Status](https://travis-ci.org/kreynes/TeleBot.svg?branch=develop)](https://travis-ci.org/kreynes/TeleBot) |

### Example

```csharp
using TeleBot;
using TeleBot.API.Message;
        public static void Main()
        {
            InitializeBot().Wait();
        }

        public static async Task InitializeBot()
        {
            //Creates a new instance of a bot, with the provided 
            //Telegram Bot API Token.
            bot = new Bot("api_token"); 
            //Send s getMe GET Request, to check if the bot is 
            //authenticating correctly.
            var userbot = await bot.SendGetMeAsync(); //
            await bot.SendMessageAsync(new TextMessage("chatid", "testtext"));
            Console.ReadLine();
        }
    }
}
```

### Installation via NuGet
TODO Add to NuGet

### License

Copyright © 2016 contributors to TeleBot. Code released under the [MIT License](https://github.com/kreynes/TeleBot/blob/master/LICENSE.md).
