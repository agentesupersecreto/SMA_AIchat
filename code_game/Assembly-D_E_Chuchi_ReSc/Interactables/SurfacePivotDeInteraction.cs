using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Interactables
{
	// Token: 0x02000180 RID: 384
	public class SurfacePivotDeInteraction : CustomMonobehaviour
	{
		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000916 RID: 2326 RVA: 0x00029051 File Offset: 0x00027251
		public Transform superficiePivot
		{
			get
			{
				return this.m_superficiePivot;
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000917 RID: 2327 RVA: 0x00029059 File Offset: 0x00027259
		public Transform handnteractionPivot
		{
			get
			{
				return this.m_handInteractionPivot;
			}
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000918 RID: 2328 RVA: 0x00029061 File Offset: 0x00027261
		public Transform handnteractionTarget
		{
			get
			{
				return this.m_handnteractionTarget;
			}
		}

		// Token: 0x0400070D RID: 1805
		[SerializeField]
		private Transform m_superficiePivot;

		// Token: 0x0400070E RID: 1806
		[SerializeField]
		private Transform m_handInteractionPivot;

		// Token: 0x0400070F RID: 1807
		[SerializeField]
		private Transform m_handnteractionTarget;
	}
}
