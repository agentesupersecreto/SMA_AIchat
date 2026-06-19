using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000082 RID: 130
	[RequireComponent(typeof(LookAtIK))]
	public class LookAtInitializador : CustomMonobehaviour
	{
		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000507 RID: 1287 RVA: 0x00019485 File Offset: 0x00017685
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

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000508 RID: 1288 RVA: 0x000194AE File Offset: 0x000176AE
		public Transform head
		{
			get
			{
				return this.m_head;
			}
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x000194B6 File Offset: 0x000176B6
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.SetDefaultCurve();
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x000194C4 File Offset: 0x000176C4
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

		// Token: 0x0600050B RID: 1291 RVA: 0x00019548 File Offset: 0x00017748
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_LookAtIK = base.GetComponent<LookAtIK>();
			this.m_LookAtIK.solver.IKPositionWeight = 0f;
			this.m_Character = base.GetComponentInParent<ICharacter>();
			this.m_LookAtIK.SetAnimator(this.m_Character.bodyAnimator);
			this.m_Character.stared += this.Cha_stared;
			this.m_Animator = this.m_Character.GetComponentInChildren<Animator>();
			this.m_hips = this.m_Animator.GetBoneTransform(HumanBodyBones.Hips);
			this.m_head = this.m_Animator.GetBoneTransform(HumanBodyBones.Head);
			this.m_spine = this.m_Animator.GetBoneTransform(HumanBodyBones.Spine);
			this.m_chest = this.m_Animator.GetBoneTransform(HumanBodyBones.Chest);
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x00019610 File Offset: 0x00017810
		protected void Cha_stared(object obj)
		{
			if (this.usarBonesDeSpine)
			{
				this.TryAddBonesToSpine(Singleton<MapasDeHuesos>.instance.mapas.spineMap.columna.bone1);
				this.TryAddBonesToSpine(Singleton<MapasDeHuesos>.instance.mapas.spineMap.columna.bone2);
				this.TryAddBonesToSpine(Singleton<MapasDeHuesos>.instance.mapas.spineMap.columna.bone3);
			}
			if (this.usarBonesDeCuello)
			{
				this.TryAddBonesToSpine(Singleton<MapasDeHuesos>.instance.mapas.spineMap.cuello.bone1);
				this.TryAddBonesToSpine(Singleton<MapasDeHuesos>.instance.mapas.spineMap.cuello.bone2);
				this.TryAddBonesToSpine(Singleton<MapasDeHuesos>.instance.mapas.spineMap.cuello.bone3);
			}
			Transform boneTransform = this.m_Animator.GetBoneTransform(HumanBodyBones.RightEye);
			Transform boneTransform2 = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftEye);
			IKSolverLookAt solver = this.m_LookAtIK.solver;
			Transform[] array = this.spineBones.ToArray();
			Transform head = this.m_head;
			Transform[] array2;
			if (!this.usarBonesDeOjos)
			{
				array2 = null;
			}
			else
			{
				Transform[] array3 = new Transform[2];
				array3[0] = boneTransform;
				array2 = array3;
				array3[1] = boneTransform2;
			}
			if (!solver.SetChain(array, head, array2, this.m_Animator.transform))
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x00019750 File Offset: 0x00017950
		private void AddBonesToSpine(IList<string> boneNames)
		{
			foreach (string text in boneNames)
			{
				this.TryAddBonesToSpine(text);
			}
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x00019798 File Offset: 0x00017998
		private void TryAddBonesToSpine(string boneName)
		{
			if (string.IsNullOrEmpty(boneName))
			{
				return;
			}
			Transform boneTransform = this.m_Animator.GetBoneTransform(boneName);
			if (boneTransform)
			{
				this.spineBones.Add(boneTransform);
				return;
			}
			throw new KeyNotFoundException(boneName);
		}

		// Token: 0x0400035B RID: 859
		protected ICharacter m_Character;

		// Token: 0x0400035C RID: 860
		protected LookAtIK m_LookAtIK;

		// Token: 0x0400035D RID: 861
		protected Animator m_Animator;

		// Token: 0x0400035E RID: 862
		protected Transform m_head;

		// Token: 0x0400035F RID: 863
		protected Transform m_chest;

		// Token: 0x04000360 RID: 864
		protected Transform m_spine;

		// Token: 0x04000361 RID: 865
		protected Transform m_hips;

		// Token: 0x04000362 RID: 866
		public bool usarBonesDeCuello = true;

		// Token: 0x04000363 RID: 867
		public bool usarBonesDeSpine = true;

		// Token: 0x04000364 RID: 868
		public bool usarBonesDeOjos;

		// Token: 0x04000365 RID: 869
		private List<Transform> spineBones = new List<Transform>();
	}
}
