using System;
using Assets._ReusableScripts.Miscellaneous;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x02000048 RID: 72
	public abstract class IKMatrixFollower : MatrixFollowerGlobalUpdaterEvents
	{
		// Token: 0x06000328 RID: 808 RVA: 0x000103A0 File Offset: 0x0000E5A0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_updater = this.GetComponentEnRoot(false);
			if (this.m_updater == null)
			{
				throw new ArgumentNullException("m_updater", "m_updater null reference.");
			}
		}

		// Token: 0x06000329 RID: 809 RVA: 0x000103CD File Offset: 0x0000E5CD
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_CustomUpdate = this.iKUpdateEvent > IKUpdateType.None;
			this.Subscribe();
		}

		// Token: 0x0600032A RID: 810 RVA: 0x000103EA File Offset: 0x0000E5EA
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.Unsubscribe();
		}

		// Token: 0x0600032B RID: 811 RVA: 0x000103F9 File Offset: 0x0000E5F9
		public override void ActualizarEventos()
		{
			this.m_CustomUpdate = this.iKUpdateEvent > IKUpdateType.None;
			base.ActualizarEventos();
			this.Unsubscribe();
			this.Subscribe();
		}

		// Token: 0x0600032C RID: 812 RVA: 0x0001041C File Offset: 0x0000E61C
		private void OnIKUpdateEvent(IIKUpdater updater)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			base.Follow();
		}

		// Token: 0x0600032D RID: 813 RVA: 0x00010430 File Offset: 0x0000E630
		private void Subscribe()
		{
			if (this.m_updater == null)
			{
				return;
			}
			switch (this.iKUpdateEvent)
			{
			case IKUpdateType.None:
				return;
			case IKUpdateType.beforeIK:
				this.m_updater.onAllIKsUpdating += this.OnIKUpdateEvent;
				return;
			case IKUpdateType.afterIK:
				this.m_updater.onAllIKsUpdated += this.OnIKUpdateEvent;
				return;
			case IKUpdateType.afterPhysicsIK:
				this.m_updater.onPhysicsIKUpdated += this.OnIKUpdateEvent;
				return;
			default:
				throw new ArgumentOutOfRangeException(this.iKUpdateEvent.ToString());
			}
		}

		// Token: 0x0600032E RID: 814 RVA: 0x000104C4 File Offset: 0x0000E6C4
		private void Unsubscribe()
		{
			if (this.m_updater == null)
			{
				return;
			}
			this.m_updater.onAllIKsUpdating -= this.OnIKUpdateEvent;
			this.m_updater.onAllIKsUpdated -= this.OnIKUpdateEvent;
			this.m_updater.onPhysicsIKUpdated -= this.OnIKUpdateEvent;
		}

		// Token: 0x0400023D RID: 573
		public IKUpdateType iKUpdateEvent;

		// Token: 0x0400023E RID: 574
		protected IIKUpdater m_updater;
	}
}
