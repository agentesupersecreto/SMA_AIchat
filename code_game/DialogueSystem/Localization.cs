using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000025 RID: 37
	public static class Localization
	{
		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x00008DF0 File Offset: 0x00006FF0
		// (set) Token: 0x060001F1 RID: 497 RVA: 0x00008DF8 File Offset: 0x00006FF8
		public static string Language { get; set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x00008E00 File Offset: 0x00007000
		public static bool IsDefaultLanguage
		{
			get
			{
				return string.IsNullOrEmpty(Localization.Language);
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x00008E0C File Offset: 0x0000700C
		// (set) Token: 0x060001F4 RID: 500 RVA: 0x00008E14 File Offset: 0x00007014
		public static bool UseDefaultIfUndefined
		{
			get
			{
				return Localization.useDefaultIfUndefined;
			}
			set
			{
				Localization.useDefaultIfUndefined = value;
			}
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00008E1C File Offset: 0x0000701C
		public static string GetLanguage(SystemLanguage systemLanguage)
		{
			switch (systemLanguage)
			{
			case SystemLanguage.Afrikaans:
				return "af";
			case SystemLanguage.Arabic:
				return "ar";
			case SystemLanguage.Basque:
				return "eu";
			case SystemLanguage.Belarusian:
				return "be";
			case SystemLanguage.Bulgarian:
				return "bg";
			case SystemLanguage.Catalan:
				return "ca";
			case SystemLanguage.Chinese:
				return "zh";
			case SystemLanguage.Czech:
				return "cs";
			case SystemLanguage.Danish:
				return "da";
			case SystemLanguage.Dutch:
				return "nl";
			case SystemLanguage.English:
				return "en";
			case SystemLanguage.Estonian:
				return "et";
			case SystemLanguage.Faroese:
				return "fo";
			case SystemLanguage.Finnish:
				return "fi";
			case SystemLanguage.French:
				return "fr";
			case SystemLanguage.German:
				return "de";
			case SystemLanguage.Greek:
				return "el";
			case SystemLanguage.Hebrew:
				return "he";
			case SystemLanguage.Hungarian:
				return "hu";
			case SystemLanguage.Icelandic:
				return "is";
			case SystemLanguage.Indonesian:
				return "id";
			case SystemLanguage.Italian:
				return "it";
			case SystemLanguage.Japanese:
				return "ja";
			case SystemLanguage.Korean:
				return "ko";
			case SystemLanguage.Latvian:
				return "lv";
			case SystemLanguage.Lithuanian:
				return "lt";
			case SystemLanguage.Norwegian:
				return "no";
			case SystemLanguage.Polish:
				return "pl";
			case SystemLanguage.Portuguese:
				return "pt";
			case SystemLanguage.Romanian:
				return "ro";
			case SystemLanguage.Russian:
				return "ru";
			case SystemLanguage.SerboCroatian:
				return "sr";
			case SystemLanguage.Slovak:
				return "sk";
			case SystemLanguage.Slovenian:
				return "sl";
			case SystemLanguage.Spanish:
				return "es";
			case SystemLanguage.Swedish:
				return "sv";
			case SystemLanguage.Thai:
				return "th";
			case SystemLanguage.Turkish:
				return "tr";
			case SystemLanguage.Ukrainian:
				return "uk";
			case SystemLanguage.Vietnamese:
				return "vi";
			default:
				return null;
			}
		}

		// Token: 0x040000D7 RID: 215
		private static bool useDefaultIfUndefined = true;
	}
}
