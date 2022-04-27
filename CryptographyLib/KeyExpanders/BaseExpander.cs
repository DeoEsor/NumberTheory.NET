using System.Collections;
using System.Collections.Generic;
using CryptographyLib.Interfaces;
using CryptographyLib.Paddings;
// ReSharper disable MemberCanBePrivate.Global
namespace CryptographyLib.KeyExpanders
{
	public abstract class BaseExpander : IExpandKey
	{
		private byte[] _originalKey;
		protected IPadding Padding; 

		protected BaseExpander(byte[] originalKey, IPadding padding = null!)
		{
			_originalKey = originalKey;
			Padding = padding;
		}

		IEnumerator<byte[]> IEnumerable<byte[]>.GetEnumerator()
			=> GetExpander();

		public IEnumerator GetEnumerator() => GetExpander();
		
		protected abstract IEnumerator<byte[]> GetExpander();
		public byte[] OriginalKey
		{
			get => _originalKey;
			set => _originalKey = value;
		}
		public abstract int RoundsCount
		{
			get;
		}
	}
}
