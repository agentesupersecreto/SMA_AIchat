using System;
using RootMotion;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.CustomIKs
{
	// Token: 0x020000BB RID: 187
	[Serializable]
	public sealed class IKSolverLimbTValle : IKSolverTrigonometricTValle
	{
		// Token: 0x060006E8 RID: 1768 RVA: 0x00021681 File Offset: 0x0001F881
		public void MaintainRotation()
		{
			if (!base.initiated)
			{
				return;
			}
			this.maintainRotation = this.bone3.transform.rotation;
			this.maintainRotationFor1Frame = true;
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x000216A9 File Offset: 0x0001F8A9
		public void MaintainBend()
		{
			if (!base.initiated)
			{
				return;
			}
			this.animationNormal = this.bone1.GetBendNormalFromCurrentRotation();
			this.maintainBendFor1Frame = true;
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x000216CC File Offset: 0x0001F8CC
		protected override void OnInitiateVirtual()
		{
			if (this.inicilizarBendNormalComoLocalDeBone2)
			{
				switch (this.bendModifier)
				{
				case IKSolverLimbTValle.BendModifier.Parent:
					this.bendNormal = this.bone2.transform.TransformDirection(this.bendNormal);
					goto IL_0060;
				}
				throw new ArgumentOutOfRangeException(this.bendModifier.ToString());
			}
			IL_0060:
			this.inicilizarBendNormalComoLocalDeBone2 = false;
			this.defaultRootRotation = this.root.rotation;
			if (this.bone1.transform.parent != null)
			{
				this.parentDefaultRotation = Quaternion.Inverse(this.defaultRootRotation) * this.bone1.transform.parent.rotation;
			}
			if (this.bone3.rotationLimit != null)
			{
				this.bone3.rotationLimit.Disable();
			}
			this.bone3DefaultRotation = this.bone3.transform.rotation;
			if (this.overrideBendNormal)
			{
				Vector3 vector = Vector3.Cross(this.bone2.transform.position - this.bone1.transform.position, this.bone3.transform.position - this.bone2.transform.position);
				if (vector != Vector3.zero)
				{
					this.bendNormal = vector;
				}
			}
			this.animationNormal = this.bendNormal;
			this.StoreAxisDirections(ref this.axisDirectionsLeft);
			this.StoreAxisDirections(ref this.axisDirectionsRight);
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x00021860 File Offset: 0x0001FA60
		protected override void OnUpdateVirtual()
		{
			this.inicilizarBendNormalComoLocalDeBone2 = false;
			if (this.IKPositionWeight > 0f)
			{
				this.bendModifierWeight = Mathf.Clamp(this.bendModifierWeight, 0f, 1f);
				this.maintainRotationWeight = Mathf.Clamp(this.maintainRotationWeight, 0f, 1f);
				this._bendNormal = this.bendNormal;
				this.bendNormal = this.GetModifiedBendNormal();
			}
			if (this.maintainRotationWeight * this.IKPositionWeight > 0f)
			{
				this.bone3RotationBeforeSolve = (this.maintainRotationFor1Frame ? this.maintainRotation : this.bone3.transform.rotation);
				this.maintainRotationFor1Frame = false;
			}
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x00021910 File Offset: 0x0001FB10
		protected override void OnPostSolveVirtual()
		{
			if (this.IKPositionWeight > 0f)
			{
				this.bendNormal = this._bendNormal;
			}
			if (this.maintainRotationWeight * this.IKPositionWeight > 0f)
			{
				this.bone3.transform.rotation = Quaternion.Slerp(this.bone3.transform.rotation, this.bone3RotationBeforeSolve, this.maintainRotationWeight * this.IKPositionWeight);
			}
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x00021982 File Offset: 0x0001FB82
		public IKSolverLimbTValle()
		{
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x000219AD File Offset: 0x0001FBAD
		public IKSolverLimbTValle(AvatarIKGoal goal)
		{
			this.goal = goal;
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060006EF RID: 1775 RVA: 0x000219DF File Offset: 0x0001FBDF
		private IKSolverLimbTValle.AxisDirection[] axisDirections
		{
			get
			{
				if (this.goal == AvatarIKGoal.LeftHand)
				{
					return this.axisDirectionsLeft;
				}
				return this.axisDirectionsRight;
			}
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x000219F8 File Offset: 0x0001FBF8
		private void StoreAxisDirections(ref IKSolverLimbTValle.AxisDirection[] axisDirections)
		{
			axisDirections[0] = new IKSolverLimbTValle.AxisDirection(Vector3.zero, new Vector3(-1f, 0f, 0f));
			axisDirections[1] = new IKSolverLimbTValle.AxisDirection(new Vector3(0.5f, 0f, -0.2f), new Vector3(-0.5f, -1f, 1f));
			axisDirections[2] = new IKSolverLimbTValle.AxisDirection(new Vector3(-0.5f, -1f, -0.2f), new Vector3(0f, 0.5f, -1f));
			axisDirections[3] = new IKSolverLimbTValle.AxisDirection(new Vector3(-0.5f, -0.5f, 1f), new Vector3(-1f, -1f, -1f));
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x00021ACC File Offset: 0x0001FCCC
		private Vector3 GetModifiedBendNormal()
		{
			float num = this.bendModifierWeight;
			if (num <= 0f)
			{
				return this.bendNormal;
			}
			switch (this.bendModifier)
			{
			case IKSolverLimbTValle.BendModifier.Animation:
				if (!this.maintainBendFor1Frame)
				{
					this.MaintainBend();
				}
				this.maintainBendFor1Frame = false;
				return Vector3.Lerp(this.bendNormal, this.animationNormal, num);
			case IKSolverLimbTValle.BendModifier.Target:
			{
				Quaternion quaternion = this.IKRotation * Quaternion.Inverse(this.bone3DefaultRotation);
				return Quaternion.Slerp(Quaternion.identity, quaternion, num) * this.bendNormal;
			}
			case IKSolverLimbTValle.BendModifier.Parent:
			{
				if (this.bone1.transform.parent == null)
				{
					return this.bendNormal;
				}
				Quaternion quaternion2 = this.bone1.transform.parent.rotation * Quaternion.Inverse(this.parentDefaultRotation);
				return Quaternion.Slerp(Quaternion.identity, quaternion2 * Quaternion.Inverse(this.defaultRootRotation), num) * this.bendNormal;
			}
			case IKSolverLimbTValle.BendModifier.Arm:
			{
				if (this.bone1.transform.parent == null)
				{
					return this.bendNormal;
				}
				if (this.goal == AvatarIKGoal.LeftFoot || this.goal == AvatarIKGoal.RightFoot)
				{
					if (!Warning.logged)
					{
						base.LogWarning("Trying to use the 'Arm' bend modifier on a leg.");
					}
					return this.bendNormal;
				}
				Vector3 vector = (this.IKPosition - this.bone1.transform.position).normalized;
				vector = Quaternion.Inverse(this.bone1.transform.parent.rotation * Quaternion.Inverse(this.parentDefaultRotation)) * vector;
				if (this.goal == AvatarIKGoal.LeftHand)
				{
					vector.x = -vector.x;
				}
				for (int i = 1; i < this.axisDirections.Length; i++)
				{
					this.axisDirections[i].dot = Mathf.Clamp(Vector3.Dot(this.axisDirections[i].direction, vector), 0f, 1f);
					this.axisDirections[i].dot = Interp.Float(this.axisDirections[i].dot, InterpolationMode.InOutQuintic);
				}
				Vector3 vector2 = this.axisDirections[0].axis;
				for (int j = 1; j < this.axisDirections.Length; j++)
				{
					vector2 = Vector3.Slerp(vector2, this.axisDirections[j].axis, this.axisDirections[j].dot);
				}
				if (this.goal == AvatarIKGoal.LeftHand)
				{
					vector2.x = -vector2.x;
					vector2 = -vector2;
				}
				Vector3 vector3 = this.bone1.transform.parent.rotation * Quaternion.Inverse(this.parentDefaultRotation) * vector2;
				if (num >= 1f)
				{
					return vector3;
				}
				return Vector3.Lerp(this.bendNormal, vector3, num);
			}
			case IKSolverLimbTValle.BendModifier.Goal:
			{
				if (this.bendGoal == null)
				{
					if (!Warning.logged)
					{
						base.LogWarning("Trying to use the 'Goal' Bend Modifier, but the Bend Goal is unassigned.");
					}
					return this.bendNormal;
				}
				Vector3 vector4 = Vector3.Cross(this.bendGoal.position - this.bone1.transform.position, this.IKPosition - this.bone1.transform.position);
				if (vector4 == Vector3.zero)
				{
					return this.bendNormal;
				}
				if (num >= 1f)
				{
					return vector4;
				}
				return Vector3.Lerp(this.bendNormal, vector4, num);
			}
			default:
				return this.bendNormal;
			}
		}

		// Token: 0x040004BA RID: 1210
		public bool inicilizarBendNormalComoLocalDeBone2;

		// Token: 0x040004BB RID: 1211
		public AvatarIKGoal goal;

		// Token: 0x040004BC RID: 1212
		public IKSolverLimbTValle.BendModifier bendModifier;

		// Token: 0x040004BD RID: 1213
		[Range(0f, 1f)]
		public float maintainRotationWeight;

		// Token: 0x040004BE RID: 1214
		[Range(0f, 1f)]
		public float bendModifierWeight = 1f;

		// Token: 0x040004BF RID: 1215
		public Transform bendGoal;

		// Token: 0x040004C0 RID: 1216
		private bool maintainBendFor1Frame;

		// Token: 0x040004C1 RID: 1217
		private bool maintainRotationFor1Frame;

		// Token: 0x040004C2 RID: 1218
		private Quaternion defaultRootRotation;

		// Token: 0x040004C3 RID: 1219
		private Quaternion parentDefaultRotation;

		// Token: 0x040004C4 RID: 1220
		private Quaternion bone3RotationBeforeSolve;

		// Token: 0x040004C5 RID: 1221
		private Quaternion maintainRotation;

		// Token: 0x040004C6 RID: 1222
		private Quaternion bone3DefaultRotation;

		// Token: 0x040004C7 RID: 1223
		private Vector3 _bendNormal;

		// Token: 0x040004C8 RID: 1224
		private Vector3 animationNormal;

		// Token: 0x040004C9 RID: 1225
		private IKSolverLimbTValle.AxisDirection[] axisDirectionsLeft = new IKSolverLimbTValle.AxisDirection[4];

		// Token: 0x040004CA RID: 1226
		private IKSolverLimbTValle.AxisDirection[] axisDirectionsRight = new IKSolverLimbTValle.AxisDirection[4];

		// Token: 0x02000192 RID: 402
		[Serializable]
		public enum BendModifier
		{
			// Token: 0x040008E7 RID: 2279
			Animation,
			// Token: 0x040008E8 RID: 2280
			Target,
			// Token: 0x040008E9 RID: 2281
			Parent,
			// Token: 0x040008EA RID: 2282
			Arm,
			// Token: 0x040008EB RID: 2283
			Goal
		}

		// Token: 0x02000193 RID: 403
		[Serializable]
		public struct AxisDirection
		{
			// Token: 0x06000C54 RID: 3156 RVA: 0x00037476 File Offset: 0x00035676
			public AxisDirection(Vector3 direction, Vector3 axis)
			{
				this.direction = direction.normalized;
				this.axis = axis.normalized;
				this.dot = 0f;
			}

			// Token: 0x040008EC RID: 2284
			public Vector3 direction;

			// Token: 0x040008ED RID: 2285
			public Vector3 axis;

			// Token: 0x040008EE RID: 2286
			public float dot;
		}
	}
}
