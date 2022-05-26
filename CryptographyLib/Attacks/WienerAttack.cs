using System.Numerics;
using NumberTheory.Extensions;

namespace CryptographyLib.Attacks;

public class WienerAttack
{

        public List<(BigInteger, BigInteger)> Attack(BigInteger isN, BigInteger isE) 
        {
            var limitD = isN.Sqrt();
            limitD = limitD.Sqrt();
            limitD = limitD/3;
            var _M = 0x01010101;
            
            return BigIntegerExtensions
                .CFRAC(isE, isN)
                .GetConvergent()
                .Where(s =>
                {
                    if (s.Item2 > limitD)
                        return false;
                    var c = BigInteger
                        .ModPow(_M, isE, isN);
                    
                    var m = BigInteger
                        .ModPow(c, s.Item2, isN);

                    return _M == m;

                })
                .ToList();
        }
}