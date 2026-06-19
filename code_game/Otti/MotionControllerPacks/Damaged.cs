using System;
using com.ootii.Actors.AnimationControllers;
using com.ootii.Actors.Combat;
using com.ootii.Geometry;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.MotionControllerPacks
{
	// Token: 0x02000007 RID: 7
	[MotionName("Damaged")]
	[MotionDescription("Support generic animations for being damaged.")]
	public class Damaged : MotionControllerMotion
	{
		// Token: 0x06000069 RID: 105 RVA: 0x00003A55 File Offset: 0x00001C55
		public Damaged()
		{
			this._Pack = Idle.GroupName();
			this._Category = 6;
			this._Priority = 30f;
			this._ActionAlias = "";
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00003A85 File Offset: 0x00001C85
		public Damaged(MotionController rController)
			: base(rController)
		{
			this._Pack = Idle.GroupName();
			this._Category = 6;
			this._Priority = 30f;
			this._ActionAlias = "";
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003AB6 File Offset: 0x00001CB6
		public override void Awake()
		{
			base.Awake();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003AC0 File Offset: 0x00001CC0
		public override bool TestActivate()
		{
			return this.mIsStartable && this.mMotionController.IsGrounded && this.mActorController.State.Stance == 0 && (this._ActionAlias.Length > 0 && this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias));
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003B30 File Offset: 0x00001D30
		public override bool TestUpdate()
		{
			return this.mIsActivatedFrame || (this.mMotionController.IsGrounded && (this.mMotionLayer._AnimatorStateID != Damaged.STATE_IdlePose || this.mMotionLayer._AnimatorTransitionID != 0 || this.mMotionController.State.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].MotionPhase == 1850) && (!this.mIsAnimatorActive || this.IsInMotionState));
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003BB6 File Offset: 0x00001DB6
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			return true;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003BB9 File Offset: 0x00001DB9
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 1850, base.Parameter, true);
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003BE4 File Offset: 0x00001DE4
		public override void Deactivate()
		{
			base.Deactivate();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003BEC File Offset: 0x00001DEC
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			rMovement = Vector3.zero;
			rRotation = Quaternion.identity;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003C08 File Offset: 0x00001E08
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			if (this.mMotionLayer._AnimatorTransitionID == Damaged.TRANS_EntryState_Damaged_0 || this.mMotionLayer._AnimatorTransitionID == Damaged.TRANS_EntryState_Death_0 || this.mMotionLayer._AnimatorTransitionID == Damaged.TRANS_EntryState_Death_180)
			{
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 0, 0, true);
			}
			if (this.mMotionLayer._AnimatorStateID == Damaged.STATE_Damaged_0)
			{
				if (this.mActorController.State.Stance == 11)
				{
					this.mMotionController.SetAnimatorMotionParameter(this.mMotionLayer._AnimatorLayerIndex, 1);
					return;
				}
				this.mMotionController.SetAnimatorMotionParameter(this.mMotionLayer._AnimatorLayerIndex, 0);
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003CBC File Offset: 0x00001EBC
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
			if (this.mActorController.State.Stance != 0)
			{
				return;
			}
			if (rMessage is CombatMessage)
			{
				CombatMessage combatMessage = rMessage as CombatMessage;
				if (!(combatMessage.Attacker == this.mMotionController.gameObject) && combatMessage.Defender == this.mMotionController.gameObject && rMessage.ID == CombatMessage.MSG_DEFENDER_DAMAGED)
				{
					if (!this.mIsActive)
					{
						Vector3 normalized = (this.mMotionController._Transform.InverseTransformPoint(combatMessage.HitPoint) - Vector3.zero).normalized;
						float num = Vector3.forward.HorizontalAngleTo(normalized, Vector3.up);
						this.mMotionController.ActivateMotion(this, (int)num);
					}
					else
					{
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 1850, base.Parameter, false);
					}
					rMessage.IsHandled = true;
					return;
				}
			}
			else if (rMessage is DamageMessage && rMessage.ID == CombatMessage.MSG_DEFENDER_DAMAGED)
			{
				this.mMotionController.ActivateMotion(this, 0);
				rMessage.IsHandled = true;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00003DE6 File Offset: 0x00001FE6
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00003DEC File Offset: 0x00001FEC
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				if (animatorTransitionID == 0)
				{
					if (animatorStateID == Damaged.STATE_Start)
					{
						return true;
					}
					if (animatorStateID == Damaged.STATE_Idle_PushButton)
					{
						return true;
					}
					if (animatorStateID == Damaged.STATE_IdlePose)
					{
						return true;
					}
					if (animatorStateID == Damaged.STATE_Idle_PickUp)
					{
						return true;
					}
					if (animatorStateID == Damaged.STATE_Sleeping)
					{
						return true;
					}
					if (animatorStateID == Damaged.STATE_GettingUp)
					{
						return true;
					}
					if (animatorStateID == Damaged.STATE_LayingDown)
					{
						return true;
					}
					if (animatorStateID == Damaged.STATE_Death_180)
					{
						return true;
					}
					if (animatorStateID == Damaged.STATE_Death_0)
					{
						return true;
					}
					if (animatorStateID == Damaged.STATE_Damaged_0)
					{
						return true;
					}
					if (animatorStateID == Damaged.STATE_Stunned)
					{
						return true;
					}
					if (animatorStateID == Damaged.STATE_Cower)
					{
						return true;
					}
					if (animatorStateID == Damaged.STATE_CowerOut)
					{
						return true;
					}
					if (animatorStateID == Damaged.STATE_KnockedDown)
					{
						return true;
					}
					if (animatorStateID == Damaged.STATE_GettingUpBackward)
					{
						return true;
					}
					if (animatorStateID == Damaged.STATE_DeathPose)
					{
						return true;
					}
					if (animatorStateID == Damaged.STATE_Frozen)
					{
						return true;
					}
					if (animatorStateID == Damaged.STATE_PushedBack_Pose)
					{
						return true;
					}
					if (animatorStateID == Damaged.STATE_PushedBack_Recover)
					{
						return true;
					}
					if (animatorStateID == Damaged.STATE_PushedBack_Loop)
					{
						return true;
					}
				}
				return animatorTransitionID == Damaged.TRANS_AnyState_Idle_PushButton || animatorTransitionID == Damaged.TRANS_EntryState_Idle_PushButton || animatorTransitionID == Damaged.TRANS_AnyState_Idle_PickUp || animatorTransitionID == Damaged.TRANS_EntryState_Idle_PickUp || animatorTransitionID == Damaged.TRANS_AnyState_LayingDown || animatorTransitionID == Damaged.TRANS_EntryState_LayingDown || animatorTransitionID == Damaged.TRANS_AnyState_Damaged_0 || animatorTransitionID == Damaged.TRANS_EntryState_Damaged_0 || animatorTransitionID == Damaged.TRANS_AnyState_Death_180 || animatorTransitionID == Damaged.TRANS_EntryState_Death_180 || animatorTransitionID == Damaged.TRANS_AnyState_Death_0 || animatorTransitionID == Damaged.TRANS_EntryState_Death_0 || animatorTransitionID == Damaged.TRANS_AnyState_Stunned || animatorTransitionID == Damaged.TRANS_EntryState_Stunned || animatorTransitionID == Damaged.TRANS_AnyState_Cower || animatorTransitionID == Damaged.TRANS_EntryState_Cower || animatorTransitionID == Damaged.TRANS_AnyState_KnockedDown || animatorTransitionID == Damaged.TRANS_EntryState_KnockedDown || animatorTransitionID == Damaged.TRANS_AnyState_DeathPose || animatorTransitionID == Damaged.TRANS_EntryState_DeathPose || animatorTransitionID == Damaged.TRANS_AnyState_Death_180 || animatorTransitionID == Damaged.TRANS_EntryState_Death_180 || animatorTransitionID == Damaged.TRANS_AnyState_Frozen || animatorTransitionID == Damaged.TRANS_EntryState_Frozen || animatorTransitionID == Damaged.TRANS_AnyState_PushedBack_Pose || animatorTransitionID == Damaged.TRANS_EntryState_PushedBack_Pose || animatorTransitionID == Damaged.TRANS_Idle_PushButton_IdlePose || animatorTransitionID == Damaged.TRANS_Idle_PickUp_IdlePose || animatorTransitionID == Damaged.TRANS_Sleeping_GettingUp || animatorTransitionID == Damaged.TRANS_GettingUp_IdlePose || animatorTransitionID == Damaged.TRANS_LayingDown_Sleeping || animatorTransitionID == Damaged.TRANS_Damaged_0_IdlePose || animatorTransitionID == Damaged.TRANS_Stunned_IdlePose || animatorTransitionID == Damaged.TRANS_Cower_CowerOut || animatorTransitionID == Damaged.TRANS_CowerOut_IdlePose || animatorTransitionID == Damaged.TRANS_KnockedDown_GettingUpBackward || animatorTransitionID == Damaged.TRANS_GettingUpBackward_IdlePose || animatorTransitionID == Damaged.TRANS_Frozen_IdlePose || animatorTransitionID == Damaged.TRANS_PushedBack_Pose_PushedBack_Loop || animatorTransitionID == Damaged.TRANS_PushedBack_Recover_IdlePose || animatorTransitionID == Damaged.TRANS_PushedBack_Loop_PushedBack_Recover;
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0000407C File Offset: 0x0000227C
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == Damaged.STATE_Start || rStateID == Damaged.STATE_Idle_PushButton || rStateID == Damaged.STATE_IdlePose || rStateID == Damaged.STATE_Idle_PickUp || rStateID == Damaged.STATE_Sleeping || rStateID == Damaged.STATE_GettingUp || rStateID == Damaged.STATE_LayingDown || rStateID == Damaged.STATE_Death_180 || rStateID == Damaged.STATE_Death_0 || rStateID == Damaged.STATE_Damaged_0 || rStateID == Damaged.STATE_Stunned || rStateID == Damaged.STATE_Cower || rStateID == Damaged.STATE_CowerOut || rStateID == Damaged.STATE_KnockedDown || rStateID == Damaged.STATE_GettingUpBackward || rStateID == Damaged.STATE_DeathPose || rStateID == Damaged.STATE_Frozen || rStateID == Damaged.STATE_PushedBack_Pose || rStateID == Damaged.STATE_PushedBack_Recover || rStateID == Damaged.STATE_PushedBack_Loop;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00004154 File Offset: 0x00002354
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			if (rTransitionID == 0)
			{
				if (rStateID == Damaged.STATE_Start)
				{
					return true;
				}
				if (rStateID == Damaged.STATE_Idle_PushButton)
				{
					return true;
				}
				if (rStateID == Damaged.STATE_IdlePose)
				{
					return true;
				}
				if (rStateID == Damaged.STATE_Idle_PickUp)
				{
					return true;
				}
				if (rStateID == Damaged.STATE_Sleeping)
				{
					return true;
				}
				if (rStateID == Damaged.STATE_GettingUp)
				{
					return true;
				}
				if (rStateID == Damaged.STATE_LayingDown)
				{
					return true;
				}
				if (rStateID == Damaged.STATE_Death_180)
				{
					return true;
				}
				if (rStateID == Damaged.STATE_Death_0)
				{
					return true;
				}
				if (rStateID == Damaged.STATE_Damaged_0)
				{
					return true;
				}
				if (rStateID == Damaged.STATE_Stunned)
				{
					return true;
				}
				if (rStateID == Damaged.STATE_Cower)
				{
					return true;
				}
				if (rStateID == Damaged.STATE_CowerOut)
				{
					return true;
				}
				if (rStateID == Damaged.STATE_KnockedDown)
				{
					return true;
				}
				if (rStateID == Damaged.STATE_GettingUpBackward)
				{
					return true;
				}
				if (rStateID == Damaged.STATE_DeathPose)
				{
					return true;
				}
				if (rStateID == Damaged.STATE_Frozen)
				{
					return true;
				}
				if (rStateID == Damaged.STATE_PushedBack_Pose)
				{
					return true;
				}
				if (rStateID == Damaged.STATE_PushedBack_Recover)
				{
					return true;
				}
				if (rStateID == Damaged.STATE_PushedBack_Loop)
				{
					return true;
				}
			}
			return rTransitionID == Damaged.TRANS_AnyState_Idle_PushButton || rTransitionID == Damaged.TRANS_EntryState_Idle_PushButton || rTransitionID == Damaged.TRANS_AnyState_Idle_PickUp || rTransitionID == Damaged.TRANS_EntryState_Idle_PickUp || rTransitionID == Damaged.TRANS_AnyState_LayingDown || rTransitionID == Damaged.TRANS_EntryState_LayingDown || rTransitionID == Damaged.TRANS_AnyState_Damaged_0 || rTransitionID == Damaged.TRANS_EntryState_Damaged_0 || rTransitionID == Damaged.TRANS_AnyState_Death_180 || rTransitionID == Damaged.TRANS_EntryState_Death_180 || rTransitionID == Damaged.TRANS_AnyState_Death_0 || rTransitionID == Damaged.TRANS_EntryState_Death_0 || rTransitionID == Damaged.TRANS_AnyState_Stunned || rTransitionID == Damaged.TRANS_EntryState_Stunned || rTransitionID == Damaged.TRANS_AnyState_Cower || rTransitionID == Damaged.TRANS_EntryState_Cower || rTransitionID == Damaged.TRANS_AnyState_KnockedDown || rTransitionID == Damaged.TRANS_EntryState_KnockedDown || rTransitionID == Damaged.TRANS_AnyState_DeathPose || rTransitionID == Damaged.TRANS_EntryState_DeathPose || rTransitionID == Damaged.TRANS_AnyState_Death_180 || rTransitionID == Damaged.TRANS_EntryState_Death_180 || rTransitionID == Damaged.TRANS_AnyState_Frozen || rTransitionID == Damaged.TRANS_EntryState_Frozen || rTransitionID == Damaged.TRANS_AnyState_PushedBack_Pose || rTransitionID == Damaged.TRANS_EntryState_PushedBack_Pose || rTransitionID == Damaged.TRANS_Idle_PushButton_IdlePose || rTransitionID == Damaged.TRANS_Idle_PickUp_IdlePose || rTransitionID == Damaged.TRANS_Sleeping_GettingUp || rTransitionID == Damaged.TRANS_GettingUp_IdlePose || rTransitionID == Damaged.TRANS_LayingDown_Sleeping || rTransitionID == Damaged.TRANS_Damaged_0_IdlePose || rTransitionID == Damaged.TRANS_Stunned_IdlePose || rTransitionID == Damaged.TRANS_Cower_CowerOut || rTransitionID == Damaged.TRANS_CowerOut_IdlePose || rTransitionID == Damaged.TRANS_KnockedDown_GettingUpBackward || rTransitionID == Damaged.TRANS_GettingUpBackward_IdlePose || rTransitionID == Damaged.TRANS_Frozen_IdlePose || rTransitionID == Damaged.TRANS_PushedBack_Pose_PushedBack_Loop || rTransitionID == Damaged.TRANS_PushedBack_Recover_IdlePose || rTransitionID == Damaged.TRANS_PushedBack_Loop_PushedBack_Recover;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000043CC File Offset: 0x000025CC
		public override void LoadAnimatorData()
		{
			Damaged.TRANS_AnyState_Idle_PushButton = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Idle_PushButton");
			Damaged.TRANS_EntryState_Idle_PushButton = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Idle_PushButton");
			Damaged.TRANS_AnyState_Idle_PickUp = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Idle_PickUp");
			Damaged.TRANS_EntryState_Idle_PickUp = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Idle_PickUp");
			Damaged.TRANS_AnyState_LayingDown = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.LayingDown");
			Damaged.TRANS_EntryState_LayingDown = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.LayingDown");
			Damaged.TRANS_AnyState_Damaged_0 = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Damaged_0");
			Damaged.TRANS_EntryState_Damaged_0 = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Damaged_0");
			Damaged.TRANS_AnyState_Death_180 = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Death_180");
			Damaged.TRANS_EntryState_Death_180 = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Death_180");
			Damaged.TRANS_AnyState_Death_0 = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Death_0");
			Damaged.TRANS_EntryState_Death_0 = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Death_0");
			Damaged.TRANS_AnyState_Stunned = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Stunned");
			Damaged.TRANS_EntryState_Stunned = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Stunned");
			Damaged.TRANS_AnyState_Cower = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Cower");
			Damaged.TRANS_EntryState_Cower = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Cower");
			Damaged.TRANS_AnyState_KnockedDown = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.KnockedDown");
			Damaged.TRANS_EntryState_KnockedDown = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.KnockedDown");
			Damaged.TRANS_AnyState_DeathPose = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.DeathPose");
			Damaged.TRANS_EntryState_DeathPose = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.DeathPose");
			Damaged.TRANS_AnyState_Death_180 = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Death_180");
			Damaged.TRANS_EntryState_Death_180 = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Death_180");
			Damaged.TRANS_AnyState_Frozen = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.Frozen");
			Damaged.TRANS_EntryState_Frozen = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.Frozen");
			Damaged.TRANS_AnyState_PushedBack_Pose = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Utilities-SM.PushedBack_Pose");
			Damaged.TRANS_EntryState_PushedBack_Pose = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Utilities-SM.PushedBack_Pose");
			Damaged.STATE_Start = this.mMotionController.AddAnimatorName("Base Layer.Start");
			Damaged.STATE_Idle_PushButton = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Idle_PushButton");
			Damaged.TRANS_Idle_PushButton_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Idle_PushButton -> Base Layer.Utilities-SM.IdlePose");
			Damaged.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.IdlePose");
			Damaged.STATE_Idle_PickUp = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Idle_PickUp");
			Damaged.TRANS_Idle_PickUp_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Idle_PickUp -> Base Layer.Utilities-SM.IdlePose");
			Damaged.STATE_Sleeping = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Sleeping");
			Damaged.TRANS_Sleeping_GettingUp = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Sleeping -> Base Layer.Utilities-SM.GettingUp");
			Damaged.STATE_GettingUp = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.GettingUp");
			Damaged.TRANS_GettingUp_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.GettingUp -> Base Layer.Utilities-SM.IdlePose");
			Damaged.STATE_LayingDown = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.LayingDown");
			Damaged.TRANS_LayingDown_Sleeping = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.LayingDown -> Base Layer.Utilities-SM.Sleeping");
			Damaged.STATE_Death_180 = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Death_180");
			Damaged.STATE_Death_0 = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Death_0");
			Damaged.STATE_Damaged_0 = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Damaged_0");
			Damaged.TRANS_Damaged_0_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Damaged_0 -> Base Layer.Utilities-SM.IdlePose");
			Damaged.STATE_Stunned = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Stunned");
			Damaged.TRANS_Stunned_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Stunned -> Base Layer.Utilities-SM.IdlePose");
			Damaged.STATE_Cower = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Cower");
			Damaged.TRANS_Cower_CowerOut = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Cower -> Base Layer.Utilities-SM.Cower Out");
			Damaged.STATE_CowerOut = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Cower Out");
			Damaged.TRANS_CowerOut_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Cower Out -> Base Layer.Utilities-SM.IdlePose");
			Damaged.STATE_KnockedDown = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.KnockedDown");
			Damaged.TRANS_KnockedDown_GettingUpBackward = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.KnockedDown -> Base Layer.Utilities-SM.GettingUpBackward");
			Damaged.STATE_GettingUpBackward = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.GettingUpBackward");
			Damaged.TRANS_GettingUpBackward_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.GettingUpBackward -> Base Layer.Utilities-SM.IdlePose");
			Damaged.STATE_DeathPose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.DeathPose");
			Damaged.STATE_Frozen = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Frozen");
			Damaged.TRANS_Frozen_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.Frozen -> Base Layer.Utilities-SM.IdlePose");
			Damaged.STATE_PushedBack_Pose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.PushedBack_Pose");
			Damaged.TRANS_PushedBack_Pose_PushedBack_Loop = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.PushedBack_Pose -> Base Layer.Utilities-SM.PushedBack_Loop");
			Damaged.STATE_PushedBack_Recover = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.PushedBack_Recover");
			Damaged.TRANS_PushedBack_Recover_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.PushedBack_Recover -> Base Layer.Utilities-SM.IdlePose");
			Damaged.STATE_PushedBack_Loop = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.PushedBack_Loop");
			Damaged.TRANS_PushedBack_Loop_PushedBack_Recover = this.mMotionController.AddAnimatorName("Base Layer.Utilities-SM.PushedBack_Loop -> Base Layer.Utilities-SM.PushedBack_Recover");
		}

		// Token: 0x04000028 RID: 40
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000029 RID: 41
		public const int PHASE_START = 1850;

		// Token: 0x0400002A RID: 42
		public static int STATE_Start = -1;

		// Token: 0x0400002B RID: 43
		public static int STATE_Idle_PushButton = -1;

		// Token: 0x0400002C RID: 44
		public static int STATE_IdlePose = -1;

		// Token: 0x0400002D RID: 45
		public static int STATE_Idle_PickUp = -1;

		// Token: 0x0400002E RID: 46
		public static int STATE_Sleeping = -1;

		// Token: 0x0400002F RID: 47
		public static int STATE_GettingUp = -1;

		// Token: 0x04000030 RID: 48
		public static int STATE_LayingDown = -1;

		// Token: 0x04000031 RID: 49
		public static int STATE_Death_180 = -1;

		// Token: 0x04000032 RID: 50
		public static int STATE_Death_0 = -1;

		// Token: 0x04000033 RID: 51
		public static int STATE_Damaged_0 = -1;

		// Token: 0x04000034 RID: 52
		public static int STATE_Stunned = -1;

		// Token: 0x04000035 RID: 53
		public static int STATE_Cower = -1;

		// Token: 0x04000036 RID: 54
		public static int STATE_CowerOut = -1;

		// Token: 0x04000037 RID: 55
		public static int STATE_KnockedDown = -1;

		// Token: 0x04000038 RID: 56
		public static int STATE_GettingUpBackward = -1;

		// Token: 0x04000039 RID: 57
		public static int STATE_DeathPose = -1;

		// Token: 0x0400003A RID: 58
		public static int STATE_Frozen = -1;

		// Token: 0x0400003B RID: 59
		public static int STATE_PushedBack_Pose = -1;

		// Token: 0x0400003C RID: 60
		public static int STATE_PushedBack_Recover = -1;

		// Token: 0x0400003D RID: 61
		public static int STATE_PushedBack_Loop = -1;

		// Token: 0x0400003E RID: 62
		public static int TRANS_AnyState_Idle_PushButton = -1;

		// Token: 0x0400003F RID: 63
		public static int TRANS_EntryState_Idle_PushButton = -1;

		// Token: 0x04000040 RID: 64
		public static int TRANS_AnyState_Idle_PickUp = -1;

		// Token: 0x04000041 RID: 65
		public static int TRANS_EntryState_Idle_PickUp = -1;

		// Token: 0x04000042 RID: 66
		public static int TRANS_AnyState_LayingDown = -1;

		// Token: 0x04000043 RID: 67
		public static int TRANS_EntryState_LayingDown = -1;

		// Token: 0x04000044 RID: 68
		public static int TRANS_AnyState_Damaged_0 = -1;

		// Token: 0x04000045 RID: 69
		public static int TRANS_EntryState_Damaged_0 = -1;

		// Token: 0x04000046 RID: 70
		public static int TRANS_AnyState_Death_180 = -1;

		// Token: 0x04000047 RID: 71
		public static int TRANS_EntryState_Death_180 = -1;

		// Token: 0x04000048 RID: 72
		public static int TRANS_AnyState_Death_0 = -1;

		// Token: 0x04000049 RID: 73
		public static int TRANS_EntryState_Death_0 = -1;

		// Token: 0x0400004A RID: 74
		public static int TRANS_AnyState_Stunned = -1;

		// Token: 0x0400004B RID: 75
		public static int TRANS_EntryState_Stunned = -1;

		// Token: 0x0400004C RID: 76
		public static int TRANS_AnyState_Cower = -1;

		// Token: 0x0400004D RID: 77
		public static int TRANS_EntryState_Cower = -1;

		// Token: 0x0400004E RID: 78
		public static int TRANS_AnyState_KnockedDown = -1;

		// Token: 0x0400004F RID: 79
		public static int TRANS_EntryState_KnockedDown = -1;

		// Token: 0x04000050 RID: 80
		public static int TRANS_AnyState_DeathPose = -1;

		// Token: 0x04000051 RID: 81
		public static int TRANS_EntryState_DeathPose = -1;

		// Token: 0x04000052 RID: 82
		public static int TRANS_AnyState_Frozen = -1;

		// Token: 0x04000053 RID: 83
		public static int TRANS_EntryState_Frozen = -1;

		// Token: 0x04000054 RID: 84
		public static int TRANS_AnyState_PushedBack_Pose = -1;

		// Token: 0x04000055 RID: 85
		public static int TRANS_EntryState_PushedBack_Pose = -1;

		// Token: 0x04000056 RID: 86
		public static int TRANS_Idle_PushButton_IdlePose = -1;

		// Token: 0x04000057 RID: 87
		public static int TRANS_Idle_PickUp_IdlePose = -1;

		// Token: 0x04000058 RID: 88
		public static int TRANS_Sleeping_GettingUp = -1;

		// Token: 0x04000059 RID: 89
		public static int TRANS_GettingUp_IdlePose = -1;

		// Token: 0x0400005A RID: 90
		public static int TRANS_LayingDown_Sleeping = -1;

		// Token: 0x0400005B RID: 91
		public static int TRANS_Damaged_0_IdlePose = -1;

		// Token: 0x0400005C RID: 92
		public static int TRANS_Stunned_IdlePose = -1;

		// Token: 0x0400005D RID: 93
		public static int TRANS_Cower_CowerOut = -1;

		// Token: 0x0400005E RID: 94
		public static int TRANS_CowerOut_IdlePose = -1;

		// Token: 0x0400005F RID: 95
		public static int TRANS_KnockedDown_GettingUpBackward = -1;

		// Token: 0x04000060 RID: 96
		public static int TRANS_GettingUpBackward_IdlePose = -1;

		// Token: 0x04000061 RID: 97
		public static int TRANS_Frozen_IdlePose = -1;

		// Token: 0x04000062 RID: 98
		public static int TRANS_PushedBack_Pose_PushedBack_Loop = -1;

		// Token: 0x04000063 RID: 99
		public static int TRANS_PushedBack_Recover_IdlePose = -1;

		// Token: 0x04000064 RID: 100
		public static int TRANS_PushedBack_Loop_PushedBack_Recover = -1;
	}
}
