using System;
using com.ootii.Actors.AnimationControllers;
using com.ootii.Cameras;
using com.ootii.Geometry;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ootii.MotionControllers
{
	// Token: 0x02000163 RID: 355
	[MotionName("TavoIdleMale")]
	[MotionDescription("Simple idle motion to be used as a default motion. It can also rotate the actor with the camera view.")]
	public class TavoIdleMale : MotionControllerMotion
	{
		// Token: 0x17000181 RID: 385
		// (get) Token: 0x0600076A RID: 1898 RVA: 0x00027044 File Offset: 0x00025244
		// (set) Token: 0x0600076B RID: 1899 RVA: 0x0002704C File Offset: 0x0002524C
		public int FormCondition
		{
			get
			{
				return this._FormCondition;
			}
			set
			{
				this._FormCondition = value;
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x0600076C RID: 1900 RVA: 0x00027055 File Offset: 0x00025255
		// (set) Token: 0x0600076D RID: 1901 RVA: 0x00027060 File Offset: 0x00025260
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

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x0600076E RID: 1902 RVA: 0x000270FE File Offset: 0x000252FE
		// (set) Token: 0x0600076F RID: 1903 RVA: 0x00027106 File Offset: 0x00025306
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

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000770 RID: 1904 RVA: 0x0002710F File Offset: 0x0002530F
		// (set) Token: 0x06000771 RID: 1905 RVA: 0x00027117 File Offset: 0x00025317
		public bool RotateWithInput
		{
			get
			{
				return this._RotateWithInput;
			}
			set
			{
				this._RotateWithInput = value;
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000772 RID: 1906 RVA: 0x00027120 File Offset: 0x00025320
		// (set) Token: 0x06000773 RID: 1907 RVA: 0x00027128 File Offset: 0x00025328
		public bool RotateWithMovementInputX
		{
			get
			{
				return this._RotateWithMovementInputX;
			}
			set
			{
				this._RotateWithMovementInputX = value;
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000774 RID: 1908 RVA: 0x00027131 File Offset: 0x00025331
		// (set) Token: 0x06000775 RID: 1909 RVA: 0x00027139 File Offset: 0x00025339
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

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000776 RID: 1910 RVA: 0x00027142 File Offset: 0x00025342
		// (set) Token: 0x06000777 RID: 1911 RVA: 0x0002714A File Offset: 0x0002534A
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

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000778 RID: 1912 RVA: 0x00027153 File Offset: 0x00025353
		// (set) Token: 0x06000779 RID: 1913 RVA: 0x0002715B File Offset: 0x0002535B
		public bool ForceViewOnInput
		{
			get
			{
				return this._ForceViewOnInput;
			}
			set
			{
				this._ForceViewOnInput = value;
			}
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x00027164 File Offset: 0x00025364
		public TavoIdleMale()
		{
			this._Category = 1;
			this._Priority = 0f;
			this._ActionAlias = "ActivateRotation";
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x000271BC File Offset: 0x000253BC
		public TavoIdleMale(MotionController rController)
			: base(rController)
		{
			this._Category = 1;
			this._Priority = 0f;
			this._ActionAlias = "ActivateRotation";
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x00027215 File Offset: 0x00025415
		public override void Awake()
		{
			base.Awake();
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x00027220 File Offset: 0x00025420
		public override bool TestActivate()
		{
			if (this._FormCondition >= 0 && this.mMotionController.CurrentForm != this._FormCondition)
			{
				return false;
			}
			if (this.mMotionLayer.ActiveMotion == null)
			{
				if (this.mMotionController.IsGrounded)
				{
					return true;
				}
				if (this.mMotionLayer.ActiveMotionDuration > 1f)
				{
					return true;
				}
			}
			return this.mIsStartable && this.mMotionController.IsGrounded && this.mMotionController.State.InputMagnitudeTrend.Average == 0f;
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x000272B3 File Offset: 0x000254B3
		public override bool TestUpdate()
		{
			return !this.mIsAnimatorActive || this.IsInMotionState;
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x000272C8 File Offset: 0x000254C8
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mYaw = 0f;
			this.mYawTarget = 0f;
			this.mYawVelocity = 0f;
			this.mLinkRotation = false;
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 100, true);
			if (this._RotateWithCamera && this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
				BaseCameraRig baseCameraRig2 = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig2.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Combine(baseCameraRig2.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x0002739C File Offset: 0x0002559C
		public override void Deactivate()
		{
			int stance = this.mActorController.State.Stance;
			if (this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			base.Deactivate();
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x00027405 File Offset: 0x00025605
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			rMovement = Vector3.zero;
			rRotation = Quaternion.identity;
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x00027420 File Offset: 0x00025620
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mMotionController.State.InputMagnitudeTrend.Value = 0f;
			this.mVelocity = Vector3.zero;
			this.mMovement = Vector3.zero;
			this.mAngularVelocity = Vector3.zero;
			this.mRotation = Quaternion.identity;
			this.mRotateWithCamera = false;
			if (this._RotateWithCamera && this.mMotionController._CameraTransform != null && (this._ActionAlias.Length == 0 || this.mMotionController._InputSource.IsPressed(this._ActionAlias)))
			{
				this.mRotateWithCamera = true;
			}
			if (this.mRotateWithCamera && !(this.mMotionController.CameraRig is BaseCameraRig))
			{
				this.OnCameraUpdated(rDeltaTime, rUpdateIndex, null);
			}
			if (!this.mRotateWithCamera)
			{
				this.mLinkRotation = false;
				this.RotateUsingInput(rDeltaTime, ref this.mRotation);
			}
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x00027500 File Offset: 0x00025700
		private void RotateUsingInput(float rDeltaTime, ref Quaternion rRotation)
		{
			if (this.mMotionController._InputSource == null)
			{
				return;
			}
			float num = 0f;
			if (this._RotateWithMovementInputX)
			{
				num = this.mMotionController._InputSource.MovementX * this._RotationSpeed * rDeltaTime;
				if (num != 0f)
				{
					this.mYaw += num;
					this.mYawTarget = this.mYaw;
					rRotation = Quaternion.Euler(0f, num, 0f);
					if (this._ForceViewOnInput && this.mMotionController.CameraRig is BaseCameraRig)
					{
						((BaseCameraRig)this.mMotionController.CameraRig).FrameForceToFollowAnchor = true;
					}
					return;
				}
			}
			if (num == 0f && this._RotateWithInput && this.mMotionController._InputSource.IsViewingActivated)
			{
				num = this.mMotionController._InputSource.ViewX * this._RotationSpeed * rDeltaTime;
			}
			this.mYawTarget += num;
			num = ((this._RotationSmoothing <= 0f) ? this.mYawTarget : Mathf.SmoothDampAngle(this.mYaw, this.mYawTarget, ref this.mYawVelocity, this._RotationSmoothing)) - this.mYaw;
			this.mYaw += num;
			if (num != 0f)
			{
				rRotation = Quaternion.Euler(0f, num, 0f);
			}
			if (this._ForceViewOnInput && this.mMotionController._InputSource.MovementX != 0f && this.mMotionController.CameraRig is BaseCameraRig)
			{
				((BaseCameraRig)this.mMotionController.CameraRig).FrameForceToFollowAnchor = true;
			}
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x000276A8 File Offset: 0x000258A8
		private void OnCameraUpdated(float rDeltaTime, int rUpdateIndex, BaseCameraRig rCamera)
		{
			if (!this.mMotionController.enabled)
			{
				return;
			}
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

		// Token: 0x06000785 RID: 1925 RVA: 0x000277AD File Offset: 0x000259AD
		public static string GroupName()
		{
			return "Basic";
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000786 RID: 1926 RVA: 0x000277B4 File Offset: 0x000259B4
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == TavoIdleMale.STATE_IdlePose || animatorTransitionID == TavoIdleMale.TRANS_EntryState_IdlePose || animatorTransitionID == TavoIdleMale.TRANS_AnyState_IdlePose;
			}
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x000277F6 File Offset: 0x000259F6
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == TavoIdleMale.STATE_IdlePose;
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x00027803 File Offset: 0x00025A03
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == TavoIdleMale.STATE_IdlePose || rTransitionID == TavoIdleMale.TRANS_EntryState_IdlePose || rTransitionID == TavoIdleMale.TRANS_AnyState_IdlePose;
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x00027824 File Offset: 0x00025A24
		public override void LoadAnimatorData()
		{
			TavoIdleMale.TRANS_EntryState_IdlePose = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Idle-SM.IdlePose");
			TavoIdleMale.TRANS_AnyState_IdlePose = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Idle-SM.IdlePose");
			TavoIdleMale.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Idle-SM.IdlePose");
		}

		// Token: 0x040005D8 RID: 1496
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x040005D9 RID: 1497
		public const int PHASE_START = 100;

		// Token: 0x040005DA RID: 1498
		public int _FormCondition;

		// Token: 0x040005DB RID: 1499
		public bool _RotateWithCamera = true;

		// Token: 0x040005DC RID: 1500
		public float _RotationToCameraSpeed = 360f;

		// Token: 0x040005DD RID: 1501
		public bool _RotateWithInput;

		// Token: 0x040005DE RID: 1502
		public bool _RotateWithMovementInputX;

		// Token: 0x040005DF RID: 1503
		public float _RotationSpeed = 120f;

		// Token: 0x040005E0 RID: 1504
		public float _RotationSmoothing = 0.1f;

		// Token: 0x040005E1 RID: 1505
		public bool _ForceViewOnInput;

		// Token: 0x040005E2 RID: 1506
		protected bool mRotateWithCamera;

		// Token: 0x040005E3 RID: 1507
		protected bool mLinkRotation;

		// Token: 0x040005E4 RID: 1508
		protected float mYaw;

		// Token: 0x040005E5 RID: 1509
		protected float mYawTarget;

		// Token: 0x040005E6 RID: 1510
		protected float mYawVelocity;

		// Token: 0x040005E7 RID: 1511
		public static int TRANS_EntryState_IdlePose = -1;

		// Token: 0x040005E8 RID: 1512
		public static int TRANS_AnyState_IdlePose = -1;

		// Token: 0x040005E9 RID: 1513
		public static int STATE_IdlePose = -1;
	}
}
