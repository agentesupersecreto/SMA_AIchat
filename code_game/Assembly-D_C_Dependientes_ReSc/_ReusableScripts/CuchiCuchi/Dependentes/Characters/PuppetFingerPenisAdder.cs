using System;
using Assets.TValle.BeachGirl.Runtime.Males;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters
{
	// Token: 0x02000232 RID: 562
	[RequireComponent(typeof(Character))]
	public sealed class PuppetFingerPenisAdder : CharacterFingerPenisAdder
	{
		// Token: 0x06000EF9 RID: 3833 RVA: 0x00042B65 File Offset: 0x00040D65
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
		}

		// Token: 0x06000EFA RID: 3834 RVA: 0x00042BA8 File Offset: 0x00040DA8
		protected override void BeforeStartPenis()
		{
			base.BeforeStartPenis();
			this.hand = this.m_PuppetMaster.GetMuscle(this.m_Character.bodyAnimator, HumanBodyBones.RightHand);
			this.forearm = this.m_PuppetMaster.GetMuscle(this.m_Character.bodyAnimator, HumanBodyBones.RightLowerArm);
			this.arm = this.m_PuppetMaster.GetMuscle(this.m_Character.bodyAnimator, HumanBodyBones.RightUpperArm);
			Collider[] colliders = this.hand.colliders;
			this.m_PenisLinearChain.collidersParaIgnorar.AddRange(colliders);
			this.m_PenisLinearChain.collidersParaIgnorar.AddRange(this.forearm.colliders);
			this.m_PenisLinearChain.collidersParaIgnorar.AddRange(this.arm.colliders);
			this.m_PenisLinearChain.rootPointEsKinematico = false;
			this.m_PenisLinearChain.correctChainScaleOnScaleChange = false;
			this.m_Penis.GetComponentNotNull<FingerLookAtTargetProvider>();
		}

		// Token: 0x06000EFB RID: 3835 RVA: 0x00042C8C File Offset: 0x00040E8C
		protected override void AfterStaredPenis()
		{
			base.AfterStaredPenis();
			FingerPhyscisController componentNotNull = this.m_holderForPhyscis.GetComponentNotNull<FingerPhyscisController>();
			componentNotNull.side = Side.R;
			componentNotNull.handMuscle = this.hand;
			componentNotNull.forearmMuscle = this.forearm;
			componentNotNull.armMuscle = this.arm;
			componentNotNull.bufferDeFuerzasConfig = this.bufferDeFuerzasConfig;
			componentNotNull.baseTransform = this.m_baseDelDedoParaPhyscis;
			componentNotNull.rootTransform = this.m_RootDelDedoParaPhyscis;
			componentNotNull.rootToHandFollower = this.m_RootToHandFollower;
			componentNotNull.armatureRotationOffset = this.m_rotationOffset;
			componentNotNull.animator = this.m_holderForPhyscis.parent.GetComponent<Animator>();
			componentNotNull.SetManualStart();
			componentNotNull.ManualStart();
			componentNotNull.enabled = false;
			componentNotNull.enabled = true;
			componentNotNull.enabled = false;
		}

		// Token: 0x06000EFC RID: 3836 RVA: 0x00042D47 File Offset: 0x00040F47
		public override Func<float> PelvisMassGetter()
		{
			Muscle hand = this.m_PuppetMaster.GetMuscle(this.m_Character.bodyAnimator, HumanBodyBones.RightHand);
			return () => hand.rigidbody.mass;
		}

		// Token: 0x06000EFD RID: 3837 RVA: 0x00042D77 File Offset: 0x00040F77
		protected override bool Waiting()
		{
			this.m_PuppetMaster.ForceInitiate();
			return !this.m_PuppetMaster.initiated;
		}

		// Token: 0x04000A30 RID: 2608
		public BufferDeFuerzasConfig bufferDeFuerzasConfig = new BufferDeFuerzasConfig
		{
			inverse = true,
			modificador = 0.1f,
			time = 0.333f
		};

		// Token: 0x04000A31 RID: 2609
		private PuppetMaster m_PuppetMaster;

		// Token: 0x04000A32 RID: 2610
		private Muscle hand;

		// Token: 0x04000A33 RID: 2611
		private Muscle forearm;

		// Token: 0x04000A34 RID: 2612
		private Muscle arm;
	}
}
