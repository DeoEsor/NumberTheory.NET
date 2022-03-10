using System;
using System.Collections.Generic;
namespace CryptographyLib
{
    /// <summary>
    ///     GF ( 2^8 ), where 2 - field characteristics, 8 - field order
    /// </summary>
	public class FieldGalua : IDisposable
    {
        /// <summary>
        /// vector of irreducible polynoms
        /// </summary>
        List<ushort> ir_poly;
        
        private readonly uint field_charac = 0b10;
        private readonly uint field_order = 0b1000;

        private readonly uint max_even;

        public FieldGalua(uint fieldCharac = 0, uint fieldOrder = 0)
        {
            if (fieldCharac != 0)
                field_charac = fieldCharac;
            if (fieldOrder != 0)
                field_order = fieldOrder;
            max_even = ((uint)Math.Pow(field_charac,field_order)) - field_charac;
            irred_poly();
        }
        
        /// <summary>
        /// vector of irreducible polynoms
        /// </summary>
        public List<ushort> IrrationalPoly
        {
            get => ir_poly;
            set => ir_poly = value;
        }

        /// <summary>
        /// Getting product of polis
        /// </summary>
        /// <param name="a"> - first poly</param>
        /// <param name="b"> - second poly</param>
        /// <param name="modulo"> - module over the ring</param>
        /// <returns>polynom</returns>
        public ushort multiply(ushort a, ushort b, ushort modulo) 
        {
        
            ushort result = 0;  ushort iter=1;

            for (uint i = 0; i < field_order; i++) 
                result ^= (ushort)( a * (b & (iter <<= (ushort)1)));
        
            return remnant(result, modulo);
        }
        
        /// <summary>
        /// Getting sum of polis
        /// </summary>
        /// <param name="a"> first poly</param>
        /// <param name="b"> second poly</param>
        /// <returns>result polynom</returns>
        static byte add(byte a, byte b) => (byte)(a ^ b);
        
        /// <summary>
        /// Getting
        /// </summary>
        /// <param name="poly">Polynom</param>
        /// <returns>Col of non zero a * x^p / degree of polynom :333</returns>
        static uint degree(ushort poly)
        {
            uint res=0;

            for (; poly > 0; poly >>= 0b1)  
                if ((poly & 0b1) == 0b1) 
                    res++;
            
            return res;
        }
        
        /// <summary>
        /// getting remnant of poly by module
        /// </summary>
        /// <param name="poly">Polynom</param>
        /// <param name="module">Module over the ring</param>
        /// <returns>Remnant of poly by module</returns>
        static byte remnant(ushort poly, ushort module) 
        {
            uint module_count = degree(module);
            uint diff = 0;

            while ((diff = degree(poly) - module_count) >= 0)  
                poly = (ushort)(poly ^ module << (int) diff);
        
            return (byte) poly;
        }
        
        /// <summary>
        /// Method for getting inverse of the required polynom
        /// </summary>
        /// <param name="poly">the required polynom</param>
        /// <param name="modulo">Module over the ring</param>
        /// <returns> polynom </returns>
        ushort get_inverse(byte poly, ushort modulo)
        {

            byte copy_poly = poly;
            uint degree_pow = degree((ushort)max_even);
            byte bit = (byte)max_even;

            for (uint i = degree_pow; i >= 0; i--, bit >>= 1)
            {
                if ((modulo & bit) == 1)   
                    poly = (byte)multiply(poly, copy_poly, modulo);
            
                poly = (byte)multiply(poly, poly, modulo);
            
            }
            return poly;
        }
    
        /// <summary>
        /// Calling in constructor
        ///
        /// pushing in vector first 30 irreducible polynoms
        /// </summary>
        void irred_poly()
        {
            uint i = 0;
            for (ushort number = 0b100000000; number <= 0b111111111; number +=2) 
            {
                if (i == 30) return;
                int null_remannts = 0;

                for (byte j = 0b10; j < 0b100000; j++)
                    if (~remnant(number, j) == 1) 
                        break;
                    else 
                        null_remannts++;

                if (null_remannts != 0)
                {
                    IrrationalPoly.Add(number);
                    i++;
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="poly">polynom thats should be checked on irreducibility</param>
        /// <returns> true if poltnom is irreducible, false else </returns>
        static bool if_irreducible(ushort poly)
        {
            uint counter = 0;
            ushort bit = 0b1;
            uint _degree = degree(poly);

            for (uint i = 0; i <= _degree; i++, bit <<= 1)
                if ((bit & poly) == 0b1) 
                    counter++;
            
            return ((counter & 0b1) & counter) == 0b1;
        }
        public void Dispose()
        {
            IrrationalPoly.Clear();
            GC.SuppressFinalize(this);
        }
    }
} 