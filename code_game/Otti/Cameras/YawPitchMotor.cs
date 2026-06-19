using System;
using com.ootii.Geometry;
using com.ootii.Input;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x0200007D RID: 125
	public abstract class YawPitchMotor : CameraMotor
	{
		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000637 RID: 1591 RVA: 0x00022BC1 File Offset: 0x00020DC1
		// (set) Token: 0x06000638 RID: 1592 RVA: 0x00022BC9 File Offset: 0x00020DC9
		public override float MaxDistance
		{
			get
			{
				return this._MaxDistance;
			}
			set
			{
				this._MaxDistance = value;
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000639 RID: 1593 RVA: 0x00022BD2 File Offset: 0x00020DD2
		// (set) Token: 0x0600063A RID: 1594 RVA: 0x00022BDA File Offset: 0x00020DDA
		public override float Distance
		{
			get
			{
				return this.mDistance;
			}
			set
			{
				this.mDistance = value;
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x0600063B RID: 1595 RVA: 0x00022BE3 File Offset: 0x00020DE3
		// (set) Token: 0x0600063C RID: 1596 RVA: 0x00022BEB File Offset: 0x00020DEB
		public virtual bool IsYawEnabled
		{
			get
			{
				return this._IsYawEnabled;
			}
			set
			{
				this._IsYawEnabled = value;
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x0600063D RID: 1597 RVA: 0x00022BF4 File Offset: 0x00020DF4
		public virtual float LocalYaw
		{
			get
			{
				Transform anchor = this.Anchor;
				float num;
				if (anchor == null)
				{
					num = this.RigController._Transform.rotation.eulerAngles.y;
				}
				else
				{
					num = (Quaternion.Inverse(anchor.rotation) * this.RigController._Transform.rotation).eulerAngles.y;
				}
				if (num > 180f)
				{
					num -= 360f;
				}
				else if (num < -180f)
				{
					num += 360f;
				}
				return num;
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x0600063E RID: 1598 RVA: 0x00022C88 File Offset: 0x00020E88
		// (set) Token: 0x0600063F RID: 1599 RVA: 0x00022C90 File Offset: 0x00020E90
		public virtual float MinYaw
		{
			get
			{
				return this._MinYaw;
			}
			set
			{
				this._MinYaw = value;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000640 RID: 1600 RVA: 0x00022C99 File Offset: 0x00020E99
		// (set) Token: 0x06000641 RID: 1601 RVA: 0x00022CA1 File Offset: 0x00020EA1
		public virtual float MaxYaw
		{
			get
			{
				return this._MaxYaw;
			}
			set
			{
				this._MaxYaw = value;
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000642 RID: 1602 RVA: 0x00022CAA File Offset: 0x00020EAA
		// (set) Token: 0x06000643 RID: 1603 RVA: 0x00022CB2 File Offset: 0x00020EB2
		public virtual float YawSpeed
		{
			get
			{
				return this._YawSpeed;
			}
			set
			{
				this._YawSpeed = value;
				this.mDegreesYPer60FPSTick = this._YawSpeed / 60f;
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000644 RID: 1604 RVA: 0x00022CCD File Offset: 0x00020ECD
		// (set) Token: 0x06000645 RID: 1605 RVA: 0x00022CD5 File Offset: 0x00020ED5
		public float TargetRotationMultiplier
		{
			get
			{
				return this._TargetRotationMultiplier;
			}
			set
			{
				this._TargetRotationMultiplier = value;
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000646 RID: 1606 RVA: 0x00022CDE File Offset: 0x00020EDE
		// (set) Token: 0x06000647 RID: 1607 RVA: 0x00022CE6 File Offset: 0x00020EE6
		public virtual bool IsPitchEnabled
		{
			get
			{
				return this._IsPitchEnabled;
			}
			set
			{
				this._IsPitchEnabled = value;
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000648 RID: 1608 RVA: 0x00022CEF File Offset: 0x00020EEF
		// (set) Token: 0x06000649 RID: 1609 RVA: 0x00022CF7 File Offset: 0x00020EF7
		public virtual bool InvertPitch
		{
			get
			{
				return this._InvertPitch;
			}
			set
			{
				this._InvertPitch = value;
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x0600064A RID: 1610 RVA: 0x00022D00 File Offset: 0x00020F00
		public virtual float LocalPitch
		{
			get
			{
				Transform anchor = this.Anchor;
				float num;
				if (anchor == null)
				{
					num = this.RigController._Transform.rotation.eulerAngles.x;
				}
				else
				{
					num = (Quaternion.Inverse(anchor.rotation) * this.RigController._Transform.rotation).eulerAngles.x;
				}
				if (num > 180f)
				{
					num -= 360f;
				}
				else if (num < -180f)
				{
					num += 360f;
				}
				return num;
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x0600064B RID: 1611 RVA: 0x00022D94 File Offset: 0x00020F94
		// (set) Token: 0x0600064C RID: 1612 RVA: 0x00022D9C File Offset: 0x00020F9C
		public virtual float MinPitch
		{
			get
			{
				return this._MinPitch;
			}
			set
			{
				this._MinPitch = Mathf.Max(value, -87.4f);
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x0600064D RID: 1613 RVA: 0x00022DAF File Offset: 0x00020FAF
		// (set) Token: 0x0600064E RID: 1614 RVA: 0x00022DB7 File Offset: 0x00020FB7
		public virtual float MaxPitch
		{
			get
			{
				return this._MaxPitch;
			}
			set
			{
				this._MaxPitch = Mathf.Min(value, 87.4f);
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x0600064F RID: 1615 RVA: 0x00022DCA File Offset: 0x00020FCA
		// (set) Token: 0x06000650 RID: 1616 RVA: 0x00022DD2 File Offset: 0x00020FD2
		public virtual float PitchSpeed
		{
			get
			{
				return this._PitchSpeed;
			}
			set
			{
				this._PitchSpeed = value;
				this.mDegreesXPer60FPSTick = this._PitchSpeed / 60f;
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000651 RID: 1617 RVA: 0x00022DED File Offset: 0x00020FED
		// (set) Token: 0x06000652 RID: 1618 RVA: 0x00022DF5 File Offset: 0x00020FF5
		public float Smoothing
		{
			get
			{
				return this._Smoothing;
			}
			set
			{
				this._Smoothing = value;
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000653 RID: 1619 RVA: 0x00022DFE File Offset: 0x00020FFE
		public Vector3 Euler
		{
			get
			{
				return this._Euler;
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000654 RID: 1620 RVA: 0x00022E06 File Offset: 0x00021006
		public Vector3 EulerTarget
		{
			get
			{
				return this._EulerTarget;
			}
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x00022E10 File Offset: 0x00021010
		public override void Awake()
		{
			base.Awake();
			this.mDistance = this._MaxDistance;
			this.mDegreesYPer60FPSTick = this._YawSpeed / 60f;
			this.mDegreesXPer60FPSTick = this._PitchSpeed / 60f;
			if (Application.isPlaying)
			{
				Transform anchor = this.Anchor;
				Transform transform = this.RigController.Transform;
				if (anchor != null)
				{
					this.mAnchorLastPosition = anchor.position;
					this.mAnchorLastRotation = anchor.rotation;
				}
				this._Euler = transform.eulerAngles;
				base.NormalizeEuler(ref this._Euler);
				this._EulerTarget = this._Euler;
				this.mFocusLastPosition = this.GetFocusPosition(transform.rotation);
			}
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x00022EC4 File Offset: 0x000210C4
		public override bool Initialize()
		{
			Transform anchor = this.Anchor;
			Transform transform = this.RigController.transform;
			if (anchor != null)
			{
				this.mAnchorLastPosition = anchor.position;
				this.mAnchorLastRotation = anchor.rotation;
			}
			this._Euler = transform.eulerAngles;
			base.NormalizeEuler(ref this._Euler);
			this._EulerTarget = this._Euler;
			this.mFocusLastPosition = this.GetFocusPosition(transform.rotation);
			return base.Initialize();
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x00022F41 File Offset: 0x00021141
		public void ClearTargetYawPitch()
		{
			this.mTargetYaw = float.MaxValue;
			this.mTargetPitch = float.MaxValue;
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x00022F5C File Offset: 0x0002115C
		public void SetTargetYawPitch(float rYaw, float rPitch, float rSpeed = -1f, bool rAutoClearTarget = true)
		{
			this.ClearTargetForward();
			this.mTargetYaw = rYaw;
			this.mTargetPitch = rPitch;
			this.mAutoClearTarget = rAutoClearTarget;
			float num = Mathf.Abs(this.mTargetYaw - this.LocalYaw);
			float num2 = Mathf.Abs(this.mTargetPitch - this.LocalPitch);
			if (rSpeed > 0f)
			{
				float num3 = ((num >= num2) ? (num / rSpeed) : (num2 / rSpeed));
				if (num3 > 0f)
				{
					this.mTargetYawSpeed = num / num3;
					this.mTargetPitchSpeed = num2 / num3;
					return;
				}
			}
			else
			{
				if (rSpeed == 0f)
				{
					this.mTargetYawSpeed = 0f;
					this.mTargetPitchSpeed = 0f;
					return;
				}
				float num4 = 1f;
				if (this.mWasAnchorRotating)
				{
					num4 = this._TargetRotationMultiplier;
				}
				else if (this.Anchor != null && !QuaternionExt.IsEqual(this.mAnchorLastRotation, this.Anchor.rotation))
				{
					num4 = this._TargetRotationMultiplier;
				}
				this.mTargetYawSpeed = this._YawSpeed * num4;
				this.mTargetPitchSpeed = this._PitchSpeed * num4;
			}
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0002305D File Offset: 0x0002125D
		public void ClearTargetForward()
		{
			this.mTargetForward = Vector3.zero;
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x0002306C File Offset: 0x0002126C
		public void SetTargetForward(Vector3 rForward, float rSpeed = -1f, bool rAutoClearTarget = true)
		{
			if (rForward.sqrMagnitude == 0f)
			{
				return;
			}
			if (this.Anchor == null)
			{
				return;
			}
			this.ClearTargetYawPitch();
			this.mTargetForward = rForward;
			this.mAutoClearTarget = rAutoClearTarget;
			Quaternion quaternion = Quaternion.LookRotation(this.mTargetForward, this.Anchor.up);
			Quaternion quaternion2 = Quaternion.Inverse(this.Anchor.rotation) * this.RigController._Transform.rotation;
			Quaternion quaternion3 = Quaternion.Inverse(this.Anchor.rotation) * quaternion;
			float num = Mathf.Abs(quaternion3.eulerAngles.y - quaternion2.eulerAngles.y);
			float num2 = Mathf.Abs(quaternion3.eulerAngles.x - quaternion2.eulerAngles.x);
			if (rSpeed > 0f)
			{
				float num3 = ((num >= num2) ? (num / rSpeed) : (num2 / rSpeed));
				if (num3 > 0f)
				{
					this.mTargetYawSpeed = num / num3;
					this.mTargetPitchSpeed = num2 / num3;
					return;
				}
			}
			else
			{
				if (rSpeed == 0f)
				{
					this.mTargetYawSpeed = 0f;
					this.mTargetPitchSpeed = 0f;
					return;
				}
				this.mTargetYawSpeed = this._YawSpeed;
				this.mTargetPitchSpeed = this._PitchSpeed;
			}
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x000231AC File Offset: 0x000213AC
		public virtual Vector3 GetFrameEuler(bool rUseYawLimits, bool rUsePitchLimits = true)
		{
			Vector3 zero = Vector3.zero;
			if (this.RigController.LastPosition != this.RigController._Transform.position)
			{
				this.mFocusLastPosition = this.GetFocusPosition(this.RigController._Transform.rotation);
			}
			if (this.mTargetForward.sqrMagnitude > 0f)
			{
				Quaternion quaternion = Quaternion.LookRotation(this.mTargetForward, this.Anchor.up);
				Quaternion quaternion2 = Quaternion.Inverse(this.Anchor.rotation) * this.RigController._Transform.rotation;
				Quaternion quaternion3 = Quaternion.Inverse(this.Anchor.rotation) * quaternion;
				float num = quaternion3.eulerAngles.y - quaternion2.eulerAngles.y;
				if (num > 180f)
				{
					num -= 360f;
				}
				else if (num < -180f)
				{
					num += 360f;
				}
				float num2 = quaternion3.eulerAngles.x - quaternion2.eulerAngles.x;
				if (num2 > 180f)
				{
					num2 -= 360f;
				}
				else if (num2 < -180f)
				{
					num2 += 360f;
				}
				if (this.mTargetYawSpeed <= 0f)
				{
					zero.y = num;
				}
				else
				{
					zero.y = Mathf.Sign(num) * Mathf.Min(this.mTargetYawSpeed * Time.deltaTime, Mathf.Abs(num));
				}
				if (this.mTargetPitchSpeed <= 0f)
				{
					zero.x = num2;
				}
				else
				{
					zero.x = Mathf.Sign(num2) * Mathf.Min(this.mTargetPitchSpeed * Time.deltaTime, Mathf.Abs(num2));
				}
				if (Mathf.Abs(zero.y) < 0.0001f && Mathf.Abs(zero.x) < 0.0001f)
				{
					this._Euler.y = this.LocalYaw;
					this._Euler.x = this.LocalPitch;
					this._EulerTarget = this._Euler;
					if (this.mAutoClearTarget)
					{
						this.mTargetForward = Vector3.zero;
					}
				}
			}
			else if (this.mTargetYaw < 3.4028235E+38f || this.mTargetPitch < 3.4028235E+38f)
			{
				if (this.mTargetYaw < 3.4028235E+38f)
				{
					float num3 = this.mTargetYaw - this.LocalYaw;
					if (this.mTargetYawSpeed <= 0f)
					{
						zero.y = num3;
					}
					else
					{
						zero.y = Mathf.Sign(num3) * Mathf.Min(this.mTargetYawSpeed * Time.deltaTime, Mathf.Abs(num3));
					}
					Transform anchor = this.Anchor;
					float num4 = this.mAnchorLastRotation.Forward().HorizontalAngleTo(anchor.forward, anchor.up);
					if (Mathf.Abs(zero.y) - Mathf.Abs(num4 * 2f) < 0.0001f)
					{
						this._Euler.y = this.mTargetYaw;
						this._EulerTarget.y = this.mTargetYaw;
					}
					if (this.mAutoClearTarget && Mathf.Abs(num3) < 0.0001f)
					{
						this.mTargetYaw = float.MaxValue;
					}
				}
				if (this.mTargetPitch < 3.4028235E+38f)
				{
					float num5 = this.mTargetPitch - this.LocalPitch;
					if (this.mTargetPitchSpeed <= 0f)
					{
						zero.x = num5;
					}
					else
					{
						zero.x = Mathf.Sign(num5) * Mathf.Min(this.mTargetPitchSpeed * Time.deltaTime, Mathf.Abs(num5));
					}
					if (Mathf.Abs(zero.x) < 0.0001f)
					{
						this._Euler.x = this.mTargetPitch;
						this._EulerTarget.x = this.mTargetPitch;
					}
					if (this.mAutoClearTarget && Mathf.Abs(num5) < 0.0001f)
					{
						this.mTargetPitch = float.MaxValue;
					}
				}
			}
			else
			{
				IInputSource inputSource = this.RigController.InputSource;
				if (inputSource.IsViewingActivated)
				{
					if (this._IsYawEnabled && zero.y == 0f)
					{
						zero.y = inputSource.ViewX * this.mDegreesYPer60FPSTick;
					}
					if (this._IsPitchEnabled && zero.x == 0f)
					{
						zero.x = ((this.RigController._InvertPitch || this._InvertPitch) ? (-1f) : 1f) * inputSource.ViewY * this.mDegreesXPer60FPSTick;
					}
				}
				this._EulerTarget.y = ((rUseYawLimits && (this._MinYaw > -180f || this._MaxYaw < 180f)) ? Mathf.Clamp(this._EulerTarget.y + zero.y, this._MinYaw, this._MaxYaw) : (this._EulerTarget.y + zero.y));
				zero.y = ((this._Smoothing <= 0f) ? this._EulerTarget.y : this.SmoothDamp(this._Euler.y, this._EulerTarget.y, this._Smoothing * 0.001f, Time.deltaTime)) - this._Euler.y;
				this._Euler.y = this._Euler.y + zero.y;
				this._EulerTarget.x = ((rUsePitchLimits && (this._MinPitch > -180f || this._MaxPitch < 180f)) ? Mathf.Clamp(this._EulerTarget.x + zero.x, this._MinPitch, this._MaxPitch) : (this._EulerTarget.x + zero.x));
				zero.x = ((this._Smoothing <= 0f) ? this._EulerTarget.x : this.SmoothDamp(this._Euler.x, this._EulerTarget.x, this._Smoothing * 0.001f, Time.deltaTime)) - this._Euler.x;
				this._Euler.x = this._Euler.x + zero.x;
			}
			return zero;
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x000237DC File Offset: 0x000219DC
		public override void PostRigLateUpdate()
		{
			Transform anchor = this.Anchor;
			if (anchor != null)
			{
				this.mWasAnchorRotating = !QuaternionExt.IsEqual(this.mAnchorLastRotation, anchor.rotation);
				this.mAnchorLastPosition = anchor.position;
				this.mAnchorLastRotation = anchor.rotation;
			}
			this.mFocusLastPosition = this.GetFocusPosition(this.RigController._Transform.rotation);
			if (Mathf.Abs(this._EulerTarget.y - this._Euler.y) < 0.0001f)
			{
				this._Euler.y = this.LocalYaw;
				this._EulerTarget.y = this._Euler.y;
				this.mViewVelocityY = 0f;
			}
			if (Mathf.Abs(this._EulerTarget.x - this._Euler.x) < 0.0001f)
			{
				this._Euler.x = this.LocalPitch;
				this._EulerTarget.x = this._Euler.x;
				this.mViewVelocityX = 0f;
			}
			base.PostRigLateUpdate();
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x000238F7 File Offset: 0x00021AF7
		public float SmoothDamp(float rSource, float rTarget, float rSmoothing, float rDeltaTime)
		{
			return Mathf.Lerp(rSource, rTarget, 1f - Mathf.Pow(rSmoothing, rDeltaTime));
		}

		// Token: 0x0400030D RID: 781
		public const float EPSILON = 0.0001f;

		// Token: 0x0400030E RID: 782
		public float _MaxDistance = 3f;

		// Token: 0x0400030F RID: 783
		protected float mDistance = 3f;

		// Token: 0x04000310 RID: 784
		public bool _IsYawEnabled = true;

		// Token: 0x04000311 RID: 785
		public float _MinYaw = -180f;

		// Token: 0x04000312 RID: 786
		public float _MaxYaw = 180f;

		// Token: 0x04000313 RID: 787
		public float _YawSpeed = 120f;

		// Token: 0x04000314 RID: 788
		public float _TargetRotationMultiplier = 3f;

		// Token: 0x04000315 RID: 789
		public bool _IsPitchEnabled = true;

		// Token: 0x04000316 RID: 790
		public bool _InvertPitch = true;

		// Token: 0x04000317 RID: 791
		public float _MinPitch = -60f;

		// Token: 0x04000318 RID: 792
		public float _MaxPitch = 60f;

		// Token: 0x04000319 RID: 793
		public float _PitchSpeed = 45f;

		// Token: 0x0400031A RID: 794
		public float _Smoothing = 0.05f;

		// Token: 0x0400031B RID: 795
		protected Vector3 _Euler = Vector3.zero;

		// Token: 0x0400031C RID: 796
		protected Vector3 _EulerTarget = Vector3.zero;

		// Token: 0x0400031D RID: 797
		protected float mDegreesYPer60FPSTick = 1f;

		// Token: 0x0400031E RID: 798
		protected float mDegreesXPer60FPSTick = 1f;

		// Token: 0x0400031F RID: 799
		protected Vector3 mFrameEuler = Vector3.zero;

		// Token: 0x04000320 RID: 800
		protected Vector3 mAnchorLastPosition = Vector3.zero;

		// Token: 0x04000321 RID: 801
		protected Quaternion mAnchorLastRotation = Quaternion.identity;

		// Token: 0x04000322 RID: 802
		protected Vector3 mFocusLastPosition = Vector3.zero;

		// Token: 0x04000323 RID: 803
		protected bool mWasAnchorRotating;

		// Token: 0x04000324 RID: 804
		protected float mTargetYaw = float.MaxValue;

		// Token: 0x04000325 RID: 805
		protected float mTargetPitch = float.MaxValue;

		// Token: 0x04000326 RID: 806
		protected Vector3 mTargetForward = Vector3.zero;

		// Token: 0x04000327 RID: 807
		protected float mTargetYawSpeed;

		// Token: 0x04000328 RID: 808
		protected float mTargetPitchSpeed;

		// Token: 0x04000329 RID: 809
		protected bool mAutoClearTarget = true;

		// Token: 0x0400032A RID: 810
		protected float mViewVelocityY;

		// Token: 0x0400032B RID: 811
		protected float mViewVelocityX;
	}
}
