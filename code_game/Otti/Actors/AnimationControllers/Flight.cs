using System;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x02000102 RID: 258
	[MotionName("Flight")]
	[MotionDescription("Flight using the InvertRotationOrder.")]
	public class Flight : MotionControllerMotion
	{
		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x06000EED RID: 3821 RVA: 0x0004DC3E File Offset: 0x0004BE3E
		// (set) Token: 0x06000EEE RID: 3822 RVA: 0x0004DC46 File Offset: 0x0004BE46
		public float HorizontalFlySpeed
		{
			get
			{
				return this._HorizontalFlySpeed;
			}
			set
			{
				this._HorizontalFlySpeed = value;
			}
		}

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x06000EEF RID: 3823 RVA: 0x0004DC4F File Offset: 0x0004BE4F
		// (set) Token: 0x06000EF0 RID: 3824 RVA: 0x0004DC57 File Offset: 0x0004BE57
		public float HorizontalHoverSpeed
		{
			get
			{
				return this._HorizontalHoverSpeed;
			}
			set
			{
				this._HorizontalHoverSpeed = value;
			}
		}

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x06000EF1 RID: 3825 RVA: 0x0004DC60 File Offset: 0x0004BE60
		// (set) Token: 0x06000EF2 RID: 3826 RVA: 0x0004DC68 File Offset: 0x0004BE68
		public float VerticalSpeed
		{
			get
			{
				return this._VerticalSpeed;
			}
			set
			{
				this._VerticalSpeed = value;
			}
		}

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x06000EF3 RID: 3827 RVA: 0x0004DC71 File Offset: 0x0004BE71
		// (set) Token: 0x06000EF4 RID: 3828 RVA: 0x0004DC79 File Offset: 0x0004BE79
		public float RotationSpeed
		{
			get
			{
				return this._RotationSpeed;
			}
			set
			{
				this._RotationSpeed = value;
			}
		}

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x06000EF5 RID: 3829 RVA: 0x0004DC82 File Offset: 0x0004BE82
		// (set) Token: 0x06000EF6 RID: 3830 RVA: 0x0004DC8A File Offset: 0x0004BE8A
		public virtual float RotationSmoothing
		{
			get
			{
				return this._RotationSmoothing;
			}
			set
			{
				this._RotationSmoothing = value;
			}
		}

		// Token: 0x06000EF7 RID: 3831 RVA: 0x0004DC94 File Offset: 0x0004BE94
		public Flight()
		{
			this._Priority = 30f;
			this._ActionAlias = "Jump";
		}

		// Token: 0x06000EF8 RID: 3832 RVA: 0x0004DCFC File Offset: 0x0004BEFC
		public Flight(MotionController rController)
			: base(rController)
		{
			this._Priority = 30f;
			this._ActionAlias = "Jump";
		}

		// Token: 0x06000EF9 RID: 3833 RVA: 0x0004DD64 File Offset: 0x0004BF64
		public override void Initialize()
		{
		}

		// Token: 0x06000EFA RID: 3834 RVA: 0x0004DD66 File Offset: 0x0004BF66
		public override bool TestActivate()
		{
			return this.mIsStartable && (this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias));
		}

		// Token: 0x06000EFB RID: 3835 RVA: 0x0004DD9A File Offset: 0x0004BF9A
		public override bool TestUpdate()
		{
			return this.mIsActivatedFrame || this.mMotionController._InputSource == null || !this.mMotionController._InputSource.IsJustPressed(this._ActionAlias);
		}

		// Token: 0x06000EFC RID: 3836 RVA: 0x0004DDCE File Offset: 0x0004BFCE
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			return true;
		}

		// Token: 0x06000EFD RID: 3837 RVA: 0x0004DDD4 File Offset: 0x0004BFD4
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mYaw = 0f;
			this.mYawTarget = 0f;
			this.mYawVelocity = 0f;
			this.mIsGravityEnabled = this.mActorController.IsGravityEnabled;
			this.mActorController.IsGravityEnabled = false;
			this.mIsOrientationEnabled = this.mActorController.OrientToGround;
			this.mActorController.OrientToGround = false;
			this.mActorController.FixGroundPenetration = false;
			this.mIsGroundingLayersEnabled = this.mActorController.IsGroundingLayersEnabled;
			this.mActorController.IsGroundingLayersEnabled = true;
			this.mGroundLayers = this.mActorController.GroundingLayers;
			this.mActorController.GroundingLayers = 0;
			this.mActorController.InvertRotationOrder = true;
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000EFE RID: 3838 RVA: 0x0004DE98 File Offset: 0x0004C098
		public override void Deactivate()
		{
			this.mActorController.InvertRotationOrder = false;
			this.mActorController.IsGravityEnabled = this.mIsGravityEnabled;
			this.mActorController.OrientToGround = this.mIsOrientationEnabled;
			this.mActorController.FixGroundPenetration = true;
			this.mActorController.IsGroundingLayersEnabled = this.mIsGroundingLayersEnabled;
			this.mActorController.GroundingLayers = this.mGroundLayers;
			base.Deactivate();
		}

		// Token: 0x06000EFF RID: 3839 RVA: 0x0004DF07 File Offset: 0x0004C107
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rVelocityDelta, ref Quaternion rRotationDelta)
		{
			rVelocityDelta = Vector3.zero;
			rRotationDelta = Quaternion.identity;
		}

		// Token: 0x06000F00 RID: 3840 RVA: 0x0004DF20 File Offset: 0x0004C120
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			float viewX = this.mMotionController._InputSource.ViewX;
			float viewY = this.mMotionController._InputSource.ViewY;
			this.mRotation = Quaternion.Euler(0f, viewX, 0f);
			this.mTilt = Quaternion.Euler(viewY, 0f, 0f);
			this.mMovement = Vector3.zero;
			this.mMovement.x = this.mMotionController.State.InputX;
			this.mMovement.z = this.mMotionController.State.InputY;
			this.mMovement = this.mMovement.normalized * this._HorizontalFlySpeed;
			if (this.mMotionController._InputSource.IsPressed(KeyCode.Q))
			{
				this.mMovement.y = this.mMovement.y + -this._VerticalSpeed;
			}
			if (this.mMotionController._InputSource.IsPressed(KeyCode.E))
			{
				this.mMovement.y = this.mMovement.y + this._VerticalSpeed;
			}
			this.mMovement = this.mMotionController._Transform.rotation * (this.mRotation * this.mTilt) * (this.mMovement * rDeltaTime);
		}

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x06000F01 RID: 3841 RVA: 0x0004E068 File Offset: 0x0004C268
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == Flight.STATE_float || animatorStateID == Flight.STATE_flying || animatorTransitionID == Flight.TRANS_EntryState_float || animatorTransitionID == Flight.TRANS_AnyState_float || animatorTransitionID == Flight.TRANS_float_flying || animatorTransitionID == Flight.TRANS_flying_float;
			}
		}

		// Token: 0x06000F02 RID: 3842 RVA: 0x0004E0CA File Offset: 0x0004C2CA
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == Flight.STATE_float || rStateID == Flight.STATE_flying;
		}

		// Token: 0x06000F03 RID: 3843 RVA: 0x0004E0E1 File Offset: 0x0004C2E1
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == Flight.STATE_float || rStateID == Flight.STATE_flying || rTransitionID == Flight.TRANS_EntryState_float || rTransitionID == Flight.TRANS_AnyState_float || rTransitionID == Flight.TRANS_float_flying || rTransitionID == Flight.TRANS_flying_float;
		}

		// Token: 0x06000F04 RID: 3844 RVA: 0x0004E120 File Offset: 0x0004C320
		public override void LoadAnimatorData()
		{
			Flight.TRANS_EntryState_float = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Fly-SM.float");
			Flight.TRANS_AnyState_float = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Fly-SM.float");
			Flight.STATE_float = this.mMotionController.AddAnimatorName("Base Layer.Fly-SM.float");
			Flight.TRANS_float_flying = this.mMotionController.AddAnimatorName("Base Layer.Fly-SM.float -> Base Layer.Fly-SM.flying");
			Flight.STATE_flying = this.mMotionController.AddAnimatorName("Base Layer.Fly-SM.flying");
			Flight.TRANS_flying_float = this.mMotionController.AddAnimatorName("Base Layer.Fly-SM.flying -> Base Layer.Fly-SM.float");
		}

		// Token: 0x0400090F RID: 2319
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000910 RID: 2320
		public const int PHASE_START = 30800;

		// Token: 0x04000911 RID: 2321
		public float _HorizontalFlySpeed = 10f;

		// Token: 0x04000912 RID: 2322
		public float _HorizontalHoverSpeed = 3f;

		// Token: 0x04000913 RID: 2323
		public float _VerticalSpeed = 5f;

		// Token: 0x04000914 RID: 2324
		public float _RotationSpeed = 120f;

		// Token: 0x04000915 RID: 2325
		public float _RotationSmoothing = 0.1f;

		// Token: 0x04000916 RID: 2326
		protected float mYaw;

		// Token: 0x04000917 RID: 2327
		protected float mYawTarget;

		// Token: 0x04000918 RID: 2328
		protected float mYawVelocity;

		// Token: 0x04000919 RID: 2329
		private bool mIsGravityEnabled = true;

		// Token: 0x0400091A RID: 2330
		private bool mIsOrientationEnabled;

		// Token: 0x0400091B RID: 2331
		private bool mIsGroundingLayersEnabled;

		// Token: 0x0400091C RID: 2332
		private int mGroundLayers;

		// Token: 0x0400091D RID: 2333
		public static int TRANS_EntryState_float = -1;

		// Token: 0x0400091E RID: 2334
		public static int TRANS_AnyState_float = -1;

		// Token: 0x0400091F RID: 2335
		public static int STATE_float = -1;

		// Token: 0x04000920 RID: 2336
		public static int TRANS_float_flying = -1;

		// Token: 0x04000921 RID: 2337
		public static int STATE_flying = -1;

		// Token: 0x04000922 RID: 2338
		public static int TRANS_flying_float = -1;
	}
}
