using System;
using com.ootii.Cameras;
using com.ootii.Geometry;
using com.ootii.Helpers;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x02000113 RID: 275
	[MotionName("Sneak")]
	[MotionDescription("A forward facing motion that looks like the actor is sneaking. The motion is slower than a walk and has the actor strafe instead of turn.")]
	public class Sneak_v2 : MotionControllerMotion
	{
		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x0600104A RID: 4170 RVA: 0x00056C1F File Offset: 0x00054E1F
		// (set) Token: 0x0600104B RID: 4171 RVA: 0x00056C27 File Offset: 0x00054E27
		public float MovementSpeed
		{
			get
			{
				return this._MovementSpeed;
			}
			set
			{
				this._MovementSpeed = value;
			}
		}

		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x0600104C RID: 4172 RVA: 0x00056C30 File Offset: 0x00054E30
		// (set) Token: 0x0600104D RID: 4173 RVA: 0x00056C38 File Offset: 0x00054E38
		public bool RotateWithInput
		{
			get
			{
				return this._RotateWithInput;
			}
			set
			{
				this._RotateWithInput = value;
				if (this._RotateWithInput)
				{
					this._RotateWithCamera = false;
				}
			}
		}

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x0600104E RID: 4174 RVA: 0x00056C50 File Offset: 0x00054E50
		// (set) Token: 0x0600104F RID: 4175 RVA: 0x00056C58 File Offset: 0x00054E58
		public bool RotateWithCamera
		{
			get
			{
				return this._RotateWithCamera;
			}
			set
			{
				this._RotateWithCamera = value;
				if (this._RotateWithCamera)
				{
					this._RotateWithInput = false;
				}
			}
		}

		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x06001050 RID: 4176 RVA: 0x00056C70 File Offset: 0x00054E70
		// (set) Token: 0x06001051 RID: 4177 RVA: 0x00056C78 File Offset: 0x00054E78
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

		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x06001052 RID: 4178 RVA: 0x00056C81 File Offset: 0x00054E81
		// (set) Token: 0x06001053 RID: 4179 RVA: 0x00056C89 File Offset: 0x00054E89
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

		// Token: 0x06001054 RID: 4180 RVA: 0x00056CC8 File Offset: 0x00054EC8
		public Sneak_v2()
		{
			this._Priority = 6f;
			this._ActionAlias = "ChangeStance";
		}

		// Token: 0x06001055 RID: 4181 RVA: 0x00056D44 File Offset: 0x00054F44
		public Sneak_v2(MotionController rController)
			: base(rController)
		{
			this._Priority = 6f;
			this._ActionAlias = "ChangeStance";
		}

		// Token: 0x06001056 RID: 4182 RVA: 0x00056DBE File Offset: 0x00054FBE
		public override void Awake()
		{
			base.Awake();
			this.SmoothingSamples = this._SmoothingSamples;
		}

		// Token: 0x06001057 RID: 4183 RVA: 0x00056DD4 File Offset: 0x00054FD4
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
			if (this.mMotionLayer.ActiveMotion == null && this.mActorController.State.Stance == 4)
			{
				return true;
			}
			if (this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsEnabled && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias))
			{
				if (this.mActorController.State.Stance != 4)
				{
					this.mStoredStance = this.mActorController.State.Stance;
					this.mActorController.State.Stance = 4;
					return true;
				}
				this.mActorController.State.Stance = this.mStoredStance;
			}
			return false;
		}

		// Token: 0x06001058 RID: 4184 RVA: 0x00056EA8 File Offset: 0x000550A8
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
			if (this.mIsAnimatorActive && !this.IsInMotionState)
			{
				return false;
			}
			if (this.mActorController.State.Stance != 4)
			{
				return false;
			}
			if (this.mMotionLayer._AnimatorStateID == Sneak_v2.STATE_IdlePose)
			{
				this.mActorController.State.Stance = this.mStoredStance;
				return false;
			}
			return true;
		}

		// Token: 0x06001059 RID: 4185 RVA: 0x00056F20 File Offset: 0x00055120
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			this.mMotionController.ForcedInput.x = this.mInputX.Average;
			this.mMotionController.ForcedInput.y = this.mInputY.Average;
			return true;
		}

		// Token: 0x0600105A RID: 4186 RVA: 0x00056F5C File Offset: 0x0005515C
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mLinkRotation = false;
			this.mActorController.State.Stance = 4;
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 620, true);
			if (this._RotateWithCamera && this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
				BaseCameraRig baseCameraRig2 = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig2.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Combine(baseCameraRig2.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			return base.Activate(rPrevMotion);
		}

		// Token: 0x0600105B RID: 4187 RVA: 0x00057020 File Offset: 0x00055220
		public override void Deactivate()
		{
			if (this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			base.Deactivate();
		}

		// Token: 0x0600105C RID: 4188 RVA: 0x00057078 File Offset: 0x00055278
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			rRotation = Quaternion.identity;
			if (this._MovementSpeed > 0f)
			{
				rMovement.x = this.mMotionController.State.InputX;
				rMovement.y = 0f;
				rMovement.z = this.mMotionController.State.InputY;
				rMovement = rMovement.normalized * (this._MovementSpeed * rDeltaTime);
			}
		}

		// Token: 0x0600105D RID: 4189 RVA: 0x000570F0 File Offset: 0x000552F0
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mMovement = Vector3.zero;
			this.mRotation = Quaternion.identity;
			if (this.mMotionController.State.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].MotionPhase == 0 && this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsEnabled && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias))
			{
				this.mMotionController.ForcedInput.x = this.mInputX.Average;
				this.mMotionController.ForcedInput.y = this.mInputY.Average;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 610, 0, true);
			}
			MotionState state = this.mMotionController.State;
			float inputX = state.InputX;
			float inputY = state.InputY;
			float value = state.InputMagnitudeTrend.Value;
			InputManagerHelper.ConvertToRadialInput(ref inputX, ref inputY, ref value, 0.5f);
			this.mInputX.Add(inputX);
			this.mInputY.Add(inputY);
			this.mInputMagnitude.Add(value);
			this.mMotionController.State.InputX = this.mInputX.Average;
			this.mMotionController.State.InputY = this.mInputY.Average;
			this.mMotionController.State.InputMagnitudeTrend.Replace(this.mInputMagnitude.Average);
			if (this._RotateWithCamera && !(this.mMotionController.CameraRig is BaseCameraRig))
			{
				this.OnCameraUpdated(rDeltaTime, rUpdateIndex, null);
			}
			if (!this._RotateWithCamera && this._RotateWithInput)
			{
				this.RotateUsingInput(rDeltaTime, ref this.mRotation);
			}
		}

		// Token: 0x0600105E RID: 4190 RVA: 0x000572BC File Offset: 0x000554BC
		private void RotateUsingInput(float rDeltaTime, ref Quaternion rRotation)
		{
			if (this.mMotionController._InputSource == null)
			{
				return;
			}
			float num = 0f;
			float num2 = 0.1f;
			if (this.mMotionController._InputSource.IsViewingActivated)
			{
				num = this.mMotionController._InputSource.ViewX * this._RotationSpeed * rDeltaTime;
			}
			this.mYawTarget += num;
			num = ((num2 <= 0f) ? this.mYawTarget : Mathf.SmoothDampAngle(this.mYaw, this.mYawTarget, ref this.mYawVelocity, num2)) - this.mYaw;
			this.mYaw += num;
			if (num != 0f)
			{
				rRotation = Quaternion.Euler(0f, num, 0f);
			}
		}

		// Token: 0x0600105F RID: 4191 RVA: 0x0005737C File Offset: 0x0005557C
		private void OnCameraUpdated(float rDeltaTime, int rUpdateIndex, BaseCameraRig rCamera)
		{
			if (this.mMotionController._CameraTransform == null)
			{
				return;
			}
			float num = this.mMotionController._Transform.forward.HorizontalAngleTo(this.mMotionController._CameraTransform.forward, this.mMotionController._Transform.up);
			if (!this.mLinkRotation && Mathf.Abs(num) <= this._RotationSpeed * rDeltaTime)
			{
				this.mLinkRotation = true;
			}
			if (!this.mLinkRotation)
			{
				float num2 = Mathf.Abs(num);
				num = Mathf.Sign(num) * Mathf.Min(this._RotationSpeed * rDeltaTime, num2);
			}
			Quaternion quaternion = Quaternion.AngleAxis(num, Vector3.up);
			this.mActorController.Yaw = this.mActorController.Yaw * quaternion;
			this.mActorController._Transform.rotation = this.mActorController.Tilt * this.mActorController.Yaw;
		}

		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x06001060 RID: 4192 RVA: 0x0005746A File Offset: 0x0005566A
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x06001061 RID: 4193 RVA: 0x00057470 File Offset: 0x00055670
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return (animatorStateID == Sneak_v2.STATE_IdlePose && animatorTransitionID == 0) || (animatorStateID == Sneak_v2.STATE_MoveTree && animatorTransitionID == 0) || animatorTransitionID == Sneak_v2.TRANS_AnyState_MoveTree || animatorTransitionID == Sneak_v2.TRANS_EntryState_MoveTree || animatorTransitionID == Sneak_v2.TRANS_MoveTree_IdlePose;
			}
		}

		// Token: 0x06001062 RID: 4194 RVA: 0x000574CE File Offset: 0x000556CE
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == Sneak_v2.STATE_IdlePose || rStateID == Sneak_v2.STATE_MoveTree;
		}

		// Token: 0x06001063 RID: 4195 RVA: 0x000574E5 File Offset: 0x000556E5
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return (rStateID == Sneak_v2.STATE_IdlePose && rTransitionID == 0) || (rStateID == Sneak_v2.STATE_MoveTree && rTransitionID == 0) || rTransitionID == Sneak_v2.TRANS_AnyState_MoveTree || rTransitionID == Sneak_v2.TRANS_EntryState_MoveTree || rTransitionID == Sneak_v2.TRANS_MoveTree_IdlePose;
		}

		// Token: 0x06001064 RID: 4196 RVA: 0x00057520 File Offset: 0x00055720
		public override void LoadAnimatorData()
		{
			Sneak_v2.TRANS_AnyState_MoveTree = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Sneak v2-SM.Move Tree");
			Sneak_v2.TRANS_EntryState_MoveTree = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Sneak v2-SM.Move Tree");
			Sneak_v2.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Sneak v2-SM.IdlePose");
			Sneak_v2.STATE_MoveTree = this.mMotionController.AddAnimatorName("Base Layer.Sneak v2-SM.Move Tree");
			Sneak_v2.TRANS_MoveTree_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Sneak v2-SM.Move Tree -> Base Layer.Sneak v2-SM.IdlePose");
		}

		// Token: 0x04000AFD RID: 2813
		public const int SMOOTHING_BASE = 20;

		// Token: 0x04000AFE RID: 2814
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000AFF RID: 2815
		public const int PHASE_START = 620;

		// Token: 0x04000B00 RID: 2816
		public const int PHASE_START_OLD = 600;

		// Token: 0x04000B01 RID: 2817
		public const int PHASE_END = 610;

		// Token: 0x04000B02 RID: 2818
		public float _MovementSpeed;

		// Token: 0x04000B03 RID: 2819
		public bool _RotateWithInput;

		// Token: 0x04000B04 RID: 2820
		public bool _RotateWithCamera = true;

		// Token: 0x04000B05 RID: 2821
		public float _RotationSpeed = 180f;

		// Token: 0x04000B06 RID: 2822
		public int _SmoothingSamples = 20;

		// Token: 0x04000B07 RID: 2823
		protected bool mLinkRotation;

		// Token: 0x04000B08 RID: 2824
		protected float mYaw;

		// Token: 0x04000B09 RID: 2825
		protected float mYawTarget;

		// Token: 0x04000B0A RID: 2826
		protected float mYawVelocity;

		// Token: 0x04000B0B RID: 2827
		protected FloatValue mInputX = new FloatValue(0f, 20);

		// Token: 0x04000B0C RID: 2828
		protected FloatValue mInputY = new FloatValue(0f, 20);

		// Token: 0x04000B0D RID: 2829
		protected FloatValue mInputMagnitude = new FloatValue(0f, 20);

		// Token: 0x04000B0E RID: 2830
		protected int mStoredStance;

		// Token: 0x04000B0F RID: 2831
		public static int STATE_IdlePose = -1;

		// Token: 0x04000B10 RID: 2832
		public static int STATE_MoveTree = -1;

		// Token: 0x04000B11 RID: 2833
		public static int TRANS_AnyState_MoveTree = -1;

		// Token: 0x04000B12 RID: 2834
		public static int TRANS_EntryState_MoveTree = -1;

		// Token: 0x04000B13 RID: 2835
		public static int TRANS_MoveTree_IdlePose = -1;
	}
}
