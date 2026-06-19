using System;
using com.ootii.Actors.Navigation;
using com.ootii.Geometry;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000FE RID: 254
	[MotionName("Climb 2.5 Meters")]
	[MotionDescription("Scaling climb that allows the actor to go up a 2.5m high wall. The best distance from the wall is 1.32m")]
	public class Climb_2_5m : MotionControllerMotion
	{
		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x06000E98 RID: 3736 RVA: 0x0004B5E2 File Offset: 0x000497E2
		// (set) Token: 0x06000E99 RID: 3737 RVA: 0x0004B5EA File Offset: 0x000497EA
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

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x06000E9A RID: 3738 RVA: 0x0004B5F3 File Offset: 0x000497F3
		// (set) Token: 0x06000E9B RID: 3739 RVA: 0x0004B5FB File Offset: 0x000497FB
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

		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x06000E9C RID: 3740 RVA: 0x0004B604 File Offset: 0x00049804
		// (set) Token: 0x06000E9D RID: 3741 RVA: 0x0004B60C File Offset: 0x0004980C
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

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x06000E9E RID: 3742 RVA: 0x0004B615 File Offset: 0x00049815
		// (set) Token: 0x06000E9F RID: 3743 RVA: 0x0004B61D File Offset: 0x0004981D
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

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x06000EA0 RID: 3744 RVA: 0x0004B626 File Offset: 0x00049826
		// (set) Token: 0x06000EA1 RID: 3745 RVA: 0x0004B62E File Offset: 0x0004982E
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

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06000EA2 RID: 3746 RVA: 0x0004B637 File Offset: 0x00049837
		// (set) Token: 0x06000EA3 RID: 3747 RVA: 0x0004B63F File Offset: 0x0004983F
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

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x06000EA4 RID: 3748 RVA: 0x0004B648 File Offset: 0x00049848
		// (set) Token: 0x06000EA5 RID: 3749 RVA: 0x0004B650 File Offset: 0x00049850
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

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x06000EA6 RID: 3750 RVA: 0x0004B659 File Offset: 0x00049859
		// (set) Token: 0x06000EA7 RID: 3751 RVA: 0x0004B661 File Offset: 0x00049861
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

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x06000EA8 RID: 3752 RVA: 0x0004B66A File Offset: 0x0004986A
		// (set) Token: 0x06000EA9 RID: 3753 RVA: 0x0004B672 File Offset: 0x00049872
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

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x06000EAA RID: 3754 RVA: 0x0004B67B File Offset: 0x0004987B
		// (set) Token: 0x06000EAB RID: 3755 RVA: 0x0004B683 File Offset: 0x00049883
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

		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x06000EAC RID: 3756 RVA: 0x0004B68C File Offset: 0x0004988C
		// (set) Token: 0x06000EAD RID: 3757 RVA: 0x0004B694 File Offset: 0x00049894
		public Vector3 ReachOffset5
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

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x06000EAE RID: 3758 RVA: 0x0004B69D File Offset: 0x0004989D
		// (set) Token: 0x06000EAF RID: 3759 RVA: 0x0004B6A5 File Offset: 0x000498A5
		public Vector3 ReachOffset6
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

		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x06000EB0 RID: 3760 RVA: 0x0004B6AE File Offset: 0x000498AE
		// (set) Token: 0x06000EB1 RID: 3761 RVA: 0x0004B6B6 File Offset: 0x000498B6
		public Vector3 ReachOffset7
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

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x06000EB2 RID: 3762 RVA: 0x0004B6BF File Offset: 0x000498BF
		// (set) Token: 0x06000EB3 RID: 3763 RVA: 0x0004B6C7 File Offset: 0x000498C7
		public Vector3 ReachOffset8
		{
			get
			{
				return this._ReachOffset8;
			}
			set
			{
				this._ReachOffset8 = value;
			}
		}

		// Token: 0x06000EB4 RID: 3764 RVA: 0x0004B6D0 File Offset: 0x000498D0
		public Climb_2_5m()
		{
			this._Category = 5;
			this._Priority = 30f;
			this._ActionAlias = "Jump";
			this._OverrideLayers = true;
			this.mIsStartable = true;
		}

		// Token: 0x06000EB5 RID: 3765 RVA: 0x0004B834 File Offset: 0x00049A34
		public Climb_2_5m(MotionController rController)
			: base(rController)
		{
			this._Category = 5;
			this._Priority = 30f;
			this._ActionAlias = "Jump";
			this._OverrideLayers = true;
			this.mIsStartable = true;
		}

		// Token: 0x06000EB6 RID: 3766 RVA: 0x0004B998 File Offset: 0x00049B98
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

		// Token: 0x06000EB7 RID: 3767 RVA: 0x0004BA48 File Offset: 0x00049C48
		public override bool TestUpdate()
		{
			if ((this.mIsAnimatorActive && !this.IsInMotionState) || this.mMotionLayer._AnimatorStateID == Climb_2_5m.STATE_IdlePose)
			{
				this.mActorController.IsGravityEnabled = true;
				this.mActorController.ForceGrounding = true;
				this.mActorController.FixGroundPenetration = true;
				this.mActorController.SetGround(null);
				return false;
			}
			return true;
		}

		// Token: 0x06000EB8 RID: 3768 RVA: 0x0004BAAC File Offset: 0x00049CAC
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
			BodyShape bodyShape = this.mActorController.GetBodyShape("Combatant Shape");
			if (bodyShape != null)
			{
				bodyShape.IsEnabledOnGround = false;
				bodyShape.IsEnabledOnSlope = false;
				bodyShape.IsEnabledAboveGround = false;
			}
			Vector3 vector = Quaternion.AngleAxis(180f, this.mActorController._Transform.up) * this.mRaycastHitInfo.normal;
			this.mFaceClimbableNormalAngle = this.mActorController._Transform.forward.HorizontalAngleTo(vector, this.mActorController._Transform.up);
			this.mFaceClimbableNormalAngleUsed = 0f;
			this.ClearReachData();
			if (this.mRaycastHitInfo.distance < 1f)
			{
				Quaternion rotation = this.mActorController._Transform.rotation;
				MotionReachData motionReachData = MotionReachData.Allocate();
				motionReachData.StateID = Climb_2_5m.STATE_StandClimb_2_5m;
				motionReachData.StartTime = 0.445f;
				motionReachData.EndTime = 0.524f;
				motionReachData.Power = 4;
				motionReachData.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.rotation * this._ReachOffset1 + rotation * this._ReachOffset2;
				motionReachData.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData);
				motionReachData = MotionReachData.Allocate();
				motionReachData.StateID = Climb_2_5m.STATE_StandClimb_2_5m;
				motionReachData.StartTime = 0.6f;
				motionReachData.EndTime = 0.8f;
				motionReachData.Power = 4;
				motionReachData.ReachTarget = this.mRaycastHitInfo.point + rotation * this._ReachOffset3;
				motionReachData.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData);
				motionReachData = MotionReachData.Allocate();
				motionReachData.StateID = Climb_2_5m.STATE_ClimbToIdle;
				motionReachData.StartTime = 0f;
				motionReachData.EndTime = 0.5f;
				motionReachData.Power = 4;
				motionReachData.ReachTarget = this.mRaycastHitInfo.point + rotation * this._ReachOffset4;
				motionReachData.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData);
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 1205, true);
			}
			else
			{
				Quaternion rotation2 = this.mActorController._Transform.rotation;
				MotionReachData motionReachData2 = MotionReachData.Allocate();
				motionReachData2.StateID = Climb_2_5m.STATE_Climb_2_5m;
				motionReachData2.StartTime = 0f;
				motionReachData2.EndTime = 0.1f;
				motionReachData2.Power = 3;
				motionReachData2.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.rotation * this._ReachOffset5 + rotation2 * new Vector3(0f, 0f, 0f);
				motionReachData2.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData2);
				motionReachData2 = MotionReachData.Allocate();
				motionReachData2.StateID = Climb_2_5m.STATE_Climb_2_5m;
				motionReachData2.StartTime = 0.1f;
				motionReachData2.EndTime = 0.216f;
				motionReachData2.Power = 3;
				motionReachData2.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.rotation * this._ReachOffset6 + rotation2 * new Vector3(0f, 0f, 0f);
				motionReachData2.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData2);
				motionReachData2 = MotionReachData.Allocate();
				motionReachData2.StateID = Climb_2_5m.STATE_Climb_2_5m;
				motionReachData2.StartTime = 0.24f;
				motionReachData2.EndTime = 0.42f;
				motionReachData2.Power = 4;
				motionReachData2.ReachTarget = this.mRaycastHitInfo.point + this.mActorController._Transform.rotation * this._ReachOffset7;
				motionReachData2.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData2);
				motionReachData2 = MotionReachData.Allocate();
				motionReachData2.StateID = Climb_2_5m.STATE_ClimbToIdle;
				motionReachData2.StartTime = 0f;
				motionReachData2.EndTime = 0.5f;
				motionReachData2.Power = 4;
				motionReachData2.ReachTarget = this.mRaycastHitInfo.point + rotation2 * this._ReachOffset8;
				motionReachData2.ReachTargetGround = this.mActorController.State.Ground;
				this.mReachData.Add(motionReachData2);
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 1200, true);
			}
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000EB9 RID: 3769 RVA: 0x0004C010 File Offset: 0x0004A210
		public override void Deactivate()
		{
			this.mClimbable = null;
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
			base.Deactivate();
		}

		// Token: 0x06000EBA RID: 3770 RVA: 0x0004C08F File Offset: 0x0004A28F
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rVelocityDelta, ref Quaternion rRotationDelta)
		{
			rRotationDelta = Quaternion.identity;
		}

		// Token: 0x06000EBB RID: 3771 RVA: 0x0004C0A0 File Offset: 0x0004A2A0
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
			if (animatorStateID == Climb_2_5m.STATE_StandClimb_2_5m)
			{
				this.mRotation = this.GetReachRotation(0.4f, 0.55f, this.mFaceClimbableNormalAngle, ref this.mFaceClimbableNormalAngleUsed);
				if (animatorStateNormalizedTime > 0.97f)
				{
					this.mActorController.IsCollsionEnabled = true;
					return;
				}
				if (animatorStateNormalizedTime > 0.6f)
				{
					this.mActorController.IsCollsionEnabled = false;
					return;
				}
			}
			else if (animatorStateID == Climb_2_5m.STATE_Climb_2_5m)
			{
				this.mRotation = this.GetReachRotation(0.1f, 0.21f, this.mFaceClimbableNormalAngle, ref this.mFaceClimbableNormalAngleUsed);
				if (animatorStateNormalizedTime > 0.65f)
				{
					this.mActorController.IsCollsionEnabled = true;
					return;
				}
				if (animatorStateNormalizedTime > 0.25f)
				{
					this.mActorController.IsCollsionEnabled = false;
					return;
				}
			}
			else if (animatorStateID == Climb_2_5m.STATE_ClimbToIdle)
			{
				this.mActorController.IsCollsionEnabled = true;
			}
		}

		// Token: 0x06000EBC RID: 3772 RVA: 0x0004C1C8 File Offset: 0x0004A3C8
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

		// Token: 0x06000EBD RID: 3773 RVA: 0x0004C228 File Offset: 0x0004A428
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
			RaycastHit raycastHit;
			if (!RaycastExt.SafeRaycast(this.mActorController._Transform.position + this.mActorController._Transform.up * this._MinHeight, this.mActorController._Transform.forward, out raycastHit, this._MaxDistance, this._ClimbableLayers, this.mActorController._Transform, null, true, false))
			{
				return false;
			}
			if (this._HandGrabOffset > 0f)
			{
				RaycastHit raycastHit2;
				if (!RaycastExt.SafeRaycast(this.mRaycastHitInfo.point + this.mRaycastHitInfo.normal * 1f + this.mActorController._Transform.rotation * new Vector3(this._HandGrabOffset, 0f, 0f), -this.mRaycastHitInfo.normal, out raycastHit2, 1.1f, this._ClimbableLayers, this.mActorController._Transform, null, true, false))
				{
					return false;
				}
				if (!RaycastExt.SafeRaycast(this.mRaycastHitInfo.point + this.mRaycastHitInfo.normal * 1f + this.mActorController._Transform.rotation * new Vector3(-this._HandGrabOffset, 0f, 0f), -this.mRaycastHitInfo.normal, out raycastHit2, 1.1f, this._ClimbableLayers, this.mActorController._Transform, null, true, false))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x06000EBE RID: 3774 RVA: 0x0004C468 File Offset: 0x0004A668
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == Climb_2_5m.STATE_IdlePose || animatorStateID == Climb_2_5m.STATE_Climb_2_5m || animatorStateID == Climb_2_5m.STATE_ClimbToIdle || animatorStateID == Climb_2_5m.STATE_StandClimb_2_5m || animatorTransitionID == Climb_2_5m.TRANS_EntryState_Climb_2_5m || animatorTransitionID == Climb_2_5m.TRANS_AnyState_Climb_2_5m || animatorTransitionID == Climb_2_5m.TRANS_EntryState_StandClimb_2_5m || animatorTransitionID == Climb_2_5m.TRANS_AnyState_StandClimb_2_5m || animatorTransitionID == Climb_2_5m.TRANS_Climb_2_5m_ClimbToIdle || animatorTransitionID == Climb_2_5m.TRANS_ClimbToIdle_IdlePose || animatorTransitionID == Climb_2_5m.TRANS_StandClimb_2_5m_ClimbToIdle;
			}
		}

		// Token: 0x06000EBF RID: 3775 RVA: 0x0004C4FC File Offset: 0x0004A6FC
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == Climb_2_5m.STATE_IdlePose || rStateID == Climb_2_5m.STATE_Climb_2_5m || rStateID == Climb_2_5m.STATE_ClimbToIdle || rStateID == Climb_2_5m.STATE_StandClimb_2_5m;
		}

		// Token: 0x06000EC0 RID: 3776 RVA: 0x0004C528 File Offset: 0x0004A728
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == Climb_2_5m.STATE_IdlePose || rStateID == Climb_2_5m.STATE_Climb_2_5m || rStateID == Climb_2_5m.STATE_ClimbToIdle || rStateID == Climb_2_5m.STATE_StandClimb_2_5m || rTransitionID == Climb_2_5m.TRANS_EntryState_Climb_2_5m || rTransitionID == Climb_2_5m.TRANS_AnyState_Climb_2_5m || rTransitionID == Climb_2_5m.TRANS_EntryState_StandClimb_2_5m || rTransitionID == Climb_2_5m.TRANS_AnyState_StandClimb_2_5m || rTransitionID == Climb_2_5m.TRANS_Climb_2_5m_ClimbToIdle || rTransitionID == Climb_2_5m.TRANS_ClimbToIdle_IdlePose || rTransitionID == Climb_2_5m.TRANS_StandClimb_2_5m_ClimbToIdle;
		}

		// Token: 0x06000EC1 RID: 3777 RVA: 0x0004C5A4 File Offset: 0x0004A7A4
		public override void LoadAnimatorData()
		{
			Climb_2_5m.TRANS_EntryState_Climb_2_5m = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Climb_2_5m-SM.Climb_2_5m");
			Climb_2_5m.TRANS_AnyState_Climb_2_5m = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Climb_2_5m-SM.Climb_2_5m");
			Climb_2_5m.TRANS_EntryState_StandClimb_2_5m = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Climb_2_5m-SM.StandClimb_2_5m");
			Climb_2_5m.TRANS_AnyState_StandClimb_2_5m = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Climb_2_5m-SM.StandClimb_2_5m");
			Climb_2_5m.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Climb_2_5m-SM.IdlePose");
			Climb_2_5m.STATE_Climb_2_5m = this.mMotionController.AddAnimatorName("Base Layer.Climb_2_5m-SM.Climb_2_5m");
			Climb_2_5m.TRANS_Climb_2_5m_ClimbToIdle = this.mMotionController.AddAnimatorName("Base Layer.Climb_2_5m-SM.Climb_2_5m -> Base Layer.Climb_2_5m-SM.ClimbToIdle");
			Climb_2_5m.STATE_ClimbToIdle = this.mMotionController.AddAnimatorName("Base Layer.Climb_2_5m-SM.ClimbToIdle");
			Climb_2_5m.TRANS_ClimbToIdle_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Climb_2_5m-SM.ClimbToIdle -> Base Layer.Climb_2_5m-SM.IdlePose");
			Climb_2_5m.STATE_StandClimb_2_5m = this.mMotionController.AddAnimatorName("Base Layer.Climb_2_5m-SM.StandClimb_2_5m");
			Climb_2_5m.TRANS_StandClimb_2_5m_ClimbToIdle = this.mMotionController.AddAnimatorName("Base Layer.Climb_2_5m-SM.StandClimb_2_5m -> Base Layer.Climb_2_5m-SM.ClimbToIdle");
		}

		// Token: 0x040008A3 RID: 2211
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x040008A4 RID: 2212
		public const int PHASE_START = 1200;

		// Token: 0x040008A5 RID: 2213
		public const int PHASE_START_CLOSE = 1205;

		// Token: 0x040008A6 RID: 2214
		public const int PHASE_TO_TOP = 1210;

		// Token: 0x040008A7 RID: 2215
		public float _MinDistance = 0.25f;

		// Token: 0x040008A8 RID: 2216
		public float _MaxDistance = 0.85f;

		// Token: 0x040008A9 RID: 2217
		public float _MinHeight = 2.4f;

		// Token: 0x040008AA RID: 2218
		public float _MaxHeight = 3.1f;

		// Token: 0x040008AB RID: 2219
		public float _HandGrabOffset = 0.13f;

		// Token: 0x040008AC RID: 2220
		public int _ClimbableLayers = 1;

		// Token: 0x040008AD RID: 2221
		public Vector3 _ReachOffset1 = new Vector3(0f, -2f, -0.3f);

		// Token: 0x040008AE RID: 2222
		public Vector3 _ReachOffset2 = new Vector3(0.1f, 0f, 0f);

		// Token: 0x040008AF RID: 2223
		public Vector3 _ReachOffset3 = new Vector3(0f, -0.85f, -0.1f);

		// Token: 0x040008B0 RID: 2224
		public Vector3 _ReachOffset4 = new Vector3(0.1f, 0f, 0.1f);

		// Token: 0x040008B1 RID: 2225
		public Vector3 _ReachOffset5 = new Vector3(0f, -2.1f, -0.7f);

		// Token: 0x040008B2 RID: 2226
		public Vector3 _ReachOffset6 = new Vector3(0f, -1.672f, -0.389f);

		// Token: 0x040008B3 RID: 2227
		public Vector3 _ReachOffset7 = new Vector3(0f, -0.85f, -0.15f);

		// Token: 0x040008B4 RID: 2228
		public Vector3 _ReachOffset8 = new Vector3(0f, 0f, 0.1f);

		// Token: 0x040008B5 RID: 2229
		protected GameObject mClimbable;

		// Token: 0x040008B6 RID: 2230
		protected float mFaceClimbableNormalAngle;

		// Token: 0x040008B7 RID: 2231
		protected float mFaceClimbableNormalAngleUsed;

		// Token: 0x040008B8 RID: 2232
		protected Vector3 mStartPosition = Vector3.zero;

		// Token: 0x040008B9 RID: 2233
		protected RaycastHit mRaycastHitInfo = RaycastExt.EmptyHitInfo;

		// Token: 0x040008BA RID: 2234
		public static int TRANS_EntryState_Climb_2_5m = -1;

		// Token: 0x040008BB RID: 2235
		public static int TRANS_AnyState_Climb_2_5m = -1;

		// Token: 0x040008BC RID: 2236
		public static int TRANS_EntryState_StandClimb_2_5m = -1;

		// Token: 0x040008BD RID: 2237
		public static int TRANS_AnyState_StandClimb_2_5m = -1;

		// Token: 0x040008BE RID: 2238
		public static int STATE_IdlePose = -1;

		// Token: 0x040008BF RID: 2239
		public static int STATE_Climb_2_5m = -1;

		// Token: 0x040008C0 RID: 2240
		public static int TRANS_Climb_2_5m_ClimbToIdle = -1;

		// Token: 0x040008C1 RID: 2241
		public static int STATE_ClimbToIdle = -1;

		// Token: 0x040008C2 RID: 2242
		public static int TRANS_ClimbToIdle_IdlePose = -1;

		// Token: 0x040008C3 RID: 2243
		public static int STATE_StandClimb_2_5m = -1;

		// Token: 0x040008C4 RID: 2244
		public static int TRANS_StandClimb_2_5m_ClimbToIdle = -1;
	}
}
