using System;

// Token: 0x0200002A RID: 42
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public sealed class ClassImplementsAttribute : ClassTypeConstraintAttribute
{
	// Token: 0x06000179 RID: 377 RVA: 0x0000918D File Offset: 0x0000738D
	public ClassImplementsAttribute()
	{
	}

	// Token: 0x0600017A RID: 378 RVA: 0x00009195 File Offset: 0x00007395
	public ClassImplementsAttribute(Type interfaceType)
	{
		this.InterfaceType = interfaceType;
	}

	// Token: 0x17000021 RID: 33
	// (get) Token: 0x0600017B RID: 379 RVA: 0x000091A4 File Offset: 0x000073A4
	// (set) Token: 0x0600017C RID: 380 RVA: 0x000091AC File Offset: 0x000073AC
	public Type InterfaceType { get; private set; }

	// Token: 0x0600017D RID: 381 RVA: 0x000091B8 File Offset: 0x000073B8
	public override bool IsConstraintSatisfied(Type type)
	{
		if (base.IsConstraintSatisfied(type))
		{
			Type[] interfaces = type.GetInterfaces();
			for (int i = 0; i < interfaces.Length; i++)
			{
				if (interfaces[i] == this.InterfaceType)
				{
					return true;
				}
			}
		}
		return false;
	}
}
