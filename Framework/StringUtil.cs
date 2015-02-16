/**************************************************************
 * Class:		StringUtility	version 1.0
 * Author:		Paul Alexander
 * Created:		June 27th, 2002 8:44 PM
**************************************************************/

using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Net;
using System.Collections;

namespace Powerson.Framework
{
	/// <summary>
	/// 字符串操作工具类。
	/// 其中包括和字符串相关的输入有效性的验证。
	/// </summary>
	public class StringUtil
	{
		/////////////////////////////////////////////////////////////////////////////
		#region Fields

		/// <summary>
		/// 一个字符串常量供调用。
		/// </summary>
		//private static string _key		= "Free is ALL!"; 

		#endregion
		/////////////////////////////////////////////////////////////////////////////

		/////////////////////////////////////////////////////////////////////////////
		#region Constructors

		/// <summary>
		/// Protected to indicate that instances of this class should not be 
		/// instantiated.
		/// </summary>
		protected StringUtil()
		{
		}
		#endregion
		/////////////////////////////////////////////////////////////////////////////

		/////////////////////////////////////////////////////////////////////////////
		#region Properties
		#endregion
		/////////////////////////////////////////////////////////////////////////////

		/////////////////////////////////////////////////////////////////////////////
		#region Helper Methods

		/// <summary>
		/// Get a HEX display of raw byte data.
		/// </summary>
		/// <remarks>
		/// The format of the dump data is as follows:
		/// <code>
		/// LINE####: XX XX XX XX  XX XX XX XX  XX XX XX XX  XX XX XX XX  CCCCCCCCCCCCCCCC
		/// </code>
		/// </remarks>
		public static string GetDumpString( byte[] data )
		{
			StringBuilder	builder	= new StringBuilder( data.Length * 5 );

			for( int block = 0; block < data.Length; block += 16 )
			{
				builder.AppendFormat( "{0,8:}: ", block );
				for( int column = 0; column < 16; column ++ )
				{
					if( block + column < data.Length )
						builder.AppendFormat( "{0:X2} ", data[ block + column ] );
					else
						builder.Append( "   " );

					if( column % 4 == 3 )
						builder.Append( " " );
				}
				for( int column = 0; column < 16; column ++ )
				{
					if( block + column < data.Length )
					{
						if( data[ block + column ] < 32 || data[ block + column ] > 255 )
							builder.Append( "." );
						else
							builder.Append( (char)data[ block + column ] );
					}
					else
						builder.Append( " " );
				}
				builder.Append( "\n" );
			}

			return builder.ToString();
		}

		#endregion
		/////////////////////////////////////////////////////////////////////////////

		/////////////////////////////////////////////////////////////////////////////
		#region Encryption Operations

		/// <summary>
		/// Performs a one-way encryption on the data and returns the result. Useful
		/// for protected authentication credentials.
		/// </summary>
		/// <param name="data">
		///		Data to be encrypted.
		/// </param>
		public static string Crypt( string data )
		{
			SHA512Managed	sha512			= new SHA512Managed();
			byte[]			sourceData		= new byte[ Encoding.Default.GetByteCount( data ) ];
			return Convert.ToBase64String( sha512.ComputeHash( Encoding.Default.GetBytes( data ) ) );
		}

		/// <summary>
		/// Generates a string that can be safely stored in a config file and later
		/// re-read without others being able to read the original data. Use 
		/// <see cref="GetFromSafeConfig"/> to get the original value.
		/// </summary>
		/// <remarks>
		///		需要在Config文件中配置对应的加密密钥
		///		The CryptKey config setting must contain the same value to decrypt the 
		///		data returned from this method at a later time. If CryptKey is not set
		///		then a default key will be used.
		/// </remarks>
//		public static string MakeSafeForConfig( string data )
//		{
//			//return Encrypt( data, ConfigUtil.GetValue( "CryptKey", _key ) );
//		}

		/// <summary>
		/// Returns the orignal data that was passed to <see cref="MakeSafeForConfig"/>
		/// </summary>
		/// <param name="data">
		///		Data that was previously encoded with <see cref="MakeSafeForConfig"/>
		/// </param>
		/// <remarks>
		///		The CryptKey config setting must contain the same value used to encrypt
		///		the data originally. If CryptKey is not set then a default key will be 
		///		used.
		/// </remarks>
//		public static string GetFromSafeConfig( string data )
//		{
//			//return Decrypt( data, ConfigUtil.GetValue( "CryptKey", _key ) );
//		}

