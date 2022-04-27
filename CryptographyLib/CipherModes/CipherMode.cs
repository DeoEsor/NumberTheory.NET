// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable InconsistentNaming
using System;
using CryptographyLib.CipherModes.Realization;
using CryptographyLib.Interfaces;
namespace CryptographyLib.CipherModes
{
	public class CipherMode
	{
		public enum Mode : byte { ECB,  CBC, CFB, OFB, CTR, RD, RDH }
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="mode">Cipher mode</param>
		/// <param name="symmetricEncryptor"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="NotImplementedException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static CipherModeBase CreateInstance(Mode mode, IEncryptor encryptor, IDecryptor decryptor, params object[] values)
		{
			switch (mode)
			{
				case Mode.ECB:
					if (values[0] is not int blocksCountECB)
						throw new ArgumentException("Failed to read params");
					
					return new ECB(encryptor, decryptor, blocksCountECB);
				case Mode.CBC:
					if (values[0] is not int blocksCountCBC || values[1] is not int ivCBC) 
						throw new ArgumentException("Failed to read params");
					
					return new CBC(encryptor, decryptor, ivCBC, blocksCountCBC);
				case Mode.CFB:
					if (values[0] is not int blocksCountCFB || values[1] is not int ivCFB || values[2] is not  int l)
						throw new ArgumentException("Failed to read params");
					
					throw new NotImplementedException();
				case Mode.OFB:
					throw new NotImplementedException();
				case Mode.CTR:
					throw new NotImplementedException();
				case Mode.RD:
					throw new NotImplementedException();
				case Mode.RDH:
					throw new NotImplementedException();
				default:
					throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
			}
		}
		
		

	}
}
