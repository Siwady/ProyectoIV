using System.Collections.Generic;
using MiniTrello.Domain.Entities;

namespace MiniTrello.Win8Phone.Models
{
    public class ReturnBoardsModel: ReturnModel
    {
        public IList<Board> Boards { get; set; }
    }
}