using System;
using UnityEngine;

namespace Assets._ReusableScripts.Memorias.JsonMemorias
{
	// Token: 0x0200000F RID: 15
	public interface IJsonMemoryNodeBehaviour : IMemoryNode<string, IJsonMemoryNode>, IMemoryNodeEvents, IDataContainer<string>, ISerializedDataContainer
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600005D RID: 93
		Transform transform { get; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600005E RID: 94
		bool isRoot { get; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600005F RID: 95
		IJsonMemoryNode root { get; }
	}
}
