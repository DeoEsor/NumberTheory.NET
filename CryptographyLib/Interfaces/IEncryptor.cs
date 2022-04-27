﻿using System.Threading.Tasks;
namespace CryptographyLib.Interfaces
{
	/// <summary>
	/// Interface for encryption
	/// </summary>
	public interface IEncryptor
	{
		/// <summary>
		/// Encryption
		/// </summary>
		/// <param name="value">Open text</param>
		/// <param name="originalKey">key</param>
		/// <returns>Closed text</returns>
		byte[] Encrypt(byte[] value, byte[] originalKey);
	}

}
