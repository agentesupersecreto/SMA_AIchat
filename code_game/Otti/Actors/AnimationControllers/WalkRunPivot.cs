using System;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x02000116 RID: 278
	[MotionName("Walk Run Pivot (old)")]
	[MotionDescription("Standard movement (walk/run) for an adventure game.")]
	public class WalkRunPivot : MotionControllerMotion, IWalkRunMotion
	{
		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x0600109A RID: 4250 RVA: 0x000590A5 File Offset: 0x000572A5
		// (set) Token: 0x0600109B RID: 4251 RVA: 0x000590AD File Offset: 0x000572AD
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

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x0600109C RID: 4252 RVA: 0x000590B6 File Offset: 0x000572B6
		// (set) Token: 0x0600109D RID: 4253 RVA: 0x000590BE File Offset: 0x000572BE
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

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x0600109E RID: 4254 RVA: 0x000590C7 File Offset: 0x000572C7
		// (set) Token: 0x0600109F RID: 4255 RVA: 0x000590CF File Offset: 0x000572CF
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

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x060010A0 RID: 4256 RVA: 0x000590D8 File Offset: 0x000572D8
		// (set) Token: 0x060010A1 RID: 4257 RVA: 0x000590E0 File Offset: 0x000572E0
		public float PivotSpeed
		{
			get
			{
				return this._PivotSpeed;
			}
			set
			{
				this._PivotSpeed = value;
			}
		}

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x060010A2 RID: 4258 RVA: 0x000590E9 File Offset: 0x000572E9
		// (set) Token: 0x060010A3 RID: 4259 RVA: 0x000590F1 File Offset: 0x000572F1
		public float StopDelay
		{
			get
			{
				return this._StopDelay;
			}
			set
			{
				this._StopDelay = value;
			}
		}

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x060010A4 RID: 4260 RVA: 0x000590FA File Offset: 0x000572FA
		// (set) Token: 0x060010A5 RID: 4261 RVA: 0x00059102 File Offset: 0x00057302
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

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x060010A6 RID: 4262 RVA: 0x0005910B File Offset: 0x0005730B
		// (set) Token: 0x060010A7 RID: 4263 RVA: 0x00059113 File Offset: 0x00057313
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

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x060010A8 RID: 4264 RVA: 0x0005911C File Offset: 0x0005731C
		// (set) Token: 0x060010A9 RID: 4265 RVA: 0x00059124 File Offset: 0x00057324
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

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x060010AA RID: 4266 RVA: 0x0005912D File Offset: 0x0005732D
		// (set) Token: 0x060010AB RID: 4267 RVA: 0x00059135 File Offset: 0x00057335
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

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x060010AC RID: 4268 RVA: 0x00059140 File Offset: 0x00057340
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

		// Token: 0x060010AD RID: 4269 RVA: 0x000591CC File Offset: 0x000573CC
		public WalkRunPivot()
		{
			this._Priority = 5f;
			this._ActionAlias = "Run";
			this.mIsStartable = true;
		}

		// Token: 0x060010AE RID: 4270 RVA: 0x00059230 File Offset: 0x00057430
		public WalkRunPivot(MotionController rController)
			: base(rController)
		{
			this._Priority = 5f;
			this._ActionAlias = "Run";
			this.mIsStartable = true;
		}

		// Token: 0x060010AF RID: 4271 RVA: 0x00059294 File Offset: 0x00057494
		public override void Awake()
		{
			base.Awake();
		}

		// Token: 0x060010B0 RID: 4272 RVA: 0x0005929C File Offset: 0x0005749C
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
			MotionState state = this.mMotionController.State;
			return state.InputMagnitudeTrend.Value >= 0.03f && this.mMotionController.Stance == 0;
		}

		// Token: 0x060010B1 RID: 4273 RVA: 0x000592F4 File Offset: 0x000574F4
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
			MotionState state = this.mMotionController.State;
			int animatorStateID = this.mMotionLayer._AnimatorStateID;
			int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
			return (this.mAge <= 0.2f || animatorStateID != WalkRunPivot.STATE_IdlePose || state.InputMagnitudeTrend.Value != 0f) && (this.mAge <= 0.2f || this.mMotionController.ActiveMotion.Category != 1 || animatorTransitionID == WalkRunPivot.TRANS_AnyState_IdlePose) && (!this.mIsAnimatorActive || this.IsMotionState(animatorStateID) || this.mStartInRun || this.mStartInWalk || animatorTransitionID == WalkRunPivot.TRANS_EntryState_IdlePose || animatorTransitionID == WalkRunPivot.TRANS_EntryState_IdleToWalk || animatorTransitionID == WalkRunPivot.TRANS_EntryState_IdleToRun || animatorTransitionID == WalkRunPivot.TRANS_EntryState_IdleTurn20R || animatorTransitionID == WalkRunPivot.TRANS_EntryState_IdleTurn90R || animatorTransitionID == WalkRunPivot.TRANS_EntryState_IdleTurn180R || animatorTransitionID == WalkRunPivot.TRANS_EntryState_IdleTurn20L || animatorTransitionID == WalkRunPivot.TRANS_EntryState_IdleTurn90L || animatorTransitionID == WalkRunPivot.TRANS_EntryState_IdleTurn180L || animatorTransitionID == WalkRunPivot.TRANS_EntryState_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_EntryState_WalkFwdLoop);
		}

		// Token: 0x060010B2 RID: 4274 RVA: 0x0005940E File Offset: 0x0005760E
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			return !(rMotion is Idle);
		}

		// Token: 0x060010B3 RID: 4275 RVA: 0x0005941C File Offset: 0x0005761C
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			if (this.mStartInRun)
			{
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 27115, true);
			}
			else if (this.mStartInWalk)
			{
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 27114, true);
			}
			else if (this.mMotionController._InputSource == null)
			{
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 27100, true);
			}
			else
			{
				if ((this._DefaultToRun && !this.mMotionController._InputSource.IsPressed(this._ActionAlias)) || (!this._DefaultToRun && this.mMotionController._InputSource.IsPressed(this._ActionAlias)))
				{
					MotionState state = this.mMotionController.State;
					state.InputMagnitudeTrend.Value = 1f;
					this.mMotionController.State = state;
				}
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 27100, true);
			}
			this.mInputInactiveStartTime = 0f;
			this.mInputFromAvatarAngleStart = this.mMotionController.State.InputFromAvatarAngle;
			this.mInputFromAvatarAngleUsed = 0f;
			return base.Activate(rPrevMotion);
		}

		// Token: 0x060010B4 RID: 4276 RVA: 0x00059567 File Offset: 0x00057767
		public override void Deactivate()
		{
			this.mStartInRun = false;
			this.mStartInWalk = false;
			base.Deactivate();
		}

		// Token: 0x060010B5 RID: 4277 RVA: 0x00059580 File Offset: 0x00057780
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			int animatorStateID = this.mMotionLayer._AnimatorStateID;
			int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
			if (animatorTransitionID == WalkRunPivot.TRANS_EntryState_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_EntryState_WalkFwdLoop)
			{
				rRotation = Quaternion.identity;
				if (this._RemoveLateralMovement)
				{
					rMovement.x = 0f;
				}
			}
			else if (animatorStateID == WalkRunPivot.STATE_WalkToIdle_RDown || animatorStateID == WalkRunPivot.STATE_WalkToIdle_LDown)
			{
				rRotation = Quaternion.identity;
			}
			else if (animatorStateID == WalkRunPivot.STATE_IdleTurn20L || animatorStateID == WalkRunPivot.STATE_IdleTurn20R)
			{
				rRotation = Quaternion.identity;
			}
			if (this._RemoveLateralMovement && (animatorStateID == WalkRunPivot.STATE_WalkFwdLoop || animatorStateID == WalkRunPivot.STATE_IdleToWalk))
			{
				rMovement.x = 0f;
			}
			if (rMovement.z < 0f)
			{
				rMovement.z = 0f;
			}
		}

		// Token: 0x060010B6 RID: 4278 RVA: 0x0005964C File Offset: 0x0005784C
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			if (rUpdateIndex < 1)
			{
				return;
			}
			bool flag = true;
			MotionState state = this.mMotionController.State;
			int motionPhase = state.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].MotionPhase;
			AnimatorStateInfo stateInfo = state.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].StateInfo;
			int fullPathHash = stateInfo.fullPathHash;
			if (motionPhase == 27100 && (fullPathHash == WalkRunPivot.STATE_IdlePose || fullPathHash == WalkRunPivot.STATE_IdleTurn20L || fullPathHash == WalkRunPivot.STATE_IdleTurn90L || fullPathHash == WalkRunPivot.STATE_IdleTurn180L || fullPathHash == WalkRunPivot.STATE_IdleTurn20R || fullPathHash == WalkRunPivot.STATE_IdleTurn90R || fullPathHash == WalkRunPivot.STATE_IdleTurn180R))
			{
				state.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].MotionPhase = 0;
			}
			bool flag2 = this._DefaultToRun;
			if (this.mMotionController._InputSource == null)
			{
				flag2 = this.mMotionController.State.InputMagnitudeTrend.Value > 0.9f;
			}
			else
			{
				flag2 = (this._DefaultToRun && !this.mMotionController._InputSource.IsPressed(this._ActionAlias)) || (!this._DefaultToRun && this.mMotionController._InputSource.IsPressed(this._ActionAlias));
			}
			if (!flag2)
			{
				state.InputY *= 0.5f;
				if (state.InputMagnitudeTrend.Value > 0.5f)
				{
					state.InputMagnitudeTrend.Replace(0.5f);
				}
			}
			int num = ((flag2 && state.InputMagnitudeTrend.Value > 0.9f) ? 1 : 0);
			bool flag3 = true;
			state.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].MotionParameter = num;
			if (state.InputMagnitudeTrend.Value >= 0.5f || this._StopDelay == 0f || (fullPathHash != WalkRunPivot.STATE_WalkFwdLoop && fullPathHash != WalkRunPivot.STATE_RunFwdLoop))
			{
				if (this.mInputInactiveStartTime == 0f)
				{
					this.mInputMagnitude = state.InputMagnitudeTrend.Value;
				}
				else if (state.InputMagnitudeTrend.Value < 0.6f && this.mInputInactiveStartTime + this._StopDelay > Time.time)
				{
					flag = false;
					flag3 = true;
					state.InputMagnitudeTrend.Replace(this.mInputMagnitude);
				}
				else
				{
					this.mInputInactiveStartTime = 0f;
				}
			}
			else
			{
				if (this.mInputInactiveStartTime == 0f)
				{
					this.mInputInactiveStartTime = Time.time;
				}
				if (this.mInputInactiveStartTime + this._StopDelay > Time.time)
				{
					flag = false;
					flag3 = true;
					state.InputMagnitudeTrend.Replace(this.mInputMagnitude);
				}
			}
			if (flag)
			{
				this.mAngularVelocity = Vector3.zero;
				if (fullPathHash == WalkRunPivot.STATE_IdleToWalk || fullPathHash == WalkRunPivot.STATE_IdleToRun)
				{
					float num2 = Mathf.Clamp01(stateInfo.normalizedTime);
					this.mAngularVelocity.y = this.GetRotationSpeed(this.mMotionController.State.InputFromAvatarAngle, rDeltaTime) * num2;
				}
				else if (fullPathHash == WalkRunPivot.STATE_WalkFwdLoop)
				{
					if (Mathf.Abs(state.InputFromAvatarAngle) < 140f)
					{
						this.mAngularVelocity.y = this.GetRotationSpeed(this.mMotionController.State.InputFromAvatarAngle, rDeltaTime);
					}
					if (state.InputMagnitudeTrend.Value < 0.1f && (state.AnimatorStates[this.mMotionLayer.AnimatorLayerIndex].MotionPhase == 0 || state.AnimatorStates[this.mMotionLayer.AnimatorLayerIndex].MotionPhase == 27121 || state.AnimatorStates[this.mMotionLayer.AnimatorLayerIndex].MotionPhase == 27120))
					{
						float num3 = stateInfo.normalizedTime % 1f;
						if (num3 > 0.25f && num3 < 0.75f)
						{
							this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 27121, true);
						}
						else
						{
							this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 27120, true);
						}
					}
				}
				else if (fullPathHash == WalkRunPivot.STATE_RunFwdLoop || fullPathHash == WalkRunPivot.STATE_RunStop_RDown || fullPathHash == WalkRunPivot.STATE_RunStop_LDown)
				{
					if (Mathf.Abs(state.InputFromAvatarAngle) < 140f)
					{
						this.mAngularVelocity.y = this.GetRotationSpeed(this.mMotionController.State.InputFromAvatarAngle, rDeltaTime);
					}
				}
				else if (fullPathHash == WalkRunPivot.STATE_IdleToWalk90L || fullPathHash == WalkRunPivot.STATE_IdleToWalk90R)
				{
					if (stateInfo.normalizedTime > 0.7f)
					{
						float num4 = Mathf.Clamp01((stateInfo.normalizedTime - 0.7f) / 0.3f);
						this.mAngularVelocity.y = this.GetRotationSpeed(this.mMotionController.State.InputFromAvatarAngle, rDeltaTime) * num4;
					}
				}
				else if (fullPathHash == WalkRunPivot.STATE_WalkPivot180L)
				{
					if (stateInfo.normalizedTime > 0.95f)
					{
						float num5 = Mathf.Clamp01((stateInfo.normalizedTime - 0.95f) / 0.05f);
						this.mAngularVelocity.y = this.GetRotationSpeed(this.mMotionController.State.InputFromAvatarAngle, rDeltaTime) * num5;
					}
				}
				else if (fullPathHash == WalkRunPivot.STATE_WalkPivot180R && stateInfo.normalizedTime > 0.7f)
				{
					float num6 = Mathf.Clamp01((stateInfo.normalizedTime - 0.7f) / 0.3f);
					this.mAngularVelocity.y = this.GetRotationSpeed(this.mMotionController.State.InputFromAvatarAngle, rDeltaTime) * num6;
				}
			}
			if (fullPathHash == WalkRunPivot.STATE_WalkFwdLoop || fullPathHash == WalkRunPivot.STATE_RunFwdLoop)
			{
				this.mStartInRun = false;
				this.mStartInWalk = false;
			}
			this.mRotation = Quaternion.identity;
			if (fullPathHash == WalkRunPivot.STATE_IdleTurn20L || fullPathHash == WalkRunPivot.STATE_IdleTurn20R)
			{
				float num7 = Mathf.Clamp01((stateInfo.normalizedTime - 0.55f) / 0.45f);
				float num8 = this.mInputFromAvatarAngleStart * num7;
				float num9 = num8 - this.mInputFromAvatarAngleUsed;
				this.mRotation = Quaternion.Euler(0f, num9, 0f);
				this.mInputFromAvatarAngleUsed = num8;
			}
			if (flag3)
			{
				this.mMotionController.State = state;
			}
		}

		// Token: 0x060010B7 RID: 4279 RVA: 0x00059C70 File Offset: 0x00057E70
		private float GetRotationSpeed(float rAngle, float rDeltaTime)
		{
			int num = 0;
			float num2 = Mathf.Abs(rAngle);
			if (this._RotationSpeed == 0f && num2 > 10f)
			{
				num = 1;
			}
			else if (this._MinPivotAngle != 0f && num2 >= this._MinPivotAngle)
			{
				num = 1;
			}
			float num3 = Mathf.Sign(rAngle) * ((num == 0) ? this._RotationSpeed : this._PivotSpeed);
			if (num3 == 0f || Mathf.Abs(num3 * rDeltaTime) > num2)
			{
				num3 = rAngle / rDeltaTime;
			}
			return num3;
		}

		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x060010B8 RID: 4280 RVA: 0x00059CE8 File Offset: 0x00057EE8
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == WalkRunPivot.STATE_IdleToWalk || animatorStateID == WalkRunPivot.STATE_IdleToRun || animatorStateID == WalkRunPivot.STATE_IdleTurn90L || animatorStateID == WalkRunPivot.STATE_IdleTurn180L || animatorStateID == WalkRunPivot.STATE_IdleToWalk90L || animatorStateID == WalkRunPivot.STATE_IdleToWalk180L || animatorStateID == WalkRunPivot.STATE_IdleToRun90L || animatorStateID == WalkRunPivot.STATE_IdleToRun180L || animatorStateID == WalkRunPivot.STATE_IdleTurn90R || animatorStateID == WalkRunPivot.STATE_IdleTurn180R || animatorStateID == WalkRunPivot.STATE_IdleToWalk90R || animatorStateID == WalkRunPivot.STATE_IdleToWalk180R || animatorStateID == WalkRunPivot.STATE_IdleToRun90R || animatorStateID == WalkRunPivot.STATE_IdleToRun180R || animatorStateID == WalkRunPivot.STATE_IdlePose || animatorStateID == WalkRunPivot.STATE_WalkFwdLoop || animatorStateID == WalkRunPivot.STATE_RunFwdLoop || animatorStateID == WalkRunPivot.STATE_RunPivot180L_RDown || animatorStateID == WalkRunPivot.STATE_RunPivot180R_LDown || animatorStateID == WalkRunPivot.STATE_WalkToIdle_RDown || animatorStateID == WalkRunPivot.STATE_WalkToIdle_LDown || animatorStateID == WalkRunPivot.STATE_RunStop_RDown || animatorStateID == WalkRunPivot.STATE_RunStop_LDown || animatorStateID == WalkRunPivot.STATE_RunPivot180L_LDown || animatorStateID == WalkRunPivot.STATE_RunPivot180R_RDown || animatorStateID == WalkRunPivot.STATE_IdleTurn20R || animatorStateID == WalkRunPivot.STATE_IdleTurn20L || animatorStateID == WalkRunPivot.STATE_WalkToIdle || animatorStateID == WalkRunPivot.STATE_WalkPivot180L || animatorStateID == WalkRunPivot.STATE_WalkPivot180R || animatorTransitionID == WalkRunPivot.TRANS_EntryState_IdleTurn20R || animatorTransitionID == WalkRunPivot.TRANS_AnyState_IdleTurn20R || animatorTransitionID == WalkRunPivot.TRANS_EntryState_IdleTurn90R || animatorTransitionID == WalkRunPivot.TRANS_AnyState_IdleTurn90R || animatorTransitionID == WalkRunPivot.TRANS_EntryState_IdleTurn180R || animatorTransitionID == WalkRunPivot.TRANS_AnyState_IdleTurn180R || animatorTransitionID == WalkRunPivot.TRANS_EntryState_IdleTurn20L || animatorTransitionID == WalkRunPivot.TRANS_AnyState_IdleTurn20L || animatorTransitionID == WalkRunPivot.TRANS_EntryState_IdleTurn90L || animatorTransitionID == WalkRunPivot.TRANS_AnyState_IdleTurn90L || animatorTransitionID == WalkRunPivot.TRANS_EntryState_IdleTurn180L || animatorTransitionID == WalkRunPivot.TRANS_AnyState_IdleTurn180L || animatorTransitionID == WalkRunPivot.TRANS_EntryState_IdlePose || animatorTransitionID == WalkRunPivot.TRANS_AnyState_IdlePose || animatorTransitionID == WalkRunPivot.TRANS_EntryState_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_AnyState_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_EntryState_WalkFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_AnyState_WalkFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_EntryState_IdleToWalk || animatorTransitionID == WalkRunPivot.TRANS_AnyState_IdleToWalk || animatorTransitionID == WalkRunPivot.TRANS_EntryState_IdleToRun || animatorTransitionID == WalkRunPivot.TRANS_AnyState_IdleToRun || animatorTransitionID == WalkRunPivot.TRANS_IdleToWalk_WalkFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_IdleToWalk_WalkToIdle || animatorTransitionID == WalkRunPivot.TRANS_IdleToRun_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_IdleToRun_RunStop_LDown || animatorTransitionID == WalkRunPivot.TRANS_IdleTurn90L_WalkFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_IdleTurn90L_IdlePose || animatorTransitionID == WalkRunPivot.TRANS_IdleTurn90L_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_IdleTurn180L_WalkFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_IdleTurn180L_IdlePose || animatorTransitionID == WalkRunPivot.TRANS_IdleTurn180L_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_IdleToWalk90L_WalkFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_IdleToWalk90L_IdlePose || animatorTransitionID == WalkRunPivot.TRANS_IdleToWalk180L_WalkFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_IdleToWalk180L_IdlePose || animatorTransitionID == WalkRunPivot.TRANS_IdleToRun90L_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_IdleToRun90L_RunStop_LDown || animatorTransitionID == WalkRunPivot.TRANS_IdleToRun180L_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_IdleToRun180L_RunStop_LDown || animatorTransitionID == WalkRunPivot.TRANS_IdleTurn90R_WalkFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_IdleTurn90R_IdlePose || animatorTransitionID == WalkRunPivot.TRANS_IdleTurn90R_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_IdleTurn180R_IdlePose || animatorTransitionID == WalkRunPivot.TRANS_IdleTurn180R_WalkFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_IdleTurn180R_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_IdleToWalk90R_WalkFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_IdleToWalk90R_IdlePose || animatorTransitionID == WalkRunPivot.TRANS_IdleToWalk180R_WalkFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_IdleToWalk180R_IdlePose || animatorTransitionID == WalkRunPivot.TRANS_IdleToRun90R_RunStop_LDown || animatorTransitionID == WalkRunPivot.TRANS_IdleToRun90R_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_IdleToRun180R_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_IdleToRun180R_RunStop_LDown || animatorTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToWalk180R || animatorTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToWalk90R || animatorTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToWalk180L || animatorTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToWalk90L || animatorTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToWalk || animatorTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToRun || animatorTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToRun90L || animatorTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToRun180L || animatorTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToRun90R || animatorTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToRun180R || animatorTransitionID == WalkRunPivot.TRANS_WalkFwdLoop_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_WalkFwdLoop_WalkToIdle_RDown || animatorTransitionID == WalkRunPivot.TRANS_WalkFwdLoop_WalkToIdle_LDown || animatorTransitionID == WalkRunPivot.TRANS_WalkFwdLoop_WalkPivot180L || animatorTransitionID == WalkRunPivot.TRANS_WalkFwdLoop_WalkPivot180R || animatorTransitionID == WalkRunPivot.TRANS_RunFwdLoop_WalkFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_RunFwdLoop_RunStop_RDown || animatorTransitionID == WalkRunPivot.TRANS_RunFwdLoop_RunStop_LDown || animatorTransitionID == WalkRunPivot.TRANS_RunFwdLoop_RunPivot180L_RDown || animatorTransitionID == WalkRunPivot.TRANS_RunFwdLoop_RunPivot180R_LDown || animatorTransitionID == WalkRunPivot.TRANS_RunFwdLoop_RunPivot180L_LDown || animatorTransitionID == WalkRunPivot.TRANS_RunFwdLoop_RunPivot180R_RDown || animatorTransitionID == WalkRunPivot.TRANS_RunPivot180L_RDown_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_RunPivot180R_LDown_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_WalkToIdle_RDown_IdlePose || animatorTransitionID == WalkRunPivot.TRANS_WalkToIdle_RDown_WalkFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_WalkToIdle_RDown_WalkPivot180R || animatorTransitionID == WalkRunPivot.TRANS_WalkToIdle_LDown_IdlePose || animatorTransitionID == WalkRunPivot.TRANS_WalkToIdle_LDown_WalkFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_WalkToIdle_LDown_WalkPivot180L || animatorTransitionID == WalkRunPivot.TRANS_RunStop_RDown_IdlePose || animatorTransitionID == WalkRunPivot.TRANS_RunStop_RDown_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_RunStop_RDown_RunPivot180R_LDown || animatorTransitionID == WalkRunPivot.TRANS_RunStop_LDown_IdlePose || animatorTransitionID == WalkRunPivot.TRANS_RunStop_LDown_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_RunStop_LDown_RunPivot180R_RDown || animatorTransitionID == WalkRunPivot.TRANS_RunPivot180L_LDown_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_RunPivot180R_RDown_RunFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_IdleTurn20R_IdlePose || animatorTransitionID == WalkRunPivot.TRANS_IdleTurn20L_IdlePose || animatorTransitionID == WalkRunPivot.TRANS_WalkToIdle_IdlePose || animatorTransitionID == WalkRunPivot.TRANS_WalkPivot180L_WalkFwdLoop || animatorTransitionID == WalkRunPivot.TRANS_WalkPivot180R_WalkFwdLoop;
			}
		}

		// Token: 0x060010B9 RID: 4281 RVA: 0x0005A204 File Offset: 0x00058404
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == WalkRunPivot.STATE_IdleToWalk || rStateID == WalkRunPivot.STATE_IdleToRun || rStateID == WalkRunPivot.STATE_IdleTurn90L || rStateID == WalkRunPivot.STATE_IdleTurn180L || rStateID == WalkRunPivot.STATE_IdleToWalk90L || rStateID == WalkRunPivot.STATE_IdleToWalk180L || rStateID == WalkRunPivot.STATE_IdleToRun90L || rStateID == WalkRunPivot.STATE_IdleToRun180L || rStateID == WalkRunPivot.STATE_IdleTurn90R || rStateID == WalkRunPivot.STATE_IdleTurn180R || rStateID == WalkRunPivot.STATE_IdleToWalk90R || rStateID == WalkRunPivot.STATE_IdleToWalk180R || rStateID == WalkRunPivot.STATE_IdleToRun90R || rStateID == WalkRunPivot.STATE_IdleToRun180R || rStateID == WalkRunPivot.STATE_IdlePose || rStateID == WalkRunPivot.STATE_WalkFwdLoop || rStateID == WalkRunPivot.STATE_RunFwdLoop || rStateID == WalkRunPivot.STATE_RunPivot180L_RDown || rStateID == WalkRunPivot.STATE_RunPivot180R_LDown || rStateID == WalkRunPivot.STATE_WalkToIdle_RDown || rStateID == WalkRunPivot.STATE_WalkToIdle_LDown || rStateID == WalkRunPivot.STATE_RunStop_RDown || rStateID == WalkRunPivot.STATE_RunStop_LDown || rStateID == WalkRunPivot.STATE_RunPivot180L_LDown || rStateID == WalkRunPivot.STATE_RunPivot180R_RDown || rStateID == WalkRunPivot.STATE_IdleTurn20R || rStateID == WalkRunPivot.STATE_IdleTurn20L || rStateID == WalkRunPivot.STATE_WalkToIdle || rStateID == WalkRunPivot.STATE_WalkPivot180L || rStateID == WalkRunPivot.STATE_WalkPivot180R;
		}

		// Token: 0x060010BA RID: 4282 RVA: 0x0005A340 File Offset: 0x00058540
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == WalkRunPivot.STATE_IdleToWalk || rStateID == WalkRunPivot.STATE_IdleToRun || rStateID == WalkRunPivot.STATE_IdleTurn90L || rStateID == WalkRunPivot.STATE_IdleTurn180L || rStateID == WalkRunPivot.STATE_IdleToWalk90L || rStateID == WalkRunPivot.STATE_IdleToWalk180L || rStateID == WalkRunPivot.STATE_IdleToRun90L || rStateID == WalkRunPivot.STATE_IdleToRun180L || rStateID == WalkRunPivot.STATE_IdleTurn90R || rStateID == WalkRunPivot.STATE_IdleTurn180R || rStateID == WalkRunPivot.STATE_IdleToWalk90R || rStateID == WalkRunPivot.STATE_IdleToWalk180R || rStateID == WalkRunPivot.STATE_IdleToRun90R || rStateID == WalkRunPivot.STATE_IdleToRun180R || rStateID == WalkRunPivot.STATE_IdlePose || rStateID == WalkRunPivot.STATE_WalkFwdLoop || rStateID == WalkRunPivot.STATE_RunFwdLoop || rStateID == WalkRunPivot.STATE_RunPivot180L_RDown || rStateID == WalkRunPivot.STATE_RunPivot180R_LDown || rStateID == WalkRunPivot.STATE_WalkToIdle_RDown || rStateID == WalkRunPivot.STATE_WalkToIdle_LDown || rStateID == WalkRunPivot.STATE_RunStop_RDown || rStateID == WalkRunPivot.STATE_RunStop_LDown || rStateID == WalkRunPivot.STATE_RunPivot180L_LDown || rStateID == WalkRunPivot.STATE_RunPivot180R_RDown || rStateID == WalkRunPivot.STATE_IdleTurn20R || rStateID == WalkRunPivot.STATE_IdleTurn20L || rStateID == WalkRunPivot.STATE_WalkToIdle || rStateID == WalkRunPivot.STATE_WalkPivot180L || rStateID == WalkRunPivot.STATE_WalkPivot180R || rTransitionID == WalkRunPivot.TRANS_EntryState_IdleTurn20R || rTransitionID == WalkRunPivot.TRANS_AnyState_IdleTurn20R || rTransitionID == WalkRunPivot.TRANS_EntryState_IdleTurn90R || rTransitionID == WalkRunPivot.TRANS_AnyState_IdleTurn90R || rTransitionID == WalkRunPivot.TRANS_EntryState_IdleTurn180R || rTransitionID == WalkRunPivot.TRANS_AnyState_IdleTurn180R || rTransitionID == WalkRunPivot.TRANS_EntryState_IdleTurn20L || rTransitionID == WalkRunPivot.TRANS_AnyState_IdleTurn20L || rTransitionID == WalkRunPivot.TRANS_EntryState_IdleTurn90L || rTransitionID == WalkRunPivot.TRANS_AnyState_IdleTurn90L || rTransitionID == WalkRunPivot.TRANS_EntryState_IdleTurn180L || rTransitionID == WalkRunPivot.TRANS_AnyState_IdleTurn180L || rTransitionID == WalkRunPivot.TRANS_EntryState_IdlePose || rTransitionID == WalkRunPivot.TRANS_AnyState_IdlePose || rTransitionID == WalkRunPivot.TRANS_EntryState_RunFwdLoop || rTransitionID == WalkRunPivot.TRANS_AnyState_RunFwdLoop || rTransitionID == WalkRunPivot.TRANS_EntryState_WalkFwdLoop || rTransitionID == WalkRunPivot.TRANS_AnyState_WalkFwdLoop || rTransitionID == WalkRunPivot.TRANS_EntryState_IdleToWalk || rTransitionID == WalkRunPivot.TRANS_AnyState_IdleToWalk || rTransitionID == WalkRunPivot.TRANS_EntryState_IdleToRun || rTransitionID == WalkRunPivot.TRANS_AnyState_IdleToRun || rTransitionID == WalkRunPivot.TRANS_IdleToWalk_WalkFwdLoop || rTransitionID == WalkRunPivot.TRANS_IdleToWalk_WalkToIdle || rTransitionID == WalkRunPivot.TRANS_IdleToRun_RunFwdLoop || rTransitionID == WalkRunPivot.TRANS_IdleToRun_RunStop_LDown || rTransitionID == WalkRunPivot.TRANS_IdleTurn90L_WalkFwdLoop || rTransitionID == WalkRunPivot.TRANS_IdleTurn90L_IdlePose || rTransitionID == WalkRunPivot.TRANS_IdleTurn90L_RunFwdLoop || rTransitionID == WalkRunPivot.TRANS_IdleTurn180L_WalkFwdLoop || rTransitionID == WalkRunPivot.TRANS_IdleTurn180L_IdlePose || rTransitionID == WalkRunPivot.TRANS_IdleTurn180L_RunFwdLoop || rTransitionID == WalkRunPivot.TRANS_IdleToWalk90L_WalkFwdLoop || rTransitionID == WalkRunPivot.TRANS_IdleToWalk90L_IdlePose || rTransitionID == WalkRunPivot.TRANS_IdleToWalk180L_WalkFwdLoop || rTransitionID == WalkRunPivot.TRANS_IdleToWalk180L_IdlePose || rTransitionID == WalkRunPivot.TRANS_IdleToRun90L_RunFwdLoop || rTransitionID == WalkRunPivot.TRANS_IdleToRun90L_RunStop_LDown || rTransitionID == WalkRunPivot.TRANS_IdleToRun180L_RunFwdLoop || rTransitionID == WalkRunPivot.TRANS_IdleToRun180L_RunStop_LDown || rTransitionID == WalkRunPivot.TRANS_IdleTurn90R_WalkFwdLoop || rTransitionID == WalkRunPivot.TRANS_IdleTurn90R_IdlePose || rTransitionID == WalkRunPivot.TRANS_IdleTurn90R_RunFwdLoop || rTransitionID == WalkRunPivot.TRANS_IdleTurn180R_IdlePose || rTransitionID == WalkRunPivot.TRANS_IdleTurn180R_WalkFwdLoop || rTransitionID == WalkRunPivot.TRANS_IdleTurn180R_RunFwdLoop || rTransitionID == WalkRunPivot.TRANS_IdleToWalk90R_WalkFwdLoop || rTransitionID == WalkRunPivot.TRANS_IdleToWalk90R_IdlePose || rTransitionID == WalkRunPivot.TRANS_IdleToWalk180R_WalkFwdLoop || rTransitionID == WalkRunPivot.TRANS_IdleToWalk180R_IdlePose || rTransitionID == WalkRunPivot.TRANS_IdleToRun90R_RunStop_LDown || rTransitionID == WalkRunPivot.TRANS_IdleToRun90R_RunFwdLoop || rTransitionID == WalkRunPivot.TRANS_IdleToRun180R_RunFwdLoop || rTransitionID == WalkRunPivot.TRANS_IdleToRun180R_RunStop_LDown || rTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToWalk180R || rTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToWalk90R || rTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToWalk180L || rTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToWalk90L || rTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToWalk || rTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToRun || rTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToRun90L || rTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToRun180L || rTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToRun90R || rTransitionID == WalkRunPivot.TRANS_IdlePose_IdleToRun180R || rTransitionID == WalkRunPivot.TRANS_WalkFwdLoop_RunFwdLoop || rTransitionID == WalkRunPivot.TRANS_WalkFwdLoop_WalkToIdle_RDown || rTransitionID == WalkRunPivot.TRANS_WalkFwdLoop_WalkToIdle_LDown || rTransitionID == WalkRunPivot.TRANS_WalkFwdLoop_WalkPivot180L || rTransitionID == WalkRunPivot.TRANS_WalkFwdLoop_WalkPivot180R || rTransitionID == WalkRunPivot.TRANS_RunFwdLoop_WalkFwdLoop || rTransitionID == WalkRunPivot.TRANS_RunFwdLoop_RunStop_RDown || rTransitionID == WalkRunPivot.TRANS_RunFwdLoop_RunStop_LDown || rTransitionID == WalkRunPivot.TRANS_RunFwdLoop_RunPivot180L_RDown || rTransitionID == WalkRunPivot.TRANS_RunFwdLoop_RunPivot180R_LDown || rTransitionID == WalkRunPivot.TRANS_RunFwdLoop_RunPivot180L_LDown || rTransitionID == WalkRunPivot.TRANS_RunFwdLoop_RunPivot180R_RDown || rTransitionID == WalkRunPivot.TRANS_RunPivot180L_RDown_RunFwdLoop || rTransitionID == WalkRunPivot.TRANS_RunPivot180R_LDown_RunFwdLoop || rTransitionID == WalkRunPivot.TRANS_WalkToIdle_RDown_IdlePose || rTransitionID == WalkRunPivot.TRANS_WalkToIdle_RDown_WalkFwdLoop || rTransitionID == WalkRunPivot.TRANS_WalkToIdle_RDown_WalkPivot180R || rTransitionID == WalkRunPivot.TRANS_WalkToIdle_LDown_IdlePose || rTransitionID == WalkRunPivot.TRANS_WalkToIdle_LDown_WalkFwdLoop || rTransitionID == WalkRunPivot.TRANS_WalkToIdle_LDown_WalkPivot180L || rTransitionID == WalkRunPivot.TRANS_RunStop_RDown_IdlePose || rTransitionID == WalkRunPivot.TRANS_RunStop_RDown_RunFwdLoop || rTransitionID == WalkRunPivot.TRANS_RunStop_RDown_RunPivot180R_LDown || rTransitionID == WalkRunPivot.TRANS_RunStop_LDown_IdlePose || rTransitionID == WalkRunPivot.TRANS_RunStop_LDown_RunFwdLoop || rTransitionID == WalkRunPivot.TRANS_RunStop_LDown_RunPivot180R_RDown || rTransitionID == WalkRunPivot.TRANS_RunPivot180L_LDown_RunFwdLoop || rTransitionID == WalkRunPivot.TRANS_RunPivot180R_RDown_RunFwdLoop || rTransitionID == WalkRunPivot.TRANS_IdleTurn20R_IdlePose || rTransitionID == WalkRunPivot.TRANS_IdleTurn20L_IdlePose || rTransitionID == WalkRunPivot.TRANS_WalkToIdle_IdlePose || rTransitionID == WalkRunPivot.TRANS_WalkPivot180L_WalkFwdLoop || rTransitionID == WalkRunPivot.TRANS_WalkPivot180R_WalkFwdLoop;
		}

		// Token: 0x060010BB RID: 4283 RVA: 0x0005A844 File Offset: 0x00058A44
		public override void LoadAnimatorData()
		{
			WalkRunPivot.TRANS_EntryState_IdleTurn20R = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunPivot-SM.IdleTurn20R");
			WalkRunPivot.TRANS_AnyState_IdleTurn20R = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunPivot-SM.IdleTurn20R");
			WalkRunPivot.TRANS_EntryState_IdleTurn90R = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunPivot-SM.IdleTurn90R");
			WalkRunPivot.TRANS_AnyState_IdleTurn90R = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunPivot-SM.IdleTurn90R");
			WalkRunPivot.TRANS_EntryState_IdleTurn180R = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunPivot-SM.IdleTurn180R");
			WalkRunPivot.TRANS_AnyState_IdleTurn180R = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunPivot-SM.IdleTurn180R");
			WalkRunPivot.TRANS_EntryState_IdleTurn20L = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunPivot-SM.IdleTurn20L");
			WalkRunPivot.TRANS_AnyState_IdleTurn20L = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunPivot-SM.IdleTurn20L");
			WalkRunPivot.TRANS_EntryState_IdleTurn90L = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunPivot-SM.IdleTurn90L");
			WalkRunPivot.TRANS_AnyState_IdleTurn90L = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunPivot-SM.IdleTurn90L");
			WalkRunPivot.TRANS_EntryState_IdleTurn180L = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunPivot-SM.IdleTurn180L");
			WalkRunPivot.TRANS_AnyState_IdleTurn180L = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunPivot-SM.IdleTurn180L");
			WalkRunPivot.TRANS_EntryState_IdlePose = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunPivot-SM.IdlePose");
			WalkRunPivot.TRANS_AnyState_IdlePose = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunPivot-SM.IdlePose");
			WalkRunPivot.TRANS_EntryState_RunFwdLoop = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunPivot-SM.RunFwdLoop");
			WalkRunPivot.TRANS_AnyState_RunFwdLoop = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunPivot-SM.RunFwdLoop");
			WalkRunPivot.TRANS_EntryState_WalkFwdLoop = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunPivot-SM.WalkFwdLoop");
			WalkRunPivot.TRANS_AnyState_WalkFwdLoop = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunPivot-SM.WalkFwdLoop");
			WalkRunPivot.TRANS_EntryState_IdleToWalk = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunPivot-SM.IdleToWalk");
			WalkRunPivot.TRANS_AnyState_IdleToWalk = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunPivot-SM.IdleToWalk");
			WalkRunPivot.TRANS_EntryState_IdleToRun = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunPivot-SM.IdleToRun");
			WalkRunPivot.TRANS_AnyState_IdleToRun = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunPivot-SM.IdleToRun");
			WalkRunPivot.STATE_IdleToWalk = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToWalk");
			WalkRunPivot.TRANS_IdleToWalk_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToWalk -> Base Layer.WalkRunPivot-SM.WalkFwdLoop");
			WalkRunPivot.TRANS_IdleToWalk_WalkToIdle = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToWalk -> Base Layer.WalkRunPivot-SM.WalkToIdle");
			WalkRunPivot.STATE_IdleToRun = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToRun");
			WalkRunPivot.TRANS_IdleToRun_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToRun -> Base Layer.WalkRunPivot-SM.RunFwdLoop");
			WalkRunPivot.TRANS_IdleToRun_RunStop_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToRun -> Base Layer.WalkRunPivot-SM.RunStop_LDown");
			WalkRunPivot.STATE_IdleTurn90L = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn90L");
			WalkRunPivot.TRANS_IdleTurn90L_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn90L -> Base Layer.WalkRunPivot-SM.WalkFwdLoop");
			WalkRunPivot.TRANS_IdleTurn90L_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn90L -> Base Layer.WalkRunPivot-SM.IdlePose");
			WalkRunPivot.TRANS_IdleTurn90L_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn90L -> Base Layer.WalkRunPivot-SM.RunFwdLoop");
			WalkRunPivot.STATE_IdleTurn180L = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn180L");
			WalkRunPivot.TRANS_IdleTurn180L_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn180L -> Base Layer.WalkRunPivot-SM.WalkFwdLoop");
			WalkRunPivot.TRANS_IdleTurn180L_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn180L -> Base Layer.WalkRunPivot-SM.IdlePose");
			WalkRunPivot.TRANS_IdleTurn180L_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn180L -> Base Layer.WalkRunPivot-SM.RunFwdLoop");
			WalkRunPivot.STATE_IdleToWalk90L = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToWalk90L");
			WalkRunPivot.TRANS_IdleToWalk90L_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToWalk90L -> Base Layer.WalkRunPivot-SM.WalkFwdLoop");
			WalkRunPivot.TRANS_IdleToWalk90L_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToWalk90L -> Base Layer.WalkRunPivot-SM.IdlePose");
			WalkRunPivot.STATE_IdleToWalk180L = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToWalk180L");
			WalkRunPivot.TRANS_IdleToWalk180L_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToWalk180L -> Base Layer.WalkRunPivot-SM.WalkFwdLoop");
			WalkRunPivot.TRANS_IdleToWalk180L_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToWalk180L -> Base Layer.WalkRunPivot-SM.IdlePose");
			WalkRunPivot.STATE_IdleToRun90L = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToRun90L");
			WalkRunPivot.TRANS_IdleToRun90L_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToRun90L -> Base Layer.WalkRunPivot-SM.RunFwdLoop");
			WalkRunPivot.TRANS_IdleToRun90L_RunStop_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToRun90L -> Base Layer.WalkRunPivot-SM.RunStop_LDown");
			WalkRunPivot.STATE_IdleToRun180L = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToRun180L");
			WalkRunPivot.TRANS_IdleToRun180L_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToRun180L -> Base Layer.WalkRunPivot-SM.RunFwdLoop");
			WalkRunPivot.TRANS_IdleToRun180L_RunStop_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToRun180L -> Base Layer.WalkRunPivot-SM.RunStop_LDown");
			WalkRunPivot.STATE_IdleTurn90R = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn90R");
			WalkRunPivot.TRANS_IdleTurn90R_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn90R -> Base Layer.WalkRunPivot-SM.WalkFwdLoop");
			WalkRunPivot.TRANS_IdleTurn90R_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn90R -> Base Layer.WalkRunPivot-SM.IdlePose");
			WalkRunPivot.TRANS_IdleTurn90R_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn90R -> Base Layer.WalkRunPivot-SM.RunFwdLoop");
			WalkRunPivot.STATE_IdleTurn180R = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn180R");
			WalkRunPivot.TRANS_IdleTurn180R_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn180R -> Base Layer.WalkRunPivot-SM.IdlePose");
			WalkRunPivot.TRANS_IdleTurn180R_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn180R -> Base Layer.WalkRunPivot-SM.WalkFwdLoop");
			WalkRunPivot.TRANS_IdleTurn180R_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn180R -> Base Layer.WalkRunPivot-SM.RunFwdLoop");
			WalkRunPivot.STATE_IdleToWalk90R = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToWalk90R");
			WalkRunPivot.TRANS_IdleToWalk90R_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToWalk90R -> Base Layer.WalkRunPivot-SM.WalkFwdLoop");
			WalkRunPivot.TRANS_IdleToWalk90R_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToWalk90R -> Base Layer.WalkRunPivot-SM.IdlePose");
			WalkRunPivot.STATE_IdleToWalk180R = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToWalk180R");
			WalkRunPivot.TRANS_IdleToWalk180R_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToWalk180R -> Base Layer.WalkRunPivot-SM.WalkFwdLoop");
			WalkRunPivot.TRANS_IdleToWalk180R_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToWalk180R -> Base Layer.WalkRunPivot-SM.IdlePose");
			WalkRunPivot.STATE_IdleToRun90R = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToRun90R");
			WalkRunPivot.TRANS_IdleToRun90R_RunStop_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToRun90R -> Base Layer.WalkRunPivot-SM.RunStop_LDown");
			WalkRunPivot.TRANS_IdleToRun90R_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToRun90R -> Base Layer.WalkRunPivot-SM.RunFwdLoop");
			WalkRunPivot.STATE_IdleToRun180R = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToRun180R");
			WalkRunPivot.TRANS_IdleToRun180R_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToRun180R -> Base Layer.WalkRunPivot-SM.RunFwdLoop");
			WalkRunPivot.TRANS_IdleToRun180R_RunStop_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleToRun180R -> Base Layer.WalkRunPivot-SM.RunStop_LDown");
			WalkRunPivot.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdlePose");
			WalkRunPivot.TRANS_IdlePose_IdleToWalk180R = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdlePose -> Base Layer.WalkRunPivot-SM.IdleToWalk180R");
			WalkRunPivot.TRANS_IdlePose_IdleToWalk90R = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdlePose -> Base Layer.WalkRunPivot-SM.IdleToWalk90R");
			WalkRunPivot.TRANS_IdlePose_IdleToWalk180L = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdlePose -> Base Layer.WalkRunPivot-SM.IdleToWalk180L");
			WalkRunPivot.TRANS_IdlePose_IdleToWalk90L = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdlePose -> Base Layer.WalkRunPivot-SM.IdleToWalk90L");
			WalkRunPivot.TRANS_IdlePose_IdleToWalk = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdlePose -> Base Layer.WalkRunPivot-SM.IdleToWalk");
			WalkRunPivot.TRANS_IdlePose_IdleToRun = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdlePose -> Base Layer.WalkRunPivot-SM.IdleToRun");
			WalkRunPivot.TRANS_IdlePose_IdleToRun90L = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdlePose -> Base Layer.WalkRunPivot-SM.IdleToRun90L");
			WalkRunPivot.TRANS_IdlePose_IdleToRun180L = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdlePose -> Base Layer.WalkRunPivot-SM.IdleToRun180L");
			WalkRunPivot.TRANS_IdlePose_IdleToRun90R = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdlePose -> Base Layer.WalkRunPivot-SM.IdleToRun90R");
			WalkRunPivot.TRANS_IdlePose_IdleToRun180R = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdlePose -> Base Layer.WalkRunPivot-SM.IdleToRun180R");
			WalkRunPivot.STATE_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkFwdLoop");
			WalkRunPivot.TRANS_WalkFwdLoop_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkFwdLoop -> Base Layer.WalkRunPivot-SM.RunFwdLoop");
			WalkRunPivot.TRANS_WalkFwdLoop_WalkToIdle_RDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkFwdLoop -> Base Layer.WalkRunPivot-SM.WalkToIdle_RDown");
			WalkRunPivot.TRANS_WalkFwdLoop_WalkToIdle_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkFwdLoop -> Base Layer.WalkRunPivot-SM.WalkToIdle_LDown");
			WalkRunPivot.TRANS_WalkFwdLoop_WalkPivot180L = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkFwdLoop -> Base Layer.WalkRunPivot-SM.WalkPivot180L");
			WalkRunPivot.TRANS_WalkFwdLoop_WalkPivot180R = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkFwdLoop -> Base Layer.WalkRunPivot-SM.WalkPivot180R");
			WalkRunPivot.STATE_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunFwdLoop");
			WalkRunPivot.TRANS_RunFwdLoop_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunFwdLoop -> Base Layer.WalkRunPivot-SM.WalkFwdLoop");
			WalkRunPivot.TRANS_RunFwdLoop_RunStop_RDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunFwdLoop -> Base Layer.WalkRunPivot-SM.RunStop_RDown");
			WalkRunPivot.TRANS_RunFwdLoop_RunStop_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunFwdLoop -> Base Layer.WalkRunPivot-SM.RunStop_LDown");
			WalkRunPivot.TRANS_RunFwdLoop_RunPivot180L_RDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunFwdLoop -> Base Layer.WalkRunPivot-SM.RunPivot180L_RDown");
			WalkRunPivot.TRANS_RunFwdLoop_RunPivot180R_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunFwdLoop -> Base Layer.WalkRunPivot-SM.RunPivot180R_LDown");
			WalkRunPivot.TRANS_RunFwdLoop_RunPivot180L_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunFwdLoop -> Base Layer.WalkRunPivot-SM.RunPivot180L_LDown");
			WalkRunPivot.TRANS_RunFwdLoop_RunPivot180R_RDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunFwdLoop -> Base Layer.WalkRunPivot-SM.RunPivot180R_RDown");
			WalkRunPivot.STATE_RunPivot180L_RDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunPivot180L_RDown");
			WalkRunPivot.TRANS_RunPivot180L_RDown_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunPivot180L_RDown -> Base Layer.WalkRunPivot-SM.RunFwdLoop");
			WalkRunPivot.STATE_RunPivot180R_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunPivot180R_LDown");
			WalkRunPivot.TRANS_RunPivot180R_LDown_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunPivot180R_LDown -> Base Layer.WalkRunPivot-SM.RunFwdLoop");
			WalkRunPivot.STATE_WalkToIdle_RDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkToIdle_RDown");
			WalkRunPivot.TRANS_WalkToIdle_RDown_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkToIdle_RDown -> Base Layer.WalkRunPivot-SM.IdlePose");
			WalkRunPivot.TRANS_WalkToIdle_RDown_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkToIdle_RDown -> Base Layer.WalkRunPivot-SM.WalkFwdLoop");
			WalkRunPivot.TRANS_WalkToIdle_RDown_WalkPivot180R = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkToIdle_RDown -> Base Layer.WalkRunPivot-SM.WalkPivot180R");
			WalkRunPivot.STATE_WalkToIdle_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkToIdle_LDown");
			WalkRunPivot.TRANS_WalkToIdle_LDown_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkToIdle_LDown -> Base Layer.WalkRunPivot-SM.IdlePose");
			WalkRunPivot.TRANS_WalkToIdle_LDown_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkToIdle_LDown -> Base Layer.WalkRunPivot-SM.WalkFwdLoop");
			WalkRunPivot.TRANS_WalkToIdle_LDown_WalkPivot180L = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkToIdle_LDown -> Base Layer.WalkRunPivot-SM.WalkPivot180L");
			WalkRunPivot.STATE_RunStop_RDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunStop_RDown");
			WalkRunPivot.TRANS_RunStop_RDown_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunStop_RDown -> Base Layer.WalkRunPivot-SM.IdlePose");
			WalkRunPivot.TRANS_RunStop_RDown_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunStop_RDown -> Base Layer.WalkRunPivot-SM.RunFwdLoop");
			WalkRunPivot.TRANS_RunStop_RDown_RunPivot180R_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunStop_RDown -> Base Layer.WalkRunPivot-SM.RunPivot180R_LDown");
			WalkRunPivot.STATE_RunStop_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunStop_LDown");
			WalkRunPivot.TRANS_RunStop_LDown_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunStop_LDown -> Base Layer.WalkRunPivot-SM.IdlePose");
			WalkRunPivot.TRANS_RunStop_LDown_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunStop_LDown -> Base Layer.WalkRunPivot-SM.RunFwdLoop");
			WalkRunPivot.TRANS_RunStop_LDown_RunPivot180R_RDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunStop_LDown -> Base Layer.WalkRunPivot-SM.RunPivot180R_RDown");
			WalkRunPivot.STATE_RunPivot180L_LDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunPivot180L_LDown");
			WalkRunPivot.TRANS_RunPivot180L_LDown_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunPivot180L_LDown -> Base Layer.WalkRunPivot-SM.RunFwdLoop");
			WalkRunPivot.STATE_RunPivot180R_RDown = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunPivot180R_RDown");
			WalkRunPivot.TRANS_RunPivot180R_RDown_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.RunPivot180R_RDown -> Base Layer.WalkRunPivot-SM.RunFwdLoop");
			WalkRunPivot.STATE_IdleTurn20R = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn20R");
			WalkRunPivot.TRANS_IdleTurn20R_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn20R -> Base Layer.WalkRunPivot-SM.IdlePose");
			WalkRunPivot.STATE_IdleTurn20L = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn20L");
			WalkRunPivot.TRANS_IdleTurn20L_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.IdleTurn20L -> Base Layer.WalkRunPivot-SM.IdlePose");
			WalkRunPivot.STATE_WalkToIdle = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkToIdle");
			WalkRunPivot.TRANS_WalkToIdle_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkToIdle -> Base Layer.WalkRunPivot-SM.IdlePose");
			WalkRunPivot.STATE_WalkPivot180L = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkPivot180L");
			WalkRunPivot.TRANS_WalkPivot180L_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkPivot180L -> Base Layer.WalkRunPivot-SM.WalkFwdLoop");
			WalkRunPivot.STATE_WalkPivot180R = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkPivot180R");
			WalkRunPivot.TRANS_WalkPivot180R_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunPivot-SM.WalkPivot180R -> Base Layer.WalkRunPivot-SM.WalkFwdLoop");
		}

		// Token: 0x04000B70 RID: 2928
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000B71 RID: 2929
		public const int PHASE_START = 27100;

		// Token: 0x04000B72 RID: 2930
		public const int PHASE_START_SHORTCUT_WALK = 27114;

		// Token: 0x04000B73 RID: 2931
		public const int PHASE_START_SHORTCUT_RUN = 27115;

		// Token: 0x04000B74 RID: 2932
		public const int PHASE_STOP_RIGHT_DOWN = 27120;

		// Token: 0x04000B75 RID: 2933
		public const int PHASE_STOP_LEFT_DOWN = 27121;

		// Token: 0x04000B76 RID: 2934
		public bool _DefaultToRun;

		// Token: 0x04000B77 RID: 2935
		public float _RotationSpeed = 180f;

		// Token: 0x04000B78 RID: 2936
		public float _MinPivotAngle = 40f;

		// Token: 0x04000B79 RID: 2937
		public float _PivotSpeed = 180f;

		// Token: 0x04000B7A RID: 2938
		public float _StopDelay = 0.15f;

		// Token: 0x04000B7B RID: 2939
		public bool _RemoveLateralMovement = true;

		// Token: 0x04000B7C RID: 2940
		private bool mStartInMove;

		// Token: 0x04000B7D RID: 2941
		private bool mStartInWalk;

		// Token: 0x04000B7E RID: 2942
		private bool mStartInRun;

		// Token: 0x04000B7F RID: 2943
		private float mInputInactiveStartTime;

		// Token: 0x04000B80 RID: 2944
		private float mInputMagnitude;

		// Token: 0x04000B81 RID: 2945
		private float mInputFromAvatarAngleStart;

		// Token: 0x04000B82 RID: 2946
		private float mInputFromAvatarAngleUsed;

		// Token: 0x04000B83 RID: 2947
		public static int TRANS_EntryState_IdleTurn20R = -1;

		// Token: 0x04000B84 RID: 2948
		public static int TRANS_AnyState_IdleTurn20R = -1;

		// Token: 0x04000B85 RID: 2949
		public static int TRANS_EntryState_IdleTurn90R = -1;

		// Token: 0x04000B86 RID: 2950
		public static int TRANS_AnyState_IdleTurn90R = -1;

		// Token: 0x04000B87 RID: 2951
		public static int TRANS_EntryState_IdleTurn180R = -1;

		// Token: 0x04000B88 RID: 2952
		public static int TRANS_AnyState_IdleTurn180R = -1;

		// Token: 0x04000B89 RID: 2953
		public static int TRANS_EntryState_IdleTurn20L = -1;

		// Token: 0x04000B8A RID: 2954
		public static int TRANS_AnyState_IdleTurn20L = -1;

		// Token: 0x04000B8B RID: 2955
		public static int TRANS_EntryState_IdleTurn90L = -1;

		// Token: 0x04000B8C RID: 2956
		public static int TRANS_AnyState_IdleTurn90L = -1;

		// Token: 0x04000B8D RID: 2957
		public static int TRANS_EntryState_IdleTurn180L = -1;

		// Token: 0x04000B8E RID: 2958
		public static int TRANS_AnyState_IdleTurn180L = -1;

		// Token: 0x04000B8F RID: 2959
		public static int TRANS_EntryState_IdlePose = -1;

		// Token: 0x04000B90 RID: 2960
		public static int TRANS_AnyState_IdlePose = -1;

		// Token: 0x04000B91 RID: 2961
		public static int TRANS_EntryState_RunFwdLoop = -1;

		// Token: 0x04000B92 RID: 2962
		public static int TRANS_AnyState_RunFwdLoop = -1;

		// Token: 0x04000B93 RID: 2963
		public static int TRANS_EntryState_WalkFwdLoop = -1;

		// Token: 0x04000B94 RID: 2964
		public static int TRANS_AnyState_WalkFwdLoop = -1;

		// Token: 0x04000B95 RID: 2965
		public static int TRANS_EntryState_IdleToWalk = -1;

		// Token: 0x04000B96 RID: 2966
		public static int TRANS_AnyState_IdleToWalk = -1;

		// Token: 0x04000B97 RID: 2967
		public static int TRANS_EntryState_IdleToRun = -1;

		// Token: 0x04000B98 RID: 2968
		public static int TRANS_AnyState_IdleToRun = -1;

		// Token: 0x04000B99 RID: 2969
		public static int STATE_IdleToWalk = -1;

		// Token: 0x04000B9A RID: 2970
		public static int TRANS_IdleToWalk_WalkFwdLoop = -1;

		// Token: 0x04000B9B RID: 2971
		public static int TRANS_IdleToWalk_WalkToIdle = -1;

		// Token: 0x04000B9C RID: 2972
		public static int STATE_IdleToRun = -1;

		// Token: 0x04000B9D RID: 2973
		public static int TRANS_IdleToRun_RunFwdLoop = -1;

		// Token: 0x04000B9E RID: 2974
		public static int TRANS_IdleToRun_RunStop_LDown = -1;

		// Token: 0x04000B9F RID: 2975
		public static int STATE_IdleTurn90L = -1;

		// Token: 0x04000BA0 RID: 2976
		public static int TRANS_IdleTurn90L_WalkFwdLoop = -1;

		// Token: 0x04000BA1 RID: 2977
		public static int TRANS_IdleTurn90L_IdlePose = -1;

		// Token: 0x04000BA2 RID: 2978
		public static int TRANS_IdleTurn90L_RunFwdLoop = -1;

		// Token: 0x04000BA3 RID: 2979
		public static int STATE_IdleTurn180L = -1;

		// Token: 0x04000BA4 RID: 2980
		public static int TRANS_IdleTurn180L_WalkFwdLoop = -1;

		// Token: 0x04000BA5 RID: 2981
		public static int TRANS_IdleTurn180L_IdlePose = -1;

		// Token: 0x04000BA6 RID: 2982
		public static int TRANS_IdleTurn180L_RunFwdLoop = -1;

		// Token: 0x04000BA7 RID: 2983
		public static int STATE_IdleToWalk90L = -1;

		// Token: 0x04000BA8 RID: 2984
		public static int TRANS_IdleToWalk90L_WalkFwdLoop = -1;

		// Token: 0x04000BA9 RID: 2985
		public static int TRANS_IdleToWalk90L_IdlePose = -1;

		// Token: 0x04000BAA RID: 2986
		public static int STATE_IdleToWalk180L = -1;

		// Token: 0x04000BAB RID: 2987
		public static int TRANS_IdleToWalk180L_WalkFwdLoop = -1;

		// Token: 0x04000BAC RID: 2988
		public static int TRANS_IdleToWalk180L_IdlePose = -1;

		// Token: 0x04000BAD RID: 2989
		public static int STATE_IdleToRun90L = -1;

		// Token: 0x04000BAE RID: 2990
		public static int TRANS_IdleToRun90L_RunFwdLoop = -1;

		// Token: 0x04000BAF RID: 2991
		public static int TRANS_IdleToRun90L_RunStop_LDown = -1;

		// Token: 0x04000BB0 RID: 2992
		public static int STATE_IdleToRun180L = -1;

		// Token: 0x04000BB1 RID: 2993
		public static int TRANS_IdleToRun180L_RunFwdLoop = -1;

		// Token: 0x04000BB2 RID: 2994
		public static int TRANS_IdleToRun180L_RunStop_LDown = -1;

		// Token: 0x04000BB3 RID: 2995
		public static int STATE_IdleTurn90R = -1;

		// Token: 0x04000BB4 RID: 2996
		public static int TRANS_IdleTurn90R_WalkFwdLoop = -1;

		// Token: 0x04000BB5 RID: 2997
		public static int TRANS_IdleTurn90R_IdlePose = -1;

		// Token: 0x04000BB6 RID: 2998
		public static int TRANS_IdleTurn90R_RunFwdLoop = -1;

		// Token: 0x04000BB7 RID: 2999
		public static int STATE_IdleTurn180R = -1;

		// Token: 0x04000BB8 RID: 3000
		public static int TRANS_IdleTurn180R_IdlePose = -1;

		// Token: 0x04000BB9 RID: 3001
		public static int TRANS_IdleTurn180R_WalkFwdLoop = -1;

		// Token: 0x04000BBA RID: 3002
		public static int TRANS_IdleTurn180R_RunFwdLoop = -1;

		// Token: 0x04000BBB RID: 3003
		public static int STATE_IdleToWalk90R = -1;

		// Token: 0x04000BBC RID: 3004
		public static int TRANS_IdleToWalk90R_WalkFwdLoop = -1;

		// Token: 0x04000BBD RID: 3005
		public static int TRANS_IdleToWalk90R_IdlePose = -1;

		// Token: 0x04000BBE RID: 3006
		public static int STATE_IdleToWalk180R = -1;

		// Token: 0x04000BBF RID: 3007
		public static int TRANS_IdleToWalk180R_WalkFwdLoop = -1;

		// Token: 0x04000BC0 RID: 3008
		public static int TRANS_IdleToWalk180R_IdlePose = -1;

		// Token: 0x04000BC1 RID: 3009
		public static int STATE_IdleToRun90R = -1;

		// Token: 0x04000BC2 RID: 3010
		public static int TRANS_IdleToRun90R_RunStop_LDown = -1;

		// Token: 0x04000BC3 RID: 3011
		public static int TRANS_IdleToRun90R_RunFwdLoop = -1;

		// Token: 0x04000BC4 RID: 3012
		public static int STATE_IdleToRun180R = -1;

		// Token: 0x04000BC5 RID: 3013
		public static int TRANS_IdleToRun180R_RunFwdLoop = -1;

		// Token: 0x04000BC6 RID: 3014
		public static int TRANS_IdleToRun180R_RunStop_LDown = -1;

		// Token: 0x04000BC7 RID: 3015
		public static int STATE_IdlePose = -1;

		// Token: 0x04000BC8 RID: 3016
		public static int TRANS_IdlePose_IdleToWalk180R = -1;

		// Token: 0x04000BC9 RID: 3017
		public static int TRANS_IdlePose_IdleToWalk90R = -1;

		// Token: 0x04000BCA RID: 3018
		public static int TRANS_IdlePose_IdleToWalk180L = -1;

		// Token: 0x04000BCB RID: 3019
		public static int TRANS_IdlePose_IdleToWalk90L = -1;

		// Token: 0x04000BCC RID: 3020
		public static int TRANS_IdlePose_IdleToWalk = -1;

		// Token: 0x04000BCD RID: 3021
		public static int TRANS_IdlePose_IdleToRun = -1;

		// Token: 0x04000BCE RID: 3022
		public static int TRANS_IdlePose_IdleToRun90L = -1;

		// Token: 0x04000BCF RID: 3023
		public static int TRANS_IdlePose_IdleToRun180L = -1;

		// Token: 0x04000BD0 RID: 3024
		public static int TRANS_IdlePose_IdleToRun90R = -1;

		// Token: 0x04000BD1 RID: 3025
		public static int TRANS_IdlePose_IdleToRun180R = -1;

		// Token: 0x04000BD2 RID: 3026
		public static int STATE_WalkFwdLoop = -1;

		// Token: 0x04000BD3 RID: 3027
		public static int TRANS_WalkFwdLoop_RunFwdLoop = -1;

		// Token: 0x04000BD4 RID: 3028
		public static int TRANS_WalkFwdLoop_WalkToIdle_RDown = -1;

		// Token: 0x04000BD5 RID: 3029
		public static int TRANS_WalkFwdLoop_WalkToIdle_LDown = -1;

		// Token: 0x04000BD6 RID: 3030
		public static int TRANS_WalkFwdLoop_WalkPivot180L = -1;

		// Token: 0x04000BD7 RID: 3031
		public static int TRANS_WalkFwdLoop_WalkPivot180R = -1;

		// Token: 0x04000BD8 RID: 3032
		public static int STATE_RunFwdLoop = -1;

		// Token: 0x04000BD9 RID: 3033
		public static int TRANS_RunFwdLoop_WalkFwdLoop = -1;

		// Token: 0x04000BDA RID: 3034
		public static int TRANS_RunFwdLoop_RunStop_RDown = -1;

		// Token: 0x04000BDB RID: 3035
		public static int TRANS_RunFwdLoop_RunStop_LDown = -1;

		// Token: 0x04000BDC RID: 3036
		public static int TRANS_RunFwdLoop_RunPivot180L_RDown = -1;

		// Token: 0x04000BDD RID: 3037
		public static int TRANS_RunFwdLoop_RunPivot180R_LDown = -1;

		// Token: 0x04000BDE RID: 3038
		public static int TRANS_RunFwdLoop_RunPivot180L_LDown = -1;

		// Token: 0x04000BDF RID: 3039
		public static int TRANS_RunFwdLoop_RunPivot180R_RDown = -1;

		// Token: 0x04000BE0 RID: 3040
		public static int STATE_RunPivot180L_RDown = -1;

		// Token: 0x04000BE1 RID: 3041
		public static int TRANS_RunPivot180L_RDown_RunFwdLoop = -1;

		// Token: 0x04000BE2 RID: 3042
		public static int STATE_RunPivot180R_LDown = -1;

		// Token: 0x04000BE3 RID: 3043
		public static int TRANS_RunPivot180R_LDown_RunFwdLoop = -1;

		// Token: 0x04000BE4 RID: 3044
		public static int STATE_WalkToIdle_RDown = -1;

		// Token: 0x04000BE5 RID: 3045
		public static int TRANS_WalkToIdle_RDown_IdlePose = -1;

		// Token: 0x04000BE6 RID: 3046
		public static int TRANS_WalkToIdle_RDown_WalkFwdLoop = -1;

		// Token: 0x04000BE7 RID: 3047
		public static int TRANS_WalkToIdle_RDown_WalkPivot180R = -1;

		// Token: 0x04000BE8 RID: 3048
		public static int STATE_WalkToIdle_LDown = -1;

		// Token: 0x04000BE9 RID: 3049
		public static int TRANS_WalkToIdle_LDown_IdlePose = -1;

		// Token: 0x04000BEA RID: 3050
		public static int TRANS_WalkToIdle_LDown_WalkFwdLoop = -1;

		// Token: 0x04000BEB RID: 3051
		public static int TRANS_WalkToIdle_LDown_WalkPivot180L = -1;

		// Token: 0x04000BEC RID: 3052
		public static int STATE_RunStop_RDown = -1;

		// Token: 0x04000BED RID: 3053
		public static int TRANS_RunStop_RDown_IdlePose = -1;

		// Token: 0x04000BEE RID: 3054
		public static int TRANS_RunStop_RDown_RunFwdLoop = -1;

		// Token: 0x04000BEF RID: 3055
		public static int TRANS_RunStop_RDown_RunPivot180R_LDown = -1;

		// Token: 0x04000BF0 RID: 3056
		public static int STATE_RunStop_LDown = -1;

		// Token: 0x04000BF1 RID: 3057
		public static int TRANS_RunStop_LDown_IdlePose = -1;

		// Token: 0x04000BF2 RID: 3058
		public static int TRANS_RunStop_LDown_RunFwdLoop = -1;

		// Token: 0x04000BF3 RID: 3059
		public static int TRANS_RunStop_LDown_RunPivot180R_RDown = -1;

		// Token: 0x04000BF4 RID: 3060
		public static int STATE_RunPivot180L_LDown = -1;

		// Token: 0x04000BF5 RID: 3061
		public static int TRANS_RunPivot180L_LDown_RunFwdLoop = -1;

		// Token: 0x04000BF6 RID: 3062
		public static int STATE_RunPivot180R_RDown = -1;

		// Token: 0x04000BF7 RID: 3063
		public static int TRANS_RunPivot180R_RDown_RunFwdLoop = -1;

		// Token: 0x04000BF8 RID: 3064
		public static int STATE_IdleTurn20R = -1;

		// Token: 0x04000BF9 RID: 3065
		public static int TRANS_IdleTurn20R_IdlePose = -1;

		// Token: 0x04000BFA RID: 3066
		public static int STATE_IdleTurn20L = -1;

		// Token: 0x04000BFB RID: 3067
		public static int TRANS_IdleTurn20L_IdlePose = -1;

		// Token: 0x04000BFC RID: 3068
		public static int STATE_WalkToIdle = -1;

		// Token: 0x04000BFD RID: 3069
		public static int TRANS_WalkToIdle_IdlePose = -1;

		// Token: 0x04000BFE RID: 3070
		public static int STATE_WalkPivot180L = -1;

		// Token: 0x04000BFF RID: 3071
		public static int TRANS_WalkPivot180L_WalkFwdLoop = -1;

		// Token: 0x04000C00 RID: 3072
		public static int STATE_WalkPivot180R = -1;

		// Token: 0x04000C01 RID: 3073
		public static int TRANS_WalkPivot180R_WalkFwdLoop = -1;
	}
}
