using System;
using com.ootii.Cameras;
using com.ootii.Geometry;
using com.ootii.Helpers;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x02000119 RID: 281
	[MotionName("Walk Run Rotate")]
	[MotionDescription("WoW style movement. When Rotate Action Alias is held, character rotates to the camera's forward. When not held, camera rotates to the character's forward.\r\n\r\nLeft/Right Action Alias = Strafe\r\nHorizontal movement keys = Rotate")]
	public class WalkRunRotate_v2 : MotionControllerMotion, IWalkRunMotion
	{
		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x06001123 RID: 4387 RVA: 0x0006031B File Offset: 0x0005E51B
		// (set) Token: 0x06001124 RID: 4388 RVA: 0x00060323 File Offset: 0x0005E523
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

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x06001125 RID: 4389 RVA: 0x0006032C File Offset: 0x0005E52C
		// (set) Token: 0x06001126 RID: 4390 RVA: 0x00060334 File Offset: 0x0005E534
		public bool DefaultToRun
		{
			get
			{
				return this._DefaultToRun;
			}
			set
			{
				this._DefaultToRun = value;
			}
		}

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x06001127 RID: 4391 RVA: 0x00060340 File Offset: 0x0005E540
		public virtual bool IsRunActive
		{
			get
			{
				if (this.mMotionController.TargetNormalizedSpeed > 0f && this.mMotionController.TargetNormalizedSpeed <= 0.5f)
				{
					return false;
				}
				if (this.mMotionController._InputSource == null)
				{
					return this._DefaultToRun;
				}
				return (this._DefaultToRun && !this.mMotionController._InputSource.IsPressed(this._ActionAlias)) || (!this._DefaultToRun && this.mMotionController._InputSource.IsPressed(this._ActionAlias));
			}
		}

		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x06001128 RID: 4392 RVA: 0x000603C9 File Offset: 0x0005E5C9
		// (set) Token: 0x06001129 RID: 4393 RVA: 0x000603D1 File Offset: 0x0005E5D1
		public string StrafeLeftActionAlias
		{
			get
			{
				return this._StrafeLeftActionAlias;
			}
			set
			{
				this._StrafeLeftActionAlias = value;
			}
		}

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x0600112A RID: 4394 RVA: 0x000603DA File Offset: 0x0005E5DA
		// (set) Token: 0x0600112B RID: 4395 RVA: 0x000603E2 File Offset: 0x0005E5E2
		public string StrafeRightActionAlias
		{
			get
			{
				return this._StrafeRightActionAlias;
			}
			set
			{
				this._StrafeRightActionAlias = value;
			}
		}

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x0600112C RID: 4396 RVA: 0x000603EB File Offset: 0x0005E5EB
		// (set) Token: 0x0600112D RID: 4397 RVA: 0x000603F3 File Offset: 0x0005E5F3
		public virtual float WalkSpeed
		{
			get
			{
				return this._WalkSpeed;
			}
			set
			{
				this._WalkSpeed = value;
			}
		}

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x0600112E RID: 4398 RVA: 0x000603FC File Offset: 0x0005E5FC
		// (set) Token: 0x0600112F RID: 4399 RVA: 0x00060404 File Offset: 0x0005E604
		public virtual float RunSpeed
		{
			get
			{
				return this._RunSpeed;
			}
			set
			{
				this._RunSpeed = value;
			}
		}

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06001130 RID: 4400 RVA: 0x0006040D File Offset: 0x0005E60D
		// (set) Token: 0x06001131 RID: 4401 RVA: 0x00060415 File Offset: 0x0005E615
		public bool StartInMove
		{
			get
			{
				return this.mStartInMove;
			}
			set
			{
				this.mStartInMove = value;
			}
		}

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06001132 RID: 4402 RVA: 0x0006041E File Offset: 0x0005E61E
		// (set) Token: 0x06001133 RID: 4403 RVA: 0x00060426 File Offset: 0x0005E626
		public bool StartInWalk
		{
			get
			{
				return this.mStartInWalk;
			}
			set
			{
				this.mStartInWalk = value;
			}
		}

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06001134 RID: 4404 RVA: 0x0006042F File Offset: 0x0005E62F
		// (set) Token: 0x06001135 RID: 4405 RVA: 0x00060437 File Offset: 0x0005E637
		public bool StartInRun
		{
			get
			{
				return this.mStartInRun;
			}
			set
			{
				this.mStartInRun = value;
			}
		}

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06001136 RID: 4406 RVA: 0x00060440 File Offset: 0x0005E640
		// (set) Token: 0x06001137 RID: 4407 RVA: 0x00060448 File Offset: 0x0005E648
		public string RotateActionAlias
		{
			get
			{
				return this._RotateActionAlias;
			}
			set
			{
				this._RotateActionAlias = value;
			}
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06001138 RID: 4408 RVA: 0x00060451 File Offset: 0x0005E651
		// (set) Token: 0x06001139 RID: 4409 RVA: 0x00060459 File Offset: 0x0005E659
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

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x0600113A RID: 4410 RVA: 0x00060462 File Offset: 0x0005E662
		// (set) Token: 0x0600113B RID: 4411 RVA: 0x0006046A File Offset: 0x0005E66A
		public bool RotateWithCamera
		{
			get
			{
				return this._RotateWithCamera;
			}
			set
			{
				this._RotateWithCamera = value;
			}
		}

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x0600113C RID: 4412 RVA: 0x00060473 File Offset: 0x0005E673
		// (set) Token: 0x0600113D RID: 4413 RVA: 0x0006047B File Offset: 0x0005E67B
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

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x0600113E RID: 4414 RVA: 0x00060484 File Offset: 0x0005E684
		// (set) Token: 0x0600113F RID: 4415 RVA: 0x0006048C File Offset: 0x0005E68C
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

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x06001140 RID: 4416 RVA: 0x00060495 File Offset: 0x0005E695
		// (set) Token: 0x06001141 RID: 4417 RVA: 0x0006049D File Offset: 0x0005E69D
		public int SmoothingSamples
		{
			get
			{
				return this._SmoothingSamples;
			}
			set
			{
				this._SmoothingSamples = value;
				this.mInputX.SampleCount = this._SmoothingSamples;
				this.mInputY.SampleCount = this._SmoothingSamples;
				this.mInputMagnitude.SampleCount = this._SmoothingSamples;
			}
		}

		// Token: 0x06001142 RID: 4418 RVA: 0x000604DC File Offset: 0x0005E6DC
		public WalkRunRotate_v2()
		{
			this._Category = 2;
			this._Priority = 5f;
			this._ActionAlias = "Run";
		}

		// Token: 0x06001143 RID: 4419 RVA: 0x00060590 File Offset: 0x0005E790
		public WalkRunRotate_v2(MotionController rController)
			: base(rController)
		{
			this._Category = 2;
			this._Priority = 5f;
			this._ActionAlias = "Run";
		}

		// Token: 0x06001144 RID: 4420 RVA: 0x00060644 File Offset: 0x0005E844
		public override void Awake()
		{
			base.Awake();
			this.SmoothingSamples = this._SmoothingSamples;
		}

		// Token: 0x06001145 RID: 4421 RVA: 0x00060658 File Offset: 0x0005E858
		public override bool TestActivate()
		{
			if (!this.mIsStartable)
			{
				return false;
			}
			if (!this.mMotionController.IsGrounded)
			{
				return false;
			}
			if (this.mMotionController.Stance != 0)
			{
				return false;
			}
			if (this._FormCondition >= 0 && this.mMotionController.CurrentForm != this._FormCondition)
			{
				return false;
			}
			if (this.mMotionController.State.InputY > -0.49f && this.mMotionController.State.InputY < 0.49f)
			{
				if (this.mMotionController._InputSource == null)
				{
					return false;
				}
				if (!this.mMotionController._InputSource.IsPressed(this._StrafeLeftActionAlias) && !this.mMotionController._InputSource.IsPressed(this._StrafeRightActionAlias) && (!this.mMotionController._InputSource.IsPressed(this._RotateActionAlias) || (this.mMotionController.State.InputX >= -0.49f && this.mMotionController.State.InputX <= 0.49f)))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06001146 RID: 4422 RVA: 0x00060768 File Offset: 0x0005E968
		public override bool TestUpdate()
		{
			return this.mIsActivatedFrame || (this.mMotionController.IsGrounded && this.mMotionController.Stance == 0 && (this.mInputMagnitude.Average != 0f || this.mMotionController.State.InputX != 0f) && this.mMotionLayer._AnimatorStateID != WalkRunRotate_v2.STATE_IdlePose && (!this.mIsAnimatorActive || this.IsInMotionState));
		}

		// Token: 0x06001147 RID: 4423 RVA: 0x000607EF File Offset: 0x0005E9EF
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			this.mMotionController.ForcedInput.x = this.mInputX.Average;
			this.mMotionController.ForcedInput.y = this.mInputY.Average;
			return true;
		}

		// Token: 0x06001148 RID: 4424 RVA: 0x00060828 File Offset: 0x0005EA28
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mYaw = 0f;
			this.mYawTarget = 0f;
			this.mYawVelocity = 0f;
			this.mLinkRotation = false;
			this.mInputX.Clear(0f);
			this.mInputY.Clear(0f);
			this.mInputMagnitude.Clear(0f);
			this.mMotionController.MaxSpeed = 5.668f;
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1730, true);
			if (this._RotateWithCamera && this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
				BaseCameraRig baseCameraRig2 = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig2.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Combine(baseCameraRig2.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06001149 RID: 4425 RVA: 0x0006093C File Offset: 0x0005EB3C
		public override void Deactivate()
		{
			if (this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			base.Deactivate();
		}

		// Token: 0x0600114A RID: 4426 RVA: 0x00060994 File Offset: 0x0005EB94
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			rRotation = Quaternion.identity;
			float num = (this.IsRunActive ? this._RunSpeed : this._WalkSpeed);
			if (num <= 0f)
			{
				if (this.mMotionController.State.InputX == 0f && rMovement.x > -0.01f && rMovement.x < 0.01f)
				{
					rMovement.x = 0f;
				}
				return;
			}
			if (rMovement.sqrMagnitude > 0f)
			{
				rMovement = rMovement.normalized * (num * rDeltaTime);
				return;
			}
			float num2 = ((this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsPressed(this._StrafeLeftActionAlias)) ? (-1f) : 0f);
			num2 += ((this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsPressed(this._StrafeRightActionAlias)) ? 1f : 0f);
			float inputY = this.mMotionController.State.InputY;
			Vector3 vector = new Vector3(num2, 0f, inputY);
			rMovement = vector.normalized * (num * rDeltaTime);
		}

		// Token: 0x0600114B RID: 4427 RVA: 0x00060AC8 File Offset: 0x0005ECC8
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mMovement = Vector3.zero;
			this.mRotation = Quaternion.identity;
			this.mForceRotationToCamera = false;
			if (this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsPressed(this._RotateActionAlias) && this.mMotionController._CameraTransform != null)
			{
				this.mForceRotationToCamera = true;
			}
			float num = (this.IsRunActive ? 1f : 0.5f);
			MotionState state = this.mMotionController.State;
			float num2 = ((this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsPressed(this._StrafeLeftActionAlias)) ? (-1f) : 0f);
			num2 += ((this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsPressed(this._StrafeRightActionAlias)) ? 1f : 0f);
			if (this.mForceRotationToCamera && num2 == 0f)
			{
				num2 = state.InputX;
			}
			float num3 = Mathf.Sqrt(num2 * num2 + state.InputY * state.InputY);
			num2 = Mathf.Clamp(num2, -num, num);
			float num4 = Mathf.Clamp(state.InputY, -num, num);
			num3 = Mathf.Clamp(num3, 0f, num);
			InputManagerHelper.ConvertToRadialInput(ref num2, ref num4, ref num3, 1f);
			this.mInputX.Add(num2);
			this.mInputY.Add(num4);
			this.mInputMagnitude.Add(num3);
			this.mMotionController.State.InputX = this.mInputX.Average;
			this.mMotionController.State.InputY = this.mInputY.Average;
			this.mMotionController.State.InputMagnitudeTrend.Replace(this.mInputMagnitude.Average);
			if (this._RotateWithCamera && !(this.mMotionController.CameraRig is BaseCameraRig))
			{
				this.OnCameraUpdated(rDeltaTime, rUpdateIndex, null);
			}
			if (this._RotateWithInput && !this.mForceRotationToCamera)
			{
				this.RotateUsingInput(rDeltaTime, ref this.mRotation);
			}
		}

		// Token: 0x0600114C RID: 4428 RVA: 0x00060CDC File Offset: 0x0005EEDC
		private void RotateUsingInput(float rDeltaTime, ref Quaternion rRotation)
		{
			if (this.mMotionController._InputSource == null)
			{
				return;
			}
			float num = this.mMotionController._InputSource.MovementX * this._RotationSpeed * rDeltaTime;
			if (num == 0f && this.mMotionController._InputSource.IsViewingActivated)
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
			if ((num != 0f || this.mMotionController.State.InputMagnitudeTrend.Value > 0f) && this.mMotionController.CameraRig is BaseCameraRig)
			{
				((BaseCameraRig)this.mMotionController.CameraRig).FrameForceToFollowAnchor = true;
			}
		}

		// Token: 0x0600114D RID: 4429 RVA: 0x00060E0C File Offset: 0x0005F00C
		private void OnCameraUpdated(float rDeltaTime, int rUpdateIndex, BaseCameraRig rCamera)
		{
			if (!this.mForceRotationToCamera)
			{
				return;
			}
			if (this.mMotionController._CameraTransform == null)
			{
				return;
			}
			float num = this.mMotionController._Transform.forward.HorizontalAngleTo(this.mMotionController._CameraTransform.forward, this.mMotionController._Transform.up);
			if (!this.mLinkRotation && Mathf.Abs(num) <= this._RotationSpeed * rDeltaTime)
			{
				this.mLinkRotation = true;
			}
			if (!this.mLinkRotation)
			{
				float num2 = Mathf.Abs(num);
				num = Mathf.Sign(num) * Mathf.Min(this._RotationSpeed * rDeltaTime, num2);
			}
			Quaternion quaternion = Quaternion.AngleAxis(num, Vector3.up);
			this.mActorController.Yaw = this.mActorController.Yaw * quaternion;
			this.mActorController._Transform.rotation = this.mActorController.Tilt * this.mActorController.Yaw;
		}

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x0600114E RID: 4430 RVA: 0x00060F03 File Offset: 0x0005F103
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x0600114F RID: 4431 RVA: 0x00060F08 File Offset: 0x0005F108
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == WalkRunRotate_v2.STATE_IdlePose || animatorStateID == WalkRunRotate_v2.STATE_MoveTree || animatorTransitionID == WalkRunRotate_v2.TRANS_AnyState_MoveTree || animatorTransitionID == WalkRunRotate_v2.TRANS_EntryState_MoveTree || animatorTransitionID == WalkRunRotate_v2.TRANS_IdlePose_MoveTree || animatorTransitionID == WalkRunRotate_v2.TRANS_MoveTree_IdlePose;
			}
		}

		// Token: 0x06001150 RID: 4432 RVA: 0x00060F6A File Offset: 0x0005F16A
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == WalkRunRotate_v2.STATE_IdlePose || rStateID == WalkRunRotate_v2.STATE_MoveTree;
		}

		// Token: 0x06001151 RID: 4433 RVA: 0x00060F81 File Offset: 0x0005F181
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == WalkRunRotate_v2.STATE_IdlePose || rStateID == WalkRunRotate_v2.STATE_MoveTree || rTransitionID == WalkRunRotate_v2.TRANS_AnyState_MoveTree || rTransitionID == WalkRunRotate_v2.TRANS_EntryState_MoveTree || rTransitionID == WalkRunRotate_v2.TRANS_IdlePose_MoveTree || rTransitionID == WalkRunRotate_v2.TRANS_MoveTree_IdlePose;
		}

		// Token: 0x06001152 RID: 4434 RVA: 0x00060FC0 File Offset: 0x0005F1C0
		public override void LoadAnimatorData()
		{
			WalkRunRotate_v2.TRANS_AnyState_MoveTree = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunRotate v2-SM.Move Tree");
			WalkRunRotate_v2.TRANS_EntryState_MoveTree = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunRotate v2-SM.Move Tree");
			WalkRunRotate_v2.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate v2-SM.IdlePose");
			WalkRunRotate_v2.TRANS_IdlePose_MoveTree = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate v2-SM.IdlePose -> Base Layer.WalkRunRotate v2-SM.Move Tree");
			WalkRunRotate_v2.STATE_MoveTree = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate v2-SM.Move Tree");
			WalkRunRotate_v2.TRANS_MoveTree_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate v2-SM.Move Tree -> Base Layer.WalkRunRotate v2-SM.IdlePose");
		}

		// Token: 0x04000CDF RID: 3295
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000CE0 RID: 3296
		public const int PHASE_START = 1730;

		// Token: 0x04000CE1 RID: 3297
		public const int PHASE_STOP = 1735;

		// Token: 0x04000CE2 RID: 3298
		public int _FormCondition = -1;

		// Token: 0x04000CE3 RID: 3299
		public bool _DefaultToRun;

		// Token: 0x04000CE4 RID: 3300
		public string _StrafeLeftActionAlias = "StrafeLeft";

		// Token: 0x04000CE5 RID: 3301
		public string _StrafeRightActionAlias = "StrafeRight";

		// Token: 0x04000CE6 RID: 3302
		public float _WalkSpeed;

		// Token: 0x04000CE7 RID: 3303
		public float _RunSpeed;

		// Token: 0x04000CE8 RID: 3304
		private bool mStartInMove;

		// Token: 0x04000CE9 RID: 3305
		private bool mStartInWalk;

		// Token: 0x04000CEA RID: 3306
		private bool mStartInRun;

		// Token: 0x04000CEB RID: 3307
		public string _RotateActionAlias = "ActivateRotation";

		// Token: 0x04000CEC RID: 3308
		public bool _RotateWithInput;

		// Token: 0x04000CED RID: 3309
		public bool _RotateWithCamera = true;

		// Token: 0x04000CEE RID: 3310
		public float _RotationSpeed = 180f;

		// Token: 0x04000CEF RID: 3311
		public float _RotationSmoothing = 0.1f;

		// Token: 0x04000CF0 RID: 3312
		public int _SmoothingSamples = 10;

		// Token: 0x04000CF1 RID: 3313
		protected bool mLinkRotation;

		// Token: 0x04000CF2 RID: 3314
		protected bool mForceRotationToCamera;

		// Token: 0x04000CF3 RID: 3315
		protected float mYaw;

		// Token: 0x04000CF4 RID: 3316
		protected float mYawTarget;

		// Token: 0x04000CF5 RID: 3317
		protected float mYawVelocity;

		// Token: 0x04000CF6 RID: 3318
		protected FloatValue mInputX = new FloatValue(0f, 10);

		// Token: 0x04000CF7 RID: 3319
		protected FloatValue mInputY = new FloatValue(0f, 10);

		// Token: 0x04000CF8 RID: 3320
		protected FloatValue mInputMagnitude = new FloatValue(0f, 15);

		// Token: 0x04000CF9 RID: 3321
		public static int STATE_IdlePose = -1;

		// Token: 0x04000CFA RID: 3322
		public static int STATE_MoveTree = -1;

		// Token: 0x04000CFB RID: 3323
		public static int TRANS_AnyState_MoveTree = -1;

		// Token: 0x04000CFC RID: 3324
		public static int TRANS_EntryState_MoveTree = -1;

		// Token: 0x04000CFD RID: 3325
		public static int TRANS_IdlePose_MoveTree = -1;

		// Token: 0x04000CFE RID: 3326
		public static int TRANS_MoveTree_IdlePose = -1;
	}
}
