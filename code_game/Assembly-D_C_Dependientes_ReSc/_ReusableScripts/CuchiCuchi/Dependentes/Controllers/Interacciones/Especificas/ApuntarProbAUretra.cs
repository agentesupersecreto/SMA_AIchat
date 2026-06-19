using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using Assets._ReusableScripts.Miscellaneous;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Especificas
{
	// Token: 0x020001BB RID: 443
	[RequireComponent(typeof(InteractionObjectV2))]
	[RequireComponent(typeof(AddProbToInteractionSimple))]
	public class ApuntarProbAUretra : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000A99 RID: 2713 RVA: 0x00034940 File Offset: 0x00032B40
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.prob == null)
			{
				throw new ArgumentNullException("prob", "prob null reference.");
			}
			this.m_InteractionObjectV2 = base.GetComponent<InteractionObjectV2>();
			this.m_probAdder = base.GetComponent<AddProbToInteractionSimple>();
			this.m_probAdder.comenzada += this.M_probAdder_comenzada;
			this.m_probAdder.terminada += this.M_probAdder_terminada;
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x000349B7 File Offset: 0x00032BB7
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.m_probAdder.comenzada -= this.M_probAdder_comenzada;
			this.m_probAdder.terminada -= this.M_probAdder_terminada;
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x000349EE File Offset: 0x00032BEE
		private void M_probAdder_comenzada(InteraccionObjectComienzaTerminaCallBacks obj)
		{
			this.m_probAdder.follower.followed += this.Follower_followed;
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x00034A0C File Offset: 0x00032C0C
		private void M_probAdder_terminada(InteraccionObjectComienzaTerminaCallBacks obj)
		{
			if (this.m_probAdder.follower)
			{
				this.m_probAdder.follower.followed -= this.Follower_followed;
			}
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x00034A3C File Offset: 0x00032C3C
		private void Follower_followed(MatrixFollowerBase obj)
		{
			if (this.prob == null)
			{
				return;
			}
			if (this.uretra == null)
			{
				return;
			}
			this.prob.LookAt(this.uretra);
		}

		// Token: 0x040007FE RID: 2046
		public Transform prob;

		// Token: 0x040007FF RID: 2047
		public Transform uretra;

		// Token: 0x04000800 RID: 2048
		private AddProbToInteractionSimple m_probAdder;

		// Token: 0x04000801 RID: 2049
		private InteractionObjectV2 m_InteractionObjectV2;
	}
}
