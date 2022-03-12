using System;
using NUnit.Framework;
namespace CryptoTest.FeistelNetwork
{
	public class SBlock
	{

		private Func<byte, byte> SBlockRule = b => (byte)((3 * b + 7) % 16);
		
		[Test]
		public void SBlockEncrypting()
		{
			Assert.AreEqual(
				11,
				CryptographyLib.FeistelNetwork.SBlock.Encrypt(12, SBlockRule, 255)
				);
		}
		
		[Test]
		public void SBlockDecripting()
		{
			Assert.AreEqual(
				1,
				CryptographyLib.FeistelNetwork.SBlock.Decrypt(
					CryptographyLib.FeistelNetwork.SBlock.Encrypt(1, SBlockRule, 255),
					SBlockRule,
					255
					)
			);
		}
	}
}
