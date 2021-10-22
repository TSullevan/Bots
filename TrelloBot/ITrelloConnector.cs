using System.Threading.Tasks;
using Trello.Models;

namespace Trello
{
    public interface ITrelloConnector
    {
        Task<Card> CreateCard(string name, string listId, string description, string label);
        Task<CheckList> CreateCheckList(string name, string cardId);
        Task<CheckListItem> CreateCheckListItem(string name, string checkListId);
    }
}
