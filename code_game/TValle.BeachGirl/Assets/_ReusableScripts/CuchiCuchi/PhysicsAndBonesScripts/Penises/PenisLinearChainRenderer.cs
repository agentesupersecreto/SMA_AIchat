using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises
{
	// Token: 0x02000106 RID: 262
	[RequireComponent(typeof(SkinnedMeshRenderer))]
	public class PenisLinearChainRenderer : MonoBehaviour
	{
		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x06000B70 RID: 2928 RVA: 0x000263C4 File Offset: 0x000245C4
		public SkinnedMeshRenderer skinnedMeshRenderer
		{
			get
			{
				return this.m_SkinnedMeshRenderer;
			}
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x000263CC File Offset: 0x000245CC
		private void Awake()
		{
			this.m_SkinnedMeshRenderer = base.GetComponent<SkinnedMeshRenderer>();
		}

		// Token: 0x04000625 RID: 1573
		private SkinnedMeshRenderer m_SkinnedMeshRenderer;
	}
}
