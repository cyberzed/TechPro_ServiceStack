using System;
using System.IO;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;

namespace cyberzed.TechPro.ServiceStack_02.Server
{
	public class CsvFormatter
	{
		private const string CsvFormatContentType = "text/csv";

		public static void Register(IAppHost appHost)
		{
			appHost.ContentTypeFilters.Register(CsvFormatContentType, SerializeToStream, (t, s) => { throw new NotImplementedException(); });
		}

		private static void SerializeToStream(IRequestContext requestcontext, object dto, Stream outputstream)
		{
			var response = dto as ChatMessageResponse;

			if (response != null)
			{
				using (var writer = new StreamWriter(outputstream))
				{
					foreach (var message in response.Messages)
					{
						writer.WriteLine("{0};{1};{2};{3}", message.Id, message.Sender, message.Receiver, message.Message);
					}
				}
			}
		}
	}
}