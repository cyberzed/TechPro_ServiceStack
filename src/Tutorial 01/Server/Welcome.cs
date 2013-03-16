using ServiceStack.ServiceHost;

namespace cyberzed.TechPro.ServiceStack_01.Server
{
	[Route("welcome")]
	[Route("welcome/{Name*}")]
	public class Welcome
	{
		public string Name { get; set; }
	}
}