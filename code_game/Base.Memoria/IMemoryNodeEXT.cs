using System;
using System.Globalization;
using Assets._ReusableScripts.Memorias;

// Token: 0x02000002 RID: 2
public static class IMemoryNodeEXT
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public static IMemoryNode<TData, TToLoadData> FindChildNotNull<TData, TToLoadData>(this IMemoryNode<TData, TToLoadData> node, int id)
	{
		return node.FindChildNotNull(id.ToString(CultureInfo.InvariantCulture));
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002064 File Offset: 0x00000264
	public static int GetNodeID<TData, TToLoadData>(this IMemoryNode<TData, TToLoadData> node)
	{
		return Convert.ToInt32(node.nodeID, CultureInfo.InvariantCulture);
	}
}
