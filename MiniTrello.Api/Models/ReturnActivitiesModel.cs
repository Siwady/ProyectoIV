using System.Collections;
using System.Collections.Generic;
using MiniTrello.Domain.Entities;

namespace MiniTrello.Win8Phone.Models
{
    public class ReturnActivitiesModel:ReturnModel
    {
        public IList<Activity> Activities { get; set; }
    }
}