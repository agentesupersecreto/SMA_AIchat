using System;

namespace Assets._ReusableScripts.Memorias.JsonMemorias
{
	// Token: 0x0200000D RID: 13
	public interface IJsonMemoryNode : IMemoryNode<string, string>, IMemoryNodeEvents, IDataContainer<string>, ISerializedDataContainer
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600005A RID: 90
		bool isRoot { get; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600005B RID: 91
		IJsonMemoryNode root { get; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600005C RID: 92
		IMemoria memory { get; }
	}
}
