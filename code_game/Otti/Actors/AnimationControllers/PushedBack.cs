using System;
using com.ootii.Actors.Navigation;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x0200010D RID: 269
	[MotionName("Pushed Back")]
	[MotionDescription("This motion is a simple pose used to push the character back or forwards.")]
	public class PushedBack : MotionControllerMotion
	{
		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x06000FC8 RID: 4040 RVA: 0x00052FEA File Offset: 0x000511EA
		// (set) Token: 0x06000FC9 RID: 4041 RVA: 0x00052FF2 File Offset: 0x000511F2
		public Vector3 PushVelocity
		{
			get
			{
				return this._PushVelocity;
			}
			set
			{
				this._PushVelocity = value;
			}
		}

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x06000FCA RID: 4042 RVA: 0x00052FFB File Offset: 0x000511FB
		// (set) Token: 0x06000FCB RID: 4043 RVA: 0x00053003 File Offset: 0x00051203
		public float DragFactor
		{
			get
			{
				return this._DragFactor;
			}
			set
			{
				this._DragFactor = value;
			}
		}

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x06000FCC RID: 4044 RVA: 0x0005300C File Offset: 0x0005120C
		// (set) Token: 0x06000FCD RID: 4045 RVA: 0x00053014 File Offset: 0x00051214
		public float MaxAge
		{
			get
			{
				return this._MaxAge;
			}
			set
			{
				this._MaxAge = value;
			}
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x06000FCE RID: 4046 RVA: 0x0005301D File Offset: 0x0005121D
		// (set) Token: 0x06000FCF RID: 4047 RVA: 0x00053025 File Offset: 0x00051225
		public bool DisableUseTransform
		{
			get
			{
				return this._DisableUseTransform;
			}
			set
			{
				this._DisableUseTransform = value;
			}
		}

		// Token: 0x06000FD0 RID: 4048 RVA: 0x00053030 File Offset: 0x00051230
		public PushedBack()
		{
			this._Priority = 20f;
			this._ActionAlias = "";
			this._Category = 6;
		}

		// Token: 0x06000FD1 RID: 4049 RVA: 0x000530A4 File Offset: 0x000512A4
		public PushedBack(MotionController rController)
			: base(rController)
		{
			this._Priority = 20f;
			this._ActionAlias = "";
			this._Category = 6;
		}

		// Token: 0x06000FD2 RID: 4050 RVA: 0x00053118 File Offset: 0x00051318
		public override bool TestActivate()
		{
			if (!this.mIsStartable)
			{
				return false;
			}
			if (this._ActionAlias.Length > 0 && this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias))
			{
				this.mPushVelocity = this._PushVelocity;
				return true;
			}
			return false;
		}

		// Token: 0x06000FD3 RID: 4051 RVA: 0x00053174 File Offset: 0x00051374
		public override bool TestUpdate()
		{
			return this.mIsActivatedFrame || (this.mMotionLayer._AnimatorStateID != PushedBack.STATE_IdlePose && (this.mMotionLayer._AnimatorStateID != PushedBack.STATE_PushedBack_Recover || this.mMotionLayer._AnimatorTransitionID != 0 || this.mMotionLayer._AnimatorStateNormalizedTime <= 0.9f));
		}

		// Token: 0x06000FD4 RID: 4052 RVA: 0x000531D4 File Offset: 0x000513D4
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mHasExpired = false;
			if (this.mPushVelocity.sqrMagnitude < 0.0001f)
			{
				this.mPushVelocity = this.PushVelocity;
			}
			this.mHasPushVelocity = this.mPushVelocity.sqrMagnitude > 0.0001f;
			if (this.DisableUseTransform)
			{
				this.mStoredUseTransform = this.mActorController.UseTransformPosition;
				this.mActorController.UseTransformPosition = false;
			}
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 1830, true);
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000FD5 RID: 4053 RVA: 0x00053266 File Offset: 0x00051466
		public override void Deactivate()
		{
			this.mPushVelocity = Vector3.zero;
			if (this.DisableUseTransform)
			{
				this.mActorController.UseTransformPosition = this.mStoredUseTransform;
			}
			base.Deactivate();
		}

		// Token: 0x06000FD6 RID: 4054 RVA: 0x00053292 File Offset: 0x00051492
		public override void FixedUpdate(float rDeltaTime)
		{
			this.mPushVelocity *= 1f - this._DragFactor;
		}

		// Token: 0x06000FD7 RID: 4055 RVA: 0x000532B1 File Offset: 0x000514B1
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rVelocityDelta, ref Quaternion rRotationDelta)
		{
			rVelocityDelta = Vector3.zero;
			rRotationDelta = Quaternion.identity;
		}

		// Token: 0x06000FD8 RID: 4056 RVA: 0x000532CC File Offset: 0x000514CC
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mMovement = Vector3.zero;
			if (!this.mHasExpired && ((this._MaxAge > 0f && this.mAge > this._MaxAge) || (this.mHasPushVelocity && this.mPushVelocity.sqrMagnitude < 0.5f) || this.mActorController.State.Velocity.magnitude <= 0.5f) && this.mMotionLayer._AnimatorStateID == PushedBack.STATE_PushedBack_Loop)
			{
				this.mHasExpired = true;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 1835, false);
			}
			this.mMovement = this.mPushVelocity * rDeltaTime;
		}

		// Token: 0x06000FD9 RID: 4057 RVA: 0x00053388 File Offset: 0x00051588
		public override void OnMessageReceived(IMessage rMessage)
		{
			if (rMessage == null || rMessage.IsHandled)
			{
				return;
			}
			if (this.mActorController.State.Stance == 14)
			{
				return;
			}
			if (rMessage is NavigationMessage)
			{
				NavigationMessage navigationMessage = rMessage as NavigationMessage;
				if (navigationMessage != null && navigationMessage.ID == NavigationMessage.MSG_NAVIGATE_PUSHED_BACK && !this.mIsActive)
				{
					if (rMessage.Data is Vector3)
					{
						this.mPushVelocity = (Vector3)rMessage.Data;
					}
					this.mMotionController.ActivateMotion(this, 0);
					rMessage.IsHandled = true;
					rMessage.Recipient = this;
					return;
				}
			}
			else if (rMessage is MotionMessage && this.mIsActive && (rMessage.ID == MotionMessage.MSG_MOTION_CONTINUE || rMessage.ID == MotionMessage.MSG_MOTION_DEACTIVATE))
			{
				this.mHasExpired = true;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 1835, true);
				rMessage.IsHandled = true;
				rMessage.Recipient = this;
			}
		}

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x06000FDA RID: 4058 RVA: 0x0005347B File Offset: 0x0005167B
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x06000FDB RID: 4059 RVA: 0x00053480 File Offset: 0x00051680
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				if (animatorTransitionID == 0)
				{
					if (animatorStateID == PushedBack.STATE_Start)
					{
						return true;
					}
					if (animatorStateID == PushedBack.STATE_Idle_PushButton)
					{
						return true;
					}
					if (animatorStateID == PushedBack.STATE_IdlePose)
					{
						return true;
					}
					if (animatorStateID == PushedBack.STATE_Idle_PickUp)
					{
						return true;
					}
					if (animatorStateID == PushedBack.STATE_Sleeping)
					{
						return true;
					}
					if (animatorStateID == PushedBack.STATE_GettingUp)
					{
						return true;
					}
					if (animatorStateID == PushedBack.STATE_LayingDown)
					{
						return true;
					}
					if (animatorStateID == PushedBack.STATE_Death_180)
					{
						return true;
					}
					if (animatorStateID == PushedBack.STATE_Death_0)
					{
						return true;
					}
					if (animatorStateID == PushedBack.STATE_Damaged_0)
					{
						return true;
					}
					if (animatorStateID == PushedBack.STATE_Stunned)
					{
						return true;
					}
					if (animatorStateID == PushedBack.STATE_Cower)
					{
						return true;
					}
					if (animatorStateID == PushedBack.STATE_CowerOut)
					{
						return true;
					}
					if (animatorStateID == PushedBack.STATE_KnockedDown)
					{
						return true;
					}
					if (animatorStateID == PushedBack.STATE_GettingUpBackward)
					{
						return true;
					}
					if (animatorStateID == PushedBack.STATE_DeathPose)
					{
						return true;
					}
					if (animatorStateID == PushedBack.STATE_Frozen)
					{
						return true;
					}
					if (animatorStateID == PushedBack.STATE_PushedBack_Pose)
					{
						return true;
					}
					if (animatorStateID == PushedBack.STATE_PushedBack_Recover)
					{
						return true;
					}
					if (animatorStateID == PushedBack.STATE_PushedBack_Loop)
					{
						return true;
					}
				}
				return animatorTransitionID == PushedBack.TRANS_AnyState_Idle_PushButton || animatorTransitionID == PushedBack.TRANS_EntryState_Idle_PushButton || animatorTransitionID == PushedBack.TRANS_AnyState_Idle_PickUp || animatorTransitionID == PushedBack.TRANS_EntryState_Idle_PickUp || animatorTransitionID == PushedBack.TRANS_AnyState_LayingDown || animatorTransitionID == PushedBack.TRANS_EntryState_LayingDown || animatorTransitionID == PushedBack.TRANS_AnyState_Damaged_0 || animatorTransitionID == PushedBack.TRANS_EntryState_Damaged_0 || animatorTransitionID == PushedBack.TRANS_AnyState_Death_180 || animatorTransitionID == PushedBack.TRANS_EntryState_Death_180 || animatorTransitionID == PushedBack.TRANS_AnyState_Death_0 || animatorTransitionID == PushedBack.TRANS_EntryState_Death_0 || animatorTransitionID == PushedBack.TRANS_AnyState_Stunned || animatorTransitionID == PushedBack.TRANS_EntryState_Stunned || animatorTransitionID == PushedBack.TRANS_AnyState_Cower || animatorTransitionID == PushedBack.TRANS_EntryState_Cower || animatorTransitionID == PushedBack.TRANS_AnyState_KnockedDown || animatorTransitionID == PushedBack.TRANS_EntryState_KnockedDown || animatorTransitionID == PushedBack.TRANS_AnyState_DeathPose || animatorTransitionID == PushedBack.TRANS_EntryState_DeathPose || animatorTransitionID == PushedBack.TRANS_AnyState_Death_180 || animatorTransitionID == PushedBack.TRANS_EntryState_Death_180 || animatorTransitionID == PushedBack.TRANS_AnyState_Frozen || animatorTransitionID == PushedBack.TRANS_EntryState_Frozen || animatorTransitionID == PushedBack.TRANS_AnyState_PushedBack_Pose || animatorTransitionID == PushedBack.TRANS_EntryState_PushedBack_Pose || animatorTransitionID == PushedBack.TRANS_Idle_PushButton_IdlePose || animatorTransitionID == PushedBack.TRANS_Idle_PickUp_IdlePose || animatorTransitionID == PushedBack.TRANS_Sleeping_GettingUp || animatorTransitionID == PushedBack.TRANS_GettingUp_IdlePose || animatorTransitionID == PushedBack.TRANS_LayingDown_Sleeping || animatorTransitionID == PushedBack.TRANS_Damaged_0_IdlePose || animatorTransitionID == PushedBack.TRANS_Stunned_IdlePose || animatorTransitionID == PushedBack.TRANS_Cower_CowerOut || animatorTransitionID == PushedBack.TRANS_CowerOut_IdlePose || animatorTransitionID == PushedBack.TRANS_KnockedDown_GettingUpBackward || animatorTransitionID == PushedBack.TRANS_GettingUpBackward_IdlePose || animatorTransitionID == PushedBack.TRANS_Frozen_IdlePose || animatorTransitionID == PushedBack.TRANS_PushedBack_Pose_PushedBack_Loop || animatorTransitionID == PushedBack.TRANS_PushedBack_Recover_IdlePose || animatorTransitionID == PushedBack.TRANS_PushedBack_Loop_PushedBack_Recover;
			}
		}

		// Token: 0x06000FDC RID: 4060 RVA: 0x00053710 File Offset: 0x00051910
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == PushedBack.STATE_Start || rStateID == PushedBack.STATE_Idle_PushButton || rStateID == PushedBack.STATE_IdlePose || rStateID == PushedBack.STATE_Idle_PickUp || rStateID == PushedBack.STATE_Sleeping || rStateID == PushedBack.STATE_GettingUp || rStateID == PushedBack.STATE_LayingDown || rStateID == PushedBack.STATE_Death_180 || rStateID == PushedBack.STATE_Death_0 || rStateID == PushedBack.STATE_Damaged_0 || rStateID == PushedBack.STATE_Stunned || rStateID == PushedBack.STATE_Cower || rStateID == PushedBack.STATE_CowerOut || rStateID == PushedBack.STATE_KnockedDown || rStateID == PushedBack.STATE_GettingUpBackward || rStateID == PushedBack.STATE_DeathPose || rStateID == PushedBack.STATE_Frozen || rStateID == PushedBack.STATE_PushedBack_Pose || rStateID == PushedBack.STATE_PushedBack_Recover || rStateID == PushedBack.STATE_PushedBack_Loop;
		}

		// Token: 0x06000FDD RID: 4061 RVA: 0x000537E8 File Offset: 0x000519E8
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			if (rTransitionID == 0)
			{
				if (rStateID == PushedBack.STATE_Start)
				{
					return true;
				}
				if (rStateID == PushedBack.STATE_Idle_PushButton)
				{
					return true;
				}
				if (rStateID == PushedBack.STATE_IdlePose)
				{
					return true;
				}
				if (rStateID == PushedBack.STATE_Idle_PickUp)
				{
					return true;
				}
				if (rStateID == PushedBack.STATE_Sleeping)
				{
					return true;
				}
				if (rStateID == PushedBack.STATE_GettingUp)
				{
					return true;
				}
				if (rStateID == PushedBack.STATE_LayingDown)
				{
					return true;
				}
				if (rStateID == PushedBack.STATE_Death_180)
				{
					return true;
				}
				if (rStateID == PushedBack.STATE_Death_0)
				{
					return true;
				}
				if (rStateID == PushedBack.STATE_Damaged_0)
				{
					return true;
				}
				if (rStateID == PushedBack.STATE_Stunned)
				{
					return true;
				}
				if (rStateID == PushedBack.STATE_Cower)
				{
					return true;
				}
				if (rStateID == PushedBack.STATE_CowerOut)
				{
					return true;
				}
				if (rStateID == PushedBack.STATE_KnockedDown)
				{
					return true;
				}
				if (rStateID == PushedBack.STATE_GettingUpBackward)
				{
					return true;
				}
				if (rStateID == PushedBack.STATE_DeathPose)
				{
					return true;
				}
				if (rStateID == PushedBack.STATE_Frozen)
				{
					return true;
				}
				if (rStateID == PushedBack.STATE_PushedBack_Pose)
				{
					return true;
				}
				if (rStateID == PushedBack.STATE_PushedBack_Recover)
				{
					return true;
				}
				if (rStateID == PushedBack.STATE_PushedBack_Loop)
				{
					return true;
				}
			}
			return rTransitionID == PushedBack.TRANS_AnyState_Idle_PushButton || rTransitionID == PushedBack.TRANS_EntryState_Idle_PushButton || rTransitionID == PushedBack.TRANS_AnyState_Idle_PickUp || rTransitionID == PushedBack.TRANS_EntryState_Idle_PickUp || rTransitionID == PushedBack.TRANS_AnyState_LayingDown || rTransitionID == PushedBack.TRANS_EntryState_LayingDown || rTransitionID == PushedBack.TRANS_AnyState_Damaged_0 || rTransitionID == PushedBack.TRANS_EntryState_Damaged_0 || rTransitionID == PushedBack.TRANS_AnyState_Death_180 || rTransitionID == PushedBack.TRANS_EntryState_Death_180 || rTransitionID == PushedBack.TRANS_AnyState_Death_0 || rTransitionID == PushedBack.TRANS_EntryState_Death_0 || rTransitionID == PushedBack.TRANS_AnyState_Stunned || rTransitionID == PushedBack.TRANS_EntryState_Stunned || rTransitionID == PushedBack.TRANS_AnyState_Cower || rTransitionID == PushedBack.TRANS_EntryState_Cower || rTransitionID == PushedBack.TRANS_AnyState_KnockedDown || rTransitionID == PushedBack.TRANS_EntryState_KnockedDown || rTransitionID == PushedBack.TRANS_AnyState_DeathPose || rTransitionID == PushedBack.TRANS_EntryState_DeathPose || rTransitionID == PushedBack.TRANS_AnyState_Death_180 || rTransitionID == PushedBack.TRANS_EntryState_Death_180 || rTransitionID == PushedBack.TRANS_AnyState_Frozen || rTransitionID == PushedBack.TRANS_EntryState_Frozen || rTransitionID == PushedBack.TRANS_AnyState_PushedBack_Pose || rTransitionID == PushedBack.TRANS_EntryState_PushedBack_Pose || rTransitionID == PushedBack.TRANS_Idle_PushButton_IdlePose || rTransitionID == PushedBack.TRANS_Idle_PickUp_IdlePose || rTransitionID == PushedBack.TRANS_Sleeping_GettingUp || rTransitionID == PushedBack.TRANS_GettingUp_IdlePose || rTransitionID == PushedBack.TRANS_LayingDown_Sleeping || rTransitionID == PushedBack.TRANS_Damaged_0_IdlePose || rTransitionID == PushedBack.TRANS_Stunned_IdlePose || rTransitionID == PushedBack.TRANS_Cower_CowerOut || rTransitionID == PushedBack.TRANS_CowerOut_IdlePose || rTransitionID == PushedBack.TRANS_KnockedDown_GettingUpBackward || rTransitionID == PushedBack.TRANS_GettingUpBackward_IdlePose || rTransitionID == PushedBack.TRANS_Frozen_IdlePose || rTransitionID == PushedBack.TRANS_PushedBack_Pose_PushedBack_Loop || rTransitionID == PushedBack.TRANS_PushedBack_Recover_IdlePose || rTransitionID == PushedBack.TRANS_PushedBack_Loop_PushedBack_Recover;
		}

		// Token: 0x06000FDE RID: 4062 RVA: 0x00053A60 File Offset: 0x00051C60
		public override void LoadAnimatorData()
		{
			PushedBack.TRANS_AnyState_Idle_PushButton = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Idle_PushButton");
			PushedBack.TRANS_EntryState_Idle_PushButton = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Idle_PushButton");
			PushedBack.TRANS_AnyState_Idle_PickUp = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Idle_PickUp");
			PushedBack.TRANS_EntryState_Idle_PickUp = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Idle_PickUp");
			PushedBack.TRANS_AnyState_LayingDown = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.LayingDown");
			PushedBack.TRANS_EntryState_LayingDown = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.LayingDown");
			PushedBack.TRANS_AnyState_Damaged_0 = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Damaged_0");
			PushedBack.TRANS_EntryState_Damaged_0 = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Damaged_0");
			PushedBack.TRANS_AnyState_Death_180 = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Death_180");
			PushedBack.TRANS_EntryState_Death_180 = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Death_180");
			PushedBack.TRANS_AnyState_Death_0 = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Death_0");
			PushedBack.TRANS_EntryState_Death_0 = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Death_0");
			PushedBack.TRANS_AnyState_Stunned = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Stunned");
			PushedBack.TRANS_EntryState_Stunned = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Stunned");
			PushedBack.TRANS_AnyState_Cower = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Cower");
			PushedBack.TRANS_EntryState_Cower = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Cower");
			PushedBack.TRANS_AnyState_KnockedDown = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.KnockedDown");
			PushedBack.TRANS_EntryState_KnockedDown = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.KnockedDown");
			PushedBack.TRANS_AnyState_DeathPose = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.DeathPose");
			PushedBack.TRANS_EntryState_DeathPose = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.DeathPose");
			PushedBack.TRANS_AnyState_Death_180 = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Death_180");
			PushedBack.TRANS_EntryState_Death_180 = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Death_180");
			PushedBack.TRANS_AnyState_Frozen = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Frozen");
			PushedBack.TRANS_EntryState_Frozen = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Frozen");
			PushedBack.TRANS_AnyState_PushedBack_Pose = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.PushedBack_Pose");
			PushedBack.TRANS_EntryState_PushedBack_Pose = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.PushedBack_Pose");
			PushedBack.STATE_Start = this.mMotionController.AddAnimatorName("Base Layer.Start");
			PushedBack.STATE_Idle_PushButton = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Idle_PushButton");
			PushedBack.TRANS_Idle_PushButton_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Idle_PushButton -> Base Layer.Utilities-SM.IdlePose");
			PushedBack.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.IdlePose");
			PushedBack.STATE_Idle_PickUp = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Idle_PickUp");
			PushedBack.TRANS_Idle_PickUp_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Idle_PickUp -> Base Layer.Utilities-SM.IdlePose");
			PushedBack.STATE_Sleeping = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Sleeping");
			PushedBack.TRANS_Sleeping_GettingUp = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Sleeping -> Base Layer.Utilities-SM.GettingUp");
			PushedBack.STATE_GettingUp = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.GettingUp");
			PushedBack.TRANS_GettingUp_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.GettingUp -> Base Layer.Utilities-SM.IdlePose");
			PushedBack.STATE_LayingDown = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.LayingDown");
			PushedBack.TRANS_LayingDown_Sleeping = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.LayingDown -> Base Layer.Utilities-SM.Sleeping");
			PushedBack.STATE_Death_180 = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Death_180");
			PushedBack.STATE_Death_0 = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Death_0");
			PushedBack.STATE_Damaged_0 = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Damaged_0");
			PushedBack.TRANS_Damaged_0_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Damaged_0 -> Base Layer.Utilities-SM.IdlePose");
			PushedBack.STATE_Stunned = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Stunned");
			PushedBack.TRANS_Stunned_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Stunned -> Base Layer.Utilities-SM.IdlePose");
			PushedBack.STATE_Cower = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Cower");
			PushedBack.TRANS_Cower_CowerOut = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Cower -> Base Layer.Utilities-SM.Cower Out");
			PushedBack.STATE_CowerOut = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Cower Out");
			PushedBack.TRANS_CowerOut_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Cower Out -> Base Layer.Utilities-SM.IdlePose");
			PushedBack.STATE_KnockedDown = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.KnockedDown");
			PushedBack.TRANS_KnockedDown_GettingUpBackward = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.KnockedDown -> Base Layer.Utilities-SM.GettingUpBackward");
			PushedBack.STATE_GettingUpBackward = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.GettingUpBackward");
			PushedBack.TRANS_GettingUpBackward_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.GettingUpBackward -> Base Layer.Utilities-SM.IdlePose");
			PushedBack.STATE_DeathPose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.DeathPose");
			PushedBack.STATE_Frozen = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Frozen");
			PushedBack.TRANS_Frozen_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Frozen -> Base Layer.Utilities-SM.IdlePose");
			PushedBack.STATE_PushedBack_Pose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.PushedBack_Pose");
			PushedBack.TRANS_PushedBack_Pose_PushedBack_Loop = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.PushedBack_Pose -> Base Layer.Utilities-SM.PushedBack_Loop");
			PushedBack.STATE_PushedBack_Recover = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.PushedBack_Recover");
			PushedBack.TRANS_PushedBack_Recover_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.PushedBack_Recover -> Base Layer.Utilities-SM.IdlePose");
			PushedBack.STATE_PushedBack_Loop = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.PushedBack_Loop");
			PushedBack.TRANS_PushedBack_Loop_PushedBack_Recover = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.PushedBack_Loop -> Base Layer.Utilities-SM.PushedBack_Recover");
		}

		// Token: 0x04000A20 RID: 2592
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000A21 RID: 2593
		public const int PHASE_START = 1830;

		// Token: 0x04000A22 RID: 2594
		public const int PHASE_END = 1835;

		// Token: 0x04000A23 RID: 2595
		public Vector3 _PushVelocity = new Vector3(0f, 0f, 0f);

		// Token: 0x04000A24 RID: 2596
		public float _DragFactor = 0.05f;

		// Token: 0x04000A25 RID: 2597
		public float _MaxAge = 3f;

		// Token: 0x04000A26 RID: 2598
		public bool _DisableUseTransform = true;

		// Token: 0x04000A27 RID: 2599
		protected bool mHasExpired;

		// Token: 0x04000A28 RID: 2600
		protected bool mHasPushVelocity;

		// Token: 0x04000A29 RID: 2601
		protected Vector3 mPushVelocity = Vector3.zero;

		// Token: 0x04000A2A RID: 2602
		protected bool mStoredUseTransform;

		// Token: 0x04000A2B RID: 2603
		public static int STATE_Start = -1;

		// Token: 0x04000A2C RID: 2604
		public static int STATE_Idle_PushButton = -1;

		// Token: 0x04000A2D RID: 2605
		public static int STATE_IdlePose = -1;

		// Token: 0x04000A2E RID: 2606
		public static int STATE_Idle_PickUp = -1;

		// Token: 0x04000A2F RID: 2607
		public static int STATE_Sleeping = -1;

		// Token: 0x04000A30 RID: 2608
		public static int STATE_GettingUp = -1;

		// Token: 0x04000A31 RID: 2609
		public static int STATE_LayingDown = -1;

		// Token: 0x04000A32 RID: 2610
		public static int STATE_Death_180 = -1;

		// Token: 0x04000A33 RID: 2611
		public static int STATE_Death_0 = -1;

		// Token: 0x04000A34 RID: 2612
		public static int STATE_Damaged_0 = -1;

		// Token: 0x04000A35 RID: 2613
		public static int STATE_Stunned = -1;

		// Token: 0x04000A36 RID: 2614
		public static int STATE_Cower = -1;

		// Token: 0x04000A37 RID: 2615
		public static int STATE_CowerOut = -1;

		// Token: 0x04000A38 RID: 2616
		public static int STATE_KnockedDown = -1;

		// Token: 0x04000A39 RID: 2617
		public static int STATE_GettingUpBackward = -1;

		// Token: 0x04000A3A RID: 2618
		public static int STATE_DeathPose = -1;

		// Token: 0x04000A3B RID: 2619
		public static int STATE_Frozen = -1;

		// Token: 0x04000A3C RID: 2620
		public static int STATE_PushedBack_Pose = -1;

		// Token: 0x04000A3D RID: 2621
		public static int STATE_PushedBack_Recover = -1;

		// Token: 0x04000A3E RID: 2622
		public static int STATE_PushedBack_Loop = -1;

		// Token: 0x04000A3F RID: 2623
		public static int TRANS_AnyState_Idle_PushButton = -1;

		// Token: 0x04000A40 RID: 2624
		public static int TRANS_EntryState_Idle_PushButton = -1;

		// Token: 0x04000A41 RID: 2625
		public static int TRANS_AnyState_Idle_PickUp = -1;

		// Token: 0x04000A42 RID: 2626
		public static int TRANS_EntryState_Idle_PickUp = -1;

		// Token: 0x04000A43 RID: 2627
		public static int TRANS_AnyState_LayingDown = -1;

		// Token: 0x04000A44 RID: 2628
		public static int TRANS_EntryState_LayingDown = -1;

		// Token: 0x04000A45 RID: 2629
		public static int TRANS_AnyState_Damaged_0 = -1;

		// Token: 0x04000A46 RID: 2630
		public static int TRANS_EntryState_Damaged_0 = -1;

		// Token: 0x04000A47 RID: 2631
		public static int TRANS_AnyState_Death_180 = -1;

		// Token: 0x04000A48 RID: 2632
		public static int TRANS_EntryState_Death_180 = -1;

		// Token: 0x04000A49 RID: 2633
		public static int TRANS_AnyState_Death_0 = -1;

		// Token: 0x04000A4A RID: 2634
		public static int TRANS_EntryState_Death_0 = -1;

		// Token: 0x04000A4B RID: 2635
		public static int TRANS_AnyState_Stunned = -1;

		// Token: 0x04000A4C RID: 2636
		public static int TRANS_EntryState_Stunned = -1;

		// Token: 0x04000A4D RID: 2637
		public static int TRANS_AnyState_Cower = -1;

		// Token: 0x04000A4E RID: 2638
		public static int TRANS_EntryState_Cower = -1;

		// Token: 0x04000A4F RID: 2639
		public static int TRANS_AnyState_KnockedDown = -1;

		// Token: 0x04000A50 RID: 2640
		public static int TRANS_EntryState_KnockedDown = -1;

		// Token: 0x04000A51 RID: 2641
		public static int TRANS_AnyState_DeathPose = -1;

		// Token: 0x04000A52 RID: 2642
		public static int TRANS_EntryState_DeathPose = -1;

		// Token: 0x04000A53 RID: 2643
		public static int TRANS_AnyState_Frozen = -1;

		// Token: 0x04000A54 RID: 2644
		public static int TRANS_EntryState_Frozen = -1;

		// Token: 0x04000A55 RID: 2645
		public static int TRANS_AnyState_PushedBack_Pose = -1;

		// Token: 0x04000A56 RID: 2646
		public static int TRANS_EntryState_PushedBack_Pose = -1;

		// Token: 0x04000A57 RID: 2647
		public static int TRANS_Idle_PushButton_IdlePose = -1;

		// Token: 0x04000A58 RID: 2648
		public static int TRANS_Idle_PickUp_IdlePose = -1;

		// Token: 0x04000A59 RID: 2649
		public static int TRANS_Sleeping_GettingUp = -1;

		// Token: 0x04000A5A RID: 2650
		public static int TRANS_GettingUp_IdlePose = -1;

		// Token: 0x04000A5B RID: 2651
		public static int TRANS_LayingDown_Sleeping = -1;

		// Token: 0x04000A5C RID: 2652
		public static int TRANS_Damaged_0_IdlePose = -1;

		// Token: 0x04000A5D RID: 2653
		public static int TRANS_Stunned_IdlePose = -1;

		// Token: 0x04000A5E RID: 2654
		public static int TRANS_Cower_CowerOut = -1;

		// Token: 0x04000A5F RID: 2655
		public static int TRANS_CowerOut_IdlePose = -1;

		// Token: 0x04000A60 RID: 2656
		public static int TRANS_KnockedDown_GettingUpBackward = -1;

		// Token: 0x04000A61 RID: 2657
		public static int TRANS_GettingUpBackward_IdlePose = -1;

		// Token: 0x04000A62 RID: 2658
		public static int TRANS_Frozen_IdlePose = -1;

		// Token: 0x04000A63 RID: 2659
		public static int TRANS_PushedBack_Pose_PushedBack_Loop = -1;

		// Token: 0x04000A64 RID: 2660
		public static int TRANS_PushedBack_Recover_IdlePose = -1;

		// Token: 0x04000A65 RID: 2661
		public static int TRANS_PushedBack_Loop_PushedBack_Recover = -1;
	}
}
