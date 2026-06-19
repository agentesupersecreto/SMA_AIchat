using System;
using com.ootii.Actors.Navigation;
using com.ootii.Geometry;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000FC RID: 252
	[MotionName("Climb 1.0 Meters")]
	[MotionDescription("Allows for getting ontop of an object that's roughly 1 meter high.")]
	public class Climb_1m : MotionControllerMotion
	{
		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x06000E58 RID: 3672 RVA: 0x0004A28C File Offset: 0x0004848C
		// (set) Token: 0x06000E59 RID: 3673 RVA: 0x0004A294 File Offset: 0x00048494
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

		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x06000E5A RID: 3674 RVA: 0x0004A29D File Offset: 0x0004849D
		// (set) Token: 0x06000E5B RID: 3675 RVA: 0x0004A2A5 File Offset: 0x000484A5
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

		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x06000E5C RID: 3676 RVA: 0x0004A2AE File Offset: 0x000484AE
		// (set) Token: 0x06000E5D RID: 3677 RVA: 0x0004A2B6 File Offset: 0x000484B6
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

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x06000E5E RID: 3678 RVA: 0x0004A2BF File Offset: 0x000484BF
		// (set) Token: 0x06000E5F RID: 3679 RVA: 0x0004A2C7 File Offset: 0x000484C7
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

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x06000E60 RID: 3680 RVA: 0x0004A2D0 File Offset: 0x000484D0
		// (set) Token: 0x06000E61 RID: 3681 RVA: 0x0004A2D8 File Offset: 0x000484D8
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

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x06000E62 RID: 3682 RVA: 0x0004A2E1 File Offset: 0x000484E1
		// (set) Token: 0x06000E63 RID: 3683 RVA: 0x0004A2E9 File Offset: 0x000484E9
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

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x06000E64 RID: 3684 RVA: 0x0004A2F2 File Offset: 0x000484F2
		// (set) Token: 0x06000E65 RID: 3685 RVA: 0x0004A2FA File Offset: 0x000484FA
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

		// Token: 0x06000E66 RID: 3686 RVA: 0x0004A304 File Offset: 0x00048504
		public Climb_1m()
		{
			this._Category = 5;
			this._Priority = 30f;
			this._ActionAlias = "Jump";
			this._OverrideLayers = true;
			this.mIsStartable = true;
		}

		// Token: 0x06000E67 RID: 3687 RVA: 0x0004A398 File Offset: 0x00048598
		public Climb_1m(MotionController rController)
			: base(rController)
		{
			this._Category = 5;
			this._Priority = 30f;
			this._ActionAlias = "Jump";
			this._OverrideLayers = true;
			this.mIsStartable = true;
		}

		// Token: 0x06000E68 RID: 3688 RVA: 0x0004A42C File Offset: 0x0004862C
		public override bool TestActivate()
		{
			return this.mIsStartable && (this.mMotionLayer.ActiveMotion == null || (this.mMotionLayer.ActiveMotion._Category != 5 && this.mMotionLayer.ActiveMotion._Category != 10 && this.mMotionLayer.ActiveMotion._Category != 11)) && this.mMotionController.IsGrounded && this.mMotionController.InputSource != null && ((this._ActionAlias.Length == 0 || this.mMotionController._InputSource.IsJustPressed(this._ActionAlias)) && this.TestForClimbUp());
		}

		// Token: 0x06000E69 RID: 3689 RVA: 0x0004A4DC File Offset: 0x000486DC
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

		// Token: 0x06000E6A RID: 3690 RVA: 0x0004A538 File Offset: 0x00048738
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
			motionReachData.StateID = Climb_1m.STATE_Climb_1m;
			motionReachData.StartTime = 0.1f;
			motionReachData.EndTime = 0.2f;
			motionReachData.Power = 3;
			motionReachData.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.up * this._ReachOffset1 + this.mRaycastHitInfo.normal * this._ReachOffset2;
			motionReachData.ReachTargetGround = this.mActorController.State.Ground;
			this.mReachData.Add(motionReachData);
			this.mActorController.IsGravityEnabled = false;
			this.mActorController.ForceGrounding = false;
			this.mActorController.FixGroundPenetration = false;
			this.mActorController.SetGround(this.mClimbable.transform);
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 950, true);
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000E6B RID: 3691 RVA: 0x0004A6D8 File Offset: 0x000488D8
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

		// Token: 0x06000E6C RID: 3692 RVA: 0x0004A72E File Offset: 0x0004892E
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rVelocityDelta, ref Quaternion rRotationDelta)
		{
			rRotationDelta = Quaternion.identity;
		}

		// Token: 0x06000E6D RID: 3693 RVA: 0x0004A73C File Offset: 0x0004893C
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
			if (animatorStateID == Climb_1m.STATE_IdleStart)
			{
				this.mRotation = this.GetReachRotation(0.6f, 0.9f, this.mFaceClimbableNormalAngle, ref this.mFaceClimbableNormalAngleUsed);
				this.mActorController.IsCollsionEnabled = false;
				return;
			}
			if (animatorStateID == Climb_1m.STATE_Climb_1m)
			{
				this.mRotation = this.GetReachRotation(0.4f, 0.55f, this.mFaceClimbableNormalAngle, ref this.mFaceClimbableNormalAngleUsed);
				if (animatorStateNormalizedTime > 2f)
				{
					this.mActorController.IsCollsionEnabled = true;
					return;
				}
			}
			else if (animatorStateID == Climb_1m.STATE_IdlePose)
			{
				this.Deactivate();
			}
		}

		// Token: 0x06000E6E RID: 3694 RVA: 0x0004A82C File Offset: 0x00048A2C
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

		// Token: 0x06000E6F RID: 3695 RVA: 0x0004A88C File Offset: 0x00048A8C
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

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x06000E70 RID: 3696 RVA: 0x0004A944 File Offset: 0x00048B44
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == Climb_1m.STATE_IdlePose || animatorStateID == Climb_1m.STATE_Climb_1m || animatorStateID == Climb_1m.STATE_IdleStart || animatorTransitionID == Climb_1m.TRANS_EntryState_IdleStart || animatorTransitionID == Climb_1m.TRANS_AnyState_IdleStart || animatorTransitionID == Climb_1m.TRANS_Climb_1m_IdlePose || animatorTransitionID == Climb_1m.TRANS_IdleStart_Climb_1m;
			}
		}

		// Token: 0x06000E71 RID: 3697 RVA: 0x0004A9B0 File Offset: 0x00048BB0
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == Climb_1m.STATE_IdlePose || rStateID == Climb_1m.STATE_Climb_1m || rStateID == Climb_1m.STATE_IdleStart;
		}

		// Token: 0x06000E72 RID: 3698 RVA: 0x0004A9D4 File Offset: 0x00048BD4
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == Climb_1m.STATE_IdlePose || rStateID == Climb_1m.STATE_Climb_1m || rStateID == Climb_1m.STATE_IdleStart || rTransitionID == Climb_1m.TRANS_EntryState_IdleStart || rTransitionID == Climb_1m.TRANS_AnyState_IdleStart || rTransitionID == Climb_1m.TRANS_Climb_1m_IdlePose || rTransitionID == Climb_1m.TRANS_IdleStart_Climb_1m;
		}

		// Token: 0x06000E73 RID: 3699 RVA: 0x0004AA28 File Offset: 0x00048C28
		public override void LoadAnimatorData()
		{
			Climb_1m.TRANS_EntryState_IdleStart = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Climb_1m-SM.IdleStart");
			Climb_1m.TRANS_AnyState_IdleStart = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Climb_1m-SM.IdleStart");
			Climb_1m.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Climb_1m-SM.IdlePose");
			Climb_1m.STATE_Climb_1m = this.mMotionController.AddAnimatorName("Base Layer.Climb_1m-SM.Climb_1m");
			Climb_1m.TRANS_Climb_1m_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Climb_1m-SM.Climb_1m -> Base Layer.Climb_1m-SM.IdlePose");
			Climb_1m.STATE_IdleStart = this.mMotionController.AddAnimatorName("Base Layer.Climb_1m-SM.IdleStart");
			Climb_1m.TRANS_IdleStart_Climb_1m = this.mMotionController.AddAnimatorName("Base Layer.Climb_1m-SM.IdleStart -> Base Layer.Climb_1m-SM.Climb_1m");
		}

		// Token: 0x04000878 RID: 2168
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000879 RID: 2169
		public const int PHASE_START = 950;

		// Token: 0x0400087A RID: 2170
		public float _MinDistance = 0.2f;

		// Token: 0x0400087B RID: 2171
		public float _MaxDistance = 0.825f;

		// Token: 0x0400087C RID: 2172
		public float _MinHeight = 0.8f;

		// Token: 0x0400087D RID: 2173
		public float _MaxHeight = 1.4f;

		// Token: 0x0400087E RID: 2174
		public int _ClimbableLayers = 1;

		// Token: 0x0400087F RID: 2175
		public float _ReachOffset1 = 0.02f;

		// Token: 0x04000880 RID: 2176
		public float _ReachOffset2 = -0.1f;

		// Token: 0x04000881 RID: 2177
		protected GameObject mClimbable;

		// Token: 0x04000882 RID: 2178
		protected float mFaceClimbableNormalAngle;

		// Token: 0x04000883 RID: 2179
		protected float mFaceClimbableNormalAngleUsed;

		// Token: 0x04000884 RID: 2180
		protected bool mIsExitTriggered;

		// Token: 0x04000885 RID: 2181
		protected RaycastHit mRaycastHitInfo = RaycastExt.EmptyHitInfo;

		// Token: 0x04000886 RID: 2182
		public static int TRANS_EntryState_IdleStart = -1;

		// Token: 0x04000887 RID: 2183
		public static int TRANS_AnyState_IdleStart = -1;

		// Token: 0x04000888 RID: 2184
		public static int STATE_IdlePose = -1;

		// Token: 0x04000889 RID: 2185
		public static int STATE_Climb_1m = -1;

		// Token: 0x0400088A RID: 2186
		public static int TRANS_Climb_1m_IdlePose = -1;

		// Token: 0x0400088B RID: 2187
		public static int STATE_IdleStart = -1;

		// Token: 0x0400088C RID: 2188
		public static int TRANS_IdleStart_Climb_1m = -1;
	}
}
