using System;
using com.ootii.Cameras;
using com.ootii.Helpers;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x02000118 RID: 280
	[MotionName("Walk Run Rotate (old)")]
	[MotionDescription("Simple walking motion that keeps the character facing forward, but rotates with the 'a' and 'd' keys.")]
	public class WalkRunRotate : MotionControllerMotion, IWalkRunMotion
	{
		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x060010F6 RID: 4342 RVA: 0x0005EA1B File Offset: 0x0005CC1B
		// (set) Token: 0x060010F7 RID: 4343 RVA: 0x0005EA23 File Offset: 0x0005CC23
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

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x060010F8 RID: 4344 RVA: 0x0005EA2C File Offset: 0x0005CC2C
		// (set) Token: 0x060010F9 RID: 4345 RVA: 0x0005EA34 File Offset: 0x0005CC34
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

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x060010FA RID: 4346 RVA: 0x0005EA3D File Offset: 0x0005CC3D
		// (set) Token: 0x060010FB RID: 4347 RVA: 0x0005EA45 File Offset: 0x0005CC45
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

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x060010FC RID: 4348 RVA: 0x0005EA4E File Offset: 0x0005CC4E
		// (set) Token: 0x060010FD RID: 4349 RVA: 0x0005EA56 File Offset: 0x0005CC56
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

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x060010FE RID: 4350 RVA: 0x0005EA5F File Offset: 0x0005CC5F
		// (set) Token: 0x060010FF RID: 4351 RVA: 0x0005EA67 File Offset: 0x0005CC67
		public bool RotateWithViewInputX
		{
			get
			{
				return this._RotateWithViewInputX;
			}
			set
			{
				this._RotateWithViewInputX = value;
			}
		}

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x06001100 RID: 4352 RVA: 0x0005EA70 File Offset: 0x0005CC70
		// (set) Token: 0x06001101 RID: 4353 RVA: 0x0005EA78 File Offset: 0x0005CC78
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

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x06001102 RID: 4354 RVA: 0x0005EA81 File Offset: 0x0005CC81
		// (set) Token: 0x06001103 RID: 4355 RVA: 0x0005EA89 File Offset: 0x0005CC89
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

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x06001104 RID: 4356 RVA: 0x0005EA92 File Offset: 0x0005CC92
		// (set) Token: 0x06001105 RID: 4357 RVA: 0x0005EA9A File Offset: 0x0005CC9A
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

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x06001106 RID: 4358 RVA: 0x0005EAB5 File Offset: 0x0005CCB5
		// (set) Token: 0x06001107 RID: 4359 RVA: 0x0005EABD File Offset: 0x0005CCBD
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

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x06001108 RID: 4360 RVA: 0x0005EAC6 File Offset: 0x0005CCC6
		// (set) Token: 0x06001109 RID: 4361 RVA: 0x0005EACE File Offset: 0x0005CCCE
		public float RotationToViewSpeed
		{
			get
			{
				return this._RotationToViewSpeed;
			}
			set
			{
				this._RotationToViewSpeed = value;
			}
		}

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x0600110A RID: 4362 RVA: 0x0005EAD7 File Offset: 0x0005CCD7
		// (set) Token: 0x0600110B RID: 4363 RVA: 0x0005EADF File Offset: 0x0005CCDF
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

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x0600110C RID: 4364 RVA: 0x0005EAE8 File Offset: 0x0005CCE8
		// (set) Token: 0x0600110D RID: 4365 RVA: 0x0005EAF0 File Offset: 0x0005CCF0
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

		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x0600110E RID: 4366 RVA: 0x0005EAF9 File Offset: 0x0005CCF9
		// (set) Token: 0x0600110F RID: 4367 RVA: 0x0005EB01 File Offset: 0x0005CD01
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

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x06001110 RID: 4368 RVA: 0x0005EB0A File Offset: 0x0005CD0A
		// (set) Token: 0x06001111 RID: 4369 RVA: 0x0005EB12 File Offset: 0x0005CD12
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

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x06001112 RID: 4370 RVA: 0x0005EB1C File Offset: 0x0005CD1C
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

		// Token: 0x06001113 RID: 4371 RVA: 0x0005EBA8 File Offset: 0x0005CDA8
		public WalkRunRotate()
		{
			this._Priority = 5f;
			this._ActionAlias = "Run";
			this.mIsStartable = true;
		}

		// Token: 0x06001114 RID: 4372 RVA: 0x0005EC34 File Offset: 0x0005CE34
		public WalkRunRotate(MotionController rController)
			: base(rController)
		{
			this._Priority = 5f;
			this._ActionAlias = "Run";
			this.mIsStartable = true;
		}

		// Token: 0x06001115 RID: 4373 RVA: 0x0005ECC0 File Offset: 0x0005CEC0
		public override void Awake()
		{
			base.Awake();
			this.mDegreesPer60FPSTick = this._RotationSpeed / 60f;
		}

		// Token: 0x06001116 RID: 4374 RVA: 0x0005ECDC File Offset: 0x0005CEDC
		public override bool TestActivate()
		{
			return this.mIsStartable && this.mMotionController.IsGrounded && this.mMotionController._InputSource != null && (this.mMotionController._InputSource.MovementY != 0f || this.mMotionController._InputSource.IsPressed(this._StrafeLeftActionAlias) || this.mMotionController._InputSource.IsPressed(this._StrafeRightActionAlias));
		}

		// Token: 0x06001117 RID: 4375 RVA: 0x0005ED5C File Offset: 0x0005CF5C
		public override bool TestUpdate()
		{
			if (this.mIsActivatedFrame)
			{
				return true;
			}
			if (!this.mMotionController.IsGrounded)
			{
				return false;
			}
			int animatorStateID = this.mMotionLayer._AnimatorStateID;
			int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
			if (animatorStateID == WalkRunRotate.STATE_IdlePose && animatorTransitionID == 0 && this.mMotionController._InputSource.MovementY == 0f && !this.mMotionController._InputSource.IsPressed(this._StrafeLeftActionAlias) && !this.mMotionController._InputSource.IsPressed(this._StrafeRightActionAlias))
			{
				return false;
			}
			if (this.mAge > 0.2f && this.mMotionController.ActiveMotion.Category == 1)
			{
				int trans_AnyState_IdlePose = WalkRunRotate.TRANS_AnyState_IdlePose;
			}
			return this.IsInMotionState;
		}

		// Token: 0x06001118 RID: 4376 RVA: 0x0005EE20 File Offset: 0x0005D020
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mYaw = 0f;
			this.mYawTarget = 0f;
			this.mYawVelocity = 0f;
			if (this.mMotionController._InputSource.IsPressed(this._RotateActionAlias) && this.mMotionController._CameraTransform != null)
			{
				float horizontalAngle = NumberHelper.GetHorizontalAngle(this.mActorController._Transform.forward, this.mMotionController._CameraTransform.forward, this.mActorController._Transform.up);
				this.mForceRotationToView = Mathf.Abs(horizontalAngle) > 1f;
			}
			if (this.mStartInRun)
			{
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1715, true);
			}
			else if (this.mStartInWalk)
			{
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1714, true);
			}
			else if (this.mMotionController._InputSource == null)
			{
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1700, true);
			}
			else
			{
				if ((!this._DefaultToRun || this.mMotionController._InputSource.IsPressed(this._ActionAlias)) && (this._DefaultToRun || !this.mMotionController._InputSource.IsPressed(this._ActionAlias)))
				{
					MotionState state = this.mMotionController.State;
					state.InputY *= 0.5f;
					if (state.InputMagnitudeTrend.Value > 0.5f)
					{
						state.InputMagnitudeTrend.Replace(0.5f);
					}
					this.mMotionController.State = state;
				}
				else
				{
					MotionState state2 = this.mMotionController.State;
					float num = (float)((state2.InputFromAvatarAngle < -90f || state2.InputFromAvatarAngle > 90f) ? (-1) : 1);
					state2.InputMagnitudeTrend.Value = num * 1f;
					state2.InputY = num * 1f;
					this.mMotionController.State = state2;
				}
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1700, true);
			}
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06001119 RID: 4377 RVA: 0x0005F056 File Offset: 0x0005D256
		public override void Deactivate()
		{
			this.mStartInRun = false;
			this.mStartInWalk = false;
			base.Deactivate();
		}

		// Token: 0x0600111A RID: 4378 RVA: 0x0005F06C File Offset: 0x0005D26C
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			if (this._RemoveLateralMovement)
			{
				AnimatorStateInfo stateInfo = this.mMotionController.State.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].StateInfo;
				int fullPathHash = stateInfo.fullPathHash;
				if (fullPathHash == WalkRunRotate.STATE_WalkFwdLoop || fullPathHash == WalkRunRotate.STATE_WalkToIdle || fullPathHash == WalkRunRotate.STATE_WalkToIdle_LDown || fullPathHash == WalkRunRotate.STATE_WalkToIdle_RDown || fullPathHash == WalkRunRotate.STATE_RunFwdLoop || fullPathHash == WalkRunRotate.STATE_WalkBackward)
				{
					rMovement.x = 0f;
				}
			}
			rRotation = Quaternion.identity;
		}

		// Token: 0x0600111B RID: 4379 RVA: 0x0005F0F8 File Offset: 0x0005D2F8
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mAngularVelocity = Vector3.zero;
			this.mRotation = Quaternion.identity;
			if (rUpdateIndex < 1)
			{
				return;
			}
			MotionState state = this.mMotionController.State;
			int motionPhase = state.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].MotionPhase;
			int num = state.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].MotionParameter;
			AnimatorStateInfo stateInfo = state.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].StateInfo;
			int fullPathHash = stateInfo.fullPathHash;
			if ((motionPhase == 1700 || motionPhase == 1710) && (fullPathHash == WalkRunRotate.STATE_IdlePose || fullPathHash == WalkRunRotate.STATE_IdleToRun))
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
			int num2 = (flag ? 1 : 0);
			bool flag2;
			if (this.mMotionController._InputSource.IsPressed(this._StrafeLeftActionAlias))
			{
				num = 2;
				flag2 = true;
				state.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].MotionParameter = num;
			}
			else if (this.mMotionController._InputSource.IsPressed(this._StrafeRightActionAlias))
			{
				num = 3;
				flag2 = true;
				state.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].MotionParameter = num;
			}
			else
			{
				num = num2;
				flag2 = true;
				state.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].MotionParameter = num;
			}
			if (fullPathHash == WalkRunRotate.STATE_WalkFwdLoop)
			{
				this.mStartInWalk = false;
				if (state.InputMagnitudeTrend.Value < 0.1f && (state.AnimatorStates[this.mMotionLayer.AnimatorLayerIndex].MotionPhase == 0 || state.AnimatorStates[this.mMotionLayer.AnimatorLayerIndex].MotionPhase == 1721 || state.AnimatorStates[this.mMotionLayer.AnimatorLayerIndex].MotionPhase == 1720))
				{
					float num3 = stateInfo.normalizedTime % 1f;
					if (num3 > 0.25f && num3 < 0.75f)
					{
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1721, true);
					}
					else
					{
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1720, true);
					}
				}
			}
			else if (fullPathHash == WalkRunRotate.STATE_RunFwdLoop)
			{
				this.mStartInRun = false;
			}
			if (flag2)
			{
				this.mMotionController.State = state;
			}
			if (this.mMotionController._InputSource.IsPressed(this._RotateActionAlias) && this.mMotionController._CameraTransform != null)
			{
				float horizontalAngle = NumberHelper.GetHorizontalAngle(this.mActorController._Transform.forward, this.mMotionController._CameraTransform.forward, this.mActorController._Transform.up);
				this.mForceRotationToView = Mathf.Abs(horizontalAngle) > 1f;
			}
			if (this.mForceRotationToView)
			{
				this.GetRotationVelocityWithView(rDeltaTime, ref this.mAngularVelocity);
				return;
			}
			if (this._RotateWithViewInputX || this._RotateWithMovementInputX)
			{
				this.GetRotationVelocityWithInput(rDeltaTime, ref this.mRotation);
				return;
			}
			this.GetRotationVelocityWithView(rDeltaTime, ref this.mAngularVelocity);
		}

		// Token: 0x0600111C RID: 4380 RVA: 0x0005F4E4 File Offset: 0x0005D6E4
		private void GetRotationVelocityWithInput(float rDeltaTime, ref Quaternion rRotation)
		{
			if (this.mMotionController._InputSource == null)
			{
				return;
			}
			float num = 0f;
			if (num == 0f && this._RotateWithMovementInputX)
			{
				num = this.mMotionController._InputSource.MovementX;
			}
			if (num == 0f && this._RotateWithViewInputX && this.mMotionController._InputSource.IsPressed(this._RotateActionAlias))
			{
				num = this.mMotionController._InputSource.ViewX;
			}
			if (num == 0f && !this.mMotionController._InputSource.IsPressed(this._RotateActionAlias))
			{
				num = 0f;
				this.mYawVelocity = 0f;
				this.mYawTarget = this.mYaw;
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

		// Token: 0x0600111D RID: 4381 RVA: 0x0005F640 File Offset: 0x0005D840
		private void GetRotationVelocityWithView(float rDeltaTime, ref Vector3 rRotationalVelocity)
		{
			if (this.mMotionController._CameraTransform == null)
			{
				return;
			}
			float num = 0f;
			float horizontalAngle = NumberHelper.GetHorizontalAngle(this.mActorController._Transform.forward, this.mMotionController._CameraTransform.forward, this.mActorController._Transform.up);
			float rotationToViewSpeed = this._RotationToViewSpeed;
			if (horizontalAngle > 0f)
			{
				if (rotationToViewSpeed == 0f)
				{
					num = horizontalAngle / rDeltaTime;
				}
				else
				{
					num = rotationToViewSpeed;
					if (num * rDeltaTime > horizontalAngle)
					{
						num = horizontalAngle / rDeltaTime;
					}
				}
			}
			else if (horizontalAngle < 0f)
			{
				if (rotationToViewSpeed == 0f)
				{
					num = horizontalAngle / rDeltaTime;
				}
				else
				{
					num = -rotationToViewSpeed;
					if (num * rDeltaTime < horizontalAngle)
					{
						num = horizontalAngle / rDeltaTime;
					}
				}
			}
			else
			{
				this.mForceRotationToView = false;
			}
			rRotationalVelocity = Vector3.up * num;
		}

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x0600111E RID: 4382 RVA: 0x0005F708 File Offset: 0x0005D908
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == WalkRunRotate.STATE_IdleToWalk || animatorStateID == WalkRunRotate.STATE_IdleToRun || animatorStateID == WalkRunRotate.STATE_RunFwdLoop || animatorStateID == WalkRunRotate.STATE_WalkToIdle_RDown || animatorStateID == WalkRunRotate.STATE_WalkToIdle_LDown || animatorStateID == WalkRunRotate.STATE_RunStop_RDown || animatorStateID == WalkRunRotate.STATE_RunStop_LDown || animatorStateID == WalkRunRotate.STATE_WalkToIdle || animatorStateID == WalkRunRotate.STATE_WalkFwdLoop || animatorStateID == WalkRunRotate.STATE_WalkBackward || animatorStateID == WalkRunRotate.STATE_IdlePose || animatorStateID == WalkRunRotate.STATE_WalkLeft || animatorStateID == WalkRunRotate.STATE_WalkRight || animatorTransitionID == WalkRunRotate.TRANS_EntryState_RunFwdLoop || animatorTransitionID == WalkRunRotate.TRANS_AnyState_RunFwdLoop || animatorTransitionID == WalkRunRotate.TRANS_EntryState_WalkFwdLoop || animatorTransitionID == WalkRunRotate.TRANS_AnyState_WalkFwdLoop || animatorTransitionID == WalkRunRotate.TRANS_EntryState_IdlePose || animatorTransitionID == WalkRunRotate.TRANS_AnyState_IdlePose || animatorTransitionID == WalkRunRotate.TRANS_EntryState_IdleToRun || animatorTransitionID == WalkRunRotate.TRANS_AnyState_IdleToRun || animatorTransitionID == WalkRunRotate.TRANS_IdleToWalk_WalkToIdle || animatorTransitionID == WalkRunRotate.TRANS_IdleToWalk_WalkFwdLoop || animatorTransitionID == WalkRunRotate.TRANS_IdleToRun_RunFwdLoop || animatorTransitionID == WalkRunRotate.TRANS_IdleToRun_RunStop_LDown || animatorTransitionID == WalkRunRotate.TRANS_IdleToRun_WalkFwdLoop || animatorTransitionID == WalkRunRotate.TRANS_RunFwdLoop_RunStop_RDown || animatorTransitionID == WalkRunRotate.TRANS_RunFwdLoop_RunStop_LDown || animatorTransitionID == WalkRunRotate.TRANS_RunFwdLoop_WalkFwdLoop || animatorTransitionID == WalkRunRotate.TRANS_WalkToIdle_RDown_IdlePose || animatorTransitionID == WalkRunRotate.TRANS_WalkToIdle_RDown_WalkFwdLoop || animatorTransitionID == WalkRunRotate.TRANS_WalkToIdle_LDown_IdlePose || animatorTransitionID == WalkRunRotate.TRANS_WalkToIdle_LDown_WalkFwdLoop || animatorTransitionID == WalkRunRotate.TRANS_RunStop_RDown_RunFwdLoop || animatorTransitionID == WalkRunRotate.TRANS_RunStop_RDown_IdlePose || animatorTransitionID == WalkRunRotate.TRANS_RunStop_LDown_RunFwdLoop || animatorTransitionID == WalkRunRotate.TRANS_RunStop_LDown_IdlePose || animatorTransitionID == WalkRunRotate.TRANS_WalkToIdle_IdlePose || animatorTransitionID == WalkRunRotate.TRANS_WalkFwdLoop_WalkBackward || animatorTransitionID == WalkRunRotate.TRANS_WalkFwdLoop_WalkLeft || animatorTransitionID == WalkRunRotate.TRANS_WalkFwdLoop_WalkRight || animatorTransitionID == WalkRunRotate.TRANS_WalkFwdLoop_RunFwdLoop || animatorTransitionID == WalkRunRotate.TRANS_WalkFwdLoop_WalkToIdle_LDown || animatorTransitionID == WalkRunRotate.TRANS_WalkFwdLoop_WalkToIdle_RDown || animatorTransitionID == WalkRunRotate.TRANS_WalkBackward_WalkFwdLoop || animatorTransitionID == WalkRunRotate.TRANS_WalkBackward_IdlePose || animatorTransitionID == WalkRunRotate.TRANS_WalkBackward_WalkLeft || animatorTransitionID == WalkRunRotate.TRANS_WalkBackward_WalkRight || animatorTransitionID == WalkRunRotate.TRANS_IdlePose_WalkBackward || animatorTransitionID == WalkRunRotate.TRANS_IdlePose_WalkLeft || animatorTransitionID == WalkRunRotate.TRANS_IdlePose_WalkRight || animatorTransitionID == WalkRunRotate.TRANS_IdlePose_IdleToWalk || animatorTransitionID == WalkRunRotate.TRANS_IdlePose_IdleToRun || animatorTransitionID == WalkRunRotate.TRANS_WalkLeft_WalkBackward || animatorTransitionID == WalkRunRotate.TRANS_WalkLeft_WalkFwdLoop || animatorTransitionID == WalkRunRotate.TRANS_WalkLeft_WalkRight || animatorTransitionID == WalkRunRotate.TRANS_WalkLeft_IdlePose || animatorTransitionID == WalkRunRotate.TRANS_WalkRight_WalkFwdLoop || animatorTransitionID == WalkRunRotate.TRANS_WalkRight_WalkBackward || animatorTransitionID == WalkRunRotate.TRANS_WalkRight_WalkLeft || animatorTransitionID == WalkRunRotate.TRANS_WalkRight_IdlePose;
			}
		}

		// Token: 0x0600111F RID: 4383 RVA: 0x0005F990 File Offset: 0x0005DB90
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == WalkRunRotate.STATE_IdleToWalk || rStateID == WalkRunRotate.STATE_IdleToRun || rStateID == WalkRunRotate.STATE_RunFwdLoop || rStateID == WalkRunRotate.STATE_WalkToIdle_RDown || rStateID == WalkRunRotate.STATE_WalkToIdle_LDown || rStateID == WalkRunRotate.STATE_RunStop_RDown || rStateID == WalkRunRotate.STATE_RunStop_LDown || rStateID == WalkRunRotate.STATE_WalkToIdle || rStateID == WalkRunRotate.STATE_WalkFwdLoop || rStateID == WalkRunRotate.STATE_WalkBackward || rStateID == WalkRunRotate.STATE_IdlePose || rStateID == WalkRunRotate.STATE_WalkLeft || rStateID == WalkRunRotate.STATE_WalkRight;
		}

		// Token: 0x06001120 RID: 4384 RVA: 0x0005FA20 File Offset: 0x0005DC20
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == WalkRunRotate.STATE_IdleToWalk || rStateID == WalkRunRotate.STATE_IdleToRun || rStateID == WalkRunRotate.STATE_RunFwdLoop || rStateID == WalkRunRotate.STATE_WalkToIdle_RDown || rStateID == WalkRunRotate.STATE_WalkToIdle_LDown || rStateID == WalkRunRotate.STATE_RunStop_RDown || rStateID == WalkRunRotate.STATE_RunStop_LDown || rStateID == WalkRunRotate.STATE_WalkToIdle || rStateID == WalkRunRotate.STATE_WalkFwdLoop || rStateID == WalkRunRotate.STATE_WalkBackward || rStateID == WalkRunRotate.STATE_IdlePose || rStateID == WalkRunRotate.STATE_WalkLeft || rStateID == WalkRunRotate.STATE_WalkRight || rTransitionID == WalkRunRotate.TRANS_EntryState_RunFwdLoop || rTransitionID == WalkRunRotate.TRANS_AnyState_RunFwdLoop || rTransitionID == WalkRunRotate.TRANS_EntryState_WalkFwdLoop || rTransitionID == WalkRunRotate.TRANS_AnyState_WalkFwdLoop || rTransitionID == WalkRunRotate.TRANS_EntryState_IdlePose || rTransitionID == WalkRunRotate.TRANS_AnyState_IdlePose || rTransitionID == WalkRunRotate.TRANS_EntryState_IdleToRun || rTransitionID == WalkRunRotate.TRANS_AnyState_IdleToRun || rTransitionID == WalkRunRotate.TRANS_IdleToWalk_WalkToIdle || rTransitionID == WalkRunRotate.TRANS_IdleToWalk_WalkFwdLoop || rTransitionID == WalkRunRotate.TRANS_IdleToRun_RunFwdLoop || rTransitionID == WalkRunRotate.TRANS_IdleToRun_RunStop_LDown || rTransitionID == WalkRunRotate.TRANS_IdleToRun_WalkFwdLoop || rTransitionID == WalkRunRotate.TRANS_RunFwdLoop_RunStop_RDown || rTransitionID == WalkRunRotate.TRANS_RunFwdLoop_RunStop_LDown || rTransitionID == WalkRunRotate.TRANS_RunFwdLoop_WalkFwdLoop || rTransitionID == WalkRunRotate.TRANS_WalkToIdle_RDown_IdlePose || rTransitionID == WalkRunRotate.TRANS_WalkToIdle_RDown_WalkFwdLoop || rTransitionID == WalkRunRotate.TRANS_WalkToIdle_LDown_IdlePose || rTransitionID == WalkRunRotate.TRANS_WalkToIdle_LDown_WalkFwdLoop || rTransitionID == WalkRunRotate.TRANS_RunStop_RDown_RunFwdLoop || rTransitionID == WalkRunRotate.TRANS_RunStop_RDown_IdlePose || rTransitionID == WalkRunRotate.TRANS_RunStop_LDown_RunFwdLoop || rTransitionID == WalkRunRotate.TRANS_RunStop_LDown_IdlePose || rTransitionID == WalkRunRotate.TRANS_WalkToIdle_IdlePose || rTransitionID == WalkRunRotate.TRANS_WalkFwdLoop_WalkBackward || rTransitionID == WalkRunRotate.TRANS_WalkFwdLoop_WalkLeft || rTransitionID == WalkRunRotate.TRANS_WalkFwdLoop_WalkRight || rTransitionID == WalkRunRotate.TRANS_WalkFwdLoop_RunFwdLoop || rTransitionID == WalkRunRotate.TRANS_WalkFwdLoop_WalkToIdle_LDown || rTransitionID == WalkRunRotate.TRANS_WalkFwdLoop_WalkToIdle_RDown || rTransitionID == WalkRunRotate.TRANS_WalkBackward_WalkFwdLoop || rTransitionID == WalkRunRotate.TRANS_WalkBackward_IdlePose || rTransitionID == WalkRunRotate.TRANS_WalkBackward_WalkLeft || rTransitionID == WalkRunRotate.TRANS_WalkBackward_WalkRight || rTransitionID == WalkRunRotate.TRANS_IdlePose_WalkBackward || rTransitionID == WalkRunRotate.TRANS_IdlePose_WalkLeft || rTransitionID == WalkRunRotate.TRANS_IdlePose_WalkRight || rTransitionID == WalkRunRotate.TRANS_IdlePose_IdleToWalk || rTransitionID == WalkRunRotate.TRANS_IdlePose_IdleToRun || rTransitionID == WalkRunRotate.TRANS_WalkLeft_WalkBackward || rTransitionID == WalkRunRotate.TRANS_WalkLeft_WalkFwdLoop || rTransitionID == WalkRunRotate.TRANS_WalkLeft_WalkRight || rTransitionID == WalkRunRotate.TRANS_WalkLeft_IdlePose || rTransitionID == WalkRunRotate.TRANS_WalkRight_WalkFwdLoop || rTransitionID == WalkRunRotate.TRANS_WalkRight_WalkBackward || rTransitionID == WalkRunRotate.TRANS_WalkRight_WalkLeft || rTransitionID == WalkRunRotate.TRANS_WalkRight_IdlePose;
		}

		// Token: 0x06001121 RID: 4385 RVA: 0x0005FC90 File Offset: 0x0005DE90
		public override void LoadAnimatorData()
		{
			WalkRunRotate.TRANS_EntryState_RunFwdLoop = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunRotate-SM.RunFwdLoop");
			WalkRunRotate.TRANS_AnyState_RunFwdLoop = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunRotate-SM.RunFwdLoop");
			WalkRunRotate.TRANS_EntryState_WalkFwdLoop = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunRotate-SM.WalkFwdLoop");
			WalkRunRotate.TRANS_AnyState_WalkFwdLoop = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunRotate-SM.WalkFwdLoop");
			WalkRunRotate.TRANS_EntryState_IdlePose = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunRotate-SM.IdlePose");
			WalkRunRotate.TRANS_AnyState_IdlePose = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunRotate-SM.IdlePose");
			WalkRunRotate.TRANS_EntryState_IdleToRun = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunRotate-SM.IdleToRun");
			WalkRunRotate.TRANS_AnyState_IdleToRun = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunRotate-SM.IdleToRun");
			WalkRunRotate.STATE_IdleToWalk = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.IdleToWalk");
			WalkRunRotate.TRANS_IdleToWalk_WalkToIdle = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.IdleToWalk -> Base Layer.WalkRunRotate-SM.WalkToIdle");
			WalkRunRotate.TRANS_IdleToWalk_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.IdleToWalk -> Base Layer.WalkRunRotate-SM.WalkFwdLoop");
			WalkRunRotate.STATE_IdleToRun = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.IdleToRun");
			WalkRunRotate.TRANS_IdleToRun_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.IdleToRun -> Base Layer.WalkRunRotate-SM.RunFwdLoop");
			WalkRunRotate.TRANS_IdleToRun_RunStop_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.IdleToRun -> Base Layer.WalkRunRotate-SM.RunStop_LDown");
			WalkRunRotate.TRANS_IdleToRun_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.IdleToRun -> Base Layer.WalkRunRotate-SM.WalkFwdLoop");
			WalkRunRotate.STATE_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.RunFwdLoop");
			WalkRunRotate.TRANS_RunFwdLoop_RunStop_RDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.RunFwdLoop -> Base Layer.WalkRunRotate-SM.RunStop_RDown");
			WalkRunRotate.TRANS_RunFwdLoop_RunStop_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.RunFwdLoop -> Base Layer.WalkRunRotate-SM.RunStop_LDown");
			WalkRunRotate.TRANS_RunFwdLoop_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.RunFwdLoop -> Base Layer.WalkRunRotate-SM.WalkFwdLoop");
			WalkRunRotate.STATE_WalkToIdle_RDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkToIdle_RDown");
			WalkRunRotate.TRANS_WalkToIdle_RDown_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkToIdle_RDown -> Base Layer.WalkRunRotate-SM.IdlePose");
			WalkRunRotate.TRANS_WalkToIdle_RDown_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkToIdle_RDown -> Base Layer.WalkRunRotate-SM.WalkFwdLoop");
			WalkRunRotate.STATE_WalkToIdle_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkToIdle_LDown");
			WalkRunRotate.TRANS_WalkToIdle_LDown_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkToIdle_LDown -> Base Layer.WalkRunRotate-SM.IdlePose");
			WalkRunRotate.TRANS_WalkToIdle_LDown_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkToIdle_LDown -> Base Layer.WalkRunRotate-SM.WalkFwdLoop");
			WalkRunRotate.STATE_RunStop_RDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.RunStop_RDown");
			WalkRunRotate.TRANS_RunStop_RDown_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.RunStop_RDown -> Base Layer.WalkRunRotate-SM.RunFwdLoop");
			WalkRunRotate.TRANS_RunStop_RDown_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.RunStop_RDown -> Base Layer.WalkRunRotate-SM.IdlePose");
			WalkRunRotate.STATE_RunStop_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.RunStop_LDown");
			WalkRunRotate.TRANS_RunStop_LDown_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.RunStop_LDown -> Base Layer.WalkRunRotate-SM.RunFwdLoop");
			WalkRunRotate.TRANS_RunStop_LDown_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.RunStop_LDown -> Base Layer.WalkRunRotate-SM.IdlePose");
			WalkRunRotate.STATE_WalkToIdle = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkToIdle");
			WalkRunRotate.TRANS_WalkToIdle_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkToIdle -> Base Layer.WalkRunRotate-SM.IdlePose");
			WalkRunRotate.STATE_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkFwdLoop");
			WalkRunRotate.TRANS_WalkFwdLoop_WalkBackward = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkFwdLoop -> Base Layer.WalkRunRotate-SM.WalkBackward");
			WalkRunRotate.TRANS_WalkFwdLoop_WalkLeft = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkFwdLoop -> Base Layer.WalkRunRotate-SM.WalkLeft");
			WalkRunRotate.TRANS_WalkFwdLoop_WalkRight = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkFwdLoop -> Base Layer.WalkRunRotate-SM.WalkRight");
			WalkRunRotate.TRANS_WalkFwdLoop_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkFwdLoop -> Base Layer.WalkRunRotate-SM.RunFwdLoop");
			WalkRunRotate.TRANS_WalkFwdLoop_WalkToIdle_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkFwdLoop -> Base Layer.WalkRunRotate-SM.WalkToIdle_LDown");
			WalkRunRotate.TRANS_WalkFwdLoop_WalkToIdle_RDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkFwdLoop -> Base Layer.WalkRunRotate-SM.WalkToIdle_RDown");
			WalkRunRotate.STATE_WalkBackward = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkBackward");
			WalkRunRotate.TRANS_WalkBackward_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkBackward -> Base Layer.WalkRunRotate-SM.WalkFwdLoop");
			WalkRunRotate.TRANS_WalkBackward_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkBackward -> Base Layer.WalkRunRotate-SM.IdlePose");
			WalkRunRotate.TRANS_WalkBackward_WalkLeft = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkBackward -> Base Layer.WalkRunRotate-SM.WalkLeft");
			WalkRunRotate.TRANS_WalkBackward_WalkRight = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkBackward -> Base Layer.WalkRunRotate-SM.WalkRight");
			WalkRunRotate.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.IdlePose");
			WalkRunRotate.TRANS_IdlePose_WalkBackward = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.IdlePose -> Base Layer.WalkRunRotate-SM.WalkBackward");
			WalkRunRotate.TRANS_IdlePose_WalkLeft = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.IdlePose -> Base Layer.WalkRunRotate-SM.WalkLeft");
			WalkRunRotate.TRANS_IdlePose_WalkRight = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.IdlePose -> Base Layer.WalkRunRotate-SM.WalkRight");
			WalkRunRotate.TRANS_IdlePose_IdleToWalk = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.IdlePose -> Base Layer.WalkRunRotate-SM.IdleToWalk");
			WalkRunRotate.TRANS_IdlePose_IdleToRun = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.IdlePose -> Base Layer.WalkRunRotate-SM.IdleToRun");
			WalkRunRotate.STATE_WalkLeft = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkLeft");
			WalkRunRotate.TRANS_WalkLeft_WalkBackward = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkLeft -> Base Layer.WalkRunRotate-SM.WalkBackward");
			WalkRunRotate.TRANS_WalkLeft_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkLeft -> Base Layer.WalkRunRotate-SM.WalkFwdLoop");
			WalkRunRotate.TRANS_WalkLeft_WalkRight = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkLeft -> Base Layer.WalkRunRotate-SM.WalkRight");
			WalkRunRotate.TRANS_WalkLeft_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkLeft -> Base Layer.WalkRunRotate-SM.IdlePose");
			WalkRunRotate.STATE_WalkRight = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkRight");
			WalkRunRotate.TRANS_WalkRight_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkRight -> Base Layer.WalkRunRotate-SM.WalkFwdLoop");
			WalkRunRotate.TRANS_WalkRight_WalkBackward = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkRight -> Base Layer.WalkRunRotate-SM.WalkBackward");
			WalkRunRotate.TRANS_WalkRight_WalkLeft = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkRight -> Base Layer.WalkRunRotate-SM.WalkLeft");
			WalkRunRotate.TRANS_WalkRight_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunRotate-SM.WalkRight -> Base Layer.WalkRunRotate-SM.IdlePose");
		}

		// Token: 0x04000C88 RID: 3208
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000C89 RID: 3209
		public const int PHASE_START = 1700;

		// Token: 0x04000C8A RID: 3210
		public const int PHASE_START_RUN = 1710;

		// Token: 0x04000C8B RID: 3211
		public const int PHASE_START_SHORTCUT_WALK = 1714;

		// Token: 0x04000C8C RID: 3212
		public const int PHASE_START_SHORTCUT_RUN = 1715;

		// Token: 0x04000C8D RID: 3213
		public const int PHASE_STOP_RIGHT_DOWN = 1720;

		// Token: 0x04000C8E RID: 3214
		public const int PHASE_STOP_LEFT_DOWN = 1721;

		// Token: 0x04000C8F RID: 3215
		public bool _DefaultToRun;

		// Token: 0x04000C90 RID: 3216
		public string _RotateActionAlias = "ActivateRotation";

		// Token: 0x04000C91 RID: 3217
		public string _StrafeLeftActionAlias = "StrafeLeft";

		// Token: 0x04000C92 RID: 3218
		public string _StrafeRightActionAlias = "StrafeRight";

		// Token: 0x04000C93 RID: 3219
		public bool _RotateWithViewInputX = true;

		// Token: 0x04000C94 RID: 3220
		public bool _RotateWithMovementInputX;

		// Token: 0x04000C95 RID: 3221
		public bool _ForceViewOnInput;

		// Token: 0x04000C96 RID: 3222
		public float _RotationSpeed = 120f;

		// Token: 0x04000C97 RID: 3223
		public float _RotationSmoothing = 0.1f;

		// Token: 0x04000C98 RID: 3224
		public float _RotationToViewSpeed = 360f;

		// Token: 0x04000C99 RID: 3225
		public bool _RemoveLateralMovement = true;

		// Token: 0x04000C9A RID: 3226
		private bool mStartInMove;

		// Token: 0x04000C9B RID: 3227
		private bool mStartInWalk;

		// Token: 0x04000C9C RID: 3228
		private bool mStartInRun;

		// Token: 0x04000C9D RID: 3229
		protected bool mForceRotationToView;

		// Token: 0x04000C9E RID: 3230
		protected float mDegreesPer60FPSTick = 1f;

		// Token: 0x04000C9F RID: 3231
		protected float mYaw;

		// Token: 0x04000CA0 RID: 3232
		protected float mYawTarget;

		// Token: 0x04000CA1 RID: 3233
		protected float mYawVelocity;

		// Token: 0x04000CA2 RID: 3234
		public static int TRANS_EntryState_RunFwdLoop = -1;

		// Token: 0x04000CA3 RID: 3235
		public static int TRANS_AnyState_RunFwdLoop = -1;

		// Token: 0x04000CA4 RID: 3236
		public static int TRANS_EntryState_WalkFwdLoop = -1;

		// Token: 0x04000CA5 RID: 3237
		public static int TRANS_AnyState_WalkFwdLoop = -1;

		// Token: 0x04000CA6 RID: 3238
		public static int TRANS_EntryState_IdlePose = -1;

		// Token: 0x04000CA7 RID: 3239
		public static int TRANS_AnyState_IdlePose = -1;

		// Token: 0x04000CA8 RID: 3240
		public static int TRANS_EntryState_IdleToRun = -1;

		// Token: 0x04000CA9 RID: 3241
		public static int TRANS_AnyState_IdleToRun = -1;

		// Token: 0x04000CAA RID: 3242
		public static int STATE_IdleToWalk = -1;

		// Token: 0x04000CAB RID: 3243
		public static int TRANS_IdleToWalk_WalkToIdle = -1;

		// Token: 0x04000CAC RID: 3244
		public static int TRANS_IdleToWalk_WalkFwdLoop = -1;

		// Token: 0x04000CAD RID: 3245
		public static int STATE_IdleToRun = -1;

		// Token: 0x04000CAE RID: 3246
		public static int TRANS_IdleToRun_RunFwdLoop = -1;

		// Token: 0x04000CAF RID: 3247
		public static int TRANS_IdleToRun_RunStop_LDown = -1;

		// Token: 0x04000CB0 RID: 3248
		public static int TRANS_IdleToRun_WalkFwdLoop = -1;

		// Token: 0x04000CB1 RID: 3249
		public static int STATE_RunFwdLoop = -1;

		// Token: 0x04000CB2 RID: 3250
		public static int TRANS_RunFwdLoop_RunStop_RDown = -1;

		// Token: 0x04000CB3 RID: 3251
		public static int TRANS_RunFwdLoop_RunStop_LDown = -1;

		// Token: 0x04000CB4 RID: 3252
		public static int TRANS_RunFwdLoop_WalkFwdLoop = -1;

		// Token: 0x04000CB5 RID: 3253
		public static int STATE_WalkToIdle_RDown = -1;

		// Token: 0x04000CB6 RID: 3254
		public static int TRANS_WalkToIdle_RDown_IdlePose = -1;

		// Token: 0x04000CB7 RID: 3255
		public static int TRANS_WalkToIdle_RDown_WalkFwdLoop = -1;

		// Token: 0x04000CB8 RID: 3256
		public static int STATE_WalkToIdle_LDown = -1;

		// Token: 0x04000CB9 RID: 3257
		public static int TRANS_WalkToIdle_LDown_IdlePose = -1;

		// Token: 0x04000CBA RID: 3258
		public static int TRANS_WalkToIdle_LDown_WalkFwdLoop = -1;

		// Token: 0x04000CBB RID: 3259
		public static int STATE_RunStop_RDown = -1;

		// Token: 0x04000CBC RID: 3260
		public static int TRANS_RunStop_RDown_RunFwdLoop = -1;

		// Token: 0x04000CBD RID: 3261
		public static int TRANS_RunStop_RDown_IdlePose = -1;

		// Token: 0x04000CBE RID: 3262
		public static int STATE_RunStop_LDown = -1;

		// Token: 0x04000CBF RID: 3263
		public static int TRANS_RunStop_LDown_RunFwdLoop = -1;

		// Token: 0x04000CC0 RID: 3264
		public static int TRANS_RunStop_LDown_IdlePose = -1;

		// Token: 0x04000CC1 RID: 3265
		public static int STATE_WalkToIdle = -1;

		// Token: 0x04000CC2 RID: 3266
		public static int TRANS_WalkToIdle_IdlePose = -1;

		// Token: 0x04000CC3 RID: 3267
		public static int STATE_WalkFwdLoop = -1;

		// Token: 0x04000CC4 RID: 3268
		public static int TRANS_WalkFwdLoop_WalkBackward = -1;

		// Token: 0x04000CC5 RID: 3269
		public static int TRANS_WalkFwdLoop_WalkLeft = -1;

		// Token: 0x04000CC6 RID: 3270
		public static int TRANS_WalkFwdLoop_WalkRight = -1;

		// Token: 0x04000CC7 RID: 3271
		public static int TRANS_WalkFwdLoop_RunFwdLoop = -1;

		// Token: 0x04000CC8 RID: 3272
		public static int TRANS_WalkFwdLoop_WalkToIdle_LDown = -1;

		// Token: 0x04000CC9 RID: 3273
		public static int TRANS_WalkFwdLoop_WalkToIdle_RDown = -1;

		// Token: 0x04000CCA RID: 3274
		public static int STATE_WalkBackward = -1;

		// Token: 0x04000CCB RID: 3275
		public static int TRANS_WalkBackward_WalkFwdLoop = -1;

		// Token: 0x04000CCC RID: 3276
		public static int TRANS_WalkBackward_IdlePose = -1;

		// Token: 0x04000CCD RID: 3277
		public static int TRANS_WalkBackward_WalkLeft = -1;

		// Token: 0x04000CCE RID: 3278
		public static int TRANS_WalkBackward_WalkRight = -1;

		// Token: 0x04000CCF RID: 3279
		public static int STATE_IdlePose = -1;

		// Token: 0x04000CD0 RID: 3280
		public static int TRANS_IdlePose_WalkBackward = -1;

		// Token: 0x04000CD1 RID: 3281
		public static int TRANS_IdlePose_WalkLeft = -1;

		// Token: 0x04000CD2 RID: 3282
		public static int TRANS_IdlePose_WalkRight = -1;

		// Token: 0x04000CD3 RID: 3283
		public static int TRANS_IdlePose_IdleToWalk = -1;

		// Token: 0x04000CD4 RID: 3284
		public static int TRANS_IdlePose_IdleToRun = -1;

		// Token: 0x04000CD5 RID: 3285
		public static int STATE_WalkLeft = -1;

		// Token: 0x04000CD6 RID: 3286
		public static int TRANS_WalkLeft_WalkBackward = -1;

		// Token: 0x04000CD7 RID: 3287
		public static int TRANS_WalkLeft_WalkFwdLoop = -1;

		// Token: 0x04000CD8 RID: 3288
		public static int TRANS_WalkLeft_WalkRight = -1;

		// Token: 0x04000CD9 RID: 3289
		public static int TRANS_WalkLeft_IdlePose = -1;

		// Token: 0x04000CDA RID: 3290
		public static int STATE_WalkRight = -1;

		// Token: 0x04000CDB RID: 3291
		public static int TRANS_WalkRight_WalkFwdLoop = -1;

		// Token: 0x04000CDC RID: 3292
		public static int TRANS_WalkRight_WalkBackward = -1;

		// Token: 0x04000CDD RID: 3293
		public static int TRANS_WalkRight_WalkLeft = -1;

		// Token: 0x04000CDE RID: 3294
		public static int TRANS_WalkRight_IdlePose = -1;
	}
}
