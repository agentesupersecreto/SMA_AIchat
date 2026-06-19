using System;
using com.ootii.Geometry;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000F9 RID: 249
	[MotionName("Climb Ladder")]
	[MotionDescription("Allows for climbing up and down ladders. Looks good for a basic wall climb too. The default spacing for rungs is 0.32.")]
	public class ClimbLadder : MotionControllerMotion
	{
		// Token: 0x170003DD RID: 989
		// (get) Token: 0x06000DDD RID: 3549 RVA: 0x00045BB6 File Offset: 0x00043DB6
		// (set) Token: 0x06000DDE RID: 3550 RVA: 0x00045BBE File Offset: 0x00043DBE
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

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x06000DDF RID: 3551 RVA: 0x00045BC7 File Offset: 0x00043DC7
		// (set) Token: 0x06000DE0 RID: 3552 RVA: 0x00045BCF File Offset: 0x00043DCF
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

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x06000DE1 RID: 3553 RVA: 0x00045BD8 File Offset: 0x00043DD8
		// (set) Token: 0x06000DE2 RID: 3554 RVA: 0x00045BE0 File Offset: 0x00043DE0
		public float TopExitTestHeight
		{
			get
			{
				return this._TopExitTestHeight;
			}
			set
			{
				this._TopExitTestHeight = value;
			}
		}

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x06000DE3 RID: 3555 RVA: 0x00045BE9 File Offset: 0x00043DE9
		// (set) Token: 0x06000DE4 RID: 3556 RVA: 0x00045BF1 File Offset: 0x00043DF1
		public float DetachTestHeight
		{
			get
			{
				return this._DetachTestHeight;
			}
			set
			{
				this._DetachTestHeight = value;
			}
		}

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x06000DE5 RID: 3557 RVA: 0x00045BFA File Offset: 0x00043DFA
		// (set) Token: 0x06000DE6 RID: 3558 RVA: 0x00045C02 File Offset: 0x00043E02
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

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x06000DE7 RID: 3559 RVA: 0x00045C0B File Offset: 0x00043E0B
		// (set) Token: 0x06000DE8 RID: 3560 RVA: 0x00045C13 File Offset: 0x00043E13
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

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x06000DE9 RID: 3561 RVA: 0x00045C1C File Offset: 0x00043E1C
		// (set) Token: 0x06000DEA RID: 3562 RVA: 0x00045C24 File Offset: 0x00043E24
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

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x06000DEB RID: 3563 RVA: 0x00045C2D File Offset: 0x00043E2D
		// (set) Token: 0x06000DEC RID: 3564 RVA: 0x00045C35 File Offset: 0x00043E35
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

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x06000DED RID: 3565 RVA: 0x00045C3E File Offset: 0x00043E3E
		// (set) Token: 0x06000DEE RID: 3566 RVA: 0x00045C46 File Offset: 0x00043E46
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

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x06000DEF RID: 3567 RVA: 0x00045C4F File Offset: 0x00043E4F
		// (set) Token: 0x06000DF0 RID: 3568 RVA: 0x00045C57 File Offset: 0x00043E57
		public float ReachOffset3
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

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x06000DF1 RID: 3569 RVA: 0x00045C60 File Offset: 0x00043E60
		// (set) Token: 0x06000DF2 RID: 3570 RVA: 0x00045C68 File Offset: 0x00043E68
		public float ReachOffset4
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

		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x06000DF3 RID: 3571 RVA: 0x00045C71 File Offset: 0x00043E71
		// (set) Token: 0x06000DF4 RID: 3572 RVA: 0x00045C79 File Offset: 0x00043E79
		public float ReachOffset5
		{
			get
			{
				return this._ReachOffset5;
			}
			set
			{
				this._ReachOffset5 = value;
			}
		}

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x06000DF5 RID: 3573 RVA: 0x00045C82 File Offset: 0x00043E82
		// (set) Token: 0x06000DF6 RID: 3574 RVA: 0x00045C8A File Offset: 0x00043E8A
		public float ReachOffset6
		{
			get
			{
				return this._ReachOffset6;
			}
			set
			{
				this._ReachOffset6 = value;
			}
		}

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x06000DF7 RID: 3575 RVA: 0x00045C93 File Offset: 0x00043E93
		// (set) Token: 0x06000DF8 RID: 3576 RVA: 0x00045C9B File Offset: 0x00043E9B
		public float ReachOffset7
		{
			get
			{
				return this._ReachOffset7;
			}
			set
			{
				this._ReachOffset7 = value;
			}
		}

		// Token: 0x06000DF9 RID: 3577 RVA: 0x00045CA4 File Offset: 0x00043EA4
		public ClimbLadder()
		{
			this._Category = 11;
			this._Priority = 40f;
			this._ActionAlias = "Jump";
			this._OverrideLayers = true;
			this.mIsStartable = true;
		}

		// Token: 0x06000DFA RID: 3578 RVA: 0x00045DA8 File Offset: 0x00043FA8
		public ClimbLadder(MotionController rController)
			: base(rController)
		{
			this._Category = 11;
			this._Priority = 40f;
			this._ActionAlias = "Jump";
			this._OverrideLayers = true;
			this.mIsStartable = true;
		}

		// Token: 0x06000DFB RID: 3579 RVA: 0x00045EAC File Offset: 0x000440AC
		public override bool TestActivate()
		{
			if (!this.mIsStartable)
			{
				return false;
			}
			if (this.mMotionController.IsGrounded)
			{
				if (this._ActionAlias.Length == 0 || (this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias)))
				{
					this.mLastGrabPoint = Vector3.zero;
					if (this.TestForClimbUp())
					{
						this.mStartState = 1500;
						return true;
					}
					if (this.TestForClimbDownBack())
					{
						this.mStartState = 1505;
						return true;
					}
					if (this.TestForClimbDownForward())
					{
						this.mStartState = 1506;
						return true;
					}
				}
			}
			else if (this.TestForClimbInAir())
			{
				this.mStartState = 1504;
				return true;
			}
			return false;
		}

		// Token: 0x06000DFC RID: 3580 RVA: 0x00045F62 File Offset: 0x00044162
		public override bool TestUpdate()
		{
			return !this.mIsAnimatorActive || this.IsInMotionState;
		}

		// Token: 0x06000DFD RID: 3581 RVA: 0x00045F78 File Offset: 0x00044178
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			if (this.mRaycastHitInfo.collider == null)
			{
				return false;
			}
			this.mIsExitTriggered = false;
			this.mStoredStance = this.mActorController.State.Stance;
			this.mActorController.State.Stance = 6;
			this.mClimbable = this.mRaycastHitInfo.collider.gameObject;
			this.mLocalClimbableNormal = this.mClimbable.transform.InverseTransformDirection(this.mRaycastHitInfo.normal);
			Vector3 vector = Quaternion.AngleAxis(180f, this.mActorController._Transform.up) * this.mRaycastHitInfo.normal;
			this.mFaceClimbableNormalAngle = this.mActorController._Transform.forward.HorizontalAngleTo(vector, this.mActorController._Transform.up);
			this.mFaceClimbableNormalAngleUsed = 0f;
			this.ClearReachData();
			if (this.mStartState == 1500)
			{
				MotionReachData motionReachData = MotionReachData.Allocate();
				motionReachData.StateID = ClimbLadder.STATE_LadderBottomOn;
				motionReachData.StartTime = 0f;
				motionReachData.EndTime = 0.9f;
				motionReachData.Power = 3;
				motionReachData.ReachTarget = this.mRaycastHitInfo.point - this.mActorController._Transform.up * this.mActorController._MaxStepHeight + this.mActorController._Transform.up * 0f + this.mRaycastHitInfo.normal * this._ReachOffset1;
				motionReachData.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData);
			}
			else if (this.mStartState == 1505)
			{
				MotionReachData motionReachData2 = MotionReachData.Allocate();
				motionReachData2.StateID = ClimbLadder.STATE_LadderTopOn;
				motionReachData2.StartTime = 0.5f;
				motionReachData2.EndTime = 0.7f;
				motionReachData2.Power = 4;
				motionReachData2.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.up * this.mActorController._MaxStepHeight + this.mActorController._Transform.up * this._ReachOffset2 + this.mRaycastHitInfo.normal * this._ReachOffset3;
				motionReachData2.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData2);
				motionReachData2 = MotionReachData.Allocate();
				motionReachData2.StateID = ClimbLadder.STATE_LadderTopOn;
				motionReachData2.StartTime = 0.75f;
				motionReachData2.EndTime = 0.95f;
				motionReachData2.Power = 3;
				motionReachData2.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.up * this.mActorController._MaxStepHeight + this.mActorController._Transform.up * this._ReachOffset4 + this.mRaycastHitInfo.normal * this._ReachOffset5;
				motionReachData2.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData2);
			}
			else if (this.mStartState == 1506)
			{
				MotionReachData motionReachData3 = MotionReachData.Allocate();
				motionReachData3.StateID = ClimbLadder.STATE_LadderTopOn;
				motionReachData3.StartTime = 0.5f;
				motionReachData3.EndTime = 0.7f;
				motionReachData3.Power = 4;
				motionReachData3.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.up * this.mActorController._MaxStepHeight + this.mActorController._Transform.up * this._ReachOffset2 + this.mRaycastHitInfo.normal * this._ReachOffset3;
				motionReachData3.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData3);
				motionReachData3 = MotionReachData.Allocate();
				motionReachData3.StateID = ClimbLadder.STATE_LadderTopOn;
				motionReachData3.StartTime = 0.75f;
				motionReachData3.EndTime = 0.95f;
				motionReachData3.Power = 3;
				motionReachData3.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.up * this.mActorController._MaxStepHeight + this.mActorController._Transform.up * this._ReachOffset4 + this.mRaycastHitInfo.normal * this._ReachOffset5;
				motionReachData3.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData3);
			}
			else if (this.mStartState == 1504)
			{
				MotionReachData motionReachData4 = MotionReachData.Allocate();
				motionReachData4.TransitionID = ClimbLadder.TRANS_EntryState_JumpToClimb;
				motionReachData4.StartTime = 0f;
				motionReachData4.EndTime = 0.95f;
				motionReachData4.Power = 2;
				motionReachData4.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.up * this.mActorController._MaxStepHeight + this.mRaycastHitInfo.normal * 0.55f + this.mActorController._Transform.up * -0.7f;
				motionReachData4.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData4);
				motionReachData4 = MotionReachData.Allocate();
				motionReachData4.StateID = ClimbLadder.STATE_JumpToClimb;
				motionReachData4.StartTime = 0f;
				motionReachData4.EndTime = 0.4f;
				motionReachData4.Power = 2;
				motionReachData4.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.up * this.mActorController._MaxStepHeight + this.mRaycastHitInfo.normal * 0.55f + this.mActorController._Transform.up * -0.65f;
				motionReachData4.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData4);
				motionReachData4 = MotionReachData.Allocate();
				motionReachData4.StateID = ClimbLadder.STATE_JumpToClimb;
				motionReachData4.StartTime = 0.5f;
				motionReachData4.EndTime = 0.7f;
				motionReachData4.Power = 4;
				motionReachData4.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.up * this.mActorController._MaxStepHeight + this.mRaycastHitInfo.normal * 0.55f + this.mActorController._Transform.up * -0.65f;
				motionReachData4.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData4);
				motionReachData4 = MotionReachData.Allocate();
				motionReachData4.StateID = ClimbLadder.STATE_JumpToClimb;
				motionReachData4.StartTime = 0.8f;
				motionReachData4.EndTime = 1.2f;
				motionReachData4.Power = 2;
				motionReachData4.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.up * this.mActorController._MaxStepHeight + this.mRaycastHitInfo.normal * 0.35f + this.mActorController._Transform.up * -0.65f;
				motionReachData4.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData4);
			}
			this.mActorController.IsGravityEnabled = false;
			this.mActorController.ForceGrounding = false;
			this.mActorController.FixGroundPenetration = false;
			this.mActorController.SetGround(this.mClimbable.transform);
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, this.mStartState, true);
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000DFE RID: 3582 RVA: 0x000467F4 File Offset: 0x000449F4
		public override void Deactivate()
		{
			this.mClimbable = null;
			if (this.mActorController.State.Stance == 6)
			{
				this.mActorController.State.Stance = this.mStoredStance;
			}
			this.mActorController.IsGravityEnabled = true;
			this.mActorController.ForceGrounding = true;
			this.mActorController.IsCollsionEnabled = true;
			this.mActorController.FixGroundPenetration = true;
			this.mActorController.SetGround(null);
			base.Deactivate();
		}

		// Token: 0x06000DFF RID: 3583 RVA: 0x00046873 File Offset: 0x00044A73
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rVelocityDelta, ref Quaternion rRotationDelta)
		{
			if (this.mMotionLayer._AnimatorStateID != ClimbLadder.STATE_IdleTurn180L)
			{
				rRotationDelta = Quaternion.identity;
			}
		}

		// Token: 0x06000E00 RID: 3584 RVA: 0x00046894 File Offset: 0x00044A94
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
			if ((animatorStateID == ClimbLadder.STATE_LadderPose || animatorStateID == ClimbLadder.STATE_LadderUp || animatorStateID == ClimbLadder.STATE_LadderDown) && this._ActionAlias.Length > 0 && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias))
			{
				this.mLastGrabPoint = this.mActorController._Transform.position;
				this.Deactivate();
				return;
			}
			if (animatorStateID == ClimbLadder.STATE_IdleTurn180L)
			{
				if (animatorStateNormalizedTime > 0.7f)
				{
					Vector3 vector = this.mClimbable.transform.TransformDirection(this.mLocalClimbableNormal);
					Vector3 vector2 = Quaternion.AngleAxis(180f, this.mActorController._Transform.up) * vector;
					this.mFaceClimbableNormalAngle = this.mActorController._Transform.forward.HorizontalAngleTo(vector2, this.mActorController._Transform.up);
					this.mFaceClimbableNormalAngleUsed = 0f;
					return;
				}
			}
			else if (animatorStateID == ClimbLadder.STATE_LadderTopOn)
			{
				this.mRotation = this.GetReachRotation(0.6f, 0.9f, this.mFaceClimbableNormalAngle, ref this.mFaceClimbableNormalAngleUsed);
				if (animatorStateNormalizedTime > 0.4f)
				{
					this.mActorController.IsCollsionEnabled = false;
					return;
				}
			}
			else
			{
				if (animatorStateID == ClimbLadder.STATE_LadderBottomOn)
				{
					this.mRotation = this.GetReachRotation(0.2f, 0.8f, this.mFaceClimbableNormalAngle, ref this.mFaceClimbableNormalAngleUsed);
					return;
				}
				if (animatorStateID == ClimbLadder.STATE_LadderUp)
				{
					if (!this.mIsExitTriggered && this.TestForTopExit())
					{
						this.mIsExitTriggered = true;
						MotionReachData motionReachData = MotionReachData.Allocate();
						motionReachData.StateID = ClimbLadder.STATE_ClimbToIdle;
						motionReachData.StartTime = 0.4f;
						motionReachData.EndTime = 0.55f;
						motionReachData.Power = 3;
						motionReachData.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.up * this._ReachOffset6 + this.mActorController._Transform.forward * this._ReachOffset7;
						motionReachData.ReachTargetGround = this.mActorController.State.Ground;
						this.mReachData.Add(motionReachData);
						this.mActorController.IsCollsionEnabled = false;
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 1520, true);
					}
					if (!this.mIsExitTriggered)
					{
						this.mActorController.IsCollsionEnabled = true;
						if (!RaycastExt.SafeRaycast(this.mActorController._Transform.position + this.mActorController._Transform.up * this._DetachTestHeight, this.mActorController._Transform.forward, out this.mRaycastHitInfo, this._MaxDistance, this._ClimbableLayers, this.mActorController._Transform, null, true, false))
						{
							this.Deactivate();
							return;
						}
					}
				}
				else if (animatorStateID == ClimbLadder.STATE_LadderDown)
				{
					this.mActorController.IsCollsionEnabled = true;
					if (!this.mIsExitTriggered && this.mActorController.State.Ground != null && this.mActorController.State.GroundSurfaceDirectDistance > 0f && this.mActorController.State.GroundSurfaceDirectDistance < 0.2f)
					{
						this.mIsExitTriggered = true;
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 1510, true);
					}
					if (!this.mIsExitTriggered)
					{
						Vector3 vector3 = this.mActorController._Transform.position + this.mActorController._Transform.up * this._DetachTestHeight;
						if (!RaycastExt.SafeRaycast(vector3, this.mActorController._Transform.forward, out this.mRaycastHitInfo, this._MaxDistance, this._ClimbableLayers, this.mActorController._Transform, null, true, false))
						{
							RaycastExt.SafeRaycast(vector3, this.mActorController._Transform.forward, out this.mRaycastHitInfo, this._MaxDistance, this._ClimbableLayers, this.mActorController._Transform, null, true, false);
							this.Deactivate();
							return;
						}
					}
				}
				else if (animatorStateID == ClimbLadder.STATE_IdlePose)
				{
					this.Deactivate();
				}
			}
		}

		// Token: 0x06000E01 RID: 3585 RVA: 0x00046D18 File Offset: 0x00044F18
		public virtual bool TestForTopExit()
		{
			Vector3 vector = this.mActorController._Transform.position + this.mActorController._Transform.up * this._TopExitTestHeight;
			Vector3 vector2 = this.mActorController._Transform.forward;
			float num = 1f;
			if (RaycastExt.SafeRaycast(vector, vector2, out this.mRaycastHitInfo, num, -1, this.mActorController._Transform, null, true, false))
			{
				return false;
			}
			Vector3 vector3 = this.mActorController._Transform.position + this.mActorController._Transform.up * this._TopExitTestHeight + this.mActorController._Transform.forward * 1f;
			vector2 = -this.mActorController._Transform.up;
			num = this._TopExitTestHeight;
			if (RaycastExt.SafeRaycast(vector3, vector2, out this.mRaycastHitInfo, num, -1, this.mActorController._Transform, null, true, false))
			{
				Vector3 vector4 = this.mRaycastHitInfo.point - this.mActorController._Transform.up * 0.01f - this.mActorController._Transform.forward * 1f;
				vector2 = this.mActorController._Transform.forward;
				num = 1.1f;
				if (RaycastExt.SafeRaycast(vector4, vector2, out this.mRaycastHitInfo, num, -1, this.mActorController._Transform, null, true, false))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000E02 RID: 3586 RVA: 0x00046E9C File Offset: 0x0004509C
		public virtual bool TestForClimbInAir()
		{
			if (this.mActorController.State.GroundSurfaceDirectDistance > 0f && this.mActorController.State.GroundSurfaceDirectDistance < this._MinGroundDistance)
			{
				return false;
			}
			Vector3 vector = this.mActorController._Transform.position + this.mActorController._Transform.up * this.mActorController._MaxStepHeight;
			Vector3 forward = this.mMotionController._Transform.forward;
			float maxDistance = this._MaxDistance;
			return RaycastExt.SafeRaycast(vector, forward, out this.mRaycastHitInfo, maxDistance, this._ClimbableLayers, this.mActorController._Transform, null, true, false) && RaycastExt.SafeRaycast(this.mActorController._Transform.position + this.mActorController._Transform.up * this.mActorController.Height, forward, maxDistance, this._ClimbableLayers, this.mActorController._Transform, null, true) && Vector3.Distance(this.mActorController._Transform.position, this.mLastGrabPoint) >= this._MinRegrabDistance;
		}

		// Token: 0x06000E03 RID: 3587 RVA: 0x00046FC8 File Offset: 0x000451C8
		public virtual bool TestForClimbUp()
		{
			if (Mathf.Abs(this.mMotionController._InputSource.InputFromAvatarAngle) > 100f)
			{
				return false;
			}
			Vector3 vector = this.mActorController._Transform.position + this.mActorController._Transform.up * this.mActorController._MaxStepHeight;
			Vector3 forward = this.mMotionController._Transform.forward;
			float maxDistance = this._MaxDistance;
			return RaycastExt.SafeRaycast(vector, forward, out this.mRaycastHitInfo, maxDistance, this._ClimbableLayers, this.mActorController._Transform, null, true, false) && this.mRaycastHitInfo.distance >= this._MinDistance && this.mRaycastHitInfo.distance <= this._MaxDistance;
		}

		// Token: 0x06000E04 RID: 3588 RVA: 0x00047090 File Offset: 0x00045290
		public virtual bool TestForClimbDownBack()
		{
			Vector3 vector = this.mActorController._Transform.position + this.mActorController._Transform.rotation * new Vector3(0f, this.mActorController._MaxStepHeight, 0f);
			Vector3 vector2 = -this.mMotionController._Transform.forward;
			float num = this._MaxDistance;
			if (RaycastExt.SafeRaycast(vector, vector2, out this.mRaycastHitInfo, num, this.mActorController._CollisionLayers, this.mActorController._Transform, null, true, false))
			{
				return false;
			}
			Vector3 vector3 = this.mActorController._Transform.position + this.mActorController._Transform.rotation * new Vector3(0f, this.mActorController._MaxStepHeight, -this._MaxDistance);
			vector2 = -this.mMotionController._Transform.up;
			num = this.mActorController._MaxStepHeight + 0.1f;
			if (RaycastExt.SafeRaycast(vector3, vector2, out this.mRaycastHitInfo, num, this.mActorController._CollisionLayers, this.mActorController._Transform, null, true, false))
			{
				return false;
			}
			Vector3 vector4 = this.mActorController._Transform.position + this.mActorController._Transform.rotation * new Vector3(0f, -this.mActorController._MaxStepHeight, -this._MaxDistance);
			vector2 = this.mMotionController._Transform.forward;
			num = this._MaxDistance;
			return RaycastExt.SafeRaycast(vector4, vector2, out this.mRaycastHitInfo, num, this._ClimbableLayers, this.mActorController._Transform, null, true, false) && this.mRaycastHitInfo.distance <= this._MaxDistance;
		}

		// Token: 0x06000E05 RID: 3589 RVA: 0x0004725C File Offset: 0x0004545C
		public virtual bool TestForClimbDownForward()
		{
			Vector3 vector = this.mActorController._Transform.position + this.mActorController._Transform.rotation * new Vector3(0f, this.mActorController._MaxStepHeight, 0f);
			Vector3 vector2 = this.mMotionController._Transform.forward;
			float num = this._MaxDistance;
			if (RaycastExt.SafeRaycast(vector, vector2, out this.mRaycastHitInfo, num, this.mActorController._CollisionLayers, this.mActorController._Transform, null, true, false))
			{
				return false;
			}
			Vector3 vector3 = this.mActorController._Transform.position + this.mActorController._Transform.rotation * new Vector3(0f, this.mActorController._MaxStepHeight, this._MaxDistance);
			vector2 = -this.mMotionController._Transform.up;
			num = this.mActorController._MaxStepHeight + 0.1f;
			if (RaycastExt.SafeRaycast(vector3, vector2, out this.mRaycastHitInfo, num, this.mActorController._CollisionLayers, this.mActorController._Transform, null, true, false))
			{
				return false;
			}
			Vector3 vector4 = this.mActorController._Transform.position + this.mActorController._Transform.rotation * new Vector3(0f, -this.mActorController._MaxStepHeight, this._MaxDistance);
			vector2 = -this.mMotionController._Transform.forward;
			num = this._MaxDistance;
			return RaycastExt.SafeRaycast(vector4, vector2, out this.mRaycastHitInfo, num, this._ClimbableLayers, this.mActorController._Transform, null, true, false) && this.mRaycastHitInfo.distance <= this._MaxDistance;
		}

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x06000E06 RID: 3590 RVA: 0x00047424 File Offset: 0x00045624
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == ClimbLadder.STATE_LadderBottomOn || animatorStateID == ClimbLadder.STATE_LadderUp || animatorStateID == ClimbLadder.STATE_LadderDown || animatorStateID == ClimbLadder.STATE_LadderBottomOff || animatorStateID == ClimbLadder.STATE_LadderPose || animatorStateID == ClimbLadder.STATE_IdlePose || animatorStateID == ClimbLadder.STATE_ClimbToIdle || animatorStateID == ClimbLadder.STATE_LadderTopOn || animatorStateID == ClimbLadder.STATE_IdleTurn180L || animatorStateID == ClimbLadder.STATE_JumpToClimb || animatorTransitionID == ClimbLadder.TRANS_EntryState_LadderBottomOn || animatorTransitionID == ClimbLadder.TRANS_AnyState_LadderBottomOn || animatorTransitionID == ClimbLadder.TRANS_EntryState_IdleTurn180L || animatorTransitionID == ClimbLadder.TRANS_AnyState_IdleTurn180L || animatorTransitionID == ClimbLadder.TRANS_EntryState_LadderTopOn || animatorTransitionID == ClimbLadder.TRANS_AnyState_LadderTopOn || animatorTransitionID == ClimbLadder.TRANS_EntryState_JumpToClimb || animatorTransitionID == ClimbLadder.TRANS_AnyState_JumpToClimb || animatorTransitionID == ClimbLadder.TRANS_LadderBottomOn_LadderUp || animatorTransitionID == ClimbLadder.TRANS_LadderUp_LadderDown || animatorTransitionID == ClimbLadder.TRANS_LadderUp_LadderPose || animatorTransitionID == ClimbLadder.TRANS_LadderUp_ClimbToIdle || animatorTransitionID == ClimbLadder.TRANS_LadderDown_LadderBottomOff || animatorTransitionID == ClimbLadder.TRANS_LadderDown_LadderUp || animatorTransitionID == ClimbLadder.TRANS_LadderDown_LadderPose || animatorTransitionID == ClimbLadder.TRANS_LadderBottomOff_IdlePose || animatorTransitionID == ClimbLadder.TRANS_LadderPose_LadderDown || animatorTransitionID == ClimbLadder.TRANS_LadderPose_LadderUp || animatorTransitionID == ClimbLadder.TRANS_ClimbToIdle_IdlePose || animatorTransitionID == ClimbLadder.TRANS_LadderTopOn_LadderDown || animatorTransitionID == ClimbLadder.TRANS_IdleTurn180L_LadderTopOn || animatorTransitionID == ClimbLadder.TRANS_JumpToClimb_LadderPose;
			}
		}

		// Token: 0x06000E07 RID: 3591 RVA: 0x0004758C File Offset: 0x0004578C
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == ClimbLadder.STATE_LadderBottomOn || rStateID == ClimbLadder.STATE_LadderUp || rStateID == ClimbLadder.STATE_LadderDown || rStateID == ClimbLadder.STATE_LadderBottomOff || rStateID == ClimbLadder.STATE_LadderPose || rStateID == ClimbLadder.STATE_IdlePose || rStateID == ClimbLadder.STATE_ClimbToIdle || rStateID == ClimbLadder.STATE_LadderTopOn || rStateID == ClimbLadder.STATE_IdleTurn180L || rStateID == ClimbLadder.STATE_JumpToClimb;
		}

		// Token: 0x06000E08 RID: 3592 RVA: 0x00047600 File Offset: 0x00045800
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == ClimbLadder.STATE_LadderBottomOn || rStateID == ClimbLadder.STATE_LadderUp || rStateID == ClimbLadder.STATE_LadderDown || rStateID == ClimbLadder.STATE_LadderBottomOff || rStateID == ClimbLadder.STATE_LadderPose || rStateID == ClimbLadder.STATE_IdlePose || rStateID == ClimbLadder.STATE_ClimbToIdle || rStateID == ClimbLadder.STATE_LadderTopOn || rStateID == ClimbLadder.STATE_IdleTurn180L || rStateID == ClimbLadder.STATE_JumpToClimb || rTransitionID == ClimbLadder.TRANS_EntryState_LadderBottomOn || rTransitionID == ClimbLadder.TRANS_AnyState_LadderBottomOn || rTransitionID == ClimbLadder.TRANS_EntryState_IdleTurn180L || rTransitionID == ClimbLadder.TRANS_AnyState_IdleTurn180L || rTransitionID == ClimbLadder.TRANS_EntryState_LadderTopOn || rTransitionID == ClimbLadder.TRANS_AnyState_LadderTopOn || rTransitionID == ClimbLadder.TRANS_EntryState_JumpToClimb || rTransitionID == ClimbLadder.TRANS_AnyState_JumpToClimb || rTransitionID == ClimbLadder.TRANS_LadderBottomOn_LadderUp || rTransitionID == ClimbLadder.TRANS_LadderUp_LadderDown || rTransitionID == ClimbLadder.TRANS_LadderUp_LadderPose || rTransitionID == ClimbLadder.TRANS_LadderUp_ClimbToIdle || rTransitionID == ClimbLadder.TRANS_LadderDown_LadderBottomOff || rTransitionID == ClimbLadder.TRANS_LadderDown_LadderUp || rTransitionID == ClimbLadder.TRANS_LadderDown_LadderPose || rTransitionID == ClimbLadder.TRANS_LadderBottomOff_IdlePose || rTransitionID == ClimbLadder.TRANS_LadderPose_LadderDown || rTransitionID == ClimbLadder.TRANS_LadderPose_LadderUp || rTransitionID == ClimbLadder.TRANS_ClimbToIdle_IdlePose || rTransitionID == ClimbLadder.TRANS_LadderTopOn_LadderDown || rTransitionID == ClimbLadder.TRANS_IdleTurn180L_LadderTopOn || rTransitionID == ClimbLadder.TRANS_JumpToClimb_LadderPose;
		}

		// Token: 0x06000E09 RID: 3593 RVA: 0x00047750 File Offset: 0x00045950
		public override void LoadAnimatorData()
		{
			ClimbLadder.TRANS_EntryState_LadderBottomOn = this.mMotionController.AddAnimatorName("Entry -> Base Layer.ClimbLadder-SM.LadderBottomOn");
			ClimbLadder.TRANS_AnyState_LadderBottomOn = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.ClimbLadder-SM.LadderBottomOn");
			ClimbLadder.TRANS_EntryState_IdleTurn180L = this.mMotionController.AddAnimatorName("Entry -> Base Layer.ClimbLadder-SM.IdleTurn180L");
			ClimbLadder.TRANS_AnyState_IdleTurn180L = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.ClimbLadder-SM.IdleTurn180L");
			ClimbLadder.TRANS_EntryState_LadderTopOn = this.mMotionController.AddAnimatorName("Entry -> Base Layer.ClimbLadder-SM.LadderTopOn");
			ClimbLadder.TRANS_AnyState_LadderTopOn = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.ClimbLadder-SM.LadderTopOn");
			ClimbLadder.TRANS_EntryState_JumpToClimb = this.mMotionController.AddAnimatorName("Entry -> Base Layer.ClimbLadder-SM.JumpToClimb");
			ClimbLadder.TRANS_AnyState_JumpToClimb = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.ClimbLadder-SM.JumpToClimb");
			ClimbLadder.STATE_LadderBottomOn = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.LadderBottomOn");
			ClimbLadder.TRANS_LadderBottomOn_LadderUp = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.LadderBottomOn -> Base Layer.ClimbLadder-SM.LadderUp");
			ClimbLadder.STATE_LadderUp = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.LadderUp");
			ClimbLadder.TRANS_LadderUp_LadderDown = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.LadderUp -> Base Layer.ClimbLadder-SM.LadderDown");
			ClimbLadder.TRANS_LadderUp_LadderPose = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.LadderUp -> Base Layer.ClimbLadder-SM.LadderPose");
			ClimbLadder.TRANS_LadderUp_ClimbToIdle = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.LadderUp -> Base Layer.ClimbLadder-SM.ClimbToIdle");
			ClimbLadder.STATE_LadderDown = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.LadderDown");
			ClimbLadder.TRANS_LadderDown_LadderBottomOff = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.LadderDown -> Base Layer.ClimbLadder-SM.LadderBottomOff");
			ClimbLadder.TRANS_LadderDown_LadderUp = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.LadderDown -> Base Layer.ClimbLadder-SM.LadderUp");
			ClimbLadder.TRANS_LadderDown_LadderPose = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.LadderDown -> Base Layer.ClimbLadder-SM.LadderPose");
			ClimbLadder.STATE_LadderBottomOff = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.LadderBottomOff");
			ClimbLadder.TRANS_LadderBottomOff_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.LadderBottomOff -> Base Layer.ClimbLadder-SM.IdlePose");
			ClimbLadder.STATE_LadderPose = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.LadderPose");
			ClimbLadder.TRANS_LadderPose_LadderDown = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.LadderPose -> Base Layer.ClimbLadder-SM.LadderDown");
			ClimbLadder.TRANS_LadderPose_LadderUp = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.LadderPose -> Base Layer.ClimbLadder-SM.LadderUp");
			ClimbLadder.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.IdlePose");
			ClimbLadder.STATE_ClimbToIdle = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.ClimbToIdle");
			ClimbLadder.TRANS_ClimbToIdle_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.ClimbToIdle -> Base Layer.ClimbLadder-SM.IdlePose");
			ClimbLadder.STATE_LadderTopOn = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.LadderTopOn");
			ClimbLadder.TRANS_LadderTopOn_LadderDown = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.LadderTopOn -> Base Layer.ClimbLadder-SM.LadderDown");
			ClimbLadder.STATE_IdleTurn180L = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.IdleTurn180L");
			ClimbLadder.TRANS_IdleTurn180L_LadderTopOn = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.IdleTurn180L -> Base Layer.ClimbLadder-SM.LadderTopOn");
			ClimbLadder.STATE_JumpToClimb = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.JumpToClimb");
			ClimbLadder.TRANS_JumpToClimb_LadderPose = this.mMotionController.AddAnimatorName("Base Layer.ClimbLadder-SM.JumpToClimb -> Base Layer.ClimbLadder-SM.LadderPose");
		}

		// Token: 0x040007E6 RID: 2022
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x040007E7 RID: 2023
		public const int PHASE_START = 1500;

		// Token: 0x040007E8 RID: 2024
		public const int PHASE_START_JUMP = 1504;

		// Token: 0x040007E9 RID: 2025
		public const int PHASE_START_TOP = 1505;

		// Token: 0x040007EA RID: 2026
		public const int PHASE_START_TOP_TURN = 1506;

		// Token: 0x040007EB RID: 2027
		public const int PHASE_EXIT_TOP = 1520;

		// Token: 0x040007EC RID: 2028
		public const int PHASE_EXIT_BOTTOM = 1510;

		// Token: 0x040007ED RID: 2029
		public float _MinDistance = 0.2f;

		// Token: 0x040007EE RID: 2030
		public float _MaxDistance = 0.75f;

		// Token: 0x040007EF RID: 2031
		public float _TopExitTestHeight = 1.6f;

		// Token: 0x040007F0 RID: 2032
		public float _DetachTestHeight = 1f;

		// Token: 0x040007F1 RID: 2033
		public float _MinGroundDistance = 1.3f;

		// Token: 0x040007F2 RID: 2034
		public float _MinRegrabDistance = 2f;

		// Token: 0x040007F3 RID: 2035
		public int _ClimbableLayers = 1;

		// Token: 0x040007F4 RID: 2036
		public float _ReachOffset1 = 0.35f;

		// Token: 0x040007F5 RID: 2037
		public float _ReachOffset2 = -0.8f;

		// Token: 0x040007F6 RID: 2038
		public float _ReachOffset3 = 0.25f;

		// Token: 0x040007F7 RID: 2039
		public float _ReachOffset4 = -1.55f;

		// Token: 0x040007F8 RID: 2040
		public float _ReachOffset5 = 0.3f;

		// Token: 0x040007F9 RID: 2041
		public float _ReachOffset6 = 0.02f;

		// Token: 0x040007FA RID: 2042
		public float _ReachOffset7 = 0.3f;

		// Token: 0x040007FB RID: 2043
		protected int mStartState = 1500;

		// Token: 0x040007FC RID: 2044
		protected GameObject mClimbable;

		// Token: 0x040007FD RID: 2045
		protected Vector3 mLocalClimbableNormal = Vector3.zero;

		// Token: 0x040007FE RID: 2046
		protected float mFaceClimbableNormalAngle;

		// Token: 0x040007FF RID: 2047
		protected float mFaceClimbableNormalAngleUsed;

		// Token: 0x04000800 RID: 2048
		protected Vector3 mLastGrabPoint = Vector3.zero;

		// Token: 0x04000801 RID: 2049
		protected bool mIsExitTriggered;

		// Token: 0x04000802 RID: 2050
		protected int mStoredStance;

		// Token: 0x04000803 RID: 2051
		protected RaycastHit mRaycastHitInfo = RaycastExt.EmptyHitInfo;

		// Token: 0x04000804 RID: 2052
		public static int TRANS_EntryState_LadderBottomOn = -1;

		// Token: 0x04000805 RID: 2053
		public static int TRANS_AnyState_LadderBottomOn = -1;

		// Token: 0x04000806 RID: 2054
		public static int TRANS_EntryState_IdleTurn180L = -1;

		// Token: 0x04000807 RID: 2055
		public static int TRANS_AnyState_IdleTurn180L = -1;

		// Token: 0x04000808 RID: 2056
		public static int TRANS_EntryState_LadderTopOn = -1;

		// Token: 0x04000809 RID: 2057
		public static int TRANS_AnyState_LadderTopOn = -1;

		// Token: 0x0400080A RID: 2058
		public static int TRANS_EntryState_JumpToClimb = -1;

		// Token: 0x0400080B RID: 2059
		public static int TRANS_AnyState_JumpToClimb = -1;

		// Token: 0x0400080C RID: 2060
		public static int STATE_LadderBottomOn = -1;

		// Token: 0x0400080D RID: 2061
		public static int TRANS_LadderBottomOn_LadderUp = -1;

		// Token: 0x0400080E RID: 2062
		public static int STATE_LadderUp = -1;

		// Token: 0x0400080F RID: 2063
		public static int TRANS_LadderUp_LadderDown = -1;

		// Token: 0x04000810 RID: 2064
		public static int TRANS_LadderUp_LadderPose = -1;

		// Token: 0x04000811 RID: 2065
		public static int TRANS_LadderUp_ClimbToIdle = -1;

		// Token: 0x04000812 RID: 2066
		public static int STATE_LadderDown = -1;

		// Token: 0x04000813 RID: 2067
		public static int TRANS_LadderDown_LadderBottomOff = -1;

		// Token: 0x04000814 RID: 2068
		public static int TRANS_LadderDown_LadderUp = -1;

		// Token: 0x04000815 RID: 2069
		public static int TRANS_LadderDown_LadderPose = -1;

		// Token: 0x04000816 RID: 2070
		public static int STATE_LadderBottomOff = -1;

		// Token: 0x04000817 RID: 2071
		public static int TRANS_LadderBottomOff_IdlePose = -1;

		// Token: 0x04000818 RID: 2072
		public static int STATE_LadderPose = -1;

		// Token: 0x04000819 RID: 2073
		public static int TRANS_LadderPose_LadderDown = -1;

		// Token: 0x0400081A RID: 2074
		public static int TRANS_LadderPose_LadderUp = -1;

		// Token: 0x0400081B RID: 2075
		public static int STATE_IdlePose = -1;

		// Token: 0x0400081C RID: 2076
		public static int STATE_ClimbToIdle = -1;

		// Token: 0x0400081D RID: 2077
		public static int TRANS_ClimbToIdle_IdlePose = -1;

		// Token: 0x0400081E RID: 2078
		public static int STATE_LadderTopOn = -1;

		// Token: 0x0400081F RID: 2079
		public static int TRANS_LadderTopOn_LadderDown = -1;

		// Token: 0x04000820 RID: 2080
		public static int STATE_IdleTurn180L = -1;

		// Token: 0x04000821 RID: 2081
		public static int TRANS_IdleTurn180L_LadderTopOn = -1;

		// Token: 0x04000822 RID: 2082
		public static int STATE_JumpToClimb = -1;

		// Token: 0x04000823 RID: 2083
		public static int TRANS_JumpToClimb_LadderPose = -1;
	}
}
