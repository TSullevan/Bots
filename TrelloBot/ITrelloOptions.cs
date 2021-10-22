namespace Trello
{
    public interface ITrelloOptions
    {
        string ApiKey { get; set; }
        string ApiToken { get; set; }
        string UrlBase { get; set; }
        string TrelloListId { get; set; }
        string TrelloLabelsId { get; set; }
        string TrelloNameCard { get; set; }
    }
}
