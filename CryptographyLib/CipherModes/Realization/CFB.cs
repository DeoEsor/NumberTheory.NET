using System;
using System.Collections.Generic;
using System.Linq;
using CryptographyLib.Extensions;
using CryptographyLib.Interfaces;
using CryptographyLib.KeyExpanders;
namespace CryptographyLib.CipherModes.Realization
{
	public class CFB : CipherModeBase
	{
		private int _iv;
		private int _blocksCount;
		private int L;

		public CFB(IEncryptor encryptor, int iv, int blocksCount,int l = 8) 
			: base(encryptor, null!)
		{
			if (l is <= 64 and >= 1)
				L = l;
			else 
				l = 8;
			_iv = iv;
			_blocksCount = blocksCount;
		}
		public override byte[] Encrypt(byte[] value, byte[] originalKey)
		{
			var expander = 
				new SimpleExpander(value, value.Length / 4)
					.ToList();

			var result = new List<byte[]>();
			
			byte[] a =BitConverter.GetBytes(_iv);
			foreach (var openBlock in expander)
			{
				var b = BitConverter.GetBytes(_iv >> 64 - L);
				var c = _encryptor.Encrypt(a, originalKey);
				a = a.XorBytes(c);
				result.Add(a);
			}
			
			return result.SelectMany(s => s).ToArray();
		}
		public override byte[] Decrypt(byte[] value, byte[] originalKey)
		{
			throw new System.NotImplementedException();
		}
	}
}
