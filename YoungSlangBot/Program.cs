using Telegram.Bot;
using System.Net;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Web;
using System.Text.Json.Nodes;

namespace YoungSlangBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TelegramBotClient botClient = new TelegramBotClient(new FileReader(new FilePathEditor("BotToken.txt").GetModifiedPath()).GetContent());
            //HttpLinker httpLinker = new HttpLinker("запрос");
            //Console.WriteLine(httpLinker.GetStringResponse());

            string url = $"https://ru.wiktionary.org/w/api.php?action=opensearch&search={HttpUtility.UrlEncode("запрос")}&format=json";
            //string url = "https://ru.wiktionary.org/w/api.php";

            HttpClient client = new HttpClient();
            //HttpResponseMessage response = client.GetAsync(url + "&" + action + "&" + page + "&" + format).Result;
            HttpResponseMessage response = client.GetAsync(url).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var deserializedObject = JsonConvert.DeserializeObject<List<List<string>>>(result);
            Console.WriteLine(deserializedObject.ElementAt(2).ElementAt(0));

        }
    }
}