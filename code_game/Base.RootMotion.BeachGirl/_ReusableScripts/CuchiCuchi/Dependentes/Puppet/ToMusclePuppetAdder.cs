using System;
using System.Collections.Generic;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet
{
	// Token: 0x020000FF RID: 255
	public abstract class ToMusclePuppetAdder<T> : BehaviourAdder where T : Component
	{
		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x0600097B RID: 2427 RVA: 0x0002B3AE File Offset: 0x000295AE
		public sealed override object addedResult
		{
			get
			{
				return this.m_added;
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x0600097C RID: 2428 RVA: 0x0002B3B6 File Offset: 0x000295B6
		protected override BehaviourAdder.AddType addType
		{
			get
			{
				return BehaviourAdder.AddType.custom;
			}
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x0002B3BC File Offset: 0x000295BC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			PuppetMaster componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("puppet", "puppet null reference.");
			}
			if (componentEnRoot.initiated)
			{
				base.OnAddBehaviour();
				return;
			}
			PuppetMaster puppetMaster = componentEnRoot;
			puppetMaster.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Combine(puppetMaster.OnPostInitiate, new PuppetMaster.UpdateDelegate(base.OnAddBehaviour));
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x0002B424 File Offset: 0x00029624
		protected override void AddBehaviour()
		{
			PuppetMaster componentEnRoot = this.GetComponentEnRoot(false);
			PuppetMaster puppetMaster = componentEnRoot;
			puppetMaster.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Remove(puppetMaster.OnPostInitiate, new PuppetMaster.UpdateDelegate(base.OnAddBehaviour));
			this.m_added = new List<T>();
			for (int i = 0; i < componentEnRoot.muscles.Length; i++)
			{
				Muscle muscle = componentEnRoot.muscles[i];
				if (this.AddToMuscleChecker(muscle))
				{
					T componentNotNull = muscle.rigidbody.GetComponentNotNull<T>();
					this.m_added.Add(componentNotNull);
					this.OnAddedToMuscle(muscle, componentNotNull);
				}
			}
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x0002B4AB File Offset: 0x000296AB
		protected virtual bool AddToMuscleChecker(Muscle muscle)
		{
			return muscle != null;
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x0002B4B1 File Offset: 0x000296B1
		protected virtual void OnAddedToMuscle(Muscle muscle, T addded)
		{
		}

		// Token: 0x040005E1 RID: 1505
		private List<T> m_added;
	}
}
