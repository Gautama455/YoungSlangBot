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
            string result = httpLinker.GetData(responseUrl);
            HtmlDocument doc = new HtmlWeb().Load(responseUrl);

            Console.WriteLine(doc.DocumentNode.SelectSingleNode("//span[@class='mw-headline' and @id='Значение']"));
        }
    }
}