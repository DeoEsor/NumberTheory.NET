using CryptographyLib;
using NUnit.Framework;

namespace CryptoTest
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void PBlockEncrypting()
		{
			Assert.AreEqual(
				37,
				FeistelNetwork.PBlock.Encrypt(50, new byte[]{5,3,6,1,4,2})
				);
		}
		
		[Test]
		public void PBlockDecripting()
		{
			Assert.AreEqual(
				50,
				FeistelNetwork.PBlock.Decrypt(
					FeistelNetwork.PBlock.Encrypt(50, new byte[]{5,3,6,1,4,2}),
					new byte[]{5,3,6,1,4,2}
					)
			);
		}
	}
}
