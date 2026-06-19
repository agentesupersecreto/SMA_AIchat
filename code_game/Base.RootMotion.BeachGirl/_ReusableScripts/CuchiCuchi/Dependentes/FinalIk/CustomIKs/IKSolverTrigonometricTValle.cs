using System;
using RootMotion;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.CustomIKs
{
	// Token: 0x020000BC RID: 188
	[Serializable]
	public class IKSolverTrigonometricTValle : IKSolver
	{
		// Token: 0x060006F2 RID: 1778 RVA: 0x00021E6C File Offset: 0x0002006C
		public void SetBendGoalPosition(Vector3 goalPosition, float weight)
		{
			if (!base.initiated)
			{
				return;
			}
			if (weight <= 0f)
			{
				return;
			}
			Vector3 vector = Vector3.Cross(goalPosition - this.bone1.transform.position, this.IKPosition - this.bone1.transform.position);
			if (vector != Vector3.zero)
			{
				if (weight >= 1f)
				{
					this.bendNormal = vector;
					return;
				}
				this.bendNormal = Vector3.Lerp(this.bendNormal, vector, weight);
			}
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x00021EF4 File Offset: 0x000200F4
		public void SetBendPlaneToCurrent()
		{
			if (!base.initiated || !this.overrideBendNormal)
			{
				return;
			}
			Vector3 vector = Vector3.Cross(this.bone2.transform.position - this.bone1.transform.position, this.bone3.transform.position - this.bone2.transform.position);
			if (vector != Vector3.zero)
			{
				this.bendNormal = vector;
			}
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00021F76 File Offset: 0x00020176
		public void SetIKRotation(Quaternion rotation)
		{
			this.IKRotation = rotation;
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00021F7F File Offset: 0x0002017F
		public void SetIKRotationWeight(float weight)
		{
			this.IKRotationWeight = Mathf.Clamp(weight, 0f, 1f);
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00021F97 File Offset: 0x00020197
		public Quaternion GetIKRotation()
		{
			return this.IKRotation;
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x00021F9F File Offset: 0x0002019F
		public float GetIKRotationWeight()
		{
			return this.IKRotationWeight;
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00021FA7 File Offset: 0x000201A7
		public override IKSolver.Point[] GetPoints()
		{
			return new IKSolver.Point[] { this.bone1, this.bone2, this.bone3 };
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x00021FCC File Offset: 0x000201CC
		public override IKSolver.Point GetPoint(Transform transform)
		{
			if (this.bone1.transform == transform)
			{
				return this.bone1;
			}
			if (this.bone2.transform == transform)
			{
				return this.bone2;
			}
			if (this.bone3.transform == transform)
			{
				return this.bone3;
			}
			return null;
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00022028 File Offset: 0x00020228
		public override void StoreDefaultLocalState()
		{
			this.bone1.StoreDefaultLocalState();
			this.bone2.StoreDefaultLocalState();
			this.bone3.StoreDefaultLocalState();
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x0002204B File Offset: 0x0002024B
		public override void FixTransforms()
		{
			this.bone1.FixTransform();
			this.bone2.FixTransform();
			this.bone3.FixTransform();
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x00022070 File Offset: 0x00020270
		public override bool IsValid(ref string message)
		{
			if (this.bone1.transform == null || this.bone2.transform == null || this.bone3.transform == null)
			{
				message = "Please assign all Bones to the IK solver.";
				return false;
			}
			Object[] array = new Transform[]
			{
				this.bone1.transform,
				this.bone2.transform,
				this.bone3.transform
			};
			Transform transform = (Transform)Hierarchy.ContainsDuplicate(array);
			if (transform != null)
			{
				message = transform.name + " is represented multiple times in the Bones.";
				return false;
			}
			if (this.bone1.transform.position == this.bone2.transform.position)
			{
				message = "first bone position is the same as second bone position.";
				return false;
			}
			if (this.bone2.transform.position == this.bone3.transform.position)
			{
				message = "second bone position is the same as third bone position.";
				return false;
			}
			return true;
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x0002217A File Offset: 0x0002037A
		public bool SetChain(Transform bone1, Transform bone2, Transform bone3, Transform root)
		{
			this.bone1.transform = bone1;
			this.bone2.transform = bone2;
			this.bone3.transform = bone3;
			base.Initiate(root);
			return base.initiated;
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x000221B0 File Offset: 0x000203B0
		public static void Solve(Transform bone1, Transform bone2, Transform bone3, Vector3 targetPosition, Vector3 bendNormal, float weight)
		{
			if (weight <= 0f)
			{
				return;
			}
			targetPosition = Vector3.Lerp(bone3.position, targetPosition, weight);
			Vector3 vector = targetPosition - bone1.position;
			float magnitude = vector.magnitude;
			if (magnitude == 0f)
			{
				return;
			}
			float sqrMagnitude = (bone2.position - bone1.position).sqrMagnitude;
			float sqrMagnitude2 = (bone3.position - bone2.position).sqrMagnitude;
			Vector3 vector2 = Vector3.Cross(vector, bendNormal);
			Vector3 directionToBendPoint = IKSolverTrigonometricTValle.GetDirectionToBendPoint(vector, magnitude, vector2, sqrMagnitude, sqrMagnitude2);
			Quaternion quaternion = Quaternion.FromToRotation(bone2.position - bone1.position, directionToBendPoint);
			if (weight < 1f)
			{
				quaternion = Quaternion.Lerp(Quaternion.identity, quaternion, weight);
			}
			bone1.rotation = quaternion * bone1.rotation;
			Quaternion quaternion2 = Quaternion.FromToRotation(bone3.position - bone2.position, targetPosition - bone2.position);
			if (weight < 1f)
			{
				quaternion2 = Quaternion.Lerp(Quaternion.identity, quaternion2, weight);
			}
			bone2.rotation = quaternion2 * bone2.rotation;
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x000222D8 File Offset: 0x000204D8
		private static Vector3 GetDirectionToBendPoint(Vector3 direction, float directionMag, Vector3 bendDirection, float sqrMag1, float sqrMag2)
		{
			float num = (directionMag * directionMag + (sqrMag1 - sqrMag2)) / 2f / directionMag;
			float num2 = (float)Math.Sqrt((double)Mathf.Clamp(sqrMag1 - num * num, 0f, float.PositiveInfinity));
			if (direction == Vector3.zero)
			{
				return Vector3.zero;
			}
			return Quaternion.LookRotation(direction, bendDirection) * new Vector3(0f, num2, num);
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x00022340 File Offset: 0x00020540
		protected override void OnInitiate()
		{
			if (this.bendNormal == Vector3.zero)
			{
				this.bendNormal = Vector3.right;
			}
			this.OnInitiateVirtual();
			this.IKPosition = this.bone3.transform.position;
			this.IKRotation = this.bone3.transform.rotation;
			this.InitiateBones();
			this.directHierarchy = this.IsDirectHierarchy();
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x000223B0 File Offset: 0x000205B0
		private bool IsDirectHierarchy()
		{
			return !(this.bone3.transform.parent != this.bone2.transform) && !(this.bone2.transform.parent != this.bone1.transform);
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00022408 File Offset: 0x00020608
		private void InitiateBones()
		{
			if (this.ignoreDefaultPose)
			{
				if (this.bonesLocalForward == Vector3.zero)
				{
					throw new InvalidOperationException();
				}
				this.bone1.Initiate(this.bone1.transform.position + this.bone1.transform.TransformDirection(this.bonesLocalForward), this.bendNormal);
			}
			else
			{
				this.bone1.Initiate(this.bone2.transform.position, this.bendNormal);
			}
			if (this.ignoreDefaultPoseBone2)
			{
				if (this.bonesLocalForward == Vector3.zero)
				{
					throw new InvalidOperationException();
				}
				this.bone2.Initiate(this.bone2.transform.position + this.bone2.transform.TransformDirection(this.bonesLocalForward), this.bendNormal);
			}
			else
			{
				this.bone2.Initiate(this.bone3.transform.position, this.bendNormal);
			}
			this.SetBendPlaneToCurrent();
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x0002251C File Offset: 0x0002071C
		protected override void OnUpdate()
		{
			this.IKPositionWeight = Mathf.Clamp(this.IKPositionWeight, 0f, 1f);
			this.IKRotationWeight = Mathf.Clamp(this.IKRotationWeight, 0f, 1f);
			if (this.target != null)
			{
				this.IKPosition = this.target.position;
				this.IKRotation = this.target.rotation;
			}
			this.OnUpdateVirtual();
			if (this.IKPositionWeight > 0f)
			{
				if (!this.directHierarchy)
				{
					if (this.ignoreDefaultPose)
					{
						if (this.bonesLocalForward == Vector3.zero)
						{
							throw new InvalidOperationException();
						}
						this.bone1.Initiate(this.bone1.transform.position + this.bone1.transform.TransformDirection(this.bonesLocalForward), this.bendNormal);
					}
					else
					{
						this.bone1.Initiate(this.bone2.transform.position, this.bendNormal);
					}
					if (this.ignoreDefaultPoseBone2)
					{
						if (this.bonesLocalForward == Vector3.zero)
						{
							throw new InvalidOperationException();
						}
						this.bone2.Initiate(this.bone2.transform.position + this.bone2.transform.TransformDirection(this.bonesLocalForward), this.bendNormal);
					}
					else
					{
						this.bone2.Initiate(this.bone3.transform.position, this.bendNormal);
					}
				}
				this.bone1.sqrMag = (this.bone2.transform.position - this.bone1.transform.position).sqrMagnitude;
				this.bone2.sqrMag = (this.bone3.transform.position - this.bone2.transform.position).sqrMagnitude;
				if (this.bendNormal == Vector3.zero && !Warning.logged)
				{
					base.LogWarning("IKSolverTrigonometric Bend Normal is Vector3.zero.");
				}
				this.weightIKPosition = Vector3.Lerp(this.bone3.transform.position, this.IKPosition, this.IKPositionWeight);
				Vector3 vector = Vector3.Lerp(this.bone1.GetBendNormalFromCurrentRotation(), this.bendNormal, this.IKPositionWeight);
				Vector3 vector2 = Vector3.Lerp(this.bone2.transform.position - this.bone1.transform.position, this.GetBendDirection(this.weightIKPosition, vector), this.IKPositionWeight);
				if (vector2 == Vector3.zero)
				{
					vector2 = this.bone2.transform.position - this.bone1.transform.position;
				}
				this.bone1.transform.rotation = this.bone1.GetRotation(vector2, vector);
				this.bone2.transform.rotation = this.bone2.GetRotation(this.weightIKPosition - this.bone2.transform.position, this.bone2.GetBendNormalFromCurrentRotation());
			}
			if (this.IKRotationWeight > 0f)
			{
				this.bone3.transform.rotation = Quaternion.Slerp(this.bone3.transform.rotation, this.IKRotation, this.IKRotationWeight);
			}
			this.OnPostSolveVirtual();
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x00022899 File Offset: 0x00020A99
		protected virtual void OnInitiateVirtual()
		{
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x0002289B File Offset: 0x00020A9B
		protected virtual void OnUpdateVirtual()
		{
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x0002289D File Offset: 0x00020A9D
		protected virtual void OnPostSolveVirtual()
		{
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x000228A0 File Offset: 0x00020AA0
		protected Vector3 GetBendDirection(Vector3 IKPosition, Vector3 bendNormal)
		{
			Vector3 vector = IKPosition - this.bone1.transform.position;
			if (vector == Vector3.zero)
			{
				return Vector3.zero;
			}
			float sqrMagnitude = vector.sqrMagnitude;
			float num = (float)Math.Sqrt((double)sqrMagnitude);
			float num2 = (sqrMagnitude + this.bone1.sqrMag - this.bone2.sqrMag) / 2f / num;
			float num3 = (float)Math.Sqrt((double)Mathf.Clamp(this.bone1.sqrMag - num2 * num2, 0f, float.PositiveInfinity));
			Vector3 vector2 = Vector3.Cross(vector, bendNormal);
			return Quaternion.LookRotation(vector, vector2) * new Vector3(0f, num3, num2);
		}

		// Token: 0x040004CB RID: 1227
		public bool overrideBendNormal;

		// Token: 0x040004CC RID: 1228
		public bool ignoreDefaultPose;

		// Token: 0x040004CD RID: 1229
		public bool ignoreDefaultPoseBone2;

		// Token: 0x040004CE RID: 1230
		public Vector3 bonesLocalForward;

		// Token: 0x040004CF RID: 1231
		public Transform target;

		// Token: 0x040004D0 RID: 1232
		[Range(0f, 1f)]
		public float IKRotationWeight = 1f;

		// Token: 0x040004D1 RID: 1233
		public Quaternion IKRotation = Quaternion.identity;

		// Token: 0x040004D2 RID: 1234
		public Vector3 bendNormal = Vector3.right;

		// Token: 0x040004D3 RID: 1235
		public IKSolverTrigonometricTValle.TrigonometricBone bone1 = new IKSolverTrigonometricTValle.TrigonometricBone();

		// Token: 0x040004D4 RID: 1236
		public IKSolverTrigonometricTValle.TrigonometricBone bone2 = new IKSolverTrigonometricTValle.TrigonometricBone();

		// Token: 0x040004D5 RID: 1237
		public IKSolverTrigonometricTValle.TrigonometricBone bone3 = new IKSolverTrigonometricTValle.TrigonometricBone();

		// Token: 0x040004D6 RID: 1238
		protected Vector3 weightIKPosition;

		// Token: 0x040004D7 RID: 1239
		protected bool directHierarchy = true;

		// Token: 0x02000194 RID: 404
		[Serializable]
		public class TrigonometricBone : IKSolver.Bone
		{
			// Token: 0x06000C55 RID: 3157 RVA: 0x000374A0 File Offset: 0x000356A0
			public void Initiate(Vector3 childPosition, Vector3 bendNormal)
			{
				Quaternion quaternion = Quaternion.LookRotation(childPosition - this.transform.position, bendNormal);
				this.targetToLocalSpace = QuaTools.RotationToLocalSpace(this.transform.rotation, quaternion);
				this.defaultLocalBendNormal = Quaternion.Inverse(this.transform.rotation) * bendNormal;
			}

			// Token: 0x06000C56 RID: 3158 RVA: 0x000374F8 File Offset: 0x000356F8
			public Quaternion GetRotation(Vector3 direction, Vector3 bendNormal)
			{
				return Quaternion.LookRotation(direction, bendNormal) * this.targetToLocalSpace;
			}

			// Token: 0x06000C57 RID: 3159 RVA: 0x0003750C File Offset: 0x0003570C
			public Vector3 GetBendNormalFromCurrentRotation()
			{
				Vector3 vector = this.transform.rotation * this.defaultLocalBendNormal;
				bool flag = this.debugDraw;
				return vector;
			}

			// Token: 0x040008EF RID: 2287
			public bool debugDraw;

			// Token: 0x040008F0 RID: 2288
			public Quaternion targetToLocalSpace;

			// Token: 0x040008F1 RID: 2289
			public Vector3 defaultLocalBendNormal;
		}
	}
}
