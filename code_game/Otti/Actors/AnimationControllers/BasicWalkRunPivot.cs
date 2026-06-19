using System;
using com.ootii.Cameras;
using com.ootii.Geometry;
using com.ootii.Helpers;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000F6 RID: 246
	[MotionName("Basic Walk Run Pivot")]
	[MotionDescription("Adventure game style movement that can be expanded. Uses no transitions.")]
	public class BasicWalkRunPivot : MotionControllerMotion, IWalkRunMotion
	{
		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06000D64 RID: 3428 RVA: 0x000422D6 File Offset: 0x000404D6
		public override bool VerifyTransition
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06000D65 RID: 3429 RVA: 0x000422D9 File Offset: 0x000404D9
		// (set) Token: 0x06000D66 RID: 3430 RVA: 0x000422E1 File Offset: 0x000404E1
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

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x06000D67 RID: 3431 RVA: 0x000422EA File Offset: 0x000404EA
		// (set) Token: 0x06000D68 RID: 3432 RVA: 0x000422F2 File Offset: 0x000404F2
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

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x06000D69 RID: 3433 RVA: 0x000422FB File Offset: 0x000404FB
		// (set) Token: 0x06000D6A RID: 3434 RVA: 0x00042303 File Offset: 0x00040503
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

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x06000D6B RID: 3435 RVA: 0x0004230C File Offset: 0x0004050C
		// (set) Token: 0x06000D6C RID: 3436 RVA: 0x00042314 File Offset: 0x00040514
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

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x06000D6D RID: 3437 RVA: 0x0004231D File Offset: 0x0004051D
		// (set) Token: 0x06000D6E RID: 3438 RVA: 0x00042325 File Offset: 0x00040525
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

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x06000D6F RID: 3439 RVA: 0x0004232E File Offset: 0x0004052E
		// (set) Token: 0x06000D70 RID: 3440 RVA: 0x00042336 File Offset: 0x00040536
		public bool StartInWalk
		{
			get
			{
				return this.mStartInWalk;
			}
			set
			{
				this.mStartInWalk = value;
				if (value)
				{
					this.mStartInMove = value;
				}
			}
		}

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x06000D71 RID: 3441 RVA: 0x00042349 File Offset: 0x00040549
		// (set) Token: 0x06000D72 RID: 3442 RVA: 0x00042351 File Offset: 0x00040551
		public bool StartInRun
		{
			get
			{
				return this.mStartInRun;
			}
			set
			{
				this.mStartInRun = value;
				if (value)
				{
					this.mStartInMove = value;
				}
			}
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06000D73 RID: 3443 RVA: 0x00042364 File Offset: 0x00040564
		// (set) Token: 0x06000D74 RID: 3444 RVA: 0x0004236C File Offset: 0x0004056C
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

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06000D75 RID: 3445 RVA: 0x000423A8 File Offset: 0x000405A8
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

		// Token: 0x06000D76 RID: 3446 RVA: 0x00042434 File Offset: 0x00040634
		public BasicWalkRunPivot()
		{
			this._Category = 2;
			this._Priority = 5f;
			this._ActionAlias = "Run";
			this._Form = -1;
		}

		// Token: 0x06000D77 RID: 3447 RVA: 0x000424E8 File Offset: 0x000406E8
		public BasicWalkRunPivot(MotionController rController)
			: base(rController)
		{
			this._Category = 2;
			this._Priority = 5f;
			this._ActionAlias = "Run";
			this._Form = -1;
		}

		// Token: 0x06000D78 RID: 3448 RVA: 0x0004259B File Offset: 0x0004079B
		public override void Awake()
		{
			base.Awake();
			this.SmoothingSamples = this._SmoothingSamples;
		}

		// Token: 0x06000D79 RID: 3449 RVA: 0x000425AF File Offset: 0x000407AF
		public override bool TestActivate()
		{
			return this.mIsStartable && this.mMotionController.IsGrounded && this.mMotionController.State.InputMagnitudeTrend.Value > 0.49f;
		}

		// Token: 0x06000D7A RID: 3450 RVA: 0x000425EC File Offset: 0x000407EC
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
			if (this.mInputMagnitude.Average == 0f)
			{
				this.mIdleTime += Time.deltaTime;
				if (this.mIdleTime > 0.2f)
				{
					return false;
				}
			}
			else
			{
				this.mIdleTime = 0f;
			}
			return true;
		}

		// Token: 0x06000D7B RID: 3451 RVA: 0x00042651 File Offset: 0x00040851
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			this.mMotionController.ForcedInput.x = this.mInputX.Average;
			this.mMotionController.ForcedInput.y = this.mInputY.Average;
			return true;
		}

		// Token: 0x06000D7C RID: 3452 RVA: 0x0004268C File Offset: 0x0004088C
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mIdleTime = 0f;
			this.mIsRotationLocked = false;
			this.mInputX.Clear(0f);
			this.mInputY.Clear(0f);
			this.mInputMagnitude.Clear(0f);
			this.mMotionController.MaxSpeed = 5.668f;
			this.mActiveForm = ((this._Form >= 0) ? this._Form : this.mMotionController.CurrentForm);
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, this.PHASE_START, this.mActiveForm, 0, true);
			if (this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
				BaseCameraRig baseCameraRig2 = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig2.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Combine(baseCameraRig2.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000D7D RID: 3453 RVA: 0x000427AC File Offset: 0x000409AC
		public override void Deactivate()
		{
			this.mStartInRun = false;
			this.mStartInWalk = false;
			if (this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			base.Deactivate();
		}

		// Token: 0x06000D7E RID: 3454 RVA: 0x00042810 File Offset: 0x00040A10
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			rRotation = Quaternion.identity;
			float num = (this.IsRunActive ? this._RunSpeed : this._WalkSpeed);
			if (num > 0f)
			{
				if (rMovement.sqrMagnitude > 0f)
				{
					rMovement = rMovement.normalized * (num * rDeltaTime);
				}
				else
				{
					Vector3 vector = new Vector3(0f, 0f, 1f);
					rMovement = vector.normalized * (num * rDeltaTime);
				}
				rMovement.x = 0f;
				rMovement.y = 0f;
				if (rMovement.z < 0f)
				{
					rMovement.z = 0f;
					return;
				}
			}
			else
			{
				rMovement.x = 0f;
				rMovement.y = 0f;
				if (rMovement.z < 0f)
				{
					rMovement.z = 0f;
				}
				if (this.mMotionController.State.InputMagnitudeTrend.Value < 0.05f)
				{
					rMovement.z = 0f;
				}
			}
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x0004291C File Offset: 0x00040B1C
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mMovement = Vector3.zero;
			this.mRotation = Quaternion.identity;
			this.SmoothInput();
			this.RotateToInput(this.mMotionController.State.InputFromAvatarAngle, rDeltaTime, ref this.mRotation);
			if (this._Form <= 0 && this.mActiveForm != this.mMotionController.CurrentForm)
			{
				this.mActiveForm = this.mMotionController.CurrentForm;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, this.PHASE_START, this.mActiveForm, 0, true);
			}
		}

		// Token: 0x06000D80 RID: 3456 RVA: 0x000429B4 File Offset: 0x00040BB4
		protected void SmoothInput()
		{
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
		}

		// Token: 0x06000D81 RID: 3457 RVA: 0x00042AA8 File Offset: 0x00040CA8
		protected void RotateToInput(float rInputFromAvatarAngle, float rDeltaTime, ref Quaternion rRotation)
		{
			if (rInputFromAvatarAngle != 0f)
			{
				if (this._RotationSpeed > 0f && Mathf.Abs(rInputFromAvatarAngle) > this._RotationSpeed * rDeltaTime)
				{
					rInputFromAvatarAngle = Mathf.Sign(rInputFromAvatarAngle) * this._RotationSpeed * rDeltaTime;
				}
				rRotation = Quaternion.Euler(0f, rInputFromAvatarAngle, 0f);
			}
		}

		// Token: 0x06000D82 RID: 3458 RVA: 0x00042B04 File Offset: 0x00040D04
		private void OnCameraUpdated(float rDeltaTime, int rUpdateIndex, BaseCameraRig rCamera)
		{
			if (this.mMotionController._InputSource != null && this.mMotionController._InputSource.ViewX == 0f)
			{
				return;
			}
			Quaternion quaternion = QuaternionExt.FromToRotation(this.mMotionController._Transform.up, Vector3.up);
			Vector3 vector = quaternion * this.mMotionController._Transform.forward;
			Vector3 vector2 = Quaternion.LookRotation(quaternion * this.mMotionController._CameraTransform.forward, Vector3.up) * this.mMotionController.State.InputForward;
			float horizontalAngle = NumberHelper.GetHorizontalAngle(vector, vector2);
			if (Mathf.Abs(horizontalAngle) > this._RotationSpeed * rDeltaTime * 5f)
			{
				this.mIsRotationLocked = false;
			}
			if (this._RotationSpeed == 0f || this.mIsRotationLocked || Mathf.Abs(horizontalAngle) < this._RotationSpeed * rDeltaTime * 1f)
			{
				this.mIsRotationLocked = true;
				Quaternion quaternion2 = Quaternion.AngleAxis(horizontalAngle, Vector3.up);
				this.mActorController.Yaw = this.mActorController.Yaw * quaternion2;
				this.mActorController._Transform.rotation = this.mActorController.Tilt * this.mActorController.Yaw;
			}
		}

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06000D83 RID: 3459 RVA: 0x00042C46 File Offset: 0x00040E46
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x06000D84 RID: 3460 RVA: 0x00042C4C File Offset: 0x00040E4C
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				if (animatorTransitionID == 0)
				{
					if (animatorStateID == this.STATE_Empty)
					{
						return true;
					}
					if (animatorStateID == this.STATE_UnarmedBlendTree)
					{
						return true;
					}
				}
				return animatorTransitionID == this.TRANS_AnyState_UnarmedBlendTree || animatorTransitionID == this.TRANS_EntryState_UnarmedBlendTree;
			}
		}

		// Token: 0x06000D85 RID: 3461 RVA: 0x00042CA1 File Offset: 0x00040EA1
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == this.STATE_Empty || rStateID == this.STATE_UnarmedBlendTree;
		}

		// Token: 0x06000D86 RID: 3462 RVA: 0x00042CBA File Offset: 0x00040EBA
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			if (rTransitionID == 0)
			{
				if (rStateID == this.STATE_Empty)
				{
					return true;
				}
				if (rStateID == this.STATE_UnarmedBlendTree)
				{
					return true;
				}
			}
			return rTransitionID == this.TRANS_AnyState_UnarmedBlendTree || rTransitionID == this.TRANS_EntryState_UnarmedBlendTree;
		}

		// Token: 0x06000D87 RID: 3463 RVA: 0x00042CEC File Offset: 0x00040EEC
		public override void LoadAnimatorData()
		{
			string layerName = this.mMotionController.Animator.GetLayerName(this.mMotionLayer._AnimatorLayerIndex);
			this.TRANS_AnyState_UnarmedBlendTree = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".BasicWalkRunPivot-SM.Unarmed BlendTree");
			this.TRANS_EntryState_UnarmedBlendTree = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".BasicWalkRunPivot-SM.Unarmed BlendTree");
			this.STATE_Empty = this.mMotionController.AddAnimatorName(layerName + ".Empty");
			this.STATE_UnarmedBlendTree = this.mMotionController.AddAnimatorName(layerName + ".BasicWalkRunPivot-SM.Unarmed BlendTree");
		}

		// Token: 0x04000768 RID: 1896
		public int PHASE_UNKNOWN;

		// Token: 0x04000769 RID: 1897
		public int PHASE_START = 3050;

		// Token: 0x0400076A RID: 1898
		public int PHASE_STOP = 3099;

		// Token: 0x0400076B RID: 1899
		public bool _DefaultToRun;

		// Token: 0x0400076C RID: 1900
		public float _WalkSpeed;

		// Token: 0x0400076D RID: 1901
		public float _RunSpeed;

		// Token: 0x0400076E RID: 1902
		public float _RotationSpeed = 360f;

		// Token: 0x0400076F RID: 1903
		private bool mStartInMove;

		// Token: 0x04000770 RID: 1904
		private bool mStartInWalk;

		// Token: 0x04000771 RID: 1905
		private bool mStartInRun;

		// Token: 0x04000772 RID: 1906
		public int _SmoothingSamples = 10;

		// Token: 0x04000773 RID: 1907
		protected FloatValue mInputX = new FloatValue(0f, 10);

		// Token: 0x04000774 RID: 1908
		protected FloatValue mInputY = new FloatValue(0f, 10);

		// Token: 0x04000775 RID: 1909
		protected FloatValue mInputMagnitude = new FloatValue(0f, 15);

		// Token: 0x04000776 RID: 1910
		protected float mIdleTime;

		// Token: 0x04000777 RID: 1911
		protected bool mIsRotationLocked;

		// Token: 0x04000778 RID: 1912
		protected int mActiveForm;

		// Token: 0x04000779 RID: 1913
		public int STATE_Empty = -1;

		// Token: 0x0400077A RID: 1914
		public int STATE_UnarmedBlendTree = -1;

		// Token: 0x0400077B RID: 1915
		public int TRANS_AnyState_UnarmedBlendTree = -1;

		// Token: 0x0400077C RID: 1916
		public int TRANS_EntryState_UnarmedBlendTree = -1;
	}
}
