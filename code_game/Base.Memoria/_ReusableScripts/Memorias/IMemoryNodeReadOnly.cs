using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.Memorias
{
	// Token: 0x02000009 RID: 9
	public interface IMemoryNodeReadOnly<TData, TToLoadData> : IDataContainerReadOnly<TData>
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600003D RID: 61
		string nodeID { get; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600003E RID: 62
		IReadOnlyDictionary<string, TData> data { get; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600003F RID: 63
		IReadOnlyList<IMemoryNodeReadOnly<TData, TToLoadData>> childrenReadOnly { get; }

		// Token: 0x06000040 RID: 64
		IMemoryNodeReadOnly<TData, TToLoadData> FindChildReadOnly(string id);

		// Token: 0x06000041 RID: 65
		T FindChildReadOnly<T>(string id) where T : class, IMemoryNodeReadOnly<TData, TToLoadData>;
	}
}
