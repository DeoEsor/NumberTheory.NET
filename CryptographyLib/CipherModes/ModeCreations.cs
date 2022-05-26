using CryptographyLib.CipherModes.Realization;
using CryptographyLib.Interfaces;

namespace CryptographyLib.CipherModes;

public static partial class CipherMode
{
    private static CipherModeBase CBC(ISymmetricEncryptor encryptor, object[] values)
    {
        if (values[0] is not int blocksCountCBC || values[1] is not ulong ivCBC)
            throw new ArgumentException("Failed to read params");

        return new CBC(encryptor, ivCBC, blocksCountCBC);
    }

    private static CipherModeBase ECB(ISymmetricEncryptor encryptor, object[] values)
    {
        if (values[0] is not int blocksCountECB)
            throw new ArgumentException("Failed to read params");

        return new ECB(encryptor, blocksCountECB);
    }

    private static CipherModeBase CFB(ISymmetricEncryptor encryptor, object[] values)
    {
        if (values[0] is not int blocksCountCFB || values[1] is not int ivCFB || values[2] is not int l)
            throw new ArgumentException("Failed to read params");

        throw new NotImplementedException();
    }

    private static CipherModeBase OFB(ISymmetricEncryptor encryptor, object[] values)
    {
        if (values[0] is not int blocksCountECB)
            throw new ArgumentException("Failed to read params");

        return new ECB(encryptor, blocksCountECB);
    }

    private static CipherModeBase CTR(ISymmetricEncryptor encryptor, object[] values)
    {
        if (values[0] is not int blocksCountECB)
            throw new ArgumentException("Failed to read params");

        return new ECB(encryptor, blocksCountECB);
    }

    private static CipherModeBase RD(ISymmetricEncryptor encryptor, object[] values)
    {
        if (values[0] is not int blocksCountECB)
            throw new ArgumentException("Failed to read params");

        return new ECB(encryptor, blocksCountECB);
    }

    private static CipherModeBase RDH(ISymmetricEncryptor encryptor, object[] values)
    {
        if (values[0] is not int blocksCountECB)
            throw new ArgumentException("Failed to read params");

        return new ECB(encryptor, blocksCountECB);
    }
}