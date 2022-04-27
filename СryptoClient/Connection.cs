using System;
using System.Net.Http;
using CryptoServices;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
namespace СryptoClient
{
	public class Connection
	{
		private readonly ILogger<Connection> _logger;

		public string last_string;
		public Connection(ILogger<Connection> logger = null)
		{
			_logger = logger;

			var httpHandler = new HttpClientHandler();

			httpHandler.ServerCertificateCustomValidationCallback =

				// Return `true` to allow certificates that are untrusted/invalid
				HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
			using var channel = GrpcChannel.ForAddress("https://localhost:5001",
				 new GrpcChannelOptions { HttpHandler = httpHandler });

			var client = new CryptoService.CryptoServiceClient(channel);
			var reply = client.StartSession(new StartSessionRequest());
			if (_logger == null)
				Console.WriteLine(last_string = $"{reply.StatusCode}");
			else
				logger.LogInformation(last_string = $"Connection {reply.StatusCode}");
		}
	}

}