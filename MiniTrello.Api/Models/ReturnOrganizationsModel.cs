using System.Collections.Generic;
using MiniTrello.Domain.Entities;

namespace MiniTrello.Win8Phone.Models
{
    public class ReturnOrganizationsModel:ReturnModel
    {
        public IList<Organization> Organizations { set; get; }
    }
}