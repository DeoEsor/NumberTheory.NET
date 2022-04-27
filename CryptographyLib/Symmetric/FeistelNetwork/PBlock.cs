using System;
using CryptographyLib.Extensions;
using CryptographyLib.Interfaces;
namespace CryptographyLib.Symmetric.FeistelNetwork
{
	/// <summary>
	/// Implementation PBlock with crypt & encrypting
	/// https://www.youtube.com/watch?v=eAKi_f5Vqzo
	/// </summary>
	public class PBlock : IEncryptor, IDecryptor
	{
		/// <summary>
		/// Encryption of <paramref name="value"/> with <paramref name="value"/> as P-Box 
		/// </summary>
		/// <param name="value">value to encrypt</param>
		/// <param name="pBlock">P-Box</param>
		/// <returns>encrypted value</returns>
		public static byte[] Encrypt(int value, byte[] pBlock)
		{
			var result = 0;
			
			for (var i = 0; i < 16; i++)
				result |= 
					value.GetKBit(pBlock.Length - pBlock[i]) 
					<< (pBlock.Length - i - 1);
			
			return BitConverter.GetBytes(result);
		}
		
		/// <summary>
		/// Decryption of <paramref name="value"/> with <paramref name="value"/> as P-Box 
		/// </summary>
		/// <param name="value">encrypted value</param>
		/// <param name="pBlock">P-Box</param>
		/// <returns>primal value</returns>
		public static byte[] Decrypt(int value, byte[] pBlock)
		{
			var result = 0;
			
			for (var i = 0; i < 16; i++)
				result |= 
					value.GetKBit(pBlock.Length - i - 1) 
					<< (pBlock.Length - pBlock[i]);

			return BitConverter.GetBytes(result);
		}
		public byte[] Encrypt(byte[] value, byte[] originalKey)
			=> Encrypt(BitConverter.ToInt16(value), originalKey);
		public byte[] Decrypt(byte[] value, byte[] originalKey)
			=> Decrypt(BitConverter.ToInt16(value), originalKey);
	}
}
