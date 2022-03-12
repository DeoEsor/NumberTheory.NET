using System;
using System.Threading.Tasks;
namespace CryptographyLib.Interfaces
{
	/// <summary>
	/// Interface of Symmetric Encryptor
	/// </summary>
	public interface ISymmetricEncryptor : IExpandKey, IEncryptor , IDecryptor
	{
		/// <summary>
		/// Storage Key
		/// </summary>
		byte[]? Key { get; set; }
		
		Task<byte[]> IEncryptor.Encrypt(byte[] value, byte[] key)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Decryption
		/// </summary>
		/// <param name="value">byte array</param>
		/// <param name="key">Key</param>
		/// <returns></returns>
		Task<byte[]> IDecryptor.Decrypt(byte[] value, byte[] key)
		{
			throw new NotImplementedException();
		}

		Task<byte[]>[] IExpandKey.Expand(byte[] key)
		{
			throw new NotImplementedException();
		}
	}
}
