using NumberTheory.Interfaces;

namespace NumberTheory.RandomGenerators;

public abstract class PrimalRandomGenerator : IRandomGenerator
{
    public IPrimalChecker PrimalChecker { get; set; }
    
    protected PrimalRandomGenerator(IPrimalChecker primalChecker)
    {
        PrimalChecker = primalChecker;
    }

    public abstract BigInteger Generate();
}