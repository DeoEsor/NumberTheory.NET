using System.Threading.Tasks;
using CryptographyLib.Interfaces;
namespace CryptographyLib.CipherModes
{
	public abstract class CipherModeBase : IEncryptor, IDecryptor
	{
		protected IEncryptor _encryptor;
		protected IDecryptor _decryptor;
		
		protected CipherModeBase(IEncryptor encryptor, IDecryptor decryptor)
		{
			_encryptor = encryptor;
			_decryptor = decryptor;
		}
		public abstract byte[] Encrypt(byte[] value, byte[] originalKey);
		public abstract byte[] Decrypt(byte[] value, byte[] originalKey);
	}
}
