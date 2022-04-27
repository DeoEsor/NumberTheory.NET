using System.Collections.Generic;
using System.Linq;
using CryptographyLib.Extensions;
using CryptographyLib.Interfaces;
using CryptographyLib.KeyExpanders;
namespace CryptographyLib.CipherModes.Realization
{
	public class CBC : CipherModeBase
	{
		private int _iv;
		private int _blocksCount;

		public CBC(IEncryptor encryptor, IDecryptor decryptor, int iv, int blocksCount) 
			: base(encryptor, decryptor)
		{
			_iv = iv;
			_blocksCount = blocksCount;
		}
		public override byte[] Encrypt(byte[] value, byte[] originalKey)
		{
			var expander = 
				new SimpleExpander(value, value.Length / 4)
				.ToList();
			
			var result = new List<byte[]>();

			foreach (var block in expander)
			{
				byte[]? resultBlock = null;
				var xor = resultBlock == null ? _iv.XorBytes(block) : resultBlock.XorBytes(block);
				resultBlock = _encryptor.Encrypt(xor, originalKey);
				result.Add(resultBlock);
			}

			return result.SelectMany(s => s).ToArray();
		}
		public override byte[] Decrypt(byte[] value, byte[] originalKey)
		{
			var expander = 
				new SimpleExpander(value, value.Length / 4)
					.ToList();
			
			var result = new List<byte[]>();

			foreach (var block in expander)
			{
				byte[]? resultBlock = null;
				var xor = resultBlock == null ? _iv.XorBytes(block) : resultBlock.XorBytes(block);
				resultBlock = _decryptor.Decrypt(xor, originalKey);
				result.Add(resultBlock);
			}

			return result.SelectMany(s => s).ToArray();
		}
	}
}
