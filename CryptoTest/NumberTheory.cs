using NumberTheory.Extensions.Arithmetic;
using NUnit.Framework;

namespace CryptoTest;

[TestFixture]
public partial class NumberTheory
{
    [Test]
    public void BinaryDivide()
    {
        Assert.AreEqual((0, 1),
            ArithmeticExtensions.unsigned_divide(1, 2));
    }
    
    [Test]
    public void BinaryPow()
    {
        Assert.AreEqual(25,
            ArithmeticExtensions.Pow(5, 2));
    }
    
    [Test]
    public void Xor()
    {
        Assert.AreEqual(7,
            ArithmeticExtensions.XOR(5, 2));
    }
}