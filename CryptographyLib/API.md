<a name='assembly'></a>
# CryptographyLib

## Contents

- [ArithmeticExtensions](#T-CryptographyLib-Extensions-ArithmeticExtensions 'CryptographyLib.Extensions.ArithmeticExtensions')
  - [unsigned_divide(dividend,divisor)](#M-CryptographyLib-Extensions-ArithmeticExtensions-unsigned_divide-System-UInt32,System-UInt32- 'CryptographyLib.Extensions.ArithmeticExtensions.unsigned_divide(System.UInt32,System.UInt32)')
- [BinaryExtensions](#T-CryptographyLib-Extensions-BinaryExtensions 'CryptographyLib.Extensions.BinaryExtensions')
  - [Pow(a,n)](#M-CryptographyLib-Extensions-BinaryExtensions-Pow-System-Int32,System-Int32- 'CryptographyLib.Extensions.BinaryExtensions.Pow(System.Int32,System.Int32)')
- [ByteExtensions](#T-CryptographyLib-Extensions-ByteExtensions 'CryptographyLib.Extensions.ByteExtensions')
  - [CountOfBites(_value)](#M-CryptographyLib-Extensions-ByteExtensions-CountOfBites-System-Int32- 'CryptographyLib.Extensions.ByteExtensions.CountOfBites(System.Int32)')
  - [GetBits(value)](#M-CryptographyLib-Extensions-ByteExtensions-GetBits-System-Int32- 'CryptographyLib.Extensions.ByteExtensions.GetBits(System.Int32)')
  - [GetByteBlocks(value,BlockLength)](#M-CryptographyLib-Extensions-ByteExtensions-GetByteBlocks-System-Byte[],System-Int32- 'CryptographyLib.Extensions.ByteExtensions.GetByteBlocks(System.Byte[],System.Int32)')
  - [GetBytes(value)](#M-CryptographyLib-Extensions-ByteExtensions-GetBytes-System-Int32- 'CryptographyLib.Extensions.ByteExtensions.GetBytes(System.Int32)')
  - [GetKBit(value,k)](#M-CryptographyLib-Extensions-ByteExtensions-GetKBit-System-Int32,System-Int32- 'CryptographyLib.Extensions.ByteExtensions.GetKBit(System.Int32,System.Int32)')
  - [GetKByte(value,k)](#M-CryptographyLib-Extensions-ByteExtensions-GetKByte-System-Int32,System-Int32- 'CryptographyLib.Extensions.ByteExtensions.GetKByte(System.Int32,System.Int32)')
  - [MaxValuableBit(_value)](#M-CryptographyLib-Extensions-ByteExtensions-MaxValuableBit-System-Int32- 'CryptographyLib.Extensions.ByteExtensions.MaxValuableBit(System.Int32)')
- [EulerExtensions](#T-CryptographyLib-Extensions-EulerExtensions 'CryptographyLib.Extensions.EulerExtensions')
  - [EulerFunc()](#M-CryptographyLib-Extensions-EulerExtensions-EulerFunc-System-Int32- 'CryptographyLib.Extensions.EulerExtensions.EulerFunc(System.Int32)')
  - [Phi(n)](#M-CryptographyLib-Extensions-EulerExtensions-Phi-System-Int32- 'CryptographyLib.Extensions.EulerExtensions.Phi(System.Int32)')
- [FeistelNetwork](#T-CryptographyLib-FeistelNetwork-FeistelNetwork 'CryptographyLib.FeistelNetwork.FeistelNetwork')
- [FieldGalua](#T-CryptographyLib-FieldGalua 'CryptographyLib.FieldGalua')
  - [_irPoly](#F-CryptographyLib-FieldGalua-_irPoly 'CryptographyLib.FieldGalua._irPoly')
  - [IrrationalPoly](#P-CryptographyLib-FieldGalua-IrrationalPoly 'CryptographyLib.FieldGalua.IrrationalPoly')
  - [add(a,b)](#M-CryptographyLib-FieldGalua-add-System-Byte,System-Byte- 'CryptographyLib.FieldGalua.add(System.Byte,System.Byte)')
  - [degree(poly)](#M-CryptographyLib-FieldGalua-degree-System-UInt16- 'CryptographyLib.FieldGalua.degree(System.UInt16)')
  - [get_inverse(poly,modulo)](#M-CryptographyLib-FieldGalua-get_inverse-System-Byte,System-UInt16- 'CryptographyLib.FieldGalua.get_inverse(System.Byte,System.UInt16)')
  - [if_irreducible(poly)](#M-CryptographyLib-FieldGalua-if_irreducible-System-UInt16- 'CryptographyLib.FieldGalua.if_irreducible(System.UInt16)')
  - [irred_poly()](#M-CryptographyLib-FieldGalua-irred_poly 'CryptographyLib.FieldGalua.irred_poly')
  - [multiply(a,b,modulo)](#M-CryptographyLib-FieldGalua-multiply-System-UInt16,System-UInt16,System-UInt16- 'CryptographyLib.FieldGalua.multiply(System.UInt16,System.UInt16,System.UInt16)')
  - [remnant(poly,module)](#M-CryptographyLib-FieldGalua-remnant-System-UInt16,System-UInt16- 'CryptographyLib.FieldGalua.remnant(System.UInt16,System.UInt16)')
- [FuncExtensions](#T-CryptographyLib-Extensions-FuncExtensions 'CryptographyLib.Extensions.FuncExtensions')
  - [CreateKeyByFunc(a,k,expectedValues)](#M-CryptographyLib-Extensions-FuncExtensions-CreateKeyByFunc-System-Func{System-Byte,System-Byte},System-Int32,System-Byte[]- 'CryptographyLib.Extensions.FuncExtensions.CreateKeyByFunc(System.Func{System.Byte,System.Byte},System.Int32,System.Byte[])')
- [IDecryptor](#T-CryptographyLib-Interfaces-IDecryptor 'CryptographyLib.Interfaces.IDecryptor')
  - [Decrypt(value,key)](#M-CryptographyLib-Interfaces-IDecryptor-Decrypt-System-Byte[],System-Byte[]- 'CryptographyLib.Interfaces.IDecryptor.Decrypt(System.Byte[],System.Byte[])')
- [IEncryptor](#T-CryptographyLib-Interfaces-IEncryptor 'CryptographyLib.Interfaces.IEncryptor')
  - [Encrypt(value,key)](#M-CryptographyLib-Interfaces-IEncryptor-Encrypt-System-Byte[],System-Byte[]- 'CryptographyLib.Interfaces.IEncryptor.Encrypt(System.Byte[],System.Byte[])')
- [IExpandKey](#T-CryptographyLib-Interfaces-IExpandKey 'CryptographyLib.Interfaces.IExpandKey')
  - [Expand(key)](#M-CryptographyLib-Interfaces-IExpandKey-Expand-System-Byte[]- 'CryptographyLib.Interfaces.IExpandKey.Expand(System.Byte[])')
- [ISymmetricEncryptor](#T-CryptographyLib-Interfaces-ISymmetricEncryptor 'CryptographyLib.Interfaces.ISymmetricEncryptor')
  - [Key](#P-CryptographyLib-Interfaces-ISymmetricEncryptor-Key 'CryptographyLib.Interfaces.ISymmetricEncryptor.Key')
  - [CryptographyLib#Interfaces#IDecryptor#Decrypt(value,key)](#M-CryptographyLib-Interfaces-ISymmetricEncryptor-CryptographyLib#Interfaces#IDecryptor#Decrypt-System-Byte[],System-Byte[]- 'CryptographyLib.Interfaces.ISymmetricEncryptor.CryptographyLib#Interfaces#IDecryptor#Decrypt(System.Byte[],System.Byte[])')
- [NumberTheoryExtensions](#T-CryptographyLib-Extensions-NumberTheoryExtensions 'CryptographyLib.Extensions.NumberTheoryExtensions')
  - [AllPrimesByModule(module)](#M-CryptographyLib-Extensions-NumberTheoryExtensions-AllPrimesByModule-System-Int32- 'CryptographyLib.Extensions.NumberTheoryExtensions.AllPrimesByModule(System.Int32)')
  - [TryGetReverseByModule(a,module)](#M-CryptographyLib-Extensions-NumberTheoryExtensions-TryGetReverseByModule-System-Int32,System-Int32- 'CryptographyLib.Extensions.NumberTheoryExtensions.TryGetReverseByModule(System.Int32,System.Int32)')
- [PBlock](#T-CryptographyLib-FeistelNetwork-PBlock 'CryptographyLib.FeistelNetwork.PBlock')
  - [Decrypt(value,pBlock)](#M-CryptographyLib-FeistelNetwork-PBlock-Decrypt-System-Int32,System-Byte[]- 'CryptographyLib.FeistelNetwork.PBlock.Decrypt(System.Int32,System.Byte[])')
  - [Encrypt(value,pBlock)](#M-CryptographyLib-FeistelNetwork-PBlock-Encrypt-System-Int32,System-Byte[]- 'CryptographyLib.FeistelNetwork.PBlock.Encrypt(System.Int32,System.Byte[])')
- [PKCS7](#T-CryptographyLib-PKCS-PKCS7 'CryptographyLib.PKCS.PKCS7')
  - [ApplyPadding(input,blockLength)](#M-CryptographyLib-PKCS-PKCS7-ApplyPadding-System-Byte[],System-Byte- 'CryptographyLib.PKCS.PKCS7.ApplyPadding(System.Byte[],System.Byte)')
- [SBlock](#T-CryptographyLib-FeistelNetwork-SBlock 'CryptographyLib.FeistelNetwork.SBlock')
  - [Decrypt(value,SBlock,k)](#M-CryptographyLib-FeistelNetwork-SBlock-Decrypt-System-Byte[],System-Func{System-Byte,System-Byte},System-Int32- 'CryptographyLib.FeistelNetwork.SBlock.Decrypt(System.Byte[],System.Func{System.Byte,System.Byte},System.Int32)')
  - [Decrypt()](#M-CryptographyLib-FeistelNetwork-SBlock-Decrypt-System-Byte[],System-Collections-Generic-Dictionary{System-Byte,System-Byte},System-Int32- 'CryptographyLib.FeistelNetwork.SBlock.Decrypt(System.Byte[],System.Collections.Generic.Dictionary{System.Byte,System.Byte},System.Int32)')
  - [Encrypt(value,SBlock,k)](#M-CryptographyLib-FeistelNetwork-SBlock-Encrypt-System-Int32,System-Collections-Generic-Dictionary{System-Byte,System-Byte},System-Int32- 'CryptographyLib.FeistelNetwork.SBlock.Encrypt(System.Int32,System.Collections.Generic.Dictionary{System.Byte,System.Byte},System.Int32)')
  - [Encrypt()](#M-CryptographyLib-FeistelNetwork-SBlock-Encrypt-System-Byte[],System-Collections-Generic-Dictionary{System-Byte,System-Byte},System-Int32- 'CryptographyLib.FeistelNetwork.SBlock.Encrypt(System.Byte[],System.Collections.Generic.Dictionary{System.Byte,System.Byte},System.Int32)')
  - [Encrypt()](#M-CryptographyLib-FeistelNetwork-SBlock-Encrypt-System-Int32,System-Func{System-Byte,System-Byte},System-Int32- 'CryptographyLib.FeistelNetwork.SBlock.Encrypt(System.Int32,System.Func{System.Byte,System.Byte},System.Int32)')
  - [Encrypt()](#M-CryptographyLib-FeistelNetwork-SBlock-Encrypt-System-Byte[],System-Func{System-Byte,System-Byte},System-Int32- 'CryptographyLib.FeistelNetwork.SBlock.Encrypt(System.Byte[],System.Func{System.Byte,System.Byte},System.Int32)')

<a name='T-CryptographyLib-Extensions-ArithmeticExtensions'></a>
## ArithmeticExtensions `type`

##### Namespace

CryptographyLib.Extensions

<a name='M-CryptographyLib-Extensions-ArithmeticExtensions-unsigned_divide-System-UInt32,System-UInt32-'></a>
### unsigned_divide(dividend,divisor) `method`

##### Summary

Binary implementation of divide (unsigned)

##### Returns

First item - quotient

Second item - remainder

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dividend | [System.UInt32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt32 'System.UInt32') |  |
| divisor | [System.UInt32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt32 'System.UInt32') |  |

<a name='T-CryptographyLib-Extensions-BinaryExtensions'></a>
## BinaryExtensions `type`

##### Namespace

CryptographyLib.Extensions

<a name='M-CryptographyLib-Extensions-BinaryExtensions-Pow-System-Int32,System-Int32-'></a>
### Pow(a,n) `method`

##### Summary

Binary exponentiation

##### Returns

a ^ n

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Base |
| n | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Power |

##### Remarks

Complexity O(log( `n` ))

<a name='T-CryptographyLib-Extensions-ByteExtensions'></a>
## ByteExtensions `type`

##### Namespace

CryptographyLib.Extensions

<a name='M-CryptographyLib-Extensions-ByteExtensions-CountOfBites-System-Int32-'></a>
### CountOfBites(_value) `method`

##### Summary

Count of bites in array of bytes

##### Returns

Count of bites

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| _value | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | array of bytes |

<a name='M-CryptographyLib-Extensions-ByteExtensions-GetBits-System-Int32-'></a>
### GetBits(value) `method`

##### Summary

Returns collection of bits in `value`

##### Returns

collection of bits

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | array of bytes |

<a name='M-CryptographyLib-Extensions-ByteExtensions-GetByteBlocks-System-Byte[],System-Int32-'></a>
### GetByteBlocks(value,BlockLength) `method`

##### Summary

Separates array of bytes into byte blocks

##### Returns

Blocks of bytes with `BlockLength` lenght

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | array of bytes |
| BlockLength | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Length of block (1,2,4,8,16 and etc.) |

<a name='M-CryptographyLib-Extensions-ByteExtensions-GetBytes-System-Int32-'></a>
### GetBytes(value) `method`

##### Summary

Returns collection of bits in `value`

##### Returns

collection of bits

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | array of bytes |

<a name='M-CryptographyLib-Extensions-ByteExtensions-GetKBit-System-Int32,System-Int32-'></a>
### GetKBit(value,k) `method`

##### Summary

Get k's bit from `value`

##### Returns

k's bit

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | byte(bits) array |
| k | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | position of bit in `value` |

<a name='M-CryptographyLib-Extensions-ByteExtensions-GetKByte-System-Int32,System-Int32-'></a>
### GetKByte(value,k) `method`

##### Summary

Get k's bit from `value`

##### Returns

k's bit

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | byte(bits) array |
| k | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | position of bit in `value` |

<a name='M-CryptographyLib-Extensions-ByteExtensions-MaxValuableBit-System-Int32-'></a>
### MaxValuableBit(_value) `method`

##### Summary

Returns max valuable bit in array of bytes

##### Returns

value of bit

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| _value | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | array of bytes |

<a name='T-CryptographyLib-Extensions-EulerExtensions'></a>
## EulerExtensions `type`

##### Namespace

CryptographyLib.Extensions

<a name='M-CryptographyLib-Extensions-EulerExtensions-EulerFunc-System-Int32-'></a>
### EulerFunc() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-CryptographyLib-Extensions-EulerExtensions-Phi-System-Int32-'></a>
### Phi(n) `method`

##### Summary

Euler function

##### Returns

Count from 1 to `n` coprime/
relatively prime or mutually prime

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| n | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number |

##### Remarks

Complexity O(sqrt(`n`))

<a name='T-CryptographyLib-FeistelNetwork-FeistelNetwork'></a>
## FeistelNetwork `type`

##### Namespace

CryptographyLib.FeistelNetwork

##### Summary



<a name='T-CryptographyLib-FieldGalua'></a>
## FieldGalua `type`

##### Namespace

CryptographyLib

##### Summary

GF ( 2^8 ), where 2 - field characteristics, 8 - field order

<a name='F-CryptographyLib-FieldGalua-_irPoly'></a>
### _irPoly `constants`

##### Summary

vector of irreducible polynoms

<a name='P-CryptographyLib-FieldGalua-IrrationalPoly'></a>
### IrrationalPoly `property`

##### Summary

vector of irreducible polynoms

<a name='M-CryptographyLib-FieldGalua-add-System-Byte,System-Byte-'></a>
### add(a,b) `method`

##### Summary

Getting sum of polis

##### Returns

result polynom

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [System.Byte](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte 'System.Byte') | first poly |
| b | [System.Byte](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte 'System.Byte') | second poly |

<a name='M-CryptographyLib-FieldGalua-degree-System-UInt16-'></a>
### degree(poly) `method`

##### Summary

Getting

##### Returns

Col of non zero a * x^p / degree of polynom :333

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| poly | [System.UInt16](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt16 'System.UInt16') | Polynom |

<a name='M-CryptographyLib-FieldGalua-get_inverse-System-Byte,System-UInt16-'></a>
### get_inverse(poly,modulo) `method`

##### Summary

Method for getting inverse of the required polynom

##### Returns

polynom

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| poly | [System.Byte](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte 'System.Byte') | the required polynom |
| modulo | [System.UInt16](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt16 'System.UInt16') | Module over the ring |

<a name='M-CryptographyLib-FieldGalua-if_irreducible-System-UInt16-'></a>
### if_irreducible(poly) `method`

##### Summary



##### Returns

true if poltnom is irreducible, false else

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| poly | [System.UInt16](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt16 'System.UInt16') | polynom thats should be checked on irreducibility |

<a name='M-CryptographyLib-FieldGalua-irred_poly'></a>
### irred_poly() `method`

##### Summary

Calling in constructor

 pushing in vector first 30 irreducible polynoms

##### Parameters

This method has no parameters.

<a name='M-CryptographyLib-FieldGalua-multiply-System-UInt16,System-UInt16,System-UInt16-'></a>
### multiply(a,b,modulo) `method`

##### Summary

Getting product of polis

##### Returns

polynom

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [System.UInt16](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt16 'System.UInt16') | - first poly |
| b | [System.UInt16](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt16 'System.UInt16') | - second poly |
| modulo | [System.UInt16](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt16 'System.UInt16') | - module over the ring |

<a name='M-CryptographyLib-FieldGalua-remnant-System-UInt16,System-UInt16-'></a>
### remnant(poly,module) `method`

##### Summary

getting remnant of poly by module

##### Returns

Remnant of poly by module

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| poly | [System.UInt16](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt16 'System.UInt16') | Polynom |
| module | [System.UInt16](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt16 'System.UInt16') | Module over the ring |

<a name='T-CryptographyLib-Extensions-FuncExtensions'></a>
## FuncExtensions `type`

##### Namespace

CryptographyLib.Extensions

<a name='M-CryptographyLib-Extensions-FuncExtensions-CreateKeyByFunc-System-Func{System-Byte,System-Byte},System-Int32,System-Byte[]-'></a>
### CreateKeyByFunc(a,k,expectedValues) `method`

##### Summary

Creating a key with rule

##### Returns

associative array (key)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [System.Func{System.Byte,System.Byte}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Byte,System.Byte}') | Rule of creating key |
| k | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Count of bytes in key |
| expectedValues | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | values that could be |

##### Remarks

`expectedValues` - optional param

<a name='T-CryptographyLib-Interfaces-IDecryptor'></a>
## IDecryptor `type`

##### Namespace

CryptographyLib.Interfaces

##### Summary

Interface for decryptor

<a name='M-CryptographyLib-Interfaces-IDecryptor-Decrypt-System-Byte[],System-Byte[]-'></a>
### Decrypt(value,key) `method`

##### Summary

Decryption

##### Returns

Open text

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Closed text |
| key | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | key |

<a name='T-CryptographyLib-Interfaces-IEncryptor'></a>
## IEncryptor `type`

##### Namespace

CryptographyLib.Interfaces

##### Summary

Interface for encryption

<a name='M-CryptographyLib-Interfaces-IEncryptor-Encrypt-System-Byte[],System-Byte[]-'></a>
### Encrypt(value,key) `method`

##### Summary

Encryption

##### Returns

Closed text

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Open text |
| key | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | key |

<a name='T-CryptographyLib-Interfaces-IExpandKey'></a>
## IExpandKey `type`

##### Namespace

CryptographyLib.Interfaces

##### Summary

Interface for Strategy Pattern for key expander

<a name='M-CryptographyLib-Interfaces-IExpandKey-Expand-System-Byte[]-'></a>
### Expand(key) `method`

##### Summary

Expanding key

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| key | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Key |

<a name='T-CryptographyLib-Interfaces-ISymmetricEncryptor'></a>
## ISymmetricEncryptor `type`

##### Namespace

CryptographyLib.Interfaces

##### Summary

Interface of Symmetric Encryptor

<a name='P-CryptographyLib-Interfaces-ISymmetricEncryptor-Key'></a>
### Key `property`

##### Summary

Storage Key

<a name='M-CryptographyLib-Interfaces-ISymmetricEncryptor-CryptographyLib#Interfaces#IDecryptor#Decrypt-System-Byte[],System-Byte[]-'></a>
### CryptographyLib#Interfaces#IDecryptor#Decrypt(value,key) `method`

##### Summary

Decryption

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | byte array |
| key | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | Key |

<a name='T-CryptographyLib-Extensions-NumberTheoryExtensions'></a>
## NumberTheoryExtensions `type`

##### Namespace

CryptographyLib.Extensions

<a name='M-CryptographyLib-Extensions-NumberTheoryExtensions-AllPrimesByModule-System-Int32-'></a>
### AllPrimesByModule(module) `method`

##### Summary

Finding all primes by a given module

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| module | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Module |

##### Remarks

https://e-maxx.ru/algo/reverse_element

<a name='M-CryptographyLib-Extensions-NumberTheoryExtensions-TryGetReverseByModule-System-Int32,System-Int32-'></a>
### TryGetReverseByModule(a,module) `method`

##### Summary

Finds reverse

##### Returns

Reverse value

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Value |
| module | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Module |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | No solution |

<a name='T-CryptographyLib-FeistelNetwork-PBlock'></a>
## PBlock `type`

##### Namespace

CryptographyLib.FeistelNetwork

<a name='M-CryptographyLib-FeistelNetwork-PBlock-Decrypt-System-Int32,System-Byte[]-'></a>
### Decrypt(value,pBlock) `method`

##### Summary

Decryption of `value` with `value` as P-Box

##### Returns

primal value

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | encrypted value |
| pBlock | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | P-Box |

<a name='M-CryptographyLib-FeistelNetwork-PBlock-Encrypt-System-Int32,System-Byte[]-'></a>
### Encrypt(value,pBlock) `method`

##### Summary

Encryption of `value` with `value` as P-Box

##### Returns

encrypted value

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | value to encrypt |
| pBlock | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | P-Box |

<a name='T-CryptographyLib-PKCS-PKCS7'></a>
## PKCS7 `type`

##### Namespace

CryptographyLib.PKCS

##### Summary

https://datatracker.ietf.org/doc/html/rfc3369

<a name='M-CryptographyLib-PKCS-PKCS7-ApplyPadding-System-Byte[],System-Byte-'></a>
### ApplyPadding(input,blockLength) `method`

##### Summary

Padding byte array in format of PKCS7
https://ru.wikipedia.org/wiki/Дополнение_(криптография)#PKCS7

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| input | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') |  |
| blockLength | [System.Byte](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte 'System.Byte') |  |

<a name='T-CryptographyLib-FeistelNetwork-SBlock'></a>
## SBlock `type`

##### Namespace

CryptographyLib.FeistelNetwork

<a name='M-CryptographyLib-FeistelNetwork-SBlock-Decrypt-System-Byte[],System-Func{System-Byte,System-Byte},System-Int32-'></a>
### Decrypt(value,SBlock,k) `method`

##### Summary

Decryption

##### Returns

Original bytes array

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Byte[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Byte[] 'System.Byte[]') | bytes array |
| SBlock | [System.Func{System.Byte,System.Byte}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Byte,System.Byte}') | Rule for creating SBlock |
| k | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | size of SBlock |

<a name='M-CryptographyLib-FeistelNetwork-SBlock-Decrypt-System-Byte[],System-Collections-Generic-Dictionary{System-Byte,System-Byte},System-Int32-'></a>
### Decrypt() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-CryptographyLib-FeistelNetwork-SBlock-Encrypt-System-Int32,System-Collections-Generic-Dictionary{System-Byte,System-Byte},System-Int32-'></a>
### Encrypt(value,SBlock,k) `method`

##### Summary

Encryption

##### Returns

Encrypted bytes array

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | bytes array |
| SBlock | [System.Collections.Generic.Dictionary{System.Byte,System.Byte}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.Byte,System.Byte}') | Rule for creating SBlock |
| k | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | size of SBlock |

<a name='M-CryptographyLib-FeistelNetwork-SBlock-Encrypt-System-Byte[],System-Collections-Generic-Dictionary{System-Byte,System-Byte},System-Int32-'></a>
### Encrypt() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-CryptographyLib-FeistelNetwork-SBlock-Encrypt-System-Int32,System-Func{System-Byte,System-Byte},System-Int32-'></a>
### Encrypt() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-CryptographyLib-FeistelNetwork-SBlock-Encrypt-System-Byte[],System-Func{System-Byte,System-Byte},System-Int32-'></a>
### Encrypt() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.
