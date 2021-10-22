namespace Trello
{
    public class TrelloOptions : ITrelloOptions
    {
        public string ApiKey { get; set; }
        public string ApiToken { get; set; }
        public string UrlBase { get; set; }
        public string TrelloListId { get; set; }
        public string TrelloLabelsId { get; set; }
        public string TrelloNameCard { get; set; }
    }
}
