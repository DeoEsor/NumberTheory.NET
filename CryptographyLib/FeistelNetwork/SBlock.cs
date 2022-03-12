// ReSharper disable InconsistentNaming
using System;
using System.Collections.Generic;
using System.Linq;
using CryptographyLib.Extensions;
namespace CryptographyLib.FeistelNetwork
{
	/// <summary>
	/// Implementation PBlock with very very slow crypt & encrypting
	/// https://www.youtube.com/watch?v=eAKi_f5Vqzo
	/// </summary>
	public static class SBlock
	{
		/// <summary>
		/// Encryption
		/// </summary>
		/// <param name="value">bytes array</param>
		/// <param name="SBlock">Rule for creating SBlock</param>
		/// <param name="k">size of SBlock</param>
		/// <returns>Encrypted bytes array</returns>
		public static int Encrypt(int value, Dictionary<byte,byte> SBlock, int k)
		{
			int result = 0;

			int i = value.CountOfBites() / 4;

			if (i == 0) i = 1;
			foreach (var bit in value.GetBytes())
				result |= SBlock[bit] << i--;
			
			return result;
		}
		
		/// <inheritdoc cref="Encrypt(int,System.Collections.Generic.Dictionary{byte,byte},int)"/>
		public static byte[] Encrypt(byte[] value, Dictionary<byte,byte> SBlock, int k)
		{
			byte[] result = new byte[value.Length];

			for (int i = 0; i < value.Length; i++)
				result[i]= (byte)(SBlock[value[i]] << i != 1 ? i-- : i);

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
		public static int Decrypt(int value, Dictionary<byte,byte> SBlock, int k)
		{
			var res
				= SBlock
					.GroupBy(p => p.Value)
					.ToDictionary(
						g => g.Key, 
						g => g.Select(pp => pp.Key)
							.First());
			
			return Encrypt(value,res,k);
		}

		/// <inheritdoc cref="Decrypt(int,System.Collections.Generic.Dictionary{byte,byte},int)"/>
		public static int Decrypt(int value, Func<byte, byte> SBlock, int k)
			=> Decrypt(value, SBlock.CreateKeyByFunc(k), k);
		
		/// <inheritdoc cref="Decrypt(int,System.Collections.Generic.Dictionary{byte,byte},int)"/>
		public static byte[] Decrypt(byte[] value, Dictionary<byte,byte> SBlock, int k)
		{ 
			var res
				= SBlock
					.GroupBy(p => p.Value)
					.ToDictionary(
						g => g.Key, 
						g => g.Select(pp => pp.Key)
							.First());
			
			return Encrypt(value,res,k);
		}

		/// <inheritdoc cref="Decrypt(int,System.Collections.Generic.Dictionary{byte,byte},int)"/>
		public static byte[] Decrypt(byte[] value, Func<byte, byte> SBlock, int k)
			=> Decrypt(value, SBlock, k);
	}
}
