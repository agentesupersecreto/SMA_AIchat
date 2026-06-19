using System;
using com.ootii.Actors.Navigation;
using com.ootii.Geometry;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000FD RID: 253
	[MotionName("Climb 1.8 Meters")]
	[MotionDescription("Scaling climb that allows the actor to go up a 1.8m high wall.")]
	public class Climb_1_8m : MotionControllerMotion
	{
		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x06000E75 RID: 3701 RVA: 0x0004AAF4 File Offset: 0x00048CF4
		// (set) Token: 0x06000E76 RID: 3702 RVA: 0x0004AAFC File Offset: 0x00048CFC
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

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x06000E77 RID: 3703 RVA: 0x0004AB05 File Offset: 0x00048D05
		// (set) Token: 0x06000E78 RID: 3704 RVA: 0x0004AB0D File Offset: 0x00048D0D
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

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x06000E79 RID: 3705 RVA: 0x0004AB16 File Offset: 0x00048D16
		// (set) Token: 0x06000E7A RID: 3706 RVA: 0x0004AB1E File Offset: 0x00048D1E
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

		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x06000E7B RID: 3707 RVA: 0x0004AB27 File Offset: 0x00048D27
		// (set) Token: 0x06000E7C RID: 3708 RVA: 0x0004AB2F File Offset: 0x00048D2F
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

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x06000E7D RID: 3709 RVA: 0x0004AB38 File Offset: 0x00048D38
		// (set) Token: 0x06000E7E RID: 3710 RVA: 0x0004AB40 File Offset: 0x00048D40
		public float HandGrabOffset
		{
			get
			{
				return this._HandGrabOffset;
			}
			set
			{
				this._HandGrabOffset = value;
			}
		}

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x06000E7F RID: 3711 RVA: 0x0004AB49 File Offset: 0x00048D49
		// (set) Token: 0x06000E80 RID: 3712 RVA: 0x0004AB51 File Offset: 0x00048D51
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

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x06000E81 RID: 3713 RVA: 0x0004AB5A File Offset: 0x00048D5A
		// (set) Token: 0x06000E82 RID: 3714 RVA: 0x0004AB62 File Offset: 0x00048D62
		public Vector3 ReachOffset1
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

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x06000E83 RID: 3715 RVA: 0x0004AB6B File Offset: 0x00048D6B
		// (set) Token: 0x06000E84 RID: 3716 RVA: 0x0004AB73 File Offset: 0x00048D73
		public Vector3 ReachOffset2
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

		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06000E85 RID: 3717 RVA: 0x0004AB7C File Offset: 0x00048D7C
		// (set) Token: 0x06000E86 RID: 3718 RVA: 0x0004AB84 File Offset: 0x00048D84
		public Vector3 ReachOffset3
		{
			get
			{
				return this._ReachOffset3;
			}
			set
			{
				this._ReachOffset3 = value;
			}
		}

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x06000E87 RID: 3719 RVA: 0x0004AB8D File Offset: 0x00048D8D
		// (set) Token: 0x06000E88 RID: 3720 RVA: 0x0004AB95 File Offset: 0x00048D95
		public Vector3 ReachOffset4
		{
			get
			{
				return this._ReachOffset4;
			}
			set
			{
				this._ReachOffset4 = value;
			}
		}

		// Token: 0x06000E89 RID: 3721 RVA: 0x0004ABA0 File Offset: 0x00048DA0
		public Climb_1_8m()
		{
			this._Category = 5;
			this._Priority = 30f;
			this._ActionAlias = "Jump";
			this._OverrideLayers = true;
			this.mIsStartable = true;
		}

		// Token: 0x06000E8A RID: 3722 RVA: 0x0004AC9C File Offset: 0x00048E9C
		public Climb_1_8m(MotionController rController)
			: base(rController)
		{
			this._Category = 5;
			this._Priority = 30f;
			this._ActionAlias = "Jump";
			this._OverrideLayers = true;
			this.mIsStartable = true;
		}

		// Token: 0x06000E8B RID: 3723 RVA: 0x0004AD98 File Offset: 0x00048F98
		public override bool TestActivate()
		{
			if (!this.mIsStartable)
			{
				return false;
			}
			if (this.mMotionLayer.ActiveMotion != null && (this.mMotionLayer.ActiveMotion._Category == 5 || this.mMotionLayer.ActiveMotion._Category == 10 || this.mMotionLayer.ActiveMotion._Category == 11))
			{
				return false;
			}
			if (!this.mMotionController.IsGrounded)
			{
				return false;
			}
			if (this.mMotionController.InputSource == null)
			{
				return false;
			}
			bool flag = false;
			if (this._ActionAlias.Length == 0 || this.mMotionController.InputSource.IsJustPressed(this._ActionAlias))
			{
				flag = this.TestForClimbUp();
			}
			return flag;
		}

		// Token: 0x06000E8C RID: 3724 RVA: 0x0004AE48 File Offset: 0x00049048
		public override bool TestUpdate()
		{
			if ((this.mIsAnimatorActive && !this.IsInMotionState) || this.mMotionLayer._AnimatorStateID == Climb_1_8m.STATE_IdlePose)
			{
				this.mActorController.IsGravityEnabled = true;
				this.mActorController.ForceGrounding = true;
				this.mActorController.FixGroundPenetration = true;
				this.mActorController.SetGround(null);
				return false;
			}
			return true;
		}

		// Token: 0x06000E8D RID: 3725 RVA: 0x0004AEAC File Offset: 0x000490AC
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			if (this.mRaycastHitInfo.collider == null)
			{
				return false;
			}
			this.mStartPosition = this.mActorController._Transform.position;
			this.mClimbable = this.mRaycastHitInfo.collider.gameObject;
			this.mActorController.IsGravityEnabled = false;
			this.mActorController.ForceGrounding = false;
			this.mActorController.FixGroundPenetration = false;
			this.mActorController.SetGround(this.mClimbable.transform);
			Vector3 vector = Quaternion.AngleAxis(180f, this.mActorController._Transform.up) * this.mRaycastHitInfo.normal;
			this.mFaceClimbableNormalAngle = this.mActorController._Transform.forward.HorizontalAngleTo(vector, this.mActorController._Transform.up);
			this.mFaceClimbableNormalAngleUsed = 0f;
			this.ClearReachData();
			Quaternion rotation = this.mActorController._Transform.rotation;
			MotionReachData motionReachData = MotionReachData.Allocate();
			motionReachData.StateID = Climb_1_8m.STATE_LegUpToIdle;
			motionReachData.StartTime = 0f;
			motionReachData.EndTime = 0.224f;
			motionReachData.Power = 2;
			motionReachData.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.rotation * this._ReachOffset1 + rotation * this._ReachOffset2;
			motionReachData.ReachTargetGround = this.mActorController.State.Ground;
			this.mReachData.Add(motionReachData);
			motionReachData = MotionReachData.Allocate();
			motionReachData.StateID = Climb_1_8m.STATE_LegUpToIdle;
			motionReachData.StartTime = 0.35f;
			motionReachData.EndTime = 0.425f;
			motionReachData.Power = 4;
			motionReachData.ReachTarget = this.mRaycastHitInfo.point + rotation * this._ReachOffset3;
			motionReachData.ReachTargetGround = this.mActorController.State.Ground;
			this.mReachData.Add(motionReachData);
			motionReachData = MotionReachData.Allocate();
			motionReachData.StateID = Climb_1_8m.STATE_LegUpToIdle;
			motionReachData.StartTime = 0.625f;
			motionReachData.EndTime = 0.725f;
			motionReachData.Power = 4;
			motionReachData.ReachTarget = this.mRaycastHitInfo.point + rotation * this._ReachOffset4;
			motionReachData.ReachTargetGround = this.mActorController.State.Ground;
			this.mReachData.Add(motionReachData);
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 1250, true);
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000E8E RID: 3726 RVA: 0x0004B148 File Offset: 0x00049348
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

		// Token: 0x06000E8F RID: 3727 RVA: 0x0004B19E File Offset: 0x0004939E
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rVelocityDelta, ref Quaternion rRotationDelta)
		{
			rRotationDelta = Quaternion.identity;
		}

		// Token: 0x06000E90 RID: 3728 RVA: 0x0004B1AC File Offset: 0x000493AC
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
			if (animatorStateID == Climb_1_8m.STATE_LegUpToIdle)
			{
				this.mRotation = this.GetReachRotation(0.4f, 0.55f, this.mFaceClimbableNormalAngle, ref this.mFaceClimbableNormalAngleUsed);
				if (animatorStateNormalizedTime > 0.6f)
				{
					this.mActorController.IsCollsionEnabled = true;
					return;
				}
				if (animatorStateNormalizedTime > 0.3f)
				{
					this.mActorController.IsCollsionEnabled = false;
				}
			}
		}

		// Token: 0x06000E91 RID: 3729 RVA: 0x0004B26C File Offset: 0x0004946C
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

		// Token: 0x06000E92 RID: 3730 RVA: 0x0004B2CC File Offset: 0x000494CC
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
			if (vector.y + this.mActorController.State.GroundSurfaceDistance < this._MinHeight - 0.01f)
			{
				return false;
			}
			if (vector.z < this._MinDistance)
			{
				return false;
			}
			if (this._HandGrabOffset > 0f)
			{
				RaycastHit raycastHit;
				if (!RaycastExt.SafeRaycast(this.mRaycastHitInfo.point + this.mRaycastHitInfo.normal * 1f + this.mActorController._Transform.rotation * new Vector3(this._HandGrabOffset, 0f, 0f), -this.mRaycastHitInfo.normal, out raycastHit, 1.1f, this._ClimbableLayers, this.mActorController._Transform, null, true, false))
				{
					return false;
				}
				if (!RaycastExt.SafeRaycast(this.mRaycastHitInfo.point + this.mRaycastHitInfo.normal * 1f + this.mActorController._Transform.rotation * new Vector3(-this._HandGrabOffset, 0f, 0f), -this.mRaycastHitInfo.normal, out raycastHit, 1.1f, this._ClimbableLayers, this.mActorController._Transform, null, true, false))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x06000E93 RID: 3731 RVA: 0x0004B4A8 File Offset: 0x000496A8
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == Climb_1_8m.STATE_IdlePose || animatorStateID == Climb_1_8m.STATE_LegUpToIdle || animatorTransitionID == Climb_1_8m.TRANS_EntryState_LegUpToIdle || animatorTransitionID == Climb_1_8m.TRANS_AnyState_LegUpToIdle || animatorTransitionID == Climb_1_8m.TRANS_LegUpToIdle_IdlePose;
			}
		}

		// Token: 0x06000E94 RID: 3732 RVA: 0x0004B500 File Offset: 0x00049700
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == Climb_1_8m.STATE_IdlePose || rStateID == Climb_1_8m.STATE_LegUpToIdle;
		}

		// Token: 0x06000E95 RID: 3733 RVA: 0x0004B517 File Offset: 0x00049717
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == Climb_1_8m.STATE_IdlePose || rStateID == Climb_1_8m.STATE_LegUpToIdle || rTransitionID == Climb_1_8m.TRANS_EntryState_LegUpToIdle || rTransitionID == Climb_1_8m.TRANS_AnyState_LegUpToIdle || rTransitionID == Climb_1_8m.TRANS_LegUpToIdle_IdlePose;
		}

		// Token: 0x06000E96 RID: 3734 RVA: 0x0004B54C File Offset: 0x0004974C
		public override void LoadAnimatorData()
		{
			Climb_1_8m.TRANS_EntryState_LegUpToIdle = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Climb_1_8m-SM.LegUpToIdle");
			Climb_1_8m.TRANS_AnyState_LegUpToIdle = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Climb_1_8m-SM.LegUpToIdle");
			Climb_1_8m.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Climb_1_8m-SM.IdlePose");
			Climb_1_8m.STATE_LegUpToIdle = this.mMotionController.AddAnimatorName("Base Layer.Climb_1_8m-SM.LegUpToIdle");
			Climb_1_8m.TRANS_LegUpToIdle_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Climb_1_8m-SM.LegUpToIdle -> Base Layer.Climb_1_8m-SM.IdlePose");
		}

		// Token: 0x0400088D RID: 2189
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x0400088E RID: 2190
		public const int PHASE_START = 1250;

		// Token: 0x0400088F RID: 2191
		public float _MinDistance = 0.25f;

		// Token: 0x04000890 RID: 2192
		public float _MaxDistance = 0.825f;

		// Token: 0x04000891 RID: 2193
		public float _MinHeight = 1.4f;

		// Token: 0x04000892 RID: 2194
		public float _MaxHeight = 2.4f;

		// Token: 0x04000893 RID: 2195
		public float _HandGrabOffset = 0.13f;

		// Token: 0x04000894 RID: 2196
		public int _ClimbableLayers = 1;

		// Token: 0x04000895 RID: 2197
		public Vector3 _ReachOffset1 = new Vector3(0f, -1.6f, -0.1f);

		// Token: 0x04000896 RID: 2198
		public Vector3 _ReachOffset2 = new Vector3(0f, 0f, -0.5f);

		// Token: 0x04000897 RID: 2199
		public Vector3 _ReachOffset3 = new Vector3(-0.1f, -0.89f, -0.1f);

		// Token: 0x04000898 RID: 2200
		public Vector3 _ReachOffset4 = new Vector3(-0.15f, 0.01f, 0.2f);

		// Token: 0x04000899 RID: 2201
		protected GameObject mClimbable;

		// Token: 0x0400089A RID: 2202
		protected float mFaceClimbableNormalAngle;

		// Token: 0x0400089B RID: 2203
		protected float mFaceClimbableNormalAngleUsed;

		// Token: 0x0400089C RID: 2204
		protected Vector3 mStartPosition = Vector3.zero;

		// Token: 0x0400089D RID: 2205
		protected RaycastHit mRaycastHitInfo = RaycastExt.EmptyHitInfo;

		// Token: 0x0400089E RID: 2206
		public static int TRANS_EntryState_LegUpToIdle = -1;

		// Token: 0x0400089F RID: 2207
		public static int TRANS_AnyState_LegUpToIdle = -1;

		// Token: 0x040008A0 RID: 2208
		public static int STATE_IdlePose = -1;

		// Token: 0x040008A1 RID: 2209
		public static int STATE_LegUpToIdle = -1;

		// Token: 0x040008A2 RID: 2210
		public static int TRANS_LegUpToIdle_IdlePose = -1;
	}
}
