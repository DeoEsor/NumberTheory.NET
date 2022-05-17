using System.Collections;

namespace CryptographyLib.Extensions;

public static class BitArrayExtensions
{
    public static byte[] ToBytes(this BitArray bitArray)
    {
        var res = new byte[bitArray.Length / 8 + 1];
        
        bitArray.CopyTo(res,0);

        return res;
    }
}