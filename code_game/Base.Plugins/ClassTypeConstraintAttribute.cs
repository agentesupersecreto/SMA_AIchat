using System;
using UnityEngine;

// Token: 0x02000028 RID: 40
public abstract class ClassTypeConstraintAttribute : PropertyAttribute
{
	// Token: 0x1700001E RID: 30
	// (get) Token: 0x0600016E RID: 366 RVA: 0x000090F8 File Offset: 0x000072F8
	// (set) Token: 0x0600016F RID: 367 RVA: 0x00009100 File Offset: 0x00007300
	public ClassGrouping Grouping
	{
		get
		{
			return this._grouping;
		}
		set
		{
			this._grouping = value;
		}
	}

	// Token: 0x1700001F RID: 31
	// (get) Token: 0x06000170 RID: 368 RVA: 0x00009109 File Offset: 0x00007309
	// (set) Token: 0x06000171 RID: 369 RVA: 0x00009111 File Offset: 0x00007311
	public bool AllowAbstract
	{
		get
		{
			return this._allowAbstract;
		}
		set
		{
			this._allowAbstract = value;
		}
	}

	// Token: 0x06000172 RID: 370 RVA: 0x0000911A File Offset: 0x0000731A
	public virtual bool IsConstraintSatisfied(Type type)
	{
		return this.AllowAbstract || !type.IsAbstract;
	}

	// Token: 0x0400005F RID: 95
	private ClassGrouping _grouping = ClassGrouping.ByNamespaceFlat;

	// Token: 0x04000060 RID: 96
	private bool _allowAbstract;
}
