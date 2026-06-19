using System;

// Token: 0x02000045 RID: 69
public abstract class StringSelectorProveedorAttribute : Attribute
{
	// Token: 0x06000247 RID: 583 RVA: 0x0000C26B File Offset: 0x0000A46B
	public StringSelectorProveedorAttribute(string StaticFieldName)
	{
		this.m_staticFieldName = StaticFieldName;
	}

	// Token: 0x17000031 RID: 49
	// (get) Token: 0x06000248 RID: 584 RVA: 0x0000C27A File Offset: 0x0000A47A
	public string staticFieldName
	{
		get
		{
			return this.m_staticFieldName;
		}
	}

	// Token: 0x0400007E RID: 126
	private string m_staticFieldName;
}
