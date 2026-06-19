using System;
using System.Reflection;

// Token: 0x02000036 RID: 54
public static class ObjectEXT
{
	// Token: 0x060001F9 RID: 505 RVA: 0x0000B1FC File Offset: 0x000093FC
	public static DateTime Next(this DateTime from, DayOfWeek dayOfWeek)
	{
		int dayOfWeek2 = (int)from.DayOfWeek;
		int num = (int)dayOfWeek;
		if (num <= dayOfWeek2)
		{
			num += 7;
		}
		return from.AddDays((double)(num - dayOfWeek2));
	}

	// Token: 0x060001FA RID: 506 RVA: 0x0000B228 File Offset: 0x00009428
	public static DateTime Last(this DateTime from, DayOfWeek dayOfWeek)
	{
		int dayOfWeek2 = (int)from.DayOfWeek;
		int num = (int)dayOfWeek;
		if (num >= dayOfWeek2)
		{
			num -= 7;
		}
		return from.AddDays((double)(num - dayOfWeek2));
	}

	// Token: 0x060001FB RID: 507 RVA: 0x0000B254 File Offset: 0x00009454
	public static bool ReflectedMemberwiseEqual(this object thisObj, object obj, out FieldInfo notEqualField)
	{
		notEqualField = null;
		if (obj == null)
		{
			return false;
		}
		Type type = thisObj.GetType();
		if (obj.GetType() != type)
		{
			return false;
		}
		FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		for (int i = 0; i < fields.Length; i++)
		{
			notEqualField = fields[i];
			object value = fields[i].GetValue(thisObj);
			object value2 = fields[i].GetValue(obj);
			if (value == null)
			{
				if (value2 != null)
				{
					return false;
				}
			}
			else if (!value.Equals(value2))
			{
				return false;
			}
		}
		notEqualField = null;
		return true;
	}
}
