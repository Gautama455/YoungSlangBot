using HtmlAgilityPack;

namespace YoungSlangBot
{
    internal class MessageBuilder
    {
        private List<HtmlNode> _htmlNodes;

        public MessageBuilder(List<HtmlNode> htmlNodes)
        {
            _htmlNodes = htmlNodes;
        }

    }
}
