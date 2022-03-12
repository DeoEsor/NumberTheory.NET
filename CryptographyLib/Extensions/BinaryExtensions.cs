using System;
using System.Collections.Generic;
namespace CryptographyLib.Extensions
{
	public static class BinaryExtensions
	{
		/// <summary>
		/// Returns collection of bits in <paramref name="value"/>
		/// </summary>
		/// <param name="value">array of bytes</param>
		/// <returns>collection of bits</returns>
		public static IEnumerable<byte> GetBits(this int value)
		{
			int z =value.CountOfBites();
			
			while (z-- > 0) 
				yield return value.GetKBit(z);
		}
		
		/// <summary>
		/// Returns collection of bits in <paramref name="value"/>
		/// </summary>
		/// <param name="value">array of bytes</param>
		/// <returns>collection of bits</returns>
		public static IEnumerable<byte[]> GetByteBlocks(this byte[] value)
		{
			//TODO
			yield break;
		}
		
		/// <summary>
		/// Returns collection of bits in <paramref name="value"/>
		/// </summary>
		/// <param name="value">array of bytes</param>
		/// <returns>collection of bits</returns>
		public static IEnumerable<byte> GetBytes(this int value)
		{
			int z =value.CountOfBites() / 4;
			if (z == 0) z = 1;
			while (z-- > 0)
				yield return value.GetKByte(z);
		}
		
		/// <summary>
		/// Get k's bit from <paramref name="value"/>
		/// </summary>
		/// <param name="value">byte(bits) array</param>
		/// <param name="k">position of bit in <paramref name="value"/></param>
		/// <returns>k's bit</returns>
		public static byte GetKBit(this int value, int k)
			=> (byte)((value >> k) & 1);
		
		/// <summary>
		/// Get k's bit from <paramref name="value"/>
		/// </summary>
		/// <param name="value">byte(bits) array</param>
		/// <param name="k">position of bit in <paramref name="value"/></param>
		/// <returns>k's bit</returns>
		public static byte GetKByte(this int value, int k)
			=> (byte)((value >> (k * 4)) & 0b1111);

		/// <summary>
		/// Count of bites in array of bytes
		/// </summary>
		/// <param name="_value">array of bytes</param>
		/// <returns>Count of bites</returns>
		public static int CountOfBites(this int _value) 
			=> Math.ILogB(_value.MaxValuableBit()) + 1;
		
		public static int CountOfBites(this byte _value) 
			=> Math.ILogB(((int)_value).MaxValuableBit()) + 1;
		
		/// <summary>
		/// Returns max valuable bit in array of bytes
		/// </summary>
		/// <param name="_value">array of bytes</param>
		/// <returns>value of bit</returns>
		public static int MaxValuableBit(this int _value)
		{
			var value = _value;
			value |= (value >>  1);
			value |= (value >>  2);
			value |= (value >>  4);
			value |= (value >>  8);
			value |= (value >> 16);
			return value - (value >> 1);
		}
		
		/// <summary>
		/// Binary implementation of divide (unsigned)
		/// </summary>
		/// <param name="dividend"></param>
		/// <param name="divisor"></param>
		/// <returns>
		/// <para>First item - quotient</para> 
		/// <para>Second item - remainder</para>
		/// </returns>
		public static (uint,uint) unsigned_divide(uint dividend, uint divisor)
		{
			uint quotient, remainder; 
			uint t, num_bits;
			uint q = 0, bit = 0, d = 0;
			int i;

			remainder = 0;
			quotient = 0;

			if (divisor == 0)
				return (UInt32.MaxValue, UInt32.MaxValue);

			if (divisor > dividend) 
			{
				remainder = dividend;
				return (quotient, remainder);
			}

			if (divisor == dividend) 
			{
				quotient = 1;
				return (quotient, remainder);
			}

			num_bits = 32;

			while (remainder < divisor) 
			{
				bit = (dividend & 0x80000000) >> 31;
				remainder = (remainder << 1) | bit;
				d = dividend;
				dividend = dividend << 1;
				num_bits--;
			}


			/* The loop, above, always goes one iteration too far.
				To avoid inserting an "if" statement inside the loop
				the last iteration is simply reversed. */

			dividend = d;
			remainder = remainder >> 1;
			num_bits++;

			for (i = 0; i < num_bits; i++) 
			{
				bit = (dividend & 0x80000000) >> 31;
				remainder = (remainder << 1) | bit;
				t = remainder - divisor;
				q = (t >> 31) == 0 ? (uint)1 : 0;
				dividend = dividend << 1;
				quotient = (quotient << 1) | q;
				if ((q & 0b1) == 1) 
					remainder = t;
			}
			return (quotient , remainder);
		}
		public static void signed_divide(int inputLength, byte blockLength)
		{
			throw new NotImplementedException();
		}
	}
}
