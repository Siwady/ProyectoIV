using System.Collections.Generic;
using MiniTrello.Domain.Entities;

namespace MiniTrello.Win8Phone.Models
{
    public class ReturnMembersModel
    {
        public IList<Account> Members { get; set; }
    }
}