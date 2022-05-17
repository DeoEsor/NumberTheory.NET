using System.Collections;
using System.Diagnostics.CodeAnalysis;
using CryptographyLib.Extensions;
using CryptographyLib.Interfaces;
using CryptographyLib.KeyExpanders;
using CryptographyLib.Paddings;
namespace CryptographyLib.Symmetric.FeistelNetwork
{
	/// <summary>
	/// 
	/// </summary>
	public class FeistelNetwork : SymmetricEncryptorBase
	{
		private readonly ISymmetricEncryptor _encryptor;
		public int Rounds
		{
			get;
			set;
		}
		private IPadding Padding = new PKCS7();

		public FeistelNetwork(  IExpandKey expandKey,
								ISymmetricEncryptor symmetricEncryptor)
			: base(expandKey)
		{
			_encryptor = symmetricEncryptor;
			Rounds = ExpandKey.RoundsCount;
		}

		public override byte[] Encrypt(byte[] value)
		{
			value = Padding.ApplyPadding(value, 4);
			BitArray l = new BitArray(Enumerable.Take(value, value.Length / 2).ToArray()), 
				   r = new BitArray(Enumerable.TakeLast(value, value.Length / 2).ToArray());

			for (var i = 0; i < Rounds - 1; i++)
			{
				r = r.Xor(new BitArray(_encryptor.Encrypt(l.ToBytes())));
				(l, r) = (r, l);
			}
			r = r.Xor(new BitArray(_encryptor.Encrypt(l.ToBytes())));
			byte[] res = new byte[r.Length / 8 + 1];
			r.CopyTo(res,0);
			return res.ToArray();
		}

		public override byte[] Decrypt(byte[] value)
		{
			value = Padding.ApplyPadding(value, 4);
			byte[]  l = Enumerable.Take(value, value.Length / 2).ToArray(), 
					r = Enumerable.TakeLast(value, value.Length / 2).ToArray();

			for (var i = Rounds - 1; i > 0; i++)
			{
				r = r.XorBytes(_encryptor.Decrypt(l));
				(l, r) = (r, l);
			}
			
			r = r.XorBytes(_encryptor.Decrypt(l));
			var res = l.ToList();
			res.AddRange(r); 
			return res.ToArray();
		}
	}
}
