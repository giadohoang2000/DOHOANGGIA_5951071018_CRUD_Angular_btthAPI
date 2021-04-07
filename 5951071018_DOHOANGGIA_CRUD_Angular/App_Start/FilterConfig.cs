using System.Web;
using System.Web.Mvc;

namespace _5951071018_DOHOANGGIA_CRUD_Angular
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
