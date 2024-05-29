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
        static async Task Main(string[] args)
        {
            string botToken = new FileReader(new FilePathEditor("BotToken.txt").GetModifiedPath()).GetContent();
            TelegramBotClient botClient = new TelegramBotClient(botToken);
            try
            {
                var cancellationTokenSource = new CancellationTokenSource();

                var receiverOptions = new ReceiverOptions
                {
                    AllowedUpdates = Array.Empty<UpdateType>()
                };

                Console.ReadLine();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
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
                            // Предполагается, что HttpLinker принимает строку в формате URL.
                            string baseUrl = "https://example.com/translate?text=";
                            string parametr = messageParts[1];
                            string fullUrl = baseUrl + Uri.EscapeDataString(parametr);

                            // Использование HttpLinker с правильным URL
                            string answerMessage = new MessageBuilder(new HttpLinker(fullUrl)).BuildMessage();
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
            // Логирование ошибки в консоль
            Console.WriteLine($"Ошибка: {exception.Message}");

            // Также можно логировать стек вызовов для более подробного анализа
            Console.WriteLine(exception.StackTrace);

            // Реализуйте дополнительную обработку ошибок при необходимости
            await Task.CompletedTask;
        }
    }
}