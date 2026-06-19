using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

// Token: 0x02000015 RID: 21
public static class ISerializedDataContainerHelper
{
	// Token: 0x06000061 RID: 97 RVA: 0x00004658 File Offset: 0x00002858
	public static string FindData(this ISerializedDataContainer node, string id, string defaultValue)
	{
		string text = node.FindData(id);
		if (text != null)
		{
			return text;
		}
		return defaultValue;
	}

	// Token: 0x06000062 RID: 98 RVA: 0x00004674 File Offset: 0x00002874
	public static void AddDataValue<TKey, TValue>(this ISerializedDataContainer node, ref TKey id, ref TValue data, bool replace = true) where TKey : struct where TValue : struct
	{
		string text = JsonUtility.ToJson(id);
		string text2 = JsonUtility.ToJson(data);
		node.AddData(text, text2, replace);
	}

	// Token: 0x06000063 RID: 99 RVA: 0x000046AC File Offset: 0x000028AC
	public static void AddDataObject<TKey, TValue>(this ISerializedDataContainer node, TKey id, TValue data, bool replace = true)
	{
		string text = JsonUtility.ToJson(id);
		string text2 = JsonUtility.ToJson(data);
		node.AddData(text, text2, replace);
	}

	// Token: 0x06000064 RID: 100 RVA: 0x000046DC File Offset: 0x000028DC
	public static bool TryFindDataObject<TKey, TValue>(this ISerializedDataContainer node, string id, out TKey key, out TValue value, TKey defaultKey, TValue defaultValue)
	{
		key = defaultKey;
		value = defaultValue;
		string text = node.FindData(id);
		if (text == null)
		{
			return false;
		}
		key = JsonUtility.FromJson<TKey>(id);
		value = JsonUtility.FromJson<TValue>(text);
		return true;
	}

	// Token: 0x06000065 RID: 101 RVA: 0x00004720 File Offset: 0x00002920
	public static bool TryFindDataValue<TKey, TValue>(this ISerializedDataContainer node, string id, out TKey key, out TValue value) where TKey : struct where TValue : struct
	{
		key = default(TKey);
		value = default(TValue);
		string text = node.FindData(id);
		if (text == null)
		{
			return false;
		}
		key = JsonUtility.FromJson<TKey>(id);
		value = JsonUtility.FromJson<TValue>(text);
		return true;
	}

	// Token: 0x06000066 RID: 102 RVA: 0x00004764 File Offset: 0x00002964
	public static void AddDataObject<T>(this ISerializedDataContainer node, string id, T data, bool replace = true)
	{
		string text = JsonUtility.ToJson(data);
		node.AddData(id, text, replace);
	}

	// Token: 0x06000067 RID: 103 RVA: 0x00004788 File Offset: 0x00002988
	public static bool TryFindDataObject<T>(this ISerializedDataContainer node, string id, out T value, T defaultValue)
	{
		value = defaultValue;
		string text = node.FindData(id);
		if (text == null)
		{
			return false;
		}
		value = JsonUtility.FromJson<T>(text);
		return true;
	}

	// Token: 0x06000068 RID: 104 RVA: 0x000047B8 File Offset: 0x000029B8
	public static bool TryFindDataObject<T>(this ISerializedDataContainer node, string id, Type type, out T value, T defaultValue) where T : class
	{
		value = defaultValue;
		string text = node.FindData(id);
		if (text == null)
		{
			return false;
		}
		value = JsonUtility.FromJson(text, type) as T;
		return true;
	}

	// Token: 0x06000069 RID: 105 RVA: 0x000047F4 File Offset: 0x000029F4
	public static bool TryFindDataObject(this ISerializedDataContainer node, string id, Type type, out object value, object defaultValue)
	{
		value = defaultValue;
		string text = node.FindData(id);
		if (text == null)
		{
			return false;
		}
		value = JsonUtility.FromJson(text, type);
		return true;
	}

	// Token: 0x0600006A RID: 106 RVA: 0x0000481C File Offset: 0x00002A1C
	public static void AddData<T>(this ISerializedDataContainer node, string id, T[] data, bool replace = true)
	{
		string text = JsonUtility.ToJson(new ISerializedDataContainerHelper.WraperArray<T>
		{
			c = data
		});
		node.AddData(id, text, replace);
	}

