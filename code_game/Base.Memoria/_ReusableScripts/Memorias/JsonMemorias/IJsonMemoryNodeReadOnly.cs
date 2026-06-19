using System;

namespace Assets._ReusableScripts.Memorias.JsonMemorias
{
	// Token: 0x0200000C RID: 12
	public interface IJsonMemoryNodeReadOnly : IMemoryNodeReadOnly<string, string>, IDataContainerReadOnly<string>, ISerializedDataContainer, IDataContainer<string>
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000057 RID: 87
		bool isRoot { get; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000058 RID: 88
		IJsonMemoryNodeReadOnly root { get; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000059 RID: 89
		IMemoria memory { get; }
	}
}
