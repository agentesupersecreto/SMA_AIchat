using System;
using Assets._ReusableScripts.Memorias.JsonMemorias.Clases;

namespace Assets
{
	// Token: 0x02000005 RID: 5
	[Serializable]
	public class MemoriaJsonGenerica<TNode> : MemoriaJsonGenerica where TNode : JsonMemoryNode, new()
	{
		// Token: 0x06000009 RID: 9 RVA: 0x000020E8 File Offset: 0x000002E8
		public MemoriaJsonGenerica()
		{
			this.m_memoria = JsonMemoryNode.ProducirRoot<TNode>("root", this);
		}
	}
}
