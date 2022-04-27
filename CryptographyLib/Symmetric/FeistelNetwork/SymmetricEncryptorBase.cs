using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CryptographyLib.Interfaces;
namespace CryptographyLib.Symmetric.FeistelNetwork
{
	public abstract class SymmetricEncryptorBase : ISymmetricEncryptor
	{
		private byte[] _key;
		private IExpandKey _expandKey;
		
		protected SymmetricEncryptorBase(IExpandKey expandKey, byte[] key)
		{
			_expandKey = expandKey;
			_key = key;
		}

		public byte[] Key
		{
			get => _key;
			set
			{
				_key = value;
				OnPropertyChanged();
			}
		}
		public IExpandKey ExpandKey
		{
			get => _expandKey;
			set
			{
				_expandKey = value;
				OnPropertyChanged();
			}
		}

		protected virtual byte[] EncryptRound(byte[] value, byte[] roundKey)
		{
			throw new NotImplementedException();
		}
		
		/// <inheritdoc />
		public abstract byte[] Encrypt(byte[] value, byte[] originalKey);
		
		protected virtual byte[] DecryptRound(byte[] value, byte[] roundKey)
		{
			throw new NotImplementedException();
		}
		/// <inheritdoc />
		public abstract byte[] Decrypt(byte[] value, byte[] originalKey);

		public event PropertyChangedEventHandler? PropertyChanged;

		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
