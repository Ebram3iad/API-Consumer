using System.Web;
using System.Web.Mvc;

namespace Day_2_API_Consumer_Lab
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
