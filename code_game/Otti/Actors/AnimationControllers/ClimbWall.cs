using System;
using com.ootii.Geometry;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000FA RID: 250
	[MotionName("Climb Wall")]
	[MotionDescription("Allows for climbing up and down walls.")]
	public class ClimbWall : MotionControllerMotion
	{
		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x06000E0B RID: 3595 RVA: 0x00047ACD File Offset: 0x00045CCD
		// (set) Token: 0x06000E0C RID: 3596 RVA: 0x00047AD5 File Offset: 0x00045CD5
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

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x06000E0D RID: 3597 RVA: 0x00047ADE File Offset: 0x00045CDE
		// (set) Token: 0x06000E0E RID: 3598 RVA: 0x00047AE6 File Offset: 0x00045CE6
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

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x06000E0F RID: 3599 RVA: 0x00047AEF File Offset: 0x00045CEF
		// (set) Token: 0x06000E10 RID: 3600 RVA: 0x00047AF7 File Offset: 0x00045CF7
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

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x06000E11 RID: 3601 RVA: 0x00047B00 File Offset: 0x00045D00
		// (set) Token: 0x06000E12 RID: 3602 RVA: 0x00047B08 File Offset: 0x00045D08
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

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x06000E13 RID: 3603 RVA: 0x00047B11 File Offset: 0x00045D11
		// (set) Token: 0x06000E14 RID: 3604 RVA: 0x00047B19 File Offset: 0x00045D19
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

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x06000E15 RID: 3605 RVA: 0x00047B22 File Offset: 0x00045D22
		// (set) Token: 0x06000E16 RID: 3606 RVA: 0x00047B2A File Offset: 0x00045D2A
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

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x06000E17 RID: 3607 RVA: 0x00047B33 File Offset: 0x00045D33
		// (set) Token: 0x06000E18 RID: 3608 RVA: 0x00047B3B File Offset: 0x00045D3B
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

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x06000E19 RID: 3609 RVA: 0x00047B44 File Offset: 0x00045D44
		// (set) Token: 0x06000E1A RID: 3610 RVA: 0x00047B4C File Offset: 0x00045D4C
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

		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x06000E1B RID: 3611 RVA: 0x00047B55 File Offset: 0x00045D55
		// (set) Token: 0x06000E1C RID: 3612 RVA: 0x00047B5D File Offset: 0x00045D5D
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

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x06000E1D RID: 3613 RVA: 0x00047B66 File Offset: 0x00045D66
		// (set) Token: 0x06000E1E RID: 3614 RVA: 0x00047B6E File Offset: 0x00045D6E
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

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x06000E1F RID: 3615 RVA: 0x00047B77 File Offset: 0x00045D77
		// (set) Token: 0x06000E20 RID: 3616 RVA: 0x00047B7F File Offset: 0x00045D7F
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

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x06000E21 RID: 3617 RVA: 0x00047B88 File Offset: 0x00045D88
		// (set) Token: 0x06000E22 RID: 3618 RVA: 0x00047B90 File Offset: 0x00045D90
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

		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x06000E23 RID: 3619 RVA: 0x00047B99 File Offset: 0x00045D99
		// (set) Token: 0x06000E24 RID: 3620 RVA: 0x00047BA1 File Offset: 0x00045DA1
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

		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x06000E25 RID: 3621 RVA: 0x00047BAA File Offset: 0x00045DAA
		// (set) Token: 0x06000E26 RID: 3622 RVA: 0x00047BB2 File Offset: 0x00045DB2
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

		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x06000E27 RID: 3623 RVA: 0x00047BBB File Offset: 0x00045DBB
		// (set) Token: 0x06000E28 RID: 3624 RVA: 0x00047BC3 File Offset: 0x00045DC3
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

		// Token: 0x06000E29 RID: 3625 RVA: 0x00047BCC File Offset: 0x00045DCC
		public ClimbWall()
		{
			this._Category = 10;
			this._Priority = 20f;
			this._ActionAlias = "Jump";
			this._OverrideLayers = true;
			this.mIsStartable = true;
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x00047CD8 File Offset: 0x00045ED8
		public ClimbWall(MotionController rController)
			: base(rController)
		{
			this._Category = 10;
			this._Priority = 20f;
			this._ActionAlias = "Jump";
			this._OverrideLayers = true;
			this.mIsStartable = true;
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x00047DE8 File Offset: 0x00045FE8
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
						this.mStartState = 1600;
						return true;
					}
					if (this.TestForClimbDownBack())
					{
						this.mStartState = 1605;
						return true;
					}
					if (this.TestForClimbDownForward())
					{
						this.mStartState = 1606;
						return true;
					}
				}
			}
			else if (this.TestForClimbInAir())
			{
				this.mStartState = 1604;
				return true;
			}
			return false;
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x00047E9E File Offset: 0x0004609E
		public override bool TestUpdate()
		{
			return !this.mIsAnimatorActive || this.IsInMotionState;
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x00047EB4 File Offset: 0x000460B4
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			if (this.mRaycastHitInfo.collider == null)
			{
				return false;
			}
			this.mIsExitTriggered = false;
			this.mStoredStance = this.mActorController.State.Stance;
			this.mActorController.State.Stance = 7;
			this.mClimbable = this.mRaycastHitInfo.collider.gameObject;
			this.mLocalClimbableNormal = this.mClimbable.transform.InverseTransformDirection(this.mRaycastHitInfo.normal);
			Vector3 vector = Quaternion.AngleAxis(180f, this.mActorController._Transform.up) * this.mRaycastHitInfo.normal;
			this.mFaceClimbableNormalAngle = this.mActorController._Transform.forward.HorizontalAngleTo(vector, this.mActorController._Transform.up);
			this.mFaceClimbableNormalAngleUsed = 0f;
			this.ClearReachData();
			if (this.mStartState == 1600)
			{
				MotionReachData motionReachData = MotionReachData.Allocate();
				motionReachData.StateID = ClimbWall.STATE_ScaleWallBottomOn;
				motionReachData.StartTime = 0f;
				motionReachData.EndTime = 0.9f;
				motionReachData.Power = 3;
				motionReachData.ReachTarget = this.mRaycastHitInfo.point - this.mActorController._Transform.up * this._MinHeight + this.mRaycastHitInfo.normal * this._ReachOffset1;
				motionReachData.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData);
			}
			else if (this.mStartState == 1605)
			{
				MotionReachData motionReachData2 = MotionReachData.Allocate();
				motionReachData2.StateID = ClimbWall.STATE_ScaleWallTopOn;
				motionReachData2.StartTime = 0.4f;
				motionReachData2.EndTime = 0.7f;
				motionReachData2.Power = 4;
				motionReachData2.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.up * this.mActorController._MaxStepHeight + this.mActorController._Transform.up * this._ReachOffset2 + this.mRaycastHitInfo.normal * this._ReachOffset3;
				motionReachData2.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData2);
				motionReachData2 = MotionReachData.Allocate();
				motionReachData2.StateID = ClimbWall.STATE_ScaleWallTopOn;
				motionReachData2.StartTime = 0.75f;
				motionReachData2.EndTime = 0.9f;
				motionReachData2.Power = 3;
				motionReachData2.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.up * this.mActorController._MaxStepHeight + this.mActorController._Transform.up * this._ReachOffset4 + this.mRaycastHitInfo.normal * this._ReachOffset5;
				motionReachData2.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData2);
			}
			else if (this.mStartState == 1606)
			{
				MotionReachData motionReachData3 = MotionReachData.Allocate();
				motionReachData3.StateID = ClimbWall.STATE_ScaleWallTopOn;
				motionReachData3.StartTime = 0.5f;
				motionReachData3.EndTime = 0.7f;
				motionReachData3.Power = 4;
				motionReachData3.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.up * this.mActorController._MaxStepHeight + this.mActorController._Transform.up * this._ReachOffset2 + this.mRaycastHitInfo.normal * this._ReachOffset3;
				motionReachData3.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData3);
				motionReachData3 = MotionReachData.Allocate();
				motionReachData3.StateID = ClimbWall.STATE_ScaleWallTopOn;
				motionReachData3.StartTime = 0.75f;
				motionReachData3.EndTime = 0.9f;
				motionReachData3.Power = 3;
				motionReachData3.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.up * this.mActorController._MaxStepHeight + this.mActorController._Transform.up * this._ReachOffset4 + this.mRaycastHitInfo.normal * this._ReachOffset5;
				motionReachData3.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData3);
			}
			else if (this.mStartState == 1604)
			{
				MotionReachData motionReachData4 = MotionReachData.Allocate();
				motionReachData4.TransitionID = ClimbWall.TRANS_EntryState_JumpToClimb;
				motionReachData4.StartTime = 0f;
				motionReachData4.EndTime = 0.95f;
				motionReachData4.Power = 2;
				motionReachData4.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.up * this.mActorController._MaxStepHeight + this.mRaycastHitInfo.normal * 0.55f + this.mActorController._Transform.up * -0.7f;
				motionReachData4.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData4);
				motionReachData4 = MotionReachData.Allocate();
				motionReachData4.StateID = ClimbWall.STATE_JumpToClimb;
				motionReachData4.StartTime = 0f;
				motionReachData4.EndTime = 0.4f;
				motionReachData4.Power = 2;
				motionReachData4.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.up * this.mActorController._MaxStepHeight + this.mRaycastHitInfo.normal * 0.55f + this.mActorController._Transform.up * -0.65f;
				motionReachData4.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData4);
				motionReachData4 = MotionReachData.Allocate();
				motionReachData4.StateID = ClimbWall.STATE_JumpToClimb;
				motionReachData4.StartTime = 0.5f;
				motionReachData4.EndTime = 0.7f;
				motionReachData4.Power = 4;
				motionReachData4.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.up * this.mActorController._MaxStepHeight + this.mRaycastHitInfo.normal * 0.55f + this.mActorController._Transform.up * -0.65f;
				motionReachData4.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData4);
				motionReachData4 = MotionReachData.Allocate();
				motionReachData4.StateID = ClimbWall.STATE_JumpToClimb;
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

		// Token: 0x06000E2E RID: 3630 RVA: 0x0004870C File Offset: 0x0004690C
		public override void Deactivate()
		{
			this.mClimbable = null;
			if (this.mActorController.State.Stance == 7)
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

		// Token: 0x06000E2F RID: 3631 RVA: 0x0004878B File Offset: 0x0004698B
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rVelocityDelta, ref Quaternion rRotationDelta)
		{
			if (this.mMotionLayer._AnimatorStateID != ClimbWall.STATE_IdleTurn180L)
			{
				rRotationDelta = Quaternion.identity;
			}
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x000487AC File Offset: 0x000469AC
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
			if ((animatorStateID == ClimbWall.STATE_ScaleWallPose || animatorStateID == ClimbWall.STATE_ScaleWallUp || animatorStateID == ClimbWall.STATE_ScaleWallDown) && ((this._ActionAlias.Length > 0 && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias)) || this.mMotionController._InputSource.IsJustPressed("Jump")))
			{
				this.mLastGrabPoint = this.mActorController._Transform.position;
				this.Deactivate();
				return;
			}
			if (animatorStateID == ClimbWall.STATE_IdleTurn180L)
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
			else
			{
				if (animatorStateID == ClimbWall.STATE_JumpToClimb)
				{
					this.mRotation = this.GetReachRotation(0.6f, 0.9f, this.mFaceClimbableNormalAngle, ref this.mFaceClimbableNormalAngleUsed);
					return;
				}
				if (animatorStateID == ClimbWall.STATE_ScaleWallTopOn)
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
					if (animatorStateID == ClimbWall.STATE_ScaleWallBottomOn)
					{
						this.mRotation = this.GetReachRotation(0.2f, 0.8f, this.mFaceClimbableNormalAngle, ref this.mFaceClimbableNormalAngleUsed);
						return;
					}
					if (animatorStateID == ClimbWall.STATE_ScaleWallUp)
					{
						if (!this.mIsExitTriggered && this.TestForTopExit())
						{
							this.mIsExitTriggered = true;
							MotionReachData motionReachData = MotionReachData.Allocate();
							motionReachData = MotionReachData.Allocate();
							motionReachData.StateID = ClimbWall.STATE_ClimbToIdle;
							motionReachData.StartTime = 0.4f;
							motionReachData.EndTime = 0.55f;
							motionReachData.Power = 4;
							motionReachData.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.up * this._ReachOffset6 + this.mActorController._Transform.forward * this._ReachOffset7;
							motionReachData.ReachTargetGround = this.mActorController.State.Ground;
							this.mReachData.Add(motionReachData);
							this.mActorController.IsCollsionEnabled = false;
							this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 1620, true);
						}
						if (!this.mIsExitTriggered)
						{
							this.mActorController.IsCollsionEnabled = true;
							if (!RaycastExt.SafeRaycast(this.mActorController._Transform.position + this.mActorController._Transform.up * this._DetachTestHeight, this.mMotionController._Transform.forward, out this.mRaycastHitInfo, this._MaxDistance, this._ClimbableLayers, this.mActorController._Transform, null, true, false))
							{
								this.Deactivate();
								return;
							}
						}
					}
					else if (animatorStateID == ClimbWall.STATE_ScaleWallDown)
					{
						this.mActorController.IsCollsionEnabled = true;
						if (!this.mIsExitTriggered && this.mActorController.State.Ground != null && this.mActorController.State.GroundSurfaceDirectDistance > 0f && this.mActorController.State.GroundSurfaceDirectDistance < 0.2f)
						{
							this.mIsExitTriggered = true;
							this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 1610, true);
						}
						if (!this.mIsExitTriggered && !RaycastExt.SafeRaycast(this.mActorController._Transform.position + this.mActorController._Transform.up * this._DetachTestHeight, this.mMotionController._Transform.forward, out this.mRaycastHitInfo, this._MaxDistance, this._ClimbableLayers, this.mActorController._Transform, null, true, false))
						{
							this.Deactivate();
							return;
						}
					}
					else if (animatorStateID == ClimbWall.STATE_IdlePose)
					{
						this.Deactivate();
					}
				}
			}
		}

		// Token: 0x06000E31 RID: 3633 RVA: 0x00048C3C File Offset: 0x00046E3C
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

		// Token: 0x06000E32 RID: 3634 RVA: 0x00048D68 File Offset: 0x00046F68
		public virtual bool TestForClimbUp()
		{
			if (Mathf.Abs(this.mMotionController._InputSource.InputFromAvatarAngle) > 100f)
			{
				return false;
			}
			Vector3 vector = this.mActorController._Transform.position + this.mActorController._Transform.up * this.mActorController._MaxStepHeight;
			Vector3 forward = this.mMotionController._Transform.forward;
			float maxDistance = this._MaxDistance;
			return RaycastExt.SafeRaycast(vector, forward, out this.mRaycastHitInfo, maxDistance, this._ClimbableLayers, this.mActorController._Transform, null, true, false) && RaycastExt.SafeRaycast(this.mActorController._Transform.position + this.mActorController._Transform.up * this._MinHeight, forward, out this.mRaycastHitInfo, maxDistance, this._ClimbableLayers, this.mActorController._Transform, null, true, false) && this.mRaycastHitInfo.distance >= this._MinDistance && this.mRaycastHitInfo.distance <= this._MaxDistance;
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x00048E84 File Offset: 0x00047084
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

		// Token: 0x06000E34 RID: 3636 RVA: 0x00049050 File Offset: 0x00047250
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

		// Token: 0x06000E35 RID: 3637 RVA: 0x00049218 File Offset: 0x00047418
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

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x06000E36 RID: 3638 RVA: 0x0004939C File Offset: 0x0004759C
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == ClimbWall.STATE_ScaleWallBottomOn || animatorStateID == ClimbWall.STATE_ScaleWallUp || animatorStateID == ClimbWall.STATE_ScaleWallDown || animatorStateID == ClimbWall.STATE_ScaleWallBottomOff || animatorStateID == ClimbWall.STATE_ScaleWallPose || animatorStateID == ClimbWall.STATE_IdlePose || animatorStateID == ClimbWall.STATE_ClimbToIdle || animatorStateID == ClimbWall.STATE_ScaleWallTopOn || animatorStateID == ClimbWall.STATE_IdleTurn180L || animatorStateID == ClimbWall.STATE_JumpToClimb || animatorTransitionID == ClimbWall.TRANS_EntryState_ScaleWallBottomOn || animatorTransitionID == ClimbWall.TRANS_AnyState_ScaleWallBottomOn || animatorTransitionID == ClimbWall.TRANS_EntryState_ScaleWallTopOn || animatorTransitionID == ClimbWall.TRANS_AnyState_ScaleWallTopOn || animatorTransitionID == ClimbWall.TRANS_EntryState_IdleTurn180L || animatorTransitionID == ClimbWall.TRANS_AnyState_IdleTurn180L || animatorTransitionID == ClimbWall.TRANS_EntryState_JumpToClimb || animatorTransitionID == ClimbWall.TRANS_AnyState_JumpToClimb || animatorTransitionID == ClimbWall.TRANS_ScaleWallBottomOn_ScaleWallUp || animatorTransitionID == ClimbWall.TRANS_ScaleWallUp_ScaleWallDown || animatorTransitionID == ClimbWall.TRANS_ScaleWallUp_ScaleWallPose || animatorTransitionID == ClimbWall.TRANS_ScaleWallUp_ClimbToIdle || animatorTransitionID == ClimbWall.TRANS_ScaleWallDown_ScaleWallBottomOff || animatorTransitionID == ClimbWall.TRANS_ScaleWallDown_ScaleWallUp || animatorTransitionID == ClimbWall.TRANS_ScaleWallDown_ScaleWallPose || animatorTransitionID == ClimbWall.TRANS_ScaleWallBottomOff_IdlePose || animatorTransitionID == ClimbWall.TRANS_ScaleWallPose_ScaleWallDown || animatorTransitionID == ClimbWall.TRANS_ScaleWallPose_ScaleWallUp || animatorTransitionID == ClimbWall.TRANS_ClimbToIdle_IdlePose || animatorTransitionID == ClimbWall.TRANS_ScaleWallTopOn_ScaleWallDown || animatorTransitionID == ClimbWall.TRANS_IdleTurn180L_ScaleWallTopOn || animatorTransitionID == ClimbWall.TRANS_JumpToClimb_ScaleWallPose;
			}
		}

		// Token: 0x06000E37 RID: 3639 RVA: 0x00049504 File Offset: 0x00047704
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == ClimbWall.STATE_ScaleWallBottomOn || rStateID == ClimbWall.STATE_ScaleWallUp || rStateID == ClimbWall.STATE_ScaleWallDown || rStateID == ClimbWall.STATE_ScaleWallBottomOff || rStateID == ClimbWall.STATE_ScaleWallPose || rStateID == ClimbWall.STATE_IdlePose || rStateID == ClimbWall.STATE_ClimbToIdle || rStateID == ClimbWall.STATE_ScaleWallTopOn || rStateID == ClimbWall.STATE_IdleTurn180L || rStateID == ClimbWall.STATE_JumpToClimb;
		}

		// Token: 0x06000E38 RID: 3640 RVA: 0x00049578 File Offset: 0x00047778
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == ClimbWall.STATE_ScaleWallBottomOn || rStateID == ClimbWall.STATE_ScaleWallUp || rStateID == ClimbWall.STATE_ScaleWallDown || rStateID == ClimbWall.STATE_ScaleWallBottomOff || rStateID == ClimbWall.STATE_ScaleWallPose || rStateID == ClimbWall.STATE_IdlePose || rStateID == ClimbWall.STATE_ClimbToIdle || rStateID == ClimbWall.STATE_ScaleWallTopOn || rStateID == ClimbWall.STATE_IdleTurn180L || rStateID == ClimbWall.STATE_JumpToClimb || rTransitionID == ClimbWall.TRANS_EntryState_ScaleWallBottomOn || rTransitionID == ClimbWall.TRANS_AnyState_ScaleWallBottomOn || rTransitionID == ClimbWall.TRANS_EntryState_ScaleWallTopOn || rTransitionID == ClimbWall.TRANS_AnyState_ScaleWallTopOn || rTransitionID == ClimbWall.TRANS_EntryState_IdleTurn180L || rTransitionID == ClimbWall.TRANS_AnyState_IdleTurn180L || rTransitionID == ClimbWall.TRANS_EntryState_JumpToClimb || rTransitionID == ClimbWall.TRANS_AnyState_JumpToClimb || rTransitionID == ClimbWall.TRANS_ScaleWallBottomOn_ScaleWallUp || rTransitionID == ClimbWall.TRANS_ScaleWallUp_ScaleWallDown || rTransitionID == ClimbWall.TRANS_ScaleWallUp_ScaleWallPose || rTransitionID == ClimbWall.TRANS_ScaleWallUp_ClimbToIdle || rTransitionID == ClimbWall.TRANS_ScaleWallDown_ScaleWallBottomOff || rTransitionID == ClimbWall.TRANS_ScaleWallDown_ScaleWallUp || rTransitionID == ClimbWall.TRANS_ScaleWallDown_ScaleWallPose || rTransitionID == ClimbWall.TRANS_ScaleWallBottomOff_IdlePose || rTransitionID == ClimbWall.TRANS_ScaleWallPose_ScaleWallDown || rTransitionID == ClimbWall.TRANS_ScaleWallPose_ScaleWallUp || rTransitionID == ClimbWall.TRANS_ClimbToIdle_IdlePose || rTransitionID == ClimbWall.TRANS_ScaleWallTopOn_ScaleWallDown || rTransitionID == ClimbWall.TRANS_IdleTurn180L_ScaleWallTopOn || rTransitionID == ClimbWall.TRANS_JumpToClimb_ScaleWallPose;
		}

		// Token: 0x06000E39 RID: 3641 RVA: 0x000496C8 File Offset: 0x000478C8
		public override void LoadAnimatorData()
		{
			ClimbWall.TRANS_EntryState_ScaleWallBottomOn = this.mMotionController.AddAnimatorName("Entry -> Base Layer.ClimbWall-SM.ScaleWallBottomOn");
			ClimbWall.TRANS_AnyState_ScaleWallBottomOn = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.ClimbWall-SM.ScaleWallBottomOn");
			ClimbWall.TRANS_EntryState_ScaleWallTopOn = this.mMotionController.AddAnimatorName("Entry -> Base Layer.ClimbWall-SM.ScaleWallTopOn");
			ClimbWall.TRANS_AnyState_ScaleWallTopOn = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.ClimbWall-SM.ScaleWallTopOn");
			ClimbWall.TRANS_EntryState_IdleTurn180L = this.mMotionController.AddAnimatorName("Entry -> Base Layer.ClimbWall-SM.IdleTurn180L");
			ClimbWall.TRANS_AnyState_IdleTurn180L = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.ClimbWall-SM.IdleTurn180L");
			ClimbWall.TRANS_EntryState_JumpToClimb = this.mMotionController.AddAnimatorName("Entry -> Base Layer.ClimbWall-SM.JumpToClimb");
			ClimbWall.TRANS_AnyState_JumpToClimb = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.ClimbWall-SM.JumpToClimb");
			ClimbWall.STATE_ScaleWallBottomOn = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.ScaleWallBottomOn");
			ClimbWall.TRANS_ScaleWallBottomOn_ScaleWallUp = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.ScaleWallBottomOn -> Base Layer.ClimbWall-SM.ScaleWallUp");
			ClimbWall.STATE_ScaleWallUp = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.ScaleWallUp");
			ClimbWall.TRANS_ScaleWallUp_ScaleWallDown = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.ScaleWallUp -> Base Layer.ClimbWall-SM.ScaleWallDown");
			ClimbWall.TRANS_ScaleWallUp_ScaleWallPose = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.ScaleWallUp -> Base Layer.ClimbWall-SM.ScaleWallPose");
			ClimbWall.TRANS_ScaleWallUp_ClimbToIdle = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.ScaleWallUp -> Base Layer.ClimbWall-SM.ClimbToIdle");
			ClimbWall.STATE_ScaleWallDown = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.ScaleWallDown");
			ClimbWall.TRANS_ScaleWallDown_ScaleWallBottomOff = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.ScaleWallDown -> Base Layer.ClimbWall-SM.ScaleWallBottomOff");
			ClimbWall.TRANS_ScaleWallDown_ScaleWallUp = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.ScaleWallDown -> Base Layer.ClimbWall-SM.ScaleWallUp");
			ClimbWall.TRANS_ScaleWallDown_ScaleWallPose = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.ScaleWallDown -> Base Layer.ClimbWall-SM.ScaleWallPose");
			ClimbWall.STATE_ScaleWallBottomOff = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.ScaleWallBottomOff");
			ClimbWall.TRANS_ScaleWallBottomOff_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.ScaleWallBottomOff -> Base Layer.ClimbWall-SM.IdlePose");
			ClimbWall.STATE_ScaleWallPose = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.ScaleWallPose");
			ClimbWall.TRANS_ScaleWallPose_ScaleWallDown = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.ScaleWallPose -> Base Layer.ClimbWall-SM.ScaleWallDown");
			ClimbWall.TRANS_ScaleWallPose_ScaleWallUp = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.ScaleWallPose -> Base Layer.ClimbWall-SM.ScaleWallUp");
			ClimbWall.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.IdlePose");
			ClimbWall.STATE_ClimbToIdle = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.ClimbToIdle");
			ClimbWall.TRANS_ClimbToIdle_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.ClimbToIdle -> Base Layer.ClimbWall-SM.IdlePose");
			ClimbWall.STATE_ScaleWallTopOn = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.ScaleWallTopOn");
			ClimbWall.TRANS_ScaleWallTopOn_ScaleWallDown = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.ScaleWallTopOn -> Base Layer.ClimbWall-SM.ScaleWallDown");
			ClimbWall.STATE_IdleTurn180L = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.IdleTurn180L");
			ClimbWall.TRANS_IdleTurn180L_ScaleWallTopOn = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.IdleTurn180L -> Base Layer.ClimbWall-SM.ScaleWallTopOn");
			ClimbWall.STATE_JumpToClimb = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.JumpToClimb");
			ClimbWall.TRANS_JumpToClimb_ScaleWallPose = this.mMotionController.AddAnimatorName("Base Layer.ClimbWall-SM.JumpToClimb -> Base Layer.ClimbWall-SM.ScaleWallPose");
		}

		// Token: 0x04000824 RID: 2084
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000825 RID: 2085
		public const int PHASE_START = 1600;

		// Token: 0x04000826 RID: 2086
		public const int PHASE_START_JUMP = 1604;

		// Token: 0x04000827 RID: 2087
		public const int PHASE_START_TOP = 1605;

		// Token: 0x04000828 RID: 2088
		public const int PHASE_START_TOP_TURN = 1606;

		// Token: 0x04000829 RID: 2089
		public const int PHASE_EXIT_TOP = 1620;

		// Token: 0x0400082A RID: 2090
		public const int PHASE_EXIT_BOTTOM = 1610;

		// Token: 0x0400082B RID: 2091
		public float _MinHeight = 2f;

		// Token: 0x0400082C RID: 2092
		public float _MinDistance = 0.2f;

		// Token: 0x0400082D RID: 2093
		public float _MaxDistance = 0.75f;

		// Token: 0x0400082E RID: 2094
		public float _TopExitTestHeight = 1.6f;

		// Token: 0x0400082F RID: 2095
		public float _DetachTestHeight = 1f;

		// Token: 0x04000830 RID: 2096
		public float _MinGroundDistance = 1.3f;

		// Token: 0x04000831 RID: 2097
		public float _MinRegrabDistance = 2f;

		// Token: 0x04000832 RID: 2098
		public int _ClimbableLayers = 1;

		// Token: 0x04000833 RID: 2099
		public float _ReachOffset1 = 0.35f;

		// Token: 0x04000834 RID: 2100
		public float _ReachOffset2 = -0.8f;

		// Token: 0x04000835 RID: 2101
		public float _ReachOffset3 = 0.25f;

		// Token: 0x04000836 RID: 2102
		public float _ReachOffset4 = -1.55f;

		// Token: 0x04000837 RID: 2103
		public float _ReachOffset5 = 0.3f;

		// Token: 0x04000838 RID: 2104
		public float _ReachOffset6 = 0.02f;

		// Token: 0x04000839 RID: 2105
		public float _ReachOffset7 = 0.3f;

		// Token: 0x0400083A RID: 2106
		protected int mStartState = 1600;

		// Token: 0x0400083B RID: 2107
		protected GameObject mClimbable;

		// Token: 0x0400083C RID: 2108
		protected Vector3 mLocalClimbableNormal = Vector3.zero;

		// Token: 0x0400083D RID: 2109
		protected float mFaceClimbableNormalAngle;

		// Token: 0x0400083E RID: 2110
		protected float mFaceClimbableNormalAngleUsed;

		// Token: 0x0400083F RID: 2111
		protected Vector3 mLastGrabPoint = Vector3.zero;

		// Token: 0x04000840 RID: 2112
		protected bool mIsExitTriggered;

		// Token: 0x04000841 RID: 2113
		protected int mStoredStance;

		// Token: 0x04000842 RID: 2114
		protected RaycastHit mRaycastHitInfo = RaycastExt.EmptyHitInfo;

		// Token: 0x04000843 RID: 2115
		public static int TRANS_EntryState_ScaleWallBottomOn = -1;

		// Token: 0x04000844 RID: 2116
		public static int TRANS_AnyState_ScaleWallBottomOn = -1;

		// Token: 0x04000845 RID: 2117
		public static int TRANS_EntryState_ScaleWallTopOn = -1;

		// Token: 0x04000846 RID: 2118
		public static int TRANS_AnyState_ScaleWallTopOn = -1;

		// Token: 0x04000847 RID: 2119
		public static int TRANS_EntryState_IdleTurn180L = -1;

		// Token: 0x04000848 RID: 2120
		public static int TRANS_AnyState_IdleTurn180L = -1;

		// Token: 0x04000849 RID: 2121
		public static int TRANS_EntryState_JumpToClimb = -1;

		// Token: 0x0400084A RID: 2122
		public static int TRANS_AnyState_JumpToClimb = -1;

		// Token: 0x0400084B RID: 2123
		public static int STATE_ScaleWallBottomOn = -1;

		// Token: 0x0400084C RID: 2124
		public static int TRANS_ScaleWallBottomOn_ScaleWallUp = -1;

		// Token: 0x0400084D RID: 2125
		public static int STATE_ScaleWallUp = -1;

		// Token: 0x0400084E RID: 2126
		public static int TRANS_ScaleWallUp_ScaleWallDown = -1;

		// Token: 0x0400084F RID: 2127
		public static int TRANS_ScaleWallUp_ScaleWallPose = -1;

		// Token: 0x04000850 RID: 2128
		public static int TRANS_ScaleWallUp_ClimbToIdle = -1;

		// Token: 0x04000851 RID: 2129
		public static int STATE_ScaleWallDown = -1;

		// Token: 0x04000852 RID: 2130
		public static int TRANS_ScaleWallDown_ScaleWallBottomOff = -1;

		// Token: 0x04000853 RID: 2131
		public static int TRANS_ScaleWallDown_ScaleWallUp = -1;

		// Token: 0x04000854 RID: 2132
		public static int TRANS_ScaleWallDown_ScaleWallPose = -1;

		// Token: 0x04000855 RID: 2133
		public static int STATE_ScaleWallBottomOff = -1;

		// Token: 0x04000856 RID: 2134
		public static int TRANS_ScaleWallBottomOff_IdlePose = -1;

		// Token: 0x04000857 RID: 2135
		public static int STATE_ScaleWallPose = -1;

		// Token: 0x04000858 RID: 2136
		public static int TRANS_ScaleWallPose_ScaleWallDown = -1;

		// Token: 0x04000859 RID: 2137
		public static int TRANS_ScaleWallPose_ScaleWallUp = -1;

		// Token: 0x0400085A RID: 2138
		public static int STATE_IdlePose = -1;

		// Token: 0x0400085B RID: 2139
		public static int STATE_ClimbToIdle = -1;

		// Token: 0x0400085C RID: 2140
		public static int TRANS_ClimbToIdle_IdlePose = -1;

		// Token: 0x0400085D RID: 2141
		public static int STATE_ScaleWallTopOn = -1;

		// Token: 0x0400085E RID: 2142
		public static int TRANS_ScaleWallTopOn_ScaleWallDown = -1;

		// Token: 0x0400085F RID: 2143
		public static int STATE_IdleTurn180L = -1;

		// Token: 0x04000860 RID: 2144
		public static int TRANS_IdleTurn180L_ScaleWallTopOn = -1;

		// Token: 0x04000861 RID: 2145
		public static int STATE_JumpToClimb = -1;

		// Token: 0x04000862 RID: 2146
		public static int TRANS_JumpToClimb_ScaleWallPose = -1;
	}
}
