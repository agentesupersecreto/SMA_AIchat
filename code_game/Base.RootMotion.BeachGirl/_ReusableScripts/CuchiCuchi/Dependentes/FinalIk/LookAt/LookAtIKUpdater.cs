using System;
using System.Linq;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.LookAt
{
	// Token: 0x0200008F RID: 143
	[RequireComponent(typeof(LookAtIK))]
	public sealed class LookAtIKUpdater : CustomMonobehaviour
	{
		// Token: 0x14000055 RID: 85
		// (add) Token: 0x06000596 RID: 1430 RVA: 0x0001C248 File Offset: 0x0001A448
		// (remove) Token: 0x06000597 RID: 1431 RVA: 0x0001C280 File Offset: 0x0001A480
		public event Action<LookAtIKUpdater> updating;

		// Token: 0x14000056 RID: 86
		// (add) Token: 0x06000598 RID: 1432 RVA: 0x0001C2B8 File Offset: 0x0001A4B8
		// (remove) Token: 0x06000599 RID: 1433 RVA: 0x0001C2F0 File Offset: 0x0001A4F0
		public event Action<LookAtIKUpdater> updated;

		// Token: 0x0600059A RID: 1434 RVA: 0x0001C325 File Offset: 0x0001A525
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_updater = this.GetComponentEnRoot(false);
			if (this.m_updater == null)
			{
				throw new ArgumentNullException("m_updater", "m_updater null reference.");
			}
			this.m_LookAtIK = base.GetComponent<LookAtIK>();
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x0001C360 File Offset: 0x0001A560
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.m_overridingRoot)
			{
				this.m_LookAtIK.solver.SetChain(this.m_LookAtIK.solver.spine.Select((IKSolverLookAt.LookAtBone s) => s.transform).ToArray<Transform>(), this.m_LookAtIK.solver.head.transform, null, this.m_overridingRoot);
			}
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x0001C3E8 File Offset: 0x0001A5E8
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_updater.onSingleIKUpdatingPass1 += this.M_updater_passing;
			this.m_updater.onFixingTransforms += this.M_updater_iKsFixedTransforms;
			if (this.m_LookAtIK.enabled)
			{
				this.m_LookAtIK.enabled = false;
			}
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x0001C442 File Offset: 0x0001A642
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_updater.onSingleIKUpdatingPass1 -= this.M_updater_passing;
			this.m_updater.onFixingTransforms -= this.M_updater_iKsFixedTransforms;
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x0001C479 File Offset: 0x0001A679
		private void M_updater_iKsFixedTransforms(IIKUpdater obj)
		{
			if (this.m_LookAtIK.fixTransforms)
			{
				this.m_LookAtIK.solver.FixTransforms();
			}
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x0001C498 File Offset: 0x0001A698
		private void M_updater_passing(IIKUpdater updater, Component IK, ref IKEventData IKEventData, ref IKPassEventData PassEventData)
		{
			if (this.m_LookAtIK.enabled)
			{
				this.m_LookAtIK.enabled = false;
			}
			if (this.iKLayer.EsParaCurrentPass(this.iKOrder, ref IKEventData) && this.iKPassOrder.EsParaCurrentPassOrder(ref PassEventData))
			{
				Action<LookAtIKUpdater> action = this.updating;
				if (action != null)
				{
					action(this);
				}
				this.m_LookAtIK.solver.Update();
				Action<LookAtIKUpdater> action2 = this.updated;
				if (action2 == null)
				{
					return;
				}
				action2(this);
			}
		}

		// Token: 0x040003D7 RID: 983
		private IIKUpdater m_updater;

		// Token: 0x040003D8 RID: 984
		[Obsolete("", true)]
		[NonSerialized]
		public int indexIK = -1;

		// Token: 0x040003D9 RID: 985
		[Obsolete("", true)]
		[NonSerialized]
		public int indexPass = -1;

		// Token: 0x040003DA RID: 986
		public IKLayer iKLayer;

		// Token: 0x040003DB RID: 987
		public IKOrder iKOrder;

		// Token: 0x040003DC RID: 988
		public IKPassOrder iKPassOrder;

		// Token: 0x040003DD RID: 989
		private LookAtIK m_LookAtIK;

		// Token: 0x040003DE RID: 990
		[SerializeField]
		private Transform m_overridingRoot;
	}
}
