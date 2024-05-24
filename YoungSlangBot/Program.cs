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

            HttpLinker httpLinker = new HttpLinker("чилить");
            string responseUrl = StringEditor.ParseResponseUrl(httpLinker.GetStringWikiResponse());
            HtmlParser htmlParser = new HtmlParser(responseUrl);

            List<HtmlNode> htmlNodes = htmlParser.getWikiResult();

            foreach (HtmlNode node in htmlNodes)
            {
                Console.WriteLine(node.InnerText);
            }


        }
    }
}