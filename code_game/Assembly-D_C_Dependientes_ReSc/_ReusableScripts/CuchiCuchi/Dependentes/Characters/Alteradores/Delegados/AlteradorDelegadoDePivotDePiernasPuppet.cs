using System;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Delegados;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Alteradores.Delegados
{
	// Token: 0x020002A4 RID: 676
	[RequireComponent(typeof(AlteradorDelegadoDePivotDePiernas))]
	public sealed class AlteradorDelegadoDePivotDePiernasPuppet : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x0600117E RID: 4478 RVA: 0x00052BB4 File Offset: 0x00050DB4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_delegado = base.GetComponent<AlteradorDelegadoDePivotDePiernas>();
			this.m_IIKUpdater = this.GetComponentEnRoot(false);
			this.m_PuppetMaster = this.GetComponentEnRoot(false);
			PuppetMaster puppetMaster = this.m_PuppetMaster;
			puppetMaster.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Combine(puppetMaster.OnPostInitiate, new PuppetMaster.UpdateDelegate(this.OnPostInitiate));
		}

		// Token: 0x0600117F RID: 4479 RVA: 0x00052C14 File Offset: 0x00050E14
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_delegado.updatedL += this.M_delegado_updatedL;
			this.m_delegado.updatedR += this.M_delegado_updatedR;
			this.m_IIKUpdater.onFixedTransforms += this.M_IIKUpdater_iKsFixedTransforms;
		}

		// Token: 0x06001180 RID: 4480 RVA: 0x00052C6C File Offset: 0x00050E6C
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_IIKUpdater != null)
			{
				this.m_IIKUpdater.onFixedTransforms -= this.M_IIKUpdater_iKsFixedTransforms;
			}
			if (this.m_delegado != null)
			{
				this.m_delegado.updatedL -= this.M_delegado_updatedL;
				this.m_delegado.updatedR -= this.M_delegado_updatedR;
			}
			if (this.m_PuppetMaster)
			{
				this.M_IIKUpdater_iKsFixedTransforms(this.m_IIKUpdater);
			}
		}

		// Token: 0x06001181 RID: 4481 RVA: 0x00052CF4 File Offset: 0x00050EF4
		private void OnPostInitiate()
		{
			PuppetMaster puppetMaster = this.m_PuppetMaster;
			puppetMaster.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Remove(puppetMaster.OnPostInitiate, new PuppetMaster.UpdateDelegate(this.OnPostInitiate));
			this.l = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftUpperLeg);
			this.r = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightUpperLeg);
			if (this.r == null)
			{
				throw new ArgumentNullException("r muscle", "r muscle null reference.");
			}
			if (this.l == null)
			{
				throw new ArgumentNullException("l muscle", "l muscle null reference.");
			}
			this.m_InicialCenterDeColliderL = ((CapsuleCollider)this.l.colliders[0]).center;
			this.m_InicialCenterDeColliderR = ((CapsuleCollider)this.r.colliders[0]).center;
		}

		// Token: 0x06001182 RID: 4482 RVA: 0x00052DB6 File Offset: 0x00050FB6
		private void M_IIKUpdater_iKsFixedTransforms(IIKUpdater obj)
		{
			((CapsuleCollider)this.l.colliders[0]).center = this.m_InicialCenterDeColliderL;
			((CapsuleCollider)this.r.colliders[0]).center = this.m_InicialCenterDeColliderR;
		}

		// Token: 0x06001183 RID: 4483 RVA: 0x00052DF2 File Offset: 0x00050FF2
		private void M_delegado_updatedR(AlteradorDelegadoDePivotDePiernas obj, Vector3 offset)
		{
			((CapsuleCollider)this.r.colliders[0]).center = this.m_InicialCenterDeColliderR + offset * this.mod;
		}

		// Token: 0x06001184 RID: 4484 RVA: 0x00052E22 File Offset: 0x00051022
		private void M_delegado_updatedL(AlteradorDelegadoDePivotDePiernas obj, Vector3 offset)
		{
			((CapsuleCollider)this.l.colliders[0]).center = this.m_InicialCenterDeColliderL + offset * this.mod;
		}

		// Token: 0x04000CD9 RID: 3289
		public float mod = 0.1f;

		// Token: 0x04000CDA RID: 3290
		private AlteradorDelegadoDePivotDePiernas m_delegado;

		// Token: 0x04000CDB RID: 3291
		private IIKUpdater m_IIKUpdater;

		// Token: 0x04000CDC RID: 3292
		private PuppetMaster m_PuppetMaster;

		// Token: 0x04000CDD RID: 3293
		private Muscle l;

		// Token: 0x04000CDE RID: 3294
		private Muscle r;

		// Token: 0x04000CDF RID: 3295
		private Vector3 m_InicialCenterDeColliderL;

		// Token: 0x04000CE0 RID: 3296
		private Vector3 m_InicialCenterDeColliderR;
	}
}
