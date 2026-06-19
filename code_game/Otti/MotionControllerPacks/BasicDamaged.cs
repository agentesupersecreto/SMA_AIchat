using System;
using com.ootii.Actors.AnimationControllers;
using com.ootii.Actors.Combat;
using com.ootii.Geometry;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.MotionControllerPacks
{
	// Token: 0x02000003 RID: 3
	[MotionName("Basic Damaged")]
	[MotionDescription("Support generic animations for being damaged.")]
	public class BasicDamaged : MotionControllerMotion
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x000020C6 File Offset: 0x000002C6
		public override bool VerifyTransition
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020CC File Offset: 0x000002CC
		public BasicDamaged()
		{
			this._Category = 6;
			this._Priority = 30f;
			this._ActionAlias = "";
			this._OverrideLayers = true;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000212C File Offset: 0x0000032C
		public BasicDamaged(MotionController rController)
			: base(rController)
		{
			this._Category = 6;
			this._Priority = 30f;
			this._ActionAlias = "";
			this._OverrideLayers = true;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000218B File Offset: 0x0000038B
		public override void Awake()
		{
			base.Awake();
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002194 File Offset: 0x00000394
		public override bool TestActivate()
		{
			return this.mIsStartable && this.mMotionController.IsGrounded && (this._ActionAlias.Length > 0 && this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias));
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000021F0 File Offset: 0x000003F0
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
			if (this.mMotionController.State.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].StateInfo.IsTag("Exit") && this.mMotionLayer._AnimatorTransitionID == 0 && this.mMotionController.State.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].MotionPhase != this.PHASE_START)
			{
				if (this.mMotionLayer._AnimatorStateID != this.GetStateID("Unarmed Damaged 0"))
				{
					return false;
				}
				if (this.mMotionLayer._AnimatorStateNormalizedTime > 0.9f)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000022B0 File Offset: 0x000004B0
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			return true;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000022B4 File Offset: 0x000004B4
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			int num = ((this._Form > 0) ? this._Form : this.mMotionController.CurrentForm);
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, this.PHASE_START, num, base.Parameter, true);
			return base.Activate(rPrevMotion);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002309 File Offset: 0x00000509
		public override void Deactivate()
		{
			base.Deactivate();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002311 File Offset: 0x00000511
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002314 File Offset: 0x00000514
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			if (this.mActorController.State.Stance == 0)
			{
				this.mMotionController.SetAnimatorMotionParameter(this.mMotionLayer._AnimatorLayerIndex, 0);
				return;
			}
			this.mMotionController.SetAnimatorMotionParameter(this.mMotionLayer._AnimatorLayerIndex, 1);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002364 File Offset: 0x00000564
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
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, this.PHASE_START, base.Parameter, true);
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

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000F RID: 15 RVA: 0x0000248F File Offset: 0x0000068F
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002494 File Offset: 0x00000694
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				if (animatorTransitionID == 0)
				{
					if (animatorStateID == this.STATE_Empty)
					{
						return true;
					}
					if (animatorStateID == this.STATE_UnarmedDamaged0)
					{
						return true;
					}
				}
				return animatorTransitionID == this.TRANS_AnyState_UnarmedDamaged0 || animatorTransitionID == this.TRANS_EntryState_UnarmedDamaged0;
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000024E9 File Offset: 0x000006E9
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == this.STATE_Empty || rStateID == this.STATE_UnarmedDamaged0;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002502 File Offset: 0x00000702
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			if (rTransitionID == 0)
			{
				if (rStateID == this.STATE_Empty)
				{
					return true;
				}
				if (rStateID == this.STATE_UnarmedDamaged0)
				{
					return true;
				}
			}
			return rTransitionID == this.TRANS_AnyState_UnarmedDamaged0 || rTransitionID == this.TRANS_EntryState_UnarmedDamaged0;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002534 File Offset: 0x00000734
		public override void LoadAnimatorData()
		{
			string layerName = this.mMotionController.Animator.GetLayerName(this.mMotionLayer._AnimatorLayerIndex);
			this.TRANS_AnyState_UnarmedDamaged0 = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".BasicDamaged-SM.Unarmed Damaged 0");
			this.TRANS_EntryState_UnarmedDamaged0 = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".BasicDamaged-SM.Unarmed Damaged 0");
			this.STATE_Empty = this.mMotionController.AddAnimatorName(layerName + ".Empty");
			this.STATE_UnarmedDamaged0 = this.mMotionController.AddAnimatorName(layerName + ".BasicDamaged-SM.Unarmed Damaged 0");
		}

		// Token: 0x04000001 RID: 1
		public int PHASE_UNKNOWN;

		// Token: 0x04000002 RID: 2
		public int PHASE_START = 3350;

		// Token: 0x04000003 RID: 3
		public int STATE_Empty = -1;

		// Token: 0x04000004 RID: 4
		public int STATE_UnarmedDamaged0 = -1;

		// Token: 0x04000005 RID: 5
		public int TRANS_AnyState_UnarmedDamaged0 = -1;

		// Token: 0x04000006 RID: 6
		public int TRANS_EntryState_UnarmedDamaged0 = -1;
	}
}
