using System;
using System.Collections.Generic;
using System.Linq;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.SexoIKs
{
	// Token: 0x02000029 RID: 41
	[RequireComponent(typeof(LookAtIK))]
	public class SexIKUpdater : CustomMonobehaviour
	{
		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000180 RID: 384 RVA: 0x00008F98 File Offset: 0x00007198
		public FullBodyBipedIK fullBodyBipedIK
		{
			get
			{
				return this.m_updater.SortedIKsDeLayer(0)[0] as FullBodyBipedIK;
			}
		}

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x06000181 RID: 385 RVA: 0x00008FB4 File Offset: 0x000071B4
		// (remove) Token: 0x06000182 RID: 386 RVA: 0x00008FEC File Offset: 0x000071EC
		public event Action updating;

		// Token: 0x06000183 RID: 387 RVA: 0x00009024 File Offset: 0x00007224
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_updater = this.GetComponentEnRoot(false);
			if (this.m_updater == null)
			{
				throw new ArgumentNullException("m_updater", "m_updater null reference.");
			}
			this.m_LookAtIK = base.GetComponent<LookAtIK>();
			IIKUpdater updater = this.m_updater;
			IReadOnlyList<Component> readOnlyList = ((updater != null) ? updater.SortedIKsDeLayer(0) : null);
			if (readOnlyList == null)
			{
				throw new ArgumentNullException("userIK", "userIK null reference.");
			}
			this.m_forcers = readOnlyList.Select((Component ik) => ik.GetComponent<TValleEffectorForcer>()).ToArray<TValleEffectorForcer>();
		}

		// Token: 0x06000184 RID: 388 RVA: 0x000090C0 File Offset: 0x000072C0
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_updater.onAllIKsUpdating += this.M_IKUpdater_onAllIKsUpdating;
			for (int i = 0; i < this.m_forcers.Length; i++)
			{
				if (this.m_forcers[i] != null)
				{
					this.m_forcers[i].updated += this.M_forcer_updated;
				}
			}
			this.m_updater.onFixingTransforms += this.M_updater_iKsFixedTransforms;
			if (this.m_LookAtIK.enabled)
			{
				this.m_LookAtIK.enabled = false;
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00009158 File Offset: 0x00007358
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_updater.onAllIKsUpdating -= this.M_IKUpdater_onAllIKsUpdating;
			if (this.m_updater != null)
			{
				this.m_updater.onFixingTransforms -= this.M_updater_iKsFixedTransforms;
			}
			for (int i = 0; i < this.m_forcers.Length; i++)
			{
				if (this.m_forcers[i] != null)
				{
					this.m_forcers[i].updated -= this.M_forcer_updated;
				}
			}
		}

		// Token: 0x06000186 RID: 390 RVA: 0x000091E0 File Offset: 0x000073E0
		private void GetForcers(out TValleEffectorForcer main, out TValleEffectorForcer off)
		{
			IReadOnlyList<Component> readOnlyList = this.m_updater.SortedIKsDeLayer(0);
			if (readOnlyList[0] == this.m_forcers[0].fullBodyBipedIK)
			{
				main = this.m_forcers[0];
				off = this.m_forcers[1];
				return;
			}
			if (readOnlyList[0] == this.m_forcers[1].fullBodyBipedIK)
			{
				main = this.m_forcers[1];
				off = this.m_forcers[0];
				return;
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00009260 File Offset: 0x00007460
		private void M_IKUpdater_onAllIKsUpdating(IIKUpdater obj)
		{
			TValleEffectorForcer tvalleEffectorForcer;
			TValleEffectorForcer tvalleEffectorForcer2;
			this.GetForcers(out tvalleEffectorForcer, out tvalleEffectorForcer2);
			this.m_forcerMainChanged = tvalleEffectorForcer != this.m_main;
			this.m_main = tvalleEffectorForcer;
			this.m_off = tvalleEffectorForcer2;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00009297 File Offset: 0x00007497
		private void M_updater_iKsFixedTransforms(IIKUpdater obj)
		{
			if (this.m_LookAtIK.fixTransforms)
			{
				this.m_LookAtIK.solver.FixTransforms();
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000092B8 File Offset: 0x000074B8
		private void M_forcer_updated(FullBodyBipedIK IK, IKEventData IKEventData, IKPassEventData PassEventData, TValleEffectorForcer sender)
		{
			if (!PassEventData.esUltimo)
			{
				return;
			}
			if (IK != this.m_main.fullBodyBipedIK)
			{
				return;
			}
			Action action = this.updating;
			if (action != null)
			{
				action();
			}
			this.m_LookAtIK.solver.Update();
		}

		// Token: 0x04000103 RID: 259
		private IIKUpdater m_updater;

		// Token: 0x04000104 RID: 260
		private LookAtIK m_LookAtIK;

		// Token: 0x04000106 RID: 262
		private TValleEffectorForcer[] m_forcers;

		// Token: 0x04000107 RID: 263
		[SerializeField]
		[ReadOnlyUI]
		private TValleEffectorForcer m_main;

		// Token: 0x04000108 RID: 264
		[SerializeField]
		[ReadOnlyUI]
		private TValleEffectorForcer m_off;

		// Token: 0x04000109 RID: 265
		[SerializeField]
		[ReadOnlyUI]
		private bool m_forcerMainChanged;
	}
}
