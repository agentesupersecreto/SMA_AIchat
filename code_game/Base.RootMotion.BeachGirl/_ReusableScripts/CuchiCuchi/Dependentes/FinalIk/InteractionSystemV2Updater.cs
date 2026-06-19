using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x0200007D RID: 125
	[RequireComponent(typeof(InteractionSystem))]
	public sealed class InteractionSystemV2Updater : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060004E5 RID: 1253 RVA: 0x00017E26 File Offset: 0x00016026
		public sealed override int updateEvent1Index
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x1400004B RID: 75
		// (add) Token: 0x060004E6 RID: 1254 RVA: 0x00017E2C File Offset: 0x0001602C
		// (remove) Token: 0x060004E7 RID: 1255 RVA: 0x00017E64 File Offset: 0x00016064
		public event Action update;

		// Token: 0x1400004C RID: 76
		// (add) Token: 0x060004E8 RID: 1256 RVA: 0x00017E9C File Offset: 0x0001609C
		// (remove) Token: 0x060004E9 RID: 1257 RVA: 0x00017ED4 File Offset: 0x000160D4
		public event IIKPassEventoHandler lateUpdate;

		// Token: 0x060004EA RID: 1258 RVA: 0x00017F09 File Offset: 0x00016109
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_InteractionSystem = base.GetComponent<InteractionSystemV3>();
			this.m_IIKUpdater = this.GetComponentEnRoot(false);
			if (this.m_IIKUpdater == null)
			{
				throw new ArgumentNullException("m_IIKUpdater", "m_IIKUpdater null reference.");
			}
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x00017F42 File Offset: 0x00016142
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_IIKUpdater.onSingleIKUpdatingJustPass3 += this.M_IIKUpdater_passing;
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x00017F61 File Offset: 0x00016161
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_IIKUpdater.onSingleIKUpdatingJustPass3 -= this.M_IIKUpdater_passing;
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x00017F81 File Offset: 0x00016181
		private void M_IIKUpdater_passing(IIKUpdater updater, Component IK, ref IKEventData IKEventData, ref IKPassEventData PassEventData)
		{
			if (this.m_InteractionSystem.ik != IK)
			{
				return;
			}
			IIKPassEventoHandler iikpassEventoHandler = this.lateUpdate;
			if (iikpassEventoHandler == null)
			{
				return;
			}
			iikpassEventoHandler(updater, IK, ref IKEventData, ref PassEventData);
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00017FAC File Offset: 0x000161AC
		public sealed override void OnUpdateEvent1()
		{
			if (this.update != null)
			{
				this.update();
			}
		}

		// Token: 0x0400033E RID: 830
		private InteractionSystemV3 m_InteractionSystem;

		// Token: 0x0400033F RID: 831
		private IIKUpdater m_IIKUpdater;
	}
}
