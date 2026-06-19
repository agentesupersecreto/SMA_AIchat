using System;
using System.Linq;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using Assets._ReusableScripts.Memorias.JsonMemorias.Clases;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000006 RID: 6
	[Serializable]
	public class MemoriaJsonGenerica : IMemoria
	{
		// Token: 0x0600000A RID: 10 RVA: 0x00002106 File Offset: 0x00000306
		public MemoriaJsonGenerica()
		{
			this.m_memoria = JsonMemoryNode.ProducirRoot("root", this);
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000211F File Offset: 0x0000031F
		public IJsonMemoryNode root
		{
			get
			{
				return this.m_memoria;
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002127 File Offset: 0x00000327
		public IJsonMemoryNode EscribirDeep(string nodeRuta)
		{
			return this.LeerDeep(nodeRuta, true);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002134 File Offset: 0x00000334
		public IJsonMemoryNode LeerDeep(string nodeRuta, bool crear = false)
		{
			string[] array = nodeRuta.Split('/', StringSplitOptions.None);
			IJsonMemoryNode memoria = this.m_memoria;
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				if ((i != 0 || !(text == "root") || !(memoria.nodeID == text)) && !string.IsNullOrEmpty(text))
				{
					this.Leer(text, ref memoria, crear);
					if (memoria == null)
					{
						return null;
					}
				}
			}
			return memoria;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000219A File Offset: 0x0000039A
		public void Leer(string nodeId, ref IJsonMemoryNode node, bool crear = false)
		{
			if (nodeId == null || node == null)
			{
				throw new NotSupportedException();
			}
			if (string.Empty == nodeId)
			{
				return;
			}
			if (!crear)
			{
				node = (IJsonMemoryNode)node.FindChild(nodeId);
				return;
			}
			node = (IJsonMemoryNode)node.FindChildNotNull(nodeId);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000021DC File Offset: 0x000003DC
		public IJsonMemoryNode RemoverDeep(string nodeRuta)
		{
			string[] array = nodeRuta.Split('/', StringSplitOptions.None);
			if (array.Length <= 1)
			{
				Debug.LogWarning("Rota: " + nodeRuta + ", es muy corta. Remover directamente");
			}
			IJsonMemoryNode memoria = this.m_memoria;
			for (int i = 0; i < array.Length - 1; i++)
			{
				string text = array[i];
				if ((i != 0 || !(text == "root") || !(memoria.nodeID == text)) && !string.IsNullOrEmpty(text))
				{
					this.Leer(text, ref memoria, false);
					if (memoria == null)
					{
						return null;
					}
				}
			}
			if (memoria != null)
			{
				return this.Remover(array.Last<string>(), memoria);
			}
			return null;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002270 File Offset: 0x00000470
		public IJsonMemoryNode Remover(string nodeId, IJsonMemoryNode parent)
		{
			if (nodeId == null)
			{
				throw new NotSupportedException();
			}
			if (string.Empty == nodeId)
			{
				return null;
			}
			if (parent == null)
			{
				parent = this.m_memoria;
			}
			IJsonMemoryNode jsonMemoryNode = (IJsonMemoryNode)parent.FindChild(nodeId);
			if (jsonMemoryNode != null)
			{
				parent.RemoverChild(jsonMemoryNode);
			}
			return jsonMemoryNode;
		}

		// Token: 0x04000001 RID: 1
		[NonSerialized]
		protected JsonMemoryNode m_memoria;
	}
}
