using CryptographyLib.CipherModes.Realization;
using CryptographyLib.Interfaces;

namespace CryptographyLib.CipherModes;

public static partial class CipherMode
{
    private static CipherModeBase CBC(IEncryptor encryptor, IDecryptor decryptor, object[] values)
    {
        if (values[0] is not int blocksCountCBC || values[1] is not int ivCBC)
            throw new ArgumentException("Failed to read params");

        return new CBC(encryptor, decryptor, ivCBC, blocksCountCBC);
    }

    private static CipherModeBase ECB(IEncryptor encryptor, IDecryptor decryptor, object[] values)
    {
        if (values[0] is not int blocksCountECB)
            throw new ArgumentException("Failed to read params");

        return new ECB(encryptor, decryptor, blocksCountECB);
    }

    private static CipherModeBase CFB(IEncryptor encryptor, IDecryptor decryptor, object[] values)
    {
        if (values[0] is not int blocksCountCFB || values[1] is not int ivCFB || values[2] is not int l)
            throw new ArgumentException("Failed to read params");

        throw new NotImplementedException();
    }

    private static CipherModeBase OFB(IEncryptor encryptor, IDecryptor decryptor, object[] values)
    {
        if (values[0] is not int blocksCountECB)
            throw new ArgumentException("Failed to read params");

        return new ECB(encryptor, decryptor, blocksCountECB);
    }

    private static CipherModeBase CTR(IEncryptor encryptor, IDecryptor decryptor, object[] values)
    {
        if (values[0] is not int blocksCountECB)
            throw new ArgumentException("Failed to read params");

        return new ECB(encryptor, decryptor, blocksCountECB);
    }

    private static CipherModeBase RD(IEncryptor encryptor, IDecryptor decryptor, object[] values)
    {
        if (values[0] is not int blocksCountECB)
            throw new ArgumentException("Failed to read params");

        return new ECB(encryptor, decryptor, blocksCountECB);
    }

    private static CipherModeBase RDH(IEncryptor encryptor, IDecryptor decryptor, object[] values)
    {
        if (values[0] is not int blocksCountECB)
            throw new ArgumentException("Failed to read params");

        return new ECB(encryptor, decryptor, blocksCountECB);
    }
    
    private static CipherModeBase CBC(ISymmetricEncryptor symmetricEncryptor, object[] values)
    {
        if (values[0] is not int blocksCountCBC || values[1] is not int ivCBC)
            throw new ArgumentException("Failed to read params");

        return new CBC(symmetricEncryptor, ivCBC, blocksCountCBC);
    }

    private static CipherModeBase ECB(ISymmetricEncryptor symmetricEncryptor, object[] values)
    {
        if (values[0] is not int blocksCountECB)
            throw new ArgumentException("Failed to read params");

        return new ECB(symmetricEncryptor, blocksCountECB);
    }

    private static CipherModeBase CFB(ISymmetricEncryptor symmetricEncryptor, object[] values)
    {
        if (values[0] is not int blocksCountCFB || values[1] is not int ivCFB || values[2] is not int l)
            throw new ArgumentException("Failed to read params");

        throw new NotImplementedException();
    }

    private static CipherModeBase OFB(ISymmetricEncryptor symmetricEncryptor, object[] values)
    {
        if (values[0] is not int blocksCountECB)
            throw new ArgumentException("Failed to read params");

        return new ECB(symmetricEncryptor, blocksCountECB);
    }

    private static CipherModeBase CTR(ISymmetricEncryptor symmetricEncryptor, object[] values)
    {
        if (values[0] is not int blocksCountECB)
            throw new ArgumentException("Failed to read params");

        return new ECB(symmetricEncryptor, blocksCountECB);
    }

    private static CipherModeBase RD(ISymmetricEncryptor symmetricEncryptor, object[] values)
    {
        if (values[0] is not int blocksCountECB)
            throw new ArgumentException("Failed to read params");

        return new ECB(symmetricEncryptor, blocksCountECB);
    }

    private static CipherModeBase RDH(ISymmetricEncryptor symmetricEncryptor, object[] values)
    {
        if (values[0] is not int blocksCountECB)
            throw new ArgumentException("Failed to read params");

        return new ECB(symmetricEncryptor, blocksCountECB);
    }
}