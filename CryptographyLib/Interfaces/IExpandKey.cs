using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptographyLib.Extensions;
using CryptographyLib.Paddings;
namespace CryptographyLib.Interfaces
{
	/// <summary>
	/// Interface for Strategy Pattern for key expander
	/// </summary>
	public interface IExpandKey : IEnumerable<byte[]>
	{
		public byte[] OriginalKey { get; set; }
		int  RoundsCount
		{
			get;
		}
	}
}
