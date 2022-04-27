using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using CryptoServices;
using StatusCode = CryptoServices.StatusCode;
namespace CryptoServer
{
	public class CryptoService : CryptoServices.CryptoService.CryptoServiceBase
	{
		private readonly ILogger<CryptoService> _logger;

		public CryptoService(ILogger<CryptoService> logger)
		{
			_logger = logger;
		}
		
		public override Task<StartSessionReply> StartSession(StartSessionRequest request,
															ServerCallContext context)
		{
			_logger.LogInformation($"Key: {request.Key} is created with {context.Peer}");
			return Task.FromResult(new StartSessionReply() 
			{
				StatusCode = StatusCode.Accepted
			});
		}


		public override Task<OpenMessage> EncryptFile(OpenMessage request, ServerCallContext context)
		{
			_logger.LogInformation($"Message: {request.Mes} encrypted for {context.Peer}");
			return Task.FromResult(new OpenMessage() 
			{
				Mes = request.Mes //TODO
			});
		}
	}
}
