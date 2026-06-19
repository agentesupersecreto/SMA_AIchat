using System;
using System.Collections;
using com.ootii.Cameras;
using com.ootii.Geometry;
using com.ootii.Helpers;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000EF RID: 239
	[MotionName("Basic Cover Strafe")]
	[MotionDescription("Shooter game style movement when the character is behind cover. Uses no transitions.")]
	public class BasicCoverStrafe : MotionControllerMotion, IWalkRunMotion, ICoverMotion, IMotionControllerMotion
	{
		// Token: 0x1700036F RID: 879
		// (get) Token: 0x06000C96 RID: 3222 RVA: 0x0003CDB5 File Offset: 0x0003AFB5
		public override bool VerifyTransition
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x06000C97 RID: 3223 RVA: 0x0003CDB8 File Offset: 0x0003AFB8
		// (set) Token: 0x06000C98 RID: 3224 RVA: 0x0003CDC0 File Offset: 0x0003AFC0
		public virtual float WalkSpeed
		{
			get
			{
				return this._WalkSpeed;
			}
			set
			{
				this._WalkSpeed = value;
			}
		}

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x06000C99 RID: 3225 RVA: 0x0003CDC9 File Offset: 0x0003AFC9
		// (set) Token: 0x06000C9A RID: 3226 RVA: 0x0003CDD1 File Offset: 0x0003AFD1
		public int CoverLayers
		{
			get
			{
				return this._CoverLayers;
			}
			set
			{
				this._CoverLayers = value;
			}
		}

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x06000C9B RID: 3227 RVA: 0x0003CDDA File Offset: 0x0003AFDA
		// (set) Token: 0x06000C9C RID: 3228 RVA: 0x0003CDE2 File Offset: 0x0003AFE2
		public virtual float CoverDistance
		{
			get
			{
				return this._CoverDistance;
			}
			set
			{
				this._CoverDistance = value;
			}
		}

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x06000C9D RID: 3229 RVA: 0x0003CDEB File Offset: 0x0003AFEB
		// (set) Token: 0x06000C9E RID: 3230 RVA: 0x0003CDF3 File Offset: 0x0003AFF3
		public float CoverRayLowHeight
		{
			get
			{
				return this._CoverRayLowHeight;
			}
			set
			{
				this._CoverRayLowHeight = value;
			}
		}

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x06000C9F RID: 3231 RVA: 0x0003CDFC File Offset: 0x0003AFFC
		// (set) Token: 0x06000CA0 RID: 3232 RVA: 0x0003CE04 File Offset: 0x0003B004
		public float CoverRayHighHeight
		{
			get
			{
				return this._CoverRayHighHeight;
			}
			set
			{
				this._CoverRayHighHeight = value;
			}
		}

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x06000CA1 RID: 3233 RVA: 0x0003CE0D File Offset: 0x0003B00D
		// (set) Token: 0x06000CA2 RID: 3234 RVA: 0x0003CE15 File Offset: 0x0003B015
		public virtual float CornerViewDistance
		{
			get
			{
				return this._CornerViewDistance;
			}
			set
			{
				this._CornerViewDistance = value;
			}
		}

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06000CA3 RID: 3235 RVA: 0x0003CE1E File Offset: 0x0003B01E
		// (set) Token: 0x06000CA4 RID: 3236 RVA: 0x0003CE26 File Offset: 0x0003B026
		public float CameraOffsetX
		{
			get
			{
				return this._CameraOffsetX;
			}
			set
			{
				this._CameraOffsetX = value;
			}
		}

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06000CA5 RID: 3237 RVA: 0x0003CE2F File Offset: 0x0003B02F
		// (set) Token: 0x06000CA6 RID: 3238 RVA: 0x0003CE37 File Offset: 0x0003B037
		public float RightCornerCameraOffsetX
		{
			get
			{
				return this._RightCornerCameraOffsetX;
			}
			set
			{
				this._RightCornerCameraOffsetX = value;
			}
		}

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06000CA7 RID: 3239 RVA: 0x0003CE40 File Offset: 0x0003B040
		// (set) Token: 0x06000CA8 RID: 3240 RVA: 0x0003CE48 File Offset: 0x0003B048
		public float LeftCornerCameraOffsetX
		{
			get
			{
				return this._LeftCornerCameraOffsetX;
			}
			set
			{
				this._LeftCornerCameraOffsetX = value;
			}
		}

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x06000CA9 RID: 3241 RVA: 0x0003CE51 File Offset: 0x0003B051
		// (set) Token: 0x06000CAA RID: 3242 RVA: 0x0003CE59 File Offset: 0x0003B059
		public float ExitSpeed
		{
			get
			{
				return this._ExitSpeed;
			}
			set
			{
				this._ExitSpeed = value;
			}
		}

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x06000CAB RID: 3243 RVA: 0x0003CE62 File Offset: 0x0003B062
		// (set) Token: 0x06000CAC RID: 3244 RVA: 0x0003CE6A File Offset: 0x0003B06A
		public int SmoothingSamples
		{
			get
			{
				return this._SmoothingSamples;
			}
			set
			{
				this._SmoothingSamples = value;
				this.mInputX.SampleCount = this._SmoothingSamples;
				this.mInputY.SampleCount = this._SmoothingSamples;
				this.mInputMagnitude.SampleCount = this._SmoothingSamples;
			}
		}

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x06000CAD RID: 3245 RVA: 0x0003CEA6 File Offset: 0x0003B0A6
		public IBaseCameraAnchor CameraAnchor
		{
			get
			{
				return this.mCameraAnchor;
			}
		}

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x06000CAE RID: 3246 RVA: 0x0003CEAE File Offset: 0x0003B0AE
		public bool IsExiting
		{
			get
			{
				return this.mIsExiting;
			}
		}

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x06000CAF RID: 3247 RVA: 0x0003CEB6 File Offset: 0x0003B0B6
		public bool IsRunActive
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x06000CB0 RID: 3248 RVA: 0x0003CEB9 File Offset: 0x0003B0B9
		// (set) Token: 0x06000CB1 RID: 3249 RVA: 0x0003CEBC File Offset: 0x0003B0BC
		public bool StartInMove
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x06000CB2 RID: 3250 RVA: 0x0003CEBE File Offset: 0x0003B0BE
		// (set) Token: 0x06000CB3 RID: 3251 RVA: 0x0003CEC1 File Offset: 0x0003B0C1
		public bool StartInWalk
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06000CB4 RID: 3252 RVA: 0x0003CEC3 File Offset: 0x0003B0C3
		// (set) Token: 0x06000CB5 RID: 3253 RVA: 0x0003CEC6 File Offset: 0x0003B0C6
		public bool StartInRun
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		// Token: 0x06000CB6 RID: 3254 RVA: 0x0003CEC8 File Offset: 0x0003B0C8
		public BasicCoverStrafe()
		{
			this._Category = 800;
			this._Priority = 15f;
			this._ActionAlias = "Cover Toggle";
			this._Form = -1;
		}

		// Token: 0x06000CB7 RID: 3255 RVA: 0x0003D1A8 File Offset: 0x0003B3A8
		public BasicCoverStrafe(MotionController rController)
			: base(rController)
		{
			this._Category = 800;
			this._Priority = 15f;
			this._ActionAlias = "Cover Toggle";
			this._Form = -1;
		}

		// Token: 0x06000CB8 RID: 3256 RVA: 0x0003D488 File Offset: 0x0003B688
		public override void Awake()
		{
			base.Awake();
			if (this.mMotionController.CameraRig != null)
			{
				Transform anchor = this.mMotionController.CameraRig.Anchor;
				this.mCameraAnchor = anchor.GetComponent<IBaseCameraAnchor>();
			}
			this.SmoothingSamples = this._SmoothingSamples;
		}

		// Token: 0x06000CB9 RID: 3257 RVA: 0x0003D4D4 File Offset: 0x0003B6D4
		public override bool TestActivate()
		{
			if (!this.mIsStartable)
			{
				return false;
			}
			if (!this.mMotionController.IsGrounded)
			{
				return false;
			}
			bool flag = this._ActionAlias.Length > 0 && this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias);
			if (this.mParameter == 1)
			{
				this.mParameter = 0;
				flag = true;
			}
			return flag && this.RaycastCover(Vector3.zero, this.mMotionController._Transform.forward, true);
		}

		// Token: 0x06000CBA RID: 3258 RVA: 0x0003D568 File Offset: 0x0003B768
		public override bool TestUpdate()
		{
			if (this.mIsActivatedFrame)
			{
				return true;
			}
			if (!this.mMotionController.IsGrounded)
			{
				return false;
			}
			if (this.mMotionController.State.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].StateInfo.IsTag("Exit"))
			{
				return false;
			}
			if (this._ActionAlias.Length > 0 && this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias))
			{
				this.ExitCover(false, false);
			}
			if (this.mLastHitInfo.collider != null && this.mMotionController.State.InputMagnitudeTrend.Value > 0.1f)
			{
				Vector3 vector = this.mMotionController.State.InputForward;
				if (this.mMotionController._CameraTransform != null)
				{
					vector = this.mMotionController._CameraTransform.rotation * vector;
				}
				if (Mathf.Abs(this.mLastHitInfo.normal.HorizontalAngleTo(vector, this.mMotionController._Transform.up)) <= 45f)
				{
					return false;
				}
			}
			if (this.mLastHitInfo.collider == null)
			{
				this.mMotionController.ForcedInput.x = this.mInputX.Average;
				this.mMotionController.ForcedInput.y = this.mInputY.Average;
				return false;
			}
			return true;
		}

		// Token: 0x06000CBB RID: 3259 RVA: 0x0003D6E7 File Offset: 0x0003B8E7
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			this.mMotionController.ForcedInput.x = this.mInputX.Average;
			this.mMotionController.ForcedInput.y = this.mInputY.Average;
			return true;
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x0003D720 File Offset: 0x0003B920
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mIsExiting = false;
			this.mIsLeftFacing = true;
			this.mLastIsLeftFacing = !this.mIsLeftFacing;
			this.mIsInCoverState = false;
			this.mLastIsHighCover = this.mIsHighCover;
			this.mCornerAnchorPosition = Vector3Ext.Null;
			this.mInputX.Clear(0f);
			this.mInputY.Clear(0f);
			this.mInputMagnitude.Clear(0f);
			this.mCoverAngle.Clear(0f);
			this.mMotionController.MaxSpeed = 5.668f;
			int num = (this.mIsHighCover ? this.PHASE_START_WALK : this.PHASE_START_SNEAK);
			this.mStartRotation = this.mMotionController._Transform.rotation;
			this.mEndRotation = Quaternion.LookRotation(this.mLastHitInfo.normal, this.mMotionController._Transform.up);
			this.mMotionController.StartCoroutine(this.mMotionController.MoveAndRotateTo(Vector3.zero, this.mEndRotation, 0.7f, true, false, true));
			num = ((Mathf.Abs(this.mMotionController._Transform.forward.HorizontalAngleTo(this.mLastHitInfo.normal, this.mMotionController._Transform.up)) < 30f) ? (num + 1) : num);
			if (this.mInputX.Value < -0.001f)
			{
				this.mIsLeftFacing = false;
			}
			else if (this.mInputX.Value > 0.001f)
			{
				this.mIsLeftFacing = true;
			}
			this.mActiveForm = ((this._Form >= 0) ? this._Form : this.mMotionController.CurrentForm);
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, num, this.mActiveForm, this.mIsLeftFacing ? 0 : 1, true);
			this.mLastCurrentForm = this.mMotionController.CurrentForm;
			this.mArmsMotion = this.mMotionController.GetMotion<BasicIdleArms>(2, false);
			if (this.mArmsMotion != null && this.mArmsMotion.TestActivate(this.mMotionController.CurrentForm))
			{
				this.mMotionController.ActivateMotion(this.mArmsMotion, 0);
			}
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x0003D958 File Offset: 0x0003BB58
		public override void Deactivate()
		{
			if (this.mCameraAnchor != null)
			{
				this.mCameraAnchor.ClearTarget(3f, 0.8f);
			}
			if (this.mArmsMotion != null && this.mArmsMotion.IsActive)
			{
				this.mArmsMotion.Deactivate();
			}
			base.Deactivate();
		}

		// Token: 0x06000CBE RID: 3262 RVA: 0x0003D9A8 File Offset: 0x0003BBA8
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			rRotation = Quaternion.identity;
			this.mIsInCoverState = this.mMotionController.State.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].StateInfo.IsTag("Cover");
			if (this.mMotionController.State.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].StateInfo.IsTag("PivotToWall"))
			{
				rMovement.x = 0f;
				rMovement.y = 0f;
				return;
			}
			if (this.mMotionController.State.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].StateInfo.IsTag("Pivot180"))
			{
				rMovement.x = 0f;
				rMovement.y = 0f;
				rMovement.z = 0f;
				return;
			}
			rMovement.y = 0f;
			rMovement.z = 0f;
			if (this._WalkSpeed > 0f && rMovement.x != 0f)
			{
				rMovement.x = Mathf.Sign(rMovement.x) * this._WalkSpeed * rDeltaTime;
			}
			if (this.mInputMagnitude.Average == 0f && this.mInputMagnitude.Value == 0f)
			{
				rMovement.x = 0f;
			}
		}

		// Token: 0x06000CBF RID: 3263 RVA: 0x0003DB0C File Offset: 0x0003BD0C
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			if (this.mIsExiting)
			{
				return;
			}
			this.mMovement = Vector3.zero;
			this.mRotation = Quaternion.identity;
			this.SmoothInput();
			if (this.mInputX.Value < -0.001f)
			{
				this.mIsLeftFacing = true;
			}
			else if (this.mInputX.Value > 0.001f)
			{
				this.mIsLeftFacing = false;
			}
			this.mMotionController.SetAnimatorMotionParameter(this.mMotionLayer._AnimatorLayerIndex, this.mIsLeftFacing ? 0 : 1);
			if (this.mIsInCoverState)
			{
				this.RaycastCover(Vector3.zero, -this.mMotionController._Transform.forward, false);
				if (this.mLastHitInfo.collider != null)
				{
					if (this.mIsHighCover != this.mLastIsHighCover)
					{
						int num = (this.mIsHighCover ? (this.PHASE_START_WALK + 1) : (this.PHASE_START_SNEAK + 1));
						this.mActiveForm = ((this._Form >= 0) ? this._Form : this.mMotionController.CurrentForm);
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, num, this.mActiveForm, this.mIsLeftFacing ? 0 : 1, true);
					}
					if (this.mInputX.Value != 0f)
					{
						float num2 = this.mMotionController._Transform.forward.HorizontalAngleTo(this.mLastHitInfo.normal, this.mMotionController._Transform.up);
						this.mCoverAngle.Value = Mathf.Sign(num2) * Mathf.Min(90f * Time.deltaTime, Mathf.Abs(num2));
						if (Mathf.Abs(this.mCoverAngle.Average) > 1f)
						{
							this.mRotation = Quaternion.AngleAxis(this.mCoverAngle.Average, Vector3.up);
						}
					}
				}
				float num3 = this.CameraOffsetX;
				this.RaycastCorner(this.mIsLeftFacing, this.CornerViewDistance);
				if (this.mCornerDistance != 0f)
				{
					if (this.mCornerAnchorPosition == Vector3Ext.Null && this.mActorController.State.Velocity.sqrMagnitude < 0.001f)
					{
						float num4 = 0f;
						CameraController cameraController = this.mMotionController.CameraRig as CameraController;
						if (cameraController != null)
						{
							YawPitchMotor yawPitchMotor = cameraController.ActiveMotor as YawPitchMotor;
							if (yawPitchMotor != null)
							{
								num4 = yawPitchMotor.Offset.x;
							}
						}
						num3 = this.mCornerDistance + (this.mIsLeftFacing ? (-this.LeftCornerCameraOffsetX) : this.RightCornerCameraOffsetX);
						this.mCornerAnchorPosition = this.mMotionController._Transform.position + this.mMotionController._Transform.rotation * new Vector3(num3 + num4, 0f, 0f);
						if (this.mCameraAnchor != null)
						{
							this.mCameraAnchor.SetTargetPosition(null, this.mCornerAnchorPosition, 5f, 0.8f, false);
						}
					}
				}
				else if (this.mIsLeftFacing != this.mLastIsLeftFacing || this.mCornerAnchorPosition != Vector3Ext.Null)
				{
					float num5 = 0f;
					CameraController cameraController2 = this.mMotionController.CameraRig as CameraController;
					if (cameraController2 != null)
					{
						YawPitchMotor yawPitchMotor2 = cameraController2.ActiveMotor as YawPitchMotor;
						if (yawPitchMotor2 != null)
						{
							num5 = yawPitchMotor2.Offset.x;
						}
					}
					if (this.mCameraAnchor != null)
					{
						num5 = (this.mIsLeftFacing ? (-this._CameraOffsetX) : this._CameraOffsetX) + num5;
						this.mCameraAnchor.SetTargetPosition(this.mMotionController._Transform, new Vector3(num5, 0f, 0f), 5f, 0.8f, false);
					}
					this.mLastIsLeftFacing = this.mIsLeftFacing;
					this.mCornerAnchorPosition = Vector3Ext.Null;
				}
				if (this.mArmsMotion != null && !this.mArmsMotion.IsActive && this.mLastCurrentForm != this.mMotionController.CurrentForm)
				{
					this.mLastCurrentForm = this.mMotionController.CurrentForm;
					if (this.mArmsMotion.TestActivate(this.mMotionController.CurrentForm))
					{
						this.mMotionController.ActivateMotion(this.mArmsMotion, 0);
					}
				}
			}
		}

		// Token: 0x06000CC0 RID: 3264 RVA: 0x0003DF50 File Offset: 0x0003C150
		public virtual void ExitCover(bool rExtrapolatePosition = false, bool rUseCameraRotation = false)
		{
			if (rExtrapolatePosition && this.mMotionController.CameraRig != null)
			{
				if (this.mCameraAnchor != null)
				{
					Vector3 position = this.mCameraAnchor.Transform.position;
					this.mCameraAnchor.SetTargetPosition(null, position, 3f, 0.8f, false);
				}
				Vector3 vector;
				Quaternion quaternion;
				this.mMotionController.CameraRig.ExtrapolateAnchorPosition(out vector, out quaternion);
				if (rUseCameraRotation)
				{
					float num = this.mMotionController._Transform.forward.HorizontalAngleTo(this.mMotionController._CameraTransform.forward, this.mMotionController._Transform.up);
					quaternion *= Quaternion.AngleAxis(num, Vector3.up);
				}
				quaternion = Quaternion.AngleAxis(this.mIsLeftFacing ? 0.5f : (-0.5f), Vector3.up) * quaternion;
				this.ExitCover(vector, quaternion);
				return;
			}
			if (this.mArmsMotion != null && this.mArmsMotion.IsActive)
			{
				this.mArmsMotion.Deactivate();
			}
			if (this.mCameraAnchor != null)
			{
				this.mCameraAnchor.ClearTarget(3f, 0.8f);
			}
			this.mStartRotation = this.mMotionController._Transform.rotation;
			this.mEndRotation = this.mStartRotation * Quaternion.AngleAxis(180f + (this.mIsLeftFacing ? 1f : (-1f)), Vector3.up);
			this.mMotionController.StartCoroutine(this.ExitCoverInternal(Vector3.zero, this.mEndRotation, this.ExitSpeed, true, false, true));
			this.mActiveForm = ((this._Form >= 0) ? this._Form : this.mMotionController.CurrentForm);
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, this.PHASE_STOP, this.mActiveForm, this.mIsLeftFacing ? 0 : 1, true);
		}

		// Token: 0x06000CC1 RID: 3265 RVA: 0x0003E130 File Offset: 0x0003C330
		public virtual void ExitCover(Vector3 rPosition, Quaternion rRotation)
		{
			if (this.mArmsMotion != null && this.mArmsMotion.IsActive)
			{
				this.mArmsMotion.Deactivate();
			}
			this.mMotionController.StartCoroutine(this.ExitCoverInternal(rPosition, rRotation, this.ExitSpeed, true, true, true));
			this.mActiveForm = ((this._Form >= 0) ? this._Form : this.mMotionController.CurrentForm);
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, this.PHASE_STOP, this.mActiveForm, 0, true);
		}

		// Token: 0x06000CC2 RID: 3266 RVA: 0x0003E1C0 File Offset: 0x0003C3C0
		protected IEnumerator ExitCoverInternal(Vector3 rPosition, Quaternion rRotation, float rTime, bool rSmooth, bool rMove, bool rRotate)
		{
			this.mIsExiting = true;
			if (rTime == 0f)
			{
				if (rMove)
				{
					this.mMotionController._ActorController.SetPosition(rPosition);
				}
				if (rRotate)
				{
					this.mMotionController._ActorController.SetRotation(rRotation);
				}
			}
			else
			{
				float lPercent = 0f;
				float lStartTime = Time.time;
				Vector3 lOldPosition = this.mMotionController._ActorController._Transform.position;
				Vector3 lNewPosition = rPosition;
				Quaternion lOldRotation = this.mMotionController._ActorController._Transform.rotation;
				float lRotationAngle = this.mMotionController._Transform.forward.HorizontalAngleTo(rRotation.Forward(), this.mMotionController._Transform.up);
				if (this.mIsLeftFacing)
				{
					if (lRotationAngle > 0f)
					{
						lRotationAngle = -360f + lRotationAngle;
					}
				}
				else if (lRotationAngle < 0f)
				{
					lRotationAngle = 360f + lRotationAngle;
				}
				while (lPercent < 1f && (rMove || rRotate))
				{
					lPercent = Mathf.Clamp01((Time.time - lStartTime) / rTime);
					if (rSmooth)
					{
						lPercent = NumberHelper.EaseInOutCubic(lPercent);
					}
					if (rMove)
					{
						Vector3 vector = Vector3.Lerp(lOldPosition, lNewPosition, lPercent);
						this.mMotionController._ActorController.SetPosition(vector);
					}
					if (rRotate)
					{
						float num = Mathf.Lerp(0f, lRotationAngle, lPercent);
						Quaternion quaternion = lOldRotation * Quaternion.AngleAxis(num, Vector3.up);
						this.mMotionController._ActorController.SetRotation(quaternion);
					}
					yield return null;
				}
				lOldPosition = default(Vector3);
				lNewPosition = default(Vector3);
				lOldRotation = default(Quaternion);
			}
			if (this.mCameraAnchor != null)
			{
				this.mCameraAnchor.Transform.rotation = this.mMotionController._Transform.rotation;
				this.mCameraAnchor.ClearTarget(true);
			}
			this.mIsExiting = false;
			yield break;
		}

		// Token: 0x06000CC3 RID: 3267 RVA: 0x0003E1FC File Offset: 0x0003C3FC
		protected void SmoothInput()
		{
			MotionState state = this.mMotionController.State;
			float num = (this.IsRunActive ? 1f : 0.5f);
			Vector3 vector = state.InputForward;
			if (this.mMotionController._CameraTransform != null)
			{
				vector = this.mMotionController._CameraTransform.rotation * vector;
			}
			vector = Quaternion.Inverse(this.mMotionController._Transform.rotation) * vector;
			float num2 = Mathf.Clamp(vector.x, -num, num);
			float num3 = Mathf.Clamp(vector.z, -num, num);
			float num4 = Mathf.Clamp(state.InputMagnitudeTrend.Value, 0f, num);
			InputManagerHelper.ConvertToRadialInput(ref num2, ref num3, ref num4, 1f);
			this.mInputX.Add(num2);
			this.mInputY.Add(num3);
			this.mInputMagnitude.Add(num4);
			this.mMotionController.State.InputX = this.mInputX.Average;
			this.mMotionController.State.InputY = this.mInputY.Average;
			this.mMotionController.State.InputMagnitudeTrend.Replace(this.mInputMagnitude.Average);
		}

		// Token: 0x06000CC4 RID: 3268 RVA: 0x0003E340 File Offset: 0x0003C540
		protected void RotateToDirection(Vector3 rForward, float rSpeed, float rDeltaTime, ref Quaternion rRotation)
		{
			Quaternion quaternion = QuaternionExt.FromToRotation(this.mMotionController._Transform.up, Vector3.up);
			Vector3 vector = quaternion * this.mMotionController._Transform.forward;
			Vector3 vector2 = quaternion * rForward;
			float num = NumberHelper.GetHorizontalAngle(vector, vector2);
			if (rSpeed > 0f && Mathf.Abs(num) > rSpeed * rDeltaTime)
			{
				num = Mathf.Sign(num) * rSpeed * rDeltaTime;
			}
			rRotation = Quaternion.AngleAxis(num, Vector3.up);
		}

		// Token: 0x06000CC5 RID: 3269 RVA: 0x0003E3C0 File Offset: 0x0003C5C0
		protected bool RaycastCover(Vector3 rOffset, Vector3 rDirection, bool rUseCircularCast = false)
		{
			this.mLastIsHighCover = this.mIsHighCover;
			Vector3 vector = this.mMotionController._Transform.position + this.mMotionController._Transform.up * this.CoverRayHighHeight;
			bool flag;
			if (rUseCircularCast)
			{
				flag = RaycastExt.SafeCircularCast(vector, rDirection, this.mMotionController._Transform.up, out this.mLastHitInfo, this.CoverDistance, 30f, this.CoverLayers, null, this.mMotionController._Transform, null, true, false);
			}
			else
			{
				flag = RaycastExt.SafeRaycast(vector, rDirection, out this.mLastHitInfo, this.CoverDistance, this.CoverLayers, this.mMotionController._Transform, null, true, false);
			}
			this.mIsHighCover = true;
			vector = this.mMotionController._Transform.position + this.mMotionController._Transform.up * this.CoverRayLowHeight;
			RaycastHit raycastHit;
			if (rUseCircularCast)
			{
				flag = RaycastExt.SafeCircularCast(vector, rDirection, this.mMotionController._Transform.up, out raycastHit, this.CoverDistance, 30f, this.CoverLayers, null, this.mMotionController._Transform, null, true, false);
			}
			else
			{
				flag = RaycastExt.SafeRaycast(vector, rDirection, out raycastHit, this.CoverDistance, this.CoverLayers, this.mMotionController._Transform, null, true, false);
			}
			if (flag && (this.mLastHitInfo.distance == 0f || raycastHit.distance < this.mLastHitInfo.distance))
			{
				this.mIsHighCover = false;
				this.mLastHitInfo = raycastHit;
			}
			if (this.mLastHitInfo.distance > 0f)
			{
				return true;
			}
			this.mLastHitInfo = RaycastExt.EmptyHitInfo;
			return false;
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x0003E56C File Offset: 0x0003C76C
		protected float RaycastCorner(bool mIsFacingLeft, float rViewDistance)
		{
			this.mCornerDistance = 0f;
			Vector3 vector = this.mMotionController._Transform.position + this.mMotionController._Transform.up * this.CoverRayLowHeight;
			Vector3 vector2 = (mIsFacingLeft ? (-this.mMotionController._Transform.right) : this.mMotionController._Transform.right);
			if (RaycastExt.SafeRaycast(vector, vector2, this.CoverDistance * 1f, this.CoverLayers, this.mMotionController._Transform, null, true))
			{
				return 0f;
			}
			Vector3 vector3 = this.mMotionController._Transform.position + this.mMotionController._Transform.up * this.CoverRayLowHeight + this.mMotionController._Transform.right * (mIsFacingLeft ? (-rViewDistance) : rViewDistance);
			vector2 = -this.mMotionController._Transform.forward;
			if (RaycastExt.SafeRaycast(vector3, vector2, this.CoverDistance * 1f, this.CoverLayers, this.mMotionController._Transform, null, true))
			{
				return 0f;
			}
			float num = 0.05f;
			for (float num2 = 0f; num2 <= this.CoverDistance * 1f; num2 += num)
			{
				if (!RaycastExt.SafeRaycast(this.mMotionController._Transform.position + this.mMotionController._Transform.up * this.CoverRayLowHeight + this.mMotionController._Transform.right * (mIsFacingLeft ? (-num2) : num2), vector2, this.CoverDistance * 1f, this.CoverLayers, this.mMotionController._Transform, null, true))
				{
					this.mCornerDistance = (mIsFacingLeft ? (-1f) : 1f) * Mathf.Max(num2 - num * 0.5f, 0f);
					this.mMotionController._Transform.position + this.mMotionController._Transform.up * this.CoverRayLowHeight + this.mMotionController._Transform.right * this.mCornerDistance;
					return Mathf.Max(num2 - num, 0f);
				}
			}
			return 0f;
		}

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06000CC7 RID: 3271 RVA: 0x0003E7D1 File Offset: 0x0003C9D1
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x06000CC8 RID: 3272 RVA: 0x0003E7D4 File Offset: 0x0003C9D4
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
					if (animatorStateID == this.STATE_IdleToCoverWalkIdle)
					{
						return true;
					}
					if (animatorStateID == this.STATE_CoverWalkLeftIdle)
					{
						return true;
					}
					if (animatorStateID == this.STATE_CoverWalkRightIdle)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdleToCoverSneakIdle)
					{
						return true;
					}
					if (animatorStateID == this.STATE_CoverSneakLeftIdle)
					{
						return true;
					}
					if (animatorStateID == this.STATE_CoverSneakRightIdle)
					{
						return true;
					}
					if (animatorStateID == this.STATE_CoverWalkLeft)
					{
						return true;
					}
					if (animatorStateID == this.STATE_CoverWalkRight)
					{
						return true;
					}
					if (animatorStateID == this.STATE_CoverSneakLeft)
					{
						return true;
					}
					if (animatorStateID == this.STATE_CoverSneakRight)
					{
						return true;
					}
					if (animatorStateID == this.STATE_CoverWalkToIdleLeft)
					{
						return true;
					}
					if (animatorStateID == this.STATE_CoverWalkToIdleRight)
					{
						return true;
					}
					if (animatorStateID == this.STATE_CoverSneakToIdleLeft)
					{
						return true;
					}
					if (animatorStateID == this.STATE_CoverSneakToIdleRight)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdlePoseExit)
					{
						return true;
					}
				}
				return animatorTransitionID == this.TRANS_AnyState_IdleToCoverWalkIdle || animatorTransitionID == this.TRANS_EntryState_IdleToCoverWalkIdle || animatorTransitionID == this.TRANS_AnyState_IdleToCoverSneakIdle || animatorTransitionID == this.TRANS_EntryState_IdleToCoverSneakIdle || animatorTransitionID == this.TRANS_AnyState_CoverWalkLeft || animatorTransitionID == this.TRANS_EntryState_CoverWalkLeft || animatorTransitionID == this.TRANS_AnyState_CoverWalkRight || animatorTransitionID == this.TRANS_EntryState_CoverWalkRight || animatorTransitionID == this.TRANS_AnyState_CoverSneakLeft || animatorTransitionID == this.TRANS_EntryState_CoverSneakLeft || animatorTransitionID == this.TRANS_AnyState_CoverSneakRight || animatorTransitionID == this.TRANS_EntryState_CoverSneakRight || animatorTransitionID == this.TRANS_IdleToCoverWalkIdle_CoverWalkLeftIdle || animatorTransitionID == this.TRANS_IdleToCoverWalkIdle_CoverWalkLeft || animatorTransitionID == this.TRANS_IdleToCoverWalkIdle_CoverWalkRight || animatorTransitionID == this.TRANS_IdleToCoverWalkIdle_CoverWalkRightIdle || animatorTransitionID == this.TRANS_CoverWalkLeftIdle_CoverWalkRightIdle || animatorTransitionID == this.TRANS_CoverWalkLeftIdle_CoverWalkLeft || animatorTransitionID == this.TRANS_CoverWalkLeftIdle_CoverWalkToIdleLeft || animatorTransitionID == this.TRANS_CoverWalkRightIdle_CoverWalkLeftIdle || animatorTransitionID == this.TRANS_CoverWalkRightIdle_CoverWalkRight || animatorTransitionID == this.TRANS_CoverWalkRightIdle_CoverWalkToIdleRight || animatorTransitionID == this.TRANS_IdleToCoverSneakIdle_CoverSneakLeftIdle || animatorTransitionID == this.TRANS_IdleToCoverSneakIdle_CoverSneakLeft || animatorTransitionID == this.TRANS_IdleToCoverSneakIdle_CoverSneakRight || animatorTransitionID == this.TRANS_IdleToCoverSneakIdle_CoverSneakRightIdle || animatorTransitionID == this.TRANS_CoverSneakLeftIdle_CoverSneakRightIdle || animatorTransitionID == this.TRANS_CoverSneakLeftIdle_CoverSneakLeft || animatorTransitionID == this.TRANS_CoverSneakLeftIdle_CoverSneakToIdleLeft || animatorTransitionID == this.TRANS_CoverSneakRightIdle_CoverSneakLeftIdle || animatorTransitionID == this.TRANS_CoverSneakRightIdle_CoverSneakRight || animatorTransitionID == this.TRANS_CoverSneakRightIdle_CoverSneakToIdleRight || animatorTransitionID == this.TRANS_CoverWalkLeft_CoverWalkRight || animatorTransitionID == this.TRANS_CoverWalkLeft_CoverWalkLeftIdle || animatorTransitionID == this.TRANS_CoverWalkRight_CoverWalkLeft || animatorTransitionID == this.TRANS_CoverWalkRight_CoverWalkRightIdle || animatorTransitionID == this.TRANS_CoverSneakLeft_CoverSneakRight || animatorTransitionID == this.TRANS_CoverSneakLeft_CoverSneakLeftIdle || animatorTransitionID == this.TRANS_CoverSneakRight_CoverSneakLeft || animatorTransitionID == this.TRANS_CoverSneakRight_CoverSneakRightIdle || animatorTransitionID == this.TRANS_CoverWalkToIdleLeft_IdlePoseExit || animatorTransitionID == this.TRANS_CoverWalkToIdleRight_IdlePoseExit || animatorTransitionID == this.TRANS_CoverSneakToIdleLeft_IdlePoseExit || animatorTransitionID == this.TRANS_CoverSneakToIdleRight_IdlePoseExit;
			}
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x0003EA94 File Offset: 0x0003CC94
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == this.STATE_Start || rStateID == this.STATE_IdleToCoverWalkIdle || rStateID == this.STATE_CoverWalkLeftIdle || rStateID == this.STATE_CoverWalkRightIdle || rStateID == this.STATE_IdleToCoverSneakIdle || rStateID == this.STATE_CoverSneakLeftIdle || rStateID == this.STATE_CoverSneakRightIdle || rStateID == this.STATE_CoverWalkLeft || rStateID == this.STATE_CoverWalkRight || rStateID == this.STATE_CoverSneakLeft || rStateID == this.STATE_CoverSneakRight || rStateID == this.STATE_CoverWalkToIdleLeft || rStateID == this.STATE_CoverWalkToIdleRight || rStateID == this.STATE_CoverSneakToIdleLeft || rStateID == this.STATE_CoverSneakToIdleRight || rStateID == this.STATE_IdlePoseExit;
		}

		// Token: 0x06000CCA RID: 3274 RVA: 0x0003EB54 File Offset: 0x0003CD54
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			if (rTransitionID == 0)
			{
				if (rStateID == this.STATE_Start)
				{
					return true;
				}
				if (rStateID == this.STATE_IdleToCoverWalkIdle)
				{
					return true;
				}
				if (rStateID == this.STATE_CoverWalkLeftIdle)
				{
					return true;
				}
				if (rStateID == this.STATE_CoverWalkRightIdle)
				{
					return true;
				}
				if (rStateID == this.STATE_IdleToCoverSneakIdle)
				{
					return true;
				}
				if (rStateID == this.STATE_CoverSneakLeftIdle)
				{
					return true;
				}
				if (rStateID == this.STATE_CoverSneakRightIdle)
				{
					return true;
				}
				if (rStateID == this.STATE_CoverWalkLeft)
				{
					return true;
				}
				if (rStateID == this.STATE_CoverWalkRight)
				{
					return true;
				}
				if (rStateID == this.STATE_CoverSneakLeft)
				{
					return true;
				}
				if (rStateID == this.STATE_CoverSneakRight)
				{
					return true;
				}
				if (rStateID == this.STATE_CoverWalkToIdleLeft)
				{
					return true;
				}
				if (rStateID == this.STATE_CoverWalkToIdleRight)
				{
					return true;
				}
				if (rStateID == this.STATE_CoverSneakToIdleLeft)
				{
					return true;
				}
				if (rStateID == this.STATE_CoverSneakToIdleRight)
				{
					return true;
				}
				if (rStateID == this.STATE_IdlePoseExit)
				{
					return true;
				}
			}
			return rTransitionID == this.TRANS_AnyState_IdleToCoverWalkIdle || rTransitionID == this.TRANS_EntryState_IdleToCoverWalkIdle || rTransitionID == this.TRANS_AnyState_IdleToCoverSneakIdle || rTransitionID == this.TRANS_EntryState_IdleToCoverSneakIdle || rTransitionID == this.TRANS_AnyState_CoverWalkLeft || rTransitionID == this.TRANS_EntryState_CoverWalkLeft || rTransitionID == this.TRANS_AnyState_CoverWalkRight || rTransitionID == this.TRANS_EntryState_CoverWalkRight || rTransitionID == this.TRANS_AnyState_CoverSneakLeft || rTransitionID == this.TRANS_EntryState_CoverSneakLeft || rTransitionID == this.TRANS_AnyState_CoverSneakRight || rTransitionID == this.TRANS_EntryState_CoverSneakRight || rTransitionID == this.TRANS_IdleToCoverWalkIdle_CoverWalkLeftIdle || rTransitionID == this.TRANS_IdleToCoverWalkIdle_CoverWalkLeft || rTransitionID == this.TRANS_IdleToCoverWalkIdle_CoverWalkRight || rTransitionID == this.TRANS_IdleToCoverWalkIdle_CoverWalkRightIdle || rTransitionID == this.TRANS_CoverWalkLeftIdle_CoverWalkRightIdle || rTransitionID == this.TRANS_CoverWalkLeftIdle_CoverWalkLeft || rTransitionID == this.TRANS_CoverWalkLeftIdle_CoverWalkToIdleLeft || rTransitionID == this.TRANS_CoverWalkRightIdle_CoverWalkLeftIdle || rTransitionID == this.TRANS_CoverWalkRightIdle_CoverWalkRight || rTransitionID == this.TRANS_CoverWalkRightIdle_CoverWalkToIdleRight || rTransitionID == this.TRANS_IdleToCoverSneakIdle_CoverSneakLeftIdle || rTransitionID == this.TRANS_IdleToCoverSneakIdle_CoverSneakLeft || rTransitionID == this.TRANS_IdleToCoverSneakIdle_CoverSneakRight || rTransitionID == this.TRANS_IdleToCoverSneakIdle_CoverSneakRightIdle || rTransitionID == this.TRANS_CoverSneakLeftIdle_CoverSneakRightIdle || rTransitionID == this.TRANS_CoverSneakLeftIdle_CoverSneakLeft || rTransitionID == this.TRANS_CoverSneakLeftIdle_CoverSneakToIdleLeft || rTransitionID == this.TRANS_CoverSneakRightIdle_CoverSneakLeftIdle || rTransitionID == this.TRANS_CoverSneakRightIdle_CoverSneakRight || rTransitionID == this.TRANS_CoverSneakRightIdle_CoverSneakToIdleRight || rTransitionID == this.TRANS_CoverWalkLeft_CoverWalkRight || rTransitionID == this.TRANS_CoverWalkLeft_CoverWalkLeftIdle || rTransitionID == this.TRANS_CoverWalkRight_CoverWalkLeft || rTransitionID == this.TRANS_CoverWalkRight_CoverWalkRightIdle || rTransitionID == this.TRANS_CoverSneakLeft_CoverSneakRight || rTransitionID == this.TRANS_CoverSneakLeft_CoverSneakLeftIdle || rTransitionID == this.TRANS_CoverSneakRight_CoverSneakLeft || rTransitionID == this.TRANS_CoverSneakRight_CoverSneakRightIdle || rTransitionID == this.TRANS_CoverWalkToIdleLeft_IdlePoseExit || rTransitionID == this.TRANS_CoverWalkToIdleRight_IdlePoseExit || rTransitionID == this.TRANS_CoverSneakToIdleLeft_IdlePoseExit || rTransitionID == this.TRANS_CoverSneakToIdleRight_IdlePoseExit;
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x0003EDFC File Offset: 0x0003CFFC
		public override void LoadAnimatorData()
		{
			string layerName = this.mMotionController.Animator.GetLayerName(this.mMotionLayer._AnimatorLayerIndex);
			this.TRANS_AnyState_IdleToCoverWalkIdle = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".BasicCoverStrafe-SM.IdleToCoverWalkIdle");
			this.TRANS_EntryState_IdleToCoverWalkIdle = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".BasicCoverStrafe-SM.IdleToCoverWalkIdle");
			this.TRANS_AnyState_IdleToCoverSneakIdle = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".BasicCoverStrafe-SM.IdleToCoverSneakIdle");
			this.TRANS_EntryState_IdleToCoverSneakIdle = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".BasicCoverStrafe-SM.IdleToCoverSneakIdle");
			this.TRANS_AnyState_CoverWalkLeft = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".BasicCoverStrafe-SM.CoverWalkLeft");
			this.TRANS_EntryState_CoverWalkLeft = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".BasicCoverStrafe-SM.CoverWalkLeft");
			this.TRANS_AnyState_CoverWalkRight = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".BasicCoverStrafe-SM.CoverWalkRight");
			this.TRANS_EntryState_CoverWalkRight = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".BasicCoverStrafe-SM.CoverWalkRight");
			this.TRANS_AnyState_CoverSneakLeft = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".BasicCoverStrafe-SM.CoverSneakLeft");
			this.TRANS_EntryState_CoverSneakLeft = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".BasicCoverStrafe-SM.CoverSneakLeft");
			this.TRANS_AnyState_CoverSneakRight = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".BasicCoverStrafe-SM.CoverSneakRight");
			this.TRANS_EntryState_CoverSneakRight = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".BasicCoverStrafe-SM.CoverSneakRight");
			this.STATE_Start = this.mMotionController.AddAnimatorName(layerName + ".Start");
			this.STATE_IdleToCoverWalkIdle = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.IdleToCoverWalkIdle");
			this.TRANS_IdleToCoverWalkIdle_CoverWalkLeftIdle = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.IdleToCoverWalkIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverWalkLeftIdle");
			this.TRANS_IdleToCoverWalkIdle_CoverWalkLeft = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.IdleToCoverWalkIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverWalkLeft");
			this.TRANS_IdleToCoverWalkIdle_CoverWalkRight = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.IdleToCoverWalkIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverWalkRight");
			this.TRANS_IdleToCoverWalkIdle_CoverWalkRightIdle = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.IdleToCoverWalkIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverWalkRightIdle");
			this.STATE_CoverWalkLeftIdle = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverWalkLeftIdle");
			this.TRANS_CoverWalkLeftIdle_CoverWalkRightIdle = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverWalkLeftIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverWalkRightIdle");
			this.TRANS_CoverWalkLeftIdle_CoverWalkLeft = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverWalkLeftIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverWalkLeft");
			this.TRANS_CoverWalkLeftIdle_CoverWalkToIdleLeft = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverWalkLeftIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverWalkToIdleLeft");
			this.STATE_CoverWalkRightIdle = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverWalkRightIdle");
			this.TRANS_CoverWalkRightIdle_CoverWalkLeftIdle = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverWalkRightIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverWalkLeftIdle");
			this.TRANS_CoverWalkRightIdle_CoverWalkRight = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverWalkRightIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverWalkRight");
			this.TRANS_CoverWalkRightIdle_CoverWalkToIdleRight = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverWalkRightIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverWalkToIdleRight");
			this.STATE_IdleToCoverSneakIdle = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.IdleToCoverSneakIdle");
			this.TRANS_IdleToCoverSneakIdle_CoverSneakLeftIdle = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.IdleToCoverSneakIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverSneakLeftIdle");
			this.TRANS_IdleToCoverSneakIdle_CoverSneakLeft = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.IdleToCoverSneakIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverSneakLeft");
			this.TRANS_IdleToCoverSneakIdle_CoverSneakRight = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.IdleToCoverSneakIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverSneakRight");
			this.TRANS_IdleToCoverSneakIdle_CoverSneakRightIdle = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.IdleToCoverSneakIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverSneakRightIdle");
			this.STATE_CoverSneakLeftIdle = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverSneakLeftIdle");
			this.TRANS_CoverSneakLeftIdle_CoverSneakRightIdle = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverSneakLeftIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverSneakRightIdle");
			this.TRANS_CoverSneakLeftIdle_CoverSneakLeft = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverSneakLeftIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverSneakLeft");
			this.TRANS_CoverSneakLeftIdle_CoverSneakToIdleLeft = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverSneakLeftIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverSneakToIdleLeft");
			this.STATE_CoverSneakRightIdle = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverSneakRightIdle");
			this.TRANS_CoverSneakRightIdle_CoverSneakLeftIdle = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverSneakRightIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverSneakLeftIdle");
			this.TRANS_CoverSneakRightIdle_CoverSneakRight = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverSneakRightIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverSneakRight");
			this.TRANS_CoverSneakRightIdle_CoverSneakToIdleRight = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverSneakRightIdle -> " + layerName + ".BasicCoverStrafe-SM.CoverSneakToIdleRight");
			this.STATE_CoverWalkLeft = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverWalkLeft");
			this.TRANS_CoverWalkLeft_CoverWalkRight = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverWalkLeft -> " + layerName + ".BasicCoverStrafe-SM.CoverWalkRight");
			this.TRANS_CoverWalkLeft_CoverWalkLeftIdle = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverWalkLeft -> " + layerName + ".BasicCoverStrafe-SM.CoverWalkLeftIdle");
			this.STATE_CoverWalkRight = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverWalkRight");
			this.TRANS_CoverWalkRight_CoverWalkLeft = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverWalkRight -> " + layerName + ".BasicCoverStrafe-SM.CoverWalkLeft");
			this.TRANS_CoverWalkRight_CoverWalkRightIdle = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverWalkRight -> " + layerName + ".BasicCoverStrafe-SM.CoverWalkRightIdle");
			this.STATE_CoverSneakLeft = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverSneakLeft");
			this.TRANS_CoverSneakLeft_CoverSneakRight = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverSneakLeft -> " + layerName + ".BasicCoverStrafe-SM.CoverSneakRight");
			this.TRANS_CoverSneakLeft_CoverSneakLeftIdle = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverSneakLeft -> " + layerName + ".BasicCoverStrafe-SM.CoverSneakLeftIdle");
			this.STATE_CoverSneakRight = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverSneakRight");
			this.TRANS_CoverSneakRight_CoverSneakLeft = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverSneakRight -> " + layerName + ".BasicCoverStrafe-SM.CoverSneakLeft");
			this.TRANS_CoverSneakRight_CoverSneakRightIdle = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverSneakRight -> " + layerName + ".BasicCoverStrafe-SM.CoverSneakRightIdle");
			this.STATE_CoverWalkToIdleLeft = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverWalkToIdleLeft");
			this.TRANS_CoverWalkToIdleLeft_IdlePoseExit = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverWalkToIdleLeft -> " + layerName + ".BasicCoverStrafe-SM.IdlePoseExit");
			this.STATE_CoverWalkToIdleRight = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverWalkToIdleRight");
			this.TRANS_CoverWalkToIdleRight_IdlePoseExit = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverWalkToIdleRight -> " + layerName + ".BasicCoverStrafe-SM.IdlePoseExit");
			this.STATE_CoverSneakToIdleLeft = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverSneakToIdleLeft");
			this.TRANS_CoverSneakToIdleLeft_IdlePoseExit = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverSneakToIdleLeft -> " + layerName + ".BasicCoverStrafe-SM.IdlePoseExit");
			this.STATE_CoverSneakToIdleRight = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverSneakToIdleRight");
			this.TRANS_CoverSneakToIdleRight_IdlePoseExit = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.CoverSneakToIdleRight -> " + layerName + ".BasicCoverStrafe-SM.IdlePoseExit");
			this.STATE_IdlePoseExit = this.mMotionController.AddAnimatorName(layerName + ".BasicCoverStrafe-SM.IdlePoseExit");
		}

		// Token: 0x040006AF RID: 1711
		protected const float EPSILON = 0.001f;

		// Token: 0x040006B0 RID: 1712
		public int PHASE_UNKNOWN;

		// Token: 0x040006B1 RID: 1713
		public int PHASE_START_WALK = 3600;

		// Token: 0x040006B2 RID: 1714
		public int PHASE_START_SNEAK = 3605;

		// Token: 0x040006B3 RID: 1715
		public int PHASE_STOP = 3610;

		// Token: 0x040006B4 RID: 1716
		public float _WalkSpeed;

		// Token: 0x040006B5 RID: 1717
		public int _CoverLayers = 1;

		// Token: 0x040006B6 RID: 1718
		public float _CoverDistance = 0.91f;

		// Token: 0x040006B7 RID: 1719
		public float _CoverRayLowHeight = 0.95f;

		// Token: 0x040006B8 RID: 1720
		public float _CoverRayHighHeight = 1.7f;

		// Token: 0x040006B9 RID: 1721
		public float _CornerViewDistance = 0.35f;

		// Token: 0x040006BA RID: 1722
		public float _CameraOffsetX = 0.3f;

		// Token: 0x040006BB RID: 1723
		public float _RightCornerCameraOffsetX = 0.35f;

		// Token: 0x040006BC RID: 1724
		public float _LeftCornerCameraOffsetX = 0.75f;

		// Token: 0x040006BD RID: 1725
		public float _ExitSpeed = 0.4f;

		// Token: 0x040006BE RID: 1726
		public int _SmoothingSamples = 10;

		// Token: 0x040006BF RID: 1727
		protected IBaseCameraAnchor mCameraAnchor;

		// Token: 0x040006C0 RID: 1728
		protected bool mIsExiting;

		// Token: 0x040006C1 RID: 1729
		protected FloatValue mInputX = new FloatValue(0f, 10);

		// Token: 0x040006C2 RID: 1730
		protected FloatValue mInputY = new FloatValue(0f, 10);

		// Token: 0x040006C3 RID: 1731
		protected FloatValue mInputMagnitude = new FloatValue(0f, 15);

		// Token: 0x040006C4 RID: 1732
		protected int mActiveForm;

		// Token: 0x040006C5 RID: 1733
		protected bool mIsInCoverState;

		// Token: 0x040006C6 RID: 1734
		protected bool mIsLeftFacing = true;

		// Token: 0x040006C7 RID: 1735
		protected bool mLastIsLeftFacing = true;

		// Token: 0x040006C8 RID: 1736
		protected bool mIsHighCover;

		// Token: 0x040006C9 RID: 1737
		protected bool mLastIsHighCover;

		// Token: 0x040006CA RID: 1738
		protected float mCornerDistance;

		// Token: 0x040006CB RID: 1739
		protected Vector3 mCornerAnchorPosition = Vector3Ext.Null;

		// Token: 0x040006CC RID: 1740
		protected Quaternion mStartRotation = Quaternion.identity;

		// Token: 0x040006CD RID: 1741
		protected Quaternion mEndRotation = Quaternion.identity;

		// Token: 0x040006CE RID: 1742
		protected RaycastHit mLastHitInfo;

		// Token: 0x040006CF RID: 1743
		protected FloatValue mCoverAngle = new FloatValue(0f, 5);

		// Token: 0x040006D0 RID: 1744
		protected int mLastCurrentForm;

		// Token: 0x040006D1 RID: 1745
		protected BasicIdleArms mArmsMotion;

		// Token: 0x040006D2 RID: 1746
		public int STATE_Start = -1;

		// Token: 0x040006D3 RID: 1747
		public int STATE_IdleToCoverWalkIdle = -1;

		// Token: 0x040006D4 RID: 1748
		public int STATE_CoverWalkLeftIdle = -1;

		// Token: 0x040006D5 RID: 1749
		public int STATE_CoverWalkRightIdle = -1;

		// Token: 0x040006D6 RID: 1750
		public int STATE_IdleToCoverSneakIdle = -1;

		// Token: 0x040006D7 RID: 1751
		public int STATE_CoverSneakLeftIdle = -1;

		// Token: 0x040006D8 RID: 1752
		public int STATE_CoverSneakRightIdle = -1;

		// Token: 0x040006D9 RID: 1753
		public int STATE_CoverWalkLeft = -1;

		// Token: 0x040006DA RID: 1754
		public int STATE_CoverWalkRight = -1;

		// Token: 0x040006DB RID: 1755
		public int STATE_CoverSneakLeft = -1;

		// Token: 0x040006DC RID: 1756
		public int STATE_CoverSneakRight = -1;

		// Token: 0x040006DD RID: 1757
		public int STATE_CoverWalkToIdleLeft = -1;

		// Token: 0x040006DE RID: 1758
		public int STATE_CoverWalkToIdleRight = -1;

		// Token: 0x040006DF RID: 1759
		public int STATE_CoverSneakToIdleLeft = -1;

		// Token: 0x040006E0 RID: 1760
		public int STATE_CoverSneakToIdleRight = -1;

		// Token: 0x040006E1 RID: 1761
		public int STATE_IdlePoseExit = -1;

		// Token: 0x040006E2 RID: 1762
		public int TRANS_AnyState_IdleToCoverWalkIdle = -1;

		// Token: 0x040006E3 RID: 1763
		public int TRANS_EntryState_IdleToCoverWalkIdle = -1;

		// Token: 0x040006E4 RID: 1764
		public int TRANS_AnyState_IdleToCoverSneakIdle = -1;

		// Token: 0x040006E5 RID: 1765
		public int TRANS_EntryState_IdleToCoverSneakIdle = -1;

		// Token: 0x040006E6 RID: 1766
		public int TRANS_AnyState_CoverWalkLeft = -1;

		// Token: 0x040006E7 RID: 1767
		public int TRANS_EntryState_CoverWalkLeft = -1;

		// Token: 0x040006E8 RID: 1768
		public int TRANS_AnyState_CoverWalkRight = -1;

		// Token: 0x040006E9 RID: 1769
		public int TRANS_EntryState_CoverWalkRight = -1;

		// Token: 0x040006EA RID: 1770
		public int TRANS_AnyState_CoverSneakLeft = -1;

		// Token: 0x040006EB RID: 1771
		public int TRANS_EntryState_CoverSneakLeft = -1;

		// Token: 0x040006EC RID: 1772
		public int TRANS_AnyState_CoverSneakRight = -1;

		// Token: 0x040006ED RID: 1773
		public int TRANS_EntryState_CoverSneakRight = -1;

		// Token: 0x040006EE RID: 1774
		public int TRANS_IdleToCoverWalkIdle_CoverWalkLeftIdle = -1;

		// Token: 0x040006EF RID: 1775
		public int TRANS_IdleToCoverWalkIdle_CoverWalkLeft = -1;

		// Token: 0x040006F0 RID: 1776
		public int TRANS_IdleToCoverWalkIdle_CoverWalkRight = -1;

		// Token: 0x040006F1 RID: 1777
		public int TRANS_IdleToCoverWalkIdle_CoverWalkRightIdle = -1;

		// Token: 0x040006F2 RID: 1778
		public int TRANS_CoverWalkLeftIdle_CoverWalkRightIdle = -1;

		// Token: 0x040006F3 RID: 1779
		public int TRANS_CoverWalkLeftIdle_CoverWalkLeft = -1;

		// Token: 0x040006F4 RID: 1780
		public int TRANS_CoverWalkLeftIdle_CoverWalkToIdleLeft = -1;

		// Token: 0x040006F5 RID: 1781
		public int TRANS_CoverWalkRightIdle_CoverWalkLeftIdle = -1;

		// Token: 0x040006F6 RID: 1782
		public int TRANS_CoverWalkRightIdle_CoverWalkRight = -1;

		// Token: 0x040006F7 RID: 1783
		public int TRANS_CoverWalkRightIdle_CoverWalkToIdleRight = -1;

		// Token: 0x040006F8 RID: 1784
		public int TRANS_IdleToCoverSneakIdle_CoverSneakLeftIdle = -1;

		// Token: 0x040006F9 RID: 1785
		public int TRANS_IdleToCoverSneakIdle_CoverSneakLeft = -1;

		// Token: 0x040006FA RID: 1786
		public int TRANS_IdleToCoverSneakIdle_CoverSneakRight = -1;

		// Token: 0x040006FB RID: 1787
		public int TRANS_IdleToCoverSneakIdle_CoverSneakRightIdle = -1;

		// Token: 0x040006FC RID: 1788
		public int TRANS_CoverSneakLeftIdle_CoverSneakRightIdle = -1;

		// Token: 0x040006FD RID: 1789
		public int TRANS_CoverSneakLeftIdle_CoverSneakLeft = -1;

		// Token: 0x040006FE RID: 1790
		public int TRANS_CoverSneakLeftIdle_CoverSneakToIdleLeft = -1;

		// Token: 0x040006FF RID: 1791
		public int TRANS_CoverSneakRightIdle_CoverSneakLeftIdle = -1;

		// Token: 0x04000700 RID: 1792
		public int TRANS_CoverSneakRightIdle_CoverSneakRight = -1;

		// Token: 0x04000701 RID: 1793
		public int TRANS_CoverSneakRightIdle_CoverSneakToIdleRight = -1;

		// Token: 0x04000702 RID: 1794
		public int TRANS_CoverWalkLeft_CoverWalkRight = -1;

		// Token: 0x04000703 RID: 1795
		public int TRANS_CoverWalkLeft_CoverWalkLeftIdle = -1;

		// Token: 0x04000704 RID: 1796
		public int TRANS_CoverWalkRight_CoverWalkLeft = -1;

		// Token: 0x04000705 RID: 1797
		public int TRANS_CoverWalkRight_CoverWalkRightIdle = -1;

		// Token: 0x04000706 RID: 1798
		public int TRANS_CoverSneakLeft_CoverSneakRight = -1;

		// Token: 0x04000707 RID: 1799
		public int TRANS_CoverSneakLeft_CoverSneakLeftIdle = -1;

		// Token: 0x04000708 RID: 1800
		public int TRANS_CoverSneakRight_CoverSneakLeft = -1;

		// Token: 0x04000709 RID: 1801
		public int TRANS_CoverSneakRight_CoverSneakRightIdle = -1;

		// Token: 0x0400070A RID: 1802
		public int TRANS_CoverWalkToIdleLeft_IdlePoseExit = -1;

		// Token: 0x0400070B RID: 1803
		public int TRANS_CoverWalkToIdleRight_IdlePoseExit = -1;

		// Token: 0x0400070C RID: 1804
		public int TRANS_CoverSneakToIdleLeft_IdlePoseExit = -1;

		// Token: 0x0400070D RID: 1805
		public int TRANS_CoverSneakToIdleRight_IdlePoseExit = -1;
	}
}
