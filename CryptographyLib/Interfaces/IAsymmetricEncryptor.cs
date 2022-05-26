using CryptographyLib.KeyExpanders;
using CryptographyLib.KeyGenerators;

namespace CryptographyLib.Interfaces;

public interface IAsymmetricEncryptor : IEncryptor, IDecryptor
{
    AsymmetricKeyGenerator Generator { get; set; }
    
    IExpandKey ExpandKey { get; set; }
}