using System;
using Assets._ReusableScripts.Memorias.JsonMemorias;

namespace Assets
{
	// Token: 0x02000004 RID: 4
	public interface IMemoria
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5
		IJsonMemoryNode root { get; }

		// Token: 0x06000006 RID: 6
		IJsonMemoryNode EscribirDeep(string nodeRuta);

		// Token: 0x06000007 RID: 7
		IJsonMemoryNode LeerDeep(string nodeRuta, bool crear = false);

		// Token: 0x06000008 RID: 8
		IJsonMemoryNode RemoverDeep(string nodeRuta);
	}
}
