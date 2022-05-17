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

		#region Constructors

		public CFB(IEncryptor encryptor, IDecryptor decryptor, int iv, int blocksCount, int l = 8)
			: base(encryptor, decryptor)
			=> Init(iv, blocksCount, l);
		
		public CFB(ISymmetricEncryptor encryptor, int iv, int blocksCount,int l = 8) 
			: base(encryptor, encryptor)
			=> Init(iv, blocksCount, l);

		#endregion

		private void Init(int iv, int blocksCount,int l = 8)
		{
			L = l is <= 64 and >= 1 ? l : 8;
			_iv = iv;
			_blocksCount = blocksCount;
		}
		
		public override byte[] Encrypt(byte[] value)
		{
			var expander = 
				new SimpleExpander(value, value.Length / 4)
					.ToList();

			var result = new List<byte[]>();
			
			byte[] a =BitConverter.GetBytes(_iv);
			foreach (var openBlock in expander)
			{
				var b = BitConverter.GetBytes(_iv >> 64 - L);
				var c = _encryptor.Encrypt(a);
				a = a.XorBytes(c);
				result.Add(a);
			}
			
			return result.SelectMany(s => s).ToArray();
		}
		public override byte[] Decrypt(byte[] value)
		{
			var expander = 
				new SimpleExpander(value, value.Length / 4)
					.ToList();

			var result = new List<byte[]>();
			
			byte[] a =BitConverter.GetBytes(_iv);
			foreach (var openBlock in expander)
			{
				var b = BitConverter.GetBytes(_iv >> 64 - L);
				var c = _encryptor.Encrypt(a);
				a = a.XorBytes(c);
				result.Add(a);
			}
			
			return result.SelectMany(s => s).ToArray();
		}
	}
}
