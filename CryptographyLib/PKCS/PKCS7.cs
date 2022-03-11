using CryptographyLib.Extensions;
namespace CryptographyLib.PKCS
{
	/// <summary>
	/// https://datatracker.ietf.org/doc/html/rfc3369
	/// </summary>
	public class PKCS7
	{
		/// <summary>
		/// Padding byte array in format of PKCS7
		/// https://ru.wikipedia.org/wiki/Дополнение_(криптография)#PKCS7
		/// </summary>
		/// <param name="input"></param>
		/// <param name="blockLength"></param>
		/// <returns></returns>
		public static byte[] ApplyPadding(byte[] input, byte blockLength)
		{
			var reqPadding= BinaryExtensions.
				unsigned_divide((uint)input.Length, blockLength).
				Item2;
			if (reqPadding == 0)
				return input;
			byte[] res = new byte[input.Length + reqPadding];

			for (int i = 0; i < input.Length; i++)
				res[i] = input[i];

			for (int i = 0; i < reqPadding; i++)
				res[input.Length + i] = (byte)reqPadding;
			
			return res;
		}
	}
}
