using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;
using CryptographyLib.CipherModes;
using CryptographyLib.Interfaces;
using NumberTheory;
// ReSharper disable InconsistentNaming
namespace CryptographyLib.Symmetric
{
	public sealed class SymmetricEncryptorContext
	{
		private ushort Seed;

		private CipherModeBase Mode;
		private byte[] OriginalKey;
		
		private SymmetricEncryptorContext(CipherMode.Mode mode, 
											ushort seed, 
											ISymmetricEncryptor symmetricEncryptor, 
											byte[] originalKey, params object[] parametrs)
		{
			Mode = CipherMode.CreateInstance(mode, symmetricEncryptor, symmetricEncryptor);
			Seed = seed;
			OriginalKey = originalKey;
		}

		public void Decrypt(byte[] value, out byte[] result)
			=> result = Mode.Decrypt(value, OriginalKey);
		public void Encrypt(byte[] value, out byte[] result)
			=> result = Mode.Encrypt(value, OriginalKey);
		public async Task AsyncEncryptFile(string pathFileInput, string  pathFileOutput)
		{
			if (File.Exists(pathFileOutput)) File.Delete(pathFileOutput);

			var input = new ConcurrentQueue<byte>();
			
			using (BinaryReader reader = new BinaryReader(File.Open(pathFileInput, FileMode.Open)))
				while (reader.PeekChar() > -1)
					input.Enqueue(reader.ReadByte());

			await using BinaryWriter writer = new BinaryWriter(File.Create(pathFileOutput));
			writer.Write(Mode.Encrypt(input.ToArray(), OriginalKey));
		}
		
		public async Task AsyncDecryptFile(string pathFileInput, string  pathFileOutput)
		{
			if (File.Exists(pathFileOutput)) 
				File.Delete(pathFileOutput);

			var input = new ConcurrentQueue<byte>();
			using (BinaryReader reader = new BinaryReader(File.Open(pathFileInput, FileMode.Open)))
				while (reader.PeekChar() > -1)
					input.Enqueue(reader.ReadByte());

			await using (BinaryWriter writer = new BinaryWriter(File.Create(pathFileOutput)))
				writer.Write(Mode.Decrypt(input.ToArray(), OriginalKey));
		}
	}
}
