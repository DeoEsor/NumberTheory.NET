using NumberTheory.Interfaces;
using NUnit.Framework;
namespace NumberTheory.RandomGenerators;

public class BruteForcePrimalRandomGenerator : PrimalRandomGenerator
{
    public BruteForcePrimalRandomGenerator(IPrimalChecker primalChecker) 
        : base(primalChecker)
    {}

    public override BigInteger Generate()
    {
        var value = BigInteger.Pow(TestContext.CurrentContext.Random.NextULong(), 2);;
        
        while (!PrimalChecker.Check(value, 0.95f))
            value = BigInteger.Pow(TestContext.CurrentContext.Random.NextULong(), 2);

        return value;
    }
}