using CryptographyLib.Interfaces;

namespace CryptographyLib.KeyGenerators;

public abstract class AsymmetricKeyGenerator 
{
    public IKeyGenerator PublicKeyGenerator { get; set; }
    public IKeyGenerator PrivateKeyGenerator { get; set; }
    
    public AsymmetricKeyGenerator(IKeyGenerator privateKeyGenerator, IKeyGenerator publicKeyGenerator)
    {
        PrivateKeyGenerator = privateKeyGenerator;
        PublicKeyGenerator = publicKeyGenerator;
    }

    public virtual byte[] CreatePublicKey(params object[] value) => PublicKeyGenerator.Generate();

    public virtual byte[] CreatePrivateKey(params object[] value)=> PrivateKeyGenerator.Generate();
}