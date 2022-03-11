using System.Threading.Tasks;
namespace CryptographyLib.Interfaces
{
	/// <summary>
	/// Interface of Strategy Pattern for encryption
	/// </summary>
	public interface IEncryptor
	{
		/// <summary>
		/// Encryption
		/// </summary>
		/// <param name="value">byte array</param>
		/// <param name="key">key</param>
		/// <returns></returns>
		Task<byte[]> Encrypt(byte[] value, byte[] key);
	}
	
	/// <summary>
	/// Interface of Strategy Pattern for encryption
	/// </summary>
	public interface IDecryptor
	{
		/// <summary>
		/// Decryption
		/// </summary>
		/// <param name="value">byte array</param>
		/// <param name="key">key</param>
		/// <returns></returns>
		Task<byte[]> Decrypt(byte[] value, byte[] key);
	}
}
