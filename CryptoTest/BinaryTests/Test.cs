using CryptographyLib.Extensions;
using NUnit.Framework;
namespace CryptoTest.BinaryTests
{
	public class Test
	{
		[Test]
		public void GetBytesTest()
		{
			var trueresult = new byte[] {1,1,0,0,1,0};

			var result = new byte[50.CountOfBites()];

			int a = 0;

			foreach (var bit4 in 50.GetBits())
				result[a++] = bit4;
			
			Assert.AreEqual(trueresult,result);
		}
		
		[Test]
		public void MaxValuebleBit()
		{
			Assert.AreEqual(64,64.MaxValuableBit());
		}
		
		[Test]
		public void CountOfBitesTest()
		{
			Assert.AreEqual(7,65.CountOfBites());
		}
		
		[Test]
		public void Divide()
		{
			Assert.AreEqual((2,1),
				BinaryExtensions.unsigned_divide((uint)7,(uint)3));
		}
	}
}
