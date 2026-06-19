using System;
using com.ootii.Actors.Navigation;
using com.ootii.Geometry;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000FB RID: 251
	[MotionName("Climb 0.5 Meters")]
	[MotionDescription("Allows for getting ontop of an object that's roughly 0.5 meter high.")]
	public class Climb_0_5m : MotionControllerMotion
	{
		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06000E3B RID: 3643 RVA: 0x00049A45 File Offset: 0x00047C45
		// (set) Token: 0x06000E3C RID: 3644 RVA: 0x00049A4D File Offset: 0x00047C4D
		public float MinDistance
		{
			get
			{
				return this._MinDistance;
			}
			set
			{
				this._MinDistance = value;
			}
		}

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x06000E3D RID: 3645 RVA: 0x00049A56 File Offset: 0x00047C56
		// (set) Token: 0x06000E3E RID: 3646 RVA: 0x00049A5E File Offset: 0x00047C5E
		public float MaxDistance
		{
			get
			{
				return this._MaxDistance;
			}
			set
			{
				this._MaxDistance = value;
			}
		}

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x06000E3F RID: 3647 RVA: 0x00049A67 File Offset: 0x00047C67
		// (set) Token: 0x06000E40 RID: 3648 RVA: 0x00049A6F File Offset: 0x00047C6F
		public float MinHeight
		{
			get
			{
				return this._MinHeight;
			}
			set
			{
				this._MinHeight = value;
			}
		}

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x06000E41 RID: 3649 RVA: 0x00049A78 File Offset: 0x00047C78
		// (set) Token: 0x06000E42 RID: 3650 RVA: 0x00049A80 File Offset: 0x00047C80
		public float MaxHeight
		{
			get
			{
				return this._MaxHeight;
			}
			set
			{
				this._MaxHeight = value;
			}
		}

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x06000E43 RID: 3651 RVA: 0x00049A89 File Offset: 0x00047C89
		// (set) Token: 0x06000E44 RID: 3652 RVA: 0x00049A91 File Offset: 0x00047C91
		public int ClimbableLayers
		{
			get
			{
				return this._ClimbableLayers;
			}
			set
			{
				this._ClimbableLayers = value;
			}
		}

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x06000E45 RID: 3653 RVA: 0x00049A9A File Offset: 0x00047C9A
		// (set) Token: 0x06000E46 RID: 3654 RVA: 0x00049AA2 File Offset: 0x00047CA2
		public float ReachOffset1
		{
			get
			{
				return this._ReachOffset1;
			}
			set
			{
				this._ReachOffset1 = value;
			}
		}

		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x06000E47 RID: 3655 RVA: 0x00049AAB File Offset: 0x00047CAB
		// (set) Token: 0x06000E48 RID: 3656 RVA: 0x00049AB3 File Offset: 0x00047CB3
		public float ReachOffset2
		{
			get
			{
				return this._ReachOffset2;
			}
			set
			{
				this._ReachOffset2 = value;
			}
		}

		// Token: 0x06000E49 RID: 3657 RVA: 0x00049ABC File Offset: 0x00047CBC
		public Climb_0_5m()
		{
			this._Category = 5;
			this._Priority = 30f;
			this._ActionAlias = "Jump";
			this._OverrideLayers = true;
			this.mIsStartable = true;
		}

		// Token: 0x06000E4A RID: 3658 RVA: 0x00049B50 File Offset: 0x00047D50
		public Climb_0_5m(MotionController rController)
			: base(rController)
		{
			this._Category = 5;
			this._Priority = 30f;
			this._ActionAlias = "Jump";
			this._OverrideLayers = true;
			this.mIsStartable = true;
		}

		// Token: 0x06000E4B RID: 3659 RVA: 0x00049BE4 File Offset: 0x00047DE4
		public override bool TestActivate()
		{
			return this.mIsStartable && (this.mMotionLayer.ActiveMotion == null || (this.mMotionLayer.ActiveMotion._Category != 5 && this.mMotionLayer.ActiveMotion._Category != 10 && this.mMotionLayer.ActiveMotion._Category != 11)) && this.mMotionController.IsGrounded && this.mMotionController.InputSource != null && ((this._ActionAlias.Length == 0 || this.mMotionController._InputSource.IsJustPressed(this._ActionAlias)) && this.TestForClimbUp());
		}

		// Token: 0x06000E4C RID: 3660 RVA: 0x00049C94 File Offset: 0x00047E94
		public override bool TestUpdate()
		{
			if (this.mIsAnimatorActive && !this.IsInMotionState)
			{
				this.mActorController.IsGravityEnabled = true;
				this.mActorController.ForceGrounding = true;
				this.mActorController.IsCollsionEnabled = true;
				this.mActorController.FixGroundPenetration = true;
				this.mActorController.SetGround(null);
				return false;
			}
			return true;
		}

		// Token: 0x06000E4D RID: 3661 RVA: 0x00049CF0 File Offset: 0x00047EF0
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			if (this.mRaycastHitInfo.collider == null)
			{
				return false;
			}
			this.mIsExitTriggered = false;
			this.mClimbable = this.mRaycastHitInfo.collider.gameObject;
			Vector3 vector = Quaternion.AngleAxis(180f, this.mActorController._Transform.up) * this.mRaycastHitInfo.normal;
			this.mFaceClimbableNormalAngle = this.mActorController._Transform.forward.HorizontalAngleTo(vector, this.mActorController._Transform.up);
			this.mFaceClimbableNormalAngleUsed = 0f;
			this.ClearReachData();
			MotionReachData motionReachData = MotionReachData.Allocate();
			motionReachData.StateID = Climb_0_5m.STATE_IdleClimbMid;
			motionReachData.StartTime = 0.2f;
			motionReachData.EndTime = 0.6f;
			motionReachData.Power = 3;
			motionReachData.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.up * this._ReachOffset1 + this.mRaycastHitInfo.normal * this._ReachOffset2;
			motionReachData.ReachTargetGround = this.mActorController.State.Ground;
			this.mReachData.Add(motionReachData);
			this.mActorController.IsGravityEnabled = false;
			this.mActorController.ForceGrounding = false;
			this.mActorController.FixGroundPenetration = false;
			this.mActorController.SetGround(this.mClimbable.transform);
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 900, true);
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000E4E RID: 3662 RVA: 0x00049E90 File Offset: 0x00048090
		public override void Deactivate()
		{
			this.mClimbable = null;
			this.mActorController.IsGravityEnabled = true;
			this.mActorController.ForceGrounding = true;
			this.mActorController.IsCollsionEnabled = true;
			this.mActorController.FixGroundPenetration = true;
			this.mActorController.SetGround(null);
			base.Deactivate();
		}

		// Token: 0x06000E4F RID: 3663 RVA: 0x00049EE6 File Offset: 0x000480E6
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rVelocityDelta, ref Quaternion rRotationDelta)
		{
			rRotationDelta = Quaternion.identity;
		}

		// Token: 0x06000E50 RID: 3664 RVA: 0x00049EF4 File Offset: 0x000480F4
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mVelocity = Vector3.zero;
			this.mMovement = Vector3.zero;
			this.mAngularVelocity = Vector3.zero;
			this.mRotation = Quaternion.identity;
			if (this.mClimbable == null)
			{
				return;
			}
			int animatorStateID = this.mMotionLayer._AnimatorStateID;
			float animatorStateNormalizedTime = this.mMotionLayer._AnimatorStateNormalizedTime;
			this.mMovement = this.GetReachMovement();
			if (animatorStateID == Climb_0_5m.STATE_IdleClimbMid)
			{
				this.mRotation = this.GetReachRotation(0.3f, 0.6f, this.mFaceClimbableNormalAngle, ref this.mFaceClimbableNormalAngleUsed);
				if (animatorStateNormalizedTime > 0.6f)
				{
					this.mActorController.IsCollsionEnabled = true;
					return;
				}
				if (animatorStateNormalizedTime > 0f)
				{
					this.mActorController.IsCollsionEnabled = false;
					return;
				}
			}
			else if (animatorStateID == Climb_0_5m.STATE_IdlePose)
			{
				this.Deactivate();
			}
		}

		// Token: 0x06000E51 RID: 3665 RVA: 0x00049FC4 File Offset: 0x000481C4
		public override void OnMessageReceived(IMessage rMessage)
		{
			if (rMessage == null)
			{
				return;
			}
			if (rMessage is NavigationMessage && rMessage.ID == NavigationMessage.MSG_NAVIGATE_CLIMB && !this.mIsActive && this.mMotionController.IsGrounded && this.TestForClimbUp())
			{
				rMessage.Recipient = this;
				rMessage.IsHandled = true;
				this.mMotionController.ActivateMotion(this, 0);
			}
		}

		// Token: 0x06000E52 RID: 3666 RVA: 0x0004A024 File Offset: 0x00048224
		public virtual bool TestForClimbUp()
		{
			if (this.mMotionController._InputSource != null && Mathf.Abs(this.mMotionController._InputSource.InputFromAvatarAngle) > 100f)
			{
				return false;
			}
			if (!RaycastExt.GetForwardEdge(this.mActorController._Transform, this._MaxDistance, this._MaxHeight, this._ClimbableLayers, out this.mRaycastHitInfo))
			{
				return false;
			}
			Vector3 vector = this.mActorController._Transform.InverseTransformPoint(this.mRaycastHitInfo.point);
			return vector.y + this.mActorController.State.GroundSurfaceDistance >= this._MinHeight - 0.01f && vector.z >= this._MinDistance;
		}

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x06000E53 RID: 3667 RVA: 0x0004A0DC File Offset: 0x000482DC
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == Climb_0_5m.STATE_IdleClimbMid || animatorStateID == Climb_0_5m.STATE_ClimbRecoverIdle || animatorStateID == Climb_0_5m.STATE_IdlePose || animatorTransitionID == Climb_0_5m.TRANS_EntryState_IdleClimbMid || animatorTransitionID == Climb_0_5m.TRANS_AnyState_IdleClimbMid || animatorTransitionID == Climb_0_5m.TRANS_IdleClimbMid_ClimbRecoverIdle || animatorTransitionID == Climb_0_5m.TRANS_IdleClimbMid_IdlePose;
			}
		}

		// Token: 0x06000E54 RID: 3668 RVA: 0x0004A148 File Offset: 0x00048348
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == Climb_0_5m.STATE_IdleClimbMid || rStateID == Climb_0_5m.STATE_ClimbRecoverIdle || rStateID == Climb_0_5m.STATE_IdlePose;
		}

		// Token: 0x06000E55 RID: 3669 RVA: 0x0004A16C File Offset: 0x0004836C
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == Climb_0_5m.STATE_IdleClimbMid || rStateID == Climb_0_5m.STATE_ClimbRecoverIdle || rStateID == Climb_0_5m.STATE_IdlePose || rTransitionID == Climb_0_5m.TRANS_EntryState_IdleClimbMid || rTransitionID == Climb_0_5m.TRANS_AnyState_IdleClimbMid || rTransitionID == Climb_0_5m.TRANS_IdleClimbMid_ClimbRecoverIdle || rTransitionID == Climb_0_5m.TRANS_IdleClimbMid_IdlePose;
		}

		// Token: 0x06000E56 RID: 3670 RVA: 0x0004A1C0 File Offset: 0x000483C0
		public override void LoadAnimatorData()
		{
			Climb_0_5m.TRANS_EntryState_IdleClimbMid = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Climb_0_5m-SM.IdleClimbMid");
			Climb_0_5m.TRANS_AnyState_IdleClimbMid = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Climb_0_5m-SM.IdleClimbMid");
			Climb_0_5m.STATE_IdleClimbMid = this.mMotionController.AddAnimatorName("Base Layer.Climb_0_5m-SM.IdleClimbMid");
			Climb_0_5m.TRANS_IdleClimbMid_ClimbRecoverIdle = this.mMotionController.AddAnimatorName("Base Layer.Climb_0_5m-SM.IdleClimbMid -> Base Layer.Climb_0_5m-SM.ClimbRecoverIdle");
			Climb_0_5m.TRANS_IdleClimbMid_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Climb_0_5m-SM.IdleClimbMid -> Base Layer.Climb_0_5m-SM.IdlePose");
			Climb_0_5m.STATE_ClimbRecoverIdle = this.mMotionController.AddAnimatorName("Base Layer.Climb_0_5m-SM.ClimbRecoverIdle");
			Climb_0_5m.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Climb_0_5m-SM.IdlePose");
		}

		// Token: 0x04000863 RID: 2147
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000864 RID: 2148
		public const int PHASE_START = 900;

		// Token: 0x04000865 RID: 2149
		public float _MinDistance = 0.2f;

		// Token: 0x04000866 RID: 2150
		public float _MaxDistance = 0.65f;

		// Token: 0x04000867 RID: 2151
		public float _MinHeight = 0.5f;

		// Token: 0x04000868 RID: 2152
		public float _MaxHeight = 0.8f;

		// Token: 0x04000869 RID: 2153
		public int _ClimbableLayers = 1;

		// Token: 0x0400086A RID: 2154
		public float _ReachOffset1 = 0.02f;

		// Token: 0x0400086B RID: 2155
		public float _ReachOffset2 = -0.05f;

		// Token: 0x0400086C RID: 2156
		protected GameObject mClimbable;

		// Token: 0x0400086D RID: 2157
		protected float mFaceClimbableNormalAngle;

		// Token: 0x0400086E RID: 2158
		protected float mFaceClimbableNormalAngleUsed;

		// Token: 0x0400086F RID: 2159
		protected bool mIsExitTriggered;

		// Token: 0x04000870 RID: 2160
		protected RaycastHit mRaycastHitInfo = RaycastExt.EmptyHitInfo;

		// Token: 0x04000871 RID: 2161
		public static int TRANS_EntryState_IdleClimbMid = -1;

		// Token: 0x04000872 RID: 2162
		public static int TRANS_AnyState_IdleClimbMid = -1;

		// Token: 0x04000873 RID: 2163
		public static int STATE_IdleClimbMid = -1;

		// Token: 0x04000874 RID: 2164
		public static int TRANS_IdleClimbMid_ClimbRecoverIdle = -1;

		// Token: 0x04000875 RID: 2165
		public static int TRANS_IdleClimbMid_IdlePose = -1;

		// Token: 0x04000876 RID: 2166
		public static int STATE_ClimbRecoverIdle = -1;

		// Token: 0x04000877 RID: 2167
		public static int STATE_IdlePose = -1;
	}
}
