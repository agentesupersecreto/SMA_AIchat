using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Males;
using Assets.TValle.BeachGirl.Runtime.Constraints.Penes;
using Assets.TValle.BeachGirl.Runtime.Semens;
using Assets._ReusableScripts.CuchiCuchi.Particulas;
using Assets._ReusableScripts.CuchiCuchi.Skins.Semen;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters
{
	// Token: 0x02000234 RID: 564
	[RequireComponent(typeof(Character))]
	public sealed class PuppetPenisAdder : CharacterPenisAdder
	{
		// Token: 0x06000F01 RID: 3841 RVA: 0x00042DD4 File Offset: 0x00040FD4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (!base.enabled)
			{
				return;
			}
			this.m_PuppetMaster = this.m_Character.GetComponentInChildren<PuppetMaster>();
			if (this.m_PuppetMaster == null)
			{
				throw new ArgumentNullException("m_PuppetMaster", "m_PuppetMaster null reference.");
			}
			this.m_Semen = this.GetComponentEnRoot(false);
			if (this.m_Semen == null)
			{
				this.m_Semen = base.transform.CreateChild("SemenParaPene").GetComponentNotNull<SemenParaPene>();
			}
		}

		// Token: 0x06000F02 RID: 3842 RVA: 0x00042E58 File Offset: 0x00041058
		protected override void BeforeStartPenis()
		{
			base.BeforeStartPenis();
			PeneMaleConstraintsAdder componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot != null && !componentEnRoot.areConstraintsAdded)
			{
				Debug.LogError("El constraint de pene root, debe estar ya añadido antes de añadir el pene");
			}
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(this.m_Character.bodyAnimator, HumanBodyBones.Hips).colliders;
			Muscle muscle = this.m_PuppetMaster.GetMuscle(this.m_Character.bodyAnimator, HumanBodyBones.LeftUpperLeg);
			Muscle muscle2 = this.m_PuppetMaster.GetMuscle(this.m_Character.bodyAnimator, HumanBodyBones.RightUpperLeg);
			this.m_PenisLinearChain.collidersParaIgnorar.AddRange(colliders);
			this.m_PenisLinearChain.collidersParaIgnorar.AddRange(muscle.colliders);
			this.m_PenisLinearChain.collidersParaIgnorar.AddRange(muscle2.colliders);
		}

		// Token: 0x06000F03 RID: 3843 RVA: 0x00042F18 File Offset: 0x00041118
		protected override void AfterStaredPenis()
		{
			base.AfterStaredPenis();
			this.m_SemenEmisor = Object.Instantiate<EmisorDeSemenChain>(Singleton<ColleccionDeParticulas>.instance.emisorParaPenePrefab, this.m_Penis.tipPhysics.position, this.m_Penis.tipPhysics.rotation * Quaternion.AngleAxis(180f, Vector3.up), this.m_Penis.tipPhysics);
			if (this.m_SemenEmisor == null)
			{
				throw new ArgumentNullException("m_SemenEmisor", "m_SemenEmisor null reference.");
			}
			this.m_SemenEmisor.GetComponentNotNull<EmisorDeSemenChainSetContraSkinComponents>();
			this.m_Semen.Init(this.m_Penis, this.m_SemenEmisor);
		}

		// Token: 0x06000F04 RID: 3844 RVA: 0x00042FC0 File Offset: 0x000411C0
		public override Func<float> PelvisMassGetter()
		{
			Muscle pelvis = this.m_PuppetMaster.GetMuscle(this.m_Character.bodyAnimator, HumanBodyBones.Hips);
			return () => pelvis.rigidbody.mass;
		}

		// Token: 0x06000F05 RID: 3845 RVA: 0x00042FEF File Offset: 0x000411EF
		protected override bool Waiting()
		{
			this.m_PuppetMaster.ForceInitiate();
			return !this.m_PuppetMaster.initiated;
		}

		// Token: 0x04000A36 RID: 2614
		private PuppetMaster m_PuppetMaster;

		// Token: 0x04000A37 RID: 2615
		private SemenParaPene m_Semen;

		// Token: 0x04000A38 RID: 2616
		private EmisorDeSemenChain m_SemenEmisor;
	}
}
