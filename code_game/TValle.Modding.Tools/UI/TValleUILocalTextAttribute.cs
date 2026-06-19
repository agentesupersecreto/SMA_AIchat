using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.TValle.Tools.Runtime.UI
{
	// Token: 0x0200000D RID: 13
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
	public abstract class TValleUILocalTextAttribute : TValleUIAttribute
	{
		// Token: 0x06000029 RID: 41 RVA: 0x00002718 File Offset: 0x00000918
		public TValleUILocalTextAttribute()
			: base(0)
		{
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002728 File Offset: 0x00000928
		public TValleUILocalTextAttribute(string text, Language localizationID)
			: this(text)
		{
			this.localizationID = localizationID;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002738 File Offset: 0x00000938
		public TValleUILocalTextAttribute(string text)
			: base(0)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text", "text null reference.");
			}
			this.text = text;
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00002762 File Offset: 0x00000962
		// (set) Token: 0x0600002D RID: 45 RVA: 0x0000276A File Offset: 0x0000096A
		public Language localizationID { get; set; } = Language.en;

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002773 File Offset: 0x00000973
		// (set) Token: 0x0600002F RID: 47 RVA: 0x0000277B File Offset: 0x0000097B
		public string text { get; set; }

		// Token: 0x06000030 RID: 48 RVA: 0x00002784 File Offset: 0x00000984
		public static string Localizado<Tenum, TLocal>(Tenum valor, Language localizacion) where Tenum : Enum, IConvertible where TLocal : TValleUILocalTextAttribute
		{
			Type typeFromHandle = typeof(Tenum);
			Type typeFromHandle2 = typeof(TLocal);
			Dictionary<Language, ValueTuple<string, string>> dictionary;
			TValleUILocalTextAttribute.InitLocalStrings(typeFromHandle, valor, out dictionary, typeFromHandle2);
			return TValleUILocalTextAttribute.GetLocalizado(typeFromHandle, valor, dictionary, localizacion, false);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000027C4 File Offset: 0x000009C4
		public static string Localizado<Tenum>(Tenum valor, Language localizacion) where Tenum : Enum, IConvertible
		{
			Type typeFromHandle = typeof(Tenum);
			Dictionary<Language, ValueTuple<string, string>> dictionary;
			TValleUILocalTextAttribute.InitLocalStrings(typeFromHandle, valor, out dictionary, null);
			return TValleUILocalTextAttribute.GetLocalizado(typeFromHandle, valor, dictionary, localizacion, false);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000027F8 File Offset: 0x000009F8
		public static string Localizado(Type enumType, object enumValue, Language localizacion)
		{
			Dictionary<Language, ValueTuple<string, string>> dictionary;
			TValleUILocalTextAttribute.InitLocalStrings(enumType, enumValue, out dictionary, null);
			return TValleUILocalTextAttribute.GetLocalizado(enumType, enumValue, dictionary, localizacion, false);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x0000281C File Offset: 0x00000A1C
		public static string Localizado(Type enumType, Type localType, object enumValue, Language localizacion)
		{
			Dictionary<Language, ValueTuple<string, string>> dictionary;
			TValleUILocalTextAttribute.InitLocalStrings(enumType, enumValue, out dictionary, localType);
			return TValleUILocalTextAttribute.GetLocalizado(enumType, enumValue, dictionary, localizacion, false);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002840 File Offset: 0x00000A40
		public static string LocalizadoFirstCharToUpper<Tenum>(Tenum valor, Language localizacion) where Tenum : Enum, IConvertible
		{
			Type typeFromHandle = typeof(Tenum);
			Dictionary<Language, ValueTuple<string, string>> dictionary;
			TValleUILocalTextAttribute.InitLocalStrings(typeFromHandle, valor, out dictionary, null);
			return TValleUILocalTextAttribute.GetLocalizado(typeFromHandle, valor, dictionary, localizacion, true);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002874 File Offset: 0x00000A74
		private static string GetLocalizado(Type enumType, object enumValue, Dictionary<Language, ValueTuple<string, string>> dicc, Language localizacion, bool upperFirst)
		{
			ValueTuple<string, string> valueTuple;
			if (dicc.TryGetValue(localizacion, out valueTuple))
			{
				if (!upperFirst)
				{
					return valueTuple.Item2;
				}
				return valueTuple.Item1;
			}
			else
			{
				if (!dicc.TryGetValue(Language.en, out valueTuple))
				{
					return Enum.GetName(enumType, enumValue);
				}
				if (!upperFirst)
				{
					return valueTuple.Item2;
				}
				return valueTuple.Item1;
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000028C4 File Offset: 0x00000AC4
		private static void InitLocalStrings(Type enumType, object enumValue, out Dictionary<Language, ValueTuple<string, string>> dicc, Type localType = null)
		{
			int num = Convert.ToInt32(enumValue);
			if (localType == null)
			{
				localType = typeof(TValleUILocalTextAttribute);
			}
			ValueTuple<Type, Type, int> valueTuple = new ValueTuple<Type, Type, int>(enumType, localType, num);
			if (!TValleUILocalTextAttribute.m_localizedStrings.TryGetValue(valueTuple, out dicc))
			{
				dicc = new Dictionary<Language, ValueTuple<string, string>>();
				TValleUILocalTextAttribute.m_localizedStrings.Add(valueTuple, dicc);
				TValleUILocalTextAttribute.InitLocal(enumType, localType, enumValue, dicc);
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002924 File Offset: 0x00000B24
		private static void InitLocal(Type enumType, Type localType, object enumValue, Dictionary<Language, ValueTuple<string, string>> dicc)
		{
			string name = Enum.GetName(enumType, enumValue);
			TValleUILocalTextAttribute[] array = enumType.GetField(name).GetCustomAttributes(false).OfType<TValleUILocalTextAttribute>()
				.ToArray<TValleUILocalTextAttribute>();
			if (localType != typeof(TValleUILocalTextAttribute))
			{
				array = array.Where((TValleUILocalTextAttribute a) => a.GetType() == localType).ToArray<TValleUILocalTextAttribute>();
			}
			if (array.Length != 0)
			{
				foreach (TValleUILocalTextAttribute tvalleUILocalTextAttribute in array)
				{
					if (!dicc.ContainsKey(tvalleUILocalTextAttribute.localizationID))
					{
						dicc.Add(tvalleUILocalTextAttribute.localizationID, new ValueTuple<string, string>(tvalleUILocalTextAttribute.text, TValleUILocalTextAttribute.FirstCharToUpper(tvalleUILocalTextAttribute.text)));
					}
				}
				return;
			}
			dicc.Add(Language.en, new ValueTuple<string, string>(name, TValleUILocalTextAttribute.FirstCharToUpper(name)));
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000029F4 File Offset: 0x00000BF4
		public static string FirstCharToUpper(string input)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			if (!(input == ""))
			{
				return input[0].ToString().ToUpper() + input.Substring(1);
			}
			throw new ArgumentException("input cannot be empty", "input");
		}

		// Token: 0x0400001B RID: 27
		private static Dictionary<ValueTuple<Type, Type, int>, Dictionary<Language, ValueTuple<string, string>>> m_localizedStrings = new Dictionary<ValueTuple<Type, Type, int>, Dictionary<Language, ValueTuple<string, string>>>();
	}
}
