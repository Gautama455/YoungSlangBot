using System.Net.NetworkInformation;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace YoungSlangBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelegramBotClient botClient = new TelegramBotClient(new FileReader(new FilePathEditor("BotToken.txt").GetModifiedPath()).GetContent());
            //Console.WriteLine(new MessageBuilder(new HttpLinker(query)).BuildMessage());

            botClient.StartReceiving(Update, Error);
            Console.ReadLine();

        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            Message message = update.Message;

            if (message != null)
            {
                if (message.Text != null)
                {
                    if (message.Text.ToLower().Contains("здорова"))
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Здоровей видали");
                        return;
                    }
                    if (message.Text.Contains("/переведи"))
                    {
                        string[] messageParts = message.Text.Split(" ");
                        if (messageParts.Length != 2)
                        {
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Для данной команды нужен 1 параметр.");
                            return;
                        }
                        else
                        {
                            string parametr = messageParts[1];
                            string answerMessage = new MessageBuilder(new HttpLinker(parametr)).BuildMessage();
                            await botClient.SendTextMessageAsync(message.Chat.Id, answerMessage);
                            return;
                        }
                    }
                }
            }
            else
            {
                return;
            }            
        }

        async static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}