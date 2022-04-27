namespace NumberTheory.Extensions.Arithmetic
{
	public static partial class ArithmeticExtensions
	{
		/// <summary>
		/// Binary exponentiation
		/// </summary>
		/// <param name="a">Base</param>
		/// <param name="n">Power</param>
		/// <returns>a ^ n</returns>
		/// <remarks>Complexity O(log( <paramref name="n"/> ))</remarks>
		public static int Pow(int a, int n) 
		{
			int res = 1;
			while (n != 0)
			{
				if ((n & 0b1) == 1)
					res *= a;
				a *= a;
				n >>= 1;
			}
			return res;
		}
	}
}
