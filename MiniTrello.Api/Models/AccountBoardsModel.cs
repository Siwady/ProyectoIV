using MiniTrello.Win8Phone.Controllers;

namespace MiniTrello.Win8Phone.Models
{
    public class AccountBoardsModel:ReturnModel
    {
        public string Title;
        public bool IsArchived { get; set; }
    }
}