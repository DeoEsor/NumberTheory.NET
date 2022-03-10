using System.Threading.Tasks;
namespace CryptographyLib.Interfaces
{
	public interface IExpandKey
	{
		Task<byte[]>[] Expand(byte[] key);
	}
}
