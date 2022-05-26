using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace CryptoServer.Core;

public class Files
{
    public int Id { get; set; }
    public byte[] File { get; set; }
}