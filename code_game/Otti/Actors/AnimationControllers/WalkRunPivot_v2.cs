using System;
using com.ootii.Cameras;
using com.ootii.Geometry;
using com.ootii.Helpers;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x02000117 RID: 279
	[MotionName("Walk Run Pivot")]
	[MotionDescription("Standard movement (walk/run) for an adventure game.")]
	public class WalkRunPivot_v2 : MotionControllerMotion, IWalkRunMotion
	{
		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x060010BD RID: 4285 RVA: 0x0005B5C3 File Offset: 0x000597C3
		// (set) Token: 0x060010BE RID: 4286 RVA: 0x0005B5CB File Offset: 0x000597CB
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

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x060010BF RID: 4287 RVA: 0x0005B5D4 File Offset: 0x000597D4
		// (set) Token: 0x060010C0 RID: 4288 RVA: 0x0005B5DC File Offset: 0x000597DC
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

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x060010C1 RID: 4289 RVA: 0x0005B5E5 File Offset: 0x000597E5
		// (set) Token: 0x060010C2 RID: 4290 RVA: 0x0005B5ED File Offset: 0x000597ED
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

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x060010C3 RID: 4291 RVA: 0x0005B5F6 File Offset: 0x000597F6
		// (set) Token: 0x060010C4 RID: 4292 RVA: 0x0005B5FE File Offset: 0x000597FE
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

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x060010C5 RID: 4293 RVA: 0x0005B607 File Offset: 0x00059807
		// (set) Token: 0x060010C6 RID: 4294 RVA: 0x0005B60F File Offset: 0x0005980F
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

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x060010C7 RID: 4295 RVA: 0x0005B618 File Offset: 0x00059818
		// (set) Token: 0x060010C8 RID: 4296 RVA: 0x0005B620 File Offset: 0x00059820
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

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x060010C9 RID: 4297 RVA: 0x0005B629 File Offset: 0x00059829
		// (set) Token: 0x060010CA RID: 4298 RVA: 0x0005B631 File Offset: 0x00059831
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

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x060010CB RID: 4299 RVA: 0x0005B63A File Offset: 0x0005983A
		// (set) Token: 0x060010CC RID: 4300 RVA: 0x0005B642 File Offset: 0x00059842
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

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x060010CD RID: 4301 RVA: 0x0005B64B File Offset: 0x0005984B
		// (set) Token: 0x060010CE RID: 4302 RVA: 0x0005B653 File Offset: 0x00059853
		public bool StartInWalk
		{
			get
			{
				return this.mStartInWalk;
			}
			set
			{
				this.mStartInWalk = value;
				if (value)
				{
					this.mStartInMove = value;
				}
			}
		}

		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x060010CF RID: 4303 RVA: 0x0005B666 File Offset: 0x00059866
		// (set) Token: 0x060010D0 RID: 4304 RVA: 0x0005B66E File Offset: 0x0005986E
		public bool StartInRun
		{
			get
			{
				return this.mStartInRun;
			}
			set
			{
				this.mStartInRun = value;
				if (value)
				{
					this.mStartInMove = value;
				}
			}
		}

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x060010D1 RID: 4305 RVA: 0x0005B681 File Offset: 0x00059881
		// (set) Token: 0x060010D2 RID: 4306 RVA: 0x0005B689 File Offset: 0x00059889
		public bool UseStartTransitions
		{
			get
			{
				return this._UseStartTransitions;
			}
			set
			{
				this._UseStartTransitions = value;
			}
		}

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x060010D3 RID: 4307 RVA: 0x0005B692 File Offset: 0x00059892
		// (set) Token: 0x060010D4 RID: 4308 RVA: 0x0005B69A File Offset: 0x0005989A
		public bool UseStopTransitions
		{
			get
			{
				return this._UseStopTransitions;
			}
			set
			{
				this._UseStopTransitions = value;
			}
		}

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x060010D5 RID: 4309 RVA: 0x0005B6A3 File Offset: 0x000598A3
		// (set) Token: 0x060010D6 RID: 4310 RVA: 0x0005B6AB File Offset: 0x000598AB
		public bool UseTapToPivot
		{
			get
			{
				return this._UseTapToPivot;
			}
			set
			{
				this._UseTapToPivot = value;
			}
		}

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x060010D7 RID: 4311 RVA: 0x0005B6B4 File Offset: 0x000598B4
		// (set) Token: 0x060010D8 RID: 4312 RVA: 0x0005B6BC File Offset: 0x000598BC
		public float TapToPivotDelay
		{
			get
			{
				return this._TapToPivotDelay;
			}
			set
			{
				this._TapToPivotDelay = value;
			}
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x060010D9 RID: 4313 RVA: 0x0005B6C5 File Offset: 0x000598C5
		// (set) Token: 0x060010DA RID: 4314 RVA: 0x0005B6CD File Offset: 0x000598CD
		public float MinPivotAngle
		{
			get
			{
				return this._MinPivotAngle;
			}
			set
			{
				this._MinPivotAngle = value;
			}
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x060010DB RID: 4315 RVA: 0x0005B6D6 File Offset: 0x000598D6
		// (set) Token: 0x060010DC RID: 4316 RVA: 0x0005B6DE File Offset: 0x000598DE
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

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x060010DD RID: 4317 RVA: 0x0005B71C File Offset: 0x0005991C
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

		// Token: 0x060010DE RID: 4318 RVA: 0x0005B7A8 File Offset: 0x000599A8
		public WalkRunPivot_v2()
		{
			this._Category = 2;
			this._Priority = 5f;
			this._ActionAlias = "Run";
		}

		// Token: 0x060010DF RID: 4319 RVA: 0x0005BB2C File Offset: 0x00059D2C
		public WalkRunPivot_v2(MotionController rController)
			: base(rController)
		{
			this._Category = 2;
			this._Priority = 5f;
			this._ActionAlias = "Run";
		}

		// Token: 0x060010E0 RID: 4320 RVA: 0x0005BEAE File Offset: 0x0005A0AE
		public override void Awake()
		{
			base.Awake();
			this.SmoothingSamples = this._SmoothingSamples;
		}

		// Token: 0x060010E1 RID: 4321 RVA: 0x0005BEC4 File Offset: 0x0005A0C4
		public override bool TestActivate()
		{
			if (!this.mIsStartable || !this.mMotionController.IsGrounded || this.mMotionController.Stance != 0)
			{
				this.mStartInPivot = false;
				this.mLastTapStartTime = 0f;
				return false;
			}
			if (this._FormCondition >= 0 && this.mMotionController.CurrentForm != this._FormCondition)
			{
				return false;
			}
			bool flag = this._UseTapToPivot && (this.mLastTapStartTime > 0f || Mathf.Abs(this.mMotionController.State.InputFromAvatarAngle) > this._MinPivotAngle);
			bool flag2 = this._UseTapToPivot && this.mMotionLayer.ActiveMotion != null && this.mMotionLayer.ActiveMotion.Category == 1;
			if (this._UseTapToPivot && flag && flag2)
			{
				if (this.mMotionController.State.InputMagnitudeTrend.Value > 0.1f)
				{
					if (this.mLastTapStartTime == 0f)
					{
						this.mLastTapStartTime = Time.time;
						this.mLastTapInputForward = this.mMotionController.State.InputForward;
						this.mLastTapInputFromAvatarAngle = this.mMotionController.State.InputFromAvatarAngle;
						return true;
					}
					if (this.mLastTapStartTime + this._TapToPivotDelay <= Time.time)
					{
						this.mStartInPivot = false;
						this.mLastTapStartTime = 0f;
						return true;
					}
					return false;
				}
				else if (this.mLastTapStartTime > 0f)
				{
					this.mStartInPivot = true;
					this.mLastTapStartTime = 0f;
					return true;
				}
			}
			else
			{
				this.mStartInPivot = false;
				this.mLastTapStartTime = 0f;
				if (this.mMotionController.State.InputMagnitudeTrend.Value > 0.49f)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060010E2 RID: 4322 RVA: 0x0005C078 File Offset: 0x0005A278
		public override bool TestUpdate()
		{
			return this.mIsActivatedFrame || this.mLastTapStartTime > 0f || (this.mMotionController.IsGrounded && this.mMotionLayer._AnimatorStateID != this.STATE_IdlePose && (this.mMotionLayer._AnimatorStateID != this.STATE_IdleTurnEndPose || this.mMotionController.State.InputMagnitudeTrend.Value >= 0.1f) && (!this.mIsAnimatorActive || this.IsInMotionState) && (this.mMotionController.State.InputMagnitudeTrend.Average >= 0.1f || this.mMotionLayer._AnimatorStateID != this.STATE_MoveTree || this.mMotionLayer._AnimatorTransitionID != 0));
		}

		// Token: 0x060010E3 RID: 4323 RVA: 0x0005C144 File Offset: 0x0005A344
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			this.mMotionController.ForcedInput.x = this.mInputX.Average;
			this.mMotionController.ForcedInput.y = this.mInputY.Average;
			return true;
		}

		// Token: 0x060010E4 RID: 4324 RVA: 0x0005C17D File Offset: 0x0005A37D
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			if (this.mLastTapStartTime == 0f)
			{
				this.DelayedActivate();
			}
			return base.Activate(rPrevMotion);
		}

		// Token: 0x060010E5 RID: 4325 RVA: 0x0005C19C File Offset: 0x0005A39C
		public void DelayedActivate()
		{
			this.mExitPhaseID = 0;
			this.mSavedInputForward = this.mMotionController.State.InputForward;
			this.mMotionController.MaxSpeed = 5.668f;
			if (this.mStartInPivot)
			{
				this.mMotionController.State.InputFromAvatarAngle = this.mLastTapInputFromAvatarAngle;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 27135, 0, true);
			}
			else if (this.mStartInMove)
			{
				this.mStartInMove = false;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 27130, 1, true);
			}
			else if (this.mMotionController._InputSource == null)
			{
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 27130, this._UseStartTransitions ? 0 : 1, true);
			}
			else
			{
				MotionState state = this.mMotionController.State;
				float inputX = state.InputX;
				float inputY = state.InputY;
				float value = state.InputMagnitudeTrend.Value;
				InputManagerHelper.ConvertToRadialInput(ref inputX, ref inputY, ref value, this.IsRunActive ? 1f : 0.5f);
				if (inputX != 0f || inputY < 0f)
				{
					this.mInputX.Clear(inputX);
					this.mInputY.Clear(inputY);
					this.mInputMagnitude.Clear(value);
				}
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 27130, this._UseStartTransitions ? 0 : 1, true);
			}
			if (this._RotateWithCamera && this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
				BaseCameraRig baseCameraRig2 = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig2.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Combine(baseCameraRig2.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
		}

		// Token: 0x060010E6 RID: 4326 RVA: 0x0005C3A0 File Offset: 0x0005A5A0
		public override void Deactivate()
		{
			this.mLastTapStartTime = 0f;
			this.mLastTapInputFromAvatarAngle = 0f;
			this.mStartInPivot = false;
			this.mStartInRun = false;
			this.mStartInWalk = false;
			if (this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			base.Deactivate();
		}

		// Token: 0x060010E7 RID: 4327 RVA: 0x0005C424 File Offset: 0x0005A624
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			if (this.mLastTapStartTime > 0f)
			{
				return;
			}
			if (this.mMotionLayer._AnimatorTransitionID == this.TRANS_EntryState_MoveTree)
			{
				rRotation = Quaternion.identity;
				rMovement = rMovement.normalized * (this.mActorController.PrevState.Velocity.magnitude * Time.deltaTime);
				rMovement.x = 0f;
				rMovement.y = 0f;
				if (rMovement.z < 0f)
				{
					rMovement.z = 0f;
					return;
				}
			}
			else if (this.mMotionLayer._AnimatorStateID == this.STATE_MoveTree && this.mMotionLayer._AnimatorTransitionID == 0)
			{
				rRotation = Quaternion.identity;
				float num = (this.IsRunActive ? this._RunSpeed : this._WalkSpeed);
				if (num > 0f)
				{
					if (rMovement.sqrMagnitude > 0f)
					{
						rMovement = rMovement.normalized * (num * rDeltaTime);
					}
					else
					{
						Vector3 vector = new Vector3(0f, 0f, 1f);
						rMovement = vector.normalized * (num * rDeltaTime);
					}
				}
				rMovement.x = 0f;
				rMovement.y = 0f;
				if (rMovement.z < 0f)
				{
					rMovement.z = 0f;
					return;
				}
			}
			else
			{
				if (this._UseTapToPivot && this.IsIdlePivoting())
				{
					rMovement = Vector3.zero;
					return;
				}
				if (this.IsStopping())
				{
					rMovement *= 0.5f;
				}
			}
		}

		// Token: 0x060010E8 RID: 4328 RVA: 0x0005C5C4 File Offset: 0x0005A7C4
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mMovement = Vector3.zero;
			this.mRotation = Quaternion.identity;
			if (this.mLastTapStartTime > 0f)
			{
				this.UpdateDelayedActivation(rDeltaTime, rUpdateIndex);
				return;
			}
			if (this._UseTapToPivot && this.IsIdlePivoting())
			{
				this.UpdateIdlePivot(rDeltaTime, rUpdateIndex);
				return;
			}
			this.UpdateMovement(rDeltaTime, rUpdateIndex);
		}

		// Token: 0x060010E9 RID: 4329 RVA: 0x0005C620 File Offset: 0x0005A820
		private void UpdateDelayedActivation(float rDeltaTime, int rUpdateIndex)
		{
			if (this.mMotionController.State.InputMagnitudeTrend.Value < 0.1f)
			{
				this.mStartInPivot = true;
				this.mLastTapStartTime = 0f;
				this.DelayedActivate();
			}
			else if (this.mLastTapStartTime + this._TapToPivotDelay < Time.time)
			{
				this.mStartInPivot = false;
				this.mLastTapStartTime = 0f;
				this.DelayedActivate();
			}
			MotionState state = this.mMotionController.State;
			float num = (this.IsRunActive ? 1f : 0.5f);
			float num2 = Mathf.Clamp(state.InputX, -num, num);
			float num3 = Mathf.Clamp(state.InputY, -num, num);
			float num4 = Mathf.Clamp(state.InputMagnitudeTrend.Value, 0f, num);
			InputManagerHelper.ConvertToRadialInput(ref num2, ref num3, ref num4, 1f);
			this.mInputX.Add(num2);
			this.mInputY.Add(num3);
			this.mInputMagnitude.Add(num4);
			this.mMotionController.State.InputX = this.mInputX.Average;
			this.mMotionController.State.InputY = this.mInputY.Average;
			this.mMotionController.State.InputMagnitudeTrend.Replace(this.mInputMagnitude.Average);
		}

		// Token: 0x060010EA RID: 4330 RVA: 0x0005C778 File Offset: 0x0005A978
		private void UpdateIdlePivot(float rDeltaTime, int rUpdateIndex)
		{
			int animatorStateID = this.mMotionLayer._AnimatorStateID;
			if ((animatorStateID == this.STATE_IdleTurn180L || animatorStateID == this.STATE_IdleTurn90L || animatorStateID == this.STATE_IdleTurn20L || animatorStateID == this.STATE_IdleTurn20R || animatorStateID == this.STATE_IdleTurn90R || animatorStateID == this.STATE_IdleTurn180R) && this.mMotionLayer._AnimatorTransitionID != 0 && this.mLastTapInputForward.sqrMagnitude > 0f && this.mMotionController._CameraTransform != null)
			{
				Vector3 vector = this.mMotionController._CameraTransform.rotation * this.mLastTapInputForward;
				float num = this.mMotionController._Transform.forward.HorizontalAngleTo(vector, this.mMotionController._Transform.up);
				this.mRotation = Quaternion.Euler(0f, num * this.mMotionLayer._AnimatorTransitionNormalizedTime, 0f);
			}
		}

		// Token: 0x060010EB RID: 4331 RVA: 0x0005C864 File Offset: 0x0005AA64
		private void UpdateMovement(float rDeltaTime, int rUpdateIndex)
		{
			bool flag = true;
			if (this.mMotionController.State.InputMagnitudeTrend.Value > 0.4f)
			{
				this.mExitPhaseID = 0;
				this.mNoInputElapsed = 0f;
				this.mSavedInputForward = this.mMotionController.State.InputForward;
				if (this.IsStopping())
				{
					this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 27133, 0, true);
				}
			}
			else
			{
				this.mNoInputElapsed += rDeltaTime;
				if (this._UseStopTransitions)
				{
					flag = false;
					if (this.mNoInputElapsed > 0.2f)
					{
						if (this.mExitPhaseID == 0)
						{
							this.mExitPhaseID = ((this.mInputMagnitude.Average < 0.6f) ? 27132 : 27131);
						}
						if (this.mExitPhaseID != 0 && this.mMotionLayer._AnimatorStateID == this.STATE_MoveTree && this.mMotionLayer._AnimatorTransitionID == 0)
						{
							this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, this.mExitPhaseID, 0, true);
						}
					}
				}
			}
			if (flag)
			{
				MotionState state = this.mMotionController.State;
				float num = (this.IsRunActive ? 1f : 0.5f);
				float num2 = Mathf.Clamp(state.InputX, -num, num);
				float num3 = Mathf.Clamp(state.InputY, -num, num);
				float num4 = Mathf.Clamp(state.InputMagnitudeTrend.Value, 0f, num);
				InputManagerHelper.ConvertToRadialInput(ref num2, ref num3, ref num4, 1f);
				this.mInputX.Add(num2);
				this.mInputY.Add(num3);
				this.mInputMagnitude.Add(num4);
			}
			this.mMotionController.State.InputX = this.mInputX.Average;
			this.mMotionController.State.InputY = this.mInputY.Average;
			this.mMotionController.State.InputMagnitudeTrend.Replace(this.mInputMagnitude.Average);
			this.mRotateWithCamera = false;
			if (this._RotateWithCamera && this.mMotionController._CameraTransform != null)
			{
				float num5 = this.mMotionController._Transform.forward.HorizontalAngleTo(this.mMotionController._CameraTransform.forward, this.mMotionController._Transform.up);
				this.mRotateWithCamera = Mathf.Abs(num5) < this._RotationSpeed * rDeltaTime;
				if (this.mRotateWithCamera && this.mMotionLayer._AnimatorStateID != this.STATE_MoveTree)
				{
					this.mRotateWithCamera = false;
				}
				if (this.mRotateWithCamera && this.mMotionLayer._AnimatorTransitionID != 0)
				{
					this.mRotateWithCamera = false;
				}
				if (this.mRotateWithCamera && (Mathf.Abs(this.mMotionController.State.InputX) > 0.05f || this.mMotionController.State.InputY <= 0f))
				{
					this.mRotateWithCamera = false;
				}
				if (this.mRotateWithCamera && this._RotateActionAlias.Length > 0 && !this.mMotionController._InputSource.IsPressed(this._RotateActionAlias))
				{
					this.mRotateWithCamera = false;
				}
			}
			if (this._RotateWithCamera && !(this.mMotionController.CameraRig is BaseCameraRig))
			{
				this.OnCameraUpdated(rDeltaTime, rUpdateIndex, null);
			}
			if ((this.mMotionLayer._AnimatorTransitionID == this.TRANS_EntryState_MoveTree || (this.mMotionLayer._AnimatorStateID == this.STATE_MoveTree && this.mMotionLayer._AnimatorTransitionID == 0) || (this.mMotionLayer._AnimatorStateID == this.STATE_IdleToWalk180L && this.mMotionLayer._AnimatorStateNormalizedTime > 0.7f) || (this.mMotionLayer._AnimatorStateID == this.STATE_IdleToWalk90L && this.mMotionLayer._AnimatorStateNormalizedTime > 0.6f) || (this.mMotionLayer._AnimatorStateID == this.STATE_IdleToWalk90R && this.mMotionLayer._AnimatorStateNormalizedTime > 0.6f) || (this.mMotionLayer._AnimatorStateID == this.STATE_IdleToWalk180R && this.mMotionLayer._AnimatorStateNormalizedTime > 0.7f) || (this.mMotionLayer._AnimatorStateID == this.STATE_IdleToRun180L && this.mMotionLayer._AnimatorStateNormalizedTime > 0.6f) || (this.mMotionLayer._AnimatorStateID == this.STATE_IdleToRun90L && this.mMotionLayer._AnimatorStateNormalizedTime > 0.6f) || (this.mMotionLayer._AnimatorStateID == this.STATE_IdleToRun || (this.mMotionLayer._AnimatorStateID == this.STATE_IdleToRun90R && this.mMotionLayer._AnimatorStateNormalizedTime > 0.6f)) || (this.mMotionLayer._AnimatorStateID == this.STATE_IdleToRun180R && this.mMotionLayer._AnimatorStateNormalizedTime > 0.6f)) && !this.mRotateWithCamera)
			{
				if (this.mMotionController._CameraTransform != null && this.mMotionController.State.InputForward.sqrMagnitude == 0f)
				{
					this.RotateToInput(this.mMotionController._CameraTransform.rotation * this.mSavedInputForward, rDeltaTime, ref this.mRotation);
					return;
				}
				this.RotateToInput(this.mMotionController.State.InputFromAvatarAngle, rDeltaTime, ref this.mRotation);
			}
		}

		// Token: 0x060010EC RID: 4332 RVA: 0x0005CDC0 File Offset: 0x0005AFC0
		private void RotateToInput(Vector3 rInputForward, float rDeltaTime, ref Quaternion rRotation)
		{
			float num = this.mMotionController._Transform.forward.HorizontalAngleTo(rInputForward, this.mMotionController._Transform.up);
			if (num != 0f)
			{
				if (this._RotationSpeed > 0f && Mathf.Abs(num) > this._RotationSpeed * rDeltaTime)
				{
					num = Mathf.Sign(num) * this._RotationSpeed * rDeltaTime;
				}
				rRotation = Quaternion.Euler(0f, num, 0f);
			}
		}

		// Token: 0x060010ED RID: 4333 RVA: 0x0005CE40 File Offset: 0x0005B040
		private void RotateToInput(float rInputFromAvatarAngle, float rDeltaTime, ref Quaternion rRotation)
		{
			if (rInputFromAvatarAngle != 0f)
			{
				if (this._RotationSpeed > 0f && Mathf.Abs(rInputFromAvatarAngle) > this._RotationSpeed * rDeltaTime)
				{
					rInputFromAvatarAngle = Mathf.Sign(rInputFromAvatarAngle) * this._RotationSpeed * rDeltaTime;
				}
				rRotation = Quaternion.Euler(0f, rInputFromAvatarAngle, 0f);
			}
		}

		// Token: 0x060010EE RID: 4334 RVA: 0x0005CE9C File Offset: 0x0005B09C
		private void OnCameraUpdated(float rDeltaTime, int rUpdateIndex, BaseCameraRig rCamera)
		{
			if (!this.mRotateWithCamera)
			{
				this.mLinkRotation = false;
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

		// Token: 0x060010EF RID: 4335 RVA: 0x0005CF88 File Offset: 0x0005B188
		private bool IsStopping()
		{
			if (!this._UseStopTransitions)
			{
				return false;
			}
			int animatorStateID = this.mMotionLayer._AnimatorStateID;
			if (animatorStateID == this.STATE_RunToIdle_LDown)
			{
				return true;
			}
			if (animatorStateID == this.STATE_RunToIdle_RDown)
			{
				return true;
			}
			if (animatorStateID == this.STATE_WalkToIdle_LDown)
			{
				return true;
			}
			if (animatorStateID == this.STATE_WalkToIdle_RDown)
			{
				return true;
			}
			int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
			return animatorTransitionID == this.TRANS_MoveTree_RunToIdle_LDown || animatorTransitionID == this.TRANS_MoveTree_RunToIdle_RDown || animatorTransitionID == this.TRANS_MoveTree_WalkToIdle_LDown || animatorTransitionID == this.TRANS_MoveTree_WalkToIdle_RDown;
		}

		// Token: 0x060010F0 RID: 4336 RVA: 0x0005D010 File Offset: 0x0005B210
		private bool IsIdlePivoting()
		{
			if (!this._UseTapToPivot)
			{
				return false;
			}
			int animatorStateID = this.mMotionLayer._AnimatorStateID;
			if (animatorStateID == this.STATE_IdleTurn180L)
			{
				return true;
			}
			if (animatorStateID == this.STATE_IdleTurn90L)
			{
				return true;
			}
			if (animatorStateID == this.STATE_IdleTurn20L)
			{
				return true;
			}
			if (animatorStateID == this.STATE_IdleTurn20R)
			{
				return true;
			}
			if (animatorStateID == this.STATE_IdleTurn90R)
			{
				return true;
			}
			if (animatorStateID == this.STATE_IdleTurn180R)
			{
				return true;
			}
			int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
			return animatorTransitionID == this.TRANS_EntryState_IdleTurn180L || animatorTransitionID == this.TRANS_EntryState_IdleTurn90L || animatorTransitionID == this.TRANS_EntryState_IdleTurn20L || animatorTransitionID == this.TRANS_EntryState_IdleTurn20R || animatorTransitionID == this.TRANS_EntryState_IdleTurn90R || animatorTransitionID == this.TRANS_EntryState_IdleTurn180R;
		}

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x060010F1 RID: 4337 RVA: 0x0005D0C4 File Offset: 0x0005B2C4
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x060010F2 RID: 4338 RVA: 0x0005D0C8 File Offset: 0x0005B2C8
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				if (animatorTransitionID == 0)
				{
					if (animatorStateID == this.STATE_Start)
					{
						return true;
					}
					if (animatorStateID == this.STATE_MoveTree)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdleToWalk90L)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdleToWalk90R)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdleToWalk180R)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdleToWalk180L)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdlePose)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdleToRun90L)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdleToRun180L)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdleToRun90R)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdleToRun180R)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdleToRun)
					{
						return true;
					}
					if (animatorStateID == this.STATE_RunPivot180R_LDown)
					{
						return true;
					}
					if (animatorStateID == this.STATE_WalkPivot180L)
					{
						return true;
					}
					if (animatorStateID == this.STATE_RunToIdle_LDown)
					{
						return true;
					}
					if (animatorStateID == this.STATE_WalkToIdle_LDown)
					{
						return true;
					}
					if (animatorStateID == this.STATE_WalkToIdle_RDown)
					{
						return true;
					}
					if (animatorStateID == this.STATE_RunToIdle_RDown)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdleTurn20R)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdleTurn90R)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdleTurn180R)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdleTurn20L)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdleTurn90L)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdleTurn180L)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdleTurnEndPose)
					{
						return true;
					}
				}
				return animatorTransitionID == this.TRANS_AnyState_IdleToWalk90L || animatorTransitionID == this.TRANS_EntryState_IdleToWalk90L || animatorTransitionID == this.TRANS_AnyState_IdleToWalk90R || animatorTransitionID == this.TRANS_EntryState_IdleToWalk90R || animatorTransitionID == this.TRANS_AnyState_IdleToWalk180R || animatorTransitionID == this.TRANS_EntryState_IdleToWalk180R || animatorTransitionID == this.TRANS_AnyState_MoveTree || animatorTransitionID == this.TRANS_EntryState_MoveTree || animatorTransitionID == this.TRANS_AnyState_IdleToWalk180L || animatorTransitionID == this.TRANS_EntryState_IdleToWalk180L || animatorTransitionID == this.TRANS_AnyState_IdleToRun180L || animatorTransitionID == this.TRANS_EntryState_IdleToRun180L || animatorTransitionID == this.TRANS_AnyState_IdleToRun90L || animatorTransitionID == this.TRANS_EntryState_IdleToRun90L || animatorTransitionID == this.TRANS_AnyState_IdleToRun90R || animatorTransitionID == this.TRANS_EntryState_IdleToRun90R || animatorTransitionID == this.TRANS_AnyState_IdleToRun180R || animatorTransitionID == this.TRANS_EntryState_IdleToRun180R || animatorTransitionID == this.TRANS_AnyState_IdleToRun || animatorTransitionID == this.TRANS_EntryState_IdleToRun || animatorTransitionID == this.TRANS_AnyState_MoveTree || animatorTransitionID == this.TRANS_EntryState_MoveTree || animatorTransitionID == this.TRANS_AnyState_MoveTree || animatorTransitionID == this.TRANS_EntryState_MoveTree || animatorTransitionID == this.TRANS_AnyState_IdleTurn180L || animatorTransitionID == this.TRANS_EntryState_IdleTurn180L || animatorTransitionID == this.TRANS_AnyState_IdleTurn90L || animatorTransitionID == this.TRANS_EntryState_IdleTurn90L || animatorTransitionID == this.TRANS_AnyState_IdleTurn20L || animatorTransitionID == this.TRANS_EntryState_IdleTurn20L || animatorTransitionID == this.TRANS_AnyState_IdleTurn20R || animatorTransitionID == this.TRANS_EntryState_IdleTurn20R || animatorTransitionID == this.TRANS_AnyState_IdleTurn90R || animatorTransitionID == this.TRANS_EntryState_IdleTurn90R || animatorTransitionID == this.TRANS_AnyState_IdleTurn180R || animatorTransitionID == this.TRANS_EntryState_IdleTurn180R || animatorTransitionID == this.TRANS_MoveTree_RunPivot180R_LDown || animatorTransitionID == this.TRANS_MoveTree_RunPivot180R_LDown || animatorTransitionID == this.TRANS_MoveTree_WalkPivot180L || animatorTransitionID == this.TRANS_MoveTree_WalkPivot180L || animatorTransitionID == this.TRANS_MoveTree_RunToIdle_LDown || animatorTransitionID == this.TRANS_MoveTree_WalkToIdle_LDown || animatorTransitionID == this.TRANS_MoveTree_RunToIdle_RDown || animatorTransitionID == this.TRANS_MoveTree_WalkToIdle_RDown || animatorTransitionID == this.TRANS_MoveTree_RunToIdle_RDown || animatorTransitionID == this.TRANS_MoveTree_RunToIdle_LDown || animatorTransitionID == this.TRANS_MoveTree_WalkToIdle_RDown || animatorTransitionID == this.TRANS_MoveTree_WalkToIdle_LDown || animatorTransitionID == this.TRANS_IdleToWalk90L_MoveTree || animatorTransitionID == this.TRANS_IdleToWalk90L_IdlePose || animatorTransitionID == this.TRANS_IdleToWalk90R_MoveTree || animatorTransitionID == this.TRANS_IdleToWalk90R_IdlePose || animatorTransitionID == this.TRANS_IdleToWalk180R_MoveTree || animatorTransitionID == this.TRANS_IdleToWalk180R_IdlePose || animatorTransitionID == this.TRANS_IdleToWalk180L_MoveTree || animatorTransitionID == this.TRANS_IdleToWalk180L_IdlePose || animatorTransitionID == this.TRANS_IdleToRun90L_MoveTree || animatorTransitionID == this.TRANS_IdleToRun90L_IdlePose || animatorTransitionID == this.TRANS_IdleToRun180L_MoveTree || animatorTransitionID == this.TRANS_IdleToRun180L_IdlePose || animatorTransitionID == this.TRANS_IdleToRun90R_MoveTree || animatorTransitionID == this.TRANS_IdleToRun90R_IdlePose || animatorTransitionID == this.TRANS_IdleToRun180R_MoveTree || animatorTransitionID == this.TRANS_IdleToRun180R_IdlePose || animatorTransitionID == this.TRANS_IdleToRun_MoveTree || animatorTransitionID == this.TRANS_IdleToRun_IdlePose || animatorTransitionID == this.TRANS_RunPivot180R_LDown_MoveTree || animatorTransitionID == this.TRANS_WalkPivot180L_MoveTree || animatorTransitionID == this.TRANS_RunToIdle_LDown_IdlePose || animatorTransitionID == this.TRANS_RunToIdle_LDown_MoveTree || animatorTransitionID == this.TRANS_RunToIdle_LDown_RunPivot180R_LDown || animatorTransitionID == this.TRANS_RunToIdle_LDown_RunPivot180R_LDown || animatorTransitionID == this.TRANS_WalkToIdle_LDown_MoveTree || animatorTransitionID == this.TRANS_WalkToIdle_LDown_IdlePose || animatorTransitionID == this.TRANS_WalkToIdle_RDown_MoveTree || animatorTransitionID == this.TRANS_WalkToIdle_RDown_IdlePose || animatorTransitionID == this.TRANS_RunToIdle_RDown_MoveTree || animatorTransitionID == this.TRANS_RunToIdle_RDown_IdlePose || animatorTransitionID == this.TRANS_RunToIdle_RDown_RunPivot180R_LDown || animatorTransitionID == this.TRANS_RunToIdle_RDown_RunPivot180R_LDown || animatorTransitionID == this.TRANS_IdleTurn20R_IdleTurnEndPose || animatorTransitionID == this.TRANS_IdleTurn90R_IdleTurnEndPose || animatorTransitionID == this.TRANS_IdleTurn180R_IdleTurnEndPose || animatorTransitionID == this.TRANS_IdleTurn20L_IdleTurnEndPose || animatorTransitionID == this.TRANS_IdleTurn90L_IdleTurnEndPose || animatorTransitionID == this.TRANS_IdleTurn180L_IdleTurnEndPose || animatorTransitionID == this.TRANS_IdleTurnEndPose_MoveTree;
			}
		}

		// Token: 0x060010F3 RID: 4339 RVA: 0x0005D5C4 File Offset: 0x0005B7C4
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == this.STATE_Start || rStateID == this.STATE_MoveTree || rStateID == this.STATE_IdleToWalk90L || rStateID == this.STATE_IdleToWalk90R || rStateID == this.STATE_IdleToWalk180R || rStateID == this.STATE_IdleToWalk180L || rStateID == this.STATE_IdlePose || rStateID == this.STATE_IdleToRun90L || rStateID == this.STATE_IdleToRun180L || rStateID == this.STATE_IdleToRun90R || rStateID == this.STATE_IdleToRun180R || rStateID == this.STATE_IdleToRun || rStateID == this.STATE_RunPivot180R_LDown || rStateID == this.STATE_WalkPivot180L || rStateID == this.STATE_RunToIdle_LDown || rStateID == this.STATE_WalkToIdle_LDown || rStateID == this.STATE_WalkToIdle_RDown || rStateID == this.STATE_RunToIdle_RDown || rStateID == this.STATE_IdleTurn20R || rStateID == this.STATE_IdleTurn90R || rStateID == this.STATE_IdleTurn180R || rStateID == this.STATE_IdleTurn20L || rStateID == this.STATE_IdleTurn90L || rStateID == this.STATE_IdleTurn180L || rStateID == this.STATE_IdleTurnEndPose;
		}

		// Token: 0x060010F4 RID: 4340 RVA: 0x0005D6E8 File Offset: 0x0005B8E8
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			if (rTransitionID == 0)
			{
				if (rStateID == this.STATE_Start)
				{
					return true;
				}
				if (rStateID == this.STATE_MoveTree)
				{
					return true;
				}
				if (rStateID == this.STATE_IdleToWalk90L)
				{
					return true;
				}
				if (rStateID == this.STATE_IdleToWalk90R)
				{
					return true;
				}
				if (rStateID == this.STATE_IdleToWalk180R)
				{
					return true;
				}
				if (rStateID == this.STATE_IdleToWalk180L)
				{
					return true;
				}
				if (rStateID == this.STATE_IdlePose)
				{
					return true;
				}
				if (rStateID == this.STATE_IdleToRun90L)
				{
					return true;
				}
				if (rStateID == this.STATE_IdleToRun180L)
				{
					return true;
				}
				if (rStateID == this.STATE_IdleToRun90R)
				{
					return true;
				}
				if (rStateID == this.STATE_IdleToRun180R)
				{
					return true;
				}
				if (rStateID == this.STATE_IdleToRun)
				{
					return true;
				}
				if (rStateID == this.STATE_RunPivot180R_LDown)
				{
					return true;
				}
				if (rStateID == this.STATE_WalkPivot180L)
				{
					return true;
				}
				if (rStateID == this.STATE_RunToIdle_LDown)
				{
					return true;
				}
				if (rStateID == this.STATE_WalkToIdle_LDown)
				{
					return true;
				}
				if (rStateID == this.STATE_WalkToIdle_RDown)
				{
					return true;
				}
				if (rStateID == this.STATE_RunToIdle_RDown)
				{
					return true;
				}
				if (rStateID == this.STATE_IdleTurn20R)
				{
					return true;
				}
				if (rStateID == this.STATE_IdleTurn90R)
				{
					return true;
				}
				if (rStateID == this.STATE_IdleTurn180R)
				{
					return true;
				}
				if (rStateID == this.STATE_IdleTurn20L)
				{
					return true;
				}
				if (rStateID == this.STATE_IdleTurn90L)
				{
					return true;
				}
				if (rStateID == this.STATE_IdleTurn180L)
				{
					return true;
				}
				if (rStateID == this.STATE_IdleTurnEndPose)
				{
					return true;
				}
			}
			return rTransitionID == this.TRANS_AnyState_IdleToWalk90L || rTransitionID == this.TRANS_EntryState_IdleToWalk90L || rTransitionID == this.TRANS_AnyState_IdleToWalk90R || rTransitionID == this.TRANS_EntryState_IdleToWalk90R || rTransitionID == this.TRANS_AnyState_IdleToWalk180R || rTransitionID == this.TRANS_EntryState_IdleToWalk180R || rTransitionID == this.TRANS_AnyState_MoveTree || rTransitionID == this.TRANS_EntryState_MoveTree || rTransitionID == this.TRANS_AnyState_IdleToWalk180L || rTransitionID == this.TRANS_EntryState_IdleToWalk180L || rTransitionID == this.TRANS_AnyState_IdleToRun180L || rTransitionID == this.TRANS_EntryState_IdleToRun180L || rTransitionID == this.TRANS_AnyState_IdleToRun90L || rTransitionID == this.TRANS_EntryState_IdleToRun90L || rTransitionID == this.TRANS_AnyState_IdleToRun90R || rTransitionID == this.TRANS_EntryState_IdleToRun90R || rTransitionID == this.TRANS_AnyState_IdleToRun180R || rTransitionID == this.TRANS_EntryState_IdleToRun180R || rTransitionID == this.TRANS_AnyState_IdleToRun || rTransitionID == this.TRANS_EntryState_IdleToRun || rTransitionID == this.TRANS_AnyState_MoveTree || rTransitionID == this.TRANS_EntryState_MoveTree || rTransitionID == this.TRANS_AnyState_MoveTree || rTransitionID == this.TRANS_EntryState_MoveTree || rTransitionID == this.TRANS_AnyState_IdleTurn180L || rTransitionID == this.TRANS_EntryState_IdleTurn180L || rTransitionID == this.TRANS_AnyState_IdleTurn90L || rTransitionID == this.TRANS_EntryState_IdleTurn90L || rTransitionID == this.TRANS_AnyState_IdleTurn20L || rTransitionID == this.TRANS_EntryState_IdleTurn20L || rTransitionID == this.TRANS_AnyState_IdleTurn20R || rTransitionID == this.TRANS_EntryState_IdleTurn20R || rTransitionID == this.TRANS_AnyState_IdleTurn90R || rTransitionID == this.TRANS_EntryState_IdleTurn90R || rTransitionID == this.TRANS_AnyState_IdleTurn180R || rTransitionID == this.TRANS_EntryState_IdleTurn180R || rTransitionID == this.TRANS_MoveTree_RunPivot180R_LDown || rTransitionID == this.TRANS_MoveTree_RunPivot180R_LDown || rTransitionID == this.TRANS_MoveTree_WalkPivot180L || rTransitionID == this.TRANS_MoveTree_WalkPivot180L || rTransitionID == this.TRANS_MoveTree_RunToIdle_LDown || rTransitionID == this.TRANS_MoveTree_WalkToIdle_LDown || rTransitionID == this.TRANS_MoveTree_RunToIdle_RDown || rTransitionID == this.TRANS_MoveTree_WalkToIdle_RDown || rTransitionID == this.TRANS_MoveTree_RunToIdle_RDown || rTransitionID == this.TRANS_MoveTree_RunToIdle_LDown || rTransitionID == this.TRANS_MoveTree_WalkToIdle_RDown || rTransitionID == this.TRANS_MoveTree_WalkToIdle_LDown || rTransitionID == this.TRANS_IdleToWalk90L_MoveTree || rTransitionID == this.TRANS_IdleToWalk90L_IdlePose || rTransitionID == this.TRANS_IdleToWalk90R_MoveTree || rTransitionID == this.TRANS_IdleToWalk90R_IdlePose || rTransitionID == this.TRANS_IdleToWalk180R_MoveTree || rTransitionID == this.TRANS_IdleToWalk180R_IdlePose || rTransitionID == this.TRANS_IdleToWalk180L_MoveTree || rTransitionID == this.TRANS_IdleToWalk180L_IdlePose || rTransitionID == this.TRANS_IdleToRun90L_MoveTree || rTransitionID == this.TRANS_IdleToRun90L_IdlePose || rTransitionID == this.TRANS_IdleToRun180L_MoveTree || rTransitionID == this.TRANS_IdleToRun180L_IdlePose || rTransitionID == this.TRANS_IdleToRun90R_MoveTree || rTransitionID == this.TRANS_IdleToRun90R_IdlePose || rTransitionID == this.TRANS_IdleToRun180R_MoveTree || rTransitionID == this.TRANS_IdleToRun180R_IdlePose || rTransitionID == this.TRANS_IdleToRun_MoveTree || rTransitionID == this.TRANS_IdleToRun_IdlePose || rTransitionID == this.TRANS_RunPivot180R_LDown_MoveTree || rTransitionID == this.TRANS_WalkPivot180L_MoveTree || rTransitionID == this.TRANS_RunToIdle_LDown_IdlePose || rTransitionID == this.TRANS_RunToIdle_LDown_MoveTree || rTransitionID == this.TRANS_RunToIdle_LDown_RunPivot180R_LDown || rTransitionID == this.TRANS_RunToIdle_LDown_RunPivot180R_LDown || rTransitionID == this.TRANS_WalkToIdle_LDown_MoveTree || rTransitionID == this.TRANS_WalkToIdle_LDown_IdlePose || rTransitionID == this.TRANS_WalkToIdle_RDown_MoveTree || rTransitionID == this.TRANS_WalkToIdle_RDown_IdlePose || rTransitionID == this.TRANS_RunToIdle_RDown_MoveTree || rTransitionID == this.TRANS_RunToIdle_RDown_IdlePose || rTransitionID == this.TRANS_RunToIdle_RDown_RunPivot180R_LDown || rTransitionID == this.TRANS_RunToIdle_RDown_RunPivot180R_LDown || rTransitionID == this.TRANS_IdleTurn20R_IdleTurnEndPose || rTransitionID == this.TRANS_IdleTurn90R_IdleTurnEndPose || rTransitionID == this.TRANS_IdleTurn180R_IdleTurnEndPose || rTransitionID == this.TRANS_IdleTurn20L_IdleTurnEndPose || rTransitionID == this.TRANS_IdleTurn90L_IdleTurnEndPose || rTransitionID == this.TRANS_IdleTurn180L_IdleTurnEndPose || rTransitionID == this.TRANS_IdleTurnEndPose_MoveTree;
		}

		// Token: 0x060010F5 RID: 4341 RVA: 0x0005DBCC File Offset: 0x0005BDCC
		public override void LoadAnimatorData()
		{
			string layerName = this.mMotionController.Animator.GetLayerName(this.mMotionLayer._AnimatorLayerIndex);
			this.TRANS_AnyState_IdleToWalk90L = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".WalkRunPivot v2-SM.IdleToWalk90L");
			this.TRANS_EntryState_IdleToWalk90L = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".WalkRunPivot v2-SM.IdleToWalk90L");
			this.TRANS_AnyState_IdleToWalk90R = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".WalkRunPivot v2-SM.IdleToWalk90R");
			this.TRANS_EntryState_IdleToWalk90R = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".WalkRunPivot v2-SM.IdleToWalk90R");
			this.TRANS_AnyState_IdleToWalk180R = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".WalkRunPivot v2-SM.IdleToWalk180R");
			this.TRANS_EntryState_IdleToWalk180R = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".WalkRunPivot v2-SM.IdleToWalk180R");
			this.TRANS_AnyState_MoveTree = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_EntryState_MoveTree = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_AnyState_IdleToWalk180L = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".WalkRunPivot v2-SM.IdleToWalk180L");
			this.TRANS_EntryState_IdleToWalk180L = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".WalkRunPivot v2-SM.IdleToWalk180L");
			this.TRANS_AnyState_IdleToRun180L = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".WalkRunPivot v2-SM.IdleToRun180L");
			this.TRANS_EntryState_IdleToRun180L = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".WalkRunPivot v2-SM.IdleToRun180L");
			this.TRANS_AnyState_IdleToRun90L = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".WalkRunPivot v2-SM.IdleToRun90L");
			this.TRANS_EntryState_IdleToRun90L = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".WalkRunPivot v2-SM.IdleToRun90L");
			this.TRANS_AnyState_IdleToRun90R = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".WalkRunPivot v2-SM.IdleToRun90R");
			this.TRANS_EntryState_IdleToRun90R = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".WalkRunPivot v2-SM.IdleToRun90R");
			this.TRANS_AnyState_IdleToRun180R = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".WalkRunPivot v2-SM.IdleToRun180R");
			this.TRANS_EntryState_IdleToRun180R = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".WalkRunPivot v2-SM.IdleToRun180R");
			this.TRANS_AnyState_IdleToRun = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".WalkRunPivot v2-SM.IdleToRun");
			this.TRANS_EntryState_IdleToRun = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".WalkRunPivot v2-SM.IdleToRun");
			this.TRANS_AnyState_MoveTree = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_EntryState_MoveTree = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_AnyState_MoveTree = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_EntryState_MoveTree = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_AnyState_IdleTurn180L = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".WalkRunPivot v2-SM.IdleTurn180L");
			this.TRANS_EntryState_IdleTurn180L = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".WalkRunPivot v2-SM.IdleTurn180L");
			this.TRANS_AnyState_IdleTurn90L = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".WalkRunPivot v2-SM.IdleTurn90L");
			this.TRANS_EntryState_IdleTurn90L = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".WalkRunPivot v2-SM.IdleTurn90L");
			this.TRANS_AnyState_IdleTurn20L = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".WalkRunPivot v2-SM.IdleTurn20L");
			this.TRANS_EntryState_IdleTurn20L = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".WalkRunPivot v2-SM.IdleTurn20L");
			this.TRANS_AnyState_IdleTurn20R = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".WalkRunPivot v2-SM.IdleTurn20R");
			this.TRANS_EntryState_IdleTurn20R = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".WalkRunPivot v2-SM.IdleTurn20R");
			this.TRANS_AnyState_IdleTurn90R = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".WalkRunPivot v2-SM.IdleTurn90R");
			this.TRANS_EntryState_IdleTurn90R = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".WalkRunPivot v2-SM.IdleTurn90R");
			this.TRANS_AnyState_IdleTurn180R = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".WalkRunPivot v2-SM.IdleTurn180R");
			this.TRANS_EntryState_IdleTurn180R = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".WalkRunPivot v2-SM.IdleTurn180R");
			this.STATE_Start = this.mMotionController.AddAnimatorName(layerName + ".Start");
			this.STATE_MoveTree = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_MoveTree_RunPivot180R_LDown = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.Move Tree -> " + layerName + ".WalkRunPivot v2-SM.RunPivot180R_LDown");
			this.TRANS_MoveTree_RunPivot180R_LDown = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.Move Tree -> " + layerName + ".WalkRunPivot v2-SM.RunPivot180R_LDown");
			this.TRANS_MoveTree_WalkPivot180L = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.Move Tree -> " + layerName + ".WalkRunPivot v2-SM.WalkPivot180L");
			this.TRANS_MoveTree_WalkPivot180L = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.Move Tree -> " + layerName + ".WalkRunPivot v2-SM.WalkPivot180L");
			this.TRANS_MoveTree_RunToIdle_LDown = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.Move Tree -> " + layerName + ".WalkRunPivot v2-SM.RunToIdle_LDown");
			this.TRANS_MoveTree_WalkToIdle_LDown = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.Move Tree -> " + layerName + ".WalkRunPivot v2-SM.WalkToIdle_LDown");
			this.TRANS_MoveTree_RunToIdle_RDown = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.Move Tree -> " + layerName + ".WalkRunPivot v2-SM.RunToIdle_RDown");
			this.TRANS_MoveTree_WalkToIdle_RDown = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.Move Tree -> " + layerName + ".WalkRunPivot v2-SM.WalkToIdle_RDown");
			this.TRANS_MoveTree_RunToIdle_RDown = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.Move Tree -> " + layerName + ".WalkRunPivot v2-SM.RunToIdle_RDown");
			this.TRANS_MoveTree_RunToIdle_LDown = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.Move Tree -> " + layerName + ".WalkRunPivot v2-SM.RunToIdle_LDown");
			this.TRANS_MoveTree_WalkToIdle_RDown = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.Move Tree -> " + layerName + ".WalkRunPivot v2-SM.WalkToIdle_RDown");
			this.TRANS_MoveTree_WalkToIdle_LDown = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.Move Tree -> " + layerName + ".WalkRunPivot v2-SM.WalkToIdle_LDown");
			this.STATE_IdleToWalk90L = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToWalk90L");
			this.TRANS_IdleToWalk90L_MoveTree = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToWalk90L -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_IdleToWalk90L_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToWalk90L -> " + layerName + ".WalkRunPivot v2-SM.IdlePose");
			this.STATE_IdleToWalk90R = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToWalk90R");
			this.TRANS_IdleToWalk90R_MoveTree = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToWalk90R -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_IdleToWalk90R_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToWalk90R -> " + layerName + ".WalkRunPivot v2-SM.IdlePose");
			this.STATE_IdleToWalk180R = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToWalk180R");
			this.TRANS_IdleToWalk180R_MoveTree = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToWalk180R -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_IdleToWalk180R_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToWalk180R -> " + layerName + ".WalkRunPivot v2-SM.IdlePose");
			this.STATE_IdleToWalk180L = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToWalk180L");
			this.TRANS_IdleToWalk180L_MoveTree = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToWalk180L -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_IdleToWalk180L_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToWalk180L -> " + layerName + ".WalkRunPivot v2-SM.IdlePose");
			this.STATE_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdlePose");
			this.STATE_IdleToRun90L = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToRun90L");
			this.TRANS_IdleToRun90L_MoveTree = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToRun90L -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_IdleToRun90L_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToRun90L -> " + layerName + ".WalkRunPivot v2-SM.IdlePose");
			this.STATE_IdleToRun180L = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToRun180L");
			this.TRANS_IdleToRun180L_MoveTree = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToRun180L -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_IdleToRun180L_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToRun180L -> " + layerName + ".WalkRunPivot v2-SM.IdlePose");
			this.STATE_IdleToRun90R = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToRun90R");
			this.TRANS_IdleToRun90R_MoveTree = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToRun90R -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_IdleToRun90R_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToRun90R -> " + layerName + ".WalkRunPivot v2-SM.IdlePose");
			this.STATE_IdleToRun180R = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToRun180R");
			this.TRANS_IdleToRun180R_MoveTree = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToRun180R -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_IdleToRun180R_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToRun180R -> " + layerName + ".WalkRunPivot v2-SM.IdlePose");
			this.STATE_IdleToRun = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToRun");
			this.TRANS_IdleToRun_MoveTree = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToRun -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_IdleToRun_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleToRun -> " + layerName + ".WalkRunPivot v2-SM.IdlePose");
			this.STATE_RunPivot180R_LDown = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.RunPivot180R_LDown");
			this.TRANS_RunPivot180R_LDown_MoveTree = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.RunPivot180R_LDown -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.STATE_WalkPivot180L = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.WalkPivot180L");
			this.TRANS_WalkPivot180L_MoveTree = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.WalkPivot180L -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.STATE_RunToIdle_LDown = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.RunToIdle_LDown");
			this.TRANS_RunToIdle_LDown_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.RunToIdle_LDown -> " + layerName + ".WalkRunPivot v2-SM.IdlePose");
			this.TRANS_RunToIdle_LDown_MoveTree = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.RunToIdle_LDown -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_RunToIdle_LDown_RunPivot180R_LDown = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.RunToIdle_LDown -> " + layerName + ".WalkRunPivot v2-SM.RunPivot180R_LDown");
			this.TRANS_RunToIdle_LDown_RunPivot180R_LDown = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.RunToIdle_LDown -> " + layerName + ".WalkRunPivot v2-SM.RunPivot180R_LDown");
			this.STATE_WalkToIdle_LDown = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.WalkToIdle_LDown");
			this.TRANS_WalkToIdle_LDown_MoveTree = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.WalkToIdle_LDown -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_WalkToIdle_LDown_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.WalkToIdle_LDown -> " + layerName + ".WalkRunPivot v2-SM.IdlePose");
			this.STATE_WalkToIdle_RDown = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.WalkToIdle_RDown");
			this.TRANS_WalkToIdle_RDown_MoveTree = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.WalkToIdle_RDown -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_WalkToIdle_RDown_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.WalkToIdle_RDown -> " + layerName + ".WalkRunPivot v2-SM.IdlePose");
			this.STATE_RunToIdle_RDown = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.RunToIdle_RDown");
			this.TRANS_RunToIdle_RDown_MoveTree = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.RunToIdle_RDown -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
			this.TRANS_RunToIdle_RDown_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.RunToIdle_RDown -> " + layerName + ".WalkRunPivot v2-SM.IdlePose");
			this.TRANS_RunToIdle_RDown_RunPivot180R_LDown = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.RunToIdle_RDown -> " + layerName + ".WalkRunPivot v2-SM.RunPivot180R_LDown");
			this.TRANS_RunToIdle_RDown_RunPivot180R_LDown = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.RunToIdle_RDown -> " + layerName + ".WalkRunPivot v2-SM.RunPivot180R_LDown");
			this.STATE_IdleTurn20R = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleTurn20R");
			this.TRANS_IdleTurn20R_IdleTurnEndPose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleTurn20R -> " + layerName + ".WalkRunPivot v2-SM.IdleTurnEndPose");
			this.STATE_IdleTurn90R = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleTurn90R");
			this.TRANS_IdleTurn90R_IdleTurnEndPose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleTurn90R -> " + layerName + ".WalkRunPivot v2-SM.IdleTurnEndPose");
			this.STATE_IdleTurn180R = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleTurn180R");
			this.TRANS_IdleTurn180R_IdleTurnEndPose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleTurn180R -> " + layerName + ".WalkRunPivot v2-SM.IdleTurnEndPose");
			this.STATE_IdleTurn20L = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleTurn20L");
			this.TRANS_IdleTurn20L_IdleTurnEndPose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleTurn20L -> " + layerName + ".WalkRunPivot v2-SM.IdleTurnEndPose");
			this.STATE_IdleTurn90L = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleTurn90L");
			this.TRANS_IdleTurn90L_IdleTurnEndPose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleTurn90L -> " + layerName + ".WalkRunPivot v2-SM.IdleTurnEndPose");
			this.STATE_IdleTurn180L = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleTurn180L");
			this.TRANS_IdleTurn180L_IdleTurnEndPose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleTurn180L -> " + layerName + ".WalkRunPivot v2-SM.IdleTurnEndPose");
			this.STATE_IdleTurnEndPose = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleTurnEndPose");
			this.TRANS_IdleTurnEndPose_MoveTree = this.mMotionController.AddAnimatorName(layerName + ".WalkRunPivot v2-SM.IdleTurnEndPose -> " + layerName + ".WalkRunPivot v2-SM.Move Tree");
		}

		// Token: 0x04000C02 RID: 3074
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000C03 RID: 3075
		public const int PHASE_START = 27130;

		// Token: 0x04000C04 RID: 3076
		public const int PHASE_END_RUN = 27131;

		// Token: 0x04000C05 RID: 3077
		public const int PHASE_END_WALK = 27132;

		// Token: 0x04000C06 RID: 3078
		public const int PHASE_RESUME = 27133;

		// Token: 0x04000C07 RID: 3079
		public const int PHASE_START_IDLE_PIVOT = 27135;

		// Token: 0x04000C08 RID: 3080
		public int _FormCondition;

		// Token: 0x04000C09 RID: 3081
		public bool _DefaultToRun;

		// Token: 0x04000C0A RID: 3082
		public float _WalkSpeed;

		// Token: 0x04000C0B RID: 3083
		public float _RunSpeed;

		// Token: 0x04000C0C RID: 3084
		public bool _RotateWithCamera = true;

		// Token: 0x04000C0D RID: 3085
		public string _RotateActionAlias = "ActivateRotation";

		// Token: 0x04000C0E RID: 3086
		public float _RotationSpeed = 180f;

		// Token: 0x04000C0F RID: 3087
		private bool mStartInMove;

		// Token: 0x04000C10 RID: 3088
		private bool mStartInWalk;

		// Token: 0x04000C11 RID: 3089
		private bool mStartInRun;

		// Token: 0x04000C12 RID: 3090
		public bool _UseStartTransitions = true;

		// Token: 0x04000C13 RID: 3091
		public bool _UseStopTransitions = true;

		// Token: 0x04000C14 RID: 3092
		public bool _UseTapToPivot;

		// Token: 0x04000C15 RID: 3093
		public float _TapToPivotDelay = 0.2f;

		// Token: 0x04000C16 RID: 3094
		public float _MinPivotAngle = 20f;

		// Token: 0x04000C17 RID: 3095
		public int _SmoothingSamples = 10;

		// Token: 0x04000C18 RID: 3096
		protected bool mStartInPivot;

		// Token: 0x04000C19 RID: 3097
		protected Vector3 mSavedInputForward = Vector3.zero;

		// Token: 0x04000C1A RID: 3098
		protected float mNoInputElapsed;

		// Token: 0x04000C1B RID: 3099
		protected int mExitPhaseID;

		// Token: 0x04000C1C RID: 3100
		protected bool mRotateWithCamera;

		// Token: 0x04000C1D RID: 3101
		protected bool mLinkRotation;

		// Token: 0x04000C1E RID: 3102
		protected FloatValue mInputX = new FloatValue(0f, 10);

		// Token: 0x04000C1F RID: 3103
		protected FloatValue mInputY = new FloatValue(0f, 10);

		// Token: 0x04000C20 RID: 3104
		protected FloatValue mInputMagnitude = new FloatValue(0f, 15);

		// Token: 0x04000C21 RID: 3105
		protected float mLastTapStartTime;

		// Token: 0x04000C22 RID: 3106
		protected float mLastTapInputFromAvatarAngle;

		// Token: 0x04000C23 RID: 3107
		protected Vector3 mLastTapInputForward = Vector3.zero;

		// Token: 0x04000C24 RID: 3108
		public int STATE_Start = -1;

		// Token: 0x04000C25 RID: 3109
		public int STATE_MoveTree = -1;

		// Token: 0x04000C26 RID: 3110
		public int STATE_IdleToWalk90L = -1;

		// Token: 0x04000C27 RID: 3111
		public int STATE_IdleToWalk90R = -1;

		// Token: 0x04000C28 RID: 3112
		public int STATE_IdleToWalk180R = -1;

		// Token: 0x04000C29 RID: 3113
		public int STATE_IdleToWalk180L = -1;

		// Token: 0x04000C2A RID: 3114
		public int STATE_IdlePose = -1;

		// Token: 0x04000C2B RID: 3115
		public int STATE_IdleToRun90L = -1;

		// Token: 0x04000C2C RID: 3116
		public int STATE_IdleToRun180L = -1;

		// Token: 0x04000C2D RID: 3117
		public int STATE_IdleToRun90R = -1;

		// Token: 0x04000C2E RID: 3118
		public int STATE_IdleToRun180R = -1;

		// Token: 0x04000C2F RID: 3119
		public int STATE_IdleToRun = -1;

		// Token: 0x04000C30 RID: 3120
		public int STATE_RunPivot180R_LDown = -1;

		// Token: 0x04000C31 RID: 3121
		public int STATE_WalkPivot180L = -1;

		// Token: 0x04000C32 RID: 3122
		public int STATE_RunToIdle_LDown = -1;

		// Token: 0x04000C33 RID: 3123
		public int STATE_WalkToIdle_LDown = -1;

		// Token: 0x04000C34 RID: 3124
		public int STATE_WalkToIdle_RDown = -1;

		// Token: 0x04000C35 RID: 3125
		public int STATE_RunToIdle_RDown = -1;

		// Token: 0x04000C36 RID: 3126
		public int STATE_IdleTurn20R = -1;

		// Token: 0x04000C37 RID: 3127
		public int STATE_IdleTurn90R = -1;

		// Token: 0x04000C38 RID: 3128
		public int STATE_IdleTurn180R = -1;

		// Token: 0x04000C39 RID: 3129
		public int STATE_IdleTurn20L = -1;

		// Token: 0x04000C3A RID: 3130
		public int STATE_IdleTurn90L = -1;

		// Token: 0x04000C3B RID: 3131
		public int STATE_IdleTurn180L = -1;

		// Token: 0x04000C3C RID: 3132
		public int STATE_IdleTurnEndPose = -1;

		// Token: 0x04000C3D RID: 3133
		public int TRANS_AnyState_IdleToWalk90L = -1;

		// Token: 0x04000C3E RID: 3134
		public int TRANS_EntryState_IdleToWalk90L = -1;

		// Token: 0x04000C3F RID: 3135
		public int TRANS_AnyState_IdleToWalk90R = -1;

		// Token: 0x04000C40 RID: 3136
		public int TRANS_EntryState_IdleToWalk90R = -1;

		// Token: 0x04000C41 RID: 3137
		public int TRANS_AnyState_IdleToWalk180R = -1;

		// Token: 0x04000C42 RID: 3138
		public int TRANS_EntryState_IdleToWalk180R = -1;

		// Token: 0x04000C43 RID: 3139
		public int TRANS_AnyState_MoveTree = -1;

		// Token: 0x04000C44 RID: 3140
		public int TRANS_EntryState_MoveTree = -1;

		// Token: 0x04000C45 RID: 3141
		public int TRANS_AnyState_IdleToWalk180L = -1;

		// Token: 0x04000C46 RID: 3142
		public int TRANS_EntryState_IdleToWalk180L = -1;

		// Token: 0x04000C47 RID: 3143
		public int TRANS_AnyState_IdleToRun180L = -1;

		// Token: 0x04000C48 RID: 3144
		public int TRANS_EntryState_IdleToRun180L = -1;

		// Token: 0x04000C49 RID: 3145
		public int TRANS_AnyState_IdleToRun90L = -1;

		// Token: 0x04000C4A RID: 3146
		public int TRANS_EntryState_IdleToRun90L = -1;

		// Token: 0x04000C4B RID: 3147
		public int TRANS_AnyState_IdleToRun90R = -1;

		// Token: 0x04000C4C RID: 3148
		public int TRANS_EntryState_IdleToRun90R = -1;

		// Token: 0x04000C4D RID: 3149
		public int TRANS_AnyState_IdleToRun180R = -1;

		// Token: 0x04000C4E RID: 3150
		public int TRANS_EntryState_IdleToRun180R = -1;

		// Token: 0x04000C4F RID: 3151
		public int TRANS_AnyState_IdleToRun = -1;

		// Token: 0x04000C50 RID: 3152
		public int TRANS_EntryState_IdleToRun = -1;

		// Token: 0x04000C51 RID: 3153
		public int TRANS_AnyState_IdleTurn180L = -1;

		// Token: 0x04000C52 RID: 3154
		public int TRANS_EntryState_IdleTurn180L = -1;

		// Token: 0x04000C53 RID: 3155
		public int TRANS_AnyState_IdleTurn90L = -1;

		// Token: 0x04000C54 RID: 3156
		public int TRANS_EntryState_IdleTurn90L = -1;

		// Token: 0x04000C55 RID: 3157
		public int TRANS_AnyState_IdleTurn20L = -1;

		// Token: 0x04000C56 RID: 3158
		public int TRANS_EntryState_IdleTurn20L = -1;

		// Token: 0x04000C57 RID: 3159
		public int TRANS_AnyState_IdleTurn20R = -1;

		// Token: 0x04000C58 RID: 3160
		public int TRANS_EntryState_IdleTurn20R = -1;

		// Token: 0x04000C59 RID: 3161
		public int TRANS_AnyState_IdleTurn90R = -1;

		// Token: 0x04000C5A RID: 3162
		public int TRANS_EntryState_IdleTurn90R = -1;

		// Token: 0x04000C5B RID: 3163
		public int TRANS_AnyState_IdleTurn180R = -1;

		// Token: 0x04000C5C RID: 3164
		public int TRANS_EntryState_IdleTurn180R = -1;

		// Token: 0x04000C5D RID: 3165
		public int TRANS_MoveTree_RunPivot180R_LDown = -1;

		// Token: 0x04000C5E RID: 3166
		public int TRANS_MoveTree_WalkPivot180L = -1;

		// Token: 0x04000C5F RID: 3167
		public int TRANS_MoveTree_RunToIdle_LDown = -1;

		// Token: 0x04000C60 RID: 3168
		public int TRANS_MoveTree_WalkToIdle_LDown = -1;

		// Token: 0x04000C61 RID: 3169
		public int TRANS_MoveTree_RunToIdle_RDown = -1;

		// Token: 0x04000C62 RID: 3170
		public int TRANS_MoveTree_WalkToIdle_RDown = -1;

		// Token: 0x04000C63 RID: 3171
		public int TRANS_IdleToWalk90L_MoveTree = -1;

		// Token: 0x04000C64 RID: 3172
		public int TRANS_IdleToWalk90L_IdlePose = -1;

		// Token: 0x04000C65 RID: 3173
		public int TRANS_IdleToWalk90R_MoveTree = -1;

		// Token: 0x04000C66 RID: 3174
		public int TRANS_IdleToWalk90R_IdlePose = -1;

		// Token: 0x04000C67 RID: 3175
		public int TRANS_IdleToWalk180R_MoveTree = -1;

		// Token: 0x04000C68 RID: 3176
		public int TRANS_IdleToWalk180R_IdlePose = -1;

		// Token: 0x04000C69 RID: 3177
		public int TRANS_IdleToWalk180L_MoveTree = -1;

		// Token: 0x04000C6A RID: 3178
		public int TRANS_IdleToWalk180L_IdlePose = -1;

		// Token: 0x04000C6B RID: 3179
		public int TRANS_IdleToRun90L_MoveTree = -1;

		// Token: 0x04000C6C RID: 3180
		public int TRANS_IdleToRun90L_IdlePose = -1;

		// Token: 0x04000C6D RID: 3181
		public int TRANS_IdleToRun180L_MoveTree = -1;

		// Token: 0x04000C6E RID: 3182
		public int TRANS_IdleToRun180L_IdlePose = -1;

		// Token: 0x04000C6F RID: 3183
		public int TRANS_IdleToRun90R_MoveTree = -1;

		// Token: 0x04000C70 RID: 3184
		public int TRANS_IdleToRun90R_IdlePose = -1;

		// Token: 0x04000C71 RID: 3185
		public int TRANS_IdleToRun180R_MoveTree = -1;

		// Token: 0x04000C72 RID: 3186
		public int TRANS_IdleToRun180R_IdlePose = -1;

		// Token: 0x04000C73 RID: 3187
		public int TRANS_IdleToRun_MoveTree = -1;

		// Token: 0x04000C74 RID: 3188
		public int TRANS_IdleToRun_IdlePose = -1;

		// Token: 0x04000C75 RID: 3189
		public int TRANS_RunPivot180R_LDown_MoveTree = -1;

		// Token: 0x04000C76 RID: 3190
		public int TRANS_WalkPivot180L_MoveTree = -1;

		// Token: 0x04000C77 RID: 3191
		public int TRANS_RunToIdle_LDown_IdlePose = -1;

		// Token: 0x04000C78 RID: 3192
		public int TRANS_RunToIdle_LDown_MoveTree = -1;

		// Token: 0x04000C79 RID: 3193
		public int TRANS_RunToIdle_LDown_RunPivot180R_LDown = -1;

		// Token: 0x04000C7A RID: 3194
		public int TRANS_WalkToIdle_LDown_MoveTree = -1;

		// Token: 0x04000C7B RID: 3195
		public int TRANS_WalkToIdle_LDown_IdlePose = -1;

		// Token: 0x04000C7C RID: 3196
		public int TRANS_WalkToIdle_RDown_MoveTree = -1;

		// Token: 0x04000C7D RID: 3197
		public int TRANS_WalkToIdle_RDown_IdlePose = -1;

		// Token: 0x04000C7E RID: 3198
		public int TRANS_RunToIdle_RDown_MoveTree = -1;

		// Token: 0x04000C7F RID: 3199
		public int TRANS_RunToIdle_RDown_IdlePose = -1;

		// Token: 0x04000C80 RID: 3200
		public int TRANS_RunToIdle_RDown_RunPivot180R_LDown = -1;

		// Token: 0x04000C81 RID: 3201
		public int TRANS_IdleTurn20R_IdleTurnEndPose = -1;

		// Token: 0x04000C82 RID: 3202
		public int TRANS_IdleTurn90R_IdleTurnEndPose = -1;

		// Token: 0x04000C83 RID: 3203
		public int TRANS_IdleTurn180R_IdleTurnEndPose = -1;

		// Token: 0x04000C84 RID: 3204
		public int TRANS_IdleTurn20L_IdleTurnEndPose = -1;

		// Token: 0x04000C85 RID: 3205
		public int TRANS_IdleTurn90L_IdleTurnEndPose = -1;

		// Token: 0x04000C86 RID: 3206
		public int TRANS_IdleTurn180L_IdleTurnEndPose = -1;

		// Token: 0x04000C87 RID: 3207
		public int TRANS_IdleTurnEndPose_MoveTree = -1;
	}
}
