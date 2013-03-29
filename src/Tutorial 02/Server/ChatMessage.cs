using ServiceStack.ServiceHost;

namespace cyberzed.TechPro.ServiceStack_02.Server
{
	[Route("/messages", "POST")]
	[Route("/messages/{Id}", "GET,PUT,DELETE")]
	[Route("/messages/mailbox/{Receiver}", "GET")]
	public class ChatMessage
	{
		public int Id { get; set; }
		public string Receiver { get; set; }
		public string Sender { get; set; }
		public string Message { get; set; }
	}
}