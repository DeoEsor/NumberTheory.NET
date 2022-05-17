using CryptographyLib.Interfaces;
using CryptographyLib.KeyExpanders;
// ReSharper disable InconsistentNaming
namespace CryptographyLib.CipherModes.Realization
{
	public class ECB : CipherModeBase
	{
		private int _blocksCount;
		public ECB(IEncryptor encryptor, IDecryptor decryptor, int blocksCount) 
			: base(encryptor, decryptor)
		{
			_blocksCount = 0;
		}
		
		public ECB(ISymmetricEncryptor symmetricEncryptor, int blocksCount) 
			: base(symmetricEncryptor)
		{
			_blocksCount = 0;
		}
		public override byte[] Encrypt(byte[] value)
		{
			var expander = new SimpleExpander(value, _blocksCount).ToList();
			var result = new List<byte[]>();
			
			Parallel.For(0,_blocksCount,
				i => result[i] = _encryptor.Encrypt(expander[i]));
			
			return result.SelectMany(s => s).ToArray();
		}
		
		public override byte[] Decrypt(byte[] value)
		{
			var expander = new SimpleExpander(value, _blocksCount).ToList();
			var result = new List<byte[]>();
			
			Parallel.For(0,_blocksCount, 
				i => result[i] = _decryptor.Decrypt(expander[i]) );
			
			return result.SelectMany(s => s).ToArray();
		}
	}
}
