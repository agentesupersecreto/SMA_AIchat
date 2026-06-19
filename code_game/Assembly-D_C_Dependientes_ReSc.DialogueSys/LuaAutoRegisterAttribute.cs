using System;
using System.Collections.Generic;
using System.Reflection;
using PixelCrushers.DialogueSystem;
using UnityEngine;

// Token: 0x02000002 RID: 2
[AttributeUsage(AttributeTargets.Method)]
public class LuaAutoRegisterAttribute : Attribute
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public static void Load(Type type)
	{
		foreach (MethodInfo methodInfo in type.GetMethods(BindingFlags.Instance | BindingFlags.Public))
		{
			HashSet<MethodInfo> hashSet;
			if (!LuaAutoRegisterAttribute.m_IN_Type_Registrables.TryGetValue(type, out hashSet))
			{
				hashSet = new HashSet<MethodInfo>();
				LuaAutoRegisterAttribute.m_IN_Type_Registrables.Add(type, hashSet);
			}
			if (methodInfo.GetCustomAttribute<LuaAutoRegisterAttribute>() != null)
			{
				hashSet.Add(methodInfo);
			}
		}
	}

	// Token: 0x06000002 RID: 2 RVA: 0x000020AC File Offset: 0x000002AC
	public static void Register(object instance)
	{
		HashSet<MethodInfo> hashSet;
		if (!LuaAutoRegisterAttribute.m_IN_Type_Registrables.TryGetValue(instance.GetType(), out hashSet))
		{
			Debug.LogError("cant register lua functions from " + instance.GetType().Name);
			return;
		}
		foreach (MethodInfo methodInfo in hashSet)
		{
			Lua.RegisterFunction(methodInfo.Name, instance, methodInfo);
		}
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002130 File Offset: 0x00000330
	public static void Unregister(object instance)
	{
		HashSet<MethodInfo> hashSet;
		if (!LuaAutoRegisterAttribute.m_IN_Type_Registrables.TryGetValue(instance.GetType(), out hashSet))
		{
			Debug.LogError("cant unregister lua functions from " + instance.GetType().Name);
			return;
		}
		foreach (MethodInfo methodInfo in hashSet)
		{
			Lua.UnregisterFunction(methodInfo.Name);
		}
	}

	// Token: 0x04000001 RID: 1
	private static Dictionary<Type, HashSet<MethodInfo>> m_IN_Type_Registrables = new Dictionary<Type, HashSet<MethodInfo>>();
}
