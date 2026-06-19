using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.CustomIKs;
using RootMotion;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000076 RID: 118
	public class FingerRigTValle : SolverManager
	{
		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000476 RID: 1142 RVA: 0x00015244 File Offset: 0x00013444
		// (set) Token: 0x06000477 RID: 1143 RVA: 0x0001524C File Offset: 0x0001344C
		public bool initiated { get; private set; }

		// Token: 0x06000478 RID: 1144 RVA: 0x00015258 File Offset: 0x00013458
		public bool IsValid(ref string errorMessage)
		{
			FingerRigTValle.Finger[] array = this.fingers;
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].IsValid(ref errorMessage))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x00015288 File Offset: 0x00013488
		[ContextMenu("Auto-detect")]
		public void AutoDetect()
		{
			this.fingers = new FingerRigTValle.Finger[0];
			for (int i = 0; i < base.transform.childCount; i++)
			{
				Transform[] array = new Transform[0];
				this.AddChildrenRecursive(base.transform.GetChild(i), ref array);
				if (array.Length == 3 || array.Length == 4)
				{
					FingerRigTValle.Finger finger = new FingerRigTValle.Finger();
					finger.bone1 = array[0];
					finger.bone2 = array[1];
					if (array.Length == 3)
					{
						finger.tip = array[2];
					}
					else
					{
						finger.bone3 = array[2];
						finger.tip = array[3];
					}
					finger.weight = 1f;
					Array.Resize<FingerRigTValle.Finger>(ref this.fingers, this.fingers.Length + 1);
					this.fingers[this.fingers.Length - 1] = finger;
				}
			}
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00015354 File Offset: 0x00013554
		public void RemoveFinger(int index)
		{
			if ((float)index < 0f || index >= this.fingers.Length)
			{
				Warning.Log("RemoveFinger index out of bounds.", base.transform, false);
				return;
			}
			if (this.fingers.Length == 1)
			{
				this.fingers = new FingerRigTValle.Finger[0];
				return;
			}
			FingerRigTValle.Finger[] array = new FingerRigTValle.Finger[this.fingers.Length - 1];
			int num = 0;
			for (int i = 0; i < this.fingers.Length; i++)
			{
				if (i != index)
				{
					array[num] = this.fingers[i];
					num++;
				}
			}
			this.fingers = array;
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x000153DE File Offset: 0x000135DE
		private void AddChildrenRecursive(Transform parent, ref Transform[] array)
		{
			Array.Resize<Transform>(ref array, array.Length + 1);
			array[array.Length - 1] = parent;
			if (parent.childCount != 1)
			{
				return;
			}
			this.AddChildrenRecursive(parent.GetChild(0), ref array);
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x00015410 File Offset: 0x00013610
		protected override void InitiateSolver()
		{
			this.initiated = true;
			for (int i = 0; i < this.fingers.Length; i++)
			{
				this.fingers[i].Initiate(base.transform, i, this.bonesLocalForward, this.localBendNormals[i]);
				if (!this.fingers[i].initiated)
				{
					this.initiated = false;
				}
			}
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x00015474 File Offset: 0x00013674
		public void UpdateFingerSolvers()
		{
			if (this.weight <= 0f)
			{
				return;
			}
			FingerRigTValle.Finger[] array = this.fingers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Update(this.weight, this.rotationWeight, this.debugDrawBendDirections);
			}
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x000154C0 File Offset: 0x000136C0
		public void FixFingerTransforms()
		{
			FingerRigTValle.Finger[] array = this.fingers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].FixTransforms();
			}
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x000154EA File Offset: 0x000136EA
		protected override void UpdateSolver()
		{
			this.UpdateFingerSolvers();
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x000154F2 File Offset: 0x000136F2
		protected override void FixTransforms()
		{
			this.FixFingerTransforms();
		}

		// Token: 0x040002F6 RID: 758
		public bool debugDrawBendDirections;

		// Token: 0x040002F7 RID: 759
		[Tooltip("The master weight for all fingers.")]
		[Range(0f, 1f)]
		public float weight = 1f;

		// Token: 0x040002F8 RID: 760
		[Tooltip("The master weight for all fingers.")]
		[Range(0f, 1f)]
		public float rotationWeight;

		// Token: 0x040002F9 RID: 761
		public Vector3 bonesLocalForward;

		// Token: 0x040002FA RID: 762
		public FingerRigTValle.FingersBendNormals localBendNormals;

		// Token: 0x040002FB RID: 763
		public FingerRigTValle.Finger[] fingers = new FingerRigTValle.Finger[0];

		// Token: 0x02000165 RID: 357
		[Serializable]
		public struct FingersBendNormals
		{
			// Token: 0x17000239 RID: 569
			public Vector3 this[int index]
			{
				get
				{
					switch (index)
					{
					case 0:
						return this.pulgar;
					case 1:
						return this.indice;
					case 2:
						return this.corazon;
					case 3:
						return this.angular;
					case 4:
						return this.menique;
					default:
						throw new ArgumentOutOfRangeException(index.ToString());
					}
				}
			}

			// Token: 0x04000808 RID: 2056
			public Vector3 pulgar;

			// Token: 0x04000809 RID: 2057
			public Vector3 indice;

			// Token: 0x0400080A RID: 2058
			public Vector3 corazon;

			// Token: 0x0400080B RID: 2059
			public Vector3 angular;

			// Token: 0x0400080C RID: 2060
			public Vector3 menique;
		}

		// Token: 0x02000166 RID: 358
		[Serializable]
		public class Finger
		{
			// Token: 0x1700023A RID: 570
			// (get) Token: 0x06000BB0 RID: 2992 RVA: 0x0003538C File Offset: 0x0003358C
			// (set) Token: 0x06000BB1 RID: 2993 RVA: 0x00035394 File Offset: 0x00033594
			public bool initiated { get; private set; }

			// Token: 0x1700023B RID: 571
			// (get) Token: 0x06000BB2 RID: 2994 RVA: 0x0003539D File Offset: 0x0003359D
			// (set) Token: 0x06000BB3 RID: 2995 RVA: 0x000353AA File Offset: 0x000335AA
			public Vector3 IKPosition
			{
				get
				{
					return this.solver.IKPosition;
				}
				set
				{
					this.solver.IKPosition = value;
				}
			}

			// Token: 0x1700023C RID: 572
			// (get) Token: 0x06000BB4 RID: 2996 RVA: 0x000353B8 File Offset: 0x000335B8
			// (set) Token: 0x06000BB5 RID: 2997 RVA: 0x000353C5 File Offset: 0x000335C5
			public Quaternion IKRotation
			{
				get
				{
					return this.solver.IKRotation;
				}
				set
				{
					this.solver.IKRotation = value;
				}
			}

			// Token: 0x06000BB6 RID: 2998 RVA: 0x000353D3 File Offset: 0x000335D3
			public bool IsValid(ref string errorMessage)
			{
				if (this.bone1 == null || this.bone2 == null || this.tip == null)
				{
					errorMessage = "One of the bones in the Finger Rig is null, can not initiate solvers.";
					return false;
				}
				return true;
			}

			// Token: 0x06000BB7 RID: 2999 RVA: 0x0003540C File Offset: 0x0003360C
			public void Initiate(Transform hand, int index, Vector3 bonesLocalForward, Vector3 localBendNormal)
			{
				if (bonesLocalForward == Vector3.zero)
				{
					throw new InvalidProgramException();
				}
				if (localBendNormal == Vector3.zero)
				{
					throw new InvalidProgramException();
				}
				this.initiated = false;
				string empty = string.Empty;
				if (!this.IsValid(ref empty))
				{
					Warning.Log(empty, hand, false);
					return;
				}
				this.solver = new IKSolverLimbTValle();
				this.solver.IKPositionWeight = this.weight;
				this.solver.bendModifier = IKSolverLimbTValle.BendModifier.Parent;
				this.solver.ignoreDefaultPose = true;
				this.solver.ignoreDefaultPoseBone2 = false;
				this.solver.overrideBendNormal = false;
				this.solver.inicilizarBendNormalComoLocalDeBone2 = true;
				this.solver.bonesLocalForward = bonesLocalForward;
				this.solver.bendNormal = localBendNormal;
				this.solver.bendModifierWeight = 1f;
				this.IKPosition = this.tip.position;
				this.IKRotation = this.tip.rotation;
				if (this.bone3 != null)
				{
					this.bone3RelativeToTarget = Quaternion.Inverse(this.IKRotation) * this.bone3.rotation;
					this.bone3DefaultLocalPosition = this.bone3.localPosition;
					this.bone3DefaultLocalRotation = this.bone3.localRotation;
				}
				this.solver.SetChain(this.bone1, this.bone2, this.tip, hand);
				this.initiated = true;
			}

			// Token: 0x06000BB8 RID: 3000 RVA: 0x0003557C File Offset: 0x0003377C
			public void FixTransforms()
			{
				if (!this.initiated)
				{
					return;
				}
				this.solver.FixTransforms();
				if (this.bone3 != null)
				{
					this.bone3.localPosition = this.bone3DefaultLocalPosition;
					this.bone3.localRotation = this.bone3DefaultLocalRotation;
				}
			}

			// Token: 0x06000BB9 RID: 3001 RVA: 0x000355D0 File Offset: 0x000337D0
			public void Update(float masterWeight, float masterRotationWeight, bool debugDraw)
			{
				if (!this.initiated)
				{
					return;
				}
				this.solver.bone1.debugDraw = debugDraw;
				this.solver.bone2.debugDraw = debugDraw;
				this.solver.bone3.debugDraw = debugDraw;
				float num = this.weight * masterWeight;
				if (num <= 0f)
				{
					return;
				}
				this.solver.target = this.target;
				if (this.target != null)
				{
					this.IKPosition = this.target.position;
					this.IKRotation = this.target.rotation;
				}
				if (this.bone3 != null)
				{
					if (num >= 1f)
					{
						this.bone3.rotation = this.IKRotation * this.bone3RelativeToTarget;
					}
					else
					{
						this.bone3.rotation = Quaternion.Lerp(this.bone3.rotation, this.IKRotation * this.bone3RelativeToTarget, num);
					}
				}
				this.solver.IKPositionWeight = num;
				this.solver.IKRotationWeight = this.weight * masterRotationWeight;
				this.solver.Update();
			}

			// Token: 0x0400080D RID: 2061
			[Tooltip("Master Weight for the finger.")]
			[Range(0f, 1f)]
			public float weight = 1f;

			// Token: 0x0400080E RID: 2062
			[Tooltip("The first bone of the finger.")]
			public Transform bone1;

			// Token: 0x0400080F RID: 2063
			[Tooltip("The second bone of the finger.")]
			public Transform bone2;

			// Token: 0x04000810 RID: 2064
			[Tooltip("The (optional) third bone of the finger. This can be ignored for thumbs.")]
			public Transform bone3;

			// Token: 0x04000811 RID: 2065
			[Tooltip("The fingertip object. If your character doesn't have tip bones, you can create an empty GameObject and parent it to the last bone in the finger. Place it to the tip of the finger.")]
			public Transform tip;

			// Token: 0x04000812 RID: 2066
			[Tooltip("The IK target (optional, can use IKPosition and IKRotation directly).")]
			public Transform target;

			// Token: 0x04000814 RID: 2068
			[HideInInspector]
			public IKSolverLimbTValle solver;

			// Token: 0x04000815 RID: 2069
			private Quaternion bone3RelativeToTarget;

			// Token: 0x04000816 RID: 2070
			private Vector3 bone3DefaultLocalPosition;

			// Token: 0x04000817 RID: 2071
			private Quaternion bone3DefaultLocalRotation;
		}
	}
}
