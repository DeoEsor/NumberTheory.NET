using CryptoServer.Interfaces;
using CryptoServices;
using Grpc.Core;
using StatusCode = CryptoServices.StatusCode;
using User = CryptoServer.Core.User;

namespace CryptoServer.Services;

public partial class CryptoService
{
    public override async Task<StartSessionReply> Register(StartSessionRequest request, ServerCallContext context)
    {
        var reply = new StartSessionReply
        {
            StatusCode = StatusCode.Accepted
        };
        try
        {
            var random = new Random();
            _logger.LogInformation($"Getted to register {request.Username}");
            if (((IRepository<User>)Db).GetDataList().FirstOrDefault(s => s.Username == request.Username) != null)
            {
                reply.StatusCode = StatusCode.WrongLogin;
                reply.Comment = "Login reserved";
                _logger.LogInformation($"Same user already registrated");
                return reply;
            }

            Db.AddData(new User
            {
                Username = request.Username,
                Password = request.Password.ToStringUtf8(),
                Color = String.Format("#{0:X6}", random.Next(0x1000000)),
                IsOnline = true
            });
            var user = ((IRepository<User>)Db)
                .GetDataList()
                .FirstOrDefault(user => user.Username == request.Username);
            if (user == null)
            {
                reply.StatusCode = StatusCode.NotAccepted;
                reply.Comment = "Wrong login or password";
                return reply;
            }

            reply.User = new CryptoServices.User
            {
                Id = (ulong)user.Id,
                Name = user.Username,
                Password = user.Password,
                Color = user.Color,
                ImageSource = user.ImageSource ?? ""
            };
            return reply;
        }
        catch(Exception e)
        {
            _logger.LogCritical($"{e.Message}");
            reply.StatusCode = StatusCode.NotAccepted;
            return reply;
        }
        finally
        {
            
        }
    }
}