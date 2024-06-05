using HtmlAgilityPack;

namespace YoungSlangBot
{
    internal class MessageBuilder
    {
        private List<HtmlNode> _messageInHtmlNodes;
        private HttpLinker _httpLinker;
        private string[] _messageArray;

        public MessageBuilder(HttpLinker httpLinker)
        {

            _httpLinker = httpLinker;
            _messageInHtmlNodes = BuildListNodes();
            _messageArray = GetTextMessageArray();
        }

        private List<HtmlNode> BuildListNodes()
        {
            string responseUrl = StringEditor.ParseResponseUrl(_httpLinker.GetStringWikiResponse());

            try
            {
                HtmlParser htmlParser = new HtmlParser(responseUrl);
                return htmlParser.getWikiResult();
            }
            catch (ArgumentException exc)
            {
                HtmlNode newNode = HtmlNode.CreateNode($"<p>{exc.Message}</p>");
                return new List<HtmlNode> { newNode };
            }
        }

        public string[] GetTextMessageArray() => _messageArray = ConvertToStringsArray(FilterMessage(_messageInHtmlNodes));

        private string[] ConvertToStringsArray(List<HtmlNode> nodes)
        {
            string[] strings = new string[nodes.Count];

            for (int i = 0; i < nodes.Count; i++)
                strings[i] = nodes.ElementAt(i).InnerText;

            return strings;
        }

        private string AddCapitalLetter(string word)
        {
            char firstLetter = char.ToUpper(word[0]);
            string firstWord = firstLetter + word.Substring(1);

            return firstWord;
        }

        private List<HtmlNode> FilterMessage(List<HtmlNode> nodes)
        {
            List<HtmlNode> filterednodes = new List<HtmlNode>();

            foreach (HtmlNode htmlNode in nodes)
            {
                if (htmlNode.InnerText == ", " || htmlNode.InnerText == " " || htmlNode.InnerText == "")
                    continue;
                else filterednodes.Add(htmlNode);
            }
            return filterednodes;
        }

        public string BuildMessage()
        {
            string message = string.Empty;

            foreach (string str in _messageArray)
            {
                if (str == _messageArray.Last())
                    message = message + str + ".";
                else
                    message = message + str + ", ";
            }

            return AddCapitalLetter(_httpLinker.Query) + " - " + message;
        }
    }
}
