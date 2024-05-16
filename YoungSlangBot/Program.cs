using Telegram.Bot;
using System.Net;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using System.Diagnostics;

namespace YoungSlangBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelegramBotClient botClient = new TelegramBotClient(new FileReader(new FilePathEditor("BotToken.txt").GetModifiedPath()).GetContent());
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(me);
        }
    }
}