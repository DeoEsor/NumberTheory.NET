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
		public static int Encrypt(int value, Func<byte,byte> SBlock, int k)
		{
			var rule = SBlock.CreateKeyByFunc(k);

			int result = 0;

			int i = value.CountOfBites() / 4;

			foreach (var bit in value.GetBytes())
				result |= rule[bit] << i != 1 ? i-- : i;
			
			return result;
		}
		
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

			foreach (var bit in value.GetBytes())
				result |= SBlock[bit] << i != 1 ? i-- : i;
			
			return result;
		}
		
		/// <summary>
		/// Decryption
		/// </summary>
		/// <param name="value">bytes array</param>
		/// <param name="SBlock">Rule for creating SBlock</param>
		/// <param name="k">size of SBlock</param>
		/// <returns>Original bytes array</returns>
		public static int Decrypt(int value, Func<byte,byte> SBlock, int k)
		{
				
			var res
				= SBlock.CreateKeyByFunc(k)
				.GroupBy(p => p.Value)
				.ToDictionary(
					g => g.Key, 
					g => g.Select(pp => pp.Key)
							.First());
			
			return Encrypt(value,res,k);
		}
		
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
	}
}
