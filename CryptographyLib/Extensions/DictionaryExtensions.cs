namespace CryptographyLib.Extensions;

public static class DictionaryExtensions
{
    public static byte[] ConvertToByte(this Dictionary<byte,byte> dict)
    {
        var result = new byte[dict.Count];

        foreach (var pair in dict)
            result[pair.Key] = pair.Value;

        return result;
    }
    
    public static Dictionary<byte,byte> ConvertToDict(this byte[] array)
    {
        var result = new Dictionary<byte, byte>();

        for (byte i = 0; i < array.Length; i++)
            result.Add(i, array[i]);
            

        return result;
    }
}