using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LiteDB;

namespace CryptoServer.Core;

public class Chat
{
    [Key]
    public int Id { get; set; }
    public int ChatId { get; set; }
    public int UserId { get; set; }
    public byte[] SecretKey { get; set; }
}