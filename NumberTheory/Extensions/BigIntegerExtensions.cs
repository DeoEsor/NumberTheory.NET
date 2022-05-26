namespace NumberTheory.Extensions;

public static class BigIntegerExtensions
{
    public static BigInteger Sqrt(this BigInteger n)
    {
        if (n == 0) return 0;
        if (n > 0)
        {
            int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
            var root = BigInteger.One << (bitLength / 2);

            while (!isSqrt(n, root))
            {
                root += n / root;
                root /= 2;
            }

            return root;
        }

        throw new ArithmeticException("NaN");
    }

    private static bool isSqrt(BigInteger n, BigInteger root)
    {
        var lowerBound = root*root;
        var upperBound = (root + 1)*(root + 1);

        return (n >= lowerBound && n < upperBound);
    }
    
    public static IEnumerable<(BigInteger,BigInteger)> GetConvergent(this IEnumerable<BigInteger> cf) 
    {
        BigInteger   r = 0, 
            s = 1,
            p = 1, 
            q = 0;
        foreach (var c in cf) 
        {
            var tempP = p;
            var tempQ = q;
            p = c * p + r;
            q = c * q + s;
            r = tempP;
            s = tempQ;

            yield return (p,q);
        }
    }
    
    public static IEnumerable<BigInteger> CFRAC(BigInteger p, BigInteger q) 
    {
        while (q != 0) 
        {
            var n = p / q;
            yield return n;
            var extra = p - q * n;
            p = q;
            q = extra;
        }
    }
}