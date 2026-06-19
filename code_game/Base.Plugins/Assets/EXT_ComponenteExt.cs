using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000CB RID: 203
	public static class EXT_ComponenteExt
	{
		// Token: 0x060005F6 RID: 1526 RVA: 0x000175AC File Offset: 0x000157AC
		public static T GetCopyOf<T>(this Component comp, T other) where T : Component
		{
			Type type = comp.GetType();
			if (type != other.GetType())
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
						propertyInfo.SetValue(comp, propertyInfo.GetValue(other, null), null);
					}
					catch
					{
					}
				}
			}
			foreach (FieldInfo fieldInfo in type.GetFields(bindingFlags))
			{
				fieldInfo.SetValue(comp, fieldInfo.GetValue(other));
			}
			return comp as T;
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x00017678 File Offset: 0x00015878
		[Obsolete("bugueado, copia la referencia al objeto C++", true)]
		public static T CopyComponent<T>(this T original, GameObject destination) where T : Component
		{
			Type type = original.GetType();
			T t = destination.GetComponent(type) as T;
			if (!t)
			{
				t = destination.AddComponent(type) as T;
			}
			foreach (FieldInfo fieldInfo in EXT_ComponenteExt.GetAllFields(type))
			{
				if (!fieldInfo.IsStatic && !(fieldInfo.Name == "m_InstanceID"))
				{
					Debug.Log(fieldInfo.Name);
					Debug.Log(fieldInfo.GetValue(original).ToString());
					fieldInfo.SetValue(t, fieldInfo.GetValue(original));
				}
			}
			foreach (PropertyInfo propertyInfo in type.GetProperties())
			{
				if (propertyInfo.CanWrite && propertyInfo.CanRead && !(propertyInfo.Name == "name"))
				{
					propertyInfo.SetValue(t, propertyInfo.GetValue(original, null), null);
				}
			}
			return t;
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x000177B4 File Offset: 0x000159B4
		public static IEnumerable<FieldInfo> GetAllFields(Type t)
		{
			if (t == null)
			{
				return Enumerable.Empty<FieldInfo>();
			}
			BindingFlags bindingFlags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
			return t.GetFields(bindingFlags).Concat(EXT_ComponenteExt.GetAllFields(t.BaseType));
		}
	}
}
