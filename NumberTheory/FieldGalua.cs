using System;
using System.Collections.Generic;
namespace NumberTheory
{
    /// <summary>
    ///     GF ( 2^8 ), where 2 - field characteristics, 8 - field order
    /// </summary>
	public sealed class FieldGalua : IDisposable
    {
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
} 