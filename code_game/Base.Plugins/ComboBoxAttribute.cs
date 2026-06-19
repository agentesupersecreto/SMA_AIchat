using System;
using UnityEngine;

// Token: 0x0200003A RID: 58
public class ComboBoxAttribute : PropertyAttribute
{
	// Token: 0x06000222 RID: 546 RVA: 0x0000BBF7 File Offset: 0x00009DF7
	public ComboBoxAttribute(Type ProveedorType)
	{
		this.m_proveedorType = ProveedorType;
	}

	// Token: 0x17000026 RID: 38
	// (get) Token: 0x06000223 RID: 547 RVA: 0x0000BC06 File Offset: 0x00009E06
	public Type proveedorType
	{
		get
		{
			return this.m_proveedorType;
		}
	}

	// Token: 0x04000068 RID: 104
	private Type m_proveedorType;
}
