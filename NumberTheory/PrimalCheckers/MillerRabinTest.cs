using System.Numerics;
using NumberTheory.Extensions.Arithmetic;
using NumberTheory.Interfaces;
using NumberTheory.Symbols;

namespace NumberTheory.PrimalCheckers;

public class MillerRabinTest : IPrimalChecker
{
    private void GetComponents(BigInteger value, out BigInteger d, out BigInteger s)
    {
        s = 0;
        d = value - 1;
        while (d % 2 != 1)
        {
            d /= 2;
            s++;
        }
    }
    public bool Check(BigInteger value, float minProbability)
    {
        var isPrime = true;
        var random = new Random();
        
        GetComponents(value, out var d, out var s);
        
        Parallel.For(0, IPrimalChecker.GetDegree(minProbability),(i, parallelState) =>
        {
            var a = BigInteger.ModPow(random.Next(), d, value);
            if (a == 1 || a == value - 1) return;
            for (var r = 1; r<s;r++)
                if ((a = BigInteger.ModPow(a,2,value)) == value - 1) return;

            isPrime = false;
            parallelState.Break();
        });

        return isPrime;
    }
}