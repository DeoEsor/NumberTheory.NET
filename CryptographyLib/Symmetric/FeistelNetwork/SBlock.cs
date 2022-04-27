// ReSharper disable InconsistentNaming
using CryptographyLib.Extensions;
using CryptographyLib.Interfaces;
namespace CryptographyLib.Symmetric.FeistelNetwork
{
	/// <summary>
	/// Implementation PBlock with very very slow crypt & encrypting
	/// https://www.youtube.com/watch?v=eAKi_f5Vqzo
	/// </summary>
	public class SBlock : IEncryptor
	{
		/// <summary>
		/// Encryption
		/// </summary>
		/// <param name="value">bytes array</param>
		/// <param name="SBlock">Rule for creating SBlock</param>
		/// <param name="k">size of SBlock</param>
		/// <returns>Encrypted bytes array</returns>
		public static int Encrypt(int value, Dictionary<byte, byte> SBlock, int k)
		{
			var i = value.CountOfBites() / 4;

			if (i == 0) i = 1;

			return value.GetBytes().Aggregate(0, (current, bit) => current | SBlock[bit] << i--);
		}

		/// <inheritdoc cref="Encrypt(int,System.Collections.Generic.Dictionary{byte,byte},int)"/>
		public static byte[] Encrypt(byte[] value, Dictionary<byte, byte> SBlock, int k)
		{
			var result = new byte[value.Length];

			for (var i = 0; i < value.Length; i++)
				result[i] = (byte)(SBlock[value[i]] << i != 1 ? i-- : i);

			return result;
		}

		public static byte[] Encrypt(byte[] value, byte[] key)
		{
			var result = new byte[value.Length];

			for (var i = 0; i < value.Length; i++)
				result[i] = (byte)(value[value[i]] << i != 1 ? i-- : i);

			return result;
		}

		/// <inheritdoc cref="Encrypt(int,System.Collections.Generic.Dictionary{byte,byte},int)"/>
		public static int Encrypt(int value, Func<byte, byte> SBlock, int k)
			=> Encrypt(value, SBlock.CreateKeyByFunc(k), k);

		/// <inheritdoc cref="Encrypt(int,System.Collections.Generic.Dictionary{byte,byte},int)"/>
		public static byte[] Encrypt(byte[] value, Func<byte, byte> SBlock, int k)
			=> Encrypt(value, SBlock.CreateKeyByFunc(k), k);

		/// <summary>
		/// Decryption
		/// </summary>
		/// <param name="value">bytes array</param>
		/// <param name="SBlock">Rule for creating SBlock</param>
		/// <param name="k">size of SBlock</param>
		/// <returns>Original bytes array</returns>
		public static byte[] Decrypt(byte[] value, Func<byte, byte> SBlock, int k)
			=> Decrypt(value, SBlock.CreateKeyByFunc(k), k);

		/// <inheritdoc cref="Decrypt(byte[],System.Collections.Generic.Dictionary{byte,byte},int)"/>
		public static byte[] Decrypt(byte[] value, Dictionary<byte, byte> SBlock, int k)
		{
			var res
				= SBlock
					.GroupBy(p => p.Value)
					.ToDictionary(
						g => g.Key,
						g => g.Select(pp => pp.Key)
							.First());

			return Encrypt(value, res, k);
		}

		byte[] IEncryptor.Encrypt(byte[] value, byte[] originalKey)
		{
			return Encrypt(value, originalKey);
		}
	}
}
