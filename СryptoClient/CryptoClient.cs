using System;
using System.Net.Http;
using System.Text;
using CryptoServices;
using Google.Protobuf;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
namespace СryptoClient;

public class CryptoClient : IDisposable
{
	private readonly ILogger<CryptoClient> _logger;
	private readonly CryptoService.CryptoServiceClient client;
	private readonly GrpcChannel Channel;
	
	public CryptoClient(ILogger<CryptoClient> logger = null)
	{
		_logger = logger;

		var httpHandler = new HttpClientHandler();

		httpHandler.ServerCertificateCustomValidationCallback =
			HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
		
		Channel  =
			GrpcChannel
				.ForAddress("https://localhost:7173", new GrpcChannelOptions { HttpHandler = httpHandler });

		client = new CryptoService.CryptoServiceClient(Channel);
	}

	public StartSessionReply Auth(string Username, string Password)
	{
		var request = new StartSessionRequest
		{
			Username = Username,
			Password = ByteString.CopyFromUtf8(Password)
		};
		return client.Auth(request);
	}
	
	public async Task<StartSessionReply> AuthAsync(string Username, string Password, CancellationToken token = default)
	{
		var request = new StartSessionRequest
		{
			Username = Username,
			Password = ByteString.CopyFromUtf8(Password)
		};
		return await client.AuthAsync(request,null,null,token);
	}
	
	public async Task<StartSessionReply> Register(string Username, string Password)
	{
		var request = new StartSessionRequest
		{
			Username = Username,
			Password = ByteString.CopyFromUtf8(Password)
		};
		return await client.RegisterAsync(request);
	}

	public AsyncUnaryCall<StartChattingReply> StartChattingAsync(ulong id)
	{
		var request = new StartChattingRequest()
		{
			TargetId = id
		};
		return client.StartChattingAsync(request);
	}

	public async Task SendMessage(
		Grpc.Core.IAsyncStreamReader<OpenMessage> requestStream,
		Grpc.Core.IServerStreamWriter<OpenMessage> responseStream,
		Grpc.Core.ServerCallContext context)
	{
		while (await requestStream.MoveNext())
		{
			var note = requestStream.Current;
			/*List<OpenMessage> prevNotes = AddNoteForLocation(note.Location, note);
			foreach (var prevNote in prevNotes)
			{
				await responseStream.WriteAsync(prevNote);
			}
			*/
		}
	}

	public async Task<List<User>> GetUsersAsync()
	{
		var reply =await client.GetUsersAsync(new UserGettingRequest());
		return reply.Users.ToList();
	}

	public void Quit(string Username, string Password)
	{
		client.Quit(new FinishSessionRequest
		{
			Username = Username,
			Password = ByteString.CopyFromUtf8(Password)
		});
	}

	public void Dispose()
	{
		Channel.Dispose();
	}
}
