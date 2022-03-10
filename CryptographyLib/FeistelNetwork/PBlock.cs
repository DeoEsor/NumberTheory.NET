namespace CryptographyLib.FeistelNetwork
{
	/// <summary>
	/// Implementation PBlock with crypt & encrypting
	/// https://www.youtube.com/watch?v=eAKi_f5Vqzo
	/// </summary>
	public static class PBlock
	{
		/// <summary>
		/// Encryption of <value> with <para>pBlock</para> as P-Box 
		/// </summary>
		/// <param name="value">value to encrypt</param>
		/// <param name="pBlock">P-Box</param>
		/// <returns>encrypted value</returns>
		public static int Encrypt(int value, byte[] pBlock)
		{
			int result = 0;
			
			for (int i = 0; i < pBlock.Length; i++)
				result |= ((value >> (pBlock.Length - pBlock[i])) & 1) 
					<< (pBlock.Length - i - 1);
			
			return result;
		}
		
		/// <summary>
		/// Decryption of <value> with <para>pBlock</para> as P-Box 
		/// </summary>
		/// <param name="value">encrypted value</param>
		/// <param name="pBlock">P-Box</param>
		/// <returns>primal value</returns>
		public static int Decrypt(int value, byte[] pBlock)
		{
			int result = 0;
			
			for (int i = 0; i < pBlock.Length; i++)
				result |= ((value >> (pBlock.Length - i - 1)) & 1) 
					<< (pBlock.Length - pBlock[i]);

			return result;
		}
		
	}
}
