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
            string apiKey = new FileReader(new FilePathEditor("APIKey.txt").GetModifiedPath()).GetContent();
            string searchEngineId = new FileReader(new FilePathEditor("SearhEngineId.txt").GetModifiedPath()).GetContent();
            string query = "Солнце";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"https://www.googleapis.com/customsearch/v1?key={apiKey}&cx={searchEngineId}&q={query}").Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(responseBody);
                }
                else
                {
                    Console.WriteLine("Ошибка: " + response.StatusCode);
                }
            }
        }
    }
}