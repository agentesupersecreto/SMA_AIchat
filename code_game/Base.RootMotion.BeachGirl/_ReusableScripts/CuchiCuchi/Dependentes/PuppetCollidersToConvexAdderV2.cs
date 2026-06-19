using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes
{
	// Token: 0x02000050 RID: 80
	[RequireComponent(typeof(ICharacter))]
	public sealed class PuppetCollidersToConvexAdderV2 : BehaviourAdder
	{
		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000356 RID: 854 RVA: 0x00010C54 File Offset: 0x0000EE54
		public sealed override object addedResult
		{
			get
			{
				return this.m_added;
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000357 RID: 855 RVA: 0x00010C5C File Offset: 0x0000EE5C
		public PuppetColliderToConvexV2 hipsCollider
		{
			get
			{
				return this.m_HipsCollider;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000358 RID: 856 RVA: 0x00010C64 File Offset: 0x0000EE64
		public PuppetColliderToConvexV2 piernaL
		{
			get
			{
				return this.m_PiernaL;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000359 RID: 857 RVA: 0x00010C6C File Offset: 0x0000EE6C
		public PuppetColliderToConvexV2 piernaR
		{
			get
			{
				return this.m_PiernaR;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600035A RID: 858 RVA: 0x00010C74 File Offset: 0x0000EE74
		public PuppetColliderToConvexV2 spine
		{
			get
			{
				return this.m_Spine;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600035B RID: 859 RVA: 0x00010C7C File Offset: 0x0000EE7C
		public PuppetColliderToConvexV2 chest
		{
			get
			{
				return this.m_Chest;
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x0600035C RID: 860 RVA: 0x00010C84 File Offset: 0x0000EE84
		public PuppetColliderToConvexV2 armL
		{
			get
			{
				return this.m_ArmL;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x0600035D RID: 861 RVA: 0x00010C8C File Offset: 0x0000EE8C
		public PuppetColliderToConvexV2 armR
		{
			get
			{
				return this.m_ArmR;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x0600035E RID: 862 RVA: 0x00010C94 File Offset: 0x0000EE94
		protected override BehaviourAdder.AddType addType
		{
			get
			{
				return BehaviourAdder.AddType.afterStart;
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x0600035F RID: 863 RVA: 0x00010C97 File Offset: 0x0000EE97
		public override bool removerDespuesDeAñadir
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00010C9C File Offset: 0x0000EE9C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			ICharacter component = base.GetComponent<ICharacter>();
			this.m_Animator = component.GetComponentInChildren<Animator>();
			this.m_puppet = component.GetComponentInChildren<PuppetMaster>();
		}

		// Token: 0x06000361 RID: 865 RVA: 0x00010CD0 File Offset: 0x0000EED0
		protected override void AddBehaviour()
		{
			Transform transform = this.m_Animator.transform.parent.CreateChild("ConvexColliders_Root");
			this.m_added = new List<PuppetColliderToConvexV2>();
			this.AddColliders(transform);
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00010D0C File Offset: 0x0000EF0C
		private void AddColliders(Transform parent)
		{
			this.AddHipsColliders(parent);
			this.AddPiernaColliders(ref this.m_PiernaL, parent, Side.L);
			this.AddPiernaColliders(ref this.m_PiernaR, parent, Side.R);
			this.AddGenericMuscleColliders(ref this.m_Spine, parent, HumanBodyBones.Spine);
			this.AddGenericMuscleColliders(ref this.m_Chest, parent, HumanBodyBones.Chest);
			this.AddGenericMuscleColliders(ref this.m_ArmL, parent, HumanBodyBones.LeftUpperArm);
			this.AddGenericMuscleColliders(ref this.m_ArmR, parent, HumanBodyBones.RightUpperArm);
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00010D78 File Offset: 0x0000EF78
		private void AddGenericMuscleColliders(ref PuppetColliderToConvexV2 resultado, Transform parent, HumanBodyBones humanBone)
		{
			Muscle muscle = PuppetCollidersToConvexAdderV2.GetMuscle(this.m_Animator, this.m_puppet, humanBone);
			Transform transform = parent.CreateChild(muscle.name + "_ConvexCollider");
			resultado = transform.gameObject.AddComponent<PuppetColliderToConvexV2>();
			this.m_added.Add(resultado);
			resultado.Init(Singleton<ConfiguracionGeneral>.instance.layers.toSkinConvexCollider, this.m_puppet, muscle, PuppetColliderToConvexV2.ToCopyFrom.muscle, 1f, 1f, 1f, null);
			resultado.transform.ExecDeepChild(delegate(Transform trans)
			{
				trans.gameObject.layer = Singleton<ConfiguracionGeneral>.instance.layers.toSkinConvexCollider;
			}, true);
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00010E2C File Offset: 0x0000F02C
		private void AddPiernaColliders(ref PuppetColliderToConvexV2 resultado, Transform parent, Side side)
		{
			Muscle muscle;
			if (side != Side.L)
			{
				if (side != Side.R)
				{
					throw new ArgumentOutOfRangeException(side.ToString());
				}
				muscle = PuppetCollidersToConvexAdderV2.GetMuscle(this.m_Animator, this.m_puppet, HumanBodyBones.RightUpperLeg);
			}
			else
			{
				muscle = PuppetCollidersToConvexAdderV2.GetMuscle(this.m_Animator, this.m_puppet, HumanBodyBones.LeftUpperLeg);
			}
			Transform transform = parent.CreateChild(muscle.name + "_ConvexCollider");
			resultado = transform.gameObject.AddComponent<PuppetColliderToConvexV2>();
			this.m_added.Add(resultado);
			resultado.Init(Singleton<ConfiguracionGeneral>.instance.layers.toSkinConvexCollider, this.m_puppet, muscle, PuppetColliderToConvexV2.ToCopyFrom.muscle, 1f, 1f, 1f, null);
			resultado.transform.ExecDeepChild(delegate(Transform trans)
			{
				trans.gameObject.layer = Singleton<ConfiguracionGeneral>.instance.layers.toSkinConvexCollider;
			}, true);
		}

		// Token: 0x06000365 RID: 869 RVA: 0x00010F14 File Offset: 0x0000F114
		private void AddHipsColliders(Transform parent)
		{
			PuppetMaster puppet = this.m_puppet;
			Muscle muscle = PuppetCollidersToConvexAdderV2.GetMuscle(this.m_Animator, puppet, HumanBodyBones.Hips);
			Transform transform = parent.CreateChild(muscle.name + "_ConvexCollider");
			this.m_HipsCollider = transform.gameObject.AddComponent<PuppetColliderToConvexV2>();
			this.m_added.Add(this.m_HipsCollider);
			this.m_HipsCollider.Init(Singleton<ConfiguracionGeneral>.instance.layers.toSkinConvexCollider, puppet, muscle, PuppetColliderToConvexV2.ToCopyFrom.muscle, 1f, 1f, 1f, null);
			this.m_HipsCollider.transform.ExecDeepChild(delegate(Transform trans)
			{
				trans.gameObject.layer = Singleton<ConfiguracionGeneral>.instance.layers.toSkinConvexCollider;
			}, true);
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00010FD4 File Offset: 0x0000F1D4
		public static Muscle GetMuscle(Animator anim, PuppetMaster puppet, HumanBodyBones bone)
		{
			Transform boneTransform = anim.GetBoneTransform(bone);
			foreach (Muscle muscle in puppet.muscles)
			{
				if (muscle.target == boneTransform)
				{
					return muscle;
				}
			}
			return null;
		}

		// Token: 0x0400024D RID: 589
		private List<PuppetColliderToConvexV2> m_added;

		// Token: 0x0400024E RID: 590
		[SerializeField]
		[ReadOnlyUI]
		private PuppetColliderToConvexV2 m_HipsCollider;

		// Token: 0x0400024F RID: 591
		[SerializeField]
		[ReadOnlyUI]
		private PuppetColliderToConvexV2 m_PiernaL;

		// Token: 0x04000250 RID: 592
		[SerializeField]
		[ReadOnlyUI]
		private PuppetColliderToConvexV2 m_PiernaR;

		// Token: 0x04000251 RID: 593
		[SerializeField]
		[ReadOnlyUI]
		private PuppetColliderToConvexV2 m_Spine;

		// Token: 0x04000252 RID: 594
		[SerializeField]
		[ReadOnlyUI]
		private PuppetColliderToConvexV2 m_Chest;

		// Token: 0x04000253 RID: 595
		[SerializeField]
		[ReadOnlyUI]
		private PuppetColliderToConvexV2 m_ArmL;

		// Token: 0x04000254 RID: 596
		[SerializeField]
		[ReadOnlyUI]
		private PuppetColliderToConvexV2 m_ArmR;

		// Token: 0x04000255 RID: 597
		private PuppetMaster m_puppet;

		// Token: 0x04000256 RID: 598
		private Animator m_Animator;
	}
}
