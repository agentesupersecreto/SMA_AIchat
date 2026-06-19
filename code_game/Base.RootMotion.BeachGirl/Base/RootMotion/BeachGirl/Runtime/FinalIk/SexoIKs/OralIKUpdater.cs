using System;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.SexoIKs
{
	// Token: 0x02000026 RID: 38
	[RequireComponent(typeof(LookAtIK))]
	public class OralIKUpdater : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000154 RID: 340 RVA: 0x00008214 File Offset: 0x00006414
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.onOralAt);
			}
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0000821D File Offset: 0x0000641D
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_lookAt = base.GetComponent<LookAtIK>();
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00008231 File Offset: 0x00006431
		public override void OnUpdateEvent1()
		{
			if (this.m_lookAt.enabled)
			{
				this.m_lookAt.enabled = false;
			}
			this.m_lookAt.solver.Update();
		}

		// Token: 0x040000E5 RID: 229
		private LookAtIK m_lookAt;
	}
}
