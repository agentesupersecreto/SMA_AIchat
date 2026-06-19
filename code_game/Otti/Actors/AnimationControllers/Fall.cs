using System;
using com.ootii.Cameras;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x02000101 RID: 257
	[MotionName("Fall")]
	[MotionDescription("Motion the avatar moves into when they are no longer grounded and are falling. Once they land, the avatar can move into the idle pose or a run.")]
	public class Fall : Jump
	{
		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x06000EE6 RID: 3814 RVA: 0x0004D995 File Offset: 0x0004BB95
		// (set) Token: 0x06000EE7 RID: 3815 RVA: 0x0004D99D File Offset: 0x0004BB9D
		public float MinFallHeight
		{
			get
			{
				return this._MinFallHeight;
			}
			set
			{
				this._MinFallHeight = value;
			}
		}

		// Token: 0x06000EE8 RID: 3816 RVA: 0x0004D9A6 File Offset: 0x0004BBA6
		public Fall()
		{
			this._Priority = 20f;
			this._IsControlEnabled = false;
			this._ConvertToHipBase = false;
			this._Impulse = 0f;
			this.mIsStartable = true;
		}

		// Token: 0x06000EE9 RID: 3817 RVA: 0x0004D9E4 File Offset: 0x0004BBE4
		public Fall(MotionController rController)
			: base(rController)
		{
			this._Priority = 20f;
			this._IsControlEnabled = false;
			this._ConvertToHipBase = false;
			this._Impulse = 0f;
			this.mIsStartable = true;
		}

		// Token: 0x06000EEA RID: 3818 RVA: 0x0004DA24 File Offset: 0x0004BC24
		public override bool TestActivate()
		{
			if (!this.mIsStartable)
			{
				return false;
			}
			if (base.IsInMidJumpState)
			{
				return false;
			}
			if (this.mActorController.UseTransformPosition)
			{
				return !this.mActorController.IsGrounded && !this.IsInMotionState && (this.mMotionLayer.ActiveMotion == null || this.mMotionLayer.ActiveMotion.Category != 9);
			}
			return !this.mActorController.State.IsGrounded && this.mActorController.State.GroundSurfaceDistance >= this._MinFallHeight;
		}

		// Token: 0x06000EEB RID: 3819 RVA: 0x0004DABC File Offset: 0x0004BCBC
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mIsActive = true;
			this.mIsAnimatorActive = false;
			this.mIsActivatedFrame = true;
			this.mIsStartable = false;
			if (rPrevMotion is IWalkRunMotion)
			{
				this.mWalkRunMotion = rPrevMotion as IWalkRunMotion;
			}
			IBaseCameraRig cameraRig = this.mMotionController.CameraRig;
			if (this._ConvertToHipBase && this.mHipBone == null)
			{
				if (this._HipBoneName.Length > 0)
				{
					this.mHipBone = this.mMotionController._Transform.Find(this._HipBoneName);
				}
				if (this.mHipBone == null)
				{
					this.mHipBone = this.mMotionController.Animator.GetBoneTransform(HumanBodyBones.Hips);
					if (this.mHipBone != null)
					{
						this._HipBoneName = this.mHipBone.name;
					}
				}
			}
			this.mLastHipDistance = 0f;
			this.mIsImpulseApplied = false;
			this.mLaunchForward = this.mActorController._Transform.forward;
			this.mLaunchVelocity = this.mActorController.State.Velocity;
			Vector3 vector = Vector3.Project(this.mLaunchVelocity, this.mActorController._Transform.up);
			this.mLaunchVelocity -= vector;
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 250, true);
			if (this.mMotionController.MotionActivated != null)
			{
				this.mMotionController.MotionActivated(this.mMotionLayer._AnimatorLayerIndex, this, rPrevMotion);
			}
			return true;
		}

		// Token: 0x06000EEC RID: 3820 RVA: 0x0004DC3C File Offset: 0x0004BE3C
		public override void OnMessageReceived(IMessage rMessage)
		{
		}

		// Token: 0x0400090C RID: 2316
		public new const int PHASE_UNKNOWN = 0;

		// Token: 0x0400090D RID: 2317
		public new const int PHASE_START_FALL = 250;

		// Token: 0x0400090E RID: 2318
		public float _MinFallHeight = 0.3f;
	}
}
