using NUnit.Framework;
namespace CryptoTest.FeistelNetwork
{
	public class PBlock
	{
		[Test]
		public void PBlockEncrypting()
		{
			Assert.AreEqual(
				37,
				CryptographyLib.FeistelNetwork.
					PBlock.Encrypt(50, new byte[]{5,3,6,1,4,2})
				);
		}
		
		[Test]
		public void PBlockDecripting()
		{
			Assert.AreEqual(
				50,
				CryptographyLib.FeistelNetwork.
					PBlock.Decrypt(
					CryptographyLib.FeistelNetwork.
						PBlock.Encrypt(50, new byte[]{5,3,6,1,4,2}),
					new byte[]{5,3,6,1,4,2}
					)
			);
		}
	}
}
