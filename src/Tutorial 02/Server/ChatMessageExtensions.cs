using System.Collections.Generic;

namespace cyberzed.TechPro.ServiceStack_02.Server
{
	internal static class ChatMessageExtensions
	{
		public static ChatMessageResponse ToResponse(this ChatMessage message)
		{
			return new ChatMessageResponse {Messages = new List<ChatMessage>(new[] {message})};
		}
	}
}