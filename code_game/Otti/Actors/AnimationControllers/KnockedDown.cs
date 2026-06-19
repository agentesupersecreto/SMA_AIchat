using System;
using com.ootii.Actors.Combat;
using com.ootii.Actors.Navigation;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x02000109 RID: 265
	[MotionName("Knocked Down")]
	[MotionDescription("Makes the actor fall back and sit. Continuing has them get back up.")]
	public class KnockedDown : MotionControllerMotion
	{
		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x06000F79 RID: 3961 RVA: 0x000511AB File Offset: 0x0004F3AB
		// (set) Token: 0x06000F7A RID: 3962 RVA: 0x000511B3 File Offset: 0x0004F3B3
		public bool WakeOnAttacked
		{
			get
			{
				return this._WakeOnAttacked;
			}
			set
			{
				this._WakeOnAttacked = value;
			}
		}

		// Token: 0x06000F7B RID: 3963 RVA: 0x000511BC File Offset: 0x0004F3BC
		public KnockedDown()
		{
			this._Priority = 50f;
			this._ActionAlias = "";
			this._Category = 500;
		}

		// Token: 0x06000F7C RID: 3964 RVA: 0x000511EC File Offset: 0x0004F3EC
		public KnockedDown(MotionController rController)
			: base(rController)
		{
			this._Priority = 50f;
			this._ActionAlias = "";
			this._Category = 500;
		}

		// Token: 0x06000F7D RID: 3965 RVA: 0x0005121D File Offset: 0x0004F41D
		public override void Initialize()
		{
		}

		// Token: 0x06000F7E RID: 3966 RVA: 0x00051220 File Offset: 0x0004F420
		public override bool TestActivate()
		{
			return this.mIsStartable && this.mMotionController.IsGrounded && (this._ActionAlias.Length > 0 && this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias));
		}

		// Token: 0x06000F7F RID: 3967 RVA: 0x0005127C File Offset: 0x0004F47C
		public override bool TestUpdate()
		{
			return this.mIsActivatedFrame || this.mMotionLayer._AnimatorStateID != KnockedDown.STATE_IdlePose;
		}

		// Token: 0x06000F80 RID: 3968 RVA: 0x0005129D File Offset: 0x0004F49D
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			return true;
		}

		// Token: 0x06000F81 RID: 3969 RVA: 0x000512A0 File Offset: 0x0004F4A0
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mWake = false;
			this.mStoredStance = this.mActorController.State.Stance;
			this.mActorController.State.Stance = 14;
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 1880, true);
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000F82 RID: 3970 RVA: 0x000512FF File Offset: 0x0004F4FF
		public override void Deactivate()
		{
			this.mActorController.State.Stance = this.mStoredStance;
			base.Deactivate();
		}

		// Token: 0x06000F83 RID: 3971 RVA: 0x0005131D File Offset: 0x0004F51D
		public void Wake()
		{
			this.mWake = true;
		}

		// Token: 0x06000F84 RID: 3972 RVA: 0x00051326 File Offset: 0x0004F526
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovementDelta, ref Quaternion rRotationDelta)
		{
			rMovementDelta.x = 0f;
			rMovementDelta.y = 0f;
		}

		// Token: 0x06000F85 RID: 3973 RVA: 0x00051340 File Offset: 0x0004F540
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			if (this.mMotionLayer._AnimatorStateID == KnockedDown.STATE_KnockedDown && this.mMotionLayer._AnimatorTransitionID == 0)
			{
				if (this._ActionAlias.Length > 0 && this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias))
				{
					this.mWake = true;
				}
				if (this.mWake)
				{
					this.mWake = false;
					this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 1885, true);
				}
			}
		}

		// Token: 0x06000F86 RID: 3974 RVA: 0x000513D4 File Offset: 0x0004F5D4
		public override void OnMessageReceived(IMessage rMessage)
		{
			if (rMessage == null)
			{
				return;
			}
			if (rMessage.IsHandled)
			{
				return;
			}
			if (!this.mIsActive)
			{
				if (rMessage is NavigationMessage)
				{
					NavigationMessage navigationMessage = rMessage as NavigationMessage;
					if (navigationMessage != null && navigationMessage.ID == NavigationMessage.MSG_NAVIGATE_KNOCKED_DOWN && !this.mIsActive)
					{
						object obj = rMessage.Data as Vector3;
						this.mMotionController.ActivateMotion(this, 0);
						rMessage.IsHandled = true;
						rMessage.Recipient = this;
						return;
					}
				}
			}
			else if (rMessage is MotionMessage)
			{
				MotionMessage motionMessage = rMessage as MotionMessage;
				if (motionMessage.ID == MotionMessage.MSG_MOTION_CONTINUE || motionMessage.ID == MotionMessage.MSG_MOTION_DEACTIVATE)
				{
					this.mWake = true;
					rMessage.IsHandled = true;
					rMessage.Recipient = this;
					return;
				}
			}
			else if (this.WakeOnAttacked)
			{
				if (rMessage is CombatMessage)
				{
					if ((rMessage as CombatMessage).Defender == this.mMotionController.gameObject && rMessage.ID == CombatMessage.MSG_DEFENDER_ATTACKED)
					{
						this.mWake = true;
						rMessage.IsHandled = true;
						rMessage.Recipient = this;
						return;
					}
				}
				else if (rMessage is DamageMessage && rMessage.ID != CombatMessage.MSG_DEFENDER_KILLED)
				{
					this.mWake = true;
					rMessage.IsHandled = true;
					rMessage.Recipient = this;
				}
			}
		}

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x06000F87 RID: 3975 RVA: 0x0005150D File Offset: 0x0004F70D
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x06000F88 RID: 3976 RVA: 0x00051510 File Offset: 0x0004F710
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				if (animatorTransitionID == 0)
				{
					if (animatorStateID == KnockedDown.STATE_Start)
					{
						return true;
					}
					if (animatorStateID == KnockedDown.STATE_Idle_PushButton)
					{
						return true;
					}
					if (animatorStateID == KnockedDown.STATE_IdlePose)
					{
						return true;
					}
					if (animatorStateID == KnockedDown.STATE_Idle_PickUp)
					{
						return true;
					}
					if (animatorStateID == KnockedDown.STATE_Sleeping)
					{
						return true;
					}
					if (animatorStateID == KnockedDown.STATE_GettingUp)
					{
						return true;
					}
					if (animatorStateID == KnockedDown.STATE_LayingDown)
					{
						return true;
					}
					if (animatorStateID == KnockedDown.STATE_Death_180)
					{
						return true;
					}
					if (animatorStateID == KnockedDown.STATE_Death_0)
					{
						return true;
					}
					if (animatorStateID == KnockedDown.STATE_Damaged_0)
					{
						return true;
					}
					if (animatorStateID == KnockedDown.STATE_Stunned)
					{
						return true;
					}
					if (animatorStateID == KnockedDown.STATE_Cower)
					{
						return true;
					}
					if (animatorStateID == KnockedDown.STATE_CowerOut)
					{
						return true;
					}
					if (animatorStateID == KnockedDown.STATE_KnockedDown)
					{
						return true;
					}
					if (animatorStateID == KnockedDown.STATE_GettingUpBackward)
					{
						return true;
					}
					if (animatorStateID == KnockedDown.STATE_DeathPose)
					{
						return true;
					}
					if (animatorStateID == KnockedDown.STATE_Frozen)
					{
						return true;
					}
					if (animatorStateID == KnockedDown.STATE_PushedBack_Pose)
					{
						return true;
					}
					if (animatorStateID == KnockedDown.STATE_PushedBack_Recover)
					{
						return true;
					}
					if (animatorStateID == KnockedDown.STATE_PushedBack_Loop)
					{
						return true;
					}
				}
				return animatorTransitionID == KnockedDown.TRANS_AnyState_Idle_PushButton || animatorTransitionID == KnockedDown.TRANS_EntryState_Idle_PushButton || animatorTransitionID == KnockedDown.TRANS_AnyState_Idle_PickUp || animatorTransitionID == KnockedDown.TRANS_EntryState_Idle_PickUp || animatorTransitionID == KnockedDown.TRANS_AnyState_LayingDown || animatorTransitionID == KnockedDown.TRANS_EntryState_LayingDown || animatorTransitionID == KnockedDown.TRANS_AnyState_Damaged_0 || animatorTransitionID == KnockedDown.TRANS_EntryState_Damaged_0 || animatorTransitionID == KnockedDown.TRANS_AnyState_Death_180 || animatorTransitionID == KnockedDown.TRANS_EntryState_Death_180 || animatorTransitionID == KnockedDown.TRANS_AnyState_Death_0 || animatorTransitionID == KnockedDown.TRANS_EntryState_Death_0 || animatorTransitionID == KnockedDown.TRANS_AnyState_Stunned || animatorTransitionID == KnockedDown.TRANS_EntryState_Stunned || animatorTransitionID == KnockedDown.TRANS_AnyState_Cower || animatorTransitionID == KnockedDown.TRANS_EntryState_Cower || animatorTransitionID == KnockedDown.TRANS_AnyState_KnockedDown || animatorTransitionID == KnockedDown.TRANS_EntryState_KnockedDown || animatorTransitionID == KnockedDown.TRANS_AnyState_DeathPose || animatorTransitionID == KnockedDown.TRANS_EntryState_DeathPose || animatorTransitionID == KnockedDown.TRANS_AnyState_Death_180 || animatorTransitionID == KnockedDown.TRANS_EntryState_Death_180 || animatorTransitionID == KnockedDown.TRANS_AnyState_Frozen || animatorTransitionID == KnockedDown.TRANS_EntryState_Frozen || animatorTransitionID == KnockedDown.TRANS_AnyState_PushedBack_Pose || animatorTransitionID == KnockedDown.TRANS_EntryState_PushedBack_Pose || animatorTransitionID == KnockedDown.TRANS_Idle_PushButton_IdlePose || animatorTransitionID == KnockedDown.TRANS_Idle_PickUp_IdlePose || animatorTransitionID == KnockedDown.TRANS_Sleeping_GettingUp || animatorTransitionID == KnockedDown.TRANS_GettingUp_IdlePose || animatorTransitionID == KnockedDown.TRANS_LayingDown_Sleeping || animatorTransitionID == KnockedDown.TRANS_Damaged_0_IdlePose || animatorTransitionID == KnockedDown.TRANS_Stunned_IdlePose || animatorTransitionID == KnockedDown.TRANS_Cower_CowerOut || animatorTransitionID == KnockedDown.TRANS_CowerOut_IdlePose || animatorTransitionID == KnockedDown.TRANS_KnockedDown_GettingUpBackward || animatorTransitionID == KnockedDown.TRANS_GettingUpBackward_IdlePose || animatorTransitionID == KnockedDown.TRANS_Frozen_IdlePose || animatorTransitionID == KnockedDown.TRANS_PushedBack_Pose_PushedBack_Loop || animatorTransitionID == KnockedDown.TRANS_PushedBack_Recover_IdlePose || animatorTransitionID == KnockedDown.TRANS_PushedBack_Loop_PushedBack_Recover;
			}
		}

		// Token: 0x06000F89 RID: 3977 RVA: 0x000517A0 File Offset: 0x0004F9A0
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == KnockedDown.STATE_Start || rStateID == KnockedDown.STATE_Idle_PushButton || rStateID == KnockedDown.STATE_IdlePose || rStateID == KnockedDown.STATE_Idle_PickUp || rStateID == KnockedDown.STATE_Sleeping || rStateID == KnockedDown.STATE_GettingUp || rStateID == KnockedDown.STATE_LayingDown || rStateID == KnockedDown.STATE_Death_180 || rStateID == KnockedDown.STATE_Death_0 || rStateID == KnockedDown.STATE_Damaged_0 || rStateID == KnockedDown.STATE_Stunned || rStateID == KnockedDown.STATE_Cower || rStateID == KnockedDown.STATE_CowerOut || rStateID == KnockedDown.STATE_KnockedDown || rStateID == KnockedDown.STATE_GettingUpBackward || rStateID == KnockedDown.STATE_DeathPose || rStateID == KnockedDown.STATE_Frozen || rStateID == KnockedDown.STATE_PushedBack_Pose || rStateID == KnockedDown.STATE_PushedBack_Recover || rStateID == KnockedDown.STATE_PushedBack_Loop;
		}

		// Token: 0x06000F8A RID: 3978 RVA: 0x00051878 File Offset: 0x0004FA78
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			if (rTransitionID == 0)
			{
				if (rStateID == KnockedDown.STATE_Start)
				{
					return true;
				}
				if (rStateID == KnockedDown.STATE_Idle_PushButton)
				{
					return true;
				}
				if (rStateID == KnockedDown.STATE_IdlePose)
				{
					return true;
				}
				if (rStateID == KnockedDown.STATE_Idle_PickUp)
				{
					return true;
				}
				if (rStateID == KnockedDown.STATE_Sleeping)
				{
					return true;
				}
				if (rStateID == KnockedDown.STATE_GettingUp)
				{
					return true;
				}
				if (rStateID == KnockedDown.STATE_LayingDown)
				{
					return true;
				}
				if (rStateID == KnockedDown.STATE_Death_180)
				{
					return true;
				}
				if (rStateID == KnockedDown.STATE_Death_0)
				{
					return true;
				}
				if (rStateID == KnockedDown.STATE_Damaged_0)
				{
					return true;
				}
				if (rStateID == KnockedDown.STATE_Stunned)
				{
					return true;
				}
				if (rStateID == KnockedDown.STATE_Cower)
				{
					return true;
				}
				if (rStateID == KnockedDown.STATE_CowerOut)
				{
					return true;
				}
				if (rStateID == KnockedDown.STATE_KnockedDown)
				{
					return true;
				}
				if (rStateID == KnockedDown.STATE_GettingUpBackward)
				{
					return true;
				}
				if (rStateID == KnockedDown.STATE_DeathPose)
				{
					return true;
				}
				if (rStateID == KnockedDown.STATE_Frozen)
				{
					return true;
				}
				if (rStateID == KnockedDown.STATE_PushedBack_Pose)
				{
					return true;
				}
				if (rStateID == KnockedDown.STATE_PushedBack_Recover)
				{
					return true;
				}
				if (rStateID == KnockedDown.STATE_PushedBack_Loop)
				{
					return true;
				}
			}
			return rTransitionID == KnockedDown.TRANS_AnyState_Idle_PushButton || rTransitionID == KnockedDown.TRANS_EntryState_Idle_PushButton || rTransitionID == KnockedDown.TRANS_AnyState_Idle_PickUp || rTransitionID == KnockedDown.TRANS_EntryState_Idle_PickUp || rTransitionID == KnockedDown.TRANS_AnyState_LayingDown || rTransitionID == KnockedDown.TRANS_EntryState_LayingDown || rTransitionID == KnockedDown.TRANS_AnyState_Damaged_0 || rTransitionID == KnockedDown.TRANS_EntryState_Damaged_0 || rTransitionID == KnockedDown.TRANS_AnyState_Death_180 || rTransitionID == KnockedDown.TRANS_EntryState_Death_180 || rTransitionID == KnockedDown.TRANS_AnyState_Death_0 || rTransitionID == KnockedDown.TRANS_EntryState_Death_0 || rTransitionID == KnockedDown.TRANS_AnyState_Stunned || rTransitionID == KnockedDown.TRANS_EntryState_Stunned || rTransitionID == KnockedDown.TRANS_AnyState_Cower || rTransitionID == KnockedDown.TRANS_EntryState_Cower || rTransitionID == KnockedDown.TRANS_AnyState_KnockedDown || rTransitionID == KnockedDown.TRANS_EntryState_KnockedDown || rTransitionID == KnockedDown.TRANS_AnyState_DeathPose || rTransitionID == KnockedDown.TRANS_EntryState_DeathPose || rTransitionID == KnockedDown.TRANS_AnyState_Death_180 || rTransitionID == KnockedDown.TRANS_EntryState_Death_180 || rTransitionID == KnockedDown.TRANS_AnyState_Frozen || rTransitionID == KnockedDown.TRANS_EntryState_Frozen || rTransitionID == KnockedDown.TRANS_AnyState_PushedBack_Pose || rTransitionID == KnockedDown.TRANS_EntryState_PushedBack_Pose || rTransitionID == KnockedDown.TRANS_Idle_PushButton_IdlePose || rTransitionID == KnockedDown.TRANS_Idle_PickUp_IdlePose || rTransitionID == KnockedDown.TRANS_Sleeping_GettingUp || rTransitionID == KnockedDown.TRANS_GettingUp_IdlePose || rTransitionID == KnockedDown.TRANS_LayingDown_Sleeping || rTransitionID == KnockedDown.TRANS_Damaged_0_IdlePose || rTransitionID == KnockedDown.TRANS_Stunned_IdlePose || rTransitionID == KnockedDown.TRANS_Cower_CowerOut || rTransitionID == KnockedDown.TRANS_CowerOut_IdlePose || rTransitionID == KnockedDown.TRANS_KnockedDown_GettingUpBackward || rTransitionID == KnockedDown.TRANS_GettingUpBackward_IdlePose || rTransitionID == KnockedDown.TRANS_Frozen_IdlePose || rTransitionID == KnockedDown.TRANS_PushedBack_Pose_PushedBack_Loop || rTransitionID == KnockedDown.TRANS_PushedBack_Recover_IdlePose || rTransitionID == KnockedDown.TRANS_PushedBack_Loop_PushedBack_Recover;
		}

		// Token: 0x06000F8B RID: 3979 RVA: 0x00051AF0 File Offset: 0x0004FCF0
		public override void LoadAnimatorData()
		{
			KnockedDown.TRANS_AnyState_Idle_PushButton = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Idle_PushButton");
			KnockedDown.TRANS_EntryState_Idle_PushButton = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Idle_PushButton");
			KnockedDown.TRANS_AnyState_Idle_PickUp = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Idle_PickUp");
			KnockedDown.TRANS_EntryState_Idle_PickUp = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Idle_PickUp");
			KnockedDown.TRANS_AnyState_LayingDown = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.LayingDown");
			KnockedDown.TRANS_EntryState_LayingDown = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.LayingDown");
			KnockedDown.TRANS_AnyState_Damaged_0 = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Damaged_0");
			KnockedDown.TRANS_EntryState_Damaged_0 = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Damaged_0");
			KnockedDown.TRANS_AnyState_Death_180 = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Death_180");
			KnockedDown.TRANS_EntryState_Death_180 = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Death_180");
			KnockedDown.TRANS_AnyState_Death_0 = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Death_0");
			KnockedDown.TRANS_EntryState_Death_0 = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Death_0");
			KnockedDown.TRANS_AnyState_Stunned = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Stunned");
			KnockedDown.TRANS_EntryState_Stunned = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Stunned");
			KnockedDown.TRANS_AnyState_Cower = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Cower");
			KnockedDown.TRANS_EntryState_Cower = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Cower");
			KnockedDown.TRANS_AnyState_KnockedDown = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.KnockedDown");
			KnockedDown.TRANS_EntryState_KnockedDown = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.KnockedDown");
			KnockedDown.TRANS_AnyState_DeathPose = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.DeathPose");
			KnockedDown.TRANS_EntryState_DeathPose = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.DeathPose");
			KnockedDown.TRANS_AnyState_Death_180 = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Death_180");
			KnockedDown.TRANS_EntryState_Death_180 = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Death_180");
			KnockedDown.TRANS_AnyState_Frozen = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Frozen");
			KnockedDown.TRANS_EntryState_Frozen = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Frozen");
			KnockedDown.TRANS_AnyState_PushedBack_Pose = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.PushedBack_Pose");
			KnockedDown.TRANS_EntryState_PushedBack_Pose = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.PushedBack_Pose");
			KnockedDown.STATE_Start = this.mMotionController.AddAnimatorName("Base Layer.Start");
			KnockedDown.STATE_Idle_PushButton = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Idle_PushButton");
			KnockedDown.TRANS_Idle_PushButton_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Idle_PushButton -> Base Layer.Utilities-SM.IdlePose");
			KnockedDown.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.IdlePose");
			KnockedDown.STATE_Idle_PickUp = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Idle_PickUp");
			KnockedDown.TRANS_Idle_PickUp_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Idle_PickUp -> Base Layer.Utilities-SM.IdlePose");
			KnockedDown.STATE_Sleeping = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Sleeping");
			KnockedDown.TRANS_Sleeping_GettingUp = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Sleeping -> Base Layer.Utilities-SM.GettingUp");
			KnockedDown.STATE_GettingUp = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.GettingUp");
			KnockedDown.TRANS_GettingUp_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.GettingUp -> Base Layer.Utilities-SM.IdlePose");
			KnockedDown.STATE_LayingDown = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.LayingDown");
			KnockedDown.TRANS_LayingDown_Sleeping = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.LayingDown -> Base Layer.Utilities-SM.Sleeping");
			KnockedDown.STATE_Death_180 = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Death_180");
			KnockedDown.STATE_Death_0 = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Death_0");
			KnockedDown.STATE_Damaged_0 = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Damaged_0");
			KnockedDown.TRANS_Damaged_0_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Damaged_0 -> Base Layer.Utilities-SM.IdlePose");
			KnockedDown.STATE_Stunned = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Stunned");
			KnockedDown.TRANS_Stunned_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Stunned -> Base Layer.Utilities-SM.IdlePose");
			KnockedDown.STATE_Cower = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Cower");
			KnockedDown.TRANS_Cower_CowerOut = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Cower -> Base Layer.Utilities-SM.Cower Out");
			KnockedDown.STATE_CowerOut = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Cower Out");
			KnockedDown.TRANS_CowerOut_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Cower Out -> Base Layer.Utilities-SM.IdlePose");
			KnockedDown.STATE_KnockedDown = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.KnockedDown");
			KnockedDown.TRANS_KnockedDown_GettingUpBackward = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.KnockedDown -> Base Layer.Utilities-SM.GettingUpBackward");
			KnockedDown.STATE_GettingUpBackward = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.GettingUpBackward");
			KnockedDown.TRANS_GettingUpBackward_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.GettingUpBackward -> Base Layer.Utilities-SM.IdlePose");
			KnockedDown.STATE_DeathPose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.DeathPose");
			KnockedDown.STATE_Frozen = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Frozen");
			KnockedDown.TRANS_Frozen_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Frozen -> Base Layer.Utilities-SM.IdlePose");
			KnockedDown.STATE_PushedBack_Pose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.PushedBack_Pose");
			KnockedDown.TRANS_PushedBack_Pose_PushedBack_Loop = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.PushedBack_Pose -> Base Layer.Utilities-SM.PushedBack_Loop");
			KnockedDown.STATE_PushedBack_Recover = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.PushedBack_Recover");
			KnockedDown.TRANS_PushedBack_Recover_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.PushedBack_Recover -> Base Layer.Utilities-SM.IdlePose");
			KnockedDown.STATE_PushedBack_Loop = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.PushedBack_Loop");
			KnockedDown.TRANS_PushedBack_Loop_PushedBack_Recover = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.PushedBack_Loop -> Base Layer.Utilities-SM.PushedBack_Recover");
		}

		// Token: 0x040009B7 RID: 2487
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x040009B8 RID: 2488
		public const int PHASE_START = 1880;

		// Token: 0x040009B9 RID: 2489
		public const int PHASE_WAKE = 1885;

		// Token: 0x040009BA RID: 2490
		public bool _WakeOnAttacked = true;

		// Token: 0x040009BB RID: 2491
		protected bool mWake;

		// Token: 0x040009BC RID: 2492
		protected int mStoredStance;

		// Token: 0x040009BD RID: 2493
		public static int STATE_Start = -1;

		// Token: 0x040009BE RID: 2494
		public static int STATE_Idle_PushButton = -1;

		// Token: 0x040009BF RID: 2495
		public static int STATE_IdlePose = -1;

		// Token: 0x040009C0 RID: 2496
		public static int STATE_Idle_PickUp = -1;

		// Token: 0x040009C1 RID: 2497
		public static int STATE_Sleeping = -1;

		// Token: 0x040009C2 RID: 2498
		public static int STATE_GettingUp = -1;

		// Token: 0x040009C3 RID: 2499
		public static int STATE_LayingDown = -1;

		// Token: 0x040009C4 RID: 2500
		public static int STATE_Death_180 = -1;

		// Token: 0x040009C5 RID: 2501
		public static int STATE_Death_0 = -1;

		// Token: 0x040009C6 RID: 2502
		public static int STATE_Damaged_0 = -1;

		// Token: 0x040009C7 RID: 2503
		public static int STATE_Stunned = -1;

		// Token: 0x040009C8 RID: 2504
		public static int STATE_Cower = -1;

		// Token: 0x040009C9 RID: 2505
		public static int STATE_CowerOut = -1;

		// Token: 0x040009CA RID: 2506
		public static int STATE_KnockedDown = -1;

		// Token: 0x040009CB RID: 2507
		public static int STATE_GettingUpBackward = -1;

		// Token: 0x040009CC RID: 2508
		public static int STATE_DeathPose = -1;

		// Token: 0x040009CD RID: 2509
		public static int STATE_Frozen = -1;

		// Token: 0x040009CE RID: 2510
		public static int STATE_PushedBack_Pose = -1;

		// Token: 0x040009CF RID: 2511
		public static int STATE_PushedBack_Recover = -1;

		// Token: 0x040009D0 RID: 2512
		public static int STATE_PushedBack_Loop = -1;

		// Token: 0x040009D1 RID: 2513
		public static int TRANS_AnyState_Idle_PushButton = -1;

		// Token: 0x040009D2 RID: 2514
		public static int TRANS_EntryState_Idle_PushButton = -1;

		// Token: 0x040009D3 RID: 2515
		public static int TRANS_AnyState_Idle_PickUp = -1;

		// Token: 0x040009D4 RID: 2516
		public static int TRANS_EntryState_Idle_PickUp = -1;

		// Token: 0x040009D5 RID: 2517
		public static int TRANS_AnyState_LayingDown = -1;

		// Token: 0x040009D6 RID: 2518
		public static int TRANS_EntryState_LayingDown = -1;

		// Token: 0x040009D7 RID: 2519
		public static int TRANS_AnyState_Damaged_0 = -1;

		// Token: 0x040009D8 RID: 2520
		public static int TRANS_EntryState_Damaged_0 = -1;

		// Token: 0x040009D9 RID: 2521
		public static int TRANS_AnyState_Death_180 = -1;

		// Token: 0x040009DA RID: 2522
		public static int TRANS_EntryState_Death_180 = -1;

		// Token: 0x040009DB RID: 2523
		public static int TRANS_AnyState_Death_0 = -1;

		// Token: 0x040009DC RID: 2524
		public static int TRANS_EntryState_Death_0 = -1;

		// Token: 0x040009DD RID: 2525
		public static int TRANS_AnyState_Stunned = -1;

		// Token: 0x040009DE RID: 2526
		public static int TRANS_EntryState_Stunned = -1;

		// Token: 0x040009DF RID: 2527
		public static int TRANS_AnyState_Cower = -1;

		// Token: 0x040009E0 RID: 2528
		public static int TRANS_EntryState_Cower = -1;

		// Token: 0x040009E1 RID: 2529
		public static int TRANS_AnyState_KnockedDown = -1;

		// Token: 0x040009E2 RID: 2530
		public static int TRANS_EntryState_KnockedDown = -1;

		// Token: 0x040009E3 RID: 2531
		public static int TRANS_AnyState_DeathPose = -1;

		// Token: 0x040009E4 RID: 2532
		public static int TRANS_EntryState_DeathPose = -1;

		// Token: 0x040009E5 RID: 2533
		public static int TRANS_AnyState_Frozen = -1;

		// Token: 0x040009E6 RID: 2534
		public static int TRANS_EntryState_Frozen = -1;

		// Token: 0x040009E7 RID: 2535
		public static int TRANS_AnyState_PushedBack_Pose = -1;

		// Token: 0x040009E8 RID: 2536
		public static int TRANS_EntryState_PushedBack_Pose = -1;

		// Token: 0x040009E9 RID: 2537
		public static int TRANS_Idle_PushButton_IdlePose = -1;

		// Token: 0x040009EA RID: 2538
		public static int TRANS_Idle_PickUp_IdlePose = -1;

		// Token: 0x040009EB RID: 2539
		public static int TRANS_Sleeping_GettingUp = -1;

		// Token: 0x040009EC RID: 2540
		public static int TRANS_GettingUp_IdlePose = -1;

		// Token: 0x040009ED RID: 2541
		public static int TRANS_LayingDown_Sleeping = -1;

		// Token: 0x040009EE RID: 2542
		public static int TRANS_Damaged_0_IdlePose = -1;

		// Token: 0x040009EF RID: 2543
		public static int TRANS_Stunned_IdlePose = -1;

		// Token: 0x040009F0 RID: 2544
		public static int TRANS_Cower_CowerOut = -1;

		// Token: 0x040009F1 RID: 2545
		public static int TRANS_CowerOut_IdlePose = -1;

		// Token: 0x040009F2 RID: 2546
		public static int TRANS_KnockedDown_GettingUpBackward = -1;

		// Token: 0x040009F3 RID: 2547
		public static int TRANS_GettingUpBackward_IdlePose = -1;

		// Token: 0x040009F4 RID: 2548
		public static int TRANS_Frozen_IdlePose = -1;

		// Token: 0x040009F5 RID: 2549
		public static int TRANS_PushedBack_Pose_PushedBack_Loop = -1;

		// Token: 0x040009F6 RID: 2550
		public static int TRANS_PushedBack_Recover_IdlePose = -1;

		// Token: 0x040009F7 RID: 2551
		public static int TRANS_PushedBack_Loop_PushedBack_Recover = -1;
	}
}
