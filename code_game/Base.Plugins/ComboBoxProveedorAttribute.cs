using System;

// Token: 0x0200003B RID: 59
public abstract class ComboBoxProveedorAttribute : Attribute
{
	// Token: 0x06000224 RID: 548 RVA: 0x0000BC0E File Offset: 0x00009E0E
	public ComboBoxProveedorAttribute(string StaticFieldNameID, string StaticFieldNameDisplay)
	{
		this.m_staticFieldNameDisplay = StaticFieldNameDisplay;
		this.m_staticFieldNameID = StaticFieldNameID;
	}

	// Token: 0x17000027 RID: 39
	// (get) Token: 0x06000225 RID: 549 RVA: 0x0000BC24 File Offset: 0x00009E24
	public string staticFieldNameDisplay
	{
		get
		{
			return this.m_staticFieldNameDisplay;
		}
	}

	// Token: 0x17000028 RID: 40
	// (get) Token: 0x06000226 RID: 550 RVA: 0x0000BC2C File Offset: 0x00009E2C
	public string staticFieldNameID
	{
		get
		{
			return this.m_staticFieldNameID;
		}
	}

	// Token: 0x04000069 RID: 105
	private string m_staticFieldNameDisplay;

	// Token: 0x0400006A RID: 106
	private string m_staticFieldNameID;
}
