using System;
using com.ootii.Cameras;
using com.ootii.Geometry;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000F0 RID: 240
	[MotionName("Basic Idle")]
	[MotionDescription("Simple idle motion to be used as a default motion. It can also rotate the actor with the camera view.")]
	public class BasicIdle : MotionControllerMotion
	{
		// Token: 0x17000383 RID: 899
		// (get) Token: 0x06000CCC RID: 3276 RVA: 0x0003F5B1 File Offset: 0x0003D7B1
		public override bool VerifyTransition
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06000CCD RID: 3277 RVA: 0x0003F5B4 File Offset: 0x0003D7B4
		// (set) Token: 0x06000CCE RID: 3278 RVA: 0x0003F5BC File Offset: 0x0003D7BC
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

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x06000CCF RID: 3279 RVA: 0x0003F65A File Offset: 0x0003D85A
		// (set) Token: 0x06000CD0 RID: 3280 RVA: 0x0003F662 File Offset: 0x0003D862
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

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06000CD1 RID: 3281 RVA: 0x0003F66B File Offset: 0x0003D86B
		// (set) Token: 0x06000CD2 RID: 3282 RVA: 0x0003F673 File Offset: 0x0003D873
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

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x06000CD3 RID: 3283 RVA: 0x0003F67C File Offset: 0x0003D87C
		// (set) Token: 0x06000CD4 RID: 3284 RVA: 0x0003F684 File Offset: 0x0003D884
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

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x06000CD5 RID: 3285 RVA: 0x0003F68D File Offset: 0x0003D88D
		// (set) Token: 0x06000CD6 RID: 3286 RVA: 0x0003F695 File Offset: 0x0003D895
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

		// Token: 0x06000CD7 RID: 3287 RVA: 0x0003F6A0 File Offset: 0x0003D8A0
		public BasicIdle()
		{
			this._Category = 1;
			this._Priority = 0f;
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x0003F710 File Offset: 0x0003D910
		public BasicIdle(MotionController rController)
			: base(rController)
		{
			this._Category = 1;
			this._Priority = 0f;
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x0003F77E File Offset: 0x0003D97E
		public override void Awake()
		{
			base.Awake();
		}

		// Token: 0x06000CDA RID: 3290 RVA: 0x0003F788 File Offset: 0x0003D988
		public override bool TestActivate()
		{
			return (this.mMotionLayer.ActiveMotion == null && this.mMotionController.IsGrounded) || (this.mIsStartable && this.mMotionController.IsGrounded && this.mMotionController.State.InputMagnitudeTrend.Average == 0f);
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x0003F7EC File Offset: 0x0003D9EC
		public override bool TestUpdate()
		{
			return this.mMotionLayer.AnimatorTransitionID != 0 || !this.mMotionController.State.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].StateInfo.IsTag("Exit");
		}

		// Token: 0x06000CDC RID: 3292 RVA: 0x0003F83C File Offset: 0x0003DA3C
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mYaw = 0f;
			this.mYawTarget = 0f;
			this.mYawVelocity = 0f;
			this.mLinkRotation = false;
			this.mActiveForm = ((this._Form > 0) ? this._Form : this.mMotionController.CurrentForm);
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, this.PHASE_START, this.mActiveForm, this.mParameter, true);
			if (this._RotateWithCamera && this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
				BaseCameraRig baseCameraRig2 = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig2.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Combine(baseCameraRig2.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000CDD RID: 3293 RVA: 0x0003F940 File Offset: 0x0003DB40
		public override void Deactivate()
		{
			this.mParameter = 0;
			if (this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			base.Deactivate();
		}

		// Token: 0x06000CDE RID: 3294 RVA: 0x0003F99D File Offset: 0x0003DB9D
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			rMovement = Vector3.zero;
			rRotation = Quaternion.identity;
		}

		// Token: 0x06000CDF RID: 3295 RVA: 0x0003F9B8 File Offset: 0x0003DBB8
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mVelocity = Vector3.zero;
			this.mMovement = Vector3.zero;
			this.mAngularVelocity = Vector3.zero;
			this.mRotation = Quaternion.identity;
			bool flag = false;
			if (this._RotateWithCamera && this.mMotionController._CameraTransform != null && this.mMotionController._InputSource.IsPressed(this._ActionAlias))
			{
				flag = true;
				if (!(this.mMotionController.CameraRig is BaseCameraRig))
				{
					this.OnCameraUpdated(rDeltaTime, rUpdateIndex, null);
				}
			}
			if (!flag && this._RotateWithInput)
			{
				this.mLinkRotation = false;
				this.RotateUsingInput(rDeltaTime, ref this.mRotation);
			}
			if (this._Form <= 0 && this.mActiveForm != this.mMotionController.CurrentForm)
			{
				this.mActiveForm = this.mMotionController.CurrentForm;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, this.PHASE_START, this.mActiveForm, 0, true);
			}
		}

		// Token: 0x06000CE0 RID: 3296 RVA: 0x0003FAB4 File Offset: 0x0003DCB4
		private void RotateUsingInput(float rDeltaTime, ref Quaternion rRotation)
		{
			if (this.mMotionController._InputSource == null)
			{
				return;
			}
			float num = 0f;
			if (this._RotateWithInput && this.mMotionController._InputSource.IsViewingActivated)
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
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x0003FB80 File Offset: 0x0003DD80
		private void OnCameraUpdated(float rDeltaTime, int rUpdateIndex, BaseCameraRig rCamera)
		{
			if (!this._RotateWithCamera)
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

		// Token: 0x06000CE2 RID: 3298 RVA: 0x0003FC77 File Offset: 0x0003DE77
		public static string GroupName()
		{
			return "Basic";
		}

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x06000CE3 RID: 3299 RVA: 0x0003FC7E File Offset: 0x0003DE7E
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x06000CE4 RID: 3300 RVA: 0x0003FC84 File Offset: 0x0003DE84
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				if (animatorTransitionID == 0)
				{
					if (animatorStateID == this.STATE_Empty)
					{
						return true;
					}
					if (animatorStateID == this.STATE_UnarmedIdlePose)
					{
						return true;
					}
				}
				return animatorTransitionID == this.TRANS_AnyState_UnarmedIdlePose || animatorTransitionID == this.TRANS_EntryState_UnarmedIdlePose || animatorTransitionID == this.TRANS_AnyState_UnarmedIdlePose || animatorTransitionID == this.TRANS_EntryState_UnarmedIdlePose;
			}
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x0003FCEF File Offset: 0x0003DEEF
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == this.STATE_Empty || rStateID == this.STATE_UnarmedIdlePose;
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x0003FD08 File Offset: 0x0003DF08
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			if (rTransitionID == 0)
			{
				if (rStateID == this.STATE_Empty)
				{
					return true;
				}
				if (rStateID == this.STATE_UnarmedIdlePose)
				{
					return true;
				}
			}
			return rTransitionID == this.TRANS_AnyState_UnarmedIdlePose || rTransitionID == this.TRANS_EntryState_UnarmedIdlePose || rTransitionID == this.TRANS_AnyState_UnarmedIdlePose || rTransitionID == this.TRANS_EntryState_UnarmedIdlePose;
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x0003FD5C File Offset: 0x0003DF5C
		public override void LoadAnimatorData()
		{
			string layerName = this.mMotionController.Animator.GetLayerName(this.mMotionLayer._AnimatorLayerIndex);
			this.TRANS_AnyState_UnarmedIdlePose = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".BasicIdle-SM.Unarmed Idle Pose");
			this.TRANS_EntryState_UnarmedIdlePose = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".BasicIdle-SM.Unarmed Idle Pose");
			this.TRANS_AnyState_UnarmedIdlePose = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".BasicIdle-SM.Unarmed Idle Pose");
			this.TRANS_EntryState_UnarmedIdlePose = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".BasicIdle-SM.Unarmed Idle Pose");
			this.STATE_Empty = this.mMotionController.AddAnimatorName(layerName + ".Empty");
			this.STATE_UnarmedIdlePose = this.mMotionController.AddAnimatorName(layerName + ".BasicIdle-SM.Unarmed Idle Pose");
		}

		// Token: 0x0400070E RID: 1806
		public int PHASE_UNKNOWN;

		// Token: 0x0400070F RID: 1807
		public int PHASE_START = 3000;

		// Token: 0x04000710 RID: 1808
		public bool _RotateWithCamera;

		// Token: 0x04000711 RID: 1809
		public float _RotationToCameraSpeed = 360f;

		// Token: 0x04000712 RID: 1810
		public bool _RotateWithInput;

		// Token: 0x04000713 RID: 1811
		public float _RotationSpeed = 120f;

		// Token: 0x04000714 RID: 1812
		public float _RotationSmoothing = 0.1f;

		// Token: 0x04000715 RID: 1813
		protected bool mLinkRotation;

		// Token: 0x04000716 RID: 1814
		protected float mYaw;

		// Token: 0x04000717 RID: 1815
		protected float mYawTarget;

		// Token: 0x04000718 RID: 1816
		protected float mYawVelocity;

		// Token: 0x04000719 RID: 1817
		protected int mActiveForm;

		// Token: 0x0400071A RID: 1818
		public int STATE_Empty = -1;

		// Token: 0x0400071B RID: 1819
		public int STATE_UnarmedIdlePose = -1;

		// Token: 0x0400071C RID: 1820
		public int TRANS_AnyState_UnarmedIdlePose = -1;

		// Token: 0x0400071D RID: 1821
		public int TRANS_EntryState_UnarmedIdlePose = -1;
	}
}
