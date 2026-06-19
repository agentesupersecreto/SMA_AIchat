using System;
using UnityEngine;

// Token: 0x0200003C RID: 60
[AttributeUsage(AttributeTargets.Field)]
public class CoolArrayItemAttribute : PropertyAttribute
{
	// Token: 0x06000227 RID: 551 RVA: 0x0000BC34 File Offset: 0x00009E34
	public CoolArrayItemAttribute()
	{
	}

	// Token: 0x06000228 RID: 552 RVA: 0x0000BC51 File Offset: 0x00009E51
	public CoolArrayItemAttribute(bool Reorderable)
	{
		this.reorderable = Reorderable;
	}

	// Token: 0x06000229 RID: 553 RVA: 0x0000BC75 File Offset: 0x00009E75
	public CoolArrayItemAttribute(bool Reorderable, bool Removable)
		: this(Reorderable)
	{
		this.removable = Removable;
	}

	// Token: 0x0600022A RID: 554 RVA: 0x0000BC85 File Offset: 0x00009E85
	public CoolArrayItemAttribute(bool Reorderable, bool Removable, bool includeChildre)
		: this(Reorderable, Removable)
	{
		this.includeChildre = includeChildre;
	}

	// Token: 0x0400006B RID: 107
	public bool includeChildre = true;

	// Token: 0x0400006C RID: 108
	public bool reorderable = true;

	// Token: 0x0400006D RID: 109
	public bool removable = true;
}
