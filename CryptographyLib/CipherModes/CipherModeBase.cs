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
		
		protected CipherModeBase(ISymmetricEncryptor symmetricEncryptor)
		{
			_encryptor = symmetricEncryptor;
			_decryptor = symmetricEncryptor;
		}
		
		public abstract byte[] Encrypt(byte[] value);
		public abstract byte[] Decrypt(byte[] value);
	}
}
