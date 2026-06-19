using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000DB RID: 219
	[Serializable]
	public struct IKPassEventData
	{
		// Token: 0x0600061C RID: 1564 RVA: 0x000177EA File Offset: 0x000159EA
		public IKPassEventData(int Index, bool EsUltimo)
		{
			this.m_index = Index;
			this.m_esUltimo = EsUltimo;
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x0600061D RID: 1565 RVA: 0x000177FA File Offset: 0x000159FA
		public int index
		{
			get
			{
				return this.m_index;
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x0600061E RID: 1566 RVA: 0x00017802 File Offset: 0x00015A02
		public bool esUltimo
		{
			get
			{
				return this.m_esUltimo;
			}
		}

		// Token: 0x040001A0 RID: 416
		[ReadOnlyUI]
		[SerializeField]
		private int m_index;

		// Token: 0x040001A1 RID: 417
		[ReadOnlyUI]
		[SerializeField]
		private bool m_esUltimo;
	}
}
