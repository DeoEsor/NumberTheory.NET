﻿using NumberTheory.Extensions;
using NumberTheory.Extensions.Arithmetic;
namespace CryptographyLib.Paddings
{
	public class X923 : IPadding
	{
		public byte[] ApplyPadding(byte[] input, byte blockLength)
		{
			var reqPadding= ArithmeticExtensions.
				unsigned_divide((uint)input.Length, blockLength)
				.Item2;
			if (reqPadding == 0)
				return input;
			byte[] res = new byte[input.Length + reqPadding];

			for (var i = 0; i < input.Length; i++)
				res[i] = input[i];

			for (var i = 0; i < reqPadding - 1; i++)
				res[input.Length + i] = 0;
			
			res[input.Length + reqPadding - 1] = (byte)reqPadding;
			
			return res;
		}
	}
}
