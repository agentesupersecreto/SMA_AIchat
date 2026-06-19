using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Especificas
{
	// Token: 0x020001C2 RID: 450
	public sealed class PeneCambiarRotationOnApplyingIntObj : InteraccionObjectCallBacks
	{
		// Token: 0x06000ACD RID: 2765 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnStaring(InteractionSystem interactionSystem)
		{
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void SetCallBacks()
		{
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x00035C95 File Offset: 0x00033E95
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_InteractionObject.applying += this.M_InteractionObject_applying;
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x00035CB4 File Offset: 0x00033EB4
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_InteractionObject.applying -= this.M_InteractionObject_applying;
		}

		// Token: 0x06000AD1 RID: 2769 RVA: 0x00035CD4 File Offset: 0x00033ED4
		private void M_InteractionObject_applying(IKSolverFullBodyBiped solver, InteractionEffector interactionEffector, FullBodyBipedEffector effector, InteractionTarget target, float timer, float weight)
		{
			MaleChar maleChar = MainChar.current as MaleChar;
			Penis penis = ((maleChar != null) ? maleChar.pene : null);
			if (penis == null)
			{
				return;
			}
			float num = Mathf.InverseLerp(0f, base.currentDuration, timer);
			num = ((num > 0.5f) ? (1f - num) : num);
			num *= 2f;
			num = num.OutPow(this.outPower);
			float num2 = Mathf.Lerp(0f, this.maxAngle, num);
			penis.currentAngleAgainsGravity = num2;
		}

		// Token: 0x04000837 RID: 2103
		public float maxAngle = 20f;

		// Token: 0x04000838 RID: 2104
		public float outPower = 1f;
	}
}
