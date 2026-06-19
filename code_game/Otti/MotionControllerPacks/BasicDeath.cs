using System;
using com.ootii.Actors.AnimationControllers;
using com.ootii.Actors.Combat;
using com.ootii.Geometry;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.MotionControllerPacks
{
	// Token: 0x02000004 RID: 4
	[MotionName("Basic Death")]
	[MotionDescription("Support generic animations for dying.")]
	public class BasicDeath : MotionControllerMotion
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000014 RID: 20 RVA: 0x000025D7 File Offset: 0x000007D7
		public override bool VerifyTransition
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000015 RID: 21 RVA: 0x000025DA File Offset: 0x000007DA
		// (set) Token: 0x06000016 RID: 22 RVA: 0x000025E2 File Offset: 0x000007E2
		public bool RemoveBodyShapes
		{
			get
			{
				return this._RemoveBodyShapes;
			}
			set
			{
				this._RemoveBodyShapes = value;
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000025EC File Offset: 0x000007EC
		public BasicDeath()
		{
			this._Category = 9;
			this._Priority = 100f;
			this._ActionAlias = "";
			this._OverrideLayers = true;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002668 File Offset: 0x00000868
		public BasicDeath(MotionController rController)
			: base(rController)
		{
			this._Category = 9;
			this._Priority = 100f;
			this._ActionAlias = "";
			this._OverrideLayers = true;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000026E4 File Offset: 0x000008E4
		public override void Awake()
		{
			base.Awake();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000026EC File Offset: 0x000008EC
		public override bool TestActivate()
		{
			return this.mIsStartable && this.mMotionController.IsGrounded && (this._ActionAlias.Length > 0 && this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias));
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002748 File Offset: 0x00000948
		public override bool TestUpdate()
		{
			return true;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000274B File Offset: 0x0000094B
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			return false;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002750 File Offset: 0x00000950
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mIsClean = false;
			this.mActivateTransitionID = this.mMotionLayer._AnimatorTransitionID;
			this.mActorController.AllowPushback = true;
			int num = ((this._Form > 0) ? this._Form : this.mMotionController.CurrentForm);
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, this.PHASE_START, num, base.Parameter, false);
			return base.Activate(rPrevMotion);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000027C9 File Offset: 0x000009C9
		public override void Deactivate()
		{
			base.Deactivate();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000027D1 File Offset: 0x000009D1
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000027D4 File Offset: 0x000009D4
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			if (this.mMotionLayer._AnimatorTransitionID != this.mActivateTransitionID)
			{
				this.mActivateTransitionID = -1;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 0, 0, true);
			}
			if (this.mActivateTransitionID == -1 && this.mMotionLayer._AnimatorTransitionID == 0 && !this.mIsClean && this.mMotionLayer._AnimatorStateNormalizedTime > 0.6f)
			{
				this.mIsClean = true;
				this.mActorController.AllowPushback = false;
				if (this._RemoveBodyShapes)
				{
					this.mActorController.RemoveBodyShapes();
				}
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000286C File Offset: 0x00000A6C
		public override void OnMessageReceived(IMessage rMessage)
		{
			if (this.mIsActive)
			{
				return;
			}
			if (rMessage == null)
			{
				return;
			}
			if (rMessage.IsHandled)
			{
				return;
			}
			if (rMessage is CombatMessage)
			{
				CombatMessage combatMessage = rMessage as CombatMessage;
				if (!(combatMessage.Defender == this.mMotionController.gameObject))
				{
					combatMessage.Attacker == this.mMotionController.gameObject;
					return;
				}
				if (rMessage.ID == CombatMessage.MSG_DEFENDER_KILLED && !this.mIsActive)
				{
					Vector3 normalized = (this.mMotionController._Transform.InverseTransformPoint(combatMessage.HitPoint) - Vector3.zero).normalized;
					float num = Vector3.forward.HorizontalAngleTo(normalized, Vector3.up);
					this.mMotionController.ActivateMotion(this, (int)num);
					rMessage.IsHandled = true;
					return;
				}
			}
			else if (rMessage is DamageMessage && rMessage.ID == CombatMessage.MSG_DEFENDER_KILLED)
			{
				this.mMotionController.ActivateMotion(this, 0);
				rMessage.IsHandled = true;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002965 File Offset: 0x00000B65
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00002968 File Offset: 0x00000B68
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
					if (animatorStateID == this.STATE_UnarmedDeath0)
					{
						return true;
					}
					if (animatorStateID == this.STATE_UnarmedDeath180)
					{
						return true;
					}
				}
				return animatorTransitionID == this.TRANS_AnyState_UnarmedDeath0 || animatorTransitionID == this.TRANS_EntryState_UnarmedDeath0 || animatorTransitionID == this.TRANS_AnyState_UnarmedDeath180 || animatorTransitionID == this.TRANS_EntryState_UnarmedDeath180 || animatorTransitionID == this.TRANS_AnyState_UnarmedDeath180 || animatorTransitionID == this.TRANS_EntryState_UnarmedDeath180;
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000029F4 File Offset: 0x00000BF4
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == this.STATE_Empty || rStateID == this.STATE_UnarmedDeath0 || rStateID == this.STATE_UnarmedDeath180;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002A18 File Offset: 0x00000C18
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			if (rTransitionID == 0)
			{
				if (rStateID == this.STATE_Empty)
				{
					return true;
				}
				if (rStateID == this.STATE_UnarmedDeath0)
				{
					return true;
				}
				if (rStateID == this.STATE_UnarmedDeath180)
				{
					return true;
				}
			}
			return rTransitionID == this.TRANS_AnyState_UnarmedDeath0 || rTransitionID == this.TRANS_EntryState_UnarmedDeath0 || rTransitionID == this.TRANS_AnyState_UnarmedDeath180 || rTransitionID == this.TRANS_EntryState_UnarmedDeath180 || rTransitionID == this.TRANS_AnyState_UnarmedDeath180 || rTransitionID == this.TRANS_EntryState_UnarmedDeath180;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002A8C File Offset: 0x00000C8C
		public override void LoadAnimatorData()
		{
			string layerName = this.mMotionController.Animator.GetLayerName(this.mMotionLayer._AnimatorLayerIndex);
			this.TRANS_AnyState_UnarmedDeath0 = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".BasicDeath-SM.Unarmed Death 0");
			this.TRANS_EntryState_UnarmedDeath0 = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".BasicDeath-SM.Unarmed Death 0");
			this.TRANS_AnyState_UnarmedDeath180 = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".BasicDeath-SM.Unarmed Death 180");
			this.TRANS_EntryState_UnarmedDeath180 = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".BasicDeath-SM.Unarmed Death 180");
			this.TRANS_AnyState_UnarmedDeath180 = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".BasicDeath-SM.Unarmed Death 180");
			this.TRANS_EntryState_UnarmedDeath180 = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".BasicDeath-SM.Unarmed Death 180");
			this.STATE_Empty = this.mMotionController.AddAnimatorName(layerName + ".Empty");
			this.STATE_UnarmedDeath0 = this.mMotionController.AddAnimatorName(layerName + ".BasicDeath-SM.Unarmed Death 0");
			this.STATE_UnarmedDeath180 = this.mMotionController.AddAnimatorName(layerName + ".BasicDeath-SM.Unarmed Death 180");
		}

		// Token: 0x04000007 RID: 7
		public int PHASE_UNKNOWN;

		// Token: 0x04000008 RID: 8
		public int PHASE_START = 3375;

		// Token: 0x04000009 RID: 9
		public bool _RemoveBodyShapes;

		// Token: 0x0400000A RID: 10
		private bool mIsClean;

		// Token: 0x0400000B RID: 11
		private int mActivateTransitionID = -1;

		// Token: 0x0400000C RID: 12
		public int STATE_Empty = -1;

		// Token: 0x0400000D RID: 13
		public int STATE_UnarmedDeath0 = -1;

		// Token: 0x0400000E RID: 14
		public int STATE_UnarmedDeath180 = -1;

		// Token: 0x0400000F RID: 15
		public int TRANS_AnyState_UnarmedDeath0 = -1;

		// Token: 0x04000010 RID: 16
		public int TRANS_EntryState_UnarmedDeath0 = -1;

		// Token: 0x04000011 RID: 17
		public int TRANS_AnyState_UnarmedDeath180 = -1;

		// Token: 0x04000012 RID: 18
		public int TRANS_EntryState_UnarmedDeath180 = -1;
	}
}
