using System;

// Token: 0x02000013 RID: 19
public interface IDataContainer<TData>
{
	// Token: 0x0600005D RID: 93
	TData FindData(string id);

	// Token: 0x0600005E RID: 94
	bool RemoverData(string id);

	// Token: 0x0600005F RID: 95
	void AddData(string id, TData data, bool replace = true);

	// Token: 0x06000060 RID: 96
	void ClearData();
}
