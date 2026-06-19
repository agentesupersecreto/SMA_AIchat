using System;

// Token: 0x0200002B RID: 43
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public sealed class ClassIsAttribute : ClassTypeConstraintAttribute
{
	// Token: 0x0600017E RID: 382 RVA: 0x000091F6 File Offset: 0x000073F6
	public ClassIsAttribute(Type baseType1)
	{
		this.BaseType1 = baseType1;
	}

	// Token: 0x0600017F RID: 383 RVA: 0x00009205 File Offset: 0x00007405
	public ClassIsAttribute(Type baseType1, Type baseType2)
		: this(baseType1)
	{
		this.BaseType2 = baseType2;
	}

	// Token: 0x17000022 RID: 34
	// (get) Token: 0x06000180 RID: 384 RVA: 0x00009215 File Offset: 0x00007415
	// (set) Token: 0x06000181 RID: 385 RVA: 0x0000921D File Offset: 0x0000741D
	public Type BaseType1 { get; private set; }

	// Token: 0x17000023 RID: 35
	// (get) Token: 0x06000182 RID: 386 RVA: 0x00009226 File Offset: 0x00007426
	// (set) Token: 0x06000183 RID: 387 RVA: 0x0000922E File Offset: 0x0000742E
	public Type BaseType2 { get; private set; }

	// Token: 0x06000184 RID: 388 RVA: 0x00009237 File Offset: 0x00007437
	public override bool IsConstraintSatisfied(Type type)
	{
		return base.IsConstraintSatisfied(type) && this.BaseType1.IsAssignableFrom(type) && (this.BaseType2 == null || this.BaseType2.IsAssignableFrom(type));
	}
}
