using System.Numerics;
using NumberTheory.Extensions.Arithmetic;
using NumberTheory.Interfaces;
using NumberTheory.Symbols;

namespace NumberTheory.PrimalCheckers;

public class Solovay_StrassenTest : IPrimalChecker
{
    public bool Check(BigInteger value, float minProbability)
    {
        if (value < 2)
            return false;
        if (value != 2 && value % 2 == 0)
            return false;
 
        var random = new Random();
        
        for (int i = 0; i < IPrimalChecker.GetDegree(minProbability); i++)
        {
            
            var a = random.Next() % (value - 1) + 1;
            var jacobian = (value + Jacobi.J(a, value)) % value;
            var mod = ArithmeticExtensions.PowMod(a, (value - 1) / 2, value);
 
            if (jacobian == 0 || mod != jacobian)
                return false;
        }
        return true;
    }
}