using HtmlAgilityPack;

namespace YoungSlangBot
{
    internal class HtmlParser
    {
        private HtmlDocument _htmlDocument;
        private HtmlNode? _currentNode = null;

        public HtmlParser(string url) => _htmlDocument = new HtmlWeb().Load(url);

        public HtmlDocument GetHtmlDocument() => _htmlDocument;
        public HtmlNode? GetCurrentNode() => _currentNode;

        private void SetNode()
        {
            _currentNode = _htmlDocument.DocumentNode.SelectSingleNode("//span[@class='mw-headline' and @id='Значение']");
        }

        public List<HtmlNode> getWikiResult()
        {
            SetNode();
            GetParentTag();
            GetTag("ol");
            GetChildTag();
            return FilterNodes(GetChildCollections());
        }

        public List<HtmlNode> FilterNodes(HtmlNodeCollection htmlNodes)
        {
            List<HtmlNode> nodes = new List<HtmlNode>();
            foreach (HtmlNode htmlNode in htmlNodes)
            {
                if ((htmlNode.OriginalName == "a" && htmlNode.FirstChild.OriginalName != "span") || htmlNode.OriginalName == "#text")
                {
                    nodes.Add(htmlNode);
                }
            }
            return nodes;
        }

        private void GetParentTag()
        {
            if (_currentNode is not null)
            {
                _currentNode = _currentNode.ParentNode;
            }
            else
            {
                throw new Exception("Не найдена родительский тэг");
            }
        }

        private void GetChildTag()
        {
            if (_currentNode.HasChildNodes)
            {
                _currentNode = _currentNode.FirstChild;
            }
            else
            {
                throw new Exception("Не найден дочерний тэг");
            }
        }

        private HtmlNodeCollection GetChildCollections()
        {
            if (_currentNode.HasChildNodes)
            {
                return _currentNode.ChildNodes;
            }
            else
            {
                throw new Exception("Не найдены дочерние тэги");
            }
        }

        private void GetTag(string tagName)
        {
            if (_currentNode is not null)
            {
                while (_currentNode.OriginalName != tagName)
                {
                    _currentNode = _currentNode.NextSibling;
                }
            }
            else { throw new Exception("Не найден текущий тэг"); }
        }
    }
}
