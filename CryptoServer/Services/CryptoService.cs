using CryptoServices;
using Grpc.Core;
namespace CryptoServer.Services
{
	public class CryptoService : CryptoServices.CryptoService.CryptoServiceBase
	{
		private readonly ILogger<CryptoService> _logger;

		public CryptoService(ILogger<CryptoService> logger)
		{
			_logger = logger;
		}

		public override Task<StartSessionReply> Auth(StartSessionRequest request, ServerCallContext context)
		{
			return base.Auth(request, context);
		}

		public override Task<UserGettingReply> GetUsers(UserGettingRequest request, ServerCallContext context)
		{
			return base.GetUsers(request, context);
		}

		public override Task<FinishSessionReply> Quit(FinishSessionRequest request, ServerCallContext context)
		{
			return base.Quit(request, context);
		}

		public override Task SendMessage(IAsyncStreamReader<OpenMessage> requestStream, IServerStreamWriter<OpenMessage> responseStream, ServerCallContext context)
		{
			return base.SendMessage(requestStream, responseStream, context);
		}

		public override Task<StartSessionReply> StartChatting(StartSessionRequest request, ServerCallContext context)
		{
			return base.StartChatting(request, context);
		}
	}
}
