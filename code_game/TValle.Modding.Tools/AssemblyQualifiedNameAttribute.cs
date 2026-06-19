using System;
using UnityEngine;

// Token: 0x02000003 RID: 3
public class AssemblyQualifiedNameAttribute : PropertyAttribute
{
	// Token: 0x06000006 RID: 6 RVA: 0x0000212D File Offset: 0x0000032D
	public AssemblyQualifiedNameAttribute(Type Implementing)
	{
		this.implementingClass = Implementing;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x0000213C File Offset: 0x0000033C
	public AssemblyQualifiedNameAttribute(Type ImplementingClass, Type ImplementingInterface)
	{
		this.implementingClass = ImplementingClass;
		this.implementingInterface = ImplementingInterface;
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002152 File Offset: 0x00000352
	public AssemblyQualifiedNameAttribute()
	{
	}

	// Token: 0x06000009 RID: 9 RVA: 0x0000215C File Offset: 0x0000035C
	public bool IsImplementing(Type other)
	{
		if (other == null)
		{
			return false;
		}
		bool flag = this.implementingClass != null;
		bool flag2 = this.implementingInterface != null;
		if (!flag && !flag2)
		{
			return true;
		}
		if (flag && flag2)
		{
			return this.implementingClass.IsAssignableFrom(other) && this.implementingInterface.IsAssignableFrom(other);
		}
		if (flag)
		{
			return this.implementingClass.IsAssignableFrom(other);
		}
		if (flag2)
		{
			return this.implementingInterface.IsAssignableFrom(other);
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x0600000A RID: 10 RVA: 0x000021E0 File Offset: 0x000003E0
	public string GetError(Type other)
	{
		if (other == null)
		{
			return string.Empty;
		}
		bool flag = this.implementingClass != null;
		bool flag2 = this.implementingInterface != null;
		if (!flag && !flag2)
		{
			return string.Empty;
		}
		if (flag && flag2)
		{
			return string.Concat(new string[]
			{
				"The selected script (",
				other.Name,
				") does not implement the ",
				this.implementingClass.Name,
				" or ",
				this.implementingInterface.Name,
				" types."
			});
		}
		if (flag)
		{
			return "The selected script (" + other.Name + ") does not implement the type " + this.implementingClass.Name;
		}
		if (flag2)
		{
			return "The selected script (" + other.Name + ") does not implement the type " + this.implementingInterface.Name;
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x04000001 RID: 1
	public Type implementingClass;

	// Token: 0x04000002 RID: 2
	public Type implementingInterface;
}
