using System.Numerics;
using CryptographyLib.Data;
using CryptographyLib.Interfaces;
using CryptographyLib.KeyExpanders;
using CryptographyLib.KeyGenerators;

namespace CryptographyLib.Asymmetric.RSA;

public class RSA : IAsymmetricEncryptor
{
    public AsymmetricKeyGenerator Generator { get; set; }
    public IExpandKey ExpandKey { get; set; }

    public RSA(IExpandKey expandKey, RSAKeyGenerator generator = null!)
    {
        ExpandKey = expandKey;
        
        Generator = generator 
                    ?? new RSAKeyGenerator(65537);
    }
    
    public byte[] Encrypt(byte[] value)
    {
        var text = new BigInteger(value);
        var key = Generator.GenerateKeys();
        var nums = Key.GetBigInts(key.PublicKey);

        var e = nums[0];
        
        var n = nums[1];

        return BigInteger
            .ModPow(text,e,n)
            .ToByteArray();
    }

    public byte[] Decrypt(byte[] value)
    {
        var text = new BigInteger(value);
        var key = Generator.GenerateKeys();
        var nums = Key.GetBigInts(key.PrivateKey);

        var d = nums[0];
        
        var n = nums[1];

        return BigInteger
            .ModPow(text,d,n)
            .ToByteArray();
    }

}