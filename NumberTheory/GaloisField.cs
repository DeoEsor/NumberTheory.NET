// ReSharper disable NonReadonlyMemberInGetHashCode
namespace NumberTheory
{
    /// <summary>
    ///     GF ( 2^8 ), where 2 - field characteristics, 8 - field order
    /// </summary>
	public sealed class GaloisField
    {
        private const int Order = 256;
        
        //irreducible polynomial used : x^8 + x^4 + x^3 + x^2 + 1 (0x11D)
        private const int Polynomial = 0x11D;
        
        //generator to be used in Exp & Log table generation
        private const byte Generator = 0x2;

        private static readonly byte[] Exp;

        private static readonly byte[] Log;

        private byte Value { get; set; }

        public GaloisField() => Value = 0;

        public GaloisField(byte value) => Value = value;

        //generates Exp & Log table for ast multiplication operator
        static GaloisField()
        {
            Exp = new byte[Order];
            Log = new byte[Order];

            byte val = 0x01;
            
            for(var i=0; i<Order; i++)
            {
                Exp[i] = val;
                if (i < Order - 1)
                    Log[val] = (byte)i;
                
                val = Multiply(Generator,val);
            }
        }

        //operators
        public static explicit operator GaloisField(byte b)
        {
            var f = new GaloisField(b);
            return f;
        }

        public static explicit operator byte(GaloisField f) => f.Value;

        public static GaloisField operator+ (GaloisField a, GaloisField b) => new GaloisField((byte)(a.Value ^ b.Value));

        public static GaloisField operator- (GaloisField a, GaloisField b) => new GaloisField((byte)(a.Value ^ b.Value));

        public static GaloisField operator* (GaloisField a, GaloisField b)
        {
            var result = new GaloisField(0);

            if (a.Value == 0 || b.Value == 0) return result;
            
            var bres = (byte)((Log[a.Value] + Log[b.Value]) % (Order-1));
            bres = Exp[bres];
            result.Value = bres;
            return result;
        }

        public static GaloisField operator/ (GaloisField a, GaloisField b)
        {
            if (b.Value == 0)
                throw new ArgumentException("Divisor cannot be 0", nameof(b));

            var result = new GaloisField(0);

            if (a.Value == 0) return result;
            
            var bres = (byte)((Order - 1 + Log[a.Value] - Log[b.Value]) % (Order-1));
            bres = Exp[bres];
            result.Value = bres;
            
            return result;
        }

        public static GaloisField Pow(GaloisField f, byte exp)
        {
            var fres = new GaloisField(1);
            for (byte i = 0; i < exp; i++)
                fres *= f;
            
            return fres;
        }

        public static bool operator== (GaloisField a, GaloisField b) => a.Value == b.Value;

        public static bool operator !=(GaloisField a, GaloisField b) => a.Value != b.Value;

        public override bool Equals(object? obj)
        {
            if (obj is not GaloisField field)
                return false;
            
            return Value == field.Value;
        }

        public override int GetHashCode() => Value;

        public override string ToString() => Value.ToString();

        /// <summary>
        /// Multiplication method which is only used in Exp & Log table generation
        /// Implemented with Russian Peasant Multiplication algorithm
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static byte Multiply(byte a, byte b) 
        {
            byte result = 0;
            var aa = a;
            var bb = b;
            while (bb != 0)
            {
                if ((bb & 1) != 0)
                    result ^= aa;
                
                var highestBit = (byte)(aa & 0x80);
                
                aa <<= 1;
                
                if (highestBit != 0)
                    aa ^= (Polynomial & 0xFF);
                
                bb >>= 1;
            }
            return result;
        }
    }
} 