using System;
using System.Collections.Generic;
using com.ootii.Cameras;
using com.ootii.Geometry;
using com.ootii.Helpers;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x0200011B RID: 283
	[MotionName("Walk Run Strafe")]
	[MotionDescription("Forward facing strafing walk/run animations.")]
	public class WalkRunStrafe_v2 : MotionControllerMotion, IWalkRunMotion
	{
		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x0600117D RID: 4477 RVA: 0x00062745 File Offset: 0x00060945
		// (set) Token: 0x0600117E RID: 4478 RVA: 0x0006274D File Offset: 0x0006094D
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

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x0600117F RID: 4479 RVA: 0x00062756 File Offset: 0x00060956
		// (set) Token: 0x06001180 RID: 4480 RVA: 0x0006275E File Offset: 0x0006095E
		public string ActivationAlias
		{
			get
			{
				return this._ActivationAlias;
			}
			set
			{
				this._ActivationAlias = value;
			}
		}

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x06001181 RID: 4481 RVA: 0x00062767 File Offset: 0x00060967
		// (set) Token: 0x06001182 RID: 4482 RVA: 0x00062770 File Offset: 0x00060970
		public string ActorStances
		{
			get
			{
				return this._ActorStances;
			}
			set
			{
				this._ActorStances = value;
				if (this._ActorStances.Length == 0)
				{
					if (this.mActorStances != null)
					{
						this.mActorStances.Clear();
						return;
					}
				}
				else
				{
					if (this.mActorStances == null)
					{
						this.mActorStances = new List<int>();
					}
					this.mActorStances.Clear();
					int num = 0;
					string[] array = this._ActorStances.Split(',', StringSplitOptions.None);
					for (int i = 0; i < array.Length; i++)
					{
						if (int.TryParse(array[i], out num) && !this.mActorStances.Contains(num))
						{
							this.mActorStances.Add(num);
						}
					}
				}
			}
		}

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x06001183 RID: 4483 RVA: 0x00062808 File Offset: 0x00060A08
		// (set) Token: 0x06001184 RID: 4484 RVA: 0x00062810 File Offset: 0x00060A10
		public bool DefaultToRun
		{
			get
			{
				return this._DefaultToRun;
			}
			set
			{
				this._DefaultToRun = value;
			}
		}

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x06001185 RID: 4485 RVA: 0x0006281C File Offset: 0x00060A1C
		public virtual bool IsRunActive
		{
			get
			{
				if (this.mMotionController.TargetNormalizedSpeed > 0f && this.mMotionController.TargetNormalizedSpeed <= 0.5f)
				{
					return false;
				}
				if (this.mMotionController._InputSource == null)
				{
					return this._DefaultToRun;
				}
				return (this._DefaultToRun && !this.mMotionController._InputSource.IsPressed(this._ActionAlias)) || (!this._DefaultToRun && this.mMotionController._InputSource.IsPressed(this._ActionAlias));
			}
		}

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x06001186 RID: 4486 RVA: 0x000628A5 File Offset: 0x00060AA5
		// (set) Token: 0x06001187 RID: 4487 RVA: 0x000628AD File Offset: 0x00060AAD
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

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x06001188 RID: 4488 RVA: 0x000628B6 File Offset: 0x00060AB6
		// (set) Token: 0x06001189 RID: 4489 RVA: 0x000628BE File Offset: 0x00060ABE
		public virtual float RunSpeed
		{
			get
			{
				return this._RunSpeed;
			}
			set
			{
				this._RunSpeed = value;
			}
		}

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x0600118A RID: 4490 RVA: 0x000628C7 File Offset: 0x00060AC7
		// (set) Token: 0x0600118B RID: 4491 RVA: 0x000628CF File Offset: 0x00060ACF
		public bool StartInMove
		{
			get
			{
				return this.mStartInMove;
			}
			set
			{
				this.mStartInMove = value;
			}
		}

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x0600118C RID: 4492 RVA: 0x000628D8 File Offset: 0x00060AD8
		// (set) Token: 0x0600118D RID: 4493 RVA: 0x000628E0 File Offset: 0x00060AE0
		public bool StartInWalk
		{
			get
			{
				return this.mStartInWalk;
			}
			set
			{
				this.mStartInWalk = value;
			}
		}

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x0600118E RID: 4494 RVA: 0x000628E9 File Offset: 0x00060AE9
		// (set) Token: 0x0600118F RID: 4495 RVA: 0x000628F1 File Offset: 0x00060AF1
		public bool StartInRun
		{
			get
			{
				return this.mStartInRun;
			}
			set
			{
				this.mStartInRun = value;
			}
		}

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x06001190 RID: 4496 RVA: 0x000628FA File Offset: 0x00060AFA
		// (set) Token: 0x06001191 RID: 4497 RVA: 0x00062902 File Offset: 0x00060B02
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

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x06001192 RID: 4498 RVA: 0x0006291A File Offset: 0x00060B1A
		// (set) Token: 0x06001193 RID: 4499 RVA: 0x00062922 File Offset: 0x00060B22
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

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06001194 RID: 4500 RVA: 0x0006293A File Offset: 0x00060B3A
		// (set) Token: 0x06001195 RID: 4501 RVA: 0x00062942 File Offset: 0x00060B42
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

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06001196 RID: 4502 RVA: 0x0006294B File Offset: 0x00060B4B
		// (set) Token: 0x06001197 RID: 4503 RVA: 0x00062953 File Offset: 0x00060B53
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

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x06001198 RID: 4504 RVA: 0x0006295C File Offset: 0x00060B5C
		// (set) Token: 0x06001199 RID: 4505 RVA: 0x00062964 File Offset: 0x00060B64
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

		// Token: 0x0600119A RID: 4506 RVA: 0x000629A0 File Offset: 0x00060BA0
		public WalkRunStrafe_v2()
		{
			this._Category = 2;
			this._Priority = 7f;
			this._ActionAlias = "Run";
		}

		// Token: 0x0600119B RID: 4507 RVA: 0x00062A4C File Offset: 0x00060C4C
		public WalkRunStrafe_v2(MotionController rController)
			: base(rController)
		{
			this._Category = 2;
			this._Priority = 7f;
			this._ActionAlias = "Run";
		}

		// Token: 0x0600119C RID: 4508 RVA: 0x00062AF9 File Offset: 0x00060CF9
		public override void Awake()
		{
			base.Awake();
			this.SmoothingSamples = this._SmoothingSamples;
		}

		// Token: 0x0600119D RID: 4509 RVA: 0x00062B10 File Offset: 0x00060D10
		public override bool TestActivate()
		{
			return this.mIsStartable && this.mMotionController.IsGrounded && this.mMotionController.Stance == 0 && (this._FormCondition < 0 || this.mMotionController.CurrentForm == this._FormCondition) && this.mMotionController.State.InputMagnitudeTrend.Value >= 0.49f && (this._ActivationAlias.Length <= 0 || (this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsPressed(this._ActivationAlias))) && (this.mActorStances == null || this.mActorStances.Count <= 0 || this.mActorStances.Contains(this.mMotionController.Stance));
		}

		// Token: 0x0600119E RID: 4510 RVA: 0x00062BE8 File Offset: 0x00060DE8
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
			if (this.mMotionController.Stance != 0)
			{
				return false;
			}
			if (this.mInputMagnitude.Average == 0f)
			{
				this.mIdleTime += Time.deltaTime;
				if (this.mIdleTime > 0.3f)
				{
					return false;
				}
			}
			else
			{
				this.mIdleTime = 0f;
			}
			return (this._ActivationAlias.Length <= 0 || (this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsPressed(this._ActivationAlias))) && this.mMotionLayer._AnimatorStateID != WalkRunStrafe_v2.STATE_IdlePose && (!this.mIsAnimatorActive || this.IsInMotionState) && (this.mActorStances == null || this.mActorStances.Count <= 0 || this.mActorStances.Contains(this.mMotionController.Stance));
		}

		// Token: 0x0600119F RID: 4511 RVA: 0x00062CE7 File Offset: 0x00060EE7
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			this.mMotionController.ForcedInput.x = this.mInputX.Average;
			this.mMotionController.ForcedInput.y = this.mInputY.Average;
			return true;
		}

		// Token: 0x060011A0 RID: 4512 RVA: 0x00062D20 File Offset: 0x00060F20
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mIdleTime = 0f;
			this.mLinkRotation = false;
			this.mInputX.Clear(0f);
			this.mInputY.Clear(0f);
			this.mInputMagnitude.Clear(0f);
			this.mMotionController.MaxSpeed = 5.668f;
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 1130, true);
			if (this._RotateWithCamera && this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
				BaseCameraRig baseCameraRig2 = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig2.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Combine(baseCameraRig2.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			return base.Activate(rPrevMotion);
		}

		// Token: 0x060011A1 RID: 4513 RVA: 0x00062E20 File Offset: 0x00061020
		public override void Deactivate()
		{
			if (this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			base.Deactivate();
		}

		// Token: 0x060011A2 RID: 4514 RVA: 0x00062E78 File Offset: 0x00061078
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			rRotation = Quaternion.identity;
			float num = (this.IsRunActive ? this._RunSpeed : this._WalkSpeed);
			if (num > 0f)
			{
				rMovement.x = this.mMotionController.State.InputX;
				rMovement.y = 0f;
				rMovement.z = this.mMotionController.State.InputY;
				rMovement = rMovement.normalized * (num * rDeltaTime);
				return;
			}
			if (this.mMotionController.State.InputX == 0f && rMovement.x > -0.01f && rMovement.x < 0.01f)
			{
				rMovement.x = 0f;
			}
		}

		// Token: 0x060011A3 RID: 4515 RVA: 0x00062F38 File Offset: 0x00061138
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mMovement = Vector3.zero;
			this.mRotation = Quaternion.identity;
			MotionState state = this.mMotionController.State;
			float num = (this.IsRunActive ? 1f : 0.5f);
			float num2 = Mathf.Clamp(state.InputX, -num, num);
			float num3 = Mathf.Clamp(state.InputY, -num, num);
			float num4 = Mathf.Clamp(state.InputMagnitudeTrend.Value, 0f, num);
			InputManagerHelper.ConvertToRadialInput(ref num2, ref num3, ref num4, 1f);
			this.mInputX.Add(num2);
			this.mInputY.Add(num3);
			this.mInputMagnitude.Add(num4);
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

		// Token: 0x060011A4 RID: 4516 RVA: 0x00063084 File Offset: 0x00061284
		private void RotateUsingInput(float rDeltaTime, ref Quaternion rRotation)
		{
			if (this.mMotionController._InputSource == null)
			{
				return;
			}
			float num = 0f;
			if (this.mMotionController._InputSource.IsViewingActivated)
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
		}

		// Token: 0x060011A5 RID: 4517 RVA: 0x00063148 File Offset: 0x00061348
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

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x060011A6 RID: 4518 RVA: 0x00063236 File Offset: 0x00061436
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x060011A7 RID: 4519 RVA: 0x0006323C File Offset: 0x0006143C
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == WalkRunStrafe_v2.STATE_IdlePose || animatorStateID == WalkRunStrafe_v2.STATE_MoveTree || animatorTransitionID == WalkRunStrafe_v2.TRANS_AnyState_MoveTree || animatorTransitionID == WalkRunStrafe_v2.TRANS_EntryState_MoveTree || animatorTransitionID == WalkRunStrafe_v2.TRANS_IdlePose_MoveTree || animatorTransitionID == WalkRunStrafe_v2.TRANS_MoveTree_IdlePose;
			}
		}

		// Token: 0x060011A8 RID: 4520 RVA: 0x0006329E File Offset: 0x0006149E
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == WalkRunStrafe_v2.STATE_IdlePose || rStateID == WalkRunStrafe_v2.STATE_MoveTree;
		}

		// Token: 0x060011A9 RID: 4521 RVA: 0x000632B5 File Offset: 0x000614B5
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == WalkRunStrafe_v2.STATE_IdlePose || rStateID == WalkRunStrafe_v2.STATE_MoveTree || rTransitionID == WalkRunStrafe_v2.TRANS_AnyState_MoveTree || rTransitionID == WalkRunStrafe_v2.TRANS_EntryState_MoveTree || rTransitionID == WalkRunStrafe_v2.TRANS_IdlePose_MoveTree || rTransitionID == WalkRunStrafe_v2.TRANS_MoveTree_IdlePose;
		}

		// Token: 0x060011AA RID: 4522 RVA: 0x000632F4 File Offset: 0x000614F4
		public override void LoadAnimatorData()
		{
			WalkRunStrafe_v2.TRANS_AnyState_MoveTree = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.WalkRunStrafe v2-SM.Move Tree");
			WalkRunStrafe_v2.TRANS_EntryState_MoveTree = this.mMotionController.AddAnimatorName("Entry -> Base Layer.WalkRunStrafe v2-SM.Move Tree");
			WalkRunStrafe_v2.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe v2-SM.IdlePose");
			WalkRunStrafe_v2.TRANS_IdlePose_MoveTree = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe v2-SM.IdlePose -> Base Layer.WalkRunStrafe v2-SM.Move Tree");
			WalkRunStrafe_v2.STATE_MoveTree = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe v2-SM.Move Tree");
			WalkRunStrafe_v2.TRANS_MoveTree_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.WalkRunStrafe v2-SM.Move Tree -> Base Layer.WalkRunStrafe v2-SM.IdlePose");
		}

		// Token: 0x04000D51 RID: 3409
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000D52 RID: 3410
		public const int PHASE_START = 1130;

		// Token: 0x04000D53 RID: 3411
		public const int PHASE_STOP = 1135;

		// Token: 0x04000D54 RID: 3412
		public int _FormCondition;

		// Token: 0x04000D55 RID: 3413
		public string _ActivationAlias = "";

		// Token: 0x04000D56 RID: 3414
		public string _ActorStances = "";

		// Token: 0x04000D57 RID: 3415
		public bool _DefaultToRun;

		// Token: 0x04000D58 RID: 3416
		public float _WalkSpeed;

		// Token: 0x04000D59 RID: 3417
		public float _RunSpeed;

		// Token: 0x04000D5A RID: 3418
		private bool mStartInMove;

		// Token: 0x04000D5B RID: 3419
		private bool mStartInWalk;

		// Token: 0x04000D5C RID: 3420
		private bool mStartInRun;

		// Token: 0x04000D5D RID: 3421
		public bool _RotateWithInput;

		// Token: 0x04000D5E RID: 3422
		public bool _RotateWithCamera = true;

		// Token: 0x04000D5F RID: 3423
		public float _RotationSpeed = 180f;

		// Token: 0x04000D60 RID: 3424
		public float _RotationSmoothing = 0.1f;

		// Token: 0x04000D61 RID: 3425
		public int _SmoothingSamples = 10;

		// Token: 0x04000D62 RID: 3426
		[SerializeField]
		protected List<int> mActorStances = new List<int>();

		// Token: 0x04000D63 RID: 3427
		protected bool mLinkRotation;

		// Token: 0x04000D64 RID: 3428
		protected float mYaw;

		// Token: 0x04000D65 RID: 3429
		protected float mYawTarget;

		// Token: 0x04000D66 RID: 3430
		protected float mYawVelocity;

		// Token: 0x04000D67 RID: 3431
		protected FloatValue mInputX = new FloatValue(0f, 10);

		// Token: 0x04000D68 RID: 3432
		protected FloatValue mInputY = new FloatValue(0f, 10);

		// Token: 0x04000D69 RID: 3433
		protected FloatValue mInputMagnitude = new FloatValue(0f, 15);

		// Token: 0x04000D6A RID: 3434
		protected float mIdleTime;

		// Token: 0x04000D6B RID: 3435
		public static int STATE_IdlePose = -1;

		// Token: 0x04000D6C RID: 3436
		public static int STATE_MoveTree = -1;

		// Token: 0x04000D6D RID: 3437
		public static int TRANS_AnyState_MoveTree = -1;

		// Token: 0x04000D6E RID: 3438
		public static int TRANS_EntryState_MoveTree = -1;

		// Token: 0x04000D6F RID: 3439
		public static int TRANS_IdlePose_MoveTree = -1;

		// Token: 0x04000D70 RID: 3440
		public static int TRANS_MoveTree_IdlePose = -1;
	}
}
