using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace com.ootii.Helpers
{
	// Token: 0x02000032 RID: 50
	public static class InterfaceHelper
	{
		// Token: 0x0600026B RID: 619 RVA: 0x0000BE68 File Offset: 0x0000A068
		public static T[] GetComponents<T>()
		{
			List<T> list = new List<T>();
			Object[] array = Object.FindObjectsOfType(typeof(MonoBehaviour));
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] is T)
				{
					T t = (T)((object)array[i]);
					list.Add(t);
				}
			}
			return list.ToArray();
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000BEBC File Offset: 0x0000A0BC
		public static T[] GetComponents<T>(GameObject rGameObject)
		{
			List<T> list = new List<T>();
			Component[] components = rGameObject.GetComponents(typeof(MonoBehaviour));
			for (int i = 0; i < components.Length; i++)
			{
				if (components[i] is T)
				{
					T t = (T)((object)components[i]);
					list.Add(t);
				}
			}
			return list.ToArray();
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000BF10 File Offset: 0x0000A110
		public static T GetComponent<T>(GameObject rGameObject)
		{
			if (rGameObject == null)
			{
				return default(T);
			}
			Type[] interfaceTypes = InterfaceHelper.GetInterfaceTypes(typeof(T));
			if (interfaceTypes == null || interfaceTypes.Length == 0)
			{
				return default(T);
			}
			foreach (Type type in interfaceTypes)
			{
				if (type.IsSubclassOf(typeof(Component)))
				{
					object component = rGameObject.GetComponent(type);
					if (component != null)
					{
						return (T)((object)component);
					}
				}
			}
			return default(T);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000BF94 File Offset: 0x0000A194
		public static T[] FindComponentsOfType<T>()
		{
			Type[] interfaceTypes = InterfaceHelper.GetInterfaceTypes(typeof(T));
			if (interfaceTypes == null || interfaceTypes.Length == 0)
			{
				return null;
			}
			List<T> list = new List<T>();
			foreach (Type type in interfaceTypes)
			{
				if (type.IsSubclassOf(typeof(Component)))
				{
					list.AddRange(Object.FindObjectsOfType(type).Cast<T>());
				}
			}
			return list.Distinct<T>().ToArray<T>();
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000C000 File Offset: 0x0000A200
		public static Type[] GetInterfaceTypes(Type rInterface)
		{
			if (!rInterface.IsInterface)
			{
				return null;
			}
			if (!InterfaceHelper.mInterfaceTypes.ContainsKey(rInterface))
			{
				Assembly[] assemblies = InterfaceHelper.GetAssemblies();
				if (assemblies != null && assemblies.Length != 0)
				{
					List<Type> list = new List<Type>();
					for (int i = 0; i < assemblies.Length; i++)
					{
						try
						{
							Type[] types = assemblies[i].GetTypes();
							if (types != null && types.Length != 0)
							{
								for (int j = 0; j < types.Length; j++)
								{
									if (rInterface.IsAssignableFrom(types[j]) && types[j] != rInterface)
									{
										list.Add(types[j]);
									}
								}
							}
						}
						catch
						{
						}
					}
					InterfaceHelper.mInterfaceTypes.Add(rInterface, list.ToArray());
				}
			}
			return InterfaceHelper.mInterfaceTypes[rInterface];
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000C0BC File Offset: 0x0000A2BC
		public static Assembly[] GetAssemblies()
		{
			return AppDomain.CurrentDomain.GetAssemblies();
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000C0C8 File Offset: 0x0000A2C8
		public static Type[] GetTypes(this Assembly assembly)
		{
			return assembly.GetTypes();
		}

		// Token: 0x04000184 RID: 388
		private static Dictionary<Type, Type[]> mInterfaceTypes = new Dictionary<Type, Type[]>();
	}
}