	// Token: 0x0600006B RID: 107 RVA: 0x00004844 File Offset: 0x00002A44
	public static bool TryFindDataArrayEmpty<T>(this ISerializedDataContainer node, string id, out T[] value)
	{
		string text = node.FindData(id);
		if (text == null)
		{
			value = new T[0];
			return false;
		}
		ISerializedDataContainerHelper.WraperArray<T> wraperArray = JsonUtility.FromJson<ISerializedDataContainerHelper.WraperArray<T>>(text);
		if (wraperArray.c == null)
		{
			value = new T[0];
		}
		else
		{
			value = wraperArray.c;
		}
		return true;
	}

	// Token: 0x0600006C RID: 108 RVA: 0x00004888 File Offset: 0x00002A88
	public static bool TryFindDataArrayNull<T>(this ISerializedDataContainer node, string id, out T[] value)
	{
		value = null;
		string text = node.FindData(id);
		if (text == null)
		{
			return false;
		}
		ISerializedDataContainerHelper.WraperArray<T> wraperArray = JsonUtility.FromJson<ISerializedDataContainerHelper.WraperArray<T>>(text);
		value = wraperArray.c;
		return true;
	}

	// Token: 0x0600006D RID: 109 RVA: 0x000048B8 File Offset: 0x00002AB8
	public static void AddData<T>(this ISerializedDataContainer node, string id, List<T> data, bool replace = true)
	{
		string text = JsonUtility.ToJson(new ISerializedDataContainerHelper.WraperList<T>
		{
			c = data
		});
		node.AddData(id, text, replace);
	}

	// Token: 0x0600006E RID: 110 RVA: 0x000048E0 File Offset: 0x00002AE0
	public static bool TryFindDataArrayEmpty<T>(this ISerializedDataContainer node, string id, out List<T> value)
	{
		string text = node.FindData(id);
		if (text == null)
		{
			value = new List<T>();
			return false;
		}
		ISerializedDataContainerHelper.WraperList<T> wraperList = JsonUtility.FromJson<ISerializedDataContainerHelper.WraperList<T>>(text);
		if (wraperList.c == null)
		{
			value = new List<T>();
		}
		else
		{
			value = wraperList.c;
		}
		return true;
	}

	// Token: 0x0600006F RID: 111 RVA: 0x00004924 File Offset: 0x00002B24
	public static bool TryFindDataArrayNull<T>(this ISerializedDataContainer node, string id, out List<T> value)
	{
		value = null;
		string text = node.FindData(id);
		if (text == null)
		{
			return false;
		}
		ISerializedDataContainerHelper.WraperList<T> wraperList = JsonUtility.FromJson<ISerializedDataContainerHelper.WraperList<T>>(text);
		value = wraperList.c;
		return true;
	}

	// Token: 0x06000070 RID: 112 RVA: 0x00004951 File Offset: 0x00002B51
	public static void AddData(this ISerializedDataContainer node, string id, int data, bool replace = true)
	{
		node.AddData(id, data.ToString(CultureInfo.InvariantCulture), replace);
	}

	// Token: 0x06000071 RID: 113 RVA: 0x00004968 File Offset: 0x00002B68
	public static int FindDataInt(this ISerializedDataContainer node, string id, int defaultValue)
	{
		string text = node.FindData(id);
		if (text != null)
		{
			return Convert.ToInt32(text, CultureInfo.InvariantCulture);
		}
		return defaultValue;
	}

	// Token: 0x06000072 RID: 114 RVA: 0x0000498D File Offset: 0x00002B8D
	public static void AddData(this ISerializedDataContainer node, string id, bool data, bool replace = true)
	{
		node.AddData(id, data.ToString(CultureInfo.InvariantCulture), replace);
	}

	// Token: 0x06000073 RID: 115 RVA: 0x000049A4 File Offset: 0x00002BA4
	public static bool FindDataBool(this ISerializedDataContainer node, string id, bool defaultValue)
	{
		string text = node.FindData(id);
		if (text != null)
		{
			return Convert.ToBoolean(text, CultureInfo.InvariantCulture);
		}
		return defaultValue;
	}

	// Token: 0x06000074 RID: 116 RVA: 0x000049CC File Offset: 0x00002BCC
	public static bool TryFindDataInt(this ISerializedDataContainer node, string id, out int value)
	{
		value = 0;
		string text = node.FindData(id);
		if (text == null)
		{
			return false;
		}
		value = Convert.ToInt32(text, CultureInfo.InvariantCulture);
		return true;
	}

