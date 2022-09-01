using LH.GestaoDePessoas.CrossCutting.MvcFilters;
using System.Web.Mvc;

namespace LH.GestaoDePessoas.UI.Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalErrorHandler());
        }
    }
}
