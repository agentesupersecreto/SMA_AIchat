using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Assets
{
	// Token: 0x02000169 RID: 361
	public static class StringExt
	{
		// Token: 0x06000AAD RID: 2733 RVA: 0x00024292 File Offset: 0x00022492
		public static bool HasPlaceholder(this string s)
		{
			return Regex.IsMatch(s, "{\\d+}");
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x000242A0 File Offset: 0x000224A0
		public static string JointUniqueWords(this string s, string other)
		{
			string[] array = s.Split(' ', StringSplitOptions.None);
			string[] array2 = other.Split(' ', StringSplitOptions.None);
			HashSet<string> hashSet = new HashSet<string>();
			for (int i = 0; i < array.Length; i++)
			{
				hashSet.Add(array[i]);
			}
			for (int j = 0; j < array2.Length; j++)
			{
				hashSet.Add(array2[j]);
			}
			return string.Join<string>(' ', hashSet);
		}

		// Token: 0x06000AAF RID: 2735 RVA: 0x00024304 File Offset: 0x00022504
		public static string WhiteSpaceBeforeUpperCase(this string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				throw new ArgumentException("There is no first characters");
			}
			string text;
			if (StringExt.m_MemoryEater_WhitSpaceBeforeUpperCase.TryGetValue(s, out text))
			{
				return text;
			}
			StringExt.m_tempBuilder.Clear();
			foreach (char c in s)
			{
				if (char.IsUpper(c))
				{
					StringExt.m_tempBuilder.Append(' ');
				}
				StringExt.m_tempBuilder.Append(c);
			}
			text = StringExt.m_tempBuilder.ToString();
			StringExt.m_MemoryEater_WhitSpaceBeforeUpperCase.Add(s, text);
			return text;
		}

		// Token: 0x06000AB0 RID: 2736 RVA: 0x00024392 File Offset: 0x00022592
		public static string FirstLetterOrDefaultToToUpperCase(this string s)
		{
			if (string.IsNullOrWhiteSpace(s) || !char.IsLetter(s[0]))
			{
				return string.Empty;
			}
			return s.FirstLetterToUpperCase();
		}

		// Token: 0x06000AB1 RID: 2737 RVA: 0x000243B8 File Offset: 0x000225B8
		public static string FirstLetterToUpperCase(this string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				throw new ArgumentException("There is no first letter");
			}
			string text;
			if (StringExt.m_MemoryEater_FirstLetterToUpperCase.TryGetValue(s, out text))
			{
				return text;
			}
			StringExt.m_tempBuilder.Clear();
			bool flag = false;
			foreach (char c in s)
			{
				if (!flag && char.IsLetter(c))
				{
					StringExt.m_tempBuilder.Append(char.ToUpper(c));
					flag = true;
				}
				else
				{
					StringExt.m_tempBuilder.Append(c);
				}
			}
			text = StringExt.m_tempBuilder.ToString();
			StringExt.m_MemoryEater_FirstLetterToUpperCase.Add(s, text);
			return text;
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x00024454 File Offset: 0x00022654
		public static string FirstLetterToLowerCase(this string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				throw new ArgumentException("There is no first letter");
			}
			string text;
			if (StringExt.m_MemoryEater_FirstLetterToLowerCase.TryGetValue(s, out text))
			{
				return text;
			}
			StringExt.m_tempBuilder.Clear();
			bool flag = false;
			foreach (char c in s)
			{
				if (!flag && char.IsLetter(c))
				{
					StringExt.m_tempBuilder.Append(char.ToLower(c));
					flag = true;
				}
				else
				{
					StringExt.m_tempBuilder.Append(c);
				}
			}
			text = StringExt.m_tempBuilder.ToString();
			StringExt.m_MemoryEater_FirstLetterToLowerCase.Add(s, text);
			return text;
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x000244EF File Offset: 0x000226EF
		public static string FirstLetterOrDefaultToUpperCaseOthersToLower(this string s)
		{
			if (string.IsNullOrWhiteSpace(s) || !char.IsLetter(s[0]))
			{
				return string.Empty;
			}
			return s.FirstLetterToUpperCaseOthersToLower();
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x00024514 File Offset: 0x00022714
		public static string FirstLetterToUpperCaseOthersToLower(this string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				throw new ArgumentException("There is no first letter");
			}
			string text;
			if (StringExt.m_MemoryEater_FirstLetterToUpperCaseOthersToLower.TryGetValue(s, out text))
			{
				return text;
			}
			string text2 = s.Trim().ToLowerInvariant();
			if (text2.Length > 0 && !char.IsLetter(text2[0]))
			{
				throw new InvalidOperationException("char " + text2[0].ToString() + " no es una letra");
			}
			char[] array = text2.ToCharArray();
			array[0] = char.ToUpper(array[0]);
			text = new string(array);
			StringExt.m_MemoryEater_FirstLetterToUpperCaseOthersToLower.Add(s, text);
			return text;
		}

		// Token: 0x06000AB5 RID: 2741 RVA: 0x000245B4 File Offset: 0x000227B4
		public static string FirstLetterToUpperCaseOthersToLowerNoOptimizado(this string s)
		{
			string text = s.Trim().ToLowerInvariant();
			if (text.Length > 0 && !char.IsLetter(text[0]))
			{
				throw new InvalidOperationException("char " + text[0].ToString() + " no es una letra");
			}
			char[] array = text.ToCharArray();
			array[0] = char.ToUpper(array[0]);
			return new string(array);
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x00024620 File Offset: 0x00022820
		public static string Replace(this string str, string oldValue, string newValue, StringComparison comparisonType)
		{
			if (str == null)
			{
				throw new ArgumentNullException("str");
			}
			if (str.Length == 0)
			{
				return str;
			}
			if (oldValue == null)
			{
				throw new ArgumentNullException("oldValue");
			}
			if (oldValue.Length == 0)
			{
				throw new ArgumentException("String cannot be of zero length.");
			}
			StringBuilder stringBuilder = new StringBuilder(str.Length);
			bool flag = string.IsNullOrEmpty(newValue);
			int num = 0;
			int num2;
			while ((num2 = str.IndexOf(oldValue, num, comparisonType)) != -1)
			{
				int num3 = num2 - num;
				if (num3 != 0)
				{
					stringBuilder.Append(str, num, num3);
				}
				if (!flag)
				{
					stringBuilder.Append(newValue);
				}
				num = num2 + oldValue.Length;
				if (num == str.Length)
				{
					return stringBuilder.ToString();
				}
			}
			int num4 = str.Length - num;
			stringBuilder.Append(str, num, num4);
			return stringBuilder.ToString();
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x000246E4 File Offset: 0x000228E4
		public static string[] Filtrar(this IList<string> sourceCompleto, string buscando, string insent = null)
		{
			if (buscando == null)
			{
				buscando = string.Empty;
			}
			if (string.IsNullOrWhiteSpace(buscando))
			{
				return sourceCompleto.ToArray<string>();
			}
			string[] array;
			try
			{
				if (insent != null)
				{
					StringExt.TEmp_Filtrado.Add(insent);
				}
				foreach (string text in sourceCompleto)
				{
					if (text.IndexOf(buscando, StringComparison.InvariantCultureIgnoreCase) >= 0)
					{
						StringExt.TEmp_Filtrado.Add(text);
					}
				}
				array = StringExt.TEmp_Filtrado.ToArray();
			}
			finally
			{
				StringExt.TEmp_Filtrado.Clear();
			}
			return array;
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x00024788 File Offset: 0x00022988
		public static void FiltrarInPlace<T>(this IList<T> sourceCompleto, Func<T, string> selector, string buscando)
		{
			if (buscando == null)
			{
				buscando = string.Empty;
			}
			if (string.IsNullOrWhiteSpace(buscando))
			{
				return;
			}
			for (int i = sourceCompleto.Count - 1; i >= 0; i--)
			{
				T t = sourceCompleto[i];
				if (selector(t).IndexOf(buscando, StringComparison.InvariantCultureIgnoreCase) == -1)
				{
					sourceCompleto.RemoveAt(i);
				}
			}
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x000247DC File Offset: 0x000229DC
		public static void Filtrar<T>(this IList<T> sourceCompleto, Func<T, string> selector, string buscando, IList<T> resultado, Predicate<T> customFiltro = null)
		{
			if (buscando == null)
			{
				buscando = string.Empty;
			}
			resultado.Clear();
			bool flag = !string.IsNullOrWhiteSpace(buscando);
			bool flag2 = customFiltro != null;
			for (int i = 0; i < sourceCompleto.Count; i++)
			{
				T t = sourceCompleto[i];
				string text = selector(t);
				if ((!flag || text.IndexOf(buscando, StringComparison.InvariantCultureIgnoreCase) >= 0) && (!flag2 || customFiltro(t)))
				{
					resultado.Add(t);
				}
			}
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x00024850 File Offset: 0x00022A50
		public static void Filtrar<T>(this IEnumerable<T> sourceCompleto, Func<T, string> selector, string buscando, IList<T> resultado, Predicate<T> customFiltro = null)
		{
			if (buscando == null)
			{
				buscando = string.Empty;
			}
			resultado.Clear();
			bool flag = !string.IsNullOrWhiteSpace(buscando);
			bool flag2 = customFiltro != null;
			foreach (T t in sourceCompleto)
			{
				string text = selector(t);
				if ((!flag || text.IndexOf(buscando, StringComparison.InvariantCultureIgnoreCase) >= 0) && (!flag2 || customFiltro(t)))
				{
					resultado.Add(t);
				}
			}
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x000248E0 File Offset: 0x00022AE0
		public static bool Filtrado(this string text, string buscando)
		{
			return !string.IsNullOrWhiteSpace(buscando) && text.IndexOf(buscando, StringComparison.InvariantCultureIgnoreCase) < 0;
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x00024900 File Offset: 0x00022B00
		public static string RemoveSpecialCharacters(this string str)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in str)
			{
				if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04000357 RID: 855
		private static Dictionary<string, string> m_MemoryEater_FirstLetterToUpperCaseOthersToLower = new Dictionary<string, string>();

		// Token: 0x04000358 RID: 856
		private static Dictionary<string, string> m_MemoryEater_FirstLetterToUpperCase = new Dictionary<string, string>();

		// Token: 0x04000359 RID: 857
		private static Dictionary<string, string> m_MemoryEater_FirstLetterToLowerCase = new Dictionary<string, string>();

		// Token: 0x0400035A RID: 858
		private static Dictionary<string, string> m_MemoryEater_WhitSpaceBeforeUpperCase = new Dictionary<string, string>();

		// Token: 0x0400035B RID: 859
		private static StringBuilder m_tempBuilder = new StringBuilder();

		// Token: 0x0400035C RID: 860
		private static List<string> TEmp_Filtrado = new List<string>();
	}
}
