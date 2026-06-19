using System;
using Assets._ReusableScripts.Miscellaneous;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.TransFollowers
{
	// Token: 0x02000049 RID: 73
	public abstract class IKPassMatrixFollower : MatrixFollowerBase
	{
		// Token: 0x06000330 RID: 816 RVA: 0x00010527 File Offset: 0x0000E727
		protected override void AwakeUnityEvent()
		{
			this.m_updater = this.GetComponentEnRoot(false);
			if (this.m_updater == null)
			{
				throw new ArgumentNullException("m_updater", "m_updater null reference.");
			}
			base.AwakeUnityEvent();
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00010554 File Offset: 0x0000E754
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.Subscribe();
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00010562 File Offset: 0x0000E762
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.Unsubscribe();
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00010571 File Offset: 0x0000E771
		private void Subscribe()
		{
			if (this.m_updater == null)
			{
				return;
			}
			this.m_updater.onSingleIKUpdatingPass1 += this.M_updater_passing;
			this.m_updater.onPhysicsIKUpdated += this.M_updater_physicsIKUpdated;
		}

		// Token: 0x06000334 RID: 820 RVA: 0x000105AC File Offset: 0x0000E7AC
		private void M_updater_physicsIKUpdated(IIKUpdater obj)
		{
			if (!base.isActiveAndEnabled || !this.m_internalUsePhysicsIKUpdated)
			{
				return;
			}
			if (this.postPhysicsIKWeight < 0f)
			{
				return;
			}
			if (this.postPhysicsIKWeight == 1f)
			{
				base.Follow();
				return;
			}
			base.FollowLimited(this.postPhysicsIKWeight);
		}

		// Token: 0x06000335 RID: 821 RVA: 0x000105F8 File Offset: 0x0000E7F8
		private void Unsubscribe()
		{
			if (this.m_updater == null)
			{
				return;
			}
			this.m_updater.onSingleIKUpdatingPass1 -= this.M_updater_passing;
			this.m_updater.onPhysicsIKUpdated -= this.M_updater_physicsIKUpdated;
		}

		// Token: 0x06000336 RID: 822 RVA: 0x00010631 File Offset: 0x0000E831
		private static IKPassMatrixFollower.Pass IndexToMasK(int index)
		{
			switch (index)
			{
			case 0:
				return IKPassMatrixFollower.Pass.primero;
			case 1:
				return IKPassMatrixFollower.Pass.segundo;
			case 2:
				return IKPassMatrixFollower.Pass.tercero;
			case 3:
				return IKPassMatrixFollower.Pass.cuarto;
			default:
				throw new ArgumentOutOfRangeException(index.ToString());
			}
		}

		// Token: 0x06000337 RID: 823 RVA: 0x00010660 File Offset: 0x0000E860
		private void M_updater_passing(IIKUpdater updater, Component IK, ref IKEventData IKEventData, ref IKPassEventData PassEventData)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			if (this.ikId != IKEventData.id)
			{
				return;
			}
			if (PassEventData.esUltimo && this.pass == IKPassMatrixFollower.Pass.ultimo)
			{
				base.Follow();
				return;
			}
			int num = (int)this.pass;
			int num2 = (int)IKPassMatrixFollower.IndexToMasK(PassEventData.index);
			if (num.HasFlag(num2))
			{
				base.Follow();
				return;
			}
		}

		// Token: 0x0400023F RID: 575
		[Header("IKPass Config")]
		public int ikId = -1;

		// Token: 0x04000240 RID: 576
		public IKPassMatrixFollower.Pass pass = IKPassMatrixFollower.Pass.ultimo;

		// Token: 0x04000241 RID: 577
		protected IIKUpdater m_updater;

		// Token: 0x04000242 RID: 578
		[Range(0f, 1f)]
		public float postPhysicsIKWeight;

		// Token: 0x04000243 RID: 579
		[NonSerialized]
		protected bool m_internalUsePhysicsIKUpdated = true;

		// Token: 0x0200014D RID: 333
		[Flags]
		public enum Pass
		{
			// Token: 0x040007BB RID: 1979
			None = 0,
			// Token: 0x040007BC RID: 1980
			primero = 1,
			// Token: 0x040007BD RID: 1981
			segundo = 2,
			// Token: 0x040007BE RID: 1982
			tercero = 4,
			// Token: 0x040007BF RID: 1983
			cuarto = 8,
			// Token: 0x040007C0 RID: 1984
			ultimo = 16
		}
	}
}
