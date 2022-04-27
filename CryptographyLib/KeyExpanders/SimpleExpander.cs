using System;
using System.Collections.Generic;
using System.Linq;
using CryptographyLib.Interfaces;
// ReSharper disable MemberCanBePrivate.Global
namespace CryptographyLib.KeyExpanders
{
	public class SimpleExpander : BaseExpander
	{
		public readonly int BlockLength;

		public override int RoundsCount => OriginalKey.Length / BlockLength;

		public  static SimpleExpander CreateInstance(byte[] originalKey,int blockLength)
		{
			return new SimpleExpander(originalKey, blockLength);
		}
		
		public SimpleExpander(byte[] originalKey, int blockLength)
			: base(originalKey)
		{
			BlockLength = blockLength;
		}
		protected override IEnumerator<byte[]> GetExpander()
		{
			for (var i = 0; i < OriginalKey.Length / BlockLength; i++)
			{
				yield return 
					OriginalKey
							.Skip(i * BlockLength)
							.Take(BlockLength) 
						as byte[] 
					?? throw new InvalidOperationException();//TODO
			}
		}
	}
}