		/// <summary>
		/// Encrypts a string of data using the given key.
		/// </summary>
		/// <remarks>
		///		The encrypted data is Base64 encoded and may safely be written and read 
		///		from plain text ASCII files.
		/// </remarks>
		/// <param name="data">
		///		Data to encrypt.
		/// </param>
		/// <param name="key">
		///		Key to use when encrypting the data.
		/// </param>
		public static string Encrypt( string data, string key )
		{
			byte[] dataBytes = Encoding.Default.GetBytes( data );

			SymmetricAlgorithm	encoder		= SymmetricAlgorithm.Create( "TripleDES" );

			encoder.Key		=  Encoding.Default.GetBytes( GetLegalKey( key, encoder ) );
			encoder.GenerateIV();

			MemoryStream				ms			= new MemoryStream();
			CryptoStream				cryptStream	= new CryptoStream( ms, encoder.CreateEncryptor(), CryptoStreamMode.Write );

			cryptStream.Write( dataBytes, 0, dataBytes.Length );
			cryptStream.FlushFinalBlock();
			
			string iv = Convert.ToBase64String( encoder.IV );
			return iv.Length.ToString( "X2" ) + iv + Convert.ToBase64String( ms.ToArray() );
		}

		/// <summary>
		/// Decrypts a string of data previously encoded with <see cref="Encrypt"/> using 
		/// the given key.
		/// </summary>
		/// <param name="data">
		///		Data that was previously encrypted with <see cref="Encrypt"/>.
		/// </param>
		/// <param name="key">
		///		Key used when the data was encrypted.
		/// </param>
		public static string Decrypt( string data, string key )
		{
			int					len			= int.Parse( data.Substring( 0, 2 ), System.Globalization.NumberStyles.HexNumber );
			byte[]				iv			= Convert.FromBase64String( data.Substring( 2, len ) );
			byte[]				dataBytes	= Convert.FromBase64String( data.Substring( 2 + len ) );
			MemoryStream		ms			= new MemoryStream();
			SymmetricAlgorithm	encoder		= SymmetricAlgorithm.Create( "TripleDES" );

			//			encoder.Padding	= PaddingMode.Zeros;
			encoder.Key		=  Encoding.Default.GetBytes( GetLegalKey( key, encoder ) );
			encoder.IV		= iv;

			CryptoStream				cryptStream	= new CryptoStream( ms, encoder.CreateDecryptor(), CryptoStreamMode.Write );
			cryptStream.Write( dataBytes, 0, dataBytes.Length );
			cryptStream.FlushFinalBlock();
			
			encoder.Clear();
			cryptStream.Clear();

			return Encoding.Default.GetString( ms.ToArray() );
		}

		
		/// <summary>
		/// Generate a key that is known to be legal for the chosen algorithm.
		/// </summary>
		private static string GetLegalKey( string key, SymmetricAlgorithm alg )
		{
			string	result	= key;
			int		size	= Encoding.Default.GetByteCount( key ) * 8;

			if (alg.LegalKeySizes.Length > 0)
			{
				if( size > alg.LegalKeySizes[ 0 ].MaxSize )
				{
					result = result.Substring( 0, Encoding.Default.GetMaxCharCount( alg.LegalKeySizes[ 0 ].MaxSize / 8 ) );
				}
				else
				{
					if( size < alg.LegalKeySizes[ 0 ].MinSize )
					{
						result = result.PadRight( result.Length + Encoding.Default.GetMaxCharCount( ( alg.LegalKeySizes[ 0 ].MinSize - size ) / 8 ) );
					}
					else
					{
						if( alg.LegalKeySizes[ 0 ].SkipSize > 0 )
						{
							if( ( size % alg.LegalKeySizes[ 0 ].SkipSize ) != 0 )
							{
								int pad = Encoding.Default.GetMaxCharCount( ( alg.LegalKeySizes[ 0 ].MaxSize - size ) / 8 );
								result = result.PadRight( result.Length + pad, 'X' );
							}
						}
					}
				}
			}

			return result;
		}

		/// <summary>
		/// Generate a IV that is known to be legal for the chosen algorithm.
		/// </summary>
		private static string GetLegalIV( string key, SymmetricAlgorithm alg )
		{
			string	result	= key;
			int		size	= Encoding.Default.GetByteCount( key ) * 8;

			if (alg.LegalBlockSizes.Length > 0)
			{
				if( size > alg.LegalBlockSizes[ 0 ].MaxSize )
				{
					result = result.Substring( 0, Encoding.Default.GetMaxCharCount( alg.LegalBlockSizes[ 0 ].MaxSize / 8 ) );
				}
				else
				{
					if( size < alg.LegalBlockSizes[ 0 ].MinSize )
					{
						result = result.PadRight( Encoding.Default.GetMaxCharCount( ( alg.LegalBlockSizes[ 0 ].MinSize - size ) / 8 ) );
					}
					else
					{
						if( alg.LegalBlockSizes[ 0 ].SkipSize > 0 )
						{
							if( ( size % alg.LegalBlockSizes[ 0 ].SkipSize ) != 0 )
							{
								int pad = Encoding.Default.GetMaxCharCount( ( alg.LegalBlockSizes[ 0 ].MaxSize - size ) / 8 );
								result = result.PadRight( result.Length + pad, 'X' );
							}
						}
					}
				}
			}

			return result;
		}

