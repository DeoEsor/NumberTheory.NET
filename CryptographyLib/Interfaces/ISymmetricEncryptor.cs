using System;
using System.ComponentModel;
using System.Threading.Tasks;
namespace CryptographyLib.Interfaces
{
	/// <summary>
	/// Interface of Symmetric Encryptor
	/// </summary>
	public interface ISymmetricEncryptor : IEncryptor, IDecryptor, INotifyPropertyChanged
	{
		/// <summary>
		/// Storage Key
		/// </summary>
		byte[] Key { get; set; }
		
		/// <summary>
		/// Rule of getting round keys
		/// </summary>
		IExpandKey ExpandKey { get; set; }
		
		/// <inheritdoc />
		abstract byte[] IEncryptor.Encrypt(byte[] value, byte[] key);


		/// <inheritdoc />
		abstract byte[] IDecryptor.Decrypt(byte[] value, byte[] key);
	}
}
