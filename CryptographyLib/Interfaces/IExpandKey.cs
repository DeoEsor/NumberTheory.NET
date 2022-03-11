using System.Threading.Tasks;
namespace CryptographyLib.Interfaces
{
	/// <summary>
	/// Interface for Strategy Pattern for key expander
	/// </summary>
	public interface IExpandKey
	{
		/// <summary>
		/// Expanding key
		/// </summary>
		/// <param name="key">Key</param>
		/// <returns></returns>
		Task<byte[]>[] Expand(byte[] key);
	}
}
