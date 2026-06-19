using System;
using com.ootii.Base;
using com.ootii.Geometry;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x02000079 RID: 121
	[BaseName("Spline Motor")]
	[BaseDescription("Rig Motor will follow along a spline and look at a target or forward.")]
	public class SplineMotor : CameraMotor
	{
		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060005AF RID: 1455 RVA: 0x00020B08 File Offset: 0x0001ED08
		// (set) Token: 0x060005B0 RID: 1456 RVA: 0x00020B10 File Offset: 0x0001ED10
		public bool UseAnchor
		{
			get
			{
				return this._UseAnchor;
			}
			set
			{
				this._UseAnchor = value;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060005B1 RID: 1457 RVA: 0x00020B19 File Offset: 0x0001ED19
		// (set) Token: 0x060005B2 RID: 1458 RVA: 0x00020B24 File Offset: 0x0001ED24
		public virtual int PathOwnerIndex
		{
			get
			{
				return this._PathOwnerIndex;
			}
			set
			{
				this._PathOwnerIndex = value;
				if (this._PathOwnerIndex >= 0 && this.RigController != null && this._PathOwnerIndex < this.RigController.StoredTransforms.Count)
				{
					this._PathOwner = this.RigController.StoredTransforms[this._PathOwnerIndex];
				}
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060005B3 RID: 1459 RVA: 0x00020B83 File Offset: 0x0001ED83
		// (set) Token: 0x060005B4 RID: 1460 RVA: 0x00020B8C File Offset: 0x0001ED8C
		public virtual Transform PathOwner
		{
			get
			{
				return this._PathOwner;
			}
			set
			{
				this._PathOwner = value;
				if (this.RigController != null)
				{
					if (this._PathOwner == null)
					{
						if (this._PathOwnerIndex >= 0 && this._PathOwnerIndex < this.RigController.StoredTransforms.Count)
						{
							this.RigController.StoredTransforms[this._PathOwnerIndex] = null;
							if (this._PathOwnerIndex == this.RigController.StoredTransforms.Count - 1)
							{
								this.RigController.StoredTransforms.RemoveAt(this._PathOwnerIndex);
								this._PathOwnerIndex = -1;
							}
						}
						this.mPath = null;
						this.mPathLength = 0f;
						return;
					}
					if (this._PathOwnerIndex == -1)
					{
						this._PathOwnerIndex = this.RigController.StoredTransforms.Count;
						this.RigController.StoredTransforms.Add(null);
					}
					this.RigController.StoredTransforms[this._PathOwnerIndex] = this._PathOwner;
					this.mPath = this._PathOwner.gameObject.GetComponent<BezierSpline>();
					this.mPathLength = ((this.mPath != null) ? this.mPath.Length : 0f);
				}
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060005B5 RID: 1461 RVA: 0x00020CCC File Offset: 0x0001EECC
		public float PathLength
		{
			get
			{
				return this.mPathLength;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060005B6 RID: 1462 RVA: 0x00020CD4 File Offset: 0x0001EED4
		// (set) Token: 0x060005B7 RID: 1463 RVA: 0x00020CDC File Offset: 0x0001EEDC
		public AnimationCurve Speed
		{
			get
			{
				return this._Speed;
			}
			set
			{
				this._Speed = value;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060005B8 RID: 1464 RVA: 0x00020CE5 File Offset: 0x0001EEE5
		// (set) Token: 0x060005B9 RID: 1465 RVA: 0x00020CED File Offset: 0x0001EEED
		public bool Loop
		{
			get
			{
				return this._Loop;
			}
			set
			{
				this._Loop = value;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060005BA RID: 1466 RVA: 0x00020CF6 File Offset: 0x0001EEF6
		// (set) Token: 0x060005BB RID: 1467 RVA: 0x00020CFE File Offset: 0x0001EEFE
		public bool RotateToMovementDirection
		{
			get
			{
				return this._RotateToMovementDirection;
			}
			set
			{
				this._RotateToMovementDirection = value;
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060005BC RID: 1468 RVA: 0x00020D07 File Offset: 0x0001EF07
		// (set) Token: 0x060005BD RID: 1469 RVA: 0x00020D0F File Offset: 0x0001EF0F
		public bool RotateToAnchor
		{
			get
			{
				return this._RotateToAnchor;
			}
			set
			{
				this._RotateToAnchor = value;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060005BE RID: 1470 RVA: 0x00020D18 File Offset: 0x0001EF18
		// (set) Token: 0x060005BF RID: 1471 RVA: 0x00020D20 File Offset: 0x0001EF20
		public bool ActivateMotorOnComplete
		{
			get
			{
				return this._ActivateMotorOnComplete;
			}
			set
			{
				this._ActivateMotorOnComplete = value;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060005C0 RID: 1472 RVA: 0x00020D29 File Offset: 0x0001EF29
		// (set) Token: 0x060005C1 RID: 1473 RVA: 0x00020D31 File Offset: 0x0001EF31
		public int EndMotorIndex
		{
			get
			{
				return this._EndMotorIndex;
			}
			set
			{
				this._EndMotorIndex = value;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060005C2 RID: 1474 RVA: 0x00020D3A File Offset: 0x0001EF3A
		// (set) Token: 0x060005C3 RID: 1475 RVA: 0x00020D42 File Offset: 0x0001EF42
		public float DistanceTravelled
		{
			get
			{
				return this.mDistanceTravelled;
			}
			set
			{
				this.mDistanceTravelled = value;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060005C4 RID: 1476 RVA: 0x00020D4B File Offset: 0x0001EF4B
		// (set) Token: 0x060005C5 RID: 1477 RVA: 0x00020D6D File Offset: 0x0001EF6D
		public float DistanceTravelledNormalized
		{
			get
			{
				if (this.mPathLength == 0f)
				{
					return 0f;
				}
				return this.mDistanceTravelled / this.mPathLength;
			}
			set
			{
				this.mDistanceTravelled = this.mPathLength * value;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060005C6 RID: 1478 RVA: 0x00020D7D File Offset: 0x0001EF7D
		// (set) Token: 0x060005C7 RID: 1479 RVA: 0x00020D85 File Offset: 0x0001EF85
		public bool AutoStart
		{
			get
			{
				return this.mAutoStart;
			}
			set
			{
				this.mAutoStart = value;
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060005C8 RID: 1480 RVA: 0x00020D8E File Offset: 0x0001EF8E
		// (set) Token: 0x060005C9 RID: 1481 RVA: 0x00020D96 File Offset: 0x0001EF96
		public bool IsPaused
		{
			get
			{
				return this.mIsPaused;
			}
			set
			{
				this.mIsPaused = value;
			}
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x00020DA0 File Offset: 0x0001EFA0
		public override void Awake()
		{
			base.Awake();
			if (this.PathOwner != null)
			{
				this.mPath = this.PathOwner.gameObject.GetComponent<BezierSpline>();
				this.mPathLength = ((this.mPath != null) ? this.mPath.Length : 0f);
			}
			if (Application.isPlaying && this.Anchor == null)
			{
				this.mRigTransform.Position = this.RigController._Transform.position;
				this.mRigTransform.Rotation = this.RigController._Transform.rotation;
			}
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x00020E48 File Offset: 0x0001F048
		public void Start(float rNormalizedDistance = 0f)
		{
			this.mHasStarted = true;
			this.mIsPaused = false;
			if (this.mPath != null)
			{
				this.mDistanceTravelled = rNormalizedDistance * this.mPathLength;
				Vector3 point = this.mPath.GetPoint(rNormalizedDistance);
				if (this.mLastPosition == Vector3.zero)
				{
					this.mLastPosition = point;
				}
				this.mRigTransform.Position = point;
			}
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x00020EB1 File Offset: 0x0001F0B1
		public void Stop()
		{
			this.mHasStarted = false;
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x00020EBA File Offset: 0x0001F0BA
		public override void Activate(CameraMotor rOldMotor)
		{
			base.Activate(rOldMotor);
			if (this.mAutoStart)
			{
				this.Start(0f);
			}
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x00020ED8 File Offset: 0x0001F0D8
		public override CameraTransform RigLateUpdate(float rDeltaTime, int rUpdateIndex, float rTiltAngle = 0f)
		{
			if (this.mPath == null)
			{
				return this.mRigTransform;
			}
			if (this.RigController == null)
			{
				return this.mRigTransform;
			}
			bool flag = false;
			if (this.mHasStarted && !this.mIsPaused)
			{
				float num = this._Speed.Evaluate(this.DistanceTravelledNormalized);
				this.mDistanceTravelled += num * rDeltaTime;
			}
			if (this.mDistanceTravelled >= this.mPathLength)
			{
				if (this._Loop)
				{
					this.mDistanceTravelled -= this.mPathLength;
				}
				else
				{
					this.mDistanceTravelled = this.mPathLength;
				}
				flag = true;
			}
			float num2 = this.mDistanceTravelled / this.mPathLength;
			Vector3 point = this.mPath.GetPoint(num2);
			if (this.mLastPosition == Vector3.zero)
			{
				this.mLastPosition = point;
			}
			this.mRigTransform.Position = point;
			if (this._RotateToAnchor)
			{
				this.mRigTransform.Rotation = Quaternion.LookRotation(this.AnchorPosition - point, Vector3.up);
			}
			else if (this._RotateToMovementDirection && (point - this.mLastPosition).sqrMagnitude != 0f)
			{
				this.mRigTransform.Rotation = Quaternion.LookRotation(point - this.mLastPosition, Vector3.up);
			}
			this.mLastPosition = point;
			if (flag && this.mHasStarted)
			{
				if (this._ActivateMotorOnComplete && this._EndMotorIndex >= 0 && this._EndMotorIndex < this.RigController.Motors.Count)
				{
					this.RigController.ActivateMotor(this._EndMotorIndex);
				}
				if (this.RigController.MotorArrived != null)
				{
					this.RigController.MotorArrived(this);
				}
				if (!this._Loop)
				{
					this.mHasStarted = false;
				}
			}
			return this.mRigTransform;
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x000210AC File Offset: 0x0001F2AC
		public override void DeserializeMotor(string rDefinition)
		{
			base.DeserializeMotor(rDefinition);
			if (this._PathOwnerIndex >= 0)
			{
				if (this._PathOwnerIndex < this.RigController.StoredTransforms.Count)
				{
					this._PathOwner = this.RigController.StoredTransforms[this._PathOwnerIndex];
				}
				else
				{
					this._PathOwner = null;
					this._PathOwnerIndex = -1;
				}
			}
			if (this._PathOwner != null)
			{
				this.mPath = this._PathOwner.gameObject.GetComponent<BezierSpline>();
				this.mPathLength = ((this.mPath != null) ? this.mPath.Length : 0f);
			}
			this._IsCollisionEnabled = false;
		}

		// Token: 0x040002C3 RID: 707
		public bool _UseAnchor = true;

		// Token: 0x040002C4 RID: 708
		public int _PathOwnerIndex = -1;

		// Token: 0x040002C5 RID: 709
		[NonSerialized]
		public Transform _PathOwner;

		// Token: 0x040002C6 RID: 710
		private float mPathLength;

		// Token: 0x040002C7 RID: 711
		public AnimationCurve _Speed = AnimationCurve.Linear(0f, 5f, 1f, 5f);

		// Token: 0x040002C8 RID: 712
		public bool _Loop;

		// Token: 0x040002C9 RID: 713
		public bool _RotateToMovementDirection;

		// Token: 0x040002CA RID: 714
		public bool _RotateToAnchor;

		// Token: 0x040002CB RID: 715
		public bool _ActivateMotorOnComplete;

		// Token: 0x040002CC RID: 716
		public int _EndMotorIndex;

		// Token: 0x040002CD RID: 717
		public float mDistanceTravelled;

		// Token: 0x040002CE RID: 718
		public bool mAutoStart = true;

		// Token: 0x040002CF RID: 719
		private bool mHasStarted;

		// Token: 0x040002D0 RID: 720
		private bool mIsPaused;

		// Token: 0x040002D1 RID: 721
		private Vector3 mLastPosition = Vector3.zero;

		// Token: 0x040002D2 RID: 722
		protected BezierSpline mPath;
	}
}
