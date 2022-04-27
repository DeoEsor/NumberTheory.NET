using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using CryptographyLib.Interfaces;
using CryptographyLib.KeyExpanders;
using CryptographyLib.Symmetric.FeistelNetwork;
namespace CryptographyLib.Symmetric.SPNetwork
{
	public class SPNetwork : SymmetricEncryptorBase
	{
		public SPNetwork(IExpandKey expandKey, byte[] key) 
			: base(expandKey, key) {}

		public override byte[] Encrypt(byte[] value, byte[] originalKey)
		{
			ExpandKey.OriginalKey = originalKey;
			foreach (var roundKey in ExpandKey)
				value = EncryptRound(value, roundKey);
			return value;
		}
		public override byte[] Decrypt(byte[] value, byte[] originalKey)
		{
			ExpandKey.OriginalKey = originalKey;
			foreach (var roundKey in ExpandKey)
				value = DecryptRound(value, roundKey);
			return value;
		}
		
		protected override byte[] DecryptRound(byte[] value, byte[] roundKey)
		{
			var expandValue = new SimpleExpander(value, 4);
			List<byte> sblockRes = new List<byte>();
			
			foreach (byte[] partValue in expandValue)
				sblockRes.AddRange( SBlock.Encrypt(partValue, roundKey));

			var a = PBlock.Decrypt(BitConverter.ToInt32(sblockRes.ToArray()), roundKey);
			return a;
		}
		protected override byte[] EncryptRound(byte[] value, byte[] roundKey)
		{
			var expandValue =new SimpleExpander(value, 4);
			List<byte> sblockRes = new List<byte>();
			
			foreach (byte[] partValue in expandValue)
				sblockRes.AddRange( SBlock.Encrypt(partValue, roundKey));

			var a = PBlock.Encrypt(BitConverter.ToInt32(sblockRes.ToArray()), roundKey);
			return a;
		}
		
	}
}
