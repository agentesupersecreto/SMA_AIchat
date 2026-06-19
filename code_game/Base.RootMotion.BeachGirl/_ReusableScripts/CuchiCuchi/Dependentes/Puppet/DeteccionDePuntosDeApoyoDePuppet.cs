using System;
using System.Collections.Generic;
using Assets.Base.Behaviours.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet
{
	// Token: 0x020000FB RID: 251
	[RequireComponent(typeof(IIKUpdater))]
	public sealed class DeteccionDePuntosDeApoyoDePuppet : DeteccionDePuntosDeApoyoBase
	{
		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000967 RID: 2407 RVA: 0x0002B039 File Offset: 0x00029239
		public PuppetMaster puppetMaster
		{
			get
			{
				return this.m_puppetMaster;
			}
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x0002B041 File Offset: 0x00029241
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_IIKUpdater = base.GetComponent<IIKUpdater>();
			this.m_puppetMaster = base.GetComponentInChildren<PuppetMaster>();
			if (this.m_puppetMaster == null)
			{
				throw new ArgumentNullException("m_puppetMaster", "m_puppetMaster null reference.");
			}
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x0002B07F File Offset: 0x0002927F
		protected override DeteccionDePuntosDeApoyoBase.IRagdoll InstanciarWraper()
		{
			return new DeteccionDePuntosDeApoyoDePuppet.PuppetMasterRagdoll(this.m_puppetMaster);
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x0002B08C File Offset: 0x0002928C
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_IIKUpdater.onAllIKsUpdated += this.M_IKBeforePhysicsV2_iKsUpdated;
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x0002B0AB File Offset: 0x000292AB
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_IIKUpdater.onAllIKsUpdated -= this.M_IKBeforePhysicsV2_iKsUpdated;
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x0002B0CC File Offset: 0x000292CC
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.m_puppetMaster.initiated)
			{
				this.puppetMaster_OnPostInitiate();
				return;
			}
			PuppetMaster puppetMaster = this.m_puppetMaster;
			puppetMaster.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Combine(puppetMaster.OnPostInitiate, new PuppetMaster.UpdateDelegate(this.puppetMaster_OnPostInitiate));
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x0002B11A File Offset: 0x0002931A
		private void puppetMaster_OnPostInitiate()
		{
			PuppetMaster puppetMaster = this.m_puppetMaster;
			puppetMaster.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Remove(puppetMaster.OnPostInitiate, new PuppetMaster.UpdateDelegate(this.puppetMaster_OnPostInitiate));
			base.InstanciarCadenas();
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x0002B149 File Offset: 0x00029349
		private void M_IKBeforePhysicsV2_iKsUpdated(IIKUpdater obj)
		{
			if (this.m_puppetMaster == null || !this.m_puppetMaster.initiated)
			{
				return;
			}
			base.UpdateCadenas(false);
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x0002B170 File Offset: 0x00029370
		protected override bool ColliderEsHitValido(Collider self, Collider other)
		{
			if (other.gameObject.layer != Singleton<ConfiguracionGeneral>.instance.layers.ragdoll || self.gameObject.layer != Singleton<ConfiguracionGeneral>.instance.layers.ragdoll)
			{
				return true;
			}
			if (!other.transform.IsChildOf(this.m_puppetMaster.transform))
			{
				return false;
			}
			if (!self.transform.IsChildOf(this.m_puppetMaster.transform))
			{
				return false;
			}
			Muscle muscle = this.m_puppetMaster.GetMuscle(self.attachedRigidbody);
			Muscle muscle2 = this.m_puppetMaster.GetMuscle(other.attachedRigidbody);
			if (muscle == null || muscle2 == null || muscle == muscle2)
			{
				return false;
			}
			if (muscle.props.group != Muscle.Group.Hand)
			{
				return false;
			}
			Muscle.Group group = muscle2.props.group;
			return group == Muscle.Group.Head || group - Muscle.Group.Leg <= 3;
		}

		// Token: 0x040005DB RID: 1499
		private IIKUpdater m_IIKUpdater;

		// Token: 0x040005DC RID: 1500
		private PuppetMaster m_puppetMaster;

		// Token: 0x020001C4 RID: 452
		public class PuppetMasterRagdoll : DeteccionDePuntosDeApoyoBase.IRagdoll
		{
			// Token: 0x06000D15 RID: 3349 RVA: 0x00039C08 File Offset: 0x00037E08
			public PuppetMasterRagdoll(PuppetMaster Puppet)
			{
				if (Puppet == null)
				{
					throw new ArgumentNullException("Puppet", "Puppet null reference.");
				}
				this.puppet = Puppet;
			}

			// Token: 0x06000D16 RID: 3350 RVA: 0x00039C30 File Offset: 0x00037E30
			public IReadOnlyList<Collider> GetCollidersDeMuscle(Transform bone)
			{
				Muscle muscle = this.puppet.GetMuscle(bone);
				if (muscle == null)
				{
					return null;
				}
				return muscle.colliders;
			}

			// Token: 0x040009D3 RID: 2515
			private readonly PuppetMaster puppet;
		}
	}
}
