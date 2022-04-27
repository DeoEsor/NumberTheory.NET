using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
		public override byte[] Encrypt(byte[] value, byte[] originalKey)
		{
			var expander = new SimpleExpander(value, _blocksCount).ToList();
			var result = new List<byte[]>();
			
			Parallel.For(0,_blocksCount,
				i => result[i] = _encryptor.Encrypt(expander[i], originalKey));
			
			return result.SelectMany(s => s).ToArray();
		}
		
		public override byte[] Decrypt(byte[] value, byte[] originalKey)
		{
			var expander = new SimpleExpander(value, _blocksCount).ToList();
			var result = new List<byte[]>();
			
			Parallel.For(0,_blocksCount, 
				i => result[i] = _decryptor.Decrypt(expander[i], originalKey) );
			
			return result.SelectMany(s => s).ToArray();
		}
	}
}
