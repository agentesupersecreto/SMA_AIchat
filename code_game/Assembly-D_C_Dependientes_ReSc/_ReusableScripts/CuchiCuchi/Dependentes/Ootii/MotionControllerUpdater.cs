using System;
using com.ootii.Actors.AnimationControllers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ootii
{
	// Token: 0x02000162 RID: 354
	[RequireComponent(typeof(MotionController))]
	public class MotionControllerUpdater : CustomUpdatedMonobehaviourBase, ITValleMotionControllerUpdater
	{
		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000766 RID: 1894 RVA: 0x00027012 File Offset: 0x00025212
		public override int updateEvent1Index
		{
			get
			{
				return 13;
			}
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x00027016 File Offset: 0x00025216
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Controller = base.GetComponent<MotionController>();
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x0002702A File Offset: 0x0002522A
		public override void OnUpdateEvent1()
		{
			if (this.m_Controller.enabled)
			{
				this.m_Controller.FixedUpdateMotion();
			}
		}

		// Token: 0x040005D7 RID: 1495
		private MotionController m_Controller;
	}
}
