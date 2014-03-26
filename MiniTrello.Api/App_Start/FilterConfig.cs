using System.Web;
using System.Web.Mvc;

namespace MiniTrello.Win8Phone
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}