		/// <summary>
		/// 产生一个指定长度的随机密码
		/// </summary>
		/// <param name="len">
		///	密码长度
		/// </param>
		/// <returns>string：密码</returns>
		public static string GeneratePassword( int len )
		{
			byte[] password = new byte[ len ];
			RNGCryptoServiceProvider rng = RNGCryptoServiceProvider.Create() as RNGCryptoServiceProvider;
	
			rng.GetNonZeroBytes( password );

			for( int index = 0; index < len; index++ )
			{
				if( password[ index ] > 127 || password[ index ] < 33 )
				{
					byte c = password[ index ];
					c = (byte)( c  & 127  );
					if( c < 32 )
						c += 33;
					password[ index ] = c;
				}
			}

			return Encoding.ASCII.GetString( password );
		}


		/////////////////////////////////////////////////////////////////////////////
		#region 口令的加密(MD5 Hash)
		/// <summary>
		/// 采用MD5 Hash对传入的字符串信息作加密
		/// </summary>
		/// <param name="cryptoValue">加密信息</param>
		/// <returns>返回的hash值</returns>
		public static string MD5Hash(string cryptoValue)
		{
			ASCIIEncoding code=new ASCIIEncoding ();
			MD5CryptoServiceProvider crypto=new MD5CryptoServiceProvider();
			//			string crptoCode=code.GetString (crypto.ComputeHash (code.GetBytes(cryptoValue)));
			string crptoCode=BitConverter.ToString(crypto.ComputeHash (code.GetBytes(cryptoValue)));
			crptoCode=crptoCode.Replace("-","");
			return crptoCode;
		}

		#endregion 口令的加密(MD5 Hash)
		/////////////////////////////////////////////////////////////////////////////
		
		#endregion
		/////////////////////////////////////////////////////////////////////////////
		
		/////////////////////////////////////////////////////////////////////////////
		#region Validation Operations

		/// <summary>
		/// 判断string的长度是否符合给定的范围。
		/// </summary>
		/// <remarks>
		///	为null的string返回长度为0
		/// </remarks>
		/// <param name="data">
		///	待检验的string，可以为null
		/// </param>
		/// <param name="min">
		///	int：最小长度 
		/// </param>
		/// <param name="max">
		///	int：最大长度，如果为－1表示不限制长度。
		/// </param>
		public static bool ValidateLength( string data, int min, int max )
		{
			Debug.Assert( min >= 0, "Expected value >= 0." );
			Debug.Assert( max >= -1, "Expected -1 or max value." );

			if( data == null )
				return min <= 0;

			if( data.Length < min )
				return false;

			if( max != -1 )
				return data.Length <= max;
			
			return true;
		}
		#region Overrides
		/// <summary>
		/// 判断string的长度是否符合给定的范围。
		/// </summary>
		/// <remarks>
		///	为null的string返回长度为0
		/// </remarks>
		/// <param name="data">
		///	待检验的string，可以为null
		/// </param>
		/// <param name="min">
		///	object：最小长度
		/// </param>
		/// <param name="max">
		///	object：最大长度，如果为－1表示不限制长度。
		/// </param>
		public static bool ValidateLength( string data, object min, object max )
		{
			try
			{
				int minValue;
				int maxValue;

				if( ( min is string && (string)min == "" ) || min == null )
					minValue = 0;
				else
					minValue = int.Parse( min.ToString() );

				if( ( max is string && (string)max == "" ) || max == null )
					maxValue = -1;
				else
					maxValue = int.Parse( max.ToString() );

				return ValidateLength( data, minValue, maxValue );
			}
			catch {}

			return false;
		}
		#endregion

		/// <summary>
		/// Determines if a string contains only characters from the chosen 
		/// ValidCharacterSet. Additional valid characters may be passed in the chars
		/// argument.
		/// </summary>
		/// <param name="data">
		///		String to validate.
		/// </param>
		/// <param name="charSet">
		///		Combination of ValidCharacterSet values.
		/// </param>
		/// <param name="chars">
		///		Additional allowable characters not included in the chosen character set.
		/// </param>
		/// <returns>
		///		Returns true if all the characters were valid, otherwise false.
		/// </returns>		
		public static bool ValidateCharacterSet( string data, ValidCharacterSet charSet, params char[] chars )
		{
			if( ( charSet & ValidCharacterSet.All ) == ValidCharacterSet.All )
				return true;
			
			if( data == null )
				return ( ValidCharacterSet.Null & charSet ) == ValidCharacterSet.Null;

			if( ( charSet & ValidCharacterSet.Any ) == ValidCharacterSet.Any )
				return true;

			string resultSet = GetCharacterSet( charSet, chars );

			foreach( char c in data )
				if( resultSet.IndexOf( c ) == -1 )
					return false;

			return true;
		}
		#region Overrides
		/// <summary>
		/// Determines if a string contains only characters from the chosen 
		/// ValidCharacterSet. Additional valid characters may be passed in the chars
		/// argument.
		/// </summary>
		/// <param name="data">
		///		String to validate.
		/// </param>
		/// <param name="charSet">
		///		One or more of the ValidCharacterSet values.
		/// </param>
		/// <param name="chars">
		///		String of additional allowable characters not included in the 
		///		chosen character set.
		/// </param>
		/// <returns></returns>
		public static bool ValidateCharacterSet( string data, ValidCharacterSet charSet, string chars )
		{
			return ValidateCharacterSet( data, charSet, chars.ToCharArray() );
		}
		/// <summary>
		/// Determines if a string contains only characters from the chosen 
		/// ValidCharacterSet. Additional valid characters may be passed in the chars
		/// argument.
		/// </summary>
		/// <param name="data">
		///		String to validate.
		/// </param>
		/// <param name="charSet">
		///		One or more of the ValidCharacterSet values.
		/// </param>
		/// <returns></returns>
		public static bool ValidateCharacterSet( string data, ValidCharacterSet charSet )
		{
			return ValidateCharacterSet( data, charSet, (char[])null );
		}
		#endregion
		#region Helper Methods

