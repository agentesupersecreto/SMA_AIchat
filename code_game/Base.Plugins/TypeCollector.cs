using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// Token: 0x0200002D RID: 45
public class TypeCollector
{
	// Token: 0x0600018F RID: 399 RVA: 0x00009388 File Offset: 0x00007588
	public static List<Type> GetTypesBy(Func<Type, bool> evaluator)
	{
		List<Type> list = new List<Type>();
		foreach (Assembly assembly2 in from assembly in AppDomain.CurrentDomain.GetAssemblies()
			where assembly.FullName.Contains("Assembly")
			select assembly)
		{
			list.AddRange(assembly2.GetTypes().Where(evaluator));
		}
		return list;
	}

	// Token: 0x06000190 RID: 400 RVA: 0x00009410 File Offset: 0x00007610
	public static List<Type> GetTypesBy(Func<Type, bool> evaluator, HashSet<Type> ignored)
	{
		List<Type> typesBy = TypeCollector.GetTypesBy(evaluator);
		typesBy.RemoveAll((Type t) => ignored.Contains(t));
		return typesBy;
	}

	// Token: 0x06000191 RID: 401 RVA: 0x00009443 File Offset: 0x00007643
	public static Func<Type, bool> PublicClassNoAbstract()
	{
		return (Type t) => t.IsPublic && t.IsClass && !t.IsAbstract;
	}

	// Token: 0x06000192 RID: 402 RVA: 0x00009464 File Offset: 0x00007664
	public static Func<Type, bool> PublicClassNoAbstractInherited(Type baseType)
	{
		return (Type t) => t.IsPublic && t.IsClass && !t.IsAbstract && baseType.IsAssignableFrom(t);
	}

	// Token: 0x06000193 RID: 403 RVA: 0x0000947D File Offset: 0x0000767D
	public static Func<Type, bool> PublicClassNoAbstractInherited<TBase>() where TBase : class
	{
		return TypeCollector.PublicClassNoAbstractInherited(typeof(TBase));
	}
}
