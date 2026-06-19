using System;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x0200011C RID: 284
	[MotionName("Walk Run Twitch")]
	[MotionDescription("Basic Super Mario style movement for arcade or 'twitch' games.")]
	public class WalkRunTwitch : MotionControllerMotion
	{
		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x060011AC RID: 4524 RVA: 0x000633A5 File Offset: 0x000615A5
		// (set) Token: 0x060011AD RID: 4525 RVA: 0x000633AD File Offset: 0x000615AD
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

		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x060011AE RID: 4526 RVA: 0x000633B6 File Offset: 0x000615B6
		// (set) Token: 0x060011AF RID: 4527 RVA: 0x000633BE File Offset: 0x000615BE
		public float WalkSpeed
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

		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x060011B0 RID: 4528 RVA: 0x000633C7 File Offset: 0x000615C7
		// (set) Token: 0x060011B1 RID: 4529 RVA: 0x000633CF File Offset: 0x000615CF
		public float RunSpeed
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

		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x060011B2 RID: 4530 RVA: 0x000633D8 File Offset: 0x000615D8
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

		// Token: 0x060011B3 RID: 4531 RVA: 0x00063461 File Offset: 0x00061661
		public WalkRunTwitch()
		{
			this._Priority = 5f;
			this._ActionAlias = "Run";
			this.mUseTrendData = false;
		}

		// Token: 0x060011B4 RID: 4532 RVA: 0x00063486 File Offset: 0x00061686
		public WalkRunTwitch(MotionController rController)
			: base(rController)
		{
			this._Priority = 5f;
			this._ActionAlias = "Run";
			this.mUseTrendData = false;
		}

		// Token: 0x060011B5 RID: 4533 RVA: 0x000634AC File Offset: 0x000616AC
		public override void Awake()
		{
			base.Awake();
		}

		// Token: 0x060011B6 RID: 4534 RVA: 0x000634B4 File Offset: 0x000616B4
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
			return state.InputMagnitudeTrend.Value >= 0.03f;
		}

		// Token: 0x060011B7 RID: 4535 RVA: 0x000634FC File Offset: 0x000616FC
		public override bool TestUpdate()
		{
			return this.mIsActivatedFrame || (this.mMotionController.IsGrounded && this.mMotionLayer._AnimatorStateID != WalkRunTwitch.STATE_IdlePose && (!this.mIsAnimatorActive || this.IsInMotionState));
		}

		// Token: 0x060011B8 RID: 4536 RVA: 0x00063549 File Offset: 0x00061749
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			return true;
		}

		// Token: 0x060011B9 RID: 4537 RVA: 0x0006354C File Offset: 0x0006174C
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 27150, this.IsRunActive ? 1 : 0, true);
			return base.Activate(rPrevMotion);
		}

		// Token: 0x060011BA RID: 4538 RVA: 0x0006357D File Offset: 0x0006177D
		public override void Deactivate()
		{
			base.Deactivate();
		}

		// Token: 0x060011BB RID: 4539 RVA: 0x00063588 File Offset: 0x00061788
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			rMovement.x = 0f;
			if (rMovement.z < 0f)
			{
				rMovement.z = 0f;
			}
			if (this._WalkSpeed > 0f || this._RunSpeed > 0f)
			{
				rMovement.z = 0f;
				if ((this.mMotionLayer._AnimatorStateID == WalkRunTwitch.STATE_WalkFwdLoop || this.mMotionLayer._AnimatorStateID == WalkRunTwitch.STATE_RunFwdLoop) && this.mMotionLayer._AnimatorTransitionID != WalkRunTwitch.TRANS_WalkFwdLoop_IdlePose)
				{
					float num = ((this._WalkSpeed > 0f) ? this._WalkSpeed : this._RunSpeed);
					float num2 = ((this._RunSpeed == 0f || !this.IsRunActive) ? this._WalkSpeed : this._RunSpeed);
					rMovement.z = num2 * rDeltaTime;
				}
			}
		}

		// Token: 0x060011BC RID: 4540 RVA: 0x00063660 File Offset: 0x00061860
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mMotionController.SetAnimatorMotionParameter(this.mMotionLayer._AnimatorLayerIndex, this.IsRunActive ? 1 : 0);
			if (this.mMotionLayer._AnimatorStateID == WalkRunTwitch.STATE_WalkFwdLoop || this.mMotionLayer._AnimatorStateID == WalkRunTwitch.STATE_RunFwdLoop)
			{
				this.mRotation = Quaternion.AngleAxis(this.mMotionController.State.InputFromAvatarAngle, this.mMotionController._Transform.up);
			}
		}

		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x060011BD RID: 4541 RVA: 0x000636E0 File Offset: 0x000618E0
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == WalkRunTwitch.STATE_WalkFwdLoop || animatorStateID == WalkRunTwitch.STATE_IdlePose || animatorStateID == WalkRunTwitch.STATE_RunFwdLoop || animatorTransitionID == WalkRunTwitch.TRANS_EntryState_WalkFwdLoop || animatorTransitionID == WalkRunTwitch.TRANS_AnyState_WalkFwdLoop || animatorTransitionID == WalkRunTwitch.TRANS_EntryState_RunFwdLoop || animatorTransitionID == WalkRunTwitch.TRANS_AnyState_RunFwdLoop || animatorTransitionID == WalkRunTwitch.TRANS_WalkFwdLoop_IdlePose || animatorTransitionID == WalkRunTwitch.TRANS_WalkFwdLoop_RunFwdLoop || animatorTransitionID == WalkRunTwitch.TRANS_IdlePose_WalkFwdLoop || animatorTransitionID == WalkRunTwitch.TRANS_IdlePose_RunFwdLoop || animatorTransitionID == WalkRunTwitch.TRANS_RunFwdLoop_IdlePose || animatorTransitionID == WalkRunTwitch.TRANS_RunFwdLoop_WalkFwdLoop;
			}
		}

		// Token: 0x060011BE RID: 4542 RVA: 0x00063788 File Offset: 0x00061988
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == WalkRunTwitch.STATE_WalkFwdLoop || rStateID == WalkRunTwitch.STATE_IdlePose || rStateID == WalkRunTwitch.STATE_RunFwdLoop;
		}

		// Token: 0x060011BF RID: 4543 RVA: 0x000637AC File Offset: 0x000619AC
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == WalkRunTwitch.STATE_WalkFwdLoop || rStateID == WalkRunTwitch.STATE_IdlePose || rStateID == WalkRunTwitch.STATE_RunFwdLoop || rTransitionID == WalkRunTwitch.TRANS_EntryState_WalkFwdLoop || rTransitionID == WalkRunTwitch.TRANS_AnyState_WalkFwdLoop || rTransitionID == WalkRunTwitch.TRANS_EntryState_RunFwdLoop || rTransitionID == WalkRunTwitch.TRANS_AnyState_RunFwdLoop || rTransitionID == WalkRunTwitch.TRANS_WalkFwdLoop_IdlePose || rTransitionID == WalkRunTwitch.TRANS_WalkFwdLoop_RunFwdLoop || rTransitionID == WalkRunTwitch.TRANS_IdlePose_WalkFwdLoop || rTransitionID == WalkRunTwitch.TRANS_IdlePose_RunFwdLoop || rTransitionID == WalkRunTwitch.TRANS_RunFwdLoop_IdlePose || rTransitionID == WalkRunTwitch.TRANS_RunFwdLoop_WalkFwdLoop;
		}

		// Token: 0x060011C0 RID: 4544 RVA: 0x0006383C File Offset: 0x00061A3C
		public override void LoadAnimatorData()
		{
			WalkRunTwitch.TRANS_EntryState_WalkFwdLoop = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunTwitch-SM.WalkFwdLoop");
			WalkRunTwitch.TRANS_AnyState_WalkFwdLoop = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunTwitch-SM.WalkFwdLoop");
			WalkRunTwitch.TRANS_EntryState_RunFwdLoop = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunTwitch-SM.RunFwdLoop");
			WalkRunTwitch.TRANS_AnyState_RunFwdLoop = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunTwitch-SM.RunFwdLoop");
			WalkRunTwitch.STATE_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunTwitch-SM.WalkFwdLoop");
			WalkRunTwitch.TRANS_WalkFwdLoop_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunTwitch-SM.WalkFwdLoop -> Base Layer.WalkRunTwitch-SM.IdlePose");
			WalkRunTwitch.TRANS_WalkFwdLoop_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunTwitch-SM.WalkFwdLoop -> Base Layer.WalkRunTwitch-SM.RunFwdLoop");
			WalkRunTwitch.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunTwitch-SM.IdlePose");
			WalkRunTwitch.TRANS_IdlePose_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunTwitch-SM.IdlePose -> Base Layer.WalkRunTwitch-SM.WalkFwdLoop");
			WalkRunTwitch.TRANS_IdlePose_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunTwitch-SM.IdlePose -> Base Layer.WalkRunTwitch-SM.RunFwdLoop");
			WalkRunTwitch.STATE_RunFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunTwitch-SM.RunFwdLoop");
			WalkRunTwitch.TRANS_RunFwdLoop_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunTwitch-SM.RunFwdLoop -> Base Layer.WalkRunTwitch-SM.IdlePose");
			WalkRunTwitch.TRANS_RunFwdLoop_WalkFwdLoop = this.mMotionController.AddAnimatorName("Base Layer.WalkRunTwitch-SM.RunFwdLoop -> Base Layer.WalkRunTwitch-SM.WalkFwdLoop");
		}

		// Token: 0x04000D71 RID: 3441
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000D72 RID: 3442
		public const int PHASE_START = 27150;

		// Token: 0x04000D73 RID: 3443
		public bool _DefaultToRun;

		// Token: 0x04000D74 RID: 3444
		public float _WalkSpeed;

		// Token: 0x04000D75 RID: 3445
		public float _RunSpeed;

		// Token: 0x04000D76 RID: 3446
		public static int TRANS_EntryState_WalkFwdLoop = -1;

		// Token: 0x04000D77 RID: 3447
		public static int TRANS_AnyState_WalkFwdLoop = -1;

		// Token: 0x04000D78 RID: 3448
		public static int TRANS_EntryState_RunFwdLoop = -1;

		// Token: 0x04000D79 RID: 3449
		public static int TRANS_AnyState_RunFwdLoop = -1;

		// Token: 0x04000D7A RID: 3450
		public static int STATE_WalkFwdLoop = -1;

		// Token: 0x04000D7B RID: 3451
		public static int TRANS_WalkFwdLoop_IdlePose = -1;

		// Token: 0x04000D7C RID: 3452
		public static int TRANS_WalkFwdLoop_RunFwdLoop = -1;

		// Token: 0x04000D7D RID: 3453
		public static int STATE_IdlePose = -1;

		// Token: 0x04000D7E RID: 3454
		public static int TRANS_IdlePose_WalkFwdLoop = -1;

		// Token: 0x04000D7F RID: 3455
		public static int TRANS_IdlePose_RunFwdLoop = -1;

		// Token: 0x04000D80 RID: 3456
		public static int STATE_RunFwdLoop = -1;

		// Token: 0x04000D81 RID: 3457
		public static int TRANS_RunFwdLoop_IdlePose = -1;

		// Token: 0x04000D82 RID: 3458
		public static int TRANS_RunFwdLoop_WalkFwdLoop = -1;
	}
}
