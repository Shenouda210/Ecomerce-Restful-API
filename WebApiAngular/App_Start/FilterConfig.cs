using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace WebApiAngular
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
   
            filters.Add(new HandleErrorAttribute());
        }
    }
}
