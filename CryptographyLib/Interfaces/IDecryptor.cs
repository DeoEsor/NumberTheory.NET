namespace CryptographyLib.Interfaces
{
	/// <summary>
	/// Interface for decryptor
	/// </summary>
	public interface IDecryptor
	{
		/// <summary>
		/// Decryption
		/// </summary>
		/// <param name="value">Closed text</param>
		/// <param name="originalKey">key</param>
		/// <returns>Open text</returns>
		byte[] Decrypt(byte[] value, byte[] originalKey);
	}
}
