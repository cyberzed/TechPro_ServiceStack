using ServiceStack.ServiceInterface;

namespace cyberzed.TechPro.ServiceStack_01.Server
{
	public class WelcomeService : Service
	{
		public WelcomeResponse Any(Welcome request)
		{
			return new WelcomeResponse {Message = string.Format("Hello {0}", request.Name.Replace("/"," "))};
		}
	}
}