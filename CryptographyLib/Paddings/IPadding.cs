namespace CryptographyLib.Paddings
{
	public interface IPadding
	{
		/// <summary>
		/// Padding byte array
		/// </summary>
		/// <param name="input"></param>
		/// <param name="blockLength"></param>
		/// <returns></returns>
		byte[] ApplyPadding(byte[] input, byte blockLength);
	}
}
