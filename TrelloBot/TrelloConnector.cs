using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Trello.Models;

namespace Trello
{
    public class TrelloConnector : ITrelloConnector
    {
        private HttpClient _httpClient { get; set; }
        private ITrelloOptions _trelloOptions { get; set; }
        public TrelloConnector(ITrelloOptions trelloOptions)
        {
            _httpClient = HttpClientFactory.Create();
            _trelloOptions = trelloOptions;
        }

        public TrelloConnector(IOptions<TrelloOptions> trelloOptions)
        {
            _httpClient = HttpClientFactory.Create();
            _trelloOptions = trelloOptions.Value;
        }

        public async Task<Card> CreateCard(string name, string listId, string description, string labelId)
        {
            var url = new StringBuilder();

            url.Append($"{_trelloOptions.UrlBase}/cards/?");
            url.Append($"key={ _trelloOptions.ApiKey}");
            url.Append($"&token={_trelloOptions.ApiToken}");
            url.Append($"&idList={listId}");
            url.Append($"&name={name}");
            url.Append($"&desc={description}");
            url.Append($"&idLabels={labelId}");

            Card data = null;

            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync<Card>(url.ToString(), new Card());

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var content = httpResponseMessage.Content;
                data = await content.ReadAsAsync<Card>();
            }

            return data;
        }

        public async Task<CheckList> CreateCheckList(string name, string cardId)
        {
            var url = new StringBuilder();

            url.Append($"{_trelloOptions.UrlBase}/cards/{cardId}/checklists?");
            url.Append($"key={_trelloOptions.ApiKey }");
            url.Append($"&token={ _trelloOptions.ApiToken }");
            url.Append($"&name={name}");

            CheckList data = null;

            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync<CheckList>(url.ToString(), new CheckList());

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var content = httpResponseMessage.Content;
                data = await content.ReadAsAsync<CheckList>();
            }

            return data;
        }

        public async Task<CheckListItem> CreateCheckListItem(string name, string checkListId)
        {
            var url = new StringBuilder();

            url.Append($"{_trelloOptions.UrlBase}/checklists/{checkListId}/checkItems?");
            url.Append($"key={_trelloOptions.ApiKey}");
            url.Append($"&token={_trelloOptions.ApiToken}");
            url.Append($"&name={name}");

            CheckListItem data = null;

            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync<CheckListItem>(url.ToString(), new CheckListItem());

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var content = httpResponseMessage.Content;
                data = await content.ReadAsAsync<CheckListItem>();
            }

            return data;
        }

    }
}
