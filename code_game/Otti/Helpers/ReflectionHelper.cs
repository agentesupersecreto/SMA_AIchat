using System;
using System.Reflection;
using UnityEngine;

namespace com.ootii.Helpers
{
	// Token: 0x02000035 RID: 53
	public class ReflectionHelper
	{
		// Token: 0x06000287 RID: 647 RVA: 0x0000C501 File Offset: 0x0000A701
		public static bool IsSubclassOf(Type rType, Type rBaseType)
		{
			return rType == rBaseType || rType.IsSubclassOf(rBaseType);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000C518 File Offset: 0x0000A718
		public static bool IsAssignableFrom(Type rType, Type rDerivedType)
		{
			return rType == rDerivedType || rType.IsAssignableFrom(rDerivedType);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000C530 File Offset: 0x0000A730
		public static T GetAttribute<T>(Type rObjectType)
		{
			object[] customAttributes = rObjectType.GetCustomAttributes(typeof(T), true);
			if (customAttributes == null || customAttributes.Length == 0)
			{
				return default(T);
			}
			return (T)((object)customAttributes[0]);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000C568 File Offset: 0x0000A768
		public static bool IsDefined(Type rObjectType, Type rType)
		{
			object[] customAttributes = rObjectType.GetCustomAttributes(rType, true);
			return customAttributes != null && customAttributes.Length != 0;
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000C588 File Offset: 0x0000A788
		public static bool IsDefined(FieldInfo rFieldInfo, Type rType)
		{
			object[] customAttributes = rFieldInfo.GetCustomAttributes(rType, true);
			return customAttributes != null && customAttributes.Length != 0;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000C5A8 File Offset: 0x0000A7A8
		public static bool IsDefined(MemberInfo rMemberInfo, Type rType)
		{
			object[] customAttributes = rMemberInfo.GetCustomAttributes(rType, true);
			return customAttributes != null && customAttributes.Length != 0;
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000C5C8 File Offset: 0x0000A7C8
		public static bool IsDefined(PropertyInfo rPropertyInfo, Type rType)
		{
			object[] customAttributes = rPropertyInfo.GetCustomAttributes(rType, true);
			return customAttributes != null && customAttributes.Length != 0;
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0000C5E8 File Offset: 0x0000A7E8
		public static void SetProperty(object rObject, string rName, object rValue)
		{
			PropertyInfo[] properties = rObject.GetType().GetProperties();
			if (properties != null && properties.Length != 0)
			{
				for (int i = 0; i < properties.Length; i++)
				{
					if (properties[i].Name == rName && properties[i].CanWrite)
					{
						properties[i].SetValue(rObject, rValue, null);
						return;
					}
				}
			}
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0000C63C File Offset: 0x0000A83C
		public static bool IsTypeValid(string rType)
		{
			bool flag;
			try
			{
				flag = Type.GetType(rType) != null;
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000C670 File Offset: 0x0000A870
		public static bool IsPrimitive(Type rType)
		{
			return rType.IsPrimitive;
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000C678 File Offset: 0x0000A878
		public static bool IsValueType(Type rType)
		{
			return rType.IsValueType;
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000C680 File Offset: 0x0000A880
		public static bool IsGenericType(Type rType)
		{
			return rType.IsGenericType;
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000C688 File Offset: 0x0000A888
		public static object GetDefaultValue(Type rType)
		{
			if (rType.IsValueType)
			{
				return Activator.CreateInstance(rType);
			}
			Vector3 vector = default(Vector3);
			return vector.GetType().GetMethod("GetDefaultGeneric").MakeGenericMethod(new Type[] { rType })
				.Invoke(vector, null);
		}
	}
}
