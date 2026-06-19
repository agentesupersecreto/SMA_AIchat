using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.Memorias
{
	// Token: 0x0200000A RID: 10
	public interface IMemoryNode<TData, TToLoadData> : IMemoryNodeEvents, IDataContainer<TData>
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000042 RID: 66
		string nodeID { get; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000043 RID: 67
		IReadOnlyDictionary<string, TData> data { get; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000044 RID: 68
		IReadOnlyList<IMemoryNode<TData, TToLoadData>> children { get; }

		// Token: 0x06000045 RID: 69
		IMemoryNode<TData, TToLoadData> FindChild(string id);

		// Token: 0x06000046 RID: 70
		T FindChild<T>(string id) where T : class, IMemoryNode<TData, TToLoadData>;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000047 RID: 71
		// (remove) Token: 0x06000048 RID: 72
		event Action<IMemoryNode<TData, TToLoadData>> loaded;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000049 RID: 73
		// (remove) Token: 0x0600004A RID: 74
		event Action<IMemoryNode<TData, TToLoadData>> saving;

		// Token: 0x0600004B RID: 75
		IMemoryNode<TData, TToLoadData> FindChildNotNull(string id);

		// Token: 0x0600004C RID: 76
		T FindChildNotNull<T>(string id) where T : class, IMemoryNode<TData, TToLoadData>;

		// Token: 0x0600004D RID: 77
		bool RemoverChild(IMemoryNode<TData, TToLoadData> child);

		// Token: 0x0600004E RID: 78
		bool RemoverChild(string id);

		// Token: 0x0600004F RID: 79
		void AddChild(IMemoryNode<TData, TToLoadData> child);

		// Token: 0x06000050 RID: 80
		void Load(TToLoadData loadData);

		// Token: 0x06000051 RID: 81
		TToLoadData Save();

		// Token: 0x06000052 RID: 82
		void ResetMemoria();
	}
}
