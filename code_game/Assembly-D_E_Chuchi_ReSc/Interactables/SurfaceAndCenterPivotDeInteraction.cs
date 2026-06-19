using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Interactables
{
	// Token: 0x0200017F RID: 383
	public class SurfaceAndCenterPivotDeInteraction : CustomMonobehaviour
	{
		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000910 RID: 2320 RVA: 0x00028FAA File Offset: 0x000271AA
		public Transform centerPivot
		{
			get
			{
				return this.m_centerPivot;
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000911 RID: 2321 RVA: 0x00028FB2 File Offset: 0x000271B2
		public Transform interactionTargetPivot
		{
			get
			{
				return this.m_interactionTargetPivot;
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000912 RID: 2322 RVA: 0x00028FBA File Offset: 0x000271BA
		public Transform surfacePivot
		{
			get
			{
				return this.m_surfacePivot;
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000913 RID: 2323 RVA: 0x00028FC2 File Offset: 0x000271C2
		public Transform handInteractionTarget
		{
			get
			{
				return this.m_handnteractionTarget;
			}
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x00028FCC File Offset: 0x000271CC
		public void CheckAndThorw()
		{
			if (this.m_centerPivot == null)
			{
				throw new ArgumentNullException("m_centerPivot", "m_centerPivot null reference.");
			}
			if (this.m_interactionTargetPivot == null)
			{
				throw new ArgumentNullException("m_interactionTargetPivot", "m_interactionTargetPivot null reference.");
			}
			if (this.m_surfacePivot == null)
			{
				throw new ArgumentNullException("m_surfacePivot", "m_surfacePivot null reference.");
			}
			if (this.m_handnteractionTarget == null)
			{
				throw new ArgumentNullException("m_handnteractionTarget", "m_handnteractionTarget null reference.");
			}
		}

		// Token: 0x04000709 RID: 1801
		[SerializeField]
		private Transform m_centerPivot;

		// Token: 0x0400070A RID: 1802
		[SerializeField]
		private Transform m_interactionTargetPivot;

		// Token: 0x0400070B RID: 1803
		[SerializeField]
		private Transform m_surfacePivot;

		// Token: 0x0400070C RID: 1804
		[SerializeField]
		private Transform m_handnteractionTarget;
	}
}
