using System;

// Token: 0x02000029 RID: 41
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public sealed class ClassExtendsAttribute : ClassTypeConstraintAttribute
{
	// Token: 0x06000174 RID: 372 RVA: 0x0000913E File Offset: 0x0000733E
	public ClassExtendsAttribute()
	{
	}

	// Token: 0x06000175 RID: 373 RVA: 0x00009146 File Offset: 0x00007346
	public ClassExtendsAttribute(Type baseType)
	{
		this.BaseType = baseType;
	}

	// Token: 0x17000020 RID: 32
	// (get) Token: 0x06000176 RID: 374 RVA: 0x00009155 File Offset: 0x00007355
	// (set) Token: 0x06000177 RID: 375 RVA: 0x0000915D File Offset: 0x0000735D
	public Type BaseType { get; private set; }

	// Token: 0x06000178 RID: 376 RVA: 0x00009166 File Offset: 0x00007366
	public override bool IsConstraintSatisfied(Type type)
	{
		return base.IsConstraintSatisfied(type) && this.BaseType.IsAssignableFrom(type) && type != this.BaseType;
	}
}
