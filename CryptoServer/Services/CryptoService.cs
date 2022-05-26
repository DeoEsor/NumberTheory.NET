using System.Text;
using CryptoServer.DBContexts;
using CryptoServer.Interfaces;
using CryptoServices;
using Google.Protobuf;
using Grpc.Core;
using StatusCode = CryptoServices.StatusCode;
using User = CryptoServer.Core.User;

namespace CryptoServer.Services
{
	public partial class CryptoService : CryptoServices.CryptoService.CryptoServiceBase
	{
		private readonly ILogger<CryptoService> _logger;

		private readonly Repository Db;

		public CryptoService(ILogger<CryptoService> logger, Repository db)
		{
			_logger = logger;
			Db = db;
		}


		public override Task<UserGettingReply> GetUsers(UserGettingRequest request, ServerCallContext context)
		{
			return base.GetUsers(request, context);
		}
		
		public override Task<StartSessionReply> Auth(StartSessionRequest request, ServerCallContext context)
		{
			var reply = new StartSessionReply
			{
				StatusCode = StatusCode.Accepted
			};
			var user = Db.ChangeStatus(request.Username, request.Password.ToStringUtf8(), true);
			if (user == null)
			{
				reply.StatusCode = StatusCode.NotAccepted;
				reply.Comment = "Wrong login or password";
				return Task.FromResult(reply);
			}

			reply.User = new CryptoServices.User
			{
				Id = (ulong)user.Id,
				Name = user.Username,
				Password = user.Password,
				Color = user.Color,
				ImageSource = user.ImageSource ?? ""
			};
			return Task.FromResult(reply);
		}

		public override Task<FinishSessionReply> Quit(FinishSessionRequest request, ServerCallContext context)
		{
			Db.ChangeStatus(request.Username,request.Password.ToStringUtf8(), false);
			return Task.FromResult(new FinishSessionReply());
		}

		public override Task SendMessage(IAsyncStreamReader<OpenMessage> requestStream, IServerStreamWriter<OpenMessage> responseStream, ServerCallContext context)
		{
			return base.SendMessage(requestStream, responseStream, context);
		}

		public override Task<StartChattingReply> StartChatting(StartChattingRequest request, ServerCallContext context)
		{
			return base.StartChatting(request, context);
		}
	}
}
