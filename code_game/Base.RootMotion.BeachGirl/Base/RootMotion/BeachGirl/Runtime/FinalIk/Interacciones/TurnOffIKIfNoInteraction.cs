using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.Interacciones
{
	// Token: 0x0200002A RID: 42
	[RequireComponent(typeof(InteractionSystemV3))]
	[RequireComponent(typeof(FullBodyBipedIK))]
	public class TurnOffIKIfNoInteraction : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600018B RID: 395 RVA: 0x0000930C File Offset: 0x0000750C
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600018C RID: 396 RVA: 0x00009314 File Offset: 0x00007514
		public ModificableDeBool forceTurnOnOR
		{
			get
			{
				return this.m_forceTurnOnOR;
			}
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0000931C File Offset: 0x0000751C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_InteractionSystemV3 = base.GetComponent<InteractionSystemV3>();
			this.m_FullBodyBipedIK = base.GetComponent<FullBodyBipedIK>();
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000933C File Offset: 0x0000753C
		public override void OnUpdateEvent1()
		{
			bool flag = this.m_forceTurnOnOR.Or(this.forceTurnOn);
			if (this.m_InteractionSystemV3.estaInteractuando || flag)
			{
				this.m_FullBodyBipedIK.solver.IKPositionWeight = Mathf.MoveTowards(this.m_FullBodyBipedIK.solver.IKPositionWeight, 1f, Time.deltaTime * 4f);
				return;
			}
			this.m_FullBodyBipedIK.solver.IKPositionWeight = Mathf.MoveTowards(this.m_FullBodyBipedIK.solver.IKPositionWeight, 0f, Time.deltaTime * 0.25f);
		}

		// Token: 0x0400010A RID: 266
		private InteractionSystemV3 m_InteractionSystemV3;

		// Token: 0x0400010B RID: 267
		private FullBodyBipedIK m_FullBodyBipedIK;

		// Token: 0x0400010C RID: 268
		public bool forceTurnOn;

		// Token: 0x0400010D RID: 269
		private ModificableDeBool m_forceTurnOnOR = new ModificableDeBool(false);
	}
}
