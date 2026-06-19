using System;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x0200011E RID: 286
	[RequireComponent(typeof(MotionController))]
	public class DefaultMotionControllerUpdater : MonoBehaviour, ITValleMotionControllerUpdater
	{
		// Token: 0x060011C2 RID: 4546 RVA: 0x000639B7 File Offset: 0x00061BB7
		private void Awake()
		{
			this.m_controller = base.GetComponent<MotionController>();
		}

		// Token: 0x060011C3 RID: 4547 RVA: 0x000639C5 File Offset: 0x00061BC5
		public void FixedUpdate()
		{
			if (this.m_controller.enabled)
			{
				this.m_controller.FixedUpdateMotion();
			}
		}

		// Token: 0x04000D83 RID: 3459
		private MotionController m_controller;
	}
}
