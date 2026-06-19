using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Runtime;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.Globales.Mapas;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.SexoIKs
{
	// Token: 0x02000025 RID: 37
	[RequireComponent(typeof(LookAtIK))]
	public class OralIKInitializador : CustomMonobehaviour, IIKInitializador
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000147 RID: 327 RVA: 0x00007EB6 File Offset: 0x000060B6
		// (set) Token: 0x06000148 RID: 328 RVA: 0x00007EBE File Offset: 0x000060BE
		Vector3 IIKInitializador.axisEurleOffset
		{
			get
			{
				return this.axisEurleOffset;
			}
			set
			{
				this.axisEurleOffset = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000149 RID: 329 RVA: 0x00007EC7 File Offset: 0x000060C7
		public LookAtIK lookAtIK
		{
			get
			{
				if (this.m_LookAtIK == null)
				{
					this.m_LookAtIK = base.GetComponent<LookAtIK>();
					return this.m_LookAtIK;
				}
				return this.m_LookAtIK;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600014A RID: 330 RVA: 0x00007EF0 File Offset: 0x000060F0
		public Transform lokingBone
		{
			get
			{
				return this.m_LokingBone;
			}
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00007EF8 File Offset: 0x000060F8
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.SetDefaultCurve();
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00007F08 File Offset: 0x00006108
		public void SetDefaultCurve()
		{
			LookAtIK lookAtIK;
			if (this.m_LookAtIK == null)
			{
				lookAtIK = base.GetComponent<LookAtIK>();
			}
			else
			{
				lookAtIK = this.m_LookAtIK;
			}
			Keyframe[] array = new Keyframe[]
			{
				new Keyframe(0f, 0.2f),
				new Keyframe(1f, 1f)
			};
			array[1].inTangent = 1f;
			lookAtIK.solver.spineWeightCurve = new AnimationCurve(array);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00007F88 File Offset: 0x00006188
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_LookAtIK = base.GetComponent<LookAtIK>();
			this.m_LookAtIK.solver.IKPositionWeight = 0f;
			this.m_Character = base.GetComponentInParent<ICharacter>();
			this.m_boca = this.m_Character.GetComponentInChildren<IBocaHole>();
			this.m_LookAtIK.SetAnimator(this.m_Character.bodyAnimator);
			this.m_Character.stared += this.Cha_stared;
			this.m_boca.stared += this.M_boca_stared;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000801D File Offset: 0x0000621D
		private void M_boca_stared(object sender)
		{
			if (this.m_Character.isStared)
			{
				this.SetChain();
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00008032 File Offset: 0x00006232
		protected void Cha_stared(object obj)
		{
			if (this.m_boca.isStared)
			{
				this.SetChain();
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00008048 File Offset: 0x00006248
		private void SetChain()
		{
			if (this.m_initiated)
			{
				return;
			}
			Animator componentInChildren = this.m_Character.GetComponentInChildren<Animator>();
			this.m_head = componentInChildren.GetBoneTransform(HumanBodyBones.Head);
			MapaSingletonDeFemaleBones instance = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
			this.m_LokingBone = this.m_boca.entrada;
			this.TryAddBonesToSpine(instance.NeckTwist01, componentInChildren);
			this.TryAddBonesToSpine(instance.NeckTwist02, componentInChildren);
			if (!this.m_LookAtIK.solver.SetChain(this.spineBones.ToArray(), this.m_head, null, this.m_LokingBone))
			{
				throw new InvalidOperationException();
			}
			this.FixAxis(TipoDeSexIK.facial);
			this.m_initiated = true;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x000080E8 File Offset: 0x000062E8
		public void FixAxis(TipoDeSexIK tipo)
		{
			if (tipo != TipoDeSexIK.facial)
			{
				throw new NotSupportedException();
			}
			Vector3 normalized = (this.m_LokingBone.position - this.m_head.position).normalized;
			this.m_LookAtIK.solver.head.axis = Quaternion.Inverse(this.m_LookAtIK.solver.head.transform.rotation) * Quaternion.Euler(this.axisEurleOffset) * normalized;
			for (int i = 0; i < this.m_LookAtIK.solver.spine.Length; i++)
			{
				IKSolverLookAt.LookAtBone lookAtBone = this.m_LookAtIK.solver.spine[i];
				lookAtBone.axis = Quaternion.Inverse(lookAtBone.transform.rotation) * Quaternion.Euler(this.axisEurleOffset) * normalized;
			}
		}

		// Token: 0x06000152 RID: 338 RVA: 0x000081C8 File Offset: 0x000063C8
		private void TryAddBonesToSpine(string boneName, Animator Animator)
		{
			if (string.IsNullOrEmpty(boneName))
			{
				return;
			}
			Transform boneTransform = Animator.GetBoneTransform(boneName);
			if (boneTransform)
			{
				this.spineBones.Add(boneTransform);
				return;
			}
			throw new KeyNotFoundException(boneName);
		}

		// Token: 0x040000DD RID: 221
		public Vector3 axisEurleOffset;

		// Token: 0x040000DE RID: 222
		protected LookAtIK m_LookAtIK;

		// Token: 0x040000DF RID: 223
		protected ICharacter m_Character;

		// Token: 0x040000E0 RID: 224
		protected IBocaHole m_boca;

		// Token: 0x040000E1 RID: 225
		protected Transform m_LokingBone;

		// Token: 0x040000E2 RID: 226
		protected Transform m_head;

		// Token: 0x040000E3 RID: 227
		private List<Transform> spineBones = new List<Transform>();

		// Token: 0x040000E4 RID: 228
		private bool m_initiated;
	}
}
