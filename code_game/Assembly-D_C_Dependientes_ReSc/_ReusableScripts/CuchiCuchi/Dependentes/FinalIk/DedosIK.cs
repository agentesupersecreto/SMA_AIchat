using System;
using RootMotion.FinalIK;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000172 RID: 370
	public sealed class DedosIK : AplicableCustomMonobehaviour
	{
		// Token: 0x06000805 RID: 2053 RVA: 0x0002965C File Offset: 0x0002785C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			DedosIK.Par par = this.pulgar;
			if (((par != null) ? par.limbIK : null) != null)
			{
				this.pulgar.Init();
			}
			DedosIK.Par par2 = this.indice;
			if (((par2 != null) ? par2.limbIK : null) != null)
			{
				this.indice.Init();
			}
			DedosIK.Par par3 = this.medio;
			if (((par3 != null) ? par3.limbIK : null) != null)
			{
				this.medio.Init();
			}
			DedosIK.Par par4 = this.angular;
			if (((par4 != null) ? par4.limbIK : null) != null)
			{
				this.angular.Init();
			}
			DedosIK.Par par5 = this.menique;
			if (((par5 != null) ? par5.limbIK : null) != null)
			{
				this.menique.Init();
			}
			if (!base.enabled)
			{
				this.EnableIK(false);
			}
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x00029737 File Offset: 0x00027937
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.EnableIK(true);
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x00029746 File Offset: 0x00027946
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.EnableIK(false);
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x00029758 File Offset: 0x00027958
		public void ClearTargets()
		{
			this.pulgar.targetHand = null;
			this.pulgar.target = null;
			this.indice.targetHand = null;
			this.indice.target = null;
			this.medio.targetHand = null;
			this.medio.target = null;
			this.angular.targetHand = null;
			this.angular.target = null;
			this.menique.targetHand = null;
			this.menique.target = null;
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x000297E0 File Offset: 0x000279E0
		public void SetTargets(Transform handTarget, Transform pulgarTarget, Transform indiceTarget, Transform medioTarget, Transform angularTarget, Transform meniqueTarget)
		{
			this.pulgar.targetHand = handTarget;
			this.pulgar.target = pulgarTarget;
			this.indice.targetHand = handTarget;
			this.indice.target = indiceTarget;
			this.medio.targetHand = handTarget;
			this.medio.target = medioTarget;
			this.angular.targetHand = handTarget;
			this.angular.target = angularTarget;
			this.menique.targetHand = handTarget;
			this.menique.target = meniqueTarget;
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x00029868 File Offset: 0x00027A68
		public void SetTargets(HumanHandBonesTargetsIK<Transform> references)
		{
			this.SetTargets(references.hand, references.thumbNub, references.indexNub, references.middleNub, references.ringNub, references.littleNub);
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x00029894 File Offset: 0x00027A94
		private void EnableIK(bool enable)
		{
			DedosIK.Par par = this.pulgar;
			if (((par != null) ? par.limbIK : null) != null)
			{
				this.pulgar.limbIK.enabled = enable;
				this.pulgar.OnEnableChanged(enable);
			}
			DedosIK.Par par2 = this.indice;
			if (((par2 != null) ? par2.limbIK : null) != null)
			{
				this.indice.limbIK.enabled = enable;
				this.indice.OnEnableChanged(enable);
			}
			DedosIK.Par par3 = this.medio;
			if (((par3 != null) ? par3.limbIK : null) != null)
			{
				this.medio.limbIK.enabled = enable;
				this.medio.OnEnableChanged(enable);
			}
			DedosIK.Par par4 = this.angular;
			if (((par4 != null) ? par4.limbIK : null) != null)
			{
				this.angular.limbIK.enabled = enable;
				this.angular.OnEnableChanged(enable);
			}
			DedosIK.Par par5 = this.menique;
			if (((par5 != null) ? par5.limbIK : null) != null)
			{
				this.menique.limbIK.enabled = enable;
				this.menique.OnEnableChanged(enable);
			}
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x000299B4 File Offset: 0x00027BB4
		protected override CustomMonobehaviourBotonConfig Boton1()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Auto Fill",
				confirmar = true,
				playTimeVisible = false
			};
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x000299D4 File Offset: 0x00027BD4
		protected override void OnAplicar()
		{
			base.OnAplicar();
			this.m_EditorAutoFill.Set(this, this.GetComponentEnRoot(false).bodyAnimator);
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x000299F4 File Offset: 0x00027BF4
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Fix Bend Normals And Freeze",
				confirmar = true,
				playTimeVisible = false
			};
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x00029A14 File Offset: 0x00027C14
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.m_FixBendNormalsAndFreeze.Fix(this, this.GetComponentEnRoot(false).bodyAnimator);
		}

		// Token: 0x04000647 RID: 1607
		public DedosIK.Par pulgar;

		// Token: 0x04000648 RID: 1608
		public DedosIK.Par indice;

		// Token: 0x04000649 RID: 1609
		public DedosIK.Par medio;

		// Token: 0x0400064A RID: 1610
		public DedosIK.Par angular;

		// Token: 0x0400064B RID: 1611
		public DedosIK.Par menique;

		// Token: 0x0400064C RID: 1612
		[Header("EDITOR")]
		[SerializeField]
		private DedosIK.EditorAutoFill m_EditorAutoFill;

		// Token: 0x0400064D RID: 1613
		[SerializeField]
		private DedosIK.FixBendNormalsAndFreeze m_FixBendNormalsAndFreeze;

		// Token: 0x02000173 RID: 371
		[Serializable]
		public class Par
		{
			// Token: 0x06000811 RID: 2065 RVA: 0x00029A3C File Offset: 0x00027C3C
			public void Init()
			{
				if (this.tip == null)
				{
					throw new ArgumentNullException("tip", "tip null reference.");
				}
				if (this.limbIK == null)
				{
					throw new ArgumentNullException("IK", "IK null reference.");
				}
				if (!this.limbIK.esSolverIniciado)
				{
					this.limbIK.InitiateComponent();
				}
				this.m_localPosicionDeBone3DesdeTip = Matrix4x4.TRS(this.tip.position, this.tip.rotation, this.limbIK.solver.bone3.transform.lossyScale).inverse.MultiplyPoint3x4(this.limbIK.solver.bone3.transform.position);
				this.m_localRotationDeBone3DesdeTip = Quaternion.Inverse(this.tip.rotation) * this.limbIK.solver.bone3.transform.rotation;
				IKSolverLimb solver = this.limbIK.solver;
				solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPreUpdate, new IKSolver.UpdateDelegate(this.OnPreUpdate));
				this.limbIK.solver.IKPositionWeight = 0f;
				this.limbIK.solver.IKRotationWeight = 0f;
				if (this.targetHand != null && this.target != null)
				{
					this.manoTargetDistance = Vector3.Distance(this.targetHand.position, this.target.position);
				}
			}

			// Token: 0x06000812 RID: 2066 RVA: 0x00029BCA File Offset: 0x00027DCA
			public void OnEnableChanged(bool enabled)
			{
				if (!enabled)
				{
					this.limbIK.solver.IKPositionWeight = 0f;
					this.limbIK.solver.IKRotationWeight = 0f;
				}
			}

			// Token: 0x06000813 RID: 2067 RVA: 0x00029BFC File Offset: 0x00027DFC
			public void GetIkPose(out Vector3 posicion, out Quaternion rotacion)
			{
				Vector3 vector = Matrix4x4.TRS(this.target.position, this.target.rotation, Vector3.one).MultiplyPoint3x4(this.m_localPosicionDeBone3DesdeTip);
				Vector3 vector2 = this.targetHand.InverseTransformPoint(vector);
				posicion = this.hand.TransformPoint(vector2);
				Quaternion quaternion = this.target.rotation * this.m_localRotationDeBone3DesdeTip;
				Quaternion quaternion2 = Quaternion.Inverse(this.targetHand.rotation) * quaternion;
				rotacion = this.hand.rotation * quaternion2;
			}

			// Token: 0x06000814 RID: 2068 RVA: 0x00029CA0 File Offset: 0x00027EA0
			private void OnPreUpdate()
			{
				if (this.target != null && this.targetHand != null && this.limbIK.enabled)
				{
					this.limbIK.solver.IKPositionWeight = Mathf.MoveTowards(this.limbIK.solver.IKPositionWeight, 1f, Time.deltaTime);
					this.limbIK.solver.IKRotationWeight = Mathf.MoveTowards(this.limbIK.solver.IKRotationWeight, 1f, Time.deltaTime);
					Vector3 vector;
					Quaternion quaternion;
					this.GetIkPose(out vector, out quaternion);
					this.limbIK.solver.IKPosition = vector;
					this.limbIK.solver.IKRotation = quaternion;
					return;
				}
				this.limbIK.solver.IKPositionWeight = Mathf.MoveTowards(this.limbIK.solver.IKPositionWeight, 0f, Time.deltaTime);
				this.limbIK.solver.IKRotationWeight = Mathf.MoveTowards(this.limbIK.solver.IKRotationWeight, 0f, Time.deltaTime);
			}

			// Token: 0x0400064E RID: 1614
			[FormerlySerializedAs("IK")]
			public LimbIK limbIK;

			// Token: 0x0400064F RID: 1615
			public Transform hand;

			// Token: 0x04000650 RID: 1616
			public Transform tip;

			// Token: 0x04000651 RID: 1617
			public Transform targetHand;

			// Token: 0x04000652 RID: 1618
			public Transform target;

			// Token: 0x04000653 RID: 1619
			public float manoTargetDistance;

			// Token: 0x04000654 RID: 1620
			private Vector3 m_localPosicionDeBone3DesdeTip;

			// Token: 0x04000655 RID: 1621
			private Quaternion m_localRotationDeBone3DesdeTip;
		}

		// Token: 0x02000174 RID: 372
		[Serializable]
		internal class EditorAutoFill
		{
			// Token: 0x06000816 RID: 2070 RVA: 0x00029DC8 File Offset: 0x00027FC8
			public void Set(DedosIK owner, Animator anim)
			{
				Side side = this.side;
				HumanBodyBones humanBodyBones;
				if (side != Side.L)
				{
					if (side != Side.R)
					{
						throw new ArgumentOutOfRangeException(this.side.ToString());
					}
					humanBodyBones = HumanBodyBones.RightHand;
					this.pulgar.bone1 = HumanBodyBones.RightThumbProximal;
					this.pulgar.bone2 = HumanBodyBones.RightThumbIntermediate;
					this.pulgar.bone3 = HumanBodyBones.RightThumbDistal;
					this.indice.bone1 = HumanBodyBones.RightIndexProximal;
					this.indice.bone2 = HumanBodyBones.RightIndexIntermediate;
					this.indice.bone3 = HumanBodyBones.RightIndexDistal;
					this.medio.bone1 = HumanBodyBones.RightMiddleProximal;
					this.medio.bone2 = HumanBodyBones.RightMiddleIntermediate;
					this.medio.bone3 = HumanBodyBones.RightMiddleDistal;
					this.angular.bone1 = HumanBodyBones.RightRingProximal;
					this.angular.bone2 = HumanBodyBones.RightRingIntermediate;
					this.angular.bone3 = HumanBodyBones.RightRingDistal;
					this.menique.bone1 = HumanBodyBones.RightLittleProximal;
					this.menique.bone2 = HumanBodyBones.RightLittleIntermediate;
					this.menique.bone3 = HumanBodyBones.RightLittleDistal;
				}
				else
				{
					humanBodyBones = HumanBodyBones.LeftHand;
					this.pulgar.bone1 = HumanBodyBones.LeftThumbProximal;
					this.pulgar.bone2 = HumanBodyBones.LeftThumbIntermediate;
					this.pulgar.bone3 = HumanBodyBones.LeftThumbDistal;
					this.indice.bone1 = HumanBodyBones.LeftIndexProximal;
					this.indice.bone2 = HumanBodyBones.LeftIndexIntermediate;
					this.indice.bone3 = HumanBodyBones.LeftIndexDistal;
					this.medio.bone1 = HumanBodyBones.LeftMiddleProximal;
					this.medio.bone2 = HumanBodyBones.LeftMiddleIntermediate;
					this.medio.bone3 = HumanBodyBones.LeftMiddleDistal;
					this.angular.bone1 = HumanBodyBones.LeftRingProximal;
					this.angular.bone2 = HumanBodyBones.LeftRingIntermediate;
					this.angular.bone3 = HumanBodyBones.LeftRingDistal;
					this.menique.bone1 = HumanBodyBones.LeftLittleProximal;
					this.menique.bone2 = HumanBodyBones.LeftLittleIntermediate;
					this.menique.bone3 = HumanBodyBones.LeftLittleDistal;
				}
				Transform boneTransform = anim.GetBoneTransform(humanBodyBones);
				Transform boneTransform2 = anim.GetBoneTransform(this.pulgar.bone1);
				Transform boneTransform3 = anim.GetBoneTransform(this.indice.bone1);
				Transform boneTransform4 = anim.GetBoneTransform(this.medio.bone1);
				Transform boneTransform5 = anim.GetBoneTransform(this.angular.bone1);
				Transform boneTransform6 = anim.GetBoneTransform(this.menique.bone1);
				Transform boneTransform7 = anim.GetBoneTransform(this.pulgar.bone3);
				Transform boneTransform8 = anim.GetBoneTransform(this.indice.bone3);
				Transform boneTransform9 = anim.GetBoneTransform(this.medio.bone3);
				Transform boneTransform10 = anim.GetBoneTransform(this.angular.bone3);
				Transform boneTransform11 = anim.GetBoneTransform(this.menique.bone3);
				this.Set(owner.pulgar, boneTransform, boneTransform2, boneTransform7);
				this.Set(owner.indice, boneTransform, boneTransform3, boneTransform8);
				this.Set(owner.medio, boneTransform, boneTransform4, boneTransform9);
				this.Set(owner.angular, boneTransform, boneTransform5, boneTransform10);
				this.Set(owner.menique, boneTransform, boneTransform6, boneTransform11);
				this.interPose = null;
				this.targets = null;
				TValleEditorTools.SetDirty(owner);
			}

			// Token: 0x06000817 RID: 2071 RVA: 0x0002A0C4 File Offset: 0x000282C4
			private void Set(DedosIK.Par par, Transform handBone, Transform Bone1, Transform Bone3)
			{
				par.limbIK = this.interPose.FindDeepChild(Bone1.name, true).GetComponent<LimbIK>();
				par.hand = this.interPose.FindDeepChild(handBone.name, true);
				par.tip = this.interPose.FindDeepChild(Bone3.GetChild(0).name, true);
				par.targetHand = this.targets.FindDeepChild(handBone.name, true);
				par.target = this.targets.FindDeepChild(par.tip.name, true);
			}

			// Token: 0x04000656 RID: 1622
			public Side side;

			// Token: 0x04000657 RID: 1623
			public Transform interPose;

			// Token: 0x04000658 RID: 1624
			public Transform targets;

			// Token: 0x04000659 RID: 1625
			private DedosIK.EditorAutoFill.Dedo pulgar = new DedosIK.EditorAutoFill.Dedo();

			// Token: 0x0400065A RID: 1626
			private DedosIK.EditorAutoFill.Dedo indice = new DedosIK.EditorAutoFill.Dedo();

			// Token: 0x0400065B RID: 1627
			private DedosIK.EditorAutoFill.Dedo medio = new DedosIK.EditorAutoFill.Dedo();

			// Token: 0x0400065C RID: 1628
			private DedosIK.EditorAutoFill.Dedo angular = new DedosIK.EditorAutoFill.Dedo();

			// Token: 0x0400065D RID: 1629
			private DedosIK.EditorAutoFill.Dedo menique = new DedosIK.EditorAutoFill.Dedo();

			// Token: 0x02000175 RID: 373
			internal class Dedo
			{
				// Token: 0x0400065E RID: 1630
				public HumanBodyBones bone1;

				// Token: 0x0400065F RID: 1631
				public HumanBodyBones bone2;

				// Token: 0x04000660 RID: 1632
				public HumanBodyBones bone3;
			}
		}

		// Token: 0x02000176 RID: 374
		[Serializable]
		internal class FixBendNormalsAndFreeze
		{
			// Token: 0x0600081A RID: 2074 RVA: 0x0002A19C File Offset: 0x0002839C
			public void Fix(DedosIK owner, Animator anim)
			{
				Side side = this.side;
				HumanBodyBones humanBodyBones;
				if (side != Side.L)
				{
					if (side != Side.R)
					{
						throw new ArgumentOutOfRangeException(this.side.ToString());
					}
					humanBodyBones = HumanBodyBones.RightHand;
					this.pulgar.bone1 = HumanBodyBones.RightThumbProximal;
					this.pulgar.bone2 = HumanBodyBones.RightThumbIntermediate;
					this.pulgar.bone3 = HumanBodyBones.RightThumbDistal;
					this.indice.bone1 = HumanBodyBones.RightIndexProximal;
					this.indice.bone2 = HumanBodyBones.RightIndexIntermediate;
					this.indice.bone3 = HumanBodyBones.RightIndexDistal;
					this.medio.bone1 = HumanBodyBones.RightMiddleProximal;
					this.medio.bone2 = HumanBodyBones.RightMiddleIntermediate;
					this.medio.bone3 = HumanBodyBones.RightMiddleDistal;
					this.angular.bone1 = HumanBodyBones.RightRingProximal;
					this.angular.bone2 = HumanBodyBones.RightRingIntermediate;
					this.angular.bone3 = HumanBodyBones.RightRingDistal;
					this.menique.bone1 = HumanBodyBones.RightLittleProximal;
					this.menique.bone2 = HumanBodyBones.RightLittleIntermediate;
					this.menique.bone3 = HumanBodyBones.RightLittleDistal;
				}
				else
				{
					humanBodyBones = HumanBodyBones.LeftHand;
					this.pulgar.bone1 = HumanBodyBones.LeftThumbProximal;
					this.pulgar.bone2 = HumanBodyBones.LeftThumbIntermediate;
					this.pulgar.bone3 = HumanBodyBones.LeftThumbDistal;
					this.indice.bone1 = HumanBodyBones.LeftIndexProximal;
					this.indice.bone2 = HumanBodyBones.LeftIndexIntermediate;
					this.indice.bone3 = HumanBodyBones.LeftIndexDistal;
					this.medio.bone1 = HumanBodyBones.LeftMiddleProximal;
					this.medio.bone2 = HumanBodyBones.LeftMiddleIntermediate;
					this.medio.bone3 = HumanBodyBones.LeftMiddleDistal;
					this.angular.bone1 = HumanBodyBones.LeftRingProximal;
					this.angular.bone2 = HumanBodyBones.LeftRingIntermediate;
					this.angular.bone3 = HumanBodyBones.LeftRingDistal;
					this.menique.bone1 = HumanBodyBones.LeftLittleProximal;
					this.menique.bone2 = HumanBodyBones.LeftLittleIntermediate;
					this.menique.bone3 = HumanBodyBones.LeftLittleDistal;
				}
				anim.GetBoneTransform(humanBodyBones);
				Transform boneTransform = anim.GetBoneTransform(this.pulgar.bone1);
				Transform boneTransform2 = anim.GetBoneTransform(this.indice.bone1);
				Transform boneTransform3 = anim.GetBoneTransform(this.medio.bone1);
				Transform boneTransform4 = anim.GetBoneTransform(this.angular.bone1);
				Transform boneTransform5 = anim.GetBoneTransform(this.menique.bone1);
				Transform boneTransform6 = anim.GetBoneTransform(this.pulgar.bone2);
				Transform boneTransform7 = anim.GetBoneTransform(this.indice.bone2);
				Transform boneTransform8 = anim.GetBoneTransform(this.medio.bone2);
				Transform boneTransform9 = anim.GetBoneTransform(this.angular.bone2);
				Transform boneTransform10 = anim.GetBoneTransform(this.menique.bone2);
				Transform boneTransform11 = anim.GetBoneTransform(this.pulgar.bone3);
				Transform boneTransform12 = anim.GetBoneTransform(this.indice.bone3);
				Transform boneTransform13 = anim.GetBoneTransform(this.medio.bone3);
				Transform boneTransform14 = anim.GetBoneTransform(this.angular.bone3);
				Transform boneTransform15 = anim.GetBoneTransform(this.menique.bone3);
				Transform transform = this.endPoseHand.FindDeepChild(boneTransform.name, true);
				Transform transform2 = this.endPoseHand.FindDeepChild(boneTransform2.name, true);
				Transform transform3 = this.endPoseHand.FindDeepChild(boneTransform3.name, true);
				Transform transform4 = this.endPoseHand.FindDeepChild(boneTransform4.name, true);
				Transform transform5 = this.endPoseHand.FindDeepChild(boneTransform5.name, true);
				Transform transform6 = this.endPoseHand.FindDeepChild(boneTransform6.name, true);
				Transform transform7 = this.endPoseHand.FindDeepChild(boneTransform7.name, true);
				Transform transform8 = this.endPoseHand.FindDeepChild(boneTransform8.name, true);
				Transform transform9 = this.endPoseHand.FindDeepChild(boneTransform9.name, true);
				Transform transform10 = this.endPoseHand.FindDeepChild(boneTransform10.name, true);
				Transform transform11 = this.endPoseHand.FindDeepChild(boneTransform11.name, true);
				Transform transform12 = this.endPoseHand.FindDeepChild(boneTransform12.name, true);
				Transform transform13 = this.endPoseHand.FindDeepChild(boneTransform13.name, true);
				Transform transform14 = this.endPoseHand.FindDeepChild(boneTransform14.name, true);
				Transform transform15 = this.endPoseHand.FindDeepChild(boneTransform15.name, true);
				LimbIK limbIK = transform.gameObject.AddComponent<LimbIK>();
				LimbIK limbIK2 = transform2.gameObject.AddComponent<LimbIK>();
				LimbIK limbIK3 = transform3.gameObject.AddComponent<LimbIK>();
				LimbIK limbIK4 = transform4.gameObject.AddComponent<LimbIK>();
				LimbIK limbIK5 = transform5.gameObject.AddComponent<LimbIK>();
				limbIK.solver.bone1.transform = transform;
				limbIK2.solver.bone1.transform = transform2;
				limbIK3.solver.bone1.transform = transform3;
				limbIK4.solver.bone1.transform = transform4;
				limbIK5.solver.bone1.transform = transform5;
				limbIK.solver.bone2.transform = transform6;
				limbIK2.solver.bone2.transform = transform7;
				limbIK3.solver.bone2.transform = transform8;
				limbIK4.solver.bone2.transform = transform9;
				limbIK5.solver.bone2.transform = transform10;
				limbIK.solver.bone3.transform = transform11;
				limbIK2.solver.bone3.transform = transform12;
				limbIK3.solver.bone3.transform = transform13;
				limbIK4.solver.bone3.transform = transform14;
				limbIK5.solver.bone3.transform = transform15;
				limbIK.solver.Initiate(limbIK.transform);
				limbIK2.solver.Initiate(limbIK2.transform);
				limbIK3.solver.Initiate(limbIK3.transform);
				limbIK4.solver.Initiate(limbIK4.transform);
				limbIK5.solver.Initiate(limbIK5.transform);
				if (!limbIK.esSolverIniciado)
				{
					throw new InvalidOperationException();
				}
				if (!limbIK2.esSolverIniciado)
				{
					throw new InvalidOperationException();
				}
				if (!limbIK3.esSolverIniciado)
				{
					throw new InvalidOperationException();
				}
				if (!limbIK4.esSolverIniciado)
				{
					throw new InvalidOperationException();
				}
				if (!limbIK5.esSolverIniciado)
				{
					throw new InvalidOperationException();
				}
				LimbIK component = this.InterHand.FindDeepChild(boneTransform.name, true).GetComponent<LimbIK>();
				LimbIK component2 = this.InterHand.FindDeepChild(boneTransform2.name, true).GetComponent<LimbIK>();
				LimbIK component3 = this.InterHand.FindDeepChild(boneTransform3.name, true).GetComponent<LimbIK>();
				LimbIK component4 = this.InterHand.FindDeepChild(boneTransform4.name, true).GetComponent<LimbIK>();
				LimbIK component5 = this.InterHand.FindDeepChild(boneTransform5.name, true).GetComponent<LimbIK>();
				component.solver.bendNormal = limbIK.solver.bendNormal;
				component2.solver.bendNormal = limbIK2.solver.bendNormal;
				component3.solver.bendNormal = limbIK3.solver.bendNormal;
				component4.solver.bendNormal = limbIK4.solver.bendNormal;
				component5.solver.bendNormal = limbIK5.solver.bendNormal;
				component.solver.dontCalculeBendNormalOnInit = true;
				component2.solver.dontCalculeBendNormalOnInit = true;
				component3.solver.dontCalculeBendNormalOnInit = true;
				component4.solver.dontCalculeBendNormalOnInit = true;
				component5.solver.dontCalculeBendNormalOnInit = true;
				Object.DestroyImmediate(limbIK, true);
				Object.DestroyImmediate(limbIK2, true);
				Object.DestroyImmediate(limbIK3, true);
				Object.DestroyImmediate(limbIK4, true);
				Object.DestroyImmediate(limbIK5, true);
				this.InterHand = null;
				this.endPoseHand = null;
				TValleEditorTools.SetDirty(component);
				TValleEditorTools.SetDirty(component2);
				TValleEditorTools.SetDirty(component3);
				TValleEditorTools.SetDirty(component4);
				TValleEditorTools.SetDirty(component5);
				TValleEditorTools.SetDirty(owner);
			}

			// Token: 0x04000661 RID: 1633
			public Side side;

			// Token: 0x04000662 RID: 1634
			public Transform InterHand;

			// Token: 0x04000663 RID: 1635
			public Transform endPoseHand;

			// Token: 0x04000664 RID: 1636
			private DedosIK.FixBendNormalsAndFreeze.Dedo pulgar = new DedosIK.FixBendNormalsAndFreeze.Dedo();

			// Token: 0x04000665 RID: 1637
			private DedosIK.FixBendNormalsAndFreeze.Dedo indice = new DedosIK.FixBendNormalsAndFreeze.Dedo();

			// Token: 0x04000666 RID: 1638
			private DedosIK.FixBendNormalsAndFreeze.Dedo medio = new DedosIK.FixBendNormalsAndFreeze.Dedo();

			// Token: 0x04000667 RID: 1639
			private DedosIK.FixBendNormalsAndFreeze.Dedo angular = new DedosIK.FixBendNormalsAndFreeze.Dedo();

			// Token: 0x04000668 RID: 1640
			private DedosIK.FixBendNormalsAndFreeze.Dedo menique = new DedosIK.FixBendNormalsAndFreeze.Dedo();

			// Token: 0x02000177 RID: 375
			internal class Dedo
			{
				// Token: 0x04000669 RID: 1641
				public HumanBodyBones bone1;

				// Token: 0x0400066A RID: 1642
				public HumanBodyBones bone2;

				// Token: 0x0400066B RID: 1643
				public HumanBodyBones bone3;
			}
		}
	}
}
