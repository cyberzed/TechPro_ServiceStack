using Funq;
using ServiceStack.WebHost.Endpoints;

namespace cyberzed.TechPro.ServiceStack_01.Server
{
	public class AppHost : AppHostBase
	{
		public AppHost() : base("TechPro ServiceStack Tutorial", typeof (AppHost).Assembly)
		{
		}

		public override void Configure(Container container)
		{
			SetConfig(new EndpointHostConfig
				{
					ServiceStackHandlerFactoryPath = "api"
				});
		}
	}
}