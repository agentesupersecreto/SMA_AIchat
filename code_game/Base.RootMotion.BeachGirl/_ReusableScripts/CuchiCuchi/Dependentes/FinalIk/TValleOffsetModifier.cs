using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x0200006A RID: 106
	public abstract class TValleOffsetModifier : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000433 RID: 1075
		protected abstract void OnModifyOffset(FullBodyBipedIK ik);

		// Token: 0x1400003B RID: 59
		// (add) Token: 0x06000434 RID: 1076 RVA: 0x00013E88 File Offset: 0x00012088
		// (remove) Token: 0x06000435 RID: 1077 RVA: 0x00013EC0 File Offset: 0x000120C0
		public event Action<TValleOffsetModifier> modifying;

		// Token: 0x1400003C RID: 60
		// (add) Token: 0x06000436 RID: 1078 RVA: 0x00013EF8 File Offset: 0x000120F8
		// (remove) Token: 0x06000437 RID: 1079 RVA: 0x00013F30 File Offset: 0x00012130
		public event Action<TValleOffsetModifier> modified;

		// Token: 0x06000438 RID: 1080 RVA: 0x00013F65 File Offset: 0x00012165
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Updater = this.GetComponentEnRoot(false);
			if (this.m_Updater == null)
			{
				throw new ArgumentNullException("m_Updater", "m_Updater null reference.");
			}
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00013F92 File Offset: 0x00012192
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.Unsubscribe();
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x00013FA4 File Offset: 0x000121A4
		protected void Subscribe(int eventOrder)
		{
			if (this.m_Updater == null)
			{
				return;
			}
			this.m_eventOrder = eventOrder;
			switch (eventOrder)
			{
			case 1:
				this.m_Updater.onSingleIKUpdatingPass1 += this.M_updater_passing;
				this.m_Updater.onSingleIKUpdatedPass3 += this.M_Updater_onSingleIKUpdatedPass;
				return;
			case 2:
				this.m_Updater.onSingleIKUpdatingPass2 += this.M_updater_passing;
				this.m_Updater.onSingleIKUpdatedPass2 += this.M_Updater_onSingleIKUpdatedPass;
				return;
			case 3:
				this.m_Updater.onSingleIKUpdatingPass3 += this.M_updater_passing;
				this.m_Updater.onSingleIKUpdatedPass1 += this.M_Updater_onSingleIKUpdatedPass;
				return;
			default:
				throw new ArgumentOutOfRangeException(eventOrder.ToString());
			}
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00014074 File Offset: 0x00012274
		protected void Unsubscribe()
		{
			if (this.m_Updater == null)
			{
				return;
			}
			switch (this.m_eventOrder)
			{
			case 1:
				this.m_Updater.onSingleIKUpdatingPass1 -= this.M_updater_passing;
				this.m_Updater.onSingleIKUpdatedPass3 -= this.M_Updater_onSingleIKUpdatedPass;
				return;
			case 2:
				this.m_Updater.onSingleIKUpdatingPass2 -= this.M_updater_passing;
				this.m_Updater.onSingleIKUpdatedPass2 -= this.M_Updater_onSingleIKUpdatedPass;
				return;
			case 3:
				this.m_Updater.onSingleIKUpdatingPass3 -= this.M_updater_passing;
				this.m_Updater.onSingleIKUpdatedPass1 -= this.M_Updater_onSingleIKUpdatedPass;
				return;
			default:
				this.m_Updater.onSingleIKUpdatingPass1 -= this.M_updater_passing;
				this.m_Updater.onSingleIKUpdatedPass3 -= this.M_Updater_onSingleIKUpdatedPass;
				this.m_Updater.onSingleIKUpdatingPass2 -= this.M_updater_passing;
				this.m_Updater.onSingleIKUpdatedPass2 -= this.M_Updater_onSingleIKUpdatedPass;
				this.m_Updater.onSingleIKUpdatingPass3 -= this.M_updater_passing;
				this.m_Updater.onSingleIKUpdatedPass1 -= this.M_Updater_onSingleIKUpdatedPass;
				return;
			}
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x000141C4 File Offset: 0x000123C4
		private void M_updater_passing(IIKUpdater updater, Component IK, ref IKEventData IKEventData, ref IKPassEventData PassEventData)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			if (this.iKLayer == IKLayerFlag.None)
			{
				return;
			}
			if (this.iKOrder == IKOrderFlag.None)
			{
				return;
			}
			if (this.iKPassOrder == IKPassOrderFlag.None)
			{
				return;
			}
			if (this.iKLayer.EsParaCurrentIkLayer(this.iKOrder, ref IKEventData) && this.iKPassOrder.EsParaCurrentPassOrder(ref PassEventData))
			{
				this.ModifyOffset(IK as FullBodyBipedIK);
			}
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00014224 File Offset: 0x00012424
		private void M_Updater_onSingleIKUpdatedPass(IIKUpdater updater, Component IK, ref IKEventData IKEventData, ref IKPassEventData PassEventData)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			if (this.iKLayer == IKLayerFlag.None)
			{
				return;
			}
			if (this.iKOrder == IKOrderFlag.None)
			{
				return;
			}
			if (this.iKPassOrder == IKPassOrderFlag.None)
			{
				return;
			}
			if (this.iKLayer.EsParaCurrentIkLayer(this.iKOrder, ref IKEventData) && this.iKPassOrder.EsParaCurrentPassOrder(ref PassEventData))
			{
				this.IKUpdated(IK as FullBodyBipedIK);
			}
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00014284 File Offset: 0x00012484
		protected virtual void IKUpdated(FullBodyBipedIK ik)
		{
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00014288 File Offset: 0x00012488
		private void ModifyOffset(FullBodyBipedIK ik)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			if (base.initPendiente)
			{
				return;
			}
			if (this.weight <= 0f)
			{
				return;
			}
			if (ik == null)
			{
				return;
			}
			this.weight = Mathf.Clamp(this.weight, 0f, 1f);
			Action<TValleOffsetModifier> action = this.modifying;
			if (action != null)
			{
				action(this);
			}
			this.OnModifyOffset(ik);
			Action<TValleOffsetModifier> action2 = this.modified;
			if (action2 == null)
			{
				return;
			}
			action2(this);
		}

		// Token: 0x040002CB RID: 715
		[Tooltip("The master weight")]
		public float weight = 1f;

		// Token: 0x040002CC RID: 716
		[Obsolete("", true)]
		[NonSerialized]
		public TValleOffsetModifier.Tipo updateOnIK;

		// Token: 0x040002CD RID: 717
		[Obsolete("", true)]
		[NonSerialized]
		public TValleOffsetModifier.Tipo updateOnPass;

		// Token: 0x040002CE RID: 718
		public IKLayerFlag iKLayer;

		// Token: 0x040002CF RID: 719
		public IKOrderFlag iKOrder;

		// Token: 0x040002D0 RID: 720
		public IKPassOrderFlag iKPassOrder;

		// Token: 0x040002D1 RID: 721
		protected IIKUpdater m_Updater;

		// Token: 0x040002D4 RID: 724
		private int m_eventOrder;

		// Token: 0x02000163 RID: 355
		[Obsolete("", true)]
		[Flags]
		public enum Tipo
		{
			// Token: 0x040007FE RID: 2046
			None = 0,
			// Token: 0x040007FF RID: 2047
			primero = 1,
			// Token: 0x04000800 RID: 2048
			segundo = 2,
			// Token: 0x04000801 RID: 2049
			tercero = 4,
			// Token: 0x04000802 RID: 2050
			cuarto = 8,
			// Token: 0x04000803 RID: 2051
			quinto = 16,
			// Token: 0x04000804 RID: 2052
			ultimo = 32
		}
	}
}
