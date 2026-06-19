using System;
using RootMotion.Dynamics;
using RootMotion.Dynamics.TavoRootMotion;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Behaviours
{
	// Token: 0x0200010C RID: 268
	[RequireComponent(typeof(BehaviourBase))]
	public class BehaviourBaseUpdater : CustomMonobehaviour, IPuppetBehaviourUpdater
	{
		// Token: 0x140000A3 RID: 163
		// (add) Token: 0x06000A7A RID: 2682 RVA: 0x0002ED90 File Offset: 0x0002CF90
		// (remove) Token: 0x06000A7B RID: 2683 RVA: 0x0002EDC8 File Offset: 0x0002CFC8
		public event Action<IPuppetBehaviourUpdater, BehaviourBase> fixedUpdating;

		// Token: 0x140000A4 RID: 164
		// (add) Token: 0x06000A7C RID: 2684 RVA: 0x0002EE00 File Offset: 0x0002D000
		// (remove) Token: 0x06000A7D RID: 2685 RVA: 0x0002EE38 File Offset: 0x0002D038
		public event Action<IPuppetBehaviourUpdater, BehaviourBase> updating;

		// Token: 0x140000A5 RID: 165
		// (add) Token: 0x06000A7E RID: 2686 RVA: 0x0002EE70 File Offset: 0x0002D070
		// (remove) Token: 0x06000A7F RID: 2687 RVA: 0x0002EEA8 File Offset: 0x0002D0A8
		public event Action<IPuppetBehaviourUpdater, BehaviourBase> lateUpdating;

		// Token: 0x06000A80 RID: 2688 RVA: 0x0002EEE0 File Offset: 0x0002D0E0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Behaviour = base.GetComponent<BehaviourBase>();
			if (this.m_Behaviour.puppetMaster != null)
			{
				this.OnPostInitiate();
				return;
			}
			BehaviourBase behaviour = this.m_Behaviour;
			behaviour.OnPostInitiate = (BehaviourBase.BehaviourDelegate)Delegate.Combine(behaviour.OnPostInitiate, new BehaviourBase.BehaviourDelegate(this.OnPostInitiate));
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x0002EF40 File Offset: 0x0002D140
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			IPuppetUpdater component = this.m_Behaviour.puppetMaster.GetComponent<IPuppetUpdater>();
			if (component != null)
			{
				BehaviourBase behaviour = this.m_Behaviour;
				behaviour.OnPostInitiate = (BehaviourBase.BehaviourDelegate)Delegate.Remove(behaviour.OnPostInitiate, new BehaviourBase.BehaviourDelegate(this.OnPostInitiate));
				component.beforeFixedUpdate -= this.FixedUpdatePuppet;
				component.beforeUpdate -= this.UpdatePuppet;
				component.beforeLateUpdate -= this.LateUpdatePuppet;
			}
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x0002EFC8 File Offset: 0x0002D1C8
		private void OnPostInitiate()
		{
			BehaviourBase behaviour = this.m_Behaviour;
			behaviour.OnPostInitiate = (BehaviourBase.BehaviourDelegate)Delegate.Remove(behaviour.OnPostInitiate, new BehaviourBase.BehaviourDelegate(this.OnPostInitiate));
			IPuppetUpdater component = this.m_Behaviour.puppetMaster.GetComponent<IPuppetUpdater>();
			component.beforeFixedUpdate -= this.FixedUpdatePuppet;
			component.beforeUpdate -= this.UpdatePuppet;
			component.beforeLateUpdate -= this.LateUpdatePuppet;
			component.beforeFixedUpdate += this.FixedUpdatePuppet;
			component.beforeUpdate += this.UpdatePuppet;
			component.beforeLateUpdate += this.LateUpdatePuppet;
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x0002F077 File Offset: 0x0002D277
		private void FixedUpdatePuppet()
		{
			if (this.m_Behaviour.enabled)
			{
				Action<IPuppetBehaviourUpdater, BehaviourBase> action = this.fixedUpdating;
				if (action != null)
				{
					action(this, this.m_Behaviour);
				}
				this.m_Behaviour.FixedUpdateBehaviour();
			}
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x0002F0A9 File Offset: 0x0002D2A9
		private void UpdatePuppet()
		{
			if (this.m_Behaviour.enabled)
			{
				Action<IPuppetBehaviourUpdater, BehaviourBase> action = this.updating;
				if (action != null)
				{
					action(this, this.m_Behaviour);
				}
				this.m_Behaviour.UpdateBehaviour();
			}
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x0002F0DB File Offset: 0x0002D2DB
		private void LateUpdatePuppet()
		{
			if (this.m_Behaviour.enabled)
			{
				Action<IPuppetBehaviourUpdater, BehaviourBase> action = this.lateUpdating;
				if (action != null)
				{
					action(this, this.m_Behaviour);
				}
				this.m_Behaviour.LateUpdateBehaviour();
			}
		}

		// Token: 0x04000662 RID: 1634
		private BehaviourBase m_Behaviour;
	}
}
