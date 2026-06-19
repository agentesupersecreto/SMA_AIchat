using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000D4 RID: 212
	public class PenetradorRenderers : MonoBehaviour
	{
		// Token: 0x17000302 RID: 770
		// (get) Token: 0x060007DB RID: 2011 RVA: 0x000185D2 File Offset: 0x000167D2
		public Renderer main
		{
			get
			{
				return this.m_main;
			}
		}

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x060007DC RID: 2012 RVA: 0x000185DA File Offset: 0x000167DA
		public IReadOnlyList<Renderer> all
		{
			get
			{
				return this.m_all;
			}
		}

		// Token: 0x0400045E RID: 1118
		[SerializeField]
		private Renderer m_main;

		// Token: 0x0400045F RID: 1119
		[SerializeField]
		private Renderer[] m_all;
	}
}
