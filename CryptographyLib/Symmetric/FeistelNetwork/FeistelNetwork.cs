using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CryptographyLib.Extensions;
using CryptographyLib.Interfaces;
using CryptographyLib.Paddings;
namespace CryptographyLib.Symmetric.FeistelNetwork
{
	/// <summary>
	/// 
	/// </summary>
	public class FeistelNetwork : SymmetricEncryptorBase
	{
		private ISymmetricEncryptor Encryptor;
		public int Rounds
		{
			get;
			set;
		}
		private IPadding Padding = new PKCS7();

		public FeistelNetwork(  [NotNull] IExpandKey expandKey,
								ISymmetricEncryptor symmetricEncryptor,
								[NotNull] byte[] key)
			: base(expandKey, key)
		{
			Encryptor = symmetricEncryptor;
			Rounds = ExpandKey.RoundsCount;
		}
		
		
		public override byte[] Encrypt(byte[] value, byte[] originalKey)
		{
			value = Padding.ApplyPadding(value, 4);
			byte[] L = value.Take(value.Length / 2).ToArray(), 
				   R = value.TakeLast(value.Length / 2).ToArray();
			var roundKeys = ExpandKey.ToList();
			
			for (var i = 0; i < Rounds - 1; i++)
			{
				R = R.XorBytes(Encryptor.Encrypt(L, originalKey));
				(L, R) = (R, L);
			}
			R = R.XorBytes(Encryptor.Encrypt(L,roundKeys[Rounds - 1]));
			var res = L.ToList();
			res.AddRange(R); 
			return res.ToArray();
		}
		
		public override byte[] Decrypt(byte[] value, byte[] originalKey)
		{
			value = Padding.ApplyPadding(value, 4);
			byte[]  L = value.Take(value.Length / 2).ToArray(), 
					R = value.TakeLast(value.Length / 2).ToArray();
			var roundKeys = ExpandKey.ToList();
			
			for (var i = Rounds - 1; i > 0; i++)
			{
				R = R.XorBytes(Encryptor.Decrypt(L,roundKeys[i]));
				(L, R) = (R, L);
			}
			
			R = R.XorBytes(Encryptor.Decrypt(L,roundKeys[0]));
			var res = L.ToList();
			res.AddRange(R); 
			return res.ToArray();
		}
	}
}
