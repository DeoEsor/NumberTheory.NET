using System.Collections;
using CryptographyLib.Interfaces;
using CryptographyLib.KeyExpanders;

namespace CryptographyLib.Symmetric.FeistelNetwork
{
	public class DES : ISymmetricEncryptor
	{
		public IExpandKey ExpandKey { get; }

		public byte[] Encrypt(byte[] value)
		{
			throw new NotImplementedException();
		}

		public BitArray Encrypt(BitArray value)
		{
			throw new NotImplementedException();
		}

		public byte[] Decrypt(byte[] value)
		{
			throw new NotImplementedException();
		}

		public BitArray Decrypt(BitArray value)
		{
			throw new NotImplementedException();
		}
	}
}
