using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CryptographyLib.Interfaces;
namespace CryptographyLib
{
	public sealed class SymmetricEncryptor : ISymmetricEncryptor, INotifyCompletion, IAsyncResult
	{
		private static FieldGalua Galua = new FieldGalua();
		private static int Count = 0;
		
		public static SymmetricEncryptor CreateInstance
			(
				Mode mode,
				ushort seed = ushort.MaxValue,
				WaitHandle waitHandle = null,
				params object[] parametrs
			)
		 => 
			new SymmetricEncryptor
			(
				mode,
				seed == ushort.MaxValue? Galua.IrrationalPoly[Count++] : seed, 
				waitHandle, 
				parametrs
			);

		private SymmetricEncryptor(Mode mode, ushort seed, WaitHandle asyncWaitHandle, params object[] parametrs)
		{
			SelectedMode = mode;
			AsyncWaitHandle = asyncWaitHandle;
		}
		
		private byte[]? _key;
		public byte[]? Key
		{
			get => _key;
			set => _key = value;
		}
		
		public enum Mode : byte { ECB, CBC, CFB, OFB, CTR, RD, RD_H }

		private Mode SelectedMode;

		private ushort Seed;
			
		public Task<byte[]>[] Expand(byte[] key)
		{
			throw new System.NotImplementedException();
		}

		public Task<byte[]> Encrypt(byte[] value, byte[] key)
		{
			throw new System.NotImplementedException();
		}

		public Task<byte[]> Decrypt(byte[] value, byte[] key)
		{
			throw new System.NotImplementedException();
		}
		
		public void OnCompleted(Action continuation) => continuation?.Invoke();
		
		public object? AsyncState
		{
			get;
		}
		public WaitHandle AsyncWaitHandle
		{
			get;
		}
		public bool CompletedSynchronously
		{
			get;
		}
		public bool IsCompleted
		{
			get;
		}
	}
}
