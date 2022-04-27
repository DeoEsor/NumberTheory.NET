using System;
using NumberTheory.Euclid;
namespace NumberTheory.Symbols
{
	public static class Jacobi
	{
		
		public static int J(int a, int b)
		{
			if (b <= 1 || b % 2 == 0 || GCD.Solve(a, b) != 1) return 0;
			var r = 1;
			
			if (a >= 0)
				return Solution(a, b, r);
			
			a = -a;
			if (b % 4 == 3)
				r = -r;

			return Solution(a, b, r);
		}

		private static int Solution(int a ,int b, int r)
		{
			var i = 0;
			for (; a % 2 == 0b0; i++)
				a /= 2;

			if (i % 2 == 0 && (b % 8 == 3 || b % 8 == 5))
				r = -r;

			if (a % 4 == 3 && b % 4 == 3)
				r = -r;
			return a != 0 ? Solution(a,b,r) : r;
		}
	}
}
