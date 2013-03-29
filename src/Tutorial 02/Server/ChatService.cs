using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ServiceStack.Common.Web;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Cors;

namespace cyberzed.TechPro.ServiceStack_02.Server
{
	public class ChatService : Service
	{
		private static readonly List<ChatMessage> messages = new List<ChatMessage>();
		private static readonly IdGenerator idGenerator = new IdGenerator();

		public ChatMessageResponse Get(ChatMessage request)
		{
			if (request == null) throw new ArgumentNullException("request");

			if (request.Id != default(int))
			{
				var message = messages.SingleOrDefault(cm => cm.Id == request.Id);

				return message.ToResponse();
			}

			if (!string.IsNullOrEmpty(request.Receiver))
			{
				var msgs = messages.FindAll(cm => cm.Receiver.Equals(request.Receiver, StringComparison.OrdinalIgnoreCase));

				return new ChatMessageResponse {Messages = new List<ChatMessage>(msgs)};
			}

			var defaultMessage = new ChatMessage {Message = "Server is quite confused by your request."};

			return defaultMessage.ToResponse();
		}

		public ChatMessageResponse Post(ChatMessage request)
		{
			if (request == null) throw new ArgumentNullException("request");

			request.Id = idGenerator.Next();

			messages.Add(request);

			return request.ToResponse();
		}

		public ChatMessageResponse Put(ChatMessage request)
		{
			if (request == null) throw new ArgumentNullException("request");

			if (request.Id == default(int))
				throw new ArgumentException("Can not update without an Id");

			messages.RemoveAll(cm => cm.Id == request.Id);

			messages.Add(request);

			return request.ToResponse();
		}

		public object Delete(ChatMessage request)
		{
			if (request == null) throw new ArgumentNullException("request");

			if (request.Id == default(int))
				throw new ArgumentException("Can not delete without an Id");

			messages.RemoveAll(cm => cm.Id == request.Id);

			return new HttpResult(HttpStatusCode.OK);
		}

		[EnableCors("http://www.tech.pro", "GET,OPTIONS")]
		public void Options(ChatMessage request)
		{
		}
	}
}