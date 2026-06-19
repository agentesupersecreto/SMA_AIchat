using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000164 RID: 356
	public static class EnumExtensions
	{
		// Token: 0x06000A73 RID: 2675 RVA: 0x00023424 File Offset: 0x00021624
		public static int GetSetBitCount(long lValue)
		{
			int num = 0;
			while (lValue != 0L)
			{
				lValue &= lValue - 1L;
				num++;
			}
			return num;
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x00023448 File Offset: 0x00021648
		[Obsolete("extremadamente costoso", true)]
		public static bool HasFlag(this Enum variable, Enum value)
		{
			Debug.LogWarning("este methodo es cara, crear uno para este tipo de enum especifico");
			bool flag;
			try
			{
				if (variable.GetType() != value.GetType())
				{
					throw new ArgumentException("The checked flag is not from the same type as the checked variable.");
				}
				if (Convert.ToInt64(variable) < 0L)
				{
					flag = true;
				}
				else
				{
					ulong num = Convert.ToUInt64(value);
					if (num == 0UL)
					{
						flag = false;
					}
					else
					{
						flag = (Convert.ToUInt64(variable) & num) == num;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.Log("exepcion ahead: uno de estos dos valoes no es un UInt64 valido: " + Convert.ToInt64(value).ToString() + " o " + Convert.ToInt64(variable).ToString());
				throw ex;
			}
			return flag;
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x000234EC File Offset: 0x000216EC
		[Obsolete("", true)]
		public static Array GetEnumValores(this Type enumType)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x000234F4 File Offset: 0x000216F4
		private static Array GetEnumArrayClean(this Type enumType)
		{
			if (!enumType.IsEnum)
			{
				throw new InvalidOperationException();
			}
			Array array;
			if (EnumExtensions.m_valuesClean.TryGetValue(enumType, out array) && array != null)
			{
				return array;
			}
			if (array == null)
			{
				EnumExtensions.m_valuesClean.Remove(enumType);
			}
			array = (from int v in Enum.GetValues(enumType)
				where v > 0
				select v into x
				orderby x
				select Enum.ToObject(enumType, x)).ToArray<object>();
			EnumExtensions.m_valuesClean.Add(enumType, array);
			return array;
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x000235D0 File Offset: 0x000217D0
		private static Array GetEnumArray(this Type enumType)
		{
			if (!enumType.IsEnum)
			{
				throw new InvalidOperationException();
			}
			Array array;
			if (EnumExtensions.m_values.TryGetValue(enumType, out array) && array != null)
			{
				return array;
			}
			if (array == null)
			{
				EnumExtensions.m_values.Remove(enumType);
			}
			array = (from int x in Enum.GetValues(enumType)
				orderby x
				select Enum.ToObject(enumType, x)).ToArray<object>();
			EnumExtensions.m_values.Add(enumType, array);
			return array;
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x00023687 File Offset: 0x00021887
		public static ICollection GetEnumValoresObject(this Type enumType)
		{
			return enumType.GetEnumArray();
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x0002368F File Offset: 0x0002188F
		public static ICollection GetEnumValoresLimpiosObject(this Type enumType)
		{
			return enumType.GetEnumArrayClean();
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x00023698 File Offset: 0x00021898
		public static IReadOnlyCollection<int> GetEnumValoresIntSet(this Type enumType)
		{
			if (!enumType.IsEnum)
			{
				throw new InvalidOperationException();
			}
			IReadOnlyCollection<int> readOnlyCollection;
			if (EnumExtensions.m_valuesIntSet.TryGetValue(enumType, out readOnlyCollection) && readOnlyCollection != null)
			{
				return readOnlyCollection;
			}
			if (readOnlyCollection == null)
			{
				EnumExtensions.m_valuesIntSet.Remove(enumType);
			}
			readOnlyCollection = new HashSet<int>(enumType.GetEnumValoresInt());
			EnumExtensions.m_valuesIntSet.Add(enumType, readOnlyCollection);
			return readOnlyCollection;
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x000236F0 File Offset: 0x000218F0
		public static IReadOnlyList<int> GetEnumValoresInt(this Type enumType)
		{
			if (!enumType.IsEnum)
			{
				throw new InvalidOperationException();
			}
			int[] array;
			if (EnumExtensions.m_valuesInt.TryGetValue(enumType, out array) && array != null)
			{
				return array;
			}
			if (array == null)
			{
				EnumExtensions.m_valuesInt.Remove(enumType);
			}
			array = (from int x in Enum.GetValues(enumType)
				orderby x
				select x).ToArray<int>();
			EnumExtensions.m_valuesInt.Add(enumType, array);
			return array;
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x00023770 File Offset: 0x00021970
		public static IReadOnlyList<string> GetEnumValoresNombres(this Type enumType)
		{
			if (!enumType.IsEnum)
			{
				throw new InvalidOperationException();
			}
			string[] names;
			if (EnumExtensions.m_valuesNombres.TryGetValue(enumType, out names) && names != null)
			{
				return names;
			}
			if (names == null)
			{
				EnumExtensions.m_valuesNombres.Remove(enumType);
			}
			names = Enum.GetNames(enumType);
			EnumExtensions.m_valuesNombres.Add(enumType, names);
			return names;
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x000237C2 File Offset: 0x000219C2
		public static int GetEnumCount(this Type enumType)
		{
			if (!enumType.IsEnum)
			{
				throw new InvalidOperationException();
			}
			return enumType.GetEnumArray().Length;
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x000237E0 File Offset: 0x000219E0
		public static int GetEnumRandomValue(this Type enumType)
		{
			if (!enumType.IsEnum)
			{
				throw new InvalidOperationException();
			}
			int num = enumType.MinEnumValue();
			int num2 = enumType.MaxEnumValue();
			return Random.Range(num, num2 + 1);
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x00023810 File Offset: 0x00021A10
		public static int GetEnumRandomIndex(this Type enumType)
		{
			if (!enumType.IsEnum)
			{
				throw new InvalidOperationException();
			}
			Array enumArray = enumType.GetEnumArray();
			return Random.Range(0, enumArray.Length);
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x00023840 File Offset: 0x00021A40
		public static int GetEnumRandomIndexIgnorandoPrimero(this Type enumType)
		{
			if (!enumType.IsEnum)
			{
				throw new InvalidOperationException();
			}
			Array enumArray = enumType.GetEnumArray();
			return Random.Range(1, enumArray.Length);
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x00023870 File Offset: 0x00021A70
		public static object GetEnumRandom(this Type enumType)
		{
			if (!enumType.IsEnum)
			{
				throw new InvalidOperationException();
			}
			Array enumArray = enumType.GetEnumArray();
			int enumRandomIndex = enumType.GetEnumRandomIndex();
			return enumArray.GetValue(enumRandomIndex);
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x000238A0 File Offset: 0x00021AA0
		public static object GetEnumRandomIgnoranzoPrimero(this Type enumType)
		{
			if (!enumType.IsEnum)
			{
				throw new InvalidOperationException();
			}
			Array enumArray = enumType.GetEnumArray();
			int enumRandomIndexIgnorandoPrimero = enumType.GetEnumRandomIndexIgnorandoPrimero();
			return enumArray.GetValue(enumRandomIndexIgnorandoPrimero);
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x000238D0 File Offset: 0x00021AD0
		public static int MinEnumValue(this Type enumType)
		{
			if (!enumType.IsEnum)
			{
				throw new InvalidOperationException();
			}
			int num;
			if (EnumExtensions.m_minValues.TryGetValue(enumType, out num))
			{
				return num;
			}
			num = enumType.GetEnumValoresInt().Min();
			EnumExtensions.m_minValues.Add(enumType, num);
			return num;
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x00023918 File Offset: 0x00021B18
		public static int MaxEnumValue(this Type enumType)
		{
			if (!enumType.IsEnum)
			{
				throw new InvalidOperationException();
			}
			int num;
			if (EnumExtensions.m_maxValues.TryGetValue(enumType, out num))
			{
				return num;
			}
			num = enumType.GetEnumValoresInt().Max();
			EnumExtensions.m_maxValues.Add(enumType, num);
			return num;
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x00023960 File Offset: 0x00021B60
		public static int AllEnumFlagsValue(this Type enumType)
		{
			if (!enumType.IsEnum)
			{
				throw new InvalidOperationException();
			}
			int num;
			if (EnumExtensions.m_allValues.TryGetValue(enumType, out num))
			{
				return num;
			}
			num = 0;
			IReadOnlyList<int> enumValoresInt = enumType.GetEnumValoresInt();
			for (int i = 0; i < enumValoresInt.Count; i++)
			{
				num |= Convert.ToInt32(enumValoresInt[i]);
			}
			EnumExtensions.m_allValues.Add(enumType, num);
			return num;
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x000239C2 File Offset: 0x00021BC2
		public static int InvertEnumValue(this Type enumType, int flags)
		{
			if (!enumType.IsEnum)
			{
				throw new InvalidOperationException();
			}
			return enumType.AllEnumFlagsValue() & ~flags;
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x000239DB File Offset: 0x00021BDB
		public static int MaxEnumValue(this Enum variable)
		{
			Debug.LogWarning("este methodo es cara, crear uno para este tipo de enum especifico");
			return variable.GetType().MaxEnumValue();
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x000239F4 File Offset: 0x00021BF4
		public static float Modificador<T_enum>(this int variable)
		{
			float num = (float)typeof(T_enum).MaxEnumValue();
			return (float)variable / num;
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x00023A16 File Offset: 0x00021C16
		public static float Porcentaje<T_enum>(this int variable)
		{
			return variable.Modificador<T_enum>() * 100f;
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x00023A24 File Offset: 0x00021C24
		public static TEnum ToEnum<TEnum>(this string strEnumValue, TEnum defaultValue) where TEnum : struct
		{
			if (string.IsNullOrEmpty(strEnumValue))
			{
				return defaultValue;
			}
			if (strEnumValue.Contains('"'))
			{
				strEnumValue = strEnumValue.Replace("\"", "");
			}
			TEnum tenum;
			if (Enum.TryParse<TEnum>(strEnumValue, out tenum))
			{
				return tenum;
			}
			return defaultValue;
		}

		// Token: 0x04000349 RID: 841
		private static Dictionary<Type, Array> m_values = new Dictionary<Type, Array>();

		// Token: 0x0400034A RID: 842
		private static Dictionary<Type, Array> m_valuesClean = new Dictionary<Type, Array>();

		// Token: 0x0400034B RID: 843
		private static Dictionary<Type, string[]> m_valuesNombres = new Dictionary<Type, string[]>();

		// Token: 0x0400034C RID: 844
		private static Dictionary<Type, int[]> m_valuesInt = new Dictionary<Type, int[]>();

		// Token: 0x0400034D RID: 845
		private static Dictionary<Type, IReadOnlyCollection<int>> m_valuesIntSet = new Dictionary<Type, IReadOnlyCollection<int>>();

		// Token: 0x0400034E RID: 846
		private static Dictionary<Type, int> m_maxValues = new Dictionary<Type, int>();

		// Token: 0x0400034F RID: 847
		private static Dictionary<Type, int> m_minValues = new Dictionary<Type, int>();

		// Token: 0x04000350 RID: 848
		private static Dictionary<Type, int> m_allValues = new Dictionary<Type, int>();
	}
}
