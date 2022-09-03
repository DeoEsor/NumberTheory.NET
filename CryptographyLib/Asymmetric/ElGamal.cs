using System.Numerics;
using CryptographyLib.Data;
using CryptographyLib.Interfaces;
using CryptographyLib.KeyExpanders;
using CryptographyLib.KeyGenerators;
using NumberTheory.Extensions;
using NumberTheory.PrimalCheckers;
using NumberTheory.RandomGenerators;


namespace CryptographyLib.Asymmetric;

public class ElGamal : IAsymmetricEncryptor
{
	public AsymmetricKeyGenerator Generator { get; set; } = new ElGamalKeyGenerator();

	public IExpandKey ExpandKey { get; set; }
	
	private PrimalRandomGenerator Random { get; set; } = new BruteForcePrimalRandomGenerator( new MillerRabinTest());
	
	private Key Key { get; set; }
	
	public byte[] Encrypt(byte[] value)
	{
		var nums = Key.GetBigInts(Key.PublicKey);
		BigInteger y = nums[0], g = nums[1], p = nums[2]; 
		var M = new BigInteger(value);

		var k = Random.Generate(1, p - 1);

		while (BigInteger.GreatestCommonDivisor(k, p-1) != 1)
			k = Random.Generate(1, p - 1);

		var a = BigInteger.ModPow(g , k , p);
		var b = (BigIntegerExtensions.Pow(y, k ) * M) % p ;

		return Key.SerializeBigInts(new[] { a, b });
	}

	public byte[] Decrypt(byte[] value)
	{
		var nums = Key.GetBigInts(value);
		var p = Key.GetBigInts(Key.PublicKey)[2];
		var x = Key.GetBigInts(Key.PrivateKey)[0];
		BigInteger a = nums[0], b = nums[1];

		var m = BigInteger
			        .Multiply(a, BigIntegerExtensions.Pow(a, p - 1 - x)) 
		        % p;

		return m
			.ToByteArray();
	}
}