using System;
using System.Threading.Tasks;
namespace CryptographyLib.Interfaces
{
	public interface ISymmetricEncryptor : IExpandKey, IEncryptor
	{
		byte[]? Key { get; set; }
		Task<byte[]> IEncryptor.Encrypt(byte[] value, byte[] key)
		{
			throw new NotImplementedException();
		}

		Task<byte[]> Decrypt(byte[] value, byte[] key);

		Task<byte[]>[] IExpandKey.Expand(byte[] key)
		{
			throw new NotImplementedException();
		}
	}
}
