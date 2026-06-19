using System;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x0200011F RID: 287
	[RequireComponent(typeof(Animator))]
	public sealed class MotionControllerAnimatorEventsListiner : MonoBehaviour
	{
		// Token: 0x060011C5 RID: 4549 RVA: 0x000639E7 File Offset: 0x00061BE7
		private void Awake()
		{
			this.m_Animator = base.GetComponent<Animator>();
			this.m_MotionController = base.GetComponentInParent<MotionController>();
			if (this.m_MotionController == null)
			{
				throw new ArgumentNullException("m_MotionController", "m_MotionController null reference.");
			}
		}

		// Token: 0x060011C6 RID: 4550 RVA: 0x00063A1F File Offset: 0x00061C1F
		private void OnAnimatorIK(int layerIndex)
		{
			this.m_MotionController.OnAnimatorIK(layerIndex);
		}

		// Token: 0x060011C7 RID: 4551 RVA: 0x00063A2D File Offset: 0x00061C2D
		private void OnAnimatorMove()
		{
			this.m_MotionController.OnAnimatorMove();
		}

		// Token: 0x04000D84 RID: 3460
		private Animator m_Animator;

		// Token: 0x04000D85 RID: 3461
		private MotionController m_MotionController;
	}
}
