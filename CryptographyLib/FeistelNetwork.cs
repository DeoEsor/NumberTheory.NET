namespace CryptographyLib
{
	public static class FeistelNetwork
	{
		public static class PBlock
		{
			public static int Encrypt(int value, byte[] pBlock)
			{
				int result = 0;
				//6
				for (int i = 0; i < pBlock.Length; i++)
					result |= ((value >> (pBlock.Length - pBlock[i])) & 1) 
						<< (pBlock.Length - i - 1);
				

				return result;
			}
			
			public static int Decrypt(int value, byte[] pBlock)
			{
				//TODO
				return 0;
			}
		}
		
	}
}
