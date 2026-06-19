using System;
using com.ootii.Cameras;
using com.ootii.Helpers;
using com.ootii.Timing;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x0200011A RID: 282
	[MotionName("Walk Run Strafe (old)")]
	[MotionDescription("Simple walking motion that keeps the character facing forward.")]
	public class WalkRunStrafe : MotionControllerMotion, IWalkRunMotion
	{
		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x06001154 RID: 4436 RVA: 0x00061071 File Offset: 0x0005F271
		// (set) Token: 0x06001155 RID: 4437 RVA: 0x00061079 File Offset: 0x0005F279
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

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06001156 RID: 4438 RVA: 0x00061082 File Offset: 0x0005F282
		// (set) Token: 0x06001157 RID: 4439 RVA: 0x0006108A File Offset: 0x0005F28A
		public bool ActivateWithAltCameraMode
		{
			get
			{
				return this._ActivateWithAltCameraMode;
			}
			set
			{
				this._ActivateWithAltCameraMode = value;
			}
		}

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06001158 RID: 4440 RVA: 0x00061093 File Offset: 0x0005F293
		// (set) Token: 0x06001159 RID: 4441 RVA: 0x0006109B File Offset: 0x0005F29B
		public bool RotateWithInput
		{
			get
			{
				return this._RotateWithInput;
			}
			set
			{
				this._RotateWithInput = value;
				if (this._RotateWithInput)
				{
					this._RotateWithView = false;
				}
			}
		}

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x0600115A RID: 4442 RVA: 0x000610B3 File Offset: 0x0005F2B3
		// (set) Token: 0x0600115B RID: 4443 RVA: 0x000610BB File Offset: 0x0005F2BB
		public bool RotateWithView
		{
			get
			{
				return this._RotateWithView;
			}
			set
			{
				this._RotateWithView = value;
				if (this._RotateWithView)
				{
					this._RotateWithInput = false;
				}
			}
		}

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x0600115C RID: 4444 RVA: 0x000610D3 File Offset: 0x0005F2D3
		// (set) Token: 0x0600115D RID: 4445 RVA: 0x000610DB File Offset: 0x0005F2DB
		public float RotationSpeed
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

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x0600115E RID: 4446 RVA: 0x000610F6 File Offset: 0x0005F2F6
		// (set) Token: 0x0600115F RID: 4447 RVA: 0x000610FE File Offset: 0x0005F2FE
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

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x06001160 RID: 4448 RVA: 0x00061107 File Offset: 0x0005F307
		// (set) Token: 0x06001161 RID: 4449 RVA: 0x0006110F File Offset: 0x0005F30F
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

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x06001162 RID: 4450 RVA: 0x00061118 File Offset: 0x0005F318
		// (set) Token: 0x06001163 RID: 4451 RVA: 0x00061120 File Offset: 0x0005F320
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

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x06001164 RID: 4452 RVA: 0x00061129 File Offset: 0x0005F329
		// (set) Token: 0x06001165 RID: 4453 RVA: 0x00061131 File Offset: 0x0005F331
		public bool RemoveLateralMovement
		{
			get
			{
				return this._RemoveLateralMovement;
			}
			set
			{
				this._RemoveLateralMovement = value;
			}
		}

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x06001166 RID: 4454 RVA: 0x0006113A File Offset: 0x0005F33A
		// (set) Token: 0x06001167 RID: 4455 RVA: 0x00061142 File Offset: 0x0005F342
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

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06001168 RID: 4456 RVA: 0x0006114B File Offset: 0x0005F34B
		// (set) Token: 0x06001169 RID: 4457 RVA: 0x00061153 File Offset: 0x0005F353
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

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x0600116A RID: 4458 RVA: 0x0006115C File Offset: 0x0005F35C
		// (set) Token: 0x0600116B RID: 4459 RVA: 0x00061164 File Offset: 0x0005F364
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

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x0600116C RID: 4460 RVA: 0x00061170 File Offset: 0x0005F370
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

		// Token: 0x0600116D RID: 4461 RVA: 0x000611FC File Offset: 0x0005F3FC
		public WalkRunStrafe()
		{
			this._Priority = 6f;
			this._ActionAlias = "Run";
			this.mIsStartable = true;
		}

		// Token: 0x0600116E RID: 4462 RVA: 0x00061270 File Offset: 0x0005F470
		public WalkRunStrafe(MotionController rController)
			: base(rController)
		{
			this._Priority = 6f;
			this._ActionAlias = "Run";
			this.mIsStartable = true;
		}

		// Token: 0x0600116F RID: 4463 RVA: 0x000612E2 File Offset: 0x0005F4E2
		public override void Awake()
		{
			base.Awake();
			this.mDegreesPer60FPSTick = this._RotationSpeed / 60f;
		}

		// Token: 0x06001170 RID: 4464 RVA: 0x000612FC File Offset: 0x0005F4FC
		public override bool TestActivate()
		{
			return this.mIsStartable && this.mMotionController.IsGrounded && this.mMotionController._InputSource != null && (this.mMotionController._InputSource.MovementX != 0f || this.mMotionController._InputSource.MovementY != 0f) && (!this._ActivateWithAltCameraMode || this.mMotionController.CameraRig == null || this.mMotionController.CameraRig.Mode != 0) && this.mActorController.State.Stance == 0 && this.mMotionController.State.InputMagnitudeTrend.Value >= 0.4f;
		}

		// Token: 0x06001171 RID: 4465 RVA: 0x000613C0 File Offset: 0x0005F5C0
		public override bool TestUpdate()
		{
			this.mClearRangedStance = true;
			if (this.mIsActivatedFrame)
			{
				return true;
			}
			if (!this.mMotionController.IsGrounded)
			{
				return false;
			}
			MotionState state = this.mMotionController.State;
			int animatorStateID = this.mMotionLayer._AnimatorStateID;
			int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
			if (animatorStateID == WalkRunStrafe.STATE_IdlePose && animatorTransitionID == 0 && state.InputMagnitudeTrend.Value == 0f)
			{
				this.mClearRangedStance = false;
				return false;
			}
			return (this.mAge <= 0.2f || this.mMotionController.ActiveMotion.Category != 1 || animatorTransitionID == WalkRunStrafe.TRANS_AnyState_IdlePose) && (!this.mIsAnimatorActive || this.IsInMotionState || this.mStartInRun || this.mStartInWalk) && (!this._ActivateWithAltCameraMode || this.mMotionController.CameraRig == null || this.mMotionController.CameraRig.Mode != 0);
		}

		// Token: 0x06001172 RID: 4466 RVA: 0x000614AC File Offset: 0x0005F6AC
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mYaw = 0f;
			this.mYawTarget = 0f;
			this.mYawVelocity = 0f;
			this.mClearRangedStance = true;
			if (this.mStartInRun)
			{
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1115, true);
			}
			else if (this.mStartInWalk)
			{
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1114, true);
			}
			else if (this.mMotionController._InputSource == null)
			{
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1100, true);
			}
			else
			{
				if ((this._DefaultToRun && !this.mMotionController._InputSource.IsPressed(this._ActionAlias)) || (!this._DefaultToRun && this.mMotionController._InputSource.IsPressed(this._ActionAlias)))
				{
					MotionState state = this.mMotionController.State;
					state.InputMagnitudeTrend.Value = 1f;
					this.mMotionController.State = state;
				}
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1100, true);
			}
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06001173 RID: 4467 RVA: 0x000615F3 File Offset: 0x0005F7F3
		public override void Deactivate()
		{
			this.mStartInRun = false;
			this.mStartInWalk = false;
			if (this.mClearRangedStance)
			{
				int stance = this.mActorController.State.Stance;
			}
			base.Deactivate();
		}

		// Token: 0x06001174 RID: 4468 RVA: 0x00061624 File Offset: 0x0005F824
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			if (this._RemoveLateralMovement)
			{
				AnimatorStateInfo stateInfo = this.mMotionController.State.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].StateInfo;
				int fullPathHash = stateInfo.fullPathHash;
				if (fullPathHash == WalkRunStrafe.STATE_WalkFwdLoop || fullPathHash == WalkRunStrafe.STATE_WalkToIdle || fullPathHash == WalkRunStrafe.STATE_WalkToIdle_LDown || fullPathHash == WalkRunStrafe.STATE_WalkToIdle_RDown || fullPathHash == WalkRunStrafe.STATE_RunFwdLoop || fullPathHash == WalkRunStrafe.STATE_WalkBackward)
				{
					rMovement.x = 0f;
				}
			}
			rRotation = Quaternion.identity;
		}

		// Token: 0x06001175 RID: 4469 RVA: 0x000616B0 File Offset: 0x0005F8B0
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mAngularVelocity = Vector3.zero;
			this.mRotation = Quaternion.identity;
			if (this.mMotionController.CameraRig != null)
			{
				int mode = this.mMotionController.CameraRig.Mode;
			}
			if (rUpdateIndex < 1)
			{
				return;
			}
			MotionState state = this.mMotionController.State;
			int motionPhase = state.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].MotionPhase;
			AnimatorStateInfo stateInfo = state.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].StateInfo;
			int fullPathHash = stateInfo.fullPathHash;
			if ((motionPhase == 1100 || motionPhase == 1110) && fullPathHash == WalkRunStrafe.STATE_IdlePose)
			{
				state.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].MotionPhase = 0;
			}
			bool flag = this._DefaultToRun;
			if (this.mMotionController._InputSource == null)
			{
				flag = this.mMotionController.State.InputMagnitudeTrend.Value > 0.9f;
			}
			else
			{
				flag = (this._DefaultToRun && !this.mMotionController._InputSource.IsPressed(this._ActionAlias)) || (!this._DefaultToRun && this.mMotionController._InputSource.IsPressed(this._ActionAlias));
			}
			if (!flag)
			{
				state.InputY *= 0.5f;
				if (state.InputMagnitudeTrend.Value > 0.5f)
				{
					state.InputMagnitudeTrend.Replace(0.5f);
				}
			}
			int num = ((flag && state.InputMagnitudeTrend.Value > 0.9f) ? 1 : 0);
			bool flag2 = true;
			state.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].MotionParameter = num;
			if (fullPathHash == WalkRunStrafe.STATE_WalkFwdLoop)
			{
				this.mStartInWalk = false;
				if (state.InputMagnitudeTrend.Value < 0.1f && (state.AnimatorStates[this.mMotionLayer.AnimatorLayerIndex].MotionPhase == 0 || state.AnimatorStates[this.mMotionLayer.AnimatorLayerIndex].MotionPhase == 1121 || state.AnimatorStates[this.mMotionLayer.AnimatorLayerIndex].MotionPhase == 1120))
				{
					float num2 = stateInfo.normalizedTime % 1f;
					if (num2 > 0.25f && num2 < 0.75f)
					{
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1121, true);
					}
					else
					{
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1120, true);
					}
				}
			}
			else if (fullPathHash == WalkRunStrafe.STATE_RunFwdLoop)
			{
				this.mStartInRun = false;
			}
			if (flag2)
			{
				this.mMotionController.State = state;
			}
			if (this._RotateWithInput || (this.mMotionController.CameraRig != null && this.mMotionController.CameraRig.Mode > 0))
			{
				this.GetRotationVelocityWithInput(rDeltaTime, ref this.mRotation);
				return;
			}
			if (this._RotateWithView)
			{
				this.GetRotationVelocityWithView(rDeltaTime, ref this.mAngularVelocity);
			}
		}

		// Token: 0x06001176 RID: 4470 RVA: 0x000619B8 File Offset: 0x0005FBB8
		private void GetRotationVelocityWithInput(float rDeltaTime, ref Quaternion rRotation)
		{
			if (this.mMotionController._InputSource == null)
			{
				return;
			}
			float num = 0f;
			if (this.mMotionController._InputSource.IsPressed(this._RotateActionAlias))
			{
				num = this.mMotionController._InputSource.ViewX * this.mDegreesPer60FPSTick * TimeManager.Relative60FPSDeltaTime;
			}
			this.mYawTarget += num;
			num = ((this._RotationSmoothing <= 0f) ? this.mYawTarget : Mathf.SmoothDampAngle(this.mYaw, this.mYawTarget, ref this.mYawVelocity, this._RotationSmoothing)) - this.mYaw;
			this.mYaw += num;
			if (num != 0f)
			{
				rRotation = Quaternion.Euler(0f, num, 0f);
				if (this._ForceViewOnInput && this.mMotionController.CameraRig is BaseCameraRig)
				{
					((BaseCameraRig)this.mMotionController.CameraRig).FrameForceToFollowAnchor = true;
				}
			}
		}

		// Token: 0x06001177 RID: 4471 RVA: 0x00061AB4 File Offset: 0x0005FCB4
		private void GetRotationVelocityWithView(float rDeltaTime, ref Vector3 rRotationalVelocity)
		{
			if (this.mMotionController._CameraTransform == null)
			{
				return;
			}
			float num = 0f;
			float smoothedDeltaTime = TimeManager.SmoothedDeltaTime;
			float horizontalAngle = NumberHelper.GetHorizontalAngle(this.mActorController._Transform.forward, this.mMotionController._CameraTransform.forward, this.mActorController._Transform.up);
			if (horizontalAngle > 0f)
			{
				if (this._RotationSpeed == 0f)
				{
					num = horizontalAngle / smoothedDeltaTime;
				}
				else
				{
					if (this._RotationSpeed < 0f)
					{
						num = this.mMotionController._RotationSpeed;
					}
					else
					{
						num = this._RotationSpeed;
					}
					if (num * smoothedDeltaTime > horizontalAngle)
					{
						num = horizontalAngle / smoothedDeltaTime;
					}
				}
			}
			else if (horizontalAngle < 0f)
			{
				if (this._RotationSpeed == 0f)
				{
					num = horizontalAngle / smoothedDeltaTime;
				}
				else
				{
					if (this._RotationSpeed < 0f)
					{
						num = -this.mMotionController._RotationSpeed;
					}
					else
					{
						num = -this._RotationSpeed;
					}
					if (num * smoothedDeltaTime < horizontalAngle)
					{
						num = horizontalAngle / smoothedDeltaTime;
					}
				}
			}
			rRotationalVelocity = Vector3.up * num;
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06001178 RID: 4472 RVA: 0x00061BBC File Offset: 0x0005FDBC
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == WalkRunStrafe.STATE_IdleToWalk || animatorStateID == WalkRunStrafe.STATE_IdleToRun || animatorStateID == WalkRunStrafe.STATE_RunFwdLoop || animatorStateID == WalkRunStrafe.STATE_WalkToIdle_RDown || animatorStateID == WalkRunStrafe.STATE_WalkToIdle_LDown || animatorStateID == WalkRunStrafe.STATE_RunStop_RDown || animatorStateID == WalkRunStrafe.STATE_RunStop_LDown || animatorStateID == WalkRunStrafe.STATE_WalkToIdle || animatorStateID == WalkRunStrafe.STATE_WalkFwdLoop || animatorStateID == WalkRunStrafe.STATE_WalkBackward || animatorStateID == WalkRunStrafe.STATE_IdlePose || animatorStateID == WalkRunStrafe.STATE_WalkLeft || animatorStateID == WalkRunStrafe.STATE_WalkRight || animatorTransitionID == WalkRunStrafe.TRANS_EntryState_RunFwdLoop || animatorTransitionID == WalkRunStrafe.TRANS_AnyState_RunFwdLoop || animatorTransitionID == WalkRunStrafe.TRANS_EntryState_WalkFwdLoop || animatorTransitionID == WalkRunStrafe.TRANS_AnyState_WalkFwdLoop || animatorTransitionID == WalkRunStrafe.TRANS_EntryState_IdlePose || animatorTransitionID == WalkRunStrafe.TRANS_AnyState_IdlePose || animatorTransitionID == WalkRunStrafe.TRANS_IdleToWalk_WalkToIdle || animatorTransitionID == WalkRunStrafe.TRANS_IdleToWalk_WalkFwdLoop || animatorTransitionID == WalkRunStrafe.TRANS_IdleToRun_RunFwdLoop || animatorTransitionID == WalkRunStrafe.TRANS_IdleToRun_RunStop_LDown || animatorTransitionID == WalkRunStrafe.TRANS_RunFwdLoop_RunStop_RDown || animatorTransitionID == WalkRunStrafe.TRANS_RunFwdLoop_RunStop_LDown || animatorTransitionID == WalkRunStrafe.TRANS_RunFwdLoop_WalkFwdLoop || animatorTransitionID == WalkRunStrafe.TRANS_WalkToIdle_RDown_IdlePose || animatorTransitionID == WalkRunStrafe.TRANS_WalkToIdle_RDown_WalkFwdLoop || animatorTransitionID == WalkRunStrafe.TRANS_WalkToIdle_LDown_IdlePose || animatorTransitionID == WalkRunStrafe.TRANS_WalkToIdle_LDown_WalkFwdLoop || animatorTransitionID == WalkRunStrafe.TRANS_RunStop_RDown_RunFwdLoop || animatorTransitionID == WalkRunStrafe.TRANS_RunStop_RDown_IdlePose || animatorTransitionID == WalkRunStrafe.TRANS_RunStop_LDown_RunFwdLoop || animatorTransitionID == WalkRunStrafe.TRANS_RunStop_LDown_IdlePose || animatorTransitionID == WalkRunStrafe.TRANS_WalkToIdle_IdlePose || animatorTransitionID == WalkRunStrafe.TRANS_WalkFwdLoop_WalkBackward || animatorTransitionID == WalkRunStrafe.TRANS_WalkFwdLoop_WalkLeft || animatorTransitionID == WalkRunStrafe.TRANS_WalkFwdLoop_WalkRight || animatorTransitionID == WalkRunStrafe.TRANS_WalkFwdLoop_RunFwdLoop || animatorTransitionID == WalkRunStrafe.TRANS_WalkFwdLoop_WalkToIdle_LDown || animatorTransitionID == WalkRunStrafe.TRANS_WalkFwdLoop_WalkToIdle_RDown || animatorTransitionID == WalkRunStrafe.TRANS_WalkBackward_WalkFwdLoop || animatorTransitionID == WalkRunStrafe.TRANS_WalkBackward_IdlePose || animatorTransitionID == WalkRunStrafe.TRANS_WalkBackward_WalkLeft || animatorTransitionID == WalkRunStrafe.TRANS_WalkBackward_WalkRight || animatorTransitionID == WalkRunStrafe.TRANS_IdlePose_WalkBackward || animatorTransitionID == WalkRunStrafe.TRANS_IdlePose_WalkLeft || animatorTransitionID == WalkRunStrafe.TRANS_IdlePose_WalkRight || animatorTransitionID == WalkRunStrafe.TRANS_IdlePose_IdleToWalk || animatorTransitionID == WalkRunStrafe.TRANS_IdlePose_IdleToRun || animatorTransitionID == WalkRunStrafe.TRANS_WalkLeft_WalkBackward || animatorTransitionID == WalkRunStrafe.TRANS_WalkLeft_WalkFwdLoop || animatorTransitionID == WalkRunStrafe.TRANS_WalkLeft_WalkRight || animatorTransitionID == WalkRunStrafe.TRANS_WalkLeft_IdlePose || animatorTransitionID == WalkRunStrafe.TRANS_WalkRight_WalkFwdLoop || animatorTransitionID == WalkRunStrafe.TRANS_WalkRight_WalkBackward || animatorTransitionID == WalkRunStrafe.TRANS_WalkRight_WalkLeft || animatorTransitionID == WalkRunStrafe.TRANS_WalkRight_IdlePose;
			}
		}

		// Token: 0x06001179 RID: 4473 RVA: 0x00061E28 File Offset: 0x00060028
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == WalkRunStrafe.STATE_IdleToWalk || rStateID == WalkRunStrafe.STATE_IdleToRun || rStateID == WalkRunStrafe.STATE_RunFwdLoop || rStateID == WalkRunStrafe.STATE_WalkToIdle_RDown || rStateID == WalkRunStrafe.STATE_WalkToIdle_LDown || rStateID == WalkRunStrafe.STATE_RunStop_RDown || rStateID == WalkRunStrafe.STATE_RunStop_LDown || rStateID == WalkRunStrafe.STATE_WalkToIdle || rStateID == WalkRunStrafe.STATE_WalkFwdLoop || rStateID == WalkRunStrafe.STATE_WalkBackward || rStateID == WalkRunStrafe.STATE_IdlePose || rStateID == WalkRunStrafe.STATE_WalkLeft || rStateID == WalkRunStrafe.STATE_WalkRight;
		}

		// Token: 0x0600117A RID: 4474 RVA: 0x00061EB8 File Offset: 0x000600B8
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == WalkRunStrafe.STATE_IdleToWalk || rStateID == WalkRunStrafe.STATE_IdleToRun || rStateID == WalkRunStrafe.STATE_RunFwdLoop || rStateID == WalkRunStrafe.STATE_WalkToIdle_RDown || rStateID == WalkRunStrafe.STATE_WalkToIdle_LDown || rStateID == WalkRunStrafe.STATE_RunStop_RDown || rStateID == WalkRunStrafe.STATE_RunStop_LDown || rStateID == WalkRunStrafe.STATE_WalkToIdle || rStateID == WalkRunStrafe.STATE_WalkFwdLoop || rStateID == WalkRunStrafe.STATE_WalkBackward || rStateID == WalkRunStrafe.STATE_IdlePose || rStateID == WalkRunStrafe.STATE_WalkLeft || rStateID == WalkRunStrafe.STATE_WalkRight || rTransitionID == WalkRunStrafe.TRANS_EntryState_RunFwdLoop || rTransitionID == WalkRunStrafe.TRANS_AnyState_RunFwdLoop || rTransitionID == WalkRunStrafe.TRANS_EntryState_WalkFwdLoop || rTransitionID == WalkRunStrafe.TRANS_AnyState_WalkFwdLoop || rTransitionID == WalkRunStrafe.TRANS_EntryState_IdlePose || rTransitionID == WalkRunStrafe.TRANS_AnyState_IdlePose || rTransitionID == WalkRunStrafe.TRANS_IdleToWalk_WalkToIdle || rTransitionID == WalkRunStrafe.TRANS_IdleToWalk_WalkFwdLoop || rTransitionID == WalkRunStrafe.TRANS_IdleToRun_RunFwdLoop || rTransitionID == WalkRunStrafe.TRANS_IdleToRun_RunStop_LDown || rTransitionID == WalkRunStrafe.TRANS_RunFwdLoop_RunStop_RDown || rTransitionID == WalkRunStrafe.TRANS_RunFwdLoop_RunStop_LDown || rTransitionID == WalkRunStrafe.TRANS_RunFwdLoop_WalkFwdLoop || rTransitionID == WalkRunStrafe.TRANS_WalkToIdle_RDown_IdlePose || rTransitionID == WalkRunStrafe.TRANS_WalkToIdle_RDown_WalkFwdLoop || rTransitionID == WalkRunStrafe.TRANS_WalkToIdle_LDown_IdlePose || rTransitionID == WalkRunStrafe.TRANS_WalkToIdle_LDown_WalkFwdLoop || rTransitionID == WalkRunStrafe.TRANS_RunStop_RDown_RunFwdLoop || rTransitionID == WalkRunStrafe.TRANS_RunStop_RDown_IdlePose || rTransitionID == WalkRunStrafe.TRANS_RunStop_LDown_RunFwdLoop || rTransitionID == WalkRunStrafe.TRANS_RunStop_LDown_IdlePose || rTransitionID == WalkRunStrafe.TRANS_WalkToIdle_IdlePose || rTransitionID == WalkRunStrafe.TRANS_WalkFwdLoop_WalkBackward || rTransitionID == WalkRunStrafe.TRANS_WalkFwdLoop_WalkLeft || rTransitionID == WalkRunStrafe.TRANS_WalkFwdLoop_WalkRight || rTransitionID == WalkRunStrafe.TRANS_WalkFwdLoop_RunFwdLoop || rTransitionID == WalkRunStrafe.TRANS_WalkFwdLoop_WalkToIdle_LDown || rTransitionID == WalkRunStrafe.TRANS_WalkFwdLoop_WalkToIdle_RDown || rTransitionID == WalkRunStrafe.TRANS_WalkBackward_WalkFwdLoop || rTransitionID == WalkRunStrafe.TRANS_WalkBackward_IdlePose || rTransitionID == WalkRunStrafe.TRANS_WalkBackward_WalkLeft || rTransitionID == WalkRunStrafe.TRANS_WalkBackward_WalkRight || rTransitionID == WalkRunStrafe.TRANS_IdlePose_WalkBackward || rTransitionID == WalkRunStrafe.TRANS_IdlePose_WalkLeft || rTransitionID == WalkRunStrafe.TRANS_IdlePose_WalkRight || rTransitionID == WalkRunStrafe.TRANS_IdlePose_IdleToWalk || rTransitionID == WalkRunStrafe.TRANS_IdlePose_IdleToRun || rTransitionID == WalkRunStrafe.TRANS_WalkLeft_WalkBackward || rTransitionID == WalkRunStrafe.TRANS_WalkLeft_WalkFwdLoop || rTransitionID == WalkRunStrafe.TRANS_WalkLeft_WalkRight || rTransitionID == WalkRunStrafe.TRANS_WalkLeft_IdlePose || rTransitionID == WalkRunStrafe.TRANS_WalkRight_WalkFwdLoop || rTransitionID == WalkRunStrafe.TRANS_WalkRight_WalkBackward || rTransitionID == WalkRunStrafe.TRANS_WalkRight_WalkLeft || rTransitionID == WalkRunStrafe.TRANS_WalkRight_IdlePose;
		}

		// Token: 0x0600117B RID: 4475 RVA: 0x0006210C File Offset: 0x0006030C
		public override void LoadAnimatorData()
		{
			WalkRunStrafe.TRANS_EntryState_RunFwdLoop = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunStrafe-SM.RunFwdLoop");
			WalkRunStrafe.TRANS_AnyState_RunFwdLoop = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunStrafe-SM.RunFwdLoop");
			WalkRunStrafe.TRANS_EntryState_WalkFwdLoop = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunStrafe-SM.WalkFwdLoop");
			WalkRunStrafe.TRANS_AnyState_WalkFwdLoop = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunStrafe-SM.WalkFwdLoop");
			WalkRunStrafe.TRANS_EntryState_IdlePose = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunStrafe-SM.IdlePose");
			WalkRunStrafe.TRANS_AnyState_IdlePose = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunStrafe-SM.IdlePose");
			WalkRunStrafe.STATE_IdleToWalk = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.IdleToWalk");
			WalkRunStrafe.TRANS_IdleToWalk_WalkToIdle = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.IdleToWalk -> Base Layer.WalkRunStrafe-SM.WalkToIdle");
			WalkRunStrafe.TRANS_IdleToWalk_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.IdleToWalk -> Base Layer.WalkRunStrafe-SM.WalkFwdLoop");
			WalkRunStrafe.STATE_IdleToRun = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.IdleToRun");
			WalkRunStrafe.TRANS_IdleToRun_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.IdleToRun -> Base Layer.WalkRunStrafe-SM.RunFwdLoop");
			WalkRunStrafe.TRANS_IdleToRun_RunStop_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.IdleToRun -> Base Layer.WalkRunStrafe-SM.RunStop_LDown");
			WalkRunStrafe.STATE_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.RunFwdLoop");
			WalkRunStrafe.TRANS_RunFwdLoop_RunStop_RDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.RunFwdLoop -> Base Layer.WalkRunStrafe-SM.RunStop_RDown");
			WalkRunStrafe.TRANS_RunFwdLoop_RunStop_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.RunFwdLoop -> Base Layer.WalkRunStrafe-SM.RunStop_LDown");
			WalkRunStrafe.TRANS_RunFwdLoop_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.RunFwdLoop -> Base Layer.WalkRunStrafe-SM.WalkFwdLoop");
			WalkRunStrafe.STATE_WalkToIdle_RDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkToIdle_RDown");
			WalkRunStrafe.TRANS_WalkToIdle_RDown_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkToIdle_RDown -> Base Layer.WalkRunStrafe-SM.IdlePose");
			WalkRunStrafe.TRANS_WalkToIdle_RDown_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkToIdle_RDown -> Base Layer.WalkRunStrafe-SM.WalkFwdLoop");
			WalkRunStrafe.STATE_WalkToIdle_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkToIdle_LDown");
			WalkRunStrafe.TRANS_WalkToIdle_LDown_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkToIdle_LDown -> Base Layer.WalkRunStrafe-SM.IdlePose");
			WalkRunStrafe.TRANS_WalkToIdle_LDown_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkToIdle_LDown -> Base Layer.WalkRunStrafe-SM.WalkFwdLoop");
			WalkRunStrafe.STATE_RunStop_RDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.RunStop_RDown");
			WalkRunStrafe.TRANS_RunStop_RDown_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.RunStop_RDown -> Base Layer.WalkRunStrafe-SM.RunFwdLoop");
			WalkRunStrafe.TRANS_RunStop_RDown_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.RunStop_RDown -> Base Layer.WalkRunStrafe-SM.IdlePose");
			WalkRunStrafe.STATE_RunStop_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.RunStop_LDown");
			WalkRunStrafe.TRANS_RunStop_LDown_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.RunStop_LDown -> Base Layer.WalkRunStrafe-SM.RunFwdLoop");
			WalkRunStrafe.TRANS_RunStop_LDown_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.RunStop_LDown -> Base Layer.WalkRunStrafe-SM.IdlePose");
			WalkRunStrafe.STATE_WalkToIdle = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkToIdle");
			WalkRunStrafe.TRANS_WalkToIdle_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkToIdle -> Base Layer.WalkRunStrafe-SM.IdlePose");
			WalkRunStrafe.STATE_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkFwdLoop");
			WalkRunStrafe.TRANS_WalkFwdLoop_WalkBackward = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkFwdLoop -> Base Layer.WalkRunStrafe-SM.WalkBackward");
			WalkRunStrafe.TRANS_WalkFwdLoop_WalkLeft = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkFwdLoop -> Base Layer.WalkRunStrafe-SM.WalkLeft");
			WalkRunStrafe.TRANS_WalkFwdLoop_WalkRight = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkFwdLoop -> Base Layer.WalkRunStrafe-SM.WalkRight");
			WalkRunStrafe.TRANS_WalkFwdLoop_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkFwdLoop -> Base Layer.WalkRunStrafe-SM.RunFwdLoop");
			WalkRunStrafe.TRANS_WalkFwdLoop_WalkToIdle_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkFwdLoop -> Base Layer.WalkRunStrafe-SM.WalkToIdle_LDown");
			WalkRunStrafe.TRANS_WalkFwdLoop_WalkToIdle_RDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkFwdLoop -> Base Layer.WalkRunStrafe-SM.WalkToIdle_RDown");
			WalkRunStrafe.STATE_WalkBackward = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkBackward");
			WalkRunStrafe.TRANS_WalkBackward_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkBackward -> Base Layer.WalkRunStrafe-SM.WalkFwdLoop");
			WalkRunStrafe.TRANS_WalkBackward_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkBackward -> Base Layer.WalkRunStrafe-SM.IdlePose");
			WalkRunStrafe.TRANS_WalkBackward_WalkLeft = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkBackward -> Base Layer.WalkRunStrafe-SM.WalkLeft");
			WalkRunStrafe.TRANS_WalkBackward_WalkRight = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkBackward -> Base Layer.WalkRunStrafe-SM.WalkRight");
			WalkRunStrafe.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.IdlePose");
			WalkRunStrafe.TRANS_IdlePose_WalkBackward = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.IdlePose -> Base Layer.WalkRunStrafe-SM.WalkBackward");
			WalkRunStrafe.TRANS_IdlePose_WalkLeft = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.IdlePose -> Base Layer.WalkRunStrafe-SM.WalkLeft");
			WalkRunStrafe.TRANS_IdlePose_WalkRight = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.IdlePose -> Base Layer.WalkRunStrafe-SM.WalkRight");
			WalkRunStrafe.TRANS_IdlePose_IdleToWalk = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.IdlePose -> Base Layer.WalkRunStrafe-SM.IdleToWalk");
			WalkRunStrafe.TRANS_IdlePose_IdleToRun = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.IdlePose -> Base Layer.WalkRunStrafe-SM.IdleToRun");
			WalkRunStrafe.STATE_WalkLeft = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkLeft");
			WalkRunStrafe.TRANS_WalkLeft_WalkBackward = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkLeft -> Base Layer.WalkRunStrafe-SM.WalkBackward");
			WalkRunStrafe.TRANS_WalkLeft_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkLeft -> Base Layer.WalkRunStrafe-SM.WalkFwdLoop");
			WalkRunStrafe.TRANS_WalkLeft_WalkRight = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkLeft -> Base Layer.WalkRunStrafe-SM.WalkRight");
			WalkRunStrafe.TRANS_WalkLeft_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkLeft -> Base Layer.WalkRunStrafe-SM.IdlePose");
			WalkRunStrafe.STATE_WalkRight = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkRight");
			WalkRunStrafe.TRANS_WalkRight_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkRight -> Base Layer.WalkRunStrafe-SM.WalkFwdLoop");
			WalkRunStrafe.TRANS_WalkRight_WalkBackward = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkRight -> Base Layer.WalkRunStrafe-SM.WalkBackward");
			WalkRunStrafe.TRANS_WalkRight_WalkLeft = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkRight -> Base Layer.WalkRunStrafe-SM.WalkLeft");
			WalkRunStrafe.TRANS_WalkRight_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe-SM.WalkRight -> Base Layer.WalkRunStrafe-SM.IdlePose");
		}

		// Token: 0x04000CFF RID: 3327
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000D00 RID: 3328
		public const int PHASE_START = 1100;

		// Token: 0x04000D01 RID: 3329
		public const int PHASE_START_RUN = 1110;

		// Token: 0x04000D02 RID: 3330
		public const int PHASE_START_SHORTCUT_WALK = 1114;

		// Token: 0x04000D03 RID: 3331
		public const int PHASE_START_SHORTCUT_RUN = 1115;

		// Token: 0x04000D04 RID: 3332
		public const int PHASE_STOP_RIGHT_DOWN = 1120;

		// Token: 0x04000D05 RID: 3333
		public const int PHASE_STOP_LEFT_DOWN = 1121;

		// Token: 0x04000D06 RID: 3334
		public bool _DefaultToRun;

		// Token: 0x04000D07 RID: 3335
		public bool _ActivateWithAltCameraMode;

		// Token: 0x04000D08 RID: 3336
		public bool _RotateWithInput = true;

		// Token: 0x04000D09 RID: 3337
		public bool _RotateWithView;

		// Token: 0x04000D0A RID: 3338
		public float _RotationSpeed = 120f;

		// Token: 0x04000D0B RID: 3339
		public float _RotationSmoothing = 0.1f;

		// Token: 0x04000D0C RID: 3340
		public string _RotateActionAlias = "ActivateRotation";

		// Token: 0x04000D0D RID: 3341
		public bool _ForceViewOnInput;

		// Token: 0x04000D0E RID: 3342
		public bool _RemoveLateralMovement = true;

		// Token: 0x04000D0F RID: 3343
		private bool mStartInMove;

		// Token: 0x04000D10 RID: 3344
		private bool mStartInWalk;

		// Token: 0x04000D11 RID: 3345
		private bool mStartInRun;

		// Token: 0x04000D12 RID: 3346
		protected bool mClearRangedStance = true;

		// Token: 0x04000D13 RID: 3347
		protected float mDegreesPer60FPSTick = 1f;

		// Token: 0x04000D14 RID: 3348
		protected float mYaw;

		// Token: 0x04000D15 RID: 3349
		protected float mYawTarget;

		// Token: 0x04000D16 RID: 3350
		protected float mYawVelocity;

		// Token: 0x04000D17 RID: 3351
		public static int TRANS_EntryState_RunFwdLoop = -1;

		// Token: 0x04000D18 RID: 3352
		public static int TRANS_AnyState_RunFwdLoop = -1;

		// Token: 0x04000D19 RID: 3353
		public static int TRANS_EntryState_WalkFwdLoop = -1;

		// Token: 0x04000D1A RID: 3354
		public static int TRANS_AnyState_WalkFwdLoop = -1;

		// Token: 0x04000D1B RID: 3355
		public static int TRANS_EntryState_IdlePose = -1;

		// Token: 0x04000D1C RID: 3356
		public static int TRANS_AnyState_IdlePose = -1;

		// Token: 0x04000D1D RID: 3357
		public static int STATE_IdleToWalk = -1;

		// Token: 0x04000D1E RID: 3358
		public static int TRANS_IdleToWalk_WalkToIdle = -1;

		// Token: 0x04000D1F RID: 3359
		public static int TRANS_IdleToWalk_WalkFwdLoop = -1;

		// Token: 0x04000D20 RID: 3360
		public static int STATE_IdleToRun = -1;

		// Token: 0x04000D21 RID: 3361
		public static int TRANS_IdleToRun_RunFwdLoop = -1;

		// Token: 0x04000D22 RID: 3362
		public static int TRANS_IdleToRun_RunStop_LDown = -1;

		// Token: 0x04000D23 RID: 3363
		public static int STATE_RunFwdLoop = -1;

		// Token: 0x04000D24 RID: 3364
		public static int TRANS_RunFwdLoop_RunStop_RDown = -1;

		// Token: 0x04000D25 RID: 3365
		public static int TRANS_RunFwdLoop_RunStop_LDown = -1;

		// Token: 0x04000D26 RID: 3366
		public static int TRANS_RunFwdLoop_WalkFwdLoop = -1;

		// Token: 0x04000D27 RID: 3367
		public static int STATE_WalkToIdle_RDown = -1;

		// Token: 0x04000D28 RID: 3368
		public static int TRANS_WalkToIdle_RDown_IdlePose = -1;

		// Token: 0x04000D29 RID: 3369
		public static int TRANS_WalkToIdle_RDown_WalkFwdLoop = -1;

		// Token: 0x04000D2A RID: 3370
		public static int STATE_WalkToIdle_LDown = -1;

		// Token: 0x04000D2B RID: 3371
		public static int TRANS_WalkToIdle_LDown_IdlePose = -1;

		// Token: 0x04000D2C RID: 3372
		public static int TRANS_WalkToIdle_LDown_WalkFwdLoop = -1;

		// Token: 0x04000D2D RID: 3373
		public static int STATE_RunStop_RDown = -1;

		// Token: 0x04000D2E RID: 3374
		public static int TRANS_RunStop_RDown_RunFwdLoop = -1;

		// Token: 0x04000D2F RID: 3375
		public static int TRANS_RunStop_RDown_IdlePose = -1;

		// Token: 0x04000D30 RID: 3376
		public static int STATE_RunStop_LDown = -1;

		// Token: 0x04000D31 RID: 3377
		public static int TRANS_RunStop_LDown_RunFwdLoop = -1;

		// Token: 0x04000D32 RID: 3378
		public static int TRANS_RunStop_LDown_IdlePose = -1;

		// Token: 0x04000D33 RID: 3379
		public static int STATE_WalkToIdle = -1;

		// Token: 0x04000D34 RID: 3380
		public static int TRANS_WalkToIdle_IdlePose = -1;

		// Token: 0x04000D35 RID: 3381
		public static int STATE_WalkFwdLoop = -1;

		// Token: 0x04000D36 RID: 3382
		public static int TRANS_WalkFwdLoop_WalkBackward = -1;

		// Token: 0x04000D37 RID: 3383
		public static int TRANS_WalkFwdLoop_WalkLeft = -1;

		// Token: 0x04000D38 RID: 3384
		public static int TRANS_WalkFwdLoop_WalkRight = -1;

		// Token: 0x04000D39 RID: 3385
		public static int TRANS_WalkFwdLoop_RunFwdLoop = -1;

		// Token: 0x04000D3A RID: 3386
		public static int TRANS_WalkFwdLoop_WalkToIdle_LDown = -1;

		// Token: 0x04000D3B RID: 3387
		public static int TRANS_WalkFwdLoop_WalkToIdle_RDown = -1;

		// Token: 0x04000D3C RID: 3388
		public static int STATE_WalkBackward = -1;

		// Token: 0x04000D3D RID: 3389
		public static int TRANS_WalkBackward_WalkFwdLoop = -1;

		// Token: 0x04000D3E RID: 3390
		public static int TRANS_WalkBackward_IdlePose = -1;

		// Token: 0x04000D3F RID: 3391
		public static int TRANS_WalkBackward_WalkLeft = -1;

		// Token: 0x04000D40 RID: 3392
		public static int TRANS_WalkBackward_WalkRight = -1;

		// Token: 0x04000D41 RID: 3393
		public static int STATE_IdlePose = -1;

		// Token: 0x04000D42 RID: 3394
		public static int TRANS_IdlePose_WalkBackward = -1;

		// Token: 0x04000D43 RID: 3395
		public static int TRANS_IdlePose_WalkLeft = -1;

		// Token: 0x04000D44 RID: 3396
		public static int TRANS_IdlePose_WalkRight = -1;

		// Token: 0x04000D45 RID: 3397
		public static int TRANS_IdlePose_IdleToWalk = -1;

		// Token: 0x04000D46 RID: 3398
		public static int TRANS_IdlePose_IdleToRun = -1;

		// Token: 0x04000D47 RID: 3399
		public static int STATE_WalkLeft = -1;

		// Token: 0x04000D48 RID: 3400
		public static int TRANS_WalkLeft_WalkBackward = -1;

		// Token: 0x04000D49 RID: 3401
		public static int TRANS_WalkLeft_WalkFwdLoop = -1;

		// Token: 0x04000D4A RID: 3402
		public static int TRANS_WalkLeft_WalkRight = -1;

		// Token: 0x04000D4B RID: 3403
		public static int TRANS_WalkLeft_IdlePose = -1;

		// Token: 0x04000D4C RID: 3404
		public static int STATE_WalkRight = -1;

		// Token: 0x04000D4D RID: 3405
		public static int TRANS_WalkRight_WalkFwdLoop = -1;

		// Token: 0x04000D4E RID: 3406
		public static int TRANS_WalkRight_WalkBackward = -1;

		// Token: 0x04000D4F RID: 3407
		public static int TRANS_WalkRight_WalkLeft = -1;

		// Token: 0x04000D50 RID: 3408
		public static int TRANS_WalkRight_IdlePose = -1;
	}
}
