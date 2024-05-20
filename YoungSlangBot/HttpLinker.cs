using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoungSlangBot
{
    public class HttpLinker
    {
        private string _apiKey;
        private string _searchEngineId;
        private string? _query;

        public HttpLinker()
        {
            _apiKey = new FileReader(new FilePathEditor("APIKey.txt").GetModifiedPath()).GetContent();
            _searchEngineId = new FileReader(new FilePathEditor("SearhEngineId.txt").GetModifiedPath()).GetContent();
            _query = null;
        }

        public HttpLinker(string query)
        {
            _apiKey = new FileReader(new FilePathEditor("APIKey.txt").GetModifiedPath()).GetContent();
            _searchEngineId = new FileReader(new FilePathEditor("SearhEngineId.txt").GetModifiedPath()).GetContent();
            _query = query;
        }

        public void GetQuery(string query)
        {
            _query = query;
        }

        public string GetStringResponse()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"https://www.googleapis.com/customsearch/v1?key={_apiKey}&cx={_searchEngineId}&q={_query}").Result;

                if (response.IsSuccessStatusCode)
                {
                     return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    throw new HttpRequestException($"Не удалось установить соединение. Status code: {response.StatusCode}");
                }
            }
        }
    }
}
