using System.Web;
using HtmlAgilityPack;


namespace YoungSlangBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TelegramBotClient botClient = new TelegramBotClient(new FileReader(new FilePathEditor("BotToken.txt").GetModifiedPath()).GetContent());
            //HttpLinker httpLinker = new HttpLinker("запрос");
            //Console.WriteLine(httpLinker.GetStringGoogleResponse());

            HttpLinker httpLinker = new HttpLinker("кринж");
            string responseUrl = StringEditor.ParseResponseUrl(httpLinker.GetStringWikiResponse());
            httpLinker.SetQuery(responseUrl);
            string result = httpLinker.GetData(responseUrl);
            Console.WriteLine(result);

        }
    }
}