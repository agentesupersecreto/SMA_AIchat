using System;
using com.ootii.Geometry;
using com.ootii.Timing;
using UnityEngine;

namespace com.ootii.Actors
{
	// Token: 0x0200008D RID: 141
	[AddComponentMenu("ootii/Actor Drivers/Move To Driver")]
	public class MoveToDriver : MonoBehaviour
	{
		// Token: 0x17000213 RID: 531
		// (get) Token: 0x060007DD RID: 2013 RVA: 0x0002AF2D File Offset: 0x0002912D
		// (set) Token: 0x060007DE RID: 2014 RVA: 0x0002AF35 File Offset: 0x00029135
		public bool IsEnabled
		{
			get
			{
				return this._IsEnabled;
			}
			set
			{
				this._IsEnabled = value;
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x060007DF RID: 2015 RVA: 0x0002AF3E File Offset: 0x0002913E
		// (set) Token: 0x060007E0 RID: 2016 RVA: 0x0002AF48 File Offset: 0x00029148
		public Transform Target
		{
			get
			{
				return this._Target;
			}
			set
			{
				this._Target = value;
				if (this._Target == null)
				{
					this.mHasArrived = false;
					this.mIsInSlowDistance = false;
					this.mIsTargetSet = false;
					this._TargetPosition = Vector3Ext.Null;
					this.mActorController.SetRelativeVelocity(Vector3.zero);
					return;
				}
				this.mIsTargetSet = true;
				this._TargetPosition = this._Target.position;
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x060007E1 RID: 2017 RVA: 0x0002AFB3 File Offset: 0x000291B3
		// (set) Token: 0x060007E2 RID: 2018 RVA: 0x0002AFBC File Offset: 0x000291BC
		public Vector3 TargetPosition
		{
			get
			{
				return this._TargetPosition;
			}
			set
			{
				this._Target = null;
				this._TargetPosition = value;
				if (this._TargetPosition == Vector3Ext.Null)
				{
					this.mHasArrived = false;
					this.mIsInSlowDistance = false;
					this.mIsTargetSet = false;
					this.mActorController.SetRelativeVelocity(Vector3.zero);
					return;
				}
				this.mIsTargetSet = true;
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x060007E3 RID: 2019 RVA: 0x0002B016 File Offset: 0x00029216
		// (set) Token: 0x060007E4 RID: 2020 RVA: 0x0002B01E File Offset: 0x0002921E
		public float FastSpeed
		{
			get
			{
				return this._FastSpeed;
			}
			set
			{
				this._FastSpeed = value;
			}
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x060007E5 RID: 2021 RVA: 0x0002B027 File Offset: 0x00029227
		// (set) Token: 0x060007E6 RID: 2022 RVA: 0x0002B02F File Offset: 0x0002922F
		public float SlowSpeed
		{
			get
			{
				return this._SlowSpeed;
			}
			set
			{
				this._SlowSpeed = value;
			}
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x060007E7 RID: 2023 RVA: 0x0002B038 File Offset: 0x00029238
		// (set) Token: 0x060007E8 RID: 2024 RVA: 0x0002B040 File Offset: 0x00029240
		public virtual float RotationSpeed
		{
			get
			{
				return this._RotationSpeed;
			}
			set
			{
				this._RotationSpeed = value;
				this.mDegreesPer60FPSTick = this._RotationSpeed / 60f;
			}
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x060007E9 RID: 2025 RVA: 0x0002B05B File Offset: 0x0002925B
		// (set) Token: 0x060007EA RID: 2026 RVA: 0x0002B063 File Offset: 0x00029263
		public float StopDistance
		{
			get
			{
				return this._StopDistance;
			}
			set
			{
				this._StopDistance = value;
			}
		}

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x060007EB RID: 2027 RVA: 0x0002B06C File Offset: 0x0002926C
		// (set) Token: 0x060007EC RID: 2028 RVA: 0x0002B074 File Offset: 0x00029274
		public float SlowDistance
		{
			get
			{
				return this._SlowDistance;
			}
			set
			{
				this._SlowDistance = value;
			}
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x060007ED RID: 2029 RVA: 0x0002B07D File Offset: 0x0002927D
		// (set) Token: 0x060007EE RID: 2030 RVA: 0x0002B085 File Offset: 0x00029285
		public bool ClearTargetOnStop
		{
			get
			{
				return this._ClearTargetOnStop;
			}
			set
			{
				this._ClearTargetOnStop = value;
			}
		}

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x060007EF RID: 2031 RVA: 0x0002B08E File Offset: 0x0002928E
		public bool IsTargetSet
		{
			get
			{
				return this.mIsTargetSet;
			}
		}

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x060007F0 RID: 2032 RVA: 0x0002B096 File Offset: 0x00029296
		public bool HasArrived
		{
			get
			{
				return this.mHasArrived;
			}
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x060007F1 RID: 2033 RVA: 0x0002B09E File Offset: 0x0002929E
		public bool IsInSlowDistance
		{
			get
			{
				return this.IsInSlowDistance;
			}
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x0002B0A6 File Offset: 0x000292A6
		protected void Awake()
		{
			this.mActorController = base.gameObject.GetComponent<ActorController>();
			this.mDegreesPer60FPSTick = this._RotationSpeed / 60f;
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x0002B0CB File Offset: 0x000292CB
		protected virtual void Start()
		{
			if (this._Target != null)
			{
				this.Target = this._Target;
				return;
			}
			if (this._TargetPosition.magnitude > 0f)
			{
				this.TargetPosition = this._TargetPosition;
			}
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x0002B108 File Offset: 0x00029308
		public void ClearTarget()
		{
			if (this._ClearTargetOnStop)
			{
				this._Target = null;
				this._TargetPosition = Vector3Ext.Null;
				this.mIsTargetSet = false;
			}
			this.mHasArrived = false;
			this.mIsInSlowDistance = false;
			this.mActorController.SetRelativeVelocity(Vector3.zero);
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x0002B154 File Offset: 0x00029354
		protected void Update()
		{
			if (!this._IsEnabled)
			{
				return;
			}
			if (!this.mIsTargetSet)
			{
				return;
			}
			if (this.mActorController == null)
			{
				return;
			}
			Vector3 zero = Vector3.zero;
			Quaternion identity = Quaternion.identity;
			if (this._Target != null)
			{
				this._TargetPosition = this._Target.position;
			}
			this.mTargetVector = this._TargetPosition - base.transform.position;
			this.mTargetDistance = this.mTargetVector.magnitude;
			if (this.mTargetDistance <= this._StopDistance)
			{
				this.ClearTarget();
				this.mHasArrived = true;
				this.OnArrived();
				return;
			}
			if (this._SlowDistance > 0f && this.mTargetDistance < this._SlowDistance)
			{
				if (!this.mIsInSlowDistance)
				{
					this.OnSlowDistanceEntered();
				}
				this.mIsInSlowDistance = true;
			}
			this.CalculateMove(this._TargetPosition, ref zero, ref identity);
			this.mActorController.Move(zero);
			this.mActorController.Rotate(identity);
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x0002B254 File Offset: 0x00029454
		protected virtual void CalculateMove(Vector3 rWaypoint, ref Vector3 rMove, ref Quaternion rRotate)
		{
			float smoothedDeltaTime = TimeManager.SmoothedDeltaTime;
			Vector3 vector = rWaypoint - base.transform.position;
			vector.Normalize();
			Vector3 vector2 = Vector3.Project(vector, base.transform.up);
			Vector3 vector3 = vector - vector2;
			float num = Vector3Ext.SignedAngle(base.transform.forward, vector3);
			if (this._RotationSpeed == 0f)
			{
				rRotate = Quaternion.AngleAxis(num, base.transform.up);
			}
			else
			{
				rRotate = Quaternion.AngleAxis(Mathf.Sign(num) * Mathf.Min(Mathf.Abs(num), this._RotationSpeed * smoothedDeltaTime), base.transform.up);
			}
			float num2 = this._FastSpeed;
			if (this.mIsInSlowDistance && this._SlowSpeed > 0f)
			{
				num2 = this._SlowSpeed;
			}
			Quaternion quaternion = base.transform.rotation * rRotate;
			rMove = quaternion.Forward() * (num2 * smoothedDeltaTime);
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x0002B359 File Offset: 0x00029559
		protected virtual void OnArrived()
		{
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x0002B35B File Offset: 0x0002955B
		protected virtual void OnSlowDistanceEntered()
		{
		}

		// Token: 0x04000407 RID: 1031
		public const float EPSILON = 0.01f;

		// Token: 0x04000408 RID: 1032
		public bool _IsEnabled = true;

		// Token: 0x04000409 RID: 1033
		public Transform _Target;

		// Token: 0x0400040A RID: 1034
		public Vector3 _TargetPosition = Vector3.zero;

		// Token: 0x0400040B RID: 1035
		public float _FastSpeed = 5f;

		// Token: 0x0400040C RID: 1036
		public float _SlowSpeed = 2f;

		// Token: 0x0400040D RID: 1037
		public float _RotationSpeed = 360f;

		// Token: 0x0400040E RID: 1038
		public float _StopDistance = 0.1f;

		// Token: 0x0400040F RID: 1039
		public float _SlowDistance = 1f;

		// Token: 0x04000410 RID: 1040
		public bool _ClearTargetOnStop = true;

		// Token: 0x04000411 RID: 1041
		protected bool mIsTargetSet;

		// Token: 0x04000412 RID: 1042
		protected bool mHasArrived;

		// Token: 0x04000413 RID: 1043
		protected bool mIsInSlowDistance;

		// Token: 0x04000414 RID: 1044
		protected Vector3 mTargetVector = Vector3.zero;

		// Token: 0x04000415 RID: 1045
		protected float mTargetDistance;

		// Token: 0x04000416 RID: 1046
		protected ActorController mActorController;

		// Token: 0x04000417 RID: 1047
		protected float mDegreesPer60FPSTick = 1f;
	}
}
