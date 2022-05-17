using System.Numerics;
using NumberTheory.Extensions.Arithmetic;
using NumberTheory.Interfaces;

namespace NumberTheory.PrimalCheckers;

public class FermatTest : IPrimalChecker
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="minProbability"></param>
    /// <returns>Is <param name="value"/> can be called pseudo-primal </returns>
    /// <exception cref="NotImplementedException"></exception>
    public bool Check(BigInteger value, float minProbability)
    {
        if (minProbability is not (> 0.49f and < 1))
            throw new ArgumentException(nameof(minProbability));
        if (value <= 0)
            throw new ArgumentException(nameof(value));
        
        if (value <= 3)
            return true;
        var random = new Random();

        for (int i = 0; i < IPrimalChecker.GetDegree(minProbability); i++) // attempts - кол-во попыток, так как тест - вероятностный 
        {
            BigInteger a = random.Next() % (value - 2) + 2;
		
            if (BigInteger.GreatestCommonDivisor(a, value) != 1) // если числа не взаимно просты, то понятно, что p не простое 
                return false;
		
            if (ArithmeticExtensions.PowMod(a, value-1,value) != 1) // a^(p-1) = 1 (mod p)
                return false;
        }

        return true;
    }
}