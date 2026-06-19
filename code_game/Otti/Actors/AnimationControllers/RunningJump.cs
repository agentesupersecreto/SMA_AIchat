using System;
using com.ootii.Actors.Navigation;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x0200010E RID: 270
	[MotionName("Running Jump")]
	[MotionDescription("Jump when the actor is running forward.")]
	public class RunningJump : MotionControllerMotion
	{
		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x06000FE0 RID: 4064 RVA: 0x000540DF File Offset: 0x000522DF
		// (set) Token: 0x06000FE1 RID: 4065 RVA: 0x000540E7 File Offset: 0x000522E7
		public float Impulse
		{
			get
			{
				return this._Impulse;
			}
			set
			{
				this._Impulse = value;
			}
		}

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x06000FE2 RID: 4066 RVA: 0x000540F0 File Offset: 0x000522F0
		// (set) Token: 0x06000FE3 RID: 4067 RVA: 0x000540F8 File Offset: 0x000522F8
		public bool ConvertToHipBase
		{
			get
			{
				return this._ConvertToHipBase;
			}
			set
			{
				this._ConvertToHipBase = value;
			}
		}

		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x06000FE4 RID: 4068 RVA: 0x00054101 File Offset: 0x00052301
		// (set) Token: 0x06000FE5 RID: 4069 RVA: 0x00054109 File Offset: 0x00052309
		public string HipBoneName
		{
			get
			{
				return this._HipBoneName;
			}
			set
			{
				this._HipBoneName = value;
				if (this.mMotionController != null)
				{
					this.mHipBone = this.mMotionController.gameObject.transform.Find(this._HipBoneName);
				}
			}
		}

		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x06000FE6 RID: 4070 RVA: 0x00054141 File Offset: 0x00052341
		// (set) Token: 0x06000FE7 RID: 4071 RVA: 0x00054149 File Offset: 0x00052349
		public float MinFallHeight
		{
			get
			{
				return this._MinFallHeight;
			}
			set
			{
				this._MinFallHeight = value;
			}
		}

		// Token: 0x06000FE8 RID: 4072 RVA: 0x00054154 File Offset: 0x00052354
		public RunningJump()
		{
			this._Priority = 16f;
			this._ActionAlias = "Jump";
			this.mIsStartable = true;
		}

		// Token: 0x06000FE9 RID: 4073 RVA: 0x000541B8 File Offset: 0x000523B8
		public RunningJump(MotionController rController)
			: base(rController)
		{
			this._Priority = 16f;
			this._ActionAlias = "Jump";
			this.mIsStartable = true;
		}

		// Token: 0x06000FEA RID: 4074 RVA: 0x0005421C File Offset: 0x0005241C
		public override void Initialize()
		{
			if (this.mMotionController != null)
			{
				if (this.mWalkRunMotion == null)
				{
					this.mWalkRunMotion = this.mMotionController.GetMotionInterface<IWalkRunMotion>(0);
				}
				this.mFall = this.mMotionController.GetMotion("Fall", false);
				if (this.mFall == null)
				{
					this.mFall = this.mMotionController.GetMotion<Fall>(false);
				}
			}
		}

		// Token: 0x06000FEB RID: 4075 RVA: 0x00054284 File Offset: 0x00052484
		public override bool TestActivate()
		{
			if (!this.mIsStartable)
			{
				return false;
			}
			if (!this.mActorController.IsGrounded)
			{
				return false;
			}
			if (this.mMotionController._InputSource == null)
			{
				return false;
			}
			if (!this.mMotionController._InputSource.IsJustPressed(this._ActionAlias))
			{
				return false;
			}
			if (this.mMotionLayer.ActiveMotion != null)
			{
				IWalkRunMotion walkRunMotion = this.mMotionLayer.ActiveMotion as IWalkRunMotion;
				if (!(this.mMotionLayer.ActiveMotion is BalanceWalk) && (walkRunMotion == null || !walkRunMotion.IsRunActive))
				{
					return false;
				}
				this.mWalkRunMotion = walkRunMotion;
			}
			return this.mMotionController.State.InputForward.magnitude >= 0.5f && Mathf.Abs(this.mMotionController.State.InputFromAvatarAngle) <= 10f && this.mMotionController.State.AnimatorStates[this.mMotionLayer.AnimatorLayerIndex].StateInfo.fullPathHash != RunningJump.STATE_IdlePose;
		}

		// Token: 0x06000FEC RID: 4076 RVA: 0x00054388 File Offset: 0x00052588
		public override bool TestUpdate()
		{
			if (this.mIsActivatedFrame)
			{
				return true;
			}
			int fullPathHash = this.mMotionController.State.AnimatorStates[this.mMotionLayer.AnimatorLayerIndex].StateInfo.fullPathHash;
			return fullPathHash != RunningJump.STATE_IdlePose && (!this.mIsImpulseApplied || this.IsMotionState(fullPathHash));
		}

		// Token: 0x06000FED RID: 4077 RVA: 0x000543E8 File Offset: 0x000525E8
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			return !(rMotion is Fall) || this.mActorController.State.GroundSurfaceDistance >= 2f;
		}

		// Token: 0x06000FEE RID: 4078 RVA: 0x0005440C File Offset: 0x0005260C
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			if (this._ConvertToHipBase && this.mHipBone == null)
			{
				if (this._HipBoneName.Length > 0)
				{
					this.mHipBone = this.mMotionController._Transform.Find(this._HipBoneName);
				}
				if (this.mHipBone == null)
				{
					this.mHipBone = this.mMotionController.Animator.GetBoneTransform(HumanBodyBones.Hips);
					if (this.mHipBone != null)
					{
						this._HipBoneName = this.mHipBone.name;
					}
				}
			}
			this.mLastHipDistance = 0f;
			this.mIsImpulseApplied = false;
			this.mIsExitTriggered = false;
			this.mLaunchVelocity = this.mActorController.State.Velocity;
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 27500, true);
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000FEF RID: 4079 RVA: 0x000544EF File Offset: 0x000526EF
		public override void Deactivate()
		{
			base.Deactivate();
		}

		// Token: 0x06000FF0 RID: 4080 RVA: 0x000544F8 File Offset: 0x000526F8
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rVelocityDelta, ref Quaternion rRotationDelta)
		{
			if (this.mMotionLayer._AnimatorTransitionID == RunningJump.TRANS_RunningJump_RunJump_RunForward || this.mMotionLayer._AnimatorStateID == RunningJump.STATE_RunJump_RunForward)
			{
				rVelocityDelta = rVelocityDelta.normalized * (this.mLaunchVelocity.magnitude * Time.deltaTime);
			}
		}

		// Token: 0x06000FF1 RID: 4081 RVA: 0x0005454C File Offset: 0x0005274C
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mVelocity = Vector3.zero;
			this.mMovement = Vector3.zero;
			float num = 0f;
			if (rUpdateIndex != 1)
			{
				return;
			}
			if (this._ConvertToHipBase && this.mHipBone != null)
			{
				float num2 = this.mHipBone.position.y - this.mMotionController._Transform.position.y;
				num = -(num2 - this.mLastHipDistance);
				this.mLastHipDistance = num2;
			}
			MotionState state = this.mMotionController.State;
			int animatorStateID = this.mMotionLayer._AnimatorStateID;
			float animatorStateNormalizedTime = this.mMotionLayer._AnimatorStateNormalizedTime;
			if (animatorStateID != RunningJump.STATE_RunningJump)
			{
				if (animatorStateID == RunningJump.STATE_RunJump_RunForward)
				{
					if (animatorStateNormalizedTime > 0f)
					{
						if (this.mWalkRunMotion != null && this.mWalkRunMotion.IsEnabled)
						{
							this.mWalkRunMotion.StartInRun = this.mWalkRunMotion.IsRunActive;
							this.mWalkRunMotion.StartInWalk = !this.mWalkRunMotion.StartInRun;
							this.mMotionController.ActivateMotion(this.mWalkRunMotion as MotionControllerMotion, 0);
							return;
						}
						this.Deactivate();
						return;
					}
				}
				else if (animatorStateID == RunningJump.STATE_IdlePose)
				{
					this.Deactivate();
				}
				return;
			}
			if (!this.mIsImpulseApplied)
			{
				this.mIsImpulseApplied = true;
				this.mActorController.AddImpulse(this.mActorController._Transform.up * this._Impulse);
			}
			if (!this.mIsExitTriggered && this.mIsImpulseApplied && animatorStateNormalizedTime > 0.2f && animatorStateNormalizedTime < 0.5f && this.mActorController.State.IsGrounded)
			{
				this.mIsExitTriggered = true;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 27540, true);
			}
			if (this.mIsExitTriggered || animatorStateNormalizedTime <= 0.83f)
			{
				this.mMovement = this.mActorController._Transform.up * num;
				return;
			}
			if (this.mFall != null && this.mFall.IsEnabled && this.mActorController.State.GroundSurfaceDistance > this._MinFallHeight)
			{
				this.mIsExitTriggered = true;
				this.mMotionController.ActivateMotion(this.mFall, 0);
				return;
			}
			if (state.InputMagnitudeTrend.Value >= 0.1f)
			{
				this.mIsExitTriggered = true;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 27545, true);
				return;
			}
			this.mIsExitTriggered = true;
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 27540, true);
		}

		// Token: 0x06000FF2 RID: 4082 RVA: 0x000547DC File Offset: 0x000529DC
		public override void OnMessageReceived(IMessage rMessage)
		{
			if (rMessage == null)
			{
				return;
			}
			if (rMessage is NavigationMessage && rMessage.ID == NavigationMessage.MSG_NAVIGATE_JUMP && !this.mIsActive && this.mMotionController.IsGrounded && this.mActorController.State.Velocity.magnitude >= 5f)
			{
				rMessage.Recipient = this;
				rMessage.IsHandled = true;
				this.mMotionController.ActivateMotion(this, 0);
			}
		}

		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x06000FF3 RID: 4083 RVA: 0x0005484E File Offset: 0x00052A4E
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x06000FF4 RID: 4084 RVA: 0x00054854 File Offset: 0x00052A54
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				if (animatorTransitionID == 0)
				{
					if (animatorStateID == RunningJump.STATE_Start)
					{
						return true;
					}
					if (animatorStateID == RunningJump.STATE_IdlePose)
					{
						return true;
					}
					if (animatorStateID == RunningJump.STATE_RunJump_RunForward)
					{
						return true;
					}
					if (animatorStateID == RunningJump.STATE_RunningJump)
					{
						return true;
					}
					if (animatorStateID == RunningJump.STATE_LandToIdle)
					{
						return true;
					}
				}
				return animatorTransitionID == RunningJump.TRANS_AnyState_RunningJump || animatorTransitionID == RunningJump.TRANS_EntryState_RunningJump || animatorTransitionID == RunningJump.TRANS_RunningJump_RunJump_RunForward || animatorTransitionID == RunningJump.TRANS_RunningJump_LandToIdle || animatorTransitionID == RunningJump.TRANS_LandToIdle_IdlePose;
			}
		}

		// Token: 0x06000FF5 RID: 4085 RVA: 0x000548E1 File Offset: 0x00052AE1
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == RunningJump.STATE_Start || rStateID == RunningJump.STATE_IdlePose || rStateID == RunningJump.STATE_RunJump_RunForward || rStateID == RunningJump.STATE_RunningJump || rStateID == RunningJump.STATE_LandToIdle;
		}

		// Token: 0x06000FF6 RID: 4086 RVA: 0x00054918 File Offset: 0x00052B18
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			if (rTransitionID == 0)
			{
				if (rStateID == RunningJump.STATE_Start)
				{
					return true;
				}
				if (rStateID == RunningJump.STATE_IdlePose)
				{
					return true;
				}
				if (rStateID == RunningJump.STATE_RunJump_RunForward)
				{
					return true;
				}
				if (rStateID == RunningJump.STATE_RunningJump)
				{
					return true;
				}
				if (rStateID == RunningJump.STATE_LandToIdle)
				{
					return true;
				}
			}
			return rTransitionID == RunningJump.TRANS_AnyState_RunningJump || rTransitionID == RunningJump.TRANS_EntryState_RunningJump || rTransitionID == RunningJump.TRANS_RunningJump_RunJump_RunForward || rTransitionID == RunningJump.TRANS_RunningJump_LandToIdle || rTransitionID == RunningJump.TRANS_LandToIdle_IdlePose;
		}

		// Token: 0x06000FF7 RID: 4087 RVA: 0x00054990 File Offset: 0x00052B90
		public override void LoadAnimatorData()
		{
			RunningJump.TRANS_AnyState_RunningJump = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.RunningJump-SM.RunningJump");
			RunningJump.TRANS_EntryState_RunningJump = this.mMotionController.AddAnimatorName("Entry -> Base Layer.RunningJump-SM.RunningJump");
			RunningJump.STATE_Start = this.mMotionController.AddAnimatorName("Base Layer.Start");
			RunningJump.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.RunningJump-SM.IdlePose");
			RunningJump.STATE_RunJump_RunForward = this.mMotionController.AddAnimatorName("Base Layer.RunningJump-SM.RunJump_RunForward");
			RunningJump.STATE_RunningJump = this.mMotionController.AddAnimatorName("Base Layer.RunningJump-SM.RunningJump");
			RunningJump.TRANS_RunningJump_RunJump_RunForward = this.mMotionController.AddAnimatorName("Base Layer.RunningJump-SM.RunningJump -> Base Layer.RunningJump-SM.RunJump_RunForward");
			RunningJump.TRANS_RunningJump_LandToIdle = this.mMotionController.AddAnimatorName("Base Layer.RunningJump-SM.RunningJump -> Base Layer.RunningJump-SM.LandToIdle");
			RunningJump.STATE_LandToIdle = this.mMotionController.AddAnimatorName("Base Layer.RunningJump-SM.LandToIdle");
			RunningJump.TRANS_LandToIdle_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.RunningJump-SM.LandToIdle -> Base Layer.RunningJump-SM.IdlePose");
		}

		// Token: 0x04000A66 RID: 2662
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000A67 RID: 2663
		public const int PHASE_START = 27500;

		// Token: 0x04000A68 RID: 2664
		public const int PHASE_TOP = 27520;

		// Token: 0x04000A69 RID: 2665
		public const int PHASE_FALL = 27530;

		// Token: 0x04000A6A RID: 2666
		public const int PHASE_LAND_IDLE = 27540;

		// Token: 0x04000A6B RID: 2667
		public const int PHASE_LAND_RUN = 27545;

		// Token: 0x04000A6C RID: 2668
		public float _Impulse = 7f;

		// Token: 0x04000A6D RID: 2669
		public bool _ConvertToHipBase = true;

		// Token: 0x04000A6E RID: 2670
		public string _HipBoneName = "";

		// Token: 0x04000A6F RID: 2671
		public float _MinFallHeight = 2f;

		// Token: 0x04000A70 RID: 2672
		protected bool mIsImpulseApplied;

		// Token: 0x04000A71 RID: 2673
		protected Vector3 mLaunchVelocity = Vector3.zero;

		// Token: 0x04000A72 RID: 2674
		protected Transform mHipBone;

		// Token: 0x04000A73 RID: 2675
		protected float mLastHipDistance;

		// Token: 0x04000A74 RID: 2676
		protected IWalkRunMotion mWalkRunMotion;

		// Token: 0x04000A75 RID: 2677
		protected MotionControllerMotion mFall;

		// Token: 0x04000A76 RID: 2678
		protected bool mIsExitTriggered;

		// Token: 0x04000A77 RID: 2679
		public static int STATE_Start = -1;

		// Token: 0x04000A78 RID: 2680
		public static int STATE_IdlePose = -1;

		// Token: 0x04000A79 RID: 2681
		public static int STATE_RunJump_RunForward = -1;

		// Token: 0x04000A7A RID: 2682
		public static int STATE_RunningJump = -1;

		// Token: 0x04000A7B RID: 2683
		public static int STATE_LandToIdle = -1;

		// Token: 0x04000A7C RID: 2684
		public static int TRANS_AnyState_RunningJump = -1;

		// Token: 0x04000A7D RID: 2685
		public static int TRANS_EntryState_RunningJump = -1;

		// Token: 0x04000A7E RID: 2686
		public static int TRANS_RunningJump_RunJump_RunForward = -1;

		// Token: 0x04000A7F RID: 2687
		public static int TRANS_RunningJump_LandToIdle = -1;

		// Token: 0x04000A80 RID: 2688
		public static int TRANS_LandToIdle_IdlePose = -1;
	}
}
