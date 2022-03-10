using System.Threading.Tasks;
namespace CryptographyLib.Interfaces
{
	public interface IEncryptor
	{
		Task<byte[]> Encrypt(byte[] value, byte[] key);
	}
}
