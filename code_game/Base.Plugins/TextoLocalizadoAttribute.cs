using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Assets;
using Assets.Base.Plugins.Runtime.UI;

// Token: 0x02000047 RID: 71
[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public abstract class TextoLocalizadoAttribute : OrderAttribute
{
	// Token: 0x06000254 RID: 596 RVA: 0x0000C3B4 File Offset: 0x0000A5B4
	public TextoLocalizadoAttribute()
		: base(0)
	{
	}

	// Token: 0x06000255 RID: 597 RVA: 0x0000C3BD File Offset: 0x0000A5BD
	public TextoLocalizadoAttribute(string text, string localizationID)
		: this(text)
	{
		if (localizationID == null)
		{
			throw new ArgumentNullException("localizationID", "localizationID null reference.");
		}
		this.localizationID = localizationID;
	}

	// Token: 0x06000256 RID: 598 RVA: 0x0000C3E0 File Offset: 0x0000A5E0
	public TextoLocalizadoAttribute(string text)
		: base(0)
	{
		if (text == null)
		{
			throw new ArgumentNullException("text", "text null reference.");
		}
		this.text = text;
	}

	// Token: 0x17000033 RID: 51
	// (get) Token: 0x06000257 RID: 599 RVA: 0x0000C403 File Offset: 0x0000A603
	// (set) Token: 0x06000258 RID: 600 RVA: 0x0000C40B File Offset: 0x0000A60B
	public string localizationID { get; set; }

	// Token: 0x17000034 RID: 52
	// (get) Token: 0x06000259 RID: 601 RVA: 0x0000C414 File Offset: 0x0000A614
	// (set) Token: 0x0600025A RID: 602 RVA: 0x0000C41C File Offset: 0x0000A61C
	public string text { get; set; }

	// Token: 0x0600025B RID: 603 RVA: 0x0000C428 File Offset: 0x0000A628
	public static string Localizado(MemberInfo fieldInfo, string localizacion)
	{
		string text;
		if (TextoLocalizadoAttribute.m_localizedStringsForMembers.TryGetValue(new ValueTuple<MemberInfo, Type, string>(fieldInfo, typeof(TextoLocalizadoAttribute), localizacion), out text))
		{
			return text;
		}
		return TextoLocalizadoAttribute.GetCurrentLocalization<TextoLocalizadoAttribute>(fieldInfo, fieldInfo.GetCustomAttributes(), localizacion);
	}

	// Token: 0x0600025C RID: 604 RVA: 0x0000C464 File Offset: 0x0000A664
	public static string Localizado<T_Buscando>(MemberInfo fieldInfo, string localizacion) where T_Buscando : TextoLocalizadoAttribute
	{
		string text;
		if (TextoLocalizadoAttribute.m_localizedStringsForMembers.TryGetValue(new ValueTuple<MemberInfo, Type, string>(fieldInfo, typeof(T_Buscando), localizacion), out text))
		{
			return text;
		}
		return TextoLocalizadoAttribute.GetCurrentLocalization<T_Buscando>(fieldInfo, fieldInfo.GetCustomAttributes(), localizacion);
	}

	// Token: 0x0600025D RID: 605 RVA: 0x0000C4A0 File Offset: 0x0000A6A0
	private static string GetCurrentLocalization<T_Buscando>(MemberInfo fieldInfo, IEnumerable<Attribute> atributes, string localizacion) where T_Buscando : TextoLocalizadoAttribute
	{
		TextoLocalizadoAttribute.<>c__DisplayClass16_0<T_Buscando> CS$<>8__locals1;
		CS$<>8__locals1.fieldInfo = fieldInfo;
		CS$<>8__locals1.localizacion = localizacion;
		string text;
		try
		{
			foreach (Attribute attribute in atributes)
			{
				if (attribute is T_Buscando)
				{
					TextoLocalizadoAttribute.m_TempTEXTLOCAL.Add((T_Buscando)((object)attribute));
				}
			}
			if (TextoLocalizadoAttribute.m_TempTEXTLOCAL.Count == 0)
			{
				text = null;
			}
			else if (TextoLocalizadoAttribute.m_TempTEXTLOCAL.Count == 1)
			{
				text = TextoLocalizadoAttribute.<GetCurrentLocalization>g__TryAddAndReturn|16_0<T_Buscando>(TextoLocalizadoAttribute.m_TempTEXTLOCAL[0] as T_Buscando, ref CS$<>8__locals1);
			}
			else
			{
				foreach (TextoLocalizadoAttribute textoLocalizadoAttribute in TextoLocalizadoAttribute.m_TempTEXTLOCAL)
				{
					if (string.Equals(CS$<>8__locals1.localizacion, textoLocalizadoAttribute.localizationID, StringComparison.InvariantCultureIgnoreCase))
					{
						return TextoLocalizadoAttribute.<GetCurrentLocalization>g__TryAddAndReturn|16_0<T_Buscando>(textoLocalizadoAttribute as T_Buscando, ref CS$<>8__locals1);
					}
				}
				text = TextoLocalizadoAttribute.<GetCurrentLocalization>g__TryAddAndReturn|16_0<T_Buscando>(TextoLocalizadoAttribute.m_TempTEXTLOCAL[0] as T_Buscando, ref CS$<>8__locals1);
			}
		}
		finally
		{
			TextoLocalizadoAttribute.m_TempTEXTLOCAL.Clear();
		}
		return text;
	}

	// Token: 0x0600025E RID: 606 RVA: 0x0000C5F0 File Offset: 0x0000A7F0
	public static string Localizado<Tenum, TLocal>(Tenum valor, string localizacion) where Tenum : Enum, IConvertible where TLocal : TextoLocalizadoAttribute
	{
		Type typeFromHandle = typeof(Tenum);
		Type typeFromHandle2 = typeof(TLocal);
		Dictionary<string, string> dictionary;
		TextoLocalizadoAttribute.InitLocalStringsEnum(typeFromHandle, valor, out dictionary, typeFromHandle2);
		return TextoLocalizadoAttribute.GetEnumLocalizado(typeFromHandle, valor, dictionary, localizacion);
	}

	// Token: 0x0600025F RID: 607 RVA: 0x0000C630 File Offset: 0x0000A830
	public static string Localizado<Tenum>(Tenum valor, string localizacion) where Tenum : Enum, IConvertible
	{
		Type typeFromHandle = typeof(Tenum);
		Dictionary<string, string> dictionary;
		TextoLocalizadoAttribute.InitLocalStringsEnum(typeFromHandle, valor, out dictionary, null);
		return TextoLocalizadoAttribute.GetEnumLocalizado(typeFromHandle, valor, dictionary, localizacion);
	}

	// Token: 0x06000260 RID: 608 RVA: 0x0000C664 File Offset: 0x0000A864
	public static string Localizado(Type enumType, object enumValue, string localizacion)
	{
		Dictionary<string, string> dictionary;
		TextoLocalizadoAttribute.InitLocalStringsEnum(enumType, enumValue, out dictionary, null);
		return TextoLocalizadoAttribute.GetEnumLocalizado(enumType, enumValue, dictionary, localizacion);
	}

	// Token: 0x06000261 RID: 609 RVA: 0x0000C684 File Offset: 0x0000A884
	public static string Localizado(Type enumType, Type localType, object enumValue, string localizacion)
	{
		Dictionary<string, string> dictionary;
		TextoLocalizadoAttribute.InitLocalStringsEnum(enumType, enumValue, out dictionary, localType);
		return TextoLocalizadoAttribute.GetEnumLocalizado(enumType, enumValue, dictionary, localizacion);
	}

	// Token: 0x06000262 RID: 610 RVA: 0x0000C6A4 File Offset: 0x0000A8A4
	private static string GetEnumLocalizado(Type enumType, object enumValue, Dictionary<string, string> dicc, string localizacion)
	{
		string text;
		if (dicc.TryGetValue(localizacion, out text))
		{
			return text;
		}
		if (dicc.TryGetValue(Localizacion.US.ToString(), out text))
		{
			return text;
		}
		return Enum.GetName(enumType, enumValue);
	}

	// Token: 0x06000263 RID: 611 RVA: 0x0000C6E0 File Offset: 0x0000A8E0
	private static void InitLocalStringsEnum(Type enumType, object enumValue, out Dictionary<string, string> dicc, Type localType = null)
	{
		int num = Convert.ToInt32(enumValue);
		if (localType == null)
		{
			localType = typeof(TextoLocalizadoAttribute);
		}
		ValueTuple<Type, Type, int> valueTuple = new ValueTuple<Type, Type, int>(enumType, localType, num);
		if (!TextoLocalizadoAttribute.m_localizedStringsForEnums.TryGetValue(valueTuple, out dicc))
		{
			dicc = new Dictionary<string, string>();
			TextoLocalizadoAttribute.m_localizedStringsForEnums.Add(valueTuple, dicc);
			TextoLocalizadoAttribute.InitLocalEnum(enumType, localType, enumValue, dicc);
		}
	}

	// Token: 0x06000264 RID: 612 RVA: 0x0000C740 File Offset: 0x0000A940
	private static void InitLocalEnum(Type enumType, Type localType, object enumValue, Dictionary<string, string> dicc)
	{
		string name = Enum.GetName(enumType, enumValue);
		IEnumerable<TextoLocalizadoAttribute> enumerable = enumType.GetField(name).GetCustomAttributes(false).OfType<TextoLocalizadoAttribute>();
		if (localType != typeof(TextoLocalizadoAttribute))
		{
			enumerable = enumerable.Where((TextoLocalizadoAttribute a) => a.GetType() == localType);
		}
		foreach (TextoLocalizadoAttribute textoLocalizadoAttribute in enumerable)
		{
			if (!dicc.ContainsKey(textoLocalizadoAttribute.localizationID))
			{
				dicc.Add(textoLocalizadoAttribute.localizationID, textoLocalizadoAttribute.text);
			}
		}
	}

	// Token: 0x06000266 RID: 614 RVA: 0x0000C818 File Offset: 0x0000AA18
	[CompilerGenerated]
	internal static string <GetCurrentLocalization>g__TryAddAndReturn|16_0<T_Buscando>(T_Buscando local, ref TextoLocalizadoAttribute.<>c__DisplayClass16_0<T_Buscando> A_1) where T_Buscando : TextoLocalizadoAttribute
	{
		if (local == null)
		{
			return null;
		}
		TextoLocalizadoAttribute.m_localizedStringsForMembers.TryAdd(new ValueTuple<MemberInfo, Type, string>(A_1.fieldInfo, typeof(T_Buscando), A_1.localizacion), local.text);
		return local.text;
	}

	// Token: 0x04000083 RID: 131
	private static Dictionary<ValueTuple<Type, Type, int>, Dictionary<string, string>> m_localizedStringsForEnums = new Dictionary<ValueTuple<Type, Type, int>, Dictionary<string, string>>();

	// Token: 0x04000084 RID: 132
	[TupleElementNames(new string[] { "fieldInfo", "localizationTypo", "localizacion" })]
	private static Dictionary<ValueTuple<MemberInfo, Type, string>, string> m_localizedStringsForMembers = new Dictionary<ValueTuple<MemberInfo, Type, string>, string>();

	// Token: 0x04000085 RID: 133
	private static List<TextoLocalizadoAttribute> m_TempTEXTLOCAL = new List<TextoLocalizadoAttribute>();
}
