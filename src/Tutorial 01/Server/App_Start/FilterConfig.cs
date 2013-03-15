using System.Web.Mvc;

namespace cyberzed.TechPro.ServiceStack_01.Server.App_Start
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}