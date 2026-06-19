using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000DC RID: 220
	[Serializable]
	public struct IKEventData
	{
		// Token: 0x0600061F RID: 1567 RVA: 0x0001780A File Offset: 0x00015A0A
		public IKEventData(int Id, int Llayer, int IndexEnLayer, bool EsUltimoDeLayer, bool EsUltimoLayer)
		{
			this.m_ID = Id;
			this.m_EsUltimoDeLayer = EsUltimoDeLayer;
			this.m_layer = Llayer;
			this.m_EsUltimoLayer = EsUltimoLayer;
			this.m_IndexEnLayer = IndexEnLayer;
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000620 RID: 1568 RVA: 0x00017831 File Offset: 0x00015A31
		public int id
		{
			get
			{
				return this.m_ID;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000621 RID: 1569 RVA: 0x00017839 File Offset: 0x00015A39
		public int layer
		{
			get
			{
				return this.m_layer;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000622 RID: 1570 RVA: 0x00017841 File Offset: 0x00015A41
		public int indexEnLayer
		{
			get
			{
				return this.m_IndexEnLayer;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000623 RID: 1571 RVA: 0x00017849 File Offset: 0x00015A49
		public bool esUltimoDeLayer
		{
			get
			{
				return this.m_EsUltimoDeLayer;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000624 RID: 1572 RVA: 0x00017851 File Offset: 0x00015A51
		public bool esUltimoLayer
		{
			get
			{
				return this.m_EsUltimoLayer;
			}
		}

		// Token: 0x040001A2 RID: 418
		[ReadOnlyUI]
		[SerializeField]
		private int m_ID;

		// Token: 0x040001A3 RID: 419
		[ReadOnlyUI]
		[SerializeField]
		private int m_layer;

		// Token: 0x040001A4 RID: 420
		[ReadOnlyUI]
		[SerializeField]
		private int m_IndexEnLayer;

		// Token: 0x040001A5 RID: 421
		[ReadOnlyUI]
		[SerializeField]
		private bool m_EsUltimoDeLayer;

		// Token: 0x040001A6 RID: 422
		[ReadOnlyUI]
		[SerializeField]
		private bool m_EsUltimoLayer;
	}
}
