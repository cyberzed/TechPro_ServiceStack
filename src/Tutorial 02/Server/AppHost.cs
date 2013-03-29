using Funq;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.WebHost.Endpoints;

namespace cyberzed.TechPro.ServiceStack_02.Server
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

			container.Register<ICacheClient>(new MemoryCacheClient());
		}
	}
}