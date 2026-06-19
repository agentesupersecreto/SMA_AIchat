using System;
using UnityEngine;

// Token: 0x02000042 RID: 66
[AttributeUsage(AttributeTargets.Field)]
public class RequiredAttribute : PropertyAttribute
{
	// Token: 0x0600023D RID: 573 RVA: 0x0000BFB1 File Offset: 0x0000A1B1
	public RequiredAttribute()
	{
	}

	// Token: 0x0600023E RID: 574 RVA: 0x0000BFB9 File Offset: 0x0000A1B9
	public RequiredAttribute(bool readOnly)
	{
		this.readOnly = readOnly;
	}

	// Token: 0x04000077 RID: 119
	public bool readOnly;
}
