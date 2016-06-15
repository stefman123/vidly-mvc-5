using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // redirects a user when a action produces an error
            filters.Add(new HandleErrorAttribute());
            //global authantication
            filters.Add(new AuthorizeAttribute());

            //stop from accessing website using http
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
