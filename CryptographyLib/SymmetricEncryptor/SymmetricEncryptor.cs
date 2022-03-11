using System;
using System.Collections.Concurrent;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CryptographyLib.FeistelNetwork;
using CryptographyLib.Interfaces;
// ReSharper disable InconsistentNaming
namespace CryptographyLib
{
	public sealed class SymmetricEncryptorContext
	{
		#region Variables and Properties
		public enum Mode : byte { ECB, CBC, CFB, OFB, CTR, RD, RD_H }
		
		private static FieldGalua Galua = new FieldGalua();
		private static int Count = 0;
		
		private byte[]? _key;

		private Mode _selectedMode;

		private ushort Seed;

		private ISymmetricEncryptor SymmetricEncryptor;
		
		public Mode SelectedMode
		{
			get => _selectedMode;
			set
			{
				_selectedMode = value; 
			}
		}
		public byte[]? Key
		{
			get => _key;
			set
			{
				_key = value; 
			}
		}
  #endregion


		#region Factories Methods for crypto algos
		public static SymmetricEncryptorContext CreateDESInstance
		(
			Mode mode,
			ushort seed = ushort.MaxValue,
			params object[] parametrs
		)
		{
			return new SymmetricEncryptorContext
			(
				mode,
				seed == ushort.MaxValue ? Galua.IrrationalPoly[Count++] : seed,
				parametrs
			)
			{
				SymmetricEncryptor = new DES()
			};
		}
  #endregion

		#region Constructor
		private SymmetricEncryptorContext(Mode mode, ushort seed, params object[] parametrs)
		{
			SelectedMode = mode;
			Seed = seed;
		}
  #endregion

		#region Byte arrays logic
		public void Decrypt(byte[] value, out byte[] result)
		{
			//TODO Parallel? Async normal code :3
			// TODO Separate byte arrays on blocks with flags/marks of end/nextbyte and parallel it
			result = SymmetricEncryptor.Decrypt(value, Key!).Result;
		}
		public void Encrypt(byte[] value, out byte[] result)
		{
			//TODO Parallel? Async normal code :3
			// TODO Separate byte arrays on blocks with flags/marks of end/nextbyte and parallel it
			result = SymmetricEncryptor.Encrypt(value, Key!).Result;
		}
		#endregion
		
		#region File logic
		public void Encrypt(string pathFileInput, string  pathFileOutput)
		{
			//TODO Parallel
			if (File.Exists(pathFileOutput)) File.Delete(pathFileOutput);

			var input = new ConcurrentQueue<byte>();
			
			using (BinaryReader reader = new BinaryReader(File.Open(pathFileInput, FileMode.Open)))
				while (reader.PeekChar() > -1)
					input.Enqueue(reader.ReadByte());
			
			// TODO Separate byte arrays on blocks with flags/marks of end/nextbyte and parallel it
			using (BinaryWriter writer = new BinaryWriter(File.Create(pathFileOutput)))
				writer.Write(SymmetricEncryptor.Encrypt(input.ToArray(), Key).Result);
		}
		
		public void Decrypt(string pathFileInput, string  pathFileOutput)
		{
			//TODO Parallel
			if (File.Exists(pathFileOutput)) File.Delete(pathFileOutput);

			var input = new ConcurrentQueue<byte>();
			
			using (BinaryReader reader = new BinaryReader(File.Open(pathFileInput, FileMode.Open)))
				while (reader.PeekChar() > -1)
					input.Enqueue(reader.ReadByte());
			
			// TODO Separate byte arrays on blocks with flags/marks of end/nextbyte and parallel it
			using (BinaryWriter writer = new BinaryWriter(File.Create(pathFileOutput)))
				writer.Write(SymmetricEncryptor.Decrypt(input.ToArray(), Key).Result);
		}
  #endregion
	}
}
