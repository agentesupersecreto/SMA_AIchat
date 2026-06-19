using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Targets;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000077 RID: 119
	[RequireComponent(typeof(FullBodyBipedIK))]
	public sealed class FixBendDirection : AplicableBehaviour
	{
		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x00015519 File Offset: 0x00013719
		private FBIKChain brazoDerecho
		{
			get
			{
				return this.m_ik.solver.GetChain(FullBodyBipedChain.RightArm);
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x0001552C File Offset: 0x0001372C
		private FBIKChain brazoIzquierdo
		{
			get
			{
				return this.m_ik.solver.GetChain(FullBodyBipedChain.RightArm);
			}
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x0001553F File Offset: 0x0001373F
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ik = base.GetComponent<FullBodyBipedIK>();
			if (this.m_ik == null)
			{
				throw new ArgumentNullException("m_ik", "m_ik null reference.");
			}
			this.Init();
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x00015578 File Offset: 0x00013778
		private void Init()
		{
			Animator componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("anim", "anim null reference.");
			}
			this.m_chest = componentEnRoot.GetBoneTransform(HumanBodyBones.Chest);
			Transform boneTransform = componentEnRoot.GetBoneTransform(HumanBodyBones.RightUpperArm);
			Transform boneTransform2 = componentEnRoot.GetBoneTransform(HumanBodyBones.LeftUpperArm);
			Transform boneTransform3 = componentEnRoot.GetBoneTransform(HumanBodyBones.RightLowerArm);
			Transform boneTransform4 = componentEnRoot.GetBoneTransform(HumanBodyBones.LeftLowerArm);
			Transform boneTransform5 = componentEnRoot.GetBoneTransform(HumanBodyBones.RightHand);
			Transform boneTransform6 = componentEnRoot.GetBoneTransform(HumanBodyBones.LeftHand);
			this.brazoRV2.Init(this.m_chest, boneTransform, boneTransform3, boneTransform5, componentEnRoot.transform, this.m_ik, false);
			this.brazoLV2.Init(this.m_chest, boneTransform2, boneTransform4, boneTransform6, componentEnRoot.transform, this.m_ik, true);
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x00015631 File Offset: 0x00013831
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			IKSolverFullBodyBiped solver = this.m_ik.solver;
			solver.OnPreBend = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPreBend, new IKSolver.UpdateDelegate(this.OnPreBend));
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00015665 File Offset: 0x00013865
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			IKSolverFullBodyBiped solver = this.m_ik.solver;
			solver.OnPreBend = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPreBend, new IKSolver.UpdateDelegate(this.OnPreBend));
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x0001569A File Offset: 0x0001389A
		private void OnPreBend()
		{
			if (this.m_ik == null)
			{
				return;
			}
			this.brazoRV2.OnPreBend();
			this.brazoLV2.OnPreBend();
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x000156C1 File Offset: 0x000138C1
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			Debug.LogWarning("Re Init solo deberia usarse en una pose por defecto.");
			this.Init();
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x000156D9 File Offset: 0x000138D9
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Re Init",
				editorTimeVisible = false
			};
		}

		// Token: 0x040002FD RID: 765
		private FullBodyBipedIK m_ik;

		// Token: 0x040002FE RID: 766
		private Transform m_chest;

		// Token: 0x040002FF RID: 767
		public FixBendDirection.ChainFixArmV2 brazoRV2 = new FixBendDirection.ChainFixArmV2();

		// Token: 0x04000300 RID: 768
		public FixBendDirection.ChainFixArmV2 brazoLV2 = new FixBendDirection.ChainFixArmV2();

		// Token: 0x04000301 RID: 769
		private static List<CustomBipedEffector> m_effectorsTypes = new List<CustomBipedEffector>
		{
			CustomBipedEffector.codoDerecho,
			CustomBipedEffector.codoIzquierdo
		};

		// Token: 0x02000167 RID: 359
		[Serializable]
		public class ChainFixArmV2
		{
			// Token: 0x06000BBB RID: 3003 RVA: 0x0003570C File Offset: 0x0003390C
			public void Init(Transform chest, Transform arm, Transform foreArm, Transform hand, Transform characterSpace, FullBodyBipedIK ik, bool esMirror)
			{
				this.chest = chest;
				this.arm = arm;
				this.foreArm = foreArm;
				this.hand = hand;
				this.ik = ik;
				ik.solver.GetChainAndNodeIndexes(arm, out this.chainIndex1, out this.nodeIndex1);
				ik.solver.GetChainAndNodeIndexes(foreArm, out this.chainIndex2, out this.nodeIndex2);
				ik.solver.GetChainAndNodeIndexes(hand, out this.chainIndex3, out this.nodeIndex3);
				Vector3 vector = this.OrthoToBone1(ik.solver, this.OrthoToLimb(ik.solver, foreArm.position - arm.position));
				Vector3 vector2 = Vector3.Cross((hand.position - arm.position).normalized, vector);
				this.defaultChildDirection = Quaternion.Inverse(hand.rotation) * vector2;
				Vector3 normalized = (Math3d.ProjectPointOnPlane(characterSpace.up, chest.position, arm.position) - chest.position).normalized;
				Vector3 vector3 = ((!esMirror) ? this.localOutDirectionV3 : new Vector3(-this.localOutDirectionV3.x, this.localOutDirectionV3.y, this.localOutDirectionV3.z));
				this.defaultLocalOutDirection = chest.InverseTransformDirection(Quaternion.LookRotation(normalized, characterSpace.up) * vector3.normalized);
				Vector3 vector4;
				if (esMirror)
				{
					vector4 = -characterSpace.right;
				}
				else
				{
					vector4 = characterSpace.right;
				}
				this.defaultLocalForwardDirection = chest.InverseTransformDirection(vector4);
				Vector3 normalized2 = Vector3.Cross(vector4, characterSpace.up).normalized;
				Vector3 up = characterSpace.up;
				this.defaultLocalRightDirection = chest.InverseTransformDirection(normalized2);
				this.defaultLocalUpDirection = chest.InverseTransformDirection(up);
				this.chain = ik.solver.chain[this.chainIndex1];
				this.handIKEffector = ik.solver.GetEffector(hand);
				this.brazoIKEffector = ik.solver.GetEffector(arm);
				this.m_esMirror = esMirror;
				this.m_CustomTarget = new FixBendDirection.ChainFixArmV2.CustomTarget(this);
			}

			// Token: 0x1700023D RID: 573
			// (get) Token: 0x06000BBC RID: 3004 RVA: 0x00035933 File Offset: 0x00033B33
			public FixBendDirection.ChainFixArmV2.CustomTarget customTarget
			{
				get
				{
					return this.m_CustomTarget;
				}
			}

			// Token: 0x06000BBD RID: 3005 RVA: 0x0003593C File Offset: 0x00033B3C
			public void OnPreBend()
			{
				try
				{
					if (!this.active)
					{
						bool flag = this.debugDraw;
					}
					else
					{
						bool flag2 = this.debugDraw;
						float num = Mathf.Max(this.handIKEffector.positionWeight, this.handIKEffector.rotationWeight);
						this.chain.bendConstraint.weight = Mathf.Lerp(0f, 1f, (num * this.weight).InPow(2f));
						if (this.chain.bendConstraint.weight > 0f)
						{
							float magnitude = (this.arm.position - this.foreArm.position).magnitude;
							Vector3 vector = this.chest.TransformDirection(this.defaultLocalOutDirection);
							float num2 = magnitude * this.distanceMod;
							Vector3 vector2 = this.arm.position + vector.normalized * num2;
							Vector3 defaultDir = this.GetDefaultDir(this.ik.solver);
							Vector3 vector3 = this.arm.position + defaultDir;
							float num3 = Vector3.Angle(vector, vector3 - vector2);
							Vector3 vector4 = defaultDir;
							Vector3 vector5 = vector2;
							bool flag3 = this.debugDraw;
							if (num3 > this.angleV2)
							{
								vector4 = (Math3d.ProjectPointOnPlaneCone(vector, vector5, vector3, this.angleV2, magnitude, false) - this.arm.position).SetMagnitud(magnitude);
							}
							Vector3 vector6 = this.ik.solver.GetNode(this.chainIndex3, this.nodeIndex3).solverPosition - this.ik.solver.GetNode(this.chainIndex1, this.nodeIndex1).solverPosition;
							float num4 = Vector3.Dot(this.chest.TransformDirection(this.defaultLocalForwardDirection), vector6);
							if (num4 < 0f)
							{
								Vector3 vector7 = this.chest.TransformDirection(this.defaultLocalRightDirection);
								bool flag4 = Vector3.Dot(vector6, this.m_esMirror ? vector7 : (-vector7)) < 0f;
								Vector3 normalized = this.localOutDirectionV3.normalized;
								normalized.x = (this.m_esMirror ? normalized.x : (-normalized.x));
								if (!flag4)
								{
									normalized.x = -normalized.x;
								}
								Vector3 vector8 = this.chest.TransformDirection(Quaternion.LookRotation(this.defaultLocalForwardDirection, this.defaultLocalUpDirection) * normalized).SetMagnitud(magnitude);
								bool flag5 = this.debugDraw;
								vector4 = Vector3.Lerp(vector4, vector8, (num4 * -1f).OutPow(this.inwardsPower) * this.inwardsMod);
								bool flag6 = this.debugDraw;
							}
							if (vector4 != Vector3.zero)
							{
								this.chain.bendConstraint.direction = vector4;
							}
							bool flag7 = this.debugDraw;
						}
					}
				}
				finally
				{
					this.m_CustomTarget.OnPreBend();
				}
			}

			// Token: 0x06000BBE RID: 3006 RVA: 0x00035C34 File Offset: 0x00033E34
			public Vector3 GetDefaultDir(IKSolverFullBody solver)
			{
				Vector3 vector = solver.GetNode(this.chainIndex3, this.nodeIndex3).solverPosition - solver.GetNode(this.chainIndex1, this.nodeIndex1).solverPosition;
				Vector3 vector2 = Quaternion.FromToRotation(this.hand.position - this.arm.position, vector) * (this.foreArm.position - this.arm.position);
				if (solver.GetNode(this.chainIndex3, this.nodeIndex3).effectorRotationWeight > 0f)
				{
					Vector3 vector3 = -Vector3.Cross(vector, solver.GetNode(this.chainIndex3, this.nodeIndex3).solverRotation * this.defaultChildDirection);
					vector2 = Vector3.Lerp(vector2, vector3, solver.GetNode(this.chainIndex3, this.nodeIndex3).effectorRotationWeight);
				}
				if (this.debugDraw)
				{
					Debug.DrawRay(this.arm.position, vector2, Color.red, Time.deltaTime, false);
				}
				return vector2;
			}

			// Token: 0x06000BBF RID: 3007 RVA: 0x00035D48 File Offset: 0x00033F48
			private Vector3 OrthoToBone1(IKSolverFullBody solver, Vector3 tangent)
			{
				Vector3 vector = solver.GetNode(this.chainIndex2, this.nodeIndex2).solverPosition - solver.GetNode(this.chainIndex1, this.nodeIndex1).solverPosition;
				Vector3.OrthoNormalize(ref vector, ref tangent);
				return tangent;
			}

			// Token: 0x06000BC0 RID: 3008 RVA: 0x00035D94 File Offset: 0x00033F94
			private Vector3 OrthoToLimb(IKSolverFullBody solver, Vector3 tangent)
			{
				Vector3 vector = solver.GetNode(this.chainIndex3, this.nodeIndex3).solverPosition - solver.GetNode(this.chainIndex1, this.nodeIndex1).solverPosition;
				Vector3.OrthoNormalize(ref vector, ref tangent);
				return tangent;
			}

			// Token: 0x04000818 RID: 2072
			public bool debugDraw;

			// Token: 0x04000819 RID: 2073
			public bool active = true;

			// Token: 0x0400081A RID: 2074
			[Range(0f, 1f)]
			public float weight = 1f;

			// Token: 0x0400081B RID: 2075
			public IKEffector brazoIKEffector;

			// Token: 0x0400081C RID: 2076
			public IKEffector handIKEffector;

			// Token: 0x0400081D RID: 2077
			public FBIKChain chain;

			// Token: 0x0400081E RID: 2078
			private FullBodyBipedIK ik;

			// Token: 0x0400081F RID: 2079
			private Transform chest;

			// Token: 0x04000820 RID: 2080
			private Transform arm;

			// Token: 0x04000821 RID: 2081
			private Transform foreArm;

			// Token: 0x04000822 RID: 2082
			private Transform hand;

			// Token: 0x04000823 RID: 2083
			private bool m_esMirror;

			// Token: 0x04000824 RID: 2084
			private int chainIndex1;

			// Token: 0x04000825 RID: 2085
			private int nodeIndex1;

			// Token: 0x04000826 RID: 2086
			private int chainIndex2;

			// Token: 0x04000827 RID: 2087
			private int nodeIndex2;

			// Token: 0x04000828 RID: 2088
			private int chainIndex3;

			// Token: 0x04000829 RID: 2089
			private int nodeIndex3;

			// Token: 0x0400082A RID: 2090
			private Vector3 defaultChildDirection;

			// Token: 0x0400082B RID: 2091
			private Vector3 defaultLocalOutDirection;

			// Token: 0x0400082C RID: 2092
			private Vector3 defaultLocalForwardDirection;

			// Token: 0x0400082D RID: 2093
			private Vector3 defaultLocalRightDirection;

			// Token: 0x0400082E RID: 2094
			private Vector3 defaultLocalUpDirection;

			// Token: 0x0400082F RID: 2095
			public float angleV2 = 45f;

			// Token: 0x04000830 RID: 2096
			public float distanceMod = 0.66f;

			// Token: 0x04000831 RID: 2097
			[NonSerialized]
			public Vector3 localOutDirectionV3 = new Vector3(0.15f, -0.75f, 1f);

			// Token: 0x04000832 RID: 2098
			public float inwardsMod = 1f;

			// Token: 0x04000833 RID: 2099
			public float inwardsPower = 6f;

			// Token: 0x04000834 RID: 2100
			[SerializeField]
			private FixBendDirection.ChainFixArmV2.CustomTarget m_CustomTarget;

			// Token: 0x020001E0 RID: 480
			[Serializable]
			public class CustomTarget
			{
				// Token: 0x06000D6B RID: 3435 RVA: 0x0003B0B6 File Offset: 0x000392B6
				public CustomTarget(FixBendDirection.ChainFixArmV2 owner)
				{
					if (owner == null)
					{
						throw new ArgumentNullException("owner", "owner null reference.");
					}
					this.m_owner = owner;
				}

				// Token: 0x06000D6C RID: 3436 RVA: 0x0003B0D8 File Offset: 0x000392D8
				public void OnPreBend()
				{
					if (this.weight <= 0f)
					{
						return;
					}
					if (this.m_owner.chain.bendConstraint.weight > 0f)
					{
						this.m_owner.chain.bendConstraint.weight = Mathf.Max(this.m_owner.chain.bendConstraint.weight, Mathf.Clamp01(this.weight));
						this.m_owner.chain.bendConstraint.direction = Vector3.Lerp(this.m_owner.chain.bendConstraint.direction, this.nodeDirection, this.weight);
					}
					else
					{
						this.m_owner.chain.bendConstraint.weight = this.weight;
						this.m_owner.chain.bendConstraint.direction = this.nodeDirection;
					}
					bool debugDraw = this.m_owner.debugDraw;
				}

				// Token: 0x04000A26 RID: 2598
				[NonSerialized]
				private FixBendDirection.ChainFixArmV2 m_owner;

				// Token: 0x04000A27 RID: 2599
				[Range(0f, 1f)]
				public float weight;

				// Token: 0x04000A28 RID: 2600
				public Vector3 nodeDirection;

				// Token: 0x04000A29 RID: 2601
				private Vector3 m_lastDirection;

				// Token: 0x04000A2A RID: 2602
				public Vector3 calculedDirection;
			}
		}

		// Token: 0x02000168 RID: 360
		[Serializable]
		public class ChainFixArm
		{
			// Token: 0x06000BC2 RID: 3010 RVA: 0x00035E4C File Offset: 0x0003404C
			public void Init(Transform chest, Transform arm, Transform hand, Transform characterSpace, float wToOutDirection, float wToBackwardsDirection, float resultDirectionMod, FullBodyBipedIK ik, bool invertX)
			{
				Vector3 vector = Math3d.ProjectPointOnPlane(characterSpace.up, chest.position, arm.position) - chest.position;
				Vector3 vector2 = characterSpace.right;
				if (invertX)
				{
					vector2 = -vector2;
				}
				float num = wToOutDirection + wToBackwardsDirection;
				if (num <= 0f)
				{
					throw new InvalidOperationException();
				}
				wToOutDirection /= num;
				wToBackwardsDirection /= num;
				Vector3 vector3 = Vector3.Lerp(vector.normalized, vector2, wToOutDirection);
				Vector3 vector4 = vector2 * wToOutDirection;
				Vector3 vector5 = -characterSpace.forward * wToBackwardsDirection;
				vector3 = vector4 + vector5;
				vector3 = vector3.SetMagnitud(vector) * resultDirectionMod;
				this.localBendGoalFromChest = chest.InverseTransformPoint(chest.position + vector3);
				this.ik = ik;
				this.chest = chest;
				this.arm = arm;
				ik.solver.GetChainAndNodeIndexes(arm, out this.chainIndex, out this.nodeIndex);
				this.chain = ik.solver.chain[this.chainIndex];
				this.handIKEffector = ik.solver.GetEffector(hand);
			}

			// Token: 0x06000BC3 RID: 3011 RVA: 0x00035F68 File Offset: 0x00034168
			public void OnPreBend()
			{
				if (!this.active)
				{
					return;
				}
				float num = Mathf.Max(this.handIKEffector.positionWeight, this.handIKEffector.rotationWeight);
				this.chain.bendConstraint.weight = Mathf.Lerp(0f, this.maxBendConstraintWeightOnCalculed, (num * this.weight).InPow(2f));
				if (this.chain.bendConstraint.weight <= 0f)
				{
					return;
				}
				Vector3 vector = this.chest.TransformPoint(this.localBendGoalFromChest);
				IKSolver.Node node = this.ik.solver.GetNode(this.chainIndex, this.nodeIndex);
				Vector3 vector2 = vector - node.solverPosition;
				if (vector2 != Vector3.zero)
				{
					this.chain.bendConstraint.direction = vector2.normalized;
				}
				bool flag = this.debugDraw;
			}

			// Token: 0x04000835 RID: 2101
			public bool active = true;

			// Token: 0x04000836 RID: 2102
			public bool debugDraw;

			// Token: 0x04000837 RID: 2103
			[Range(0f, 1f)]
			public float weight = 1f;

			// Token: 0x04000838 RID: 2104
			[Range(0f, 1f)]
			public float maxBendConstraintWeightOnCalculed = 0.5f;

			// Token: 0x04000839 RID: 2105
			[Range(0f, 1f)]
			public float maxBendConstraintWeightOnTarget = 1f;

			// Token: 0x0400083A RID: 2106
			public IKEffector handIKEffector;

			// Token: 0x0400083B RID: 2107
			public FBIKChain chain;

			// Token: 0x0400083C RID: 2108
			public Transform chest;

			// Token: 0x0400083D RID: 2109
			public Transform arm;

			// Token: 0x0400083E RID: 2110
			public FullBodyBipedIK ik;

			// Token: 0x0400083F RID: 2111
			public Vector3 localBendGoalFromChest;

			// Token: 0x04000840 RID: 2112
			public int chainIndex;

			// Token: 0x04000841 RID: 2113
			public int nodeIndex;
		}
	}
}
