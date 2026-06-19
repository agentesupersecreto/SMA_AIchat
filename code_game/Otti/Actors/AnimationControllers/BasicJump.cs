using System;
using com.ootii.Actors.Navigation;
using com.ootii.Geometry;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000F4 RID: 244
	[MotionName("Basic Jump")]
	[MotionDescription("Simple jump motion that can be expanded.")]
	public class BasicJump : MotionControllerMotion
	{
		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06000D33 RID: 3379 RVA: 0x00041345 File Offset: 0x0003F545
		public override bool VerifyTransition
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06000D34 RID: 3380 RVA: 0x00041348 File Offset: 0x0003F548
		// (set) Token: 0x06000D35 RID: 3381 RVA: 0x00041350 File Offset: 0x0003F550
		public bool IsMomentumEnabled
		{
			get
			{
				return this._IsMomentumEnabled;
			}
			set
			{
				this._IsMomentumEnabled = value;
			}
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06000D36 RID: 3382 RVA: 0x00041359 File Offset: 0x0003F559
		// (set) Token: 0x06000D37 RID: 3383 RVA: 0x00041361 File Offset: 0x0003F561
		public bool IsControlEnabled
		{
			get
			{
				return this._IsControlEnabled;
			}
			set
			{
				this._IsControlEnabled = value;
			}
		}

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x06000D38 RID: 3384 RVA: 0x0004136A File Offset: 0x0003F56A
		// (set) Token: 0x06000D39 RID: 3385 RVA: 0x00041372 File Offset: 0x0003F572
		public float ControlSpeed
		{
			get
			{
				return this._ControlSpeed;
			}
			set
			{
				this._ControlSpeed = value;
			}
		}

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x06000D3A RID: 3386 RVA: 0x0004137B File Offset: 0x0003F57B
		// (set) Token: 0x06000D3B RID: 3387 RVA: 0x00041383 File Offset: 0x0003F583
		public bool AllowSliding
		{
			get
			{
				return this._AllowSliding;
			}
			set
			{
				this._AllowSliding = value;
			}
		}

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06000D3C RID: 3388 RVA: 0x0004138C File Offset: 0x0003F58C
		// (set) Token: 0x06000D3D RID: 3389 RVA: 0x00041394 File Offset: 0x0003F594
		public float RequiredOverheadDistance
		{
			get
			{
				return this._RequiredOverheadDistance;
			}
			set
			{
				this._RequiredOverheadDistance = value;
			}
		}

		// Token: 0x06000D3E RID: 3390 RVA: 0x000413A0 File Offset: 0x0003F5A0
		public BasicJump()
		{
			this._Category = 4;
			this._Priority = 15f;
			this._ActionAlias = "Jump";
		}

		// Token: 0x06000D3F RID: 3391 RVA: 0x00041454 File Offset: 0x0003F654
		public BasicJump(MotionController rController)
			: base(rController)
		{
			this._Category = 4;
			this._Priority = 15f;
			this._ActionAlias = "Jump";
		}

		// Token: 0x06000D40 RID: 3392 RVA: 0x00041509 File Offset: 0x0003F709
		public override void Awake()
		{
			base.Awake();
		}

		// Token: 0x06000D41 RID: 3393 RVA: 0x00041514 File Offset: 0x0003F714
		public override bool TestActivate()
		{
			if (!this.mIsStartable)
			{
				return false;
			}
			if (this.mActorController.UseTransformPosition)
			{
				return !this.mActorController.IsGrounded && Vector3.Dot(Vector3.Project(this.mActorController.State.Velocity, this.mActorController._Transform.up), this.mActorController._Transform.up) > 0f && (this.mMotionLayer.ActiveMotion == null || this.mMotionLayer.ActiveMotion.Category != 5);
			}
			return this.mActorController.IsGrounded && this._ActionAlias.Length != 0 && this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias) && (this._RequiredOverheadDistance <= 0f || !RaycastExt.SafeRaycast(this.mActorController._Transform.position, this.mActorController._Transform.up, this._RequiredOverheadDistance, this.mActorController._CollisionLayers, this.mActorController._Transform, null, true));
		}

		// Token: 0x06000D42 RID: 3394 RVA: 0x00041644 File Offset: 0x0003F844
		public override bool TestUpdate()
		{
			return this.mIsActivatedFrame || !this.mMotionController.State.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].StateInfo.IsTag("Exit");
		}

		// Token: 0x06000D43 RID: 3395 RVA: 0x00041684 File Offset: 0x0003F884
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			return (!(rMotion is Fall) || this.mActorController.State.GroundSurfaceDistance >= 1f) && base.TestInterruption(rMotion);
		}

		// Token: 0x06000D44 RID: 3396 RVA: 0x000416B0 File Offset: 0x0003F8B0
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mStoreIsGravityEnabled = this.mActorController.IsGravityEnabled;
			this.mActorController.IsGravityEnabled = false;
			this.mStoreForcedGrounding = this.mActorController.ForceGrounding;
			this.mActorController.ForceGrounding = false;
			this.mHasLeftGround = false;
			this.mLaunchForward = this.mActorController._Transform.forward;
			this.mLaunchVelocity = this.mActorController.State.Velocity;
			this.mActiveForm = ((this._Form > 0) ? this._Form : this.mMotionController.CurrentForm);
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, this.PHASE_START, this.mActiveForm, this.mParameter, true);
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000D45 RID: 3397 RVA: 0x0004177C File Offset: 0x0003F97C
		public override void Deactivate()
		{
			this.mActorController.IsGravityEnabled = this.mStoreIsGravityEnabled;
			this.mActorController.ForceGrounding = this.mStoreForcedGrounding;
			base.Deactivate();
		}

		// Token: 0x06000D46 RID: 3398 RVA: 0x000417A6 File Offset: 0x0003F9A6
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
		}

		// Token: 0x06000D47 RID: 3399 RVA: 0x000417A8 File Offset: 0x0003F9A8
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			if (!this.mHasLeftGround && this.mActorController.State.GroundSurfaceDistance > 0.1f)
			{
				this.mHasLeftGround = true;
			}
			this.mVelocity = this.DetermineVelocity(this._AllowSliding);
			if (this.mHasLeftGround && this.mActorController.State.GroundSurfaceDistance < 0.1f)
			{
				this.mActorController.IsGravityEnabled = this.mStoreIsGravityEnabled;
				this.mActorController.ForceGrounding = this.mStoreForcedGrounding;
			}
		}

		// Token: 0x06000D48 RID: 3400 RVA: 0x00041830 File Offset: 0x0003FA30
		public override void OnMessageReceived(IMessage rMessage)
		{
			if (rMessage == null)
			{
				return;
			}
			if (rMessage is NavigationMessage && rMessage.ID == NavigationMessage.MSG_NAVIGATE_JUMP && !this.mIsActive && this.mMotionController.IsGrounded && this.mActorController.State.Velocity.magnitude < 5f)
			{
				rMessage.Recipient = this;
				rMessage.IsHandled = true;
				this.mMotionController.ActivateMotion(this, 0);
			}
		}

		// Token: 0x06000D49 RID: 3401 RVA: 0x000418A4 File Offset: 0x0003FAA4
		protected Vector3 DetermineVelocity(bool rAllowSlide)
		{
			Vector3 vector = Vector3.zero;
			if (this.mActorController.State.IsColliding)
			{
				return vector;
			}
			if (!rAllowSlide && this.mActorController.State.IsGrounded)
			{
				return vector;
			}
			MotionState state = this.mMotionController.State;
			Vector3 vector2 = this.mLaunchVelocity;
			float num = (this._IsMomentumEnabled ? vector2.magnitude : 0f);
			float num2 = (this._IsControlEnabled ? (this._ControlSpeed * state.InputMagnitudeTrend.Value) : 0f);
			float num3 = Mathf.Max(num, num2);
			if (this._IsControlEnabled)
			{
				Vector3 vector3 = this.mActorController._Transform.forward;
				if (this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsEnabled && this.mMotionController._CameraTransform != null)
				{
					vector3 = this.mMotionController._CameraTransform.forward;
				}
				Vector3 vector4 = Quaternion.LookRotation(vector3, this.mActorController._Transform.up) * state.InputForward;
				vector += vector4 * num3;
			}
			if (this._IsMomentumEnabled)
			{
				vector += vector2;
			}
			if (vector.magnitude > num3)
			{
				vector = vector.normalized * num3;
			}
			return vector;
		}

		// Token: 0x06000D4A RID: 3402 RVA: 0x000419F6 File Offset: 0x0003FBF6
		public static string GroupName()
		{
			return "Basic";
		}

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06000D4B RID: 3403 RVA: 0x000419FD File Offset: 0x0003FBFD
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x06000D4C RID: 3404 RVA: 0x00041A00 File Offset: 0x0003FC00
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				if (animatorTransitionID == 0)
				{
					if (animatorStateID == this.STATE_Start)
					{
						return true;
					}
					if (animatorStateID == this.STATE_UnarmedJump)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdlePose)
					{
						return true;
					}
				}
				return animatorTransitionID == this.TRANS_AnyState_UnarmedJump || animatorTransitionID == this.TRANS_EntryState_UnarmedJump || animatorTransitionID == this.TRANS_UnarmedJump_IdlePose;
			}
		}

		// Token: 0x06000D4D RID: 3405 RVA: 0x00041A6B File Offset: 0x0003FC6B
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == this.STATE_Start || rStateID == this.STATE_UnarmedJump || rStateID == this.STATE_IdlePose;
		}

		// Token: 0x06000D4E RID: 3406 RVA: 0x00041A90 File Offset: 0x0003FC90
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			if (rTransitionID == 0)
			{
				if (rStateID == this.STATE_Start)
				{
					return true;
				}
				if (rStateID == this.STATE_UnarmedJump)
				{
					return true;
				}
				if (rStateID == this.STATE_IdlePose)
				{
					return true;
				}
			}
			return rTransitionID == this.TRANS_AnyState_UnarmedJump || rTransitionID == this.TRANS_EntryState_UnarmedJump || rTransitionID == this.TRANS_UnarmedJump_IdlePose;
		}

		// Token: 0x06000D4F RID: 3407 RVA: 0x00041AE4 File Offset: 0x0003FCE4
		public override void LoadAnimatorData()
		{
			string layerName = this.mMotionController.Animator.GetLayerName(this.mMotionLayer._AnimatorLayerIndex);
			this.TRANS_AnyState_UnarmedJump = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".BasicJump-SM.Unarmed Jump");
			this.TRANS_EntryState_UnarmedJump = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".BasicJump-SM.Unarmed Jump");
			this.STATE_Start = this.mMotionController.AddAnimatorName(layerName + ".Start");
			this.STATE_UnarmedJump = this.mMotionController.AddAnimatorName(layerName + ".BasicJump-SM.Unarmed Jump");
			this.TRANS_UnarmedJump_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".BasicJump-SM.Unarmed Jump -> " + layerName + ".BasicJump-SM.IdlePose");
			this.STATE_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".BasicJump-SM.IdlePose");
		}

		// Token: 0x0400074D RID: 1869
		public int PHASE_UNKNOWN;

		// Token: 0x0400074E RID: 1870
		public int PHASE_START = 3400;

		// Token: 0x0400074F RID: 1871
		public bool _IsMomentumEnabled = true;

		// Token: 0x04000750 RID: 1872
		public bool _IsControlEnabled = true;

		// Token: 0x04000751 RID: 1873
		public float _ControlSpeed = 2f;

		// Token: 0x04000752 RID: 1874
		public bool _AllowSliding = true;

		// Token: 0x04000753 RID: 1875
		public float _RequiredOverheadDistance = 0.5f;

		// Token: 0x04000754 RID: 1876
		protected int mActiveForm;

		// Token: 0x04000755 RID: 1877
		protected Vector3 mLaunchForward = Vector3.zero;

		// Token: 0x04000756 RID: 1878
		protected Vector3 mLaunchVelocity = Vector3.zero;

		// Token: 0x04000757 RID: 1879
		protected bool mHasLeftGround;

		// Token: 0x04000758 RID: 1880
		protected bool mStoreIsGravityEnabled = true;

		// Token: 0x04000759 RID: 1881
		protected bool mStoreForcedGrounding = true;

		// Token: 0x0400075A RID: 1882
		public int STATE_Start = -1;

		// Token: 0x0400075B RID: 1883
		public int STATE_UnarmedJump = -1;

		// Token: 0x0400075C RID: 1884
		public int STATE_IdlePose = -1;

		// Token: 0x0400075D RID: 1885
		public int TRANS_AnyState_UnarmedJump = -1;

		// Token: 0x0400075E RID: 1886
		public int TRANS_EntryState_UnarmedJump = -1;

		// Token: 0x0400075F RID: 1887
		public int TRANS_UnarmedJump_IdlePose = -1;
	}
}
