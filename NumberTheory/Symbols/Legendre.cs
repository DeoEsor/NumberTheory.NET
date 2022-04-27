using System;
namespace NumberTheory.Symbols
{
	public static class Legendre
	{
		public static int L(int a, int p)
		{
			if (a == 1) return 1;
			if (a % 2 == 0)
				return (int)(L(a / 2, p) 
					* Math.Pow(-1, (Math.Pow(p, 2) - 1) / 8));
			
			return (int)(L(p % a, a) *
				Math.Pow(-1, (a - 1) * ((p - 1) / 4)));
		}
	}
}