		/// <summary>
		/// Gets the string of valid characters as defined by the combination of 
		/// values in the <c>charSet</c> parameter.
		/// </summary>
		/// <param name="charSet">
		///		Combination of ValidCharacterSet values.
		/// </param>
		/// <param name="chars">
		///		Additional characters to treat as valid.
		/// </param>
		/// <returns>
		///		Returns a combined string containing all the characters to 
		///		consider valid.
		/// </returns>
		public static string GetCharacterSet( ValidCharacterSet charSet, char[] chars )
		{
			StringBuilder resultSet	= new StringBuilder( new string( chars ) );
			
			foreach( ValidCharacterSet val in Enum.GetValues( typeof( ValidCharacterSet ) ) )
			{
				if( ( ( val & charSet ) == val ) && ( ( val & ValidCharacterSet.mark_Combo ) != ValidCharacterSet.mark_Combo ) && val != ValidCharacterSet.mark_SingleCharacter )
				{
					switch( val )
					{
						case ValidCharacterSet.Uppercase:
							resultSet.Append( "ABCDEFGHIJKLMNOPQRSTUVWXYZ" );
							break;
						case ValidCharacterSet.Lowercase:
							resultSet.Append( "abcdefghijklmnopqrstuvwxyz" );
							break;
						case ValidCharacterSet.Numeric:
							resultSet.Append( "1234567890" );
							break;
						case ValidCharacterSet.Hyphen:
							resultSet.Append( '-' );
							break;
						case ValidCharacterSet.Underscore:
							resultSet.Append( '_' );
							break;
						case ValidCharacterSet.Tab:
							resultSet.Append( '\t' );
							break;
						case ValidCharacterSet.Space:
							resultSet.Append( ' ' );
							break;
						case ValidCharacterSet.CarriageReturn:
							resultSet.Append( '\r' );
							break;
						case ValidCharacterSet.LineFeed:
							resultSet.Append( '\n' );
							break;
						case ValidCharacterSet.Period:
							resultSet.Append( '.' );
							break;
						case ValidCharacterSet.At:
							resultSet.Append( '@' );
							break;
						case ValidCharacterSet.Punctuation:
							resultSet.Append( "!@#$%^&*<>()[]{}|\\/:;,.\"'-_=+~`" );
							break;
						case ValidCharacterSet.SafePunctuation:
							resultSet.Append( "_-." );
							break;
						case ValidCharacterSet.Currency:
							resultSet.Append( System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator );
							resultSet.Append( System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator );
							resultSet.Append( System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol );
							break;
					}
				}
			}

			return resultSet.ToString();
		}

		/// <summary>
		/// Gets the human readable names of the character sets defined in the <c>charSet</c>
		/// parameter.
		/// </summary>
		/// <param name="charSet">
		///		Combination of ValidCharacterSet values.
		/// </param>
		/// <param name="chars">
		///		Additional characters to include in the final name.
		/// </param>
		/// <returns>
		///		Returns a comma separated list of character sets.
		/// </returns>
		public static string GetCharacterSetNames( ValidCharacterSet charSet, char[] chars )
		{
			StringBuilder resultSet	= new StringBuilder();
			
			foreach( ValidCharacterSet val in Enum.GetValues( typeof( ValidCharacterSet ) ) )
			{
				if( ( ( val & charSet ) == val ) && ( ( val & ValidCharacterSet.mark_Combo ) != ValidCharacterSet.mark_Combo ) && ( val != ValidCharacterSet.None && val != ValidCharacterSet.mark_SingleCharacter ) )
				{
					if( resultSet.Length > 0 )
						resultSet.Append( ", " );

					resultSet.Append( Enum.GetName( typeof( ValidCharacterSet ), val ).ToLower() );

					if( ( val & ValidCharacterSet.mark_SingleCharacter ) == ValidCharacterSet.mark_SingleCharacter )
						resultSet.AppendFormat( " '{0}'", GetCharacterSet( val, null ) );
				}
			}

			if( chars != null && chars.Length > 0 )
			{
				if( resultSet.Length > 0 )
					resultSet.Append( ", " );

				resultSet.AppendFormat( "'{0}'", new string( chars ) );
			}

			if( resultSet.ToString().IndexOf( ',' ) > -1 )
				resultSet.Insert( resultSet.ToString().LastIndexOf( ',' ) + 1, " and" );
				
			return resultSet.ToString();
		}
		#endregion

