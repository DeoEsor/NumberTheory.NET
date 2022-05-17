using CryptographyLib.Interfaces;
namespace CryptographyLib.CipherModes.Realization
{
	public class OFB : CipherModeBase
	{

		public OFB(IEncryptor encryptor, IDecryptor decryptor) 
			: base(encryptor, decryptor)
		{}

		public override byte[] Encrypt(byte[] value)
		{
			throw new NotImplementedException();
		}

		public override byte[] Decrypt(byte[] value)
		{
			throw new NotImplementedException();
		}
	}
}
