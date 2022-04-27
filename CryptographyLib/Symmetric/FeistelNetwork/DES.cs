using System.Diagnostics.CodeAnalysis;
using CryptographyLib.Interfaces;
namespace CryptographyLib.Symmetric.FeistelNetwork
{
	public class DES : SymmetricEncryptorBase
	{

		public DES([NotNull] IExpandKey expandKey, [NotNull] byte[] key)
			: base(expandKey, key)
		{
		}
		public override byte[] Decrypt(byte[] value, byte[] originalKey)
		{
			throw new System.NotImplementedException();
		}
		public override byte[] Encrypt(byte[] value, byte[] originalKey)
		{
			throw new System.NotImplementedException();
		}
		
		protected override byte[] DecryptRound(byte[] value, byte[] roundKey)
		{
			return base.DecryptRound(value, roundKey);
		}
		protected override byte[] EncryptRound(byte[] value, byte[] roundKey)
		{
			return base.EncryptRound(value, roundKey);
		}
	}
}
