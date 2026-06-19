using System;
using com.ootii.Cameras;
using com.ootii.Geometry;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x02000105 RID: 261
	[MotionName("Idle")]
	[MotionDescription("Simple idle motion to be used as a default motion. It can also rotate the actor with the camera view.")]
	public class Idle : MotionControllerMotion
	{
		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x06000F1D RID: 3869 RVA: 0x0004F14B File Offset: 0x0004D34B
		// (set) Token: 0x06000F1E RID: 3870 RVA: 0x0004F153 File Offset: 0x0004D353
		public int FormCondition
		{
			get
			{
				return this._FormCondition;
			}
			set
			{
				this._FormCondition = value;
			}
		}

		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x06000F1F RID: 3871 RVA: 0x0004F15C File Offset: 0x0004D35C
		// (set) Token: 0x06000F20 RID: 3872 RVA: 0x0004F164 File Offset: 0x0004D364
		public bool RotateWithCamera
		{
			get
			{
				return this._RotateWithCamera;
			}
			set
			{
				this._RotateWithCamera = value;
				if (this.mMotionController != null && this.mMotionController.CameraRig is BaseCameraRig)
				{
					BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
					baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
					if (this._RotateWithCamera)
					{
						BaseCameraRig baseCameraRig2 = (BaseCameraRig)this.mMotionController.CameraRig;
						baseCameraRig2.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Combine(baseCameraRig2.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
					}
				}
			}
		}

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x06000F21 RID: 3873 RVA: 0x0004F202 File Offset: 0x0004D402
		// (set) Token: 0x06000F22 RID: 3874 RVA: 0x0004F20A File Offset: 0x0004D40A
		public float RotationToCameraSpeed
		{
			get
			{
				return this._RotationToCameraSpeed;
			}
			set
			{
				this._RotationToCameraSpeed = value;
			}
		}

		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x06000F23 RID: 3875 RVA: 0x0004F213 File Offset: 0x0004D413
		// (set) Token: 0x06000F24 RID: 3876 RVA: 0x0004F21B File Offset: 0x0004D41B
		public bool RotateWithInput
		{
			get
			{
				return this._RotateWithInput;
			}
			set
			{
				this._RotateWithInput = value;
			}
		}

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x06000F25 RID: 3877 RVA: 0x0004F224 File Offset: 0x0004D424
		// (set) Token: 0x06000F26 RID: 3878 RVA: 0x0004F22C File Offset: 0x0004D42C
		public bool RotateWithMovementInputX
		{
			get
			{
				return this._RotateWithMovementInputX;
			}
			set
			{
				this._RotateWithMovementInputX = value;
			}
		}

		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x06000F27 RID: 3879 RVA: 0x0004F235 File Offset: 0x0004D435
		// (set) Token: 0x06000F28 RID: 3880 RVA: 0x0004F23D File Offset: 0x0004D43D
		public float RotationSpeed
		{
			get
			{
				return this._RotationSpeed;
			}
			set
			{
				this._RotationSpeed = value;
			}
		}

		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x06000F29 RID: 3881 RVA: 0x0004F246 File Offset: 0x0004D446
		// (set) Token: 0x06000F2A RID: 3882 RVA: 0x0004F24E File Offset: 0x0004D44E
		public virtual float RotationSmoothing
		{
			get
			{
				return this._RotationSmoothing;
			}
			set
			{
				this._RotationSmoothing = value;
			}
		}

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x06000F2B RID: 3883 RVA: 0x0004F257 File Offset: 0x0004D457
		// (set) Token: 0x06000F2C RID: 3884 RVA: 0x0004F25F File Offset: 0x0004D45F
		public bool ForceViewOnInput
		{
			get
			{
				return this._ForceViewOnInput;
			}
			set
			{
				this._ForceViewOnInput = value;
			}
		}

		// Token: 0x06000F2D RID: 3885 RVA: 0x0004F268 File Offset: 0x0004D468
		public Idle()
		{
			this._Category = 1;
			this._Priority = 0f;
			this._ActionAlias = "ActivateRotation";
		}

		// Token: 0x06000F2E RID: 3886 RVA: 0x0004F2C0 File Offset: 0x0004D4C0
		public Idle(MotionController rController)
			: base(rController)
		{
			this._Category = 1;
			this._Priority = 0f;
			this._ActionAlias = "ActivateRotation";
		}

		// Token: 0x06000F2F RID: 3887 RVA: 0x0004F319 File Offset: 0x0004D519
		public override void Awake()
		{
			base.Awake();
		}

		// Token: 0x06000F30 RID: 3888 RVA: 0x0004F324 File Offset: 0x0004D524
		public override bool TestActivate()
		{
			if (this._FormCondition >= 0 && this.mMotionController.CurrentForm != this._FormCondition)
			{
				return false;
			}
			if (this.mMotionLayer.ActiveMotion == null)
			{
				if (this.mMotionController.IsGrounded)
				{
					return true;
				}
				if (this.mMotionLayer.ActiveMotionDuration > 1f)
				{
					return true;
				}
			}
			return this.mIsStartable && this.mMotionController.IsGrounded && this.mMotionController.State.InputMagnitudeTrend.Average == 0f;
		}

		// Token: 0x06000F31 RID: 3889 RVA: 0x0004F3B7 File Offset: 0x0004D5B7
		public override bool TestUpdate()
		{
			return !this.mIsAnimatorActive || this.IsInMotionState;
		}

		// Token: 0x06000F32 RID: 3890 RVA: 0x0004F3CC File Offset: 0x0004D5CC
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mYaw = 0f;
			this.mYawTarget = 0f;
			this.mYawVelocity = 0f;
			this.mLinkRotation = false;
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 100, true);
			if (this._RotateWithCamera && this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
				BaseCameraRig baseCameraRig2 = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig2.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Combine(baseCameraRig2.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000F33 RID: 3891 RVA: 0x0004F4A0 File Offset: 0x0004D6A0
		public override void Deactivate()
		{
			int stance = this.mActorController.State.Stance;
			if (this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			base.Deactivate();
		}

		// Token: 0x06000F34 RID: 3892 RVA: 0x0004F509 File Offset: 0x0004D709
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			rMovement = Vector3.zero;
			rRotation = Quaternion.identity;
		}

		// Token: 0x06000F35 RID: 3893 RVA: 0x0004F524 File Offset: 0x0004D724
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mVelocity = Vector3.zero;
			this.mMovement = Vector3.zero;
			this.mAngularVelocity = Vector3.zero;
			this.mRotation = Quaternion.identity;
			this.mRotateWithCamera = false;
			if (this._RotateWithCamera && this.mMotionController._CameraTransform != null && (this._ActionAlias.Length == 0 || this.mMotionController._InputSource.IsPressed(this._ActionAlias)))
			{
				this.mRotateWithCamera = true;
			}
			if (this.mRotateWithCamera && !(this.mMotionController.CameraRig is BaseCameraRig))
			{
				this.OnCameraUpdated(rDeltaTime, rUpdateIndex, null);
			}
			if (!this.mRotateWithCamera)
			{
				this.mLinkRotation = false;
				this.RotateUsingInput(rDeltaTime, ref this.mRotation);
			}
		}

		// Token: 0x06000F36 RID: 3894 RVA: 0x0004F5EC File Offset: 0x0004D7EC
		private void RotateUsingInput(float rDeltaTime, ref Quaternion rRotation)
		{
			if (this.mMotionController._InputSource == null)
			{
				return;
			}
			float num = 0f;
			if (this._RotateWithMovementInputX)
			{
				num = this.mMotionController._InputSource.MovementX * this._RotationSpeed * rDeltaTime;
				if (num != 0f)
				{
					this.mYaw += num;
					this.mYawTarget = this.mYaw;
					rRotation = Quaternion.Euler(0f, num, 0f);
					if (this._ForceViewOnInput && this.mMotionController.CameraRig is BaseCameraRig)
					{
						((BaseCameraRig)this.mMotionController.CameraRig).FrameForceToFollowAnchor = true;
					}
					return;
				}
			}
			if (num == 0f && this._RotateWithInput && this.mMotionController._InputSource.IsViewingActivated)
			{
				num = this.mMotionController._InputSource.ViewX * this._RotationSpeed * rDeltaTime;
			}
			this.mYawTarget += num;
			num = ((this._RotationSmoothing <= 0f) ? this.mYawTarget : Mathf.SmoothDampAngle(this.mYaw, this.mYawTarget, ref this.mYawVelocity, this._RotationSmoothing)) - this.mYaw;
			this.mYaw += num;
			if (num != 0f)
			{
				rRotation = Quaternion.Euler(0f, num, 0f);
			}
			if (this._ForceViewOnInput && this.mMotionController._InputSource.MovementX != 0f && this.mMotionController.CameraRig is BaseCameraRig)
			{
				((BaseCameraRig)this.mMotionController.CameraRig).FrameForceToFollowAnchor = true;
			}
		}

		// Token: 0x06000F37 RID: 3895 RVA: 0x0004F794 File Offset: 0x0004D994
		private void OnCameraUpdated(float rDeltaTime, int rUpdateIndex, BaseCameraRig rCamera)
		{
			if (!this.mRotateWithCamera)
			{
				return;
			}
			if (this.mMotionController._CameraTransform == null)
			{
				return;
			}
			float num = this.mMotionController._Transform.forward.HorizontalAngleTo(this.mMotionController._CameraTransform.forward, this.mMotionController._Transform.up);
			if (!this.mLinkRotation && Mathf.Abs(num) <= this._RotationToCameraSpeed * rDeltaTime)
			{
				this.mLinkRotation = true;
			}
			if (!this.mLinkRotation)
			{
				float num2 = Mathf.Abs(num);
				num = Mathf.Sign(num) * Mathf.Min(this._RotationToCameraSpeed * rDeltaTime, num2);
			}
			Quaternion quaternion = Quaternion.AngleAxis(num, Vector3.up);
			this.mActorController.Yaw = this.mActorController.Yaw * quaternion;
			this.mActorController._Transform.rotation = this.mActorController.Tilt * this.mActorController.Yaw;
		}

		// Token: 0x06000F38 RID: 3896 RVA: 0x0004F88B File Offset: 0x0004DA8B
		public static string GroupName()
		{
			return "Basic";
		}

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x06000F39 RID: 3897 RVA: 0x0004F894 File Offset: 0x0004DA94
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == Idle.STATE_IdlePose || animatorTransitionID == Idle.TRANS_EntryState_IdlePose || animatorTransitionID == Idle.TRANS_AnyState_IdlePose;
			}
		}

		// Token: 0x06000F3A RID: 3898 RVA: 0x0004F8D6 File Offset: 0x0004DAD6
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == Idle.STATE_IdlePose;
		}

		// Token: 0x06000F3B RID: 3899 RVA: 0x0004F8E3 File Offset: 0x0004DAE3
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == Idle.STATE_IdlePose || rTransitionID == Idle.TRANS_EntryState_IdlePose || rTransitionID == Idle.TRANS_AnyState_IdlePose;
		}

		// Token: 0x06000F3C RID: 3900 RVA: 0x0004F904 File Offset: 0x0004DB04
		public override void LoadAnimatorData()
		{
			Idle.TRANS_EntryState_IdlePose = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Idle-SM.IdlePose");
			Idle.TRANS_AnyState_IdlePose = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Idle-SM.IdlePose");
			Idle.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Idle-SM.IdlePose");
		}

		// Token: 0x04000964 RID: 2404
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000965 RID: 2405
		public const int PHASE_START = 100;

		// Token: 0x04000966 RID: 2406
		public int _FormCondition;

		// Token: 0x04000967 RID: 2407
		public bool _RotateWithCamera = true;

		// Token: 0x04000968 RID: 2408
		public float _RotationToCameraSpeed = 360f;

		// Token: 0x04000969 RID: 2409
		public bool _RotateWithInput;

		// Token: 0x0400096A RID: 2410
		public bool _RotateWithMovementInputX;

		// Token: 0x0400096B RID: 2411
		public float _RotationSpeed = 120f;

		// Token: 0x0400096C RID: 2412
		public float _RotationSmoothing = 0.1f;

		// Token: 0x0400096D RID: 2413
		public bool _ForceViewOnInput;

		// Token: 0x0400096E RID: 2414
		protected bool mRotateWithCamera;

		// Token: 0x0400096F RID: 2415
		protected bool mLinkRotation;

		// Token: 0x04000970 RID: 2416
		protected float mYaw;

		// Token: 0x04000971 RID: 2417
		protected float mYawTarget;

		// Token: 0x04000972 RID: 2418
		protected float mYawVelocity;

		// Token: 0x04000973 RID: 2419
		public static int TRANS_EntryState_IdlePose = -1;

		// Token: 0x04000974 RID: 2420
		public static int TRANS_AnyState_IdlePose = -1;

		// Token: 0x04000975 RID: 2421
		public static int STATE_IdlePose = -1;
	}
}
