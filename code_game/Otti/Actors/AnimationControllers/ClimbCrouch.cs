using System;
using com.ootii.Geometry;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000F8 RID: 248
	[MotionName("Climb Crouch")]
	[MotionDescription("Allows the avatar to move into a 'cat grab' parkour style position. When jumping or falling the avatar will attempt to grab a ledge. From there, this motions will allow them to move left or right or climb to the top of the ledge.")]
	public class ClimbCrouch : MotionControllerMotion
	{
		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x06000DB9 RID: 3513 RVA: 0x00043C97 File Offset: 0x00041E97
		// (set) Token: 0x06000DBA RID: 3514 RVA: 0x00043C9F File Offset: 0x00041E9F
		public float MinGroundDistance
		{
			get
			{
				return this._MinGroundDistance;
			}
			set
			{
				this._MinGroundDistance = value;
			}
		}

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x06000DBB RID: 3515 RVA: 0x00043CA8 File Offset: 0x00041EA8
		// (set) Token: 0x06000DBC RID: 3516 RVA: 0x00043CB0 File Offset: 0x00041EB0
		public float MinRegrabDistance
		{
			get
			{
				return this._MinRegrabDistance;
			}
			set
			{
				this._MinRegrabDistance = value;
			}
		}

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x06000DBD RID: 3517 RVA: 0x00043CB9 File Offset: 0x00041EB9
		// (set) Token: 0x06000DBE RID: 3518 RVA: 0x00043CC1 File Offset: 0x00041EC1
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

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x06000DBF RID: 3519 RVA: 0x00043CCA File Offset: 0x00041ECA
		// (set) Token: 0x06000DC0 RID: 3520 RVA: 0x00043CD2 File Offset: 0x00041ED2
		public Vector3 BodyTargetOffset
		{
			get
			{
				return this._BodyTargetOffset;
			}
			set
			{
				this._BodyTargetOffset = value;
			}
		}

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x06000DC1 RID: 3521 RVA: 0x00043CDB File Offset: 0x00041EDB
		// (set) Token: 0x06000DC2 RID: 3522 RVA: 0x00043CE3 File Offset: 0x00041EE3
		public Vector3 ExitPositionOffset
		{
			get
			{
				return this._ExitPositionOffset;
			}
			set
			{
				this._ExitPositionOffset = value;
			}
		}

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x06000DC3 RID: 3523 RVA: 0x00043CEC File Offset: 0x00041EEC
		// (set) Token: 0x06000DC4 RID: 3524 RVA: 0x00043CF4 File Offset: 0x00041EF4
		public Vector3 ToTopVelocity
		{
			get
			{
				return this._ToTopVelocity;
			}
			set
			{
				this._ToTopVelocity = value;
			}
		}

		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x06000DC5 RID: 3525 RVA: 0x00043CFD File Offset: 0x00041EFD
		// (set) Token: 0x06000DC6 RID: 3526 RVA: 0x00043D05 File Offset: 0x00041F05
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

		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x06000DC7 RID: 3527 RVA: 0x00043D0E File Offset: 0x00041F0E
		// (set) Token: 0x06000DC8 RID: 3528 RVA: 0x00043D16 File Offset: 0x00041F16
		[MotionDescription("Minimum space required for the avatar to shimmy to the left or right.")]
		public float MinSideSpaceForMove
		{
			get
			{
				return this._MinSideSpaceForMove;
			}
			set
			{
				this._MinSideSpaceForMove = value;
			}
		}

		// Token: 0x06000DC9 RID: 3529 RVA: 0x00043D20 File Offset: 0x00041F20
		public ClimbCrouch()
		{
			this._Category = 5;
			this._Priority = 20f;
			this._ActionAlias = "Jump";
			this._OverrideLayers = true;
			this.mIsStartable = true;
		}

		// Token: 0x06000DCA RID: 3530 RVA: 0x00043E34 File Offset: 0x00042034
		public ClimbCrouch(MotionController rController)
			: base(rController)
		{
			this._Category = 5;
			this._Priority = 20f;
			this._ActionAlias = "Jump";
			this._OverrideLayers = true;
			this.mIsStartable = true;
		}

		// Token: 0x06000DCB RID: 3531 RVA: 0x00043F48 File Offset: 0x00042148
		public override bool TestActivate()
		{
			if (!this.mIsStartable)
			{
				return false;
			}
			bool flag = false;
			if (this.mMotionController.IsGrounded)
			{
				if (this.mGrabPosition.sqrMagnitude > 0f)
				{
					this.mGrabPosition = Vector3.zero;
				}
			}
			else
			{
				if (this.mActorController.State.Velocity.y > 2f)
				{
					this.mGrabMotion = 1;
					flag = this.TestGrab(this.mMotionController.transform.position, this.mMotionController.transform.rotation, this.mMotionController.transform.forward, this.mActorController.BaseRadius, 1.2f, 1.35f);
				}
				else if (this.mActorController.State.Velocity.y > -2f)
				{
					this.mGrabMotion = 2;
					flag = this.TestGrab(this.mMotionController.transform.position, this.mMotionController.transform.rotation, this.mMotionController.transform.forward, this.mActorController.BaseRadius, 1f, 1.2f);
				}
				else
				{
					this.mGrabMotion = 3;
					flag = this.TestGrab(this.mMotionController.transform.position, this.mMotionController.transform.rotation, this.mMotionController.transform.forward, this.mActorController.BaseRadius, 1f, 1.42f);
				}
				if (flag && this.mActorController.State.GroundSurfaceDistance < this._MinGroundDistance)
				{
					flag = false;
				}
			}
			if (flag && Vector3.Distance(this.mRaycastHitInfo.point, this.mGrabPosition) < this._MinRegrabDistance)
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000DCC RID: 3532 RVA: 0x0004410C File Offset: 0x0004230C
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			if (this.mRaycastHitInfo.collider == null)
			{
				return false;
			}
			this.mIsActive = true;
			this.mIsActivatedFrame = true;
			this.mIsStartable = false;
			this.mHasArrived = false;
			this.mArrivalLerp = 0.25f;
			this.mMotionController.AccumulatedVelocity = Vector3.zero;
			this.mStoredStance = this.mActorController.State.Stance;
			this.mActorController.State.Stance = 5;
			MotionState state = this.mMotionController.State;
			if (this.mGrabMotion == 1)
			{
				this.mPhase = 301;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 301, true);
			}
			else if (this.mGrabMotion == 2)
			{
				this.mPhase = 302;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 302, true);
			}
			else if (this.mGrabMotion == 3)
			{
				this.mPhase = 303;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 303, true);
			}
			this.mMotionController.State = state;
			this.mClimbable = this.mRaycastHitInfo.collider.gameObject;
			Vector3 vector = Quaternion.AngleAxis(180f, this.mActorController._Transform.up) * this.mRaycastHitInfo.normal;
			this.mFaceClimbableNormalAngle = this.mActorController._Transform.forward.HorizontalAngleTo(vector, this.mActorController._Transform.up);
			this.mFaceClimbableNormalAngleUsed = 0f;
			this.mActorController.IsGravityEnabled = false;
			this.mActorController.ForceGrounding = false;
			this.mActorController.FixGroundPenetration = false;
			this.mActorController.SetGround(this.mClimbable.transform);
			BodyShape bodyShape = this.mActorController.GetBodyShape("Combatant Shape");
			if (bodyShape != null)
			{
				bodyShape.IsEnabledOnGround = false;
				bodyShape.IsEnabledOnSlope = false;
				bodyShape.IsEnabledAboveGround = false;
			}
			this.mGrabPosition = this.mRaycastHitInfo.point;
			this.mLocalGrabPosition = Quaternion.Inverse(this.mClimbable.transform.rotation) * (this.mRaycastHitInfo.point - this.mClimbable.transform.position);
			this.mGrabPositionNormal = this.mRaycastHitInfo.normal;
			this.mTargetPosition = this.DetermineTargetPositions(ref this.mGrabPosition, ref this.mGrabPositionNormal);
			this.mAvatarContactPosition = Vector3.zero;
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000DCD RID: 3533 RVA: 0x000443A0 File Offset: 0x000425A0
		public override void Deactivate()
		{
			this.mIsActive = false;
			this.mIsStartable = true;
			this.mDeactivationTime = Time.time;
			this.mVelocity = Vector3.zero;
			this.mAngularVelocity = Vector3.zero;
			this.mGrabMotion = 0;
			this.mClimbable = null;
			if (this.mActorController.State.Stance == 5)
			{
				this.mActorController.State.Stance = this.mStoredStance;
			}
			this.mActorController.IsGravityEnabled = true;
			this.mActorController.ForceGrounding = true;
			this.mActorController.IsCollsionEnabled = true;
			this.mActorController.FixGroundPenetration = true;
			this.mActorController.SetGround(null);
			BodyShape bodyShape = this.mActorController.GetBodyShape("Combatant Shape");
			if (bodyShape != null)
			{
				bodyShape.IsEnabledOnGround = true;
				bodyShape.IsEnabledOnSlope = true;
				bodyShape.IsEnabledAboveGround = true;
			}
			if (this.mPhase == 320)
			{
				this.mPhase = 0;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 0);
			}
			base.Deactivate();
		}

		// Token: 0x06000DCE RID: 3534 RVA: 0x000444AC File Offset: 0x000426AC
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rVelocityDelta, ref Quaternion rRotationDelta)
		{
			int animatorStateID = this.mMotionLayer._AnimatorStateID;
			int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
			if (animatorTransitionID == ClimbCrouch.TRANS_EntryState_JumpRiseToClimbCrouch || animatorTransitionID == ClimbCrouch.TRANS_AnyState_JumpRiseToClimbCrouch || animatorStateID == ClimbCrouch.STATE_JumpFallToClimbCrouch || animatorStateID == ClimbCrouch.STATE_JumpTopToClimbCrouch || animatorStateID == ClimbCrouch.STATE_ClimbCrouchRecoverIdle)
			{
				rVelocityDelta.x = 0f;
				rVelocityDelta.z = 0f;
				return;
			}
			if (this.IsInClimbShimmy)
			{
				rVelocityDelta.z = 0f;
				rVelocityDelta.y = 0f;
				return;
			}
			rVelocityDelta.x = 0f;
		}

		// Token: 0x06000DCF RID: 3535 RVA: 0x0004453C File Offset: 0x0004273C
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mVelocity = Vector3.zero;
			this.mMovement = Vector3.zero;
			this.mAngularVelocity = Vector3.zero;
			this.mRotation = Quaternion.identity;
			if (Time.deltaTime == 0f)
			{
				return;
			}
			int animatorStateID = this.mMotionLayer._AnimatorStateID;
			float normalizedTime = this.mMotionController.State.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].StateInfo.normalizedTime;
			if (animatorStateID == ClimbCrouch.STATE_IdleToClimbCrouch || animatorStateID == ClimbCrouch.STATE_JumpFallToClimbCrouch || animatorStateID == ClimbCrouch.STATE_JumpRiseToClimbCrouch || animatorStateID == ClimbCrouch.STATE_JumpTopToClimbCrouch)
			{
				this.mRotation = this.GetReachRotation(0f, 0.5f, this.mFaceClimbableNormalAngle, ref this.mFaceClimbableNormalAngleUsed);
			}
			if (!this.mHasArrived)
			{
				float num = Vector3.Distance(this.mMotionController.transform.position, this.mTargetPosition);
				if (!this.mHasArrived && num < 0.03f)
				{
					this.mHasArrived = true;
				}
			}
			if (!this.mHasArrived)
			{
				Vector3 vector = Vector3.Lerp(this.mMotionController.transform.position, this.mTargetPosition, this.mArrivalLerp);
				this.mVelocity = (vector - this.mMotionController.transform.position) / Time.fixedDeltaTime;
				this.mVelocity.y = Mathf.Min(this.mVelocity.y, 5.5f);
				if (this.mVelocity.y == 0f && (this.mVelocity.x != 0f || this.mVelocity.z != 0f))
				{
					if (Vector3.Distance(this.mMotionController.transform.position, this.mTargetPosition) < 0.1f)
					{
						this.mTargetPosition = this.mMotionController.transform.position;
						return;
					}
					this.mHasArrived = true;
					this.mPhase = 370;
					this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 370);
					return;
				}
			}
			else if (animatorStateID == ClimbCrouch.STATE_JumpFallToClimbCrouch)
			{
				if (this.mHasArrived)
				{
					this.mPhase = 320;
					this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 320);
					return;
				}
			}
			else if (animatorStateID == ClimbCrouch.STATE_ClimbCrouchPose)
			{
				if (this.mMotionController.State.InputFromAvatarAngle < -80f && this.mMotionController.State.InputFromAvatarAngle > -100f)
				{
					if (this.TestShimmy(-this._MinSideSpaceForMove))
					{
						this.mPhase = 380;
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 380, true);
						return;
					}
				}
				else if (this.mMotionController.State.InputFromAvatarAngle > 80f && this.mMotionController.State.InputFromAvatarAngle < 100f)
				{
					if (this.TestShimmy(this._MinSideSpaceForMove))
					{
						this.mPhase = 385;
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 385, true);
						return;
					}
				}
				else
				{
					if ((this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias)) || (this.mMotionController.State.InputMagnitudeTrend.Value > 0.1f && this.mMotionController.State.InputFromAvatarAngle > -10f && this.mMotionController.State.InputFromAvatarAngle < 10f))
					{
						this.mActorController.IsCollsionEnabled = false;
						this.mPhase = 350;
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 350);
						return;
					}
					if (this.mMotionController.State.InputY > 0f)
					{
						this.mActorController.IsCollsionEnabled = false;
						this.mPhase = 350;
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 350);
						return;
					}
					if (this.mActorController.State.GroundSurfaceDistance < this._MinGroundDistance || this.mMotionController.State.InputFromAvatarAngle < -170f || this.mMotionController.State.InputFromAvatarAngle > 170f)
					{
						this.mPhase = 370;
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 370);
						return;
					}
				}
			}
			else
			{
				if (this.IsInClimbShimmy)
				{
					float num2 = Vector3Ext.SignedAngle(this.mGrabPositionNormal, -this.mActorController._Transform.forward);
					this.mRotation = Quaternion.AngleAxis(num2, Vector3.up);
					float num3 = Mathf.Abs(this._BodyTargetOffset.z);
					this.mVelocity = Vector3.zero;
					if (RaycastExt.SafeRaycast(this.mMotionController.transform.position, this.mMotionController.transform.forward, out ClimbCrouch.sCollisionUpdateInfo, num3 * 1.5f, this._ClimbableLayers, this.mActorController._Transform, null, true, false))
					{
						this.mVelocity = this.mMotionController.transform.forward * (ClimbCrouch.sCollisionUpdateInfo.distance - num3) / Time.deltaTime;
					}
					this.mAvatarContactPosition = Quaternion.Inverse(this.mClimbable.transform.rotation) * (this.mMotionController.transform.position - this.mClimbable.transform.position);
					return;
				}
				if (animatorStateID == ClimbCrouch.STATE_ClimbCrouchToTop)
				{
					this.mVelocity = this._ToTopVelocity;
					if (normalizedTime > 0.9f)
					{
						this.mActorController.IsCollsionEnabled = true;
					}
					this.mAvatarContactPosition = Quaternion.Inverse(this.mClimbable.transform.rotation) * (this.mMotionController.transform.position - this.mClimbable.transform.position);
					return;
				}
				if (animatorStateID == ClimbCrouch.STATE_ClimbCrouchRecoverIdle)
				{
					this.mActorController.IsCollsionEnabled = true;
					Vector3 vector2 = this.mMotionController.transform.position + this.mMotionController.transform.rotation * this._ExitPositionOffset;
					vector2.y = this.mGrabPosition.y + this._ExitPositionOffset.y;
					if (Vector3.Distance(vector2, this.mMotionController.transform.position) > 0.01f)
					{
						this.mTargetPosition = vector2;
						Vector3 vector3 = Vector3.Lerp(this.mMotionController.transform.position, this.mTargetPosition, 0.25f);
						this.mVelocity = (vector3 - this.mMotionController.transform.position) / Time.fixedDeltaTime;
					}
					if (this.mAvatarContactPosition.sqrMagnitude == 0f)
					{
						this.mAvatarContactPosition = Quaternion.Inverse(this.mClimbable.transform.rotation) * (this.mTargetPosition - this.mClimbable.transform.position);
						return;
					}
				}
				else if (animatorStateID == ClimbCrouch.STATE_ClimbCrouchToJumpFall)
				{
					if (normalizedTime > 0.5f && this.mPhase != 0)
					{
						this.Deactivate();
						this.mPhase = 0;
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 0);
						return;
					}
				}
				else if (animatorStateID == ClimbCrouch.STATE_IdlePose)
				{
					this.Deactivate();
					this.mPhase = 0;
				}
			}
		}

		// Token: 0x06000DD0 RID: 3536 RVA: 0x00044CC0 File Offset: 0x00042EC0
		public virtual bool TestGrab(Vector3 rPosition, Quaternion rRotation, Vector3 rForward, float rRadius, float rBottom, float rTop)
		{
			Vector3 vector = Vector3.zero;
			float num = -this._BodyTargetOffset.z * 1.5f;
			vector = rPosition + this.mActorController._Transform.up * rTop;
			if (RaycastExt.SafeRaycast(vector, rForward, out this.mRaycastHitInfo, num, this._ClimbableLayers, this.mActorController._Transform, null, true, false))
			{
				return false;
			}
			vector = rPosition + this.mActorController._Transform.up * rBottom;
			if (!RaycastExt.SafeRaycast(vector, rForward, out this.mRaycastHitInfo, num, this._ClimbableLayers, this.mActorController._Transform, null, true, false))
			{
				return false;
			}
			vector = this.mRaycastHitInfo.point + this.mActorController._Transform.up * (rTop - rBottom) + rForward * 0.01f;
			if (!RaycastExt.SafeRaycast(vector, -this.mActorController._Transform.up, out this.mRaycastHitInfo, rTop, this._ClimbableLayers, this.mActorController._Transform, null, true, false))
			{
				return false;
			}
			Vector3 vector2 = this.mActorController._Transform.InverseTransformPoint(this.mRaycastHitInfo.point);
			vector = rPosition + this.mActorController._Transform.up * (vector2.y - 0.01f);
			if (!RaycastExt.SafeRaycast(vector, rForward, out this.mRaycastHitInfo, num, this._ClimbableLayers, this.mActorController._Transform, null, true, false))
			{
				return false;
			}
			RaycastHit raycastHit;
			if (RaycastExt.SafeRaycast(this.mRaycastHitInfo.point - this.mActorController._Transform.up, this.mRaycastHitInfo.normal, out raycastHit, rRadius * 3f, this._ClimbableLayers, this.mActorController._Transform, null, true, false))
			{
				return false;
			}
			if (this._HandGrabOffset > 0f)
			{
				RaycastHit raycastHit2;
				if (!RaycastExt.SafeRaycast(vector + rRotation * new Vector3(this._HandGrabOffset, 0f, 0f), rForward, out raycastHit2, num, this._ClimbableLayers, this.mActorController._Transform, null, true, false))
				{
					return false;
				}
				if (!RaycastExt.SafeRaycast(vector + rRotation * new Vector3(-this._HandGrabOffset, 0f, 0f), rForward, out raycastHit2, num, this._ClimbableLayers, this.mActorController._Transform, null, true, false))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000DD1 RID: 3537 RVA: 0x00044F38 File Offset: 0x00043138
		private bool TestShimmy(float rOffset)
		{
			float num = Mathf.Abs(rOffset);
			Transform transform = this.mMotionController.transform;
			Vector3 position = transform.position;
			Vector3 vector = transform.rotation * new Vector3((float)((rOffset < 0f) ? (-1) : 1), 0f, 0f);
			if (RaycastExt.SafeRaycast(position, vector, num, -1, null, null, true))
			{
				return false;
			}
			Vector3 vector2 = transform.position + transform.rotation * new Vector3(rOffset, 0f, 0f);
			if (!this.TestGrab(vector2, this.mMotionController.transform.rotation, this.mMotionController.transform.forward, this.mActorController.BaseRadius, 1f, 1.5f))
			{
				return false;
			}
			this.mClimbable = this.mRaycastHitInfo.collider.gameObject;
			this.mGrabPosition = this.mRaycastHitInfo.point;
			this.mLocalGrabPosition = Quaternion.Inverse(this.mClimbable.transform.rotation) * (this.mRaycastHitInfo.point - this.mClimbable.transform.position);
			this.mGrabPositionNormal = this.mRaycastHitInfo.normal;
			this.mTargetPosition = this.DetermineTargetPositions(ref this.mGrabPosition, ref this.mGrabPositionNormal);
			return true;
		}

		// Token: 0x06000DD2 RID: 3538 RVA: 0x00045090 File Offset: 0x00043290
		public override void OnAnimatorStateChange(int rLastStateID, int rNewStateID)
		{
			if (rNewStateID == ClimbCrouch.STATE_JumpRiseToClimbCrouch || rNewStateID == ClimbCrouch.STATE_JumpTopToClimbCrouch)
			{
				this.mPhase = 320;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 320);
			}
			if (rLastStateID == ClimbCrouch.STATE_ClimbCrouchRecoverIdle)
			{
				this.Deactivate();
				this.mGrabPosition = Vector3.zero;
				this.mPhase = 0;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 0);
			}
		}

		// Token: 0x06000DD3 RID: 3539 RVA: 0x0004510C File Offset: 0x0004330C
		private Vector3 DetermineTargetPositions(ref Vector3 rGrabPosition, ref Vector3 rGrabNormal)
		{
			if (this.mActorController.State.Ground != null && this.mActorController.State.Ground == this.mActorController.PrevState.Ground && Quaternion.Angle(this.mActorController.State.GroundRotation, this.mActorController.PrevState.GroundRotation) != 0f)
			{
				Quaternion quaternion = this.mActorController.PrevState.GroundRotation.RotationTo(this.mActorController.State.GroundRotation);
				rGrabNormal = quaternion * rGrabNormal;
			}
			if (this._HandGrabOffset > 0f)
			{
				this.mLeftHandTargetPosition = rGrabPosition - Quaternion.AngleAxis(-90f, Vector3.up) * rGrabNormal * this._HandGrabOffset;
				this.mRightHandTargetPosition = rGrabPosition - Quaternion.AngleAxis(90f, Vector3.up) * rGrabNormal * this._HandGrabOffset;
			}
			return rGrabPosition + this.mActorController._Transform.rotation * this._BodyTargetOffset;
		}

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x06000DD4 RID: 3540 RVA: 0x00045260 File Offset: 0x00043460
		protected bool IsInClimbUpState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorTransitionID == ClimbCrouch.TRANS_EntryState_JumpRiseToClimbCrouch || animatorTransitionID == ClimbCrouch.TRANS_AnyState_JumpRiseToClimbCrouch || animatorStateID == ClimbCrouch.STATE_IdleToClimbCrouch || animatorStateID == ClimbCrouch.STATE_JumpRiseToClimbCrouch || animatorStateID == ClimbCrouch.STATE_JumpTopToClimbCrouch || animatorStateID == ClimbCrouch.STATE_JumpFallToClimbCrouch;
			}
		}

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x06000DD5 RID: 3541 RVA: 0x000452B8 File Offset: 0x000434B8
		protected bool IsInClimbIdleState
		{
			get
			{
				return this.mMotionLayer._AnimatorStateID == ClimbCrouch.STATE_ClimbCrouchPose;
			}
		}

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x06000DD6 RID: 3542 RVA: 0x000452D0 File Offset: 0x000434D0
		protected bool IsInClimbState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorTransitionID == ClimbCrouch.TRANS_EntryState_JumpRiseToClimbCrouch || animatorTransitionID == ClimbCrouch.TRANS_EntryState_IdleToClimbCrouch || animatorTransitionID == ClimbCrouch.TRANS_EntryState_JumpTopToClimbCrouch || animatorTransitionID == ClimbCrouch.TRANS_EntryState_JumpFallToClimbCrouch || animatorTransitionID == ClimbCrouch.TRANS_AnyState_JumpRiseToClimbCrouch || animatorTransitionID == ClimbCrouch.TRANS_AnyState_IdleToClimbCrouch || animatorTransitionID == ClimbCrouch.TRANS_AnyState_JumpTopToClimbCrouch || animatorTransitionID == ClimbCrouch.TRANS_AnyState_JumpFallToClimbCrouch || animatorStateID == ClimbCrouch.STATE_IdleToClimbCrouch || animatorStateID == ClimbCrouch.STATE_JumpRiseToClimbCrouch || animatorStateID == ClimbCrouch.STATE_JumpTopToClimbCrouch || animatorStateID == ClimbCrouch.STATE_JumpFallToClimbCrouch || animatorStateID == ClimbCrouch.STATE_ClimbCrouchPose || animatorStateID == ClimbCrouch.STATE_ClimbCrouchToTop || animatorStateID == ClimbCrouch.STATE_ClimbCrouchRecoverIdle || animatorStateID == ClimbCrouch.STATE_ClimbCrouchToJumpFall || animatorStateID == ClimbCrouch.STATE_ClimbCrouchShimmyLeft || animatorStateID == ClimbCrouch.STATE_ClimbCrouchShimmyRight || animatorTransitionID == ClimbCrouch.TRANS_ClimbCrouchPose_ClimbCrouchShimmyLeft || animatorTransitionID == ClimbCrouch.TRANS_ClimbCrouchPose_ClimbCrouchShimmyRight || animatorTransitionID == ClimbCrouch.TRANS_ClimbCrouchShimmyLeft_ClimbCrouchPose || animatorTransitionID == ClimbCrouch.TRANS_ClimbCrouchShimmyRight_ClimbCrouchPose;
			}
		}

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x06000DD7 RID: 3543 RVA: 0x000453BC File Offset: 0x000435BC
		protected bool IsInClimbShimmy
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == ClimbCrouch.STATE_ClimbCrouchShimmyLeft || animatorStateID == ClimbCrouch.STATE_ClimbCrouchShimmyRight || animatorTransitionID == ClimbCrouch.TRANS_ClimbCrouchPose_ClimbCrouchShimmyLeft || animatorTransitionID == ClimbCrouch.TRANS_ClimbCrouchPose_ClimbCrouchShimmyRight || animatorTransitionID == ClimbCrouch.TRANS_ClimbCrouchShimmyLeft_ClimbCrouchPose || animatorTransitionID == ClimbCrouch.TRANS_ClimbCrouchShimmyRight_ClimbCrouchPose;
			}
		}

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x06000DD8 RID: 3544 RVA: 0x00045414 File Offset: 0x00043614
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == ClimbCrouch.STATE_ClimbCrouchPose || animatorStateID == ClimbCrouch.STATE_IdleToClimbCrouch || animatorStateID == ClimbCrouch.STATE_ClimbCrouchToTop || animatorStateID == ClimbCrouch.STATE_JumpRiseToClimbCrouch || animatorStateID == ClimbCrouch.STATE_JumpFallToClimbCrouch || animatorStateID == ClimbCrouch.STATE_ClimbCrouchToJumpFall || animatorStateID == ClimbCrouch.STATE_JumpTopToClimbCrouch || animatorStateID == ClimbCrouch.STATE_ClimbCrouchRecoverIdle || animatorStateID == ClimbCrouch.STATE_ClimbCrouchShimmyRight || animatorStateID == ClimbCrouch.STATE_ClimbCrouchShimmyLeft || animatorStateID == ClimbCrouch.STATE_IdlePose || animatorTransitionID == ClimbCrouch.TRANS_EntryState_IdleToClimbCrouch || animatorTransitionID == ClimbCrouch.TRANS_AnyState_IdleToClimbCrouch || animatorTransitionID == ClimbCrouch.TRANS_EntryState_JumpRiseToClimbCrouch || animatorTransitionID == ClimbCrouch.TRANS_AnyState_JumpRiseToClimbCrouch || animatorTransitionID == ClimbCrouch.TRANS_EntryState_JumpTopToClimbCrouch || animatorTransitionID == ClimbCrouch.TRANS_AnyState_JumpTopToClimbCrouch || animatorTransitionID == ClimbCrouch.TRANS_EntryState_JumpFallToClimbCrouch || animatorTransitionID == ClimbCrouch.TRANS_AnyState_JumpFallToClimbCrouch || animatorTransitionID == ClimbCrouch.TRANS_ClimbCrouchPose_ClimbCrouchToTop || animatorTransitionID == ClimbCrouch.TRANS_ClimbCrouchPose_ClimbCrouchToJumpFall || animatorTransitionID == ClimbCrouch.TRANS_ClimbCrouchPose_ClimbCrouchShimmyRight || animatorTransitionID == ClimbCrouch.TRANS_ClimbCrouchPose_ClimbCrouchShimmyLeft || animatorTransitionID == ClimbCrouch.TRANS_IdleToClimbCrouch_ClimbCrouchToTop || animatorTransitionID == ClimbCrouch.TRANS_IdleToClimbCrouch_ClimbCrouchPose || animatorTransitionID == ClimbCrouch.TRANS_ClimbCrouchToTop_ClimbCrouchRecoverIdle || animatorTransitionID == ClimbCrouch.TRANS_JumpRiseToClimbCrouch_ClimbCrouchPose || animatorTransitionID == ClimbCrouch.TRANS_JumpRiseToClimbCrouch_ClimbCrouchToTop || animatorTransitionID == ClimbCrouch.TRANS_JumpFallToClimbCrouch_ClimbCrouchPose || animatorTransitionID == ClimbCrouch.TRANS_JumpFallToClimbCrouch_ClimbCrouchToTop || animatorTransitionID == ClimbCrouch.TRANS_JumpTopToClimbCrouch_ClimbCrouchPose || animatorTransitionID == ClimbCrouch.TRANS_JumpTopToClimbCrouch_ClimbCrouchToTop || animatorTransitionID == ClimbCrouch.TRANS_ClimbCrouchRecoverIdle_IdlePose || animatorTransitionID == ClimbCrouch.TRANS_ClimbCrouchShimmyRight_ClimbCrouchPose || animatorTransitionID == ClimbCrouch.TRANS_ClimbCrouchShimmyRight_ClimbCrouchToJumpFall || animatorTransitionID == ClimbCrouch.TRANS_ClimbCrouchShimmyLeft_ClimbCrouchPose || animatorTransitionID == ClimbCrouch.TRANS_ClimbCrouchShimmyLeft_ClimbCrouchToJumpFall;
			}
		}

		// Token: 0x06000DD9 RID: 3545 RVA: 0x000455AC File Offset: 0x000437AC
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == ClimbCrouch.STATE_ClimbCrouchPose || rStateID == ClimbCrouch.STATE_IdleToClimbCrouch || rStateID == ClimbCrouch.STATE_ClimbCrouchToTop || rStateID == ClimbCrouch.STATE_JumpRiseToClimbCrouch || rStateID == ClimbCrouch.STATE_JumpFallToClimbCrouch || rStateID == ClimbCrouch.STATE_ClimbCrouchToJumpFall || rStateID == ClimbCrouch.STATE_JumpTopToClimbCrouch || rStateID == ClimbCrouch.STATE_ClimbCrouchRecoverIdle || rStateID == ClimbCrouch.STATE_ClimbCrouchShimmyRight || rStateID == ClimbCrouch.STATE_ClimbCrouchShimmyLeft || rStateID == ClimbCrouch.STATE_IdlePose;
		}

		// Token: 0x06000DDA RID: 3546 RVA: 0x00045628 File Offset: 0x00043828
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == ClimbCrouch.STATE_ClimbCrouchPose || rStateID == ClimbCrouch.STATE_IdleToClimbCrouch || rStateID == ClimbCrouch.STATE_ClimbCrouchToTop || rStateID == ClimbCrouch.STATE_JumpRiseToClimbCrouch || rStateID == ClimbCrouch.STATE_JumpFallToClimbCrouch || rStateID == ClimbCrouch.STATE_ClimbCrouchToJumpFall || rStateID == ClimbCrouch.STATE_JumpTopToClimbCrouch || rStateID == ClimbCrouch.STATE_ClimbCrouchRecoverIdle || rStateID == ClimbCrouch.STATE_ClimbCrouchShimmyRight || rStateID == ClimbCrouch.STATE_ClimbCrouchShimmyLeft || rStateID == ClimbCrouch.STATE_IdlePose || rTransitionID == ClimbCrouch.TRANS_EntryState_IdleToClimbCrouch || rTransitionID == ClimbCrouch.TRANS_AnyState_IdleToClimbCrouch || rTransitionID == ClimbCrouch.TRANS_EntryState_JumpRiseToClimbCrouch || rTransitionID == ClimbCrouch.TRANS_AnyState_JumpRiseToClimbCrouch || rTransitionID == ClimbCrouch.TRANS_EntryState_JumpTopToClimbCrouch || rTransitionID == ClimbCrouch.TRANS_AnyState_JumpTopToClimbCrouch || rTransitionID == ClimbCrouch.TRANS_EntryState_JumpFallToClimbCrouch || rTransitionID == ClimbCrouch.TRANS_AnyState_JumpFallToClimbCrouch || rTransitionID == ClimbCrouch.TRANS_ClimbCrouchPose_ClimbCrouchToTop || rTransitionID == ClimbCrouch.TRANS_ClimbCrouchPose_ClimbCrouchToJumpFall || rTransitionID == ClimbCrouch.TRANS_ClimbCrouchPose_ClimbCrouchShimmyRight || rTransitionID == ClimbCrouch.TRANS_ClimbCrouchPose_ClimbCrouchShimmyLeft || rTransitionID == ClimbCrouch.TRANS_IdleToClimbCrouch_ClimbCrouchToTop || rTransitionID == ClimbCrouch.TRANS_IdleToClimbCrouch_ClimbCrouchPose || rTransitionID == ClimbCrouch.TRANS_ClimbCrouchToTop_ClimbCrouchRecoverIdle || rTransitionID == ClimbCrouch.TRANS_JumpRiseToClimbCrouch_ClimbCrouchPose || rTransitionID == ClimbCrouch.TRANS_JumpRiseToClimbCrouch_ClimbCrouchToTop || rTransitionID == ClimbCrouch.TRANS_JumpFallToClimbCrouch_ClimbCrouchPose || rTransitionID == ClimbCrouch.TRANS_JumpFallToClimbCrouch_ClimbCrouchToTop || rTransitionID == ClimbCrouch.TRANS_JumpTopToClimbCrouch_ClimbCrouchPose || rTransitionID == ClimbCrouch.TRANS_JumpTopToClimbCrouch_ClimbCrouchToTop || rTransitionID == ClimbCrouch.TRANS_ClimbCrouchRecoverIdle_IdlePose || rTransitionID == ClimbCrouch.TRANS_ClimbCrouchShimmyRight_ClimbCrouchPose || rTransitionID == ClimbCrouch.TRANS_ClimbCrouchShimmyRight_ClimbCrouchToJumpFall || rTransitionID == ClimbCrouch.TRANS_ClimbCrouchShimmyLeft_ClimbCrouchPose || rTransitionID == ClimbCrouch.TRANS_ClimbCrouchShimmyLeft_ClimbCrouchToJumpFall;
		}

		// Token: 0x06000DDB RID: 3547 RVA: 0x000457A8 File Offset: 0x000439A8
		public override void LoadAnimatorData()
		{
			ClimbCrouch.TRANS_EntryState_IdleToClimbCrouch = this.mMotionController.AddAnimatorName("Entry -> Base Layer.ClimbCrouch-SM.IdleToClimbCrouch");
			ClimbCrouch.TRANS_AnyState_IdleToClimbCrouch = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.ClimbCrouch-SM.IdleToClimbCrouch");
			ClimbCrouch.TRANS_EntryState_JumpRiseToClimbCrouch = this.mMotionController.AddAnimatorName("Entry -> Base Layer.ClimbCrouch-SM.JumpRiseToClimbCrouch");
			ClimbCrouch.TRANS_AnyState_JumpRiseToClimbCrouch = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.ClimbCrouch-SM.JumpRiseToClimbCrouch");
			ClimbCrouch.TRANS_EntryState_JumpTopToClimbCrouch = this.mMotionController.AddAnimatorName("Entry -> Base Layer.ClimbCrouch-SM.JumpTopToClimbCrouch");
			ClimbCrouch.TRANS_AnyState_JumpTopToClimbCrouch = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.ClimbCrouch-SM.JumpTopToClimbCrouch");
			ClimbCrouch.TRANS_EntryState_JumpFallToClimbCrouch = this.mMotionController.AddAnimatorName("Entry -> Base Layer.ClimbCrouch-SM.JumpFallToClimbCrouch");
			ClimbCrouch.TRANS_AnyState_JumpFallToClimbCrouch = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.ClimbCrouch-SM.JumpFallToClimbCrouch");
			ClimbCrouch.STATE_ClimbCrouchPose = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.ClimbCrouchPose");
			ClimbCrouch.TRANS_ClimbCrouchPose_ClimbCrouchToTop = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.ClimbCrouchPose -> Base Layer.ClimbCrouch-SM.ClimbCrouchToTop");
			ClimbCrouch.TRANS_ClimbCrouchPose_ClimbCrouchToJumpFall = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.ClimbCrouchPose -> Base Layer.ClimbCrouch-SM.ClimbCrouchToJumpFall");
			ClimbCrouch.TRANS_ClimbCrouchPose_ClimbCrouchShimmyRight = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.ClimbCrouchPose -> Base Layer.ClimbCrouch-SM.ClimbCrouchShimmyRight");
			ClimbCrouch.TRANS_ClimbCrouchPose_ClimbCrouchShimmyLeft = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.ClimbCrouchPose -> Base Layer.ClimbCrouch-SM.ClimbCrouchShimmyLeft");
			ClimbCrouch.STATE_IdleToClimbCrouch = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.IdleToClimbCrouch");
			ClimbCrouch.TRANS_IdleToClimbCrouch_ClimbCrouchToTop = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.IdleToClimbCrouch -> Base Layer.ClimbCrouch-SM.ClimbCrouchToTop");
			ClimbCrouch.TRANS_IdleToClimbCrouch_ClimbCrouchPose = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.IdleToClimbCrouch -> Base Layer.ClimbCrouch-SM.ClimbCrouchPose");
			ClimbCrouch.STATE_ClimbCrouchToTop = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.ClimbCrouchToTop");
			ClimbCrouch.TRANS_ClimbCrouchToTop_ClimbCrouchRecoverIdle = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.ClimbCrouchToTop -> Base Layer.ClimbCrouch-SM.ClimbCrouchRecoverIdle");
			ClimbCrouch.STATE_JumpRiseToClimbCrouch = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.JumpRiseToClimbCrouch");
			ClimbCrouch.TRANS_JumpRiseToClimbCrouch_ClimbCrouchPose = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.JumpRiseToClimbCrouch -> Base Layer.ClimbCrouch-SM.ClimbCrouchPose");
			ClimbCrouch.TRANS_JumpRiseToClimbCrouch_ClimbCrouchToTop = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.JumpRiseToClimbCrouch -> Base Layer.ClimbCrouch-SM.ClimbCrouchToTop");
			ClimbCrouch.STATE_JumpFallToClimbCrouch = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.JumpFallToClimbCrouch");
			ClimbCrouch.TRANS_JumpFallToClimbCrouch_ClimbCrouchPose = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.JumpFallToClimbCrouch -> Base Layer.ClimbCrouch-SM.ClimbCrouchPose");
			ClimbCrouch.TRANS_JumpFallToClimbCrouch_ClimbCrouchToTop = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.JumpFallToClimbCrouch -> Base Layer.ClimbCrouch-SM.ClimbCrouchToTop");
			ClimbCrouch.STATE_ClimbCrouchToJumpFall = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.ClimbCrouchToJumpFall");
			ClimbCrouch.STATE_JumpTopToClimbCrouch = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.JumpTopToClimbCrouch");
			ClimbCrouch.TRANS_JumpTopToClimbCrouch_ClimbCrouchPose = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.JumpTopToClimbCrouch -> Base Layer.ClimbCrouch-SM.ClimbCrouchPose");
			ClimbCrouch.TRANS_JumpTopToClimbCrouch_ClimbCrouchToTop = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.JumpTopToClimbCrouch -> Base Layer.ClimbCrouch-SM.ClimbCrouchToTop");
			ClimbCrouch.STATE_ClimbCrouchRecoverIdle = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.ClimbCrouchRecoverIdle");
			ClimbCrouch.TRANS_ClimbCrouchRecoverIdle_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.ClimbCrouchRecoverIdle -> Base Layer.ClimbCrouch-SM.IdlePose");
			ClimbCrouch.STATE_ClimbCrouchShimmyRight = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.ClimbCrouchShimmyRight");
			ClimbCrouch.TRANS_ClimbCrouchShimmyRight_ClimbCrouchPose = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.ClimbCrouchShimmyRight -> Base Layer.ClimbCrouch-SM.ClimbCrouchPose");
			ClimbCrouch.TRANS_ClimbCrouchShimmyRight_ClimbCrouchToJumpFall = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.ClimbCrouchShimmyRight -> Base Layer.ClimbCrouch-SM.ClimbCrouchToJumpFall");
			ClimbCrouch.STATE_ClimbCrouchShimmyLeft = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.ClimbCrouchShimmyLeft");
			ClimbCrouch.TRANS_ClimbCrouchShimmyLeft_ClimbCrouchPose = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.ClimbCrouchShimmyLeft -> Base Layer.ClimbCrouch-SM.ClimbCrouchPose");
			ClimbCrouch.TRANS_ClimbCrouchShimmyLeft_ClimbCrouchToJumpFall = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.ClimbCrouchShimmyLeft -> Base Layer.ClimbCrouch-SM.ClimbCrouchToJumpFall");
			ClimbCrouch.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.ClimbCrouch-SM.IdlePose");
		}

		// Token: 0x0400079D RID: 1949
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x0400079E RID: 1950
		public const int PHASE_START = 300;

		// Token: 0x0400079F RID: 1951
		public const int PHASE_FROM_IDLE = 300;

		// Token: 0x040007A0 RID: 1952
		public const int PHASE_FROM_JUMP_RISE = 301;

		// Token: 0x040007A1 RID: 1953
		public const int PHASE_FROM_JUMP_TOP = 302;

		// Token: 0x040007A2 RID: 1954
		public const int PHASE_FROM_JUMP_FALL = 303;

		// Token: 0x040007A3 RID: 1955
		public const int PHASE_FROM_JUMP_IMPACT = 304;

		// Token: 0x040007A4 RID: 1956
		public const int PHASE_IDLE = 320;

		// Token: 0x040007A5 RID: 1957
		public const int PHASE_TO_TOP = 350;

		// Token: 0x040007A6 RID: 1958
		public const int PHASE_TO_FALL = 370;

		// Token: 0x040007A7 RID: 1959
		public const int PHASE_SHIMMY_LEFT = 380;

		// Token: 0x040007A8 RID: 1960
		public const int PHASE_SHIMMY_RIGHT = 385;

		// Token: 0x040007A9 RID: 1961
		private static RaycastHit sCollisionUpdateInfo = default(RaycastHit);

		// Token: 0x040007AA RID: 1962
		public float _MinGroundDistance = 0.3f;

		// Token: 0x040007AB RID: 1963
		public float _MinRegrabDistance = 1f;

		// Token: 0x040007AC RID: 1964
		public float _HandGrabOffset = 0.13f;

		// Token: 0x040007AD RID: 1965
		public Vector3 _BodyTargetOffset = new Vector3(0f, -1.35f, -0.6f);

		// Token: 0x040007AE RID: 1966
		public Vector3 _ExitPositionOffset = new Vector3(0f, 0.015f, 0f);

		// Token: 0x040007AF RID: 1967
		public Vector3 _ToTopVelocity = Vector3.zero;

		// Token: 0x040007B0 RID: 1968
		public int _ClimbableLayers = 1;

		// Token: 0x040007B1 RID: 1969
		public float _MinSideSpaceForMove = 0.6f;

		// Token: 0x040007B2 RID: 1970
		protected GameObject mClimbable;

		// Token: 0x040007B3 RID: 1971
		protected float mFaceClimbableNormalAngle;

		// Token: 0x040007B4 RID: 1972
		protected float mFaceClimbableNormalAngleUsed;

		// Token: 0x040007B5 RID: 1973
		protected RaycastHit mRaycastHitInfo = RaycastExt.EmptyHitInfo;

		// Token: 0x040007B6 RID: 1974
		protected Vector3 mGrabPosition = Vector3.zero;

		// Token: 0x040007B7 RID: 1975
		protected Vector3 mLocalGrabPosition = Vector3.zero;

		// Token: 0x040007B8 RID: 1976
		protected Vector3 mAvatarContactPosition = Vector3.zero;

		// Token: 0x040007B9 RID: 1977
		protected Vector3 mGrabPositionNormal = Vector3.zero;

		// Token: 0x040007BA RID: 1978
		protected Vector3 mTargetPosition = Vector3.zero;

		// Token: 0x040007BB RID: 1979
		protected Vector3 mRightHandTargetPosition = Vector3.zero;

		// Token: 0x040007BC RID: 1980
		protected Vector3 mLeftHandTargetPosition = Vector3.zero;

		// Token: 0x040007BD RID: 1981
		protected bool mHasArrived;

		// Token: 0x040007BE RID: 1982
		protected float mArrivalLerp = 0.25f;

		// Token: 0x040007BF RID: 1983
		protected int mGrabMotion;

		// Token: 0x040007C0 RID: 1984
		protected int mStoredStance;

		// Token: 0x040007C1 RID: 1985
		public static int TRANS_EntryState_IdleToClimbCrouch = -1;

		// Token: 0x040007C2 RID: 1986
		public static int TRANS_AnyState_IdleToClimbCrouch = -1;

		// Token: 0x040007C3 RID: 1987
		public static int TRANS_EntryState_JumpRiseToClimbCrouch = -1;

		// Token: 0x040007C4 RID: 1988
		public static int TRANS_AnyState_JumpRiseToClimbCrouch = -1;

		// Token: 0x040007C5 RID: 1989
		public static int TRANS_EntryState_JumpTopToClimbCrouch = -1;

		// Token: 0x040007C6 RID: 1990
		public static int TRANS_AnyState_JumpTopToClimbCrouch = -1;

		// Token: 0x040007C7 RID: 1991
		public static int TRANS_EntryState_JumpFallToClimbCrouch = -1;

		// Token: 0x040007C8 RID: 1992
		public static int TRANS_AnyState_JumpFallToClimbCrouch = -1;

		// Token: 0x040007C9 RID: 1993
		public static int STATE_ClimbCrouchPose = -1;

		// Token: 0x040007CA RID: 1994
		public static int TRANS_ClimbCrouchPose_ClimbCrouchToTop = -1;

		// Token: 0x040007CB RID: 1995
		public static int TRANS_ClimbCrouchPose_ClimbCrouchToJumpFall = -1;

		// Token: 0x040007CC RID: 1996
		public static int TRANS_ClimbCrouchPose_ClimbCrouchShimmyRight = -1;

		// Token: 0x040007CD RID: 1997
		public static int TRANS_ClimbCrouchPose_ClimbCrouchShimmyLeft = -1;

		// Token: 0x040007CE RID: 1998
		public static int STATE_IdleToClimbCrouch = -1;

		// Token: 0x040007CF RID: 1999
		public static int TRANS_IdleToClimbCrouch_ClimbCrouchToTop = -1;

		// Token: 0x040007D0 RID: 2000
		public static int TRANS_IdleToClimbCrouch_ClimbCrouchPose = -1;

		// Token: 0x040007D1 RID: 2001
		public static int STATE_ClimbCrouchToTop = -1;

		// Token: 0x040007D2 RID: 2002
		public static int TRANS_ClimbCrouchToTop_ClimbCrouchRecoverIdle = -1;

		// Token: 0x040007D3 RID: 2003
		public static int STATE_JumpRiseToClimbCrouch = -1;

		// Token: 0x040007D4 RID: 2004
		public static int TRANS_JumpRiseToClimbCrouch_ClimbCrouchPose = -1;

		// Token: 0x040007D5 RID: 2005
		public static int TRANS_JumpRiseToClimbCrouch_ClimbCrouchToTop = -1;

		// Token: 0x040007D6 RID: 2006
		public static int STATE_JumpFallToClimbCrouch = -1;

		// Token: 0x040007D7 RID: 2007
		public static int TRANS_JumpFallToClimbCrouch_ClimbCrouchPose = -1;

		// Token: 0x040007D8 RID: 2008
		public static int TRANS_JumpFallToClimbCrouch_ClimbCrouchToTop = -1;

		// Token: 0x040007D9 RID: 2009
		public static int STATE_ClimbCrouchToJumpFall = -1;

		// Token: 0x040007DA RID: 2010
		public static int STATE_JumpTopToClimbCrouch = -1;

		// Token: 0x040007DB RID: 2011
		public static int TRANS_JumpTopToClimbCrouch_ClimbCrouchPose = -1;

		// Token: 0x040007DC RID: 2012
		public static int TRANS_JumpTopToClimbCrouch_ClimbCrouchToTop = -1;

		// Token: 0x040007DD RID: 2013
		public static int STATE_ClimbCrouchRecoverIdle = -1;

		// Token: 0x040007DE RID: 2014
		public static int TRANS_ClimbCrouchRecoverIdle_IdlePose = -1;

		// Token: 0x040007DF RID: 2015
		public static int STATE_ClimbCrouchShimmyRight = -1;

		// Token: 0x040007E0 RID: 2016
		public static int TRANS_ClimbCrouchShimmyRight_ClimbCrouchPose = -1;

		// Token: 0x040007E1 RID: 2017
		public static int TRANS_ClimbCrouchShimmyRight_ClimbCrouchToJumpFall = -1;

		// Token: 0x040007E2 RID: 2018
		public static int STATE_ClimbCrouchShimmyLeft = -1;

		// Token: 0x040007E3 RID: 2019
		public static int TRANS_ClimbCrouchShimmyLeft_ClimbCrouchPose = -1;

		// Token: 0x040007E4 RID: 2020
		public static int TRANS_ClimbCrouchShimmyLeft_ClimbCrouchToJumpFall = -1;

		// Token: 0x040007E5 RID: 2021
		public static int STATE_IdlePose = -1;
	}
}
