using Telegram.Bot;

namespace YoungSlangBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelegramBotClient botClient = new TelegramBotClient(new FileReader(new FilePathEditor("BotToken.txt").GetModifiedPath()).GetContent());
            string query = "запрос";
            Console.WriteLine(new MessageBuilder(new HttpLinker(query)).BuildMessage());
        }
    }
}