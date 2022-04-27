﻿// ReSharper disable InconsistentNaming
using System;
using NumberTheory.Extensions;
using NumberTheory.Extensions.Arithmetic;
namespace CryptographyLib.Paddings
{
	public class ISO_10126 : IPadding
	{
		public byte[] ApplyPadding(byte[] input, byte blockLength)
		{
			var random = new Random();
			var reqPadding= ArithmeticExtensions.
				unsigned_divide((uint)input.Length, blockLength)
				.Item2;
			if (reqPadding == 0)
				return input;
			byte[] res = new byte[input.Length + reqPadding];

			for (var i = 0; i < input.Length; i++)
				res[i] = input[i];

			for (var i = 0; i < reqPadding - 1; i++)
				res[input.Length + i] = (byte)random.Next(0, 15);
			
			res[input.Length + reqPadding - 1] = (byte)reqPadding;
			
			return res;
		}
	}
}