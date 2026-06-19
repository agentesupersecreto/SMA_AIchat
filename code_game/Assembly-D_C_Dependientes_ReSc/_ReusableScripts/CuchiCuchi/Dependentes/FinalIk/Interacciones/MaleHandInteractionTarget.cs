using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x0200017D RID: 381
	[RequireComponent(typeof(InteractionTarget))]
	public class MaleHandInteractionTarget : CustomMonobehaviour
	{
		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000838 RID: 2104 RVA: 0x0002B6CC File Offset: 0x000298CC
		public InteractionTarget interactionTarget
		{
			get
			{
				return this.m_InteractionTarget;
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000839 RID: 2105 RVA: 0x0002B6D4 File Offset: 0x000298D4
		public Transform proximalIndex
		{
			get
			{
				return this.m_ProximalIndex;
			}
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x0002B6DC File Offset: 0x000298DC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_InteractionTarget = base.GetComponent<InteractionTarget>();
			if (this.m_ProximalIndex == null)
			{
				throw new ArgumentNullException("m_ProximalIndex", "m_ProximalIndex null reference.");
			}
		}

		// Token: 0x0400069A RID: 1690
		private InteractionTarget m_InteractionTarget;

		// Token: 0x0400069B RID: 1691
		[SerializeField]
		private Transform m_ProximalIndex;
	}
}
