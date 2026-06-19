using System;
using System.Reflection;
using UnityEngine;

namespace com.ootii.Geometry
{
	// Token: 0x02000049 RID: 73
	public static class GameObjectExt
	{
		// Token: 0x06000390 RID: 912 RVA: 0x00011EDC File Offset: 0x000100DC
		public static object GetComponentInParents(this GameObject rThis, Type rType)
		{
			if (rThis == null)
			{
				return null;
			}
			Transform transform = rThis.transform;
			while (transform != null)
			{
				Component component = transform.gameObject.GetComponent(rType);
				if (component != null)
				{
					return component;
				}
				transform = transform.parent;
			}
			return null;
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00011F28 File Offset: 0x00010128
		public static T GetComponentInParents<T>(this GameObject rThis) where T : Component
		{
			if (rThis == null)
			{
				return default(T);
			}
			Transform transform = rThis.transform;
			while (transform != null)
			{
				T component = transform.GetComponent<T>();
				if (component != null)
				{
					return component;
				}
				transform = transform.parent;
			}
			return default(T);
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00011F84 File Offset: 0x00010184
		public static T GetCopyOf<T>(this Component rThis, T rOther) where T : Component
		{
			Type type = rThis.GetType();
			if (type != rOther.GetType())
			{
				return default(T);
			}
			BindingFlags bindingFlags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			foreach (PropertyInfo propertyInfo in type.GetProperties(bindingFlags))
			{
				if (propertyInfo.CanWrite)
				{
					try
					{
						propertyInfo.SetValue(rThis, propertyInfo.GetValue(rOther, null), null);
					}
					catch
					{
					}
				}
			}
			foreach (FieldInfo fieldInfo in type.GetFields(bindingFlags))
			{
				fieldInfo.SetValue(rThis, fieldInfo.GetValue(rOther));
			}
			return rThis as T;
		}
	}
}
