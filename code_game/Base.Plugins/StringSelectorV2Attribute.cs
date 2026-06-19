using System;
using UnityEngine;

// Token: 0x02000044 RID: 68
public class StringSelectorV2Attribute : PropertyAttribute
{
	// Token: 0x06000245 RID: 581 RVA: 0x0000C254 File Offset: 0x0000A454
	public StringSelectorV2Attribute(Type ProveedorType)
	{
		this.m_proveedorType = ProveedorType;
	}

	// Token: 0x17000030 RID: 48
	// (get) Token: 0x06000246 RID: 582 RVA: 0x0000C263 File Offset: 0x0000A463
	public Type proveedorType
	{
		get
		{
			return this.m_proveedorType;
		}
	}

	// Token: 0x0400007C RID: 124
	public static bool flagClearCache;

	// Token: 0x0400007D RID: 125
	private Type m_proveedorType;
}