	// Token: 0x06000075 RID: 117 RVA: 0x000049F7 File Offset: 0x00002BF7
	public static void AddData(this ISerializedDataContainer node, int id, int data, bool replace = true)
	{
		node.AddData(id.ToString(CultureInfo.InvariantCulture), data.ToString(CultureInfo.InvariantCulture), replace);
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00004A18 File Offset: 0x00002C18
	public static int FindDataInt(this ISerializedDataContainer node, int id, int defaultValue)
	{
		return node.FindDataInt(id.ToString(CultureInfo.InvariantCulture), defaultValue);
	}

	// Token: 0x06000077 RID: 119 RVA: 0x00004A2D File Offset: 0x00002C2D
	public static bool TryFindDataInt(this ISerializedDataContainer node, int id, out int value)
	{
		return node.TryFindDataInt(id.ToString(CultureInfo.InvariantCulture), out value);
	}

	// Token: 0x06000078 RID: 120 RVA: 0x00004A42 File Offset: 0x00002C42
	public static void AddData(this ISerializedDataContainer node, string id, float data, bool replace = true)
	{
		node.AddData(id, data.Serialized(), replace);
	}

	// Token: 0x06000079 RID: 121 RVA: 0x00004A54 File Offset: 0x00002C54
	public static float FindDataFloat(this ISerializedDataContainer node, string id, float defaultValue)
	{
		string text = node.FindData(id);
		if (text != null)
		{
			return text.DeserializedAsFloat(defaultValue);
		}
		return defaultValue;
	}

	// Token: 0x0600007A RID: 122 RVA: 0x00004A75 File Offset: 0x00002C75
	public static float DataToFloat(this string data, float defaultValue)
	{
		if (data != null)
		{
			return data.DeserializedAsFloat(defaultValue);
		}
		return defaultValue;
	}

	// Token: 0x0600007B RID: 123 RVA: 0x00004A84 File Offset: 0x00002C84
	public static bool TryFindDataFloat(this ISerializedDataContainer node, string id, out float value)
	{
		value = 0f;
		string text = node.FindData(id);
		if (text == null)
		{
			return false;
		}
		value = text.DeserializedAsFloat(0f);
		return true;
	}

	// Token: 0x0600007C RID: 124 RVA: 0x00004AB3 File Offset: 0x00002CB3
	public static void AddData(this ISerializedDataContainer node, int id, float data, bool replace = true)
	{
		node.AddData(id.ToString(CultureInfo.InvariantCulture), data.Serialized(), replace);
	}

	// Token: 0x0600007D RID: 125 RVA: 0x00004ACE File Offset: 0x00002CCE
	public static float FindDataFloat(this ISerializedDataContainer node, int id, float defaultValue)
	{
		return node.FindDataFloat(id.ToString(CultureInfo.InvariantCulture), defaultValue);
	}

	// Token: 0x0600007E RID: 126 RVA: 0x00004AE3 File Offset: 0x00002CE3
	public static bool TryFindDataFloat(this ISerializedDataContainer node, int id, out float value)
	{
		return node.TryFindDataFloat(id.ToString(CultureInfo.InvariantCulture), out value);
	}

	// Token: 0x0600007F RID: 127 RVA: 0x00004AF8 File Offset: 0x00002CF8
	public static void AddData(this ISerializedDataContainer node, string id, Texture2D data, bool replace = true)
	{
		string text = Convert.ToBase64String(data.EncodeToJPG());
		node.AddData(id, text, replace);
	}

	// Token: 0x06000080 RID: 128 RVA: 0x00004B1C File Offset: 0x00002D1C
	public static Texture2D FindDataImage(this ISerializedDataContainer node, string id)
	{
		Texture2D texture2D = new Texture2D(2, 2);
		if (!node.TryFindDataImage(id, ref texture2D))
		{
			Object.Destroy(texture2D);
			return null;
		}
		return texture2D;
	}

	// Token: 0x06000081 RID: 129 RVA: 0x00004B48 File Offset: 0x00002D48
	public static bool TryFindDataImage(this ISerializedDataContainer node, string id, ref Texture2D result)
	{
		if (result == null)
		{
			result = new Texture2D(2, 2);
		}
		string text = node.FindData(id, string.Empty);
		if (string.IsNullOrWhiteSpace(text))
		{
			return false;
		}
		bool flag;
		try
		{
			byte[] array = Convert.FromBase64String(text);
			flag = result.LoadImage(array, true);
		}
		catch (Exception ex)
		{
			Debug.LogError("Error loading image form node");
			Debug.LogException(ex);
			flag = false;
		}
		return flag;
	}

	// Token: 0x02000197 RID: 407
	private class WraperArray<T>
	{
		// Token: 0x040003E0 RID: 992
		public T[] c;
	}

	// Token: 0x02000198 RID: 408
	private class WraperList<T>
	{
		// Token: 0x040003E1 RID: 993
		public List<T> c;
	}
}