		/// <summary>
		/// 判断ip地址是否有效
		/// </summary>
		/// <param name="ipaddress">
		///	待检验的ip地址
		/// </param>
		/// <returns>
		///	bool：有效ip返回true；否则为false
		/// </returns>
		public static bool ValidateIPAddress( string ipaddress )
		{
			Regex regex = new Regex( @"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$", RegexOptions.Compiled );

			if( ! regex.IsMatch( ipaddress ) )
				return false;

			return true;
		}

		/// <summary>
		/// 判断域名是否有效
		/// </summary>
		/// <param name="domainName">
		///	待检查的域名
		/// </param>
		/// <param name="resolve">
		///	bool：是否要把域名解析为 IPHostEntry 实例
		/// </param>
		/// <returns>
		///	bool：有效的域名返回true；否则为false
		/// </returns>
		public static bool ValidateDomainName( string domainName, bool resolve )
		{
			Regex regex = new Regex( @"^([a-z][\-_a-z0-9]{1,25}\.)*[a-z][\-_a-z0-9]{1,25}\.[a-z]{2,3}$", RegexOptions.Compiled );

			if( ! regex.IsMatch( domainName.ToLower() ) )
				return false;

			if( resolve )
			{
				try
				{
					Dns.GetHostEntry( domainName );
				}
				catch
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// 判断email地址是否有效
		/// </summary>
		/// <param name="email">
		///	待检验的email地址
		/// </param>
		/// <returns>
		///	bool：有效的email返回true，否则为false
		/// </returns>
		public static bool ValidateEmail( string email )
		{
			Regex regex = new Regex( @"^[a-z]([\.\-_a-z0-9])*@([a-z][\-_a-z0-9]{1,25}\.)*[a-z][\-_a-z0-9]{1,25}\.[a-z]{2,3}$", RegexOptions.Compiled );

			return regex.IsMatch( email.ToLower() );
		}

		/// <summary>
		/// 判断url是否格式正确
		/// </summary>
		/// <param name="url">
		///	url
		/// </param>
		/// <param name="fullyQualified">
		///	bool:url是否要求全部有效
		/// </param>
		/// <returns>
		///	bool：有效的url返回true；否则false
		/// </returns>
		public static bool ValidateUrl( string url, bool fullyQualified )
		{
			Regex regex = new Regex( @"^(((http://)|(https://)|(ftp://)|(file://))(([a-z][\-_a-z0-9]{1,25}\.)*[a-z][\-_a-z0-9]{1,25}\.[a-z]{2,3})|(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9]))" + (fullyQualified ? "{1}" : "?" ) + @"([/\\][\.\-_a-zA-Z0-9~%\?&#=]*)*$", RegexOptions.Compiled );

			return regex.IsMatch( url.ToLower() );
		}

		/// <summary>
		/// Determines if the given credit card number is valid and one of the selected
		/// types.
		/// </summary>
		/// <param name="number">
		///		The credit card number to validate.
		/// </param>
		/// <param name="validTypes">
		///		Combination of <see cref="CreditCardType"/> values that determine which
		///		types are acceptable.
		/// </param>
		/// <returns>
		///		Returns true if the number is valid, otherwise false.
		/// </returns>
		public static bool ValidateCreditCard( string number, CreditCardType validTypes )
		{
			if( ! ValidateCharacterSet( number, ValidCharacterSet.Numeric | ValidCharacterSet.Space | ValidCharacterSet.Hyphen ) )
				return false;

			string cleanNumber = number.Replace( " ", "" ).Replace( "-", "" );

			if( cleanNumber.Length < 13 )
				return false;

			byte[] digits	= Encoding.Convert( Encoding.Default, Encoding.ASCII, Encoding.Default.GetBytes( cleanNumber ) );
			int length		= cleanNumber.Length;
			int index		= length - 1;
			int digit		= 0;
			int sum			= 0;

			while( index >= 0 )
			{
				digit = digits[ index ] - 48;
				
				if( ( ( index % 2 ) ^ ( length % 2 ) ) == 0 )
				{
					digit *= 2;

					if( digit > 9 )
					{
						sum += ( ( digit / 10 ) + ( digit - 10 ) );
					}
					else
					{
						sum += digit;
					}
				}
				else
				{
					sum += digit;
				}

				index--;
			}

			if( ( sum % 10 ) != 0 )
				return false;

			return ValidateCreditCardType( number, validTypes );
		}

		/// <summary>
		/// Determines if the credit card number is one of the valid types.
		/// </summary>
		/// <param name="number">
		///		The credit card number to validate.
		/// </param>
		/// <param name="validTypes">
		///		Combination of <see cref="CreditCardType"/> values that determine which
		///		types are acceptable.
		/// </param>
		/// <returns>
		///		Returns true if the number is valid, otherwise false.
		/// </returns>
		public static bool ValidateCreditCardType( string number, CreditCardType validTypes )
		{
			if( number == null || number == "" )
				return false;

			if( validTypes == CreditCardType.Any )
				return true;

			switch( number[ 0 ] )
			{
				case '4':	// Visa
					return ( number.Length == 13 || number.Length == 16 ) && 
						( ( validTypes & CreditCardType.Visa ) == CreditCardType.Visa );
				case '5':	// MasterCard
					return number.Length == 16 && 
						number[ 1 ] >= '1' &&
						number[ 2 ] <= '5' &&
						( ( validTypes & CreditCardType.MasterCard ) == CreditCardType.MasterCard );
				case '6':	// Discover
					return number.Length == 16 &&
						number.StartsWith( "6011" ) &&
						( ( validTypes & CreditCardType.Discover ) == CreditCardType.Discover );
				case '3':
					if( number[ 1 ] ==  '4' || number[ 1 ] == '7' )
						return number.Length == 15 &&
							( ( validTypes & CreditCardType.AmericanExpress ) == CreditCardType.AmericanExpress );

					return number.Length == 14 &&
						( ( number[ 1 ] == '6' || number[ 1 ] == '8' ) ||
						( number[ 1 ] == '0' && number[ 2 ] >= '0' && number[ 2 ] <= '5' ) ) &&
						( ( ( validTypes & CreditCardType.DinersClub ) == CreditCardType.DinersClub ) ||
						( ( validTypes & CreditCardType.CarteBlanche ) == CreditCardType.CarteBlanche ) );
			}

			return false;
		}

		#endregion
		/////////////////////////////////////////////////////////////////////////////

		/////////////////////////////////////////////////////////////////////////////
		#region Formatting Operations

		/// <summary>
		/// Formats a timespan in a more descriptive manner, ie. "5 seconds", "3 minutes".
		/// </summary>
		/// <param name="time">
		///		The TimeSpan to format.
		/// </param>
		/// <returns>
		///		Returns the formatted time
		/// </returns>
		public static string FormatTimeSpan( TimeSpan time )
		{
			double remaining= time.TotalSeconds;

			if( remaining == 0 )
				return "";
			else if( remaining < 60000 )
				return String.Format( "{0:#} seconds", remaining / 1000 );
			else if( remaining < 3600000 )
				return String.Format( "{0:#} minutes", remaining / 60000 );
			else if( remaining < 86400000 )
				return String.Format( "{0:#} hours, {1} minutes", remaining / 360000, ( remaining % 360000 ) / 60000 );
			else
				return String.Format( "{0:#}", TimeSpan.FromMilliseconds( remaining ) );

		}
		/// <summary>
		/// 将文本转换为html可以正常显示的文本
		/// 例如\r\n <>
		/// </summary>
		/// <param name="p_origin"></param>
		/// <returns></returns>
		public static string FormatHtmlText(string p_origin)
		{
			return p_origin.Replace("<","&lt;").Replace(">","&gt;").Replace("\r\n","<br>");
		}
        /// <summary>
        /// 将一个字符串按照某个分割符，生成ArrayList
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern">分割符</param>
        /// <returns></returns>
        public static ArrayList StrToArray(string input, string pattern)
        {
            string[] strItems = System.Text.RegularExpressions.Regex.Split(input, pattern);
            ArrayList alRet = new ArrayList();
            foreach (string strItem in strItems)
            {
                if (strItem != "")
                {
                    alRet.Add(strItem);
                }
            }
            return alRet;
        }
        #endregion
		/////////////////////////////////////////////////////////////////////////////
		
		/////////////////////////////////////////////////////////////////////////////
		#region StrLeft-StrRight
		/// <summary>
		/// 在输入字符串(inputStr)中查找目标字符串(strToFound),并返回
		/// 目标字符串左边的字符串。如：
		/// 输入字符串:"C:\Temp\File.aspx"
		/// 目标字符串:"Temp"
		/// 返回字符串:"C:\"
		/// </summary>
		/// <param name="inputStr">输入字符串</param>
		/// <param name="strToFound">目标字符串</param>
		/// <param name="flag">true,如果没有找到目标字符串，则返回全部字符串
		///								false,如果没有找到目标字符串，则返回空字符串</param>
		/// <returns>如果没有找到目标字符串，则返回</returns>
		public static string StrLeft(string inputStr,string strToFound,bool flag)
		{
			//返回的字符串
			string returnValue = "";
			int position;

			//对输入字符串进行检查，如果为null，则返回null
			if(inputStr == null)return null;

			//查找目标字符串的位置
			position = inputStr.IndexOf(strToFound);

			//获得返回值
			if(position <= 0)
			{
				//没有找到目标字符串

				if(flag)
					//返回全部字符串
					returnValue = inputStr;
				else
					//返回空字符串
					returnValue = "";
			}
			else
			{
				//找到了目标字符串

				//获得返回值
				returnValue = inputStr.Substring(0 , position);
			}

			//返回值
			return returnValue;
		}


		/// <summary>
		/// 在输入字符串(inputStr)中查找目标字符串(strToFound),并返回
		/// 目标字符串右边的字符串。如：
		/// 输入字符串:"C:\Temp\File.aspx"
		/// 目标字符串:"Temp"
		/// 返回字符串:"\File.aspx"
		/// </summary>
		/// <param name="inputStr">输入字符串</param>
		/// <param name="strToFound">目标字符串</param>
		/// <param name="flag">true,如果没有找到目标字符串，则返回全部字符串
		///								false,如果没有找到目标字符串，则返回空字符串</param>
		/// <returns>如果没有找到目标字符串，则返回</returns>
		public static string StrRight(string inputStr,string strToFound,bool flag)
		{
			//返回的字符串
			string returnValue = "";
			int position;

			//对输入字符串进行检查，如果为null，则返回null
			if(inputStr == null)return null;

			//查找目标字符串的位置
			position = inputStr.IndexOf(strToFound);

			//获得返回值
			if(position < 0)
			{
				//没有找到目标字符串

				if(flag)
					//返回全部字符串
					returnValue = inputStr;
				else
					//返回空字符串
					returnValue = "";
			}
			else
			{
				//找到了目标字符串

				//获得返回值
				returnValue = inputStr.Substring(position + strToFound.Length);
			}

			//返回值
			return returnValue;
		}


		/// <summary>
		/// 在输入字符串(inputStr)中从右边开始查找目标字符串(strToFound),并返回
		/// 目标字符串左边的字符串。如：
		/// 输入字符串:"C:\Temp\File.aspx"
		/// 目标字符串:"e"
		/// 返回字符串:"C:\Temp\Fil"
		/// </summary>
		/// <param name="inputStr">输入字符串</param>
		/// <param name="strToFound">目标字符串</param>
		/// <param name="flag">true,如果没有找到目标字符串，则返回全部字符串
		///								false,如果没有找到目标字符串，则返回空字符串
		///	 </param>
		/// <returns>如果没有找到目标字符串，则返回</returns>
		public static string StrLeftBack(string inputStr,string strToFound,bool flag)
		{
			//返回的字符串
			string returnValue = "";
			int position;

			//对输入字符串进行检查，如果为null，则返回null
			if(inputStr == null)return null;

			//查找目标字符串的位置
			position = inputStr.LastIndexOf(strToFound);

			//获得返回值
			if(position <= 0)
			{
				//没有找到目标字符串

				if(flag)
					//返回全部字符串
					returnValue = inputStr;
				else
					//返回空字符串
					returnValue = "";
			}
			else
			{
				//找到了目标字符串

				//获得返回值
				returnValue = inputStr.Substring(0 , position);
			}

			//返回值
			return returnValue;
		}


		/// <summary>
		/// 在输入字符串(inputStr)中从右边开始查找目标字符串(strToFound),并返回
		/// 目标字符串右边的字符串。如：
		/// 输入字符串:"C:\Temp\File.aspx"
		/// 目标字符串:"e"
		/// 返回字符串:".aspx"
		/// </summary>
		/// <param name="inputStr">输入字符串</param>
		/// <param name="strToFound">目标字符串</param>
		/// <param name="flag">true,如果没有找到目标字符串，则返回全部字符串
		///								false,如果没有找到目标字符串，则返回空字符串</param>
		/// <returns>如果没有找到目标字符串，则返回</returns>
		public static string StrRightBack(string inputStr,string strToFound,bool flag)
		{
			//返回的字符串
			string returnValue = "";
			int position;

			//对输入字符串进行检查，如果为null，则返回null
			if(inputStr == null)return null;

			//查找目标字符串的位置
			position = inputStr.LastIndexOf(strToFound);

			//获得返回值
			if(position < 0)
			{
				//没有找到目标字符串

				if(flag)
					//返回全部字符串
					returnValue = inputStr;
				else
					//返回空字符串
					returnValue = "";
			}
			else
			{
				//找到了目标字符串

				//获得返回值
				returnValue = inputStr.Substring(position + strToFound.Length);
			}

			//返回值
			return returnValue;
		}
		#endregion StrLeft-StrRight
		/////////////////////////////////////////////////////////////////////////////
	} // End class StringUtility

	#region ValidCharacterSet Enum
	/// <summary>
	/// Selection of character sets used to validate data values.
	/// </summary>
	[Flags]
	public enum ValidCharacterSet
	{
		/// <summary>
		/// No characters.
		/// </summary>
		None			= 0,

		/// <summary>
		/// Numeric characters
		/// </summary>
		Numeric			= 1,

		/// <summary>
		/// Lower case characters
		/// </summary>
		Lowercase		= 2,

		/// <summary>
		/// Upper case characters
		/// </summary>
		Uppercase		= 4,

		/// <summary>
		/// Safe punctuation characters that can be used in HTML, XML
		/// and URLs.
		/// </summary>
		SafePunctuation = 8,		
		
		/// <summary>
		/// Any punctuation character
		/// </summary>
		Punctuation		= 16,

		/// <summary>
		/// Any character except the Null character.
		/// </summary>
		Any				= 32,

		/// <summary>
		/// The space character ' '
		/// </summary>
		Space			= 64 | mark_SingleCharacter,

		/// <summary>
		/// The tab character '	'
		/// </summary>
		Tab				= 128 | mark_SingleCharacter,

		/// <summary>
		/// Carriage return character '\r'
		/// </summary>
		CarriageReturn	= 256 | mark_SingleCharacter,

		/// <summary>
		/// Line feed character '\n'
		/// </summary>
		LineFeed		= 512 | mark_SingleCharacter,

		/// <summary>
		/// The NULL character
		/// </summary>
		Null			= 1024,

		/// <summary>
		/// The hyphen character '-'
		/// </summary>
		Hyphen			= 2048 | mark_SingleCharacter,

		/// <summary>
		/// The underscore character '_'
		/// </summary>
		Underscore		= 4096 | mark_SingleCharacter,

		/// <summary>
		/// The period character '.'
		/// </summary>
		Period			= 8192 | mark_SingleCharacter,

		/// <summary>
		/// The at character '@'
		/// </summary>
		At				= 16384 | mark_SingleCharacter,

		/// <summary>
		/// Currency values
		/// </summary>
		Currency		= 32678,

		/// <summary>
		/// Name space holder for defined values that are a combination
		/// of other values. Not intended for use by callees.
		/// </summary>
		mark_Combo				= 0xF000000,

		/// <summary>
		/// Name space holder for defined values that represent a single
		/// character. Not intended for use by callees.
		/// </summary>
		mark_SingleCharacter	= 0x0F00000,

		/// <summary>
		/// All characters.
		/// </summary>
		All = Any | Null | mark_Combo,

		/// <summary>
		/// Alphabetic charcaters
		/// </summary>
		Alpha = Lowercase | Uppercase | mark_Combo,
		
		/// <summary>
		/// Special white space characters that only affect linear formatting
		/// such as spaces and tabs.
		/// </summary>
		LinearWhitespace = Space | Tab | mark_Combo,

		/// <summary>
		/// Whitespace characters. Space, tab, linefeed, carriage return.
		/// </summary>
		Whitespace = Space | Tab | CarriageReturn | LineFeed | mark_Combo,

		/// <summary>
		/// Standard whitespace replacement characters such as the hyphen (-) 
		/// and the underscore (_) character.
		/// </summary>
		AltWhitespace = Hyphen | Underscore | mark_Combo,

		/// <summary>
		/// Both alphabetic and numeric characters.
		/// </summary>
		AlphaNumeric	= Alpha | Numeric | mark_Combo,

		/// <summary>
		/// Valid username characters.
		/// </summary>
		Username		= AlphaNumeric | Underscore | Period | At | Hyphen | mark_Combo,

		/// <summary>
		/// Valid password characters.
		/// </summary>
		Password		= Any | mark_Combo,

		/// <summary>
		/// Valid e-mail characters.
		/// </summary>
		Email			= Alpha | Underscore | Period | At | Hyphen | mark_Combo,

		/// <summary>
		/// Characters safe to use in an XML name.
		/// </summary>
		XmlName			= Alpha | Numeric | AltWhitespace | mark_Combo,

		/// <summary>
		/// Characters safe to use in a URL.
		/// </summary>
		Url				= Alpha | Numeric | SafePunctuation | mark_Combo,
	}
	#endregion

	#region CreditCardType Enum
	/// <summary>
	/// Known credit card types.
	/// </summary>
	[ Flags ]
	public enum CreditCardType
	{
		/// <summary>
		/// Unknown
		/// </summary>
		Unknown				= 0,
		/// <summary>
		/// MasterCard
		/// </summary>
		MasterCard			= 1,
		/// <summary>
		/// Visa
		/// </summary>
		Visa				= 2,
		/// <summary>
		/// Discover
		/// </summary>
		Discover			= 4,
		/// <summary>
		/// AmericanExpress
		/// </summary>
		AmericanExpress		= 8,
		/// <summary>
		/// CarteBlanche
		/// </summary>
		CarteBlanche		= 16,
		/// <summary>
		/// DinersClub
		/// </summary>
		DinersClub			= 32,
		/// <summary>
		/// Common
		/// </summary>
		Common				= MasterCard | Visa,
		/// <summary>
		/// Major
		/// </summary>
		Major				= MasterCard | Visa | AmericanExpress,
		/// <summary>
		/// Any
		/// </summary>
		Any					= MasterCard | Visa | Discover | AmericanExpress | CarteBlanche | DinersClub
	} // End enum CreditCardType
	#endregion

} // End namespace Xheo
////////////////////////////////////////////////////////////////////////////////
#region Copyright (C) 2002 Paul Alexander. All Rights Reserved.
#endregion
////////////////////////////////////////////////////////////////////////////////