using System;
using com.ootii.Actors.Navigation;
using com.ootii.Cameras;
using com.ootii.Geometry;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x02000108 RID: 264
	[MotionName("Jump")]
	[MotionDescription("A physics based multi-part jump that allows the player to launch into the air and recover into the idle pose or a run. The jump is created so the avatar can jump as high as mass, gravity, and impulse allow.")]
	public class Jump : MotionControllerMotion
	{
		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x06000F4D RID: 3917 RVA: 0x0004F964 File Offset: 0x0004DB64
		// (set) Token: 0x06000F4E RID: 3918 RVA: 0x0004F96C File Offset: 0x0004DB6C
		public float Impulse
		{
			get
			{
				return this._Impulse;
			}
			set
			{
				this._Impulse = value;
			}
		}

		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x06000F4F RID: 3919 RVA: 0x0004F975 File Offset: 0x0004DB75
		// (set) Token: 0x06000F50 RID: 3920 RVA: 0x0004F97D File Offset: 0x0004DB7D
		public bool ConvertToHipBase
		{
			get
			{
				return this._ConvertToHipBase;
			}
			set
			{
				this._ConvertToHipBase = value;
			}
		}

		// Token: 0x1700044B RID: 1099
		// (get) Token: 0x06000F51 RID: 3921 RVA: 0x0004F986 File Offset: 0x0004DB86
		// (set) Token: 0x06000F52 RID: 3922 RVA: 0x0004F98E File Offset: 0x0004DB8E
		public string HipBoneName
		{
			get
			{
				return this._HipBoneName;
			}
			set
			{
				this._HipBoneName = value;
				if (this.mMotionController != null)
				{
					this.mHipBone = this.mMotionController.gameObject.transform.Find(this._HipBoneName);
				}
			}
		}

		// Token: 0x1700044C RID: 1100
		// (get) Token: 0x06000F53 RID: 3923 RVA: 0x0004F9C6 File Offset: 0x0004DBC6
		// (set) Token: 0x06000F54 RID: 3924 RVA: 0x0004F9CE File Offset: 0x0004DBCE
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

		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x06000F55 RID: 3925 RVA: 0x0004F9D7 File Offset: 0x0004DBD7
		// (set) Token: 0x06000F56 RID: 3926 RVA: 0x0004F9DF File Offset: 0x0004DBDF
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

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06000F57 RID: 3927 RVA: 0x0004F9E8 File Offset: 0x0004DBE8
		// (set) Token: 0x06000F58 RID: 3928 RVA: 0x0004F9F0 File Offset: 0x0004DBF0
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

		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06000F59 RID: 3929 RVA: 0x0004F9F9 File Offset: 0x0004DBF9
		// (set) Token: 0x06000F5A RID: 3930 RVA: 0x0004FA01 File Offset: 0x0004DC01
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

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06000F5B RID: 3931 RVA: 0x0004FA0A File Offset: 0x0004DC0A
		// (set) Token: 0x06000F5C RID: 3932 RVA: 0x0004FA12 File Offset: 0x0004DC12
		public float MaxJumpTime
		{
			get
			{
				return this._MaxJumpTime;
			}
			set
			{
				this._MaxJumpTime = value;
			}
		}

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06000F5D RID: 3933 RVA: 0x0004FA1B File Offset: 0x0004DC1B
		// (set) Token: 0x06000F5E RID: 3934 RVA: 0x0004FA23 File Offset: 0x0004DC23
		public Vector3 LaunchVelocityOverride
		{
			get
			{
				return this.mLaunchVelocityOverride;
			}
			set
			{
				this.mLaunchVelocityOverride = value;
			}
		}

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06000F5F RID: 3935 RVA: 0x0004FA2C File Offset: 0x0004DC2C
		// (set) Token: 0x06000F60 RID: 3936 RVA: 0x0004FA34 File Offset: 0x0004DC34
		public bool RotateWithCamera
		{
			get
			{
				return this._RotateWithCamera;
			}
			set
			{
				this._RotateWithCamera = value;
				if (this.mMotionController != null && this.mMotionController.CameraRig is BaseCameraRig)
				{
					BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
					baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
					if (this._RotateWithCamera)
					{
						BaseCameraRig baseCameraRig2 = (BaseCameraRig)this.mMotionController.CameraRig;
						baseCameraRig2.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Combine(baseCameraRig2.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
					}
				}
			}
		}

		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06000F61 RID: 3937 RVA: 0x0004FAD2 File Offset: 0x0004DCD2
		// (set) Token: 0x06000F62 RID: 3938 RVA: 0x0004FADA File Offset: 0x0004DCDA
		public string RotateWithCameraAlias
		{
			get
			{
				return this._RotateWithCameraAlias;
			}
			set
			{
				this._RotateWithCameraAlias = value;
			}
		}

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06000F63 RID: 3939 RVA: 0x0004FAE3 File Offset: 0x0004DCE3
		// (set) Token: 0x06000F64 RID: 3940 RVA: 0x0004FAEB File Offset: 0x0004DCEB
		public float RotationToCameraSpeed
		{
			get
			{
				return this._RotationToCameraSpeed;
			}
			set
			{
				this._RotationToCameraSpeed = value;
			}
		}

		// Token: 0x06000F65 RID: 3941 RVA: 0x0004FAF4 File Offset: 0x0004DCF4
		public Jump()
		{
			this._Form = -1;
			this._Priority = 15f;
			this._ActionAlias = "Jump";
			this.mIsStartable = true;
		}

		// Token: 0x06000F66 RID: 3942 RVA: 0x0004FB9C File Offset: 0x0004DD9C
		public Jump(MotionController rController)
			: base(rController)
		{
			this._Form = -1;
			this._Priority = 15f;
			this._ActionAlias = "Jump";
			this.mIsStartable = true;
		}

		// Token: 0x06000F67 RID: 3943 RVA: 0x0004FC45 File Offset: 0x0004DE45
		public override void Initialize()
		{
			if (this.mMotionController != null && this.mWalkRunMotion == null)
			{
				this.mWalkRunMotion = this.mMotionController.GetMotionInterface<IWalkRunMotion>(0);
			}
		}

		// Token: 0x06000F68 RID: 3944 RVA: 0x0004FC6F File Offset: 0x0004DE6F
		public override void Awake()
		{
			base.Awake();
		}

		// Token: 0x06000F69 RID: 3945 RVA: 0x0004FC78 File Offset: 0x0004DE78
		public override bool TestActivate()
		{
			if (!this.mIsStartable)
			{
				return false;
			}
			if (this._Form >= 0 && this.mMotionController.CurrentForm != this._Form)
			{
				return false;
			}
			if (this.mActorController.UseTransformPosition)
			{
				return !this.mActorController.IsGrounded && Vector3.Dot(Vector3.Project(this.mActorController.State.Velocity, this.mActorController._Transform.up), this.mActorController._Transform.up) > 0f && (this.mMotionLayer.ActiveMotion == null || this.mMotionLayer.ActiveMotion.Category != 5);
			}
			if (!this.mActorController.IsGrounded)
			{
				return false;
			}
			if (this.mMotionController._InputSource == null)
			{
				return false;
			}
			if (this.mMotionController._InputSource.IsJustPressed(this._ActionAlias))
			{
				if (this._RequiredOverheadDistance > 0f && RaycastExt.SafeRaycast(this.mActorController._Transform.position, this.mActorController._Transform.up, this._RequiredOverheadDistance, this.mActorController._CollisionLayers, this.mActorController._Transform, null, true))
				{
					return false;
				}
				if (this.IsInLandedState || !this.IsInMotionState)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000F6A RID: 3946 RVA: 0x0004FDCC File Offset: 0x0004DFCC
		public override bool TestUpdate()
		{
			return this.mIsActivatedFrame || ((this._MaxJumpTime <= 0f || this.mMotionLayer.ActiveMotionDuration <= this._MaxJumpTime) && (!this.mIsAnimatorActive || this.IsInMotionState || this.mMotionLayer._AnimatorTransitionID != 0) && (this._RequiredOverheadDistance <= 0f || !RaycastExt.SafeRaycast(this.mMotionController.transform.position, Vector3.up, this._RequiredOverheadDistance, -1, null, null, true)));
		}

		// Token: 0x06000F6B RID: 3947 RVA: 0x0004FE5C File Offset: 0x0004E05C
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
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
					this.mHipBone = this.mActorController._Transform.Find(this._HipBoneName);
				}
				if (this.mHipBone == null)
				{
					Animator animator = this.mMotionController.Animator;
					if (animator != null)
					{
						this.mHipBone = animator.GetBoneTransform(HumanBodyBones.Hips);
						if (this.mHipBone != null)
						{
							this._HipBoneName = this.mHipBone.name;
						}
					}
				}
			}
			this.mLastHipDistance = 0f;
			this.mIsImpulseApplied = false;
			this.mLaunchForward = this.mActorController._Transform.forward;
			this.mLaunchVelocity = ((this.mLaunchVelocityOverride.sqrMagnitude > 0f) ? this.mLaunchVelocityOverride : this.mActorController.State.Velocity);
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 251, true);
			if (this._RotateWithCamera && this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
				BaseCameraRig baseCameraRig2 = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig2.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Combine(baseCameraRig2.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000F6C RID: 3948 RVA: 0x00050020 File Offset: 0x0004E220
		public override void Deactivate()
		{
			this.mLaunchVelocityOverride = Vector3.zero;
			if (this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			base.Deactivate();
		}

		// Token: 0x06000F6D RID: 3949 RVA: 0x00050081 File Offset: 0x0004E281
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rVelocityDelta, ref Quaternion rRotationDelta)
		{
			rRotationDelta = Quaternion.identity;
			if (!this.IsInLandedState)
			{
				rVelocityDelta = Vector3.zero;
			}
		}

		// Token: 0x06000F6E RID: 3950 RVA: 0x000500A4 File Offset: 0x0004E2A4
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mMovement = Vector3.zero;
			bool flag = false;
			float num = 0f;
			if (rUpdateIndex != 1)
			{
				return;
			}
			MotionState state = this.mMotionController.State;
			int animatorStateID = this.mMotionLayer._AnimatorStateID;
			float animatorStateNormalizedTime = this.mMotionLayer._AnimatorStateNormalizedTime;
			int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
			float animatorTransitionNormalizedTime = this.mMotionLayer._AnimatorTransitionNormalizedTime;
			Quaternion quaternion = QuaternionExt.FromToRotation(this.mActorController._Transform.up, Vector3.up);
			Vector3 vector = this.mActorController.State.Velocity;
			if (Time.deltaTime > Time.fixedDeltaTime)
			{
				vector = this.mActorController.State.Velocity * Time.deltaTime / Time.fixedDeltaTime;
			}
			vector = quaternion * vector;
			if (this._ConvertToHipBase && this.mHipBone != null)
			{
				float y = (-this.mHipBone.InverseTransformPoint(this.mActorController._Transform.position)).y;
				num = -(y - this.mLastHipDistance);
				this.mLastHipDistance = y;
			}
			if (animatorTransitionID == Jump.TRANS_EntryState_JumpRise)
			{
				if (!this.mIsImpulseApplied && animatorTransitionNormalizedTime > 0.5f)
				{
					this.mIsImpulseApplied = true;
					this.mActorController.AddImpulse(this.mActorController._Transform.up * this._Impulse);
				}
			}
			else if (animatorStateID == Jump.STATE_JumpRise)
			{
				if (!this.mIsImpulseApplied)
				{
					this.mIsImpulseApplied = true;
					this.mActorController.AddImpulse(this.mActorController._Transform.up * this._Impulse);
				}
				else if (vector.y < 1.5f)
				{
					this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 203);
				}
			}
			else if (animatorStateID == Jump.STATE_JumpRisePose)
			{
				if (vector.y < 2.5f)
				{
					this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 203);
				}
				this.mMovement = this.mActorController._Transform.up * num;
			}
			else if (animatorStateID == Jump.STATE_JumpRiseToTop)
			{
				if (vector.y < -1.5f)
				{
					this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 205);
				}
				this.mMovement = this.mActorController._Transform.up * num;
			}
			else if (animatorStateID == Jump.STATE_JumpTopPose)
			{
				if (this.mActorController.State.GroundSurfaceDistance < 0.5f)
				{
					this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 208);
				}
				else if (vector.y < -0.25f)
				{
					this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 205);
				}
				else
				{
					this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 204);
				}
				this.mMovement = this.mActorController._Transform.up * num;
			}
			else if (animatorStateID == Jump.STATE_JumpTopToFall)
			{
				if (this.mActorController.State.GroundSurfaceDistance < 0.15f)
				{
					this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 208);
				}
				else if (this.mActorController.State.GroundSurfaceDistance < 0.35f)
				{
					this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 207);
				}
				this.mMovement = this.mActorController._Transform.up * num;
			}
			else if (animatorStateID == Jump.STATE_JumpFallPose)
			{
				if (this.mActorController.State.GroundSurfaceDistance < 0.35f)
				{
					this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 207);
				}
				this.mMovement = this.mActorController._Transform.up * num;
			}
			else if (animatorStateID == Jump.STATE_JumpLand)
			{
				if (this.mActorController.State.IsGrounded)
				{
					if (state.InputMagnitudeTrend.Value < 0.03f)
					{
						this.mLaunchVelocity = Vector3.zero;
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 208);
					}
					else if (this.mWalkRunMotion != null && this.mWalkRunMotion.IsEnabled && this.mWalkRunMotion.IsRunActive)
					{
						if (Mathf.Abs(state.InputFromAvatarAngle) > 140f)
						{
							this.mLaunchVelocity = Vector3.zero;
						}
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 209);
					}
					else
					{
						this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 208);
					}
				}
				else
				{
					this.mMovement = this.mActorController._Transform.up * num;
				}
			}
			else if (animatorStateID == Jump.STATE_JumpRecoverIdle)
			{
				this.mIsStartable = true;
				if (state.InputMagnitudeTrend.Value >= 0.1f && Mathf.Abs(state.InputFromAvatarAngle) < 20f)
				{
					flag = true;
					if (animatorStateNormalizedTime > 0.3f && this.mWalkRunMotion != null && this.mWalkRunMotion.IsEnabled)
					{
						this.mWalkRunMotion.StartInRun = this.mWalkRunMotion.IsRunActive;
						this.mWalkRunMotion.StartInWalk = !this.mWalkRunMotion.StartInRun;
						this.mMotionController.ActivateMotion(this.mWalkRunMotion as MotionControllerMotion, 0);
					}
				}
			}
			else if (animatorStateID == Jump.STATE_JumpRecoverRun)
			{
				this.mLaunchVelocity = Vector3.zero;
				if (this.mWalkRunMotion != null && this.mWalkRunMotion.IsEnabled)
				{
					flag = true;
					if (animatorStateNormalizedTime > 0.2f)
					{
						this.mWalkRunMotion.StartInRun = this.mWalkRunMotion.IsRunActive;
						this.mWalkRunMotion.StartInWalk = !this.mWalkRunMotion.StartInRun;
						this.mMotionController.ActivateMotion(this.mWalkRunMotion as MotionControllerMotion, 0);
					}
				}
				else
				{
					this.Deactivate();
				}
			}
			else if (animatorStateID == Jump.STATE_IdlePose && this.mAge > 0.05f)
			{
				this.Deactivate();
			}
			this.mRotateWithCamera = false;
			if (this._RotateWithCamera && this.mMotionController._CameraTransform != null && (this._RotateWithCameraAlias.Length == 0 || this.mMotionController._InputSource.IsPressed(this._RotateWithCameraAlias)))
			{
				this.mRotateWithCamera = true;
			}
			if (this.mRotateWithCamera && !(this.mMotionController.CameraRig is BaseCameraRig))
			{
				this.OnCameraUpdated(rDeltaTime, rUpdateIndex, null);
			}
			this.mMotionController.State = state;
			this.mVelocity = this.DetermineVelocity(flag);
		}

		// Token: 0x06000F6F RID: 3951 RVA: 0x00050790 File Offset: 0x0004E990
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

		// Token: 0x06000F70 RID: 3952 RVA: 0x00050804 File Offset: 0x0004EA04
		protected Vector3 DetermineVelocity(bool rAllowSlide)
		{
			Vector3 vector = Vector3.zero;
			int animatorStateID = this.mMotionLayer._AnimatorStateID;
			if (this.mActorController.State.IsColliding)
			{
				return vector;
			}
			if ((animatorStateID != Jump.STATE_JumpRecoverIdle || rAllowSlide) && (animatorStateID != Jump.STATE_JumpRecoverRun || rAllowSlide) && this.IsInMotionState)
			{
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
			}
			return vector;
		}

		// Token: 0x06000F71 RID: 3953 RVA: 0x0005097C File Offset: 0x0004EB7C
		private void OnCameraUpdated(float rDeltaTime, int rUpdateIndex, BaseCameraRig rCamera)
		{
			if (!this.mRotateWithCamera)
			{
				return;
			}
			if (this.mMotionController._CameraTransform == null)
			{
				return;
			}
			float num = this.mMotionController._Transform.forward.HorizontalAngleTo(this.mMotionController._CameraTransform.forward, this.mMotionController._Transform.up);
			if (!this.mLinkRotation && Mathf.Abs(num) <= this._RotationToCameraSpeed * rDeltaTime)
			{
				this.mLinkRotation = true;
			}
			if (!this.mLinkRotation)
			{
				float num2 = Mathf.Abs(num);
				num = Mathf.Sign(num) * Mathf.Min(this._RotationToCameraSpeed * rDeltaTime, num2);
			}
			Quaternion quaternion = Quaternion.AngleAxis(num, Vector3.up);
			this.mActorController.Yaw = this.mActorController.Yaw * quaternion;
			this.mActorController._Transform.rotation = this.mActorController.Tilt * this.mActorController.Yaw;
		}

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x06000F72 RID: 3954 RVA: 0x00050A74 File Offset: 0x0004EC74
		protected bool IsInMidJumpState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				if (animatorStateID == Jump.STATE_JumpRise)
				{
					return true;
				}
				if (animatorStateID == Jump.STATE_JumpRisePose)
				{
					return true;
				}
				if (animatorStateID == Jump.STATE_JumpRiseToTop)
				{
					return true;
				}
				if (animatorStateID == Jump.STATE_JumpTopPose)
				{
					return true;
				}
				if (animatorStateID == Jump.STATE_JumpTopToFall)
				{
					return true;
				}
				if (animatorStateID == Jump.STATE_JumpFallPose)
				{
					return true;
				}
				if (animatorStateID == Jump.STATE_JumpLand)
				{
					return true;
				}
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorTransitionID == Jump.TRANS_EntryState_JumpRise || animatorTransitionID == Jump.TRANS_AnyState_JumpRise || animatorTransitionID == Jump.TRANS_EntryState_JumpFallPose || animatorTransitionID == Jump.TRANS_AnyState_JumpFallPose;
			}
		}

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x06000F73 RID: 3955 RVA: 0x00050B08 File Offset: 0x0004ED08
		protected bool IsInLandedState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				return animatorStateID == Jump.STATE_JumpRecoverRun || animatorStateID == Jump.STATE_IdlePose;
			}
		}

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x06000F74 RID: 3956 RVA: 0x00050B38 File Offset: 0x0004ED38
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == Jump.STATE_JumpRise || animatorStateID == Jump.STATE_JumpLand || animatorStateID == Jump.STATE_JumpRisePose || animatorStateID == Jump.STATE_JumpFallPose || animatorStateID == Jump.STATE_JumpTopToFall || animatorStateID == Jump.STATE_JumpRiseToTop || animatorStateID == Jump.STATE_JumpTopPose || animatorStateID == Jump.STATE_JumpRecoverIdle || animatorStateID == Jump.STATE_JumpRecoverRun || animatorStateID == Jump.STATE_IdlePose || animatorTransitionID == Jump.TRANS_EntryState_JumpRise || animatorTransitionID == Jump.TRANS_AnyState_JumpRise || animatorTransitionID == Jump.TRANS_EntryState_JumpFallPose || animatorTransitionID == Jump.TRANS_AnyState_JumpFallPose || animatorTransitionID == Jump.TRANS_JumpRise_JumpRiseToTop || animatorTransitionID == Jump.TRANS_JumpRise_JumpRisePose || animatorTransitionID == Jump.TRANS_JumpLand_JumpRecoverRun || animatorTransitionID == Jump.TRANS_JumpLand_JumpRecoverIdle || animatorTransitionID == Jump.TRANS_JumpRisePose_JumpRiseToTop || animatorTransitionID == Jump.TRANS_JumpFallPose_JumpLand || animatorTransitionID == Jump.TRANS_JumpTopToFall_JumpLand || animatorTransitionID == Jump.TRANS_JumpTopToFall_JumpFallPose || animatorTransitionID == Jump.TRANS_JumpTopToFall_JumpRecoverIdle || animatorTransitionID == Jump.TRANS_JumpTopToFall_JumpRecoverRun || animatorTransitionID == Jump.TRANS_JumpRiseToTop_JumpTopToFall || animatorTransitionID == Jump.TRANS_JumpRiseToTop_JumpTopPose || animatorTransitionID == Jump.TRANS_JumpRiseToTop_JumpRecoverIdle || animatorTransitionID == Jump.TRANS_JumpRiseToTop_JumpRecoverRun || animatorTransitionID == Jump.TRANS_JumpTopPose_JumpTopToFall || animatorTransitionID == Jump.TRANS_JumpTopPose_JumpRecoverIdle || animatorTransitionID == Jump.TRANS_JumpRecoverIdle_IdlePose;
			}
		}

		// Token: 0x06000F75 RID: 3957 RVA: 0x00050C94 File Offset: 0x0004EE94
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == Jump.STATE_JumpRise || rStateID == Jump.STATE_JumpLand || rStateID == Jump.STATE_JumpRisePose || rStateID == Jump.STATE_JumpFallPose || rStateID == Jump.STATE_JumpTopToFall || rStateID == Jump.STATE_JumpRiseToTop || rStateID == Jump.STATE_JumpTopPose || rStateID == Jump.STATE_JumpRecoverIdle || rStateID == Jump.STATE_JumpRecoverRun || rStateID == Jump.STATE_IdlePose;
		}

		// Token: 0x06000F76 RID: 3958 RVA: 0x00050D08 File Offset: 0x0004EF08
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == Jump.STATE_JumpRise || rStateID == Jump.STATE_JumpLand || rStateID == Jump.STATE_JumpRisePose || rStateID == Jump.STATE_JumpFallPose || rStateID == Jump.STATE_JumpTopToFall || rStateID == Jump.STATE_JumpRiseToTop || rStateID == Jump.STATE_JumpTopPose || rStateID == Jump.STATE_JumpRecoverIdle || rStateID == Jump.STATE_JumpRecoverRun || rStateID == Jump.STATE_IdlePose || rTransitionID == Jump.TRANS_EntryState_JumpRise || rTransitionID == Jump.TRANS_AnyState_JumpRise || rTransitionID == Jump.TRANS_EntryState_JumpFallPose || rTransitionID == Jump.TRANS_AnyState_JumpFallPose || rTransitionID == Jump.TRANS_JumpRise_JumpRiseToTop || rTransitionID == Jump.TRANS_JumpRise_JumpRisePose || rTransitionID == Jump.TRANS_JumpLand_JumpRecoverRun || rTransitionID == Jump.TRANS_JumpLand_JumpRecoverIdle || rTransitionID == Jump.TRANS_JumpRisePose_JumpRiseToTop || rTransitionID == Jump.TRANS_JumpFallPose_JumpLand || rTransitionID == Jump.TRANS_JumpTopToFall_JumpLand || rTransitionID == Jump.TRANS_JumpTopToFall_JumpFallPose || rTransitionID == Jump.TRANS_JumpTopToFall_JumpRecoverIdle || rTransitionID == Jump.TRANS_JumpTopToFall_JumpRecoverRun || rTransitionID == Jump.TRANS_JumpRiseToTop_JumpTopToFall || rTransitionID == Jump.TRANS_JumpRiseToTop_JumpTopPose || rTransitionID == Jump.TRANS_JumpRiseToTop_JumpRecoverIdle || rTransitionID == Jump.TRANS_JumpRiseToTop_JumpRecoverRun || rTransitionID == Jump.TRANS_JumpTopPose_JumpTopToFall || rTransitionID == Jump.TRANS_JumpTopPose_JumpRecoverIdle || rTransitionID == Jump.TRANS_JumpRecoverIdle_IdlePose;
		}

		// Token: 0x06000F77 RID: 3959 RVA: 0x00050E4C File Offset: 0x0004F04C
		public override void LoadAnimatorData()
		{
			Jump.TRANS_EntryState_JumpRise = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Jump-SM.JumpRise");
			Jump.TRANS_AnyState_JumpRise = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Jump-SM.JumpRise");
			Jump.TRANS_EntryState_JumpFallPose = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Jump-SM.JumpFallPose");
			Jump.TRANS_AnyState_JumpFallPose = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Jump-SM.JumpFallPose");
			Jump.STATE_JumpRise = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpRise");
			Jump.TRANS_JumpRise_JumpRiseToTop = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpRise -> Base Layer.Jump-SM.JumpRiseToTop");
			Jump.TRANS_JumpRise_JumpRisePose = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpRise -> Base Layer.Jump-SM.JumpRisePose");
			Jump.STATE_JumpLand = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpLand");
			Jump.TRANS_JumpLand_JumpRecoverRun = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpLand -> Base Layer.Jump-SM.JumpRecoverRun");
			Jump.TRANS_JumpLand_JumpRecoverIdle = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpLand -> Base Layer.Jump-SM.JumpRecoverIdle");
			Jump.STATE_JumpRisePose = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpRisePose");
			Jump.TRANS_JumpRisePose_JumpRiseToTop = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpRisePose -> Base Layer.Jump-SM.JumpRiseToTop");
			Jump.STATE_JumpFallPose = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpFallPose");
			Jump.TRANS_JumpFallPose_JumpLand = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpFallPose -> Base Layer.Jump-SM.JumpLand");
			Jump.STATE_JumpTopToFall = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpTopToFall");
			Jump.TRANS_JumpTopToFall_JumpLand = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpTopToFall -> Base Layer.Jump-SM.JumpLand");
			Jump.TRANS_JumpTopToFall_JumpFallPose = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpTopToFall -> Base Layer.Jump-SM.JumpFallPose");
			Jump.TRANS_JumpTopToFall_JumpRecoverIdle = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpTopToFall -> Base Layer.Jump-SM.JumpRecoverIdle");
			Jump.TRANS_JumpTopToFall_JumpRecoverRun = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpTopToFall -> Base Layer.Jump-SM.JumpRecoverRun");
			Jump.STATE_JumpRiseToTop = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpRiseToTop");
			Jump.TRANS_JumpRiseToTop_JumpTopToFall = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpRiseToTop -> Base Layer.Jump-SM.JumpTopToFall");
			Jump.TRANS_JumpRiseToTop_JumpTopPose = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpRiseToTop -> Base Layer.Jump-SM.JumpTopPose");
			Jump.TRANS_JumpRiseToTop_JumpRecoverIdle = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpRiseToTop -> Base Layer.Jump-SM.JumpRecoverIdle");
			Jump.TRANS_JumpRiseToTop_JumpRecoverRun = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpRiseToTop -> Base Layer.Jump-SM.JumpRecoverRun");
			Jump.STATE_JumpTopPose = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpTopPose");
			Jump.TRANS_JumpTopPose_JumpTopToFall = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpTopPose -> Base Layer.Jump-SM.JumpTopToFall");
			Jump.TRANS_JumpTopPose_JumpRecoverIdle = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpTopPose -> Base Layer.Jump-SM.JumpRecoverIdle");
			Jump.STATE_JumpRecoverIdle = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpRecoverIdle");
			Jump.TRANS_JumpRecoverIdle_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpRecoverIdle -> Base Layer.Jump-SM.IdlePose");
			Jump.STATE_JumpRecoverRun = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.JumpRecoverRun");
			Jump.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Jump-SM.IdlePose");
		}

		// Token: 0x04000976 RID: 2422
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000977 RID: 2423
		public const int PHASE_START = 251;

		// Token: 0x04000978 RID: 2424
		public const int PHASE_START_FALL = 250;

		// Token: 0x04000979 RID: 2425
		public const int PHASE_LAUNCH = 201;

		// Token: 0x0400097A RID: 2426
		public const int PHASE_RISE = 202;

		// Token: 0x0400097B RID: 2427
		public const int PHASE_RISE_TO_TOP = 203;

		// Token: 0x0400097C RID: 2428
		public const int PHASE_TOP = 204;

		// Token: 0x0400097D RID: 2429
		public const int PHASE_TOP_TO_FALL = 205;

		// Token: 0x0400097E RID: 2430
		public const int PHASE_FALL = 206;

		// Token: 0x0400097F RID: 2431
		public const int PHASE_LAND = 207;

		// Token: 0x04000980 RID: 2432
		public const int PHASE_RECOVER_TO_IDLE = 208;

		// Token: 0x04000981 RID: 2433
		public const int PHASE_RECOVER_TO_MOVE = 209;

		// Token: 0x04000982 RID: 2434
		public const int PHASE_RUN = 210;

		// Token: 0x04000983 RID: 2435
		public const int PHASE_WALK = 211;

		// Token: 0x04000984 RID: 2436
		protected float _Impulse = 10f;

		// Token: 0x04000985 RID: 2437
		public bool _ConvertToHipBase;

		// Token: 0x04000986 RID: 2438
		public string _HipBoneName = "";

		// Token: 0x04000987 RID: 2439
		public bool _IsMomentumEnabled = true;

		// Token: 0x04000988 RID: 2440
		public bool _IsControlEnabled = true;

		// Token: 0x04000989 RID: 2441
		public float _ControlSpeed = 2f;

		// Token: 0x0400098A RID: 2442
		public float _RequiredOverheadDistance;

		// Token: 0x0400098B RID: 2443
		public float _MaxJumpTime = 5f;

		// Token: 0x0400098C RID: 2444
		protected Vector3 mLaunchVelocityOverride = Vector3.zero;

		// Token: 0x0400098D RID: 2445
		public bool _RotateWithCamera;

		// Token: 0x0400098E RID: 2446
		public string _RotateWithCameraAlias = "ActivateRotation";

		// Token: 0x0400098F RID: 2447
		public float _RotationToCameraSpeed = 360f;

		// Token: 0x04000990 RID: 2448
		protected Vector3 mLaunchForward = Vector3.zero;

		// Token: 0x04000991 RID: 2449
		protected Vector3 mLaunchVelocity = Vector3.zero;

		// Token: 0x04000992 RID: 2450
		protected Transform mHipBone;

		// Token: 0x04000993 RID: 2451
		protected float mLastHipDistance;

		// Token: 0x04000994 RID: 2452
		protected bool mIsImpulseApplied;

		// Token: 0x04000995 RID: 2453
		protected IWalkRunMotion mWalkRunMotion;

		// Token: 0x04000996 RID: 2454
		protected bool mRotateWithCamera;

		// Token: 0x04000997 RID: 2455
		protected bool mLinkRotation;

		// Token: 0x04000998 RID: 2456
		public static int TRANS_EntryState_JumpRise = -1;

		// Token: 0x04000999 RID: 2457
		public static int TRANS_AnyState_JumpRise = -1;

		// Token: 0x0400099A RID: 2458
		public static int TRANS_EntryState_JumpFallPose = -1;

		// Token: 0x0400099B RID: 2459
		public static int TRANS_AnyState_JumpFallPose = -1;

		// Token: 0x0400099C RID: 2460
		public static int STATE_JumpRise = -1;

		// Token: 0x0400099D RID: 2461
		public static int TRANS_JumpRise_JumpRiseToTop = -1;

		// Token: 0x0400099E RID: 2462
		public static int TRANS_JumpRise_JumpRisePose = -1;

		// Token: 0x0400099F RID: 2463
		public static int STATE_JumpLand = -1;

		// Token: 0x040009A0 RID: 2464
		public static int TRANS_JumpLand_JumpRecoverRun = -1;

		// Token: 0x040009A1 RID: 2465
		public static int TRANS_JumpLand_JumpRecoverIdle = -1;

		// Token: 0x040009A2 RID: 2466
		public static int STATE_JumpRisePose = -1;

		// Token: 0x040009A3 RID: 2467
		public static int TRANS_JumpRisePose_JumpRiseToTop = -1;

		// Token: 0x040009A4 RID: 2468
		public static int STATE_JumpFallPose = -1;

		// Token: 0x040009A5 RID: 2469
		public static int TRANS_JumpFallPose_JumpLand = -1;

		// Token: 0x040009A6 RID: 2470
		public static int STATE_JumpTopToFall = -1;

		// Token: 0x040009A7 RID: 2471
		public static int TRANS_JumpTopToFall_JumpLand = -1;

		// Token: 0x040009A8 RID: 2472
		public static int TRANS_JumpTopToFall_JumpFallPose = -1;

		// Token: 0x040009A9 RID: 2473
		public static int TRANS_JumpTopToFall_JumpRecoverIdle = -1;

		// Token: 0x040009AA RID: 2474
		public static int TRANS_JumpTopToFall_JumpRecoverRun = -1;

		// Token: 0x040009AB RID: 2475
		public static int STATE_JumpRiseToTop = -1;

		// Token: 0x040009AC RID: 2476
		public static int TRANS_JumpRiseToTop_JumpTopToFall = -1;

		// Token: 0x040009AD RID: 2477
		public static int TRANS_JumpRiseToTop_JumpTopPose = -1;

		// Token: 0x040009AE RID: 2478
		public static int TRANS_JumpRiseToTop_JumpRecoverIdle = -1;

		// Token: 0x040009AF RID: 2479
		public static int TRANS_JumpRiseToTop_JumpRecoverRun = -1;

		// Token: 0x040009B0 RID: 2480
		public static int STATE_JumpTopPose = -1;

		// Token: 0x040009B1 RID: 2481
		public static int TRANS_JumpTopPose_JumpTopToFall = -1;

		// Token: 0x040009B2 RID: 2482
		public static int TRANS_JumpTopPose_JumpRecoverIdle = -1;

		// Token: 0x040009B3 RID: 2483
		public static int STATE_JumpRecoverIdle = -1;

		// Token: 0x040009B4 RID: 2484
		public static int TRANS_JumpRecoverIdle_IdlePose = -1;

		// Token: 0x040009B5 RID: 2485
		public static int STATE_JumpRecoverRun = -1;

		// Token: 0x040009B6 RID: 2486
		public static int STATE_IdlePose = -1;
	}
}
