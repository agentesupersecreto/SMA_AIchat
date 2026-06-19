using System;
using UnityEngine;

// Token: 0x02000040 RID: 64
public class FixedListV2Attribute : PropertyAttribute
{
	// Token: 0x06000238 RID: 568 RVA: 0x0000BF74 File Offset: 0x0000A174
	public FixedListV2Attribute(Type ProveedorType, string namesField, string dataField)
	{
		this.m_proveedorType = ProveedorType;
		this.m_namesField = namesField;
		this.m_dataField = dataField;
	}

	// Token: 0x1700002C RID: 44
	// (get) Token: 0x06000239 RID: 569 RVA: 0x0000BF91 File Offset: 0x0000A191
	public string namesField
	{
		get
		{
			return this.m_namesField;
		}
	}

	// Token: 0x1700002D RID: 45
	// (get) Token: 0x0600023A RID: 570 RVA: 0x0000BF99 File Offset: 0x0000A199
	public string dataField
	{
		get
		{
			return this.m_dataField;
		}
	}

	// Token: 0x1700002E RID: 46
	// (get) Token: 0x0600023B RID: 571 RVA: 0x0000BFA1 File Offset: 0x0000A1A1
	public Type proveedorType
	{
		get
		{
			return this.m_proveedorType;
		}
	}

	// Token: 0x04000074 RID: 116
	private Type m_proveedorType;

	// Token: 0x04000075 RID: 117
	private string m_namesField;

	// Token: 0x04000076 RID: 118
	private string m_dataField;
}
