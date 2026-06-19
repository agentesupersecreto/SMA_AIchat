using System;

namespace com.ootii.Collections
{
	// Token: 0x02000064 RID: 100
	public static class ArrayExt
	{
		// Token: 0x06000497 RID: 1175 RVA: 0x0001B824 File Offset: 0x00019A24
		public static void RemoveAt<T>(ref T[] rSource, int rIndex)
		{
			if (rSource.Length == 0)
			{
				return;
			}
			if (rIndex < 0 || rIndex >= rSource.Length)
			{
				return;
			}
			T[] array = new T[rSource.Length - 1];
			if (rIndex > 0)
			{
				Array.Copy(rSource, 0, array, 0, rIndex);
			}
			if (rIndex < rSource.Length - 1)
			{
				Array.Copy(rSource, rIndex + 1, array, rIndex, rSource.Length - rIndex - 1);
			}
			rSource = array;
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x0001B880 File Offset: 0x00019A80
		public static T[] RemoveAt<T>(T[] rSource, int rIndex)
		{
			int num = rSource.Length;
			if (num == 0)
			{
				return null;
			}
			if (rIndex < 0 || rIndex >= num)
			{
				return null;
			}
			int i = 0;
			int num2 = 0;
			T[] array = new T[num - 1];
			while (i < num)
			{
				if (i != rIndex)
				{
					array[num2] = rSource[i];
					num2++;
				}
				i++;
			}
			return array;
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x0001B8CE File Offset: 0x00019ACE
		public static void Sort<T>(this T[] rSource, Comparison<T> rComparison)
		{
			if (rSource.Length <= 1)
			{
				return;
			}
			Array.Sort<T>(rSource, rComparison);
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0001B8E0 File Offset: 0x00019AE0
		public static bool Contains<T>(this T[] rArray, T rValue)
		{
			return Array.Exists<T>(rArray, (T item) => item.Equals(rValue));
		}
	}
}
