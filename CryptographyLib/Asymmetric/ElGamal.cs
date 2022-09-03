using CryptographyLib.Interfaces;
using CryptographyLib.KeyExpanders;
using CryptographyLib.KeyGenerators;
using NumberTheory.RandomGenerators;


namespace CryptographyLib.Asymmetric;

public class ElGamal : IAsymmetricEncryptor
{
	public AsymmetricKeyGenerator Generator { get; set; }
	
	public IExpandKey ExpandKey { get; set; }
	
	private PrimalRandomGenerator Random { get; set; }
	
	public byte[] Encrypt(byte[] value)
	{
		
	}

	public byte[] Decrypt(byte[] value)
	{
		throw new NotImplementedException();
	}
}