using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes
{
	// Token: 0x02000051 RID: 81
	[RequireComponent(typeof(ICharacter))]
	public sealed class PuppetCollidersToPenisAdder : BehaviourAdder
	{
		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000368 RID: 872 RVA: 0x0001101B File Offset: 0x0000F21B
		public sealed override object addedResult
		{
			get
			{
				return this.m_added;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000369 RID: 873 RVA: 0x00011023 File Offset: 0x0000F223
		public PuppetColliderToPene hipsCollider
		{
			get
			{
				return this.m_HipsCollider;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x0600036A RID: 874 RVA: 0x0001102B File Offset: 0x0000F22B
		public PuppetColliderToPene piernaL
		{
			get
			{
				return this.m_PiernaL;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600036B RID: 875 RVA: 0x00011033 File Offset: 0x0000F233
		public PuppetColliderToPene piernaR
		{
			get
			{
				return this.m_PiernaR;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600036C RID: 876 RVA: 0x0001103B File Offset: 0x0000F23B
		protected override BehaviourAdder.AddType addType
		{
			get
			{
				return BehaviourAdder.AddType.afterStart;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x0600036D RID: 877 RVA: 0x0001103E File Offset: 0x0000F23E
		public override bool removerDespuesDeAñadir
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600036E RID: 878 RVA: 0x00011044 File Offset: 0x0000F244
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			ICharacter component = base.GetComponent<ICharacter>();
			this.m_Animator = component.GetComponentInChildren<Animator>();
			this.m_puppet = component.GetComponentInChildren<PuppetMaster>();
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00011078 File Offset: 0x0000F278
		protected override void AddBehaviour()
		{
			Transform transform = this.m_Animator.transform.parent.CreateChild("ToPenisColliders_Root");
			this.m_added = new List<PuppetColliderToPene>();
			this.AddColliders(transform);
		}

		// Token: 0x06000370 RID: 880 RVA: 0x000110B2 File Offset: 0x0000F2B2
		private void AddColliders(Transform parent)
		{
			this.AddHipsColliders(parent);
			this.AddPiernaColliders(ref this.m_PiernaL, parent, Side.L);
			this.AddPiernaColliders(ref this.m_PiernaR, parent, Side.R);
		}

		// Token: 0x06000371 RID: 881 RVA: 0x000110D8 File Offset: 0x0000F2D8
		private void AddPiernaColliders(ref PuppetColliderToPene resultado, Transform parent, Side side)
		{
			Muscle muscle;
			if (side != Side.L)
			{
				if (side != Side.R)
				{
					throw new ArgumentOutOfRangeException(side.ToString());
				}
				muscle = PuppetCollidersToPenisAdder.GetMuscle(this.m_Animator, this.m_puppet, HumanBodyBones.RightUpperLeg);
			}
			else
			{
				muscle = PuppetCollidersToPenisAdder.GetMuscle(this.m_Animator, this.m_puppet, HumanBodyBones.LeftUpperLeg);
			}
			Transform transform = parent.CreateChild(muscle.name + "_ToPenisCollider");
			resultado = transform.gameObject.AddComponent<PuppetColliderToPene>();
			this.m_added.Add(resultado);
			resultado.Init(Singleton<ConfiguracionGeneral>.instance.layers.skinsHairRenders, this.m_puppet, muscle, PuppetColliderToPene.ToCopyFrom.muscle, this.widhtMod);
			resultado.transform.ExecDeepChild(delegate(Transform trans)
			{
				trans.gameObject.layer = Singleton<ConfiguracionGeneral>.instance.layers.skinsHairRenders;
			}, true);
		}

		// Token: 0x06000372 RID: 882 RVA: 0x000111B0 File Offset: 0x0000F3B0
		private void AddHipsColliders(Transform parent)
		{
			PuppetMaster puppet = this.m_puppet;
			Muscle muscle = PuppetCollidersToPenisAdder.GetMuscle(this.m_Animator, puppet, HumanBodyBones.Hips);
			Transform transform = parent.CreateChild(muscle.name + "_ToPenisCollider");
			this.m_HipsCollider = transform.gameObject.AddComponent<PuppetColliderToPene>();
			this.m_added.Add(this.m_HipsCollider);
			this.m_HipsCollider.Init(Singleton<ConfiguracionGeneral>.instance.layers.skinsHairRenders, puppet, muscle, PuppetColliderToPene.ToCopyFrom.muscle, this.widhtMod);
			this.m_HipsCollider.transform.ExecDeepChild(delegate(Transform trans)
			{
				trans.gameObject.layer = Singleton<ConfiguracionGeneral>.instance.layers.skinsHairRenders;
			}, true);
		}

		// Token: 0x06000373 RID: 883 RVA: 0x00011260 File Offset: 0x0000F460
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

		// Token: 0x04000257 RID: 599
		private List<PuppetColliderToPene> m_added;

		// Token: 0x04000258 RID: 600
		[SerializeField]
		private float widhtMod = 0.85f;

		// Token: 0x04000259 RID: 601
		[SerializeField]
		[ReadOnlyUI]
		private PuppetColliderToPene m_HipsCollider;

		// Token: 0x0400025A RID: 602
		[SerializeField]
		[ReadOnlyUI]
		private PuppetColliderToPene m_PiernaL;

		// Token: 0x0400025B RID: 603
		[SerializeField]
		[ReadOnlyUI]
		private PuppetColliderToPene m_PiernaR;

		// Token: 0x0400025C RID: 604
		private PuppetMaster m_puppet;

		// Token: 0x0400025D RID: 605
		private Animator m_Animator;
	}
}
