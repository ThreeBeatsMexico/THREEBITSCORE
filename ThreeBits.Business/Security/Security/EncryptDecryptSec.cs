using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Business.Security.Security
{
	public class EncryptDecryptSec
	{
		private string _version;

		private int[] S;

		private string cls_Key;

		private string Key
		{
			get
			{
				return cls_Key;
			}
			set
			{
				cls_Key = value;
			}
		}

		private string Version => _version;

		public EncryptDecryptSec()
		{
			_version = "1.0.1";
			S = new int[256];
		}

		private EncryptDecryptSec(string Key)
		{
			_version = "1.0.1";
			S = new int[256];
			this.Key = Key;
		}

		private string Crypt(string Param)
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			int length = Param.Length;
			StringBuilder stringBuilder = new StringBuilder();
			CreateKeyArray();
			checked
			{
				int num = length - 1;
				int num2 = 0;
				int num4 = 0;
				int num5 = 0;
				while (true)
				{
					int num7 = num2;
					int num3 = num;
					if (num7 > num3)
					{
						break;
					}
					num4 = (num4 + 1) & 0xFF;
					num5 = (num5 + S[num4]) & 0xFF;
					int num6 = S[num4];
					S[num4] = S[num5];
					S[num5] = num6;
					num6 = (S[num4] + S[num5]) & 0xFF;
					stringBuilder.Append(Strings.Chr(Strings.Asc(Param.Substring(num2, 1)) ^ S[num6]));
					num2++;
				}
				return stringBuilder.ToString();
			}
		}

		private string CryptFile(string FilePath)
		{
			checked
			{
				if (new FileInfo(FilePath).Exists)
				{
					FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
					StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
					if (fileStream.CanRead)
					{
						string text = streamReader.ReadToEnd();
						int length = text.Length;
						StringBuilder stringBuilder = new StringBuilder();
						CreateKeyArray();
						int num = length - 1;
						int num2 = 0;
						int num4 = 0;
						int num5 = 0;
						while (true)
						{
							int num7 = num2;
							int num3 = num;
							if (num7 > num3)
							{
								break;
							}
							num4 = (num4 + 1) & 0xFF;
							num5 = (num5 + S[num4]) & 0xFF;
							int num6 = S[num4];
							S[num4] = S[num5];
							S[num5] = num6;
							num6 = (S[num4] + S[num5]) & 0xFF;
							stringBuilder.Append(Strings.Chr(Strings.Asc(text.Substring(num2, 1)) ^ S[num6]));
							num2++;
						}
						return stringBuilder.ToString();
					}
					throw new Exception("Impossible de lire le fichier " + FilePath);
				}
				throw new Exception("Impossible de trouver le fichier " + FilePath);
			}
		}

		private long CryptFile(string FilePath, string OutPutFile)
		{
			checked
			{
				if (new FileInfo(FilePath).Exists)
				{
					FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
					StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
					if (fileStream.CanRead)
					{
						string text = streamReader.ReadToEnd();
						fileStream.Close();
						streamReader.Close();
						int length = text.Length;
						StringBuilder stringBuilder = new StringBuilder();
						CreateKeyArray();
						int num = length - 1;
						int num2 = 0;
						int num4 = 0;
						int num5 = 0;
						while (true)
						{
							int num7 = num2;
							int num3 = num;
							if (num7 > num3)
							{
								break;
							}
							num4 = (num4 + 1) & 0xFF;
							num5 = (num5 + S[num4]) & 0xFF;
							int num6 = S[num4];
							S[num4] = S[num5];
							S[num5] = num6;
							num6 = (S[num4] + S[num5]) & 0xFF;
							stringBuilder.Append(Strings.Chr(Strings.Asc(text.Substring(num2, 1)) ^ S[num6]));
							num2++;
						}
						StreamWriter streamWriter = new StreamWriter(new FileStream(OutPutFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite), Encoding.Default);
						try
						{
							streamWriter.Write(stringBuilder.ToString());
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							throw new Exception("Impossible d'écrire le fichier de sortie " + OutPutFile);
						}
						streamWriter.Close();
						return 0L;
					}
					throw new Exception("Impossible de lire le fichier " + FilePath);
				}
				throw new Exception("Impossible de trouver le fichier " + FilePath);
			}
		}

		private string Decrypt(string Param)
		{
			int num8 = Strings.Len(Param);
			StringBuilder stringBuilder = new StringBuilder();
			CreateKeyArray();
			checked
			{
				int num2 = num8 - 1;
				int num3 = 0;
				int num5 = 0;
				int num6 = 0;
				while (true)
				{
					int num9 = num3;
					int num4 = num2;
					if (num9 > num4)
					{
						break;
					}
					num5 = (num5 + 1) & 0xFF;
					num6 = (num6 + S[num5]) & 0xFF;
					int num7 = S[num5];
					S[num5] = S[num6];
					S[num6] = num7;
					num7 = (S[num5] + S[num6]) & 0xFF;
					stringBuilder.Append(Strings.Chr(Strings.Asc(Param.Substring(num3, 1)) ^ S[num7]));
					num3++;
				}
				return stringBuilder.ToString();
			}
		}

		private string DecryptFile(string FilePath)
		{
			checked
			{
				if (new FileInfo(FilePath).Exists)
				{
					FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
					StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
					if (fileStream.CanRead)
					{
						string text = streamReader.ReadToEnd();
						int length = text.Length;
						StringBuilder stringBuilder = new StringBuilder();
						CreateKeyArray();
						int num = length - 1;
						int num2 = 0;
						int num4 = 0;
						int num5 = 0;
						while (true)
						{
							int num7 = num2;
							int num3 = num;
							if (num7 > num3)
							{
								break;
							}
							num4 = (num4 + 1) & 0xFF;
							num5 = (num5 + S[num4]) & 0xFF;
							int num6 = S[num4];
							S[num4] = S[num5];
							S[num5] = num6;
							num6 = (S[num4] + S[num5]) & 0xFF;
							stringBuilder.Append(Strings.Chr(Strings.Asc(text.Substring(num2, 1)) ^ S[num6]));
							num2++;
						}
						return stringBuilder.ToString();
					}
					throw new Exception("Impossible de lire le fichier " + FilePath);
				}
				throw new Exception("Impossible de trouver le fichier " + FilePath);
			}
		}

		private long DecryptFile(string FilePath, string OutPutFile)
		{
			checked
			{
				if (new FileInfo(FilePath).Exists)
				{
					FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
					StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
					if (fileStream.CanRead)
					{
						string text = streamReader.ReadToEnd();
						int length = text.Length;
						StringBuilder stringBuilder = new StringBuilder();
						CreateKeyArray();
						int num = length - 1;
						int num2 = 0;
						int num4 = 0;
						int num5 = 0;
						while (true)
						{
							int num7 = num2;
							int num3 = num;
							if (num7 > num3)
							{
								break;
							}
							num4 = (num4 + 1) & 0xFF;
							num5 = (num5 + S[num4]) & 0xFF;
							int num6 = S[num4];
							S[num4] = S[num5];
							S[num5] = num6;
							num6 = (S[num4] + S[num5]) & 0xFF;
							stringBuilder.Append(Strings.Chr(Strings.Asc(text.Substring(num2, 1)) ^ S[num6]));
							num2++;
						}
						StreamWriter streamWriter = new StreamWriter(new FileStream(OutPutFile, FileMode.Create, FileAccess.Write, FileShare.None), Encoding.Default);
						try
						{
							streamWriter.Write(stringBuilder.ToString());
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							throw new Exception("Impossible d'écrire le fichier de sortie " + OutPutFile);
						}
						streamWriter.Close();
						return 0L;
					}
					throw new Exception("Impossible de lire le fichier " + FilePath);
				}
				throw new Exception("Impossible de trouver le fichier " + FilePath);
			}
		}

		private void CreateKeyArray()
		{
			int num = 0;
			int num2 = 0;
			checked
			{
				if (Key.Trim().Length > 0)
				{
					int length = cls_Key.Length;
					num = 0;
					int num3;
					int num4;
					do
					{
						S[num] = num;
						num++;
						num3 = num;
						num4 = 255;
					}
					while (num3 <= num4);
					num = 0;
					int num6;
					do
					{
						num2 = (num2 + S[num] + Strings.Asc(cls_Key.Substring(unchecked(num % length), 1))) & 0xFF;
						int num5 = S[num];
						S[num] = S[num2];
						S[num2] = num5;
						num++;
						num6 = num;
						num4 = 255;
					}
					while (num6 <= num4);
					num = 0;
					num2 = 0;
					return;
				}
				throw new ArgumentException("La clef est vide");
			}
		}

		private string GenerateKey()
		{
			StringBuilder stringBuilder = new StringBuilder();
			short num = 255;
			VBMath.Randomize(DateAndTime.Today.Millisecond);
			checked
			{
				for (int i = 0; i < num; i++)
				{
					stringBuilder.Append(Strings.Chr((int)Math.Round(VBMath.Rnd(255f))));
				}
				Key = stringBuilder.ToString();
				return stringBuilder.ToString();
			}
		}

		private string GenerateKey(int KeyLen)
		{
			StringBuilder stringBuilder = new StringBuilder();
			VBMath.Randomize(DateAndTime.Today.Millisecond);
			checked
			{
				for (int i = 0; i < KeyLen; i++)
				{
					stringBuilder.Append(Strings.Chr((int)Math.Round(VBMath.Rnd(255f))));
				}
				Key = stringBuilder.ToString();
				return stringBuilder.ToString();
			}
		}

		private string GenerateKey(int KeyLen, bool Readable)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			checked
			{
				int num = text.Length - 1;
				VBMath.Randomize(DateAndTime.Today.Millisecond);
				int i = 0;
				if (Readable)
				{
					for (; i < KeyLen; i++)
					{
						stringBuilder.Append(text.Substring((int)Math.Round(VBMath.Rnd(num)), 1));
					}
				}
				else
				{
					for (; i < KeyLen; i++)
					{
						stringBuilder.Append(Strings.Chr((int)Math.Round(VBMath.Rnd(255f))));
					}
				}
				Key = stringBuilder.ToString();
				return stringBuilder.ToString();
			}
		}

		private string GenerateKey(int KeyLen, string AvailableChar)
		{
			StringBuilder stringBuilder = new StringBuilder();
			checked
			{
				int num = AvailableChar.Length - 1;
				VBMath.Randomize(DateAndTime.Today.Millisecond);
				for (int i = 0; i < KeyLen; i++)
				{
					stringBuilder.Append(AvailableChar.Substring((int)Math.Round(VBMath.Rnd(num)), 1));
				}
				Key = stringBuilder.ToString();
				return stringBuilder.ToString();
			}
		}

		private string ConvToHex(int x)
		{
			if (x > 9)
			{
				return Conversions.ToString(Strings.Chr(checked(x + 55)));
			}
			return Conversions.ToString(x);
		}

		private object Encriptar(object DataValue)
		{
			long num6 = 1L;
			long num2 = Strings.Len(RuntimeHelpers.GetObjectValue(DataValue));
			long num3 = num6;
			string text3 = null;
			checked
			{
				while (true)
				{
					long num7 = num3;
					long num4 = num2;
					if (num7 > num4)
					{
						break;
					}
					string text = Strings.Mid(Conversions.ToString(DataValue), (int)num3, 1);
					int num5 = (int)Math.Round(Conversion.Int((double)Strings.Asc(text) / 16.0));
					if (num5 * 16 < Strings.Asc(text))
					{
						string text2 = ConvToHex(Strings.Asc(text) - num5 * 16);
						text3 = text3 + ConvToHex(num5) + text2;
					}
					else
					{
						text3 = text3 + ConvToHex(num5) + "0";
					}
					num3++;
				}
				return text3;
			}
		}

		private int ConvToInt(string x)
		{
			string text = Strings.Mid(x, 1, 1);
			string text2 = Strings.Mid(x, 2, 1);
			checked
			{
				int num = ((!Versioned.IsNumeric(text)) ? ((Strings.Asc(text) - 55) * 16) : Conversions.ToInteger(Operators.MultiplyObject(16, Conversion.Int(text))));
				if (Versioned.IsNumeric(text2))
				{
					return Conversions.ToInteger(Operators.AddObject(num, Conversion.Int(text2)));
				}
				return num + (Strings.Asc(text2) - 55);
			}
		}

		public object Desencriptar(object DataValue)
		{
			int num7 = 0;
			checked
			{
				object result;
				try
				{
					ProjectData.ClearProjectError();
					long num8 = 1L;
					long num4 = Strings.Len(RuntimeHelpers.GetObjectValue(DataValue));
					long num5 = num8;
					string text = null;
					while (true)
					{
						long num9 = num5;
						long num6 = num4;
						if (num9 > num6)
						{
							break;
						}
						string x = Strings.Mid(Conversions.ToString(DataValue), (int)num5, 2);
						text += Conversions.ToString(Strings.Chr(ConvToInt(x)));
						num5 += 2;
					}
					result = text;
				}
				catch
				{
					result = null;
				}
				if (num7 != 0)
				{
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		public string EncryptString(string Cadena, string Llave)
		{
			if (Operators.CompareString(Llave, "", false) == 0)
			{
				Llave = "599E9A82";
			}
			Key = Llave;
			object obj = Crypt(Cadena);
			return Conversions.ToString(Encriptar(RuntimeHelpers.GetObjectValue(obj)));
		}

		public string DecryptString(string Cadena, string Llave)
		{
			if (Operators.CompareString(Llave, "", false) == 0)
			{
				Llave = "599E9A82";
			}
			Key = Llave;
			object objectValue = RuntimeHelpers.GetObjectValue(Desencriptar(Cadena));
			return Decrypt(Conversions.ToString(objectValue));
		}
	}
}
