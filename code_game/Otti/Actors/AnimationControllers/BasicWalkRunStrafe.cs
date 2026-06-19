using System;
using System.Collections.Generic;
using com.ootii.Actors.Combat;
using com.ootii.Cameras;
using com.ootii.Geometry;
using com.ootii.Helpers;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000F7 RID: 247
	[MotionName("Basic Walk Run Strafe")]
	[MotionDescription("Shooter game style movement that can be expanded. Uses no transitions.")]
	public class BasicWalkRunStrafe : MotionControllerMotion, IWalkRunMotion
	{
		// Token: 0x170003BE RID: 958
		// (get) Token: 0x06000D88 RID: 3464 RVA: 0x00042D8F File Offset: 0x00040F8F
		public override bool VerifyTransition
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x06000D89 RID: 3465 RVA: 0x00042D92 File Offset: 0x00040F92
		// (set) Token: 0x06000D8A RID: 3466 RVA: 0x00042D9A File Offset: 0x00040F9A
		public bool RequireTarget
		{
			get
			{
				return this._RequireTarget;
			}
			set
			{
				this._RequireTarget = value;
			}
		}

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x06000D8B RID: 3467 RVA: 0x00042DA3 File Offset: 0x00040FA3
		// (set) Token: 0x06000D8C RID: 3468 RVA: 0x00042DAB File Offset: 0x00040FAB
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

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x06000D8D RID: 3469 RVA: 0x00042DB4 File Offset: 0x00040FB4
		// (set) Token: 0x06000D8E RID: 3470 RVA: 0x00042DBC File Offset: 0x00040FBC
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

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x06000D8F RID: 3471 RVA: 0x00042E54 File Offset: 0x00041054
		// (set) Token: 0x06000D90 RID: 3472 RVA: 0x00042E5C File Offset: 0x0004105C
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

		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x06000D91 RID: 3473 RVA: 0x00042E68 File Offset: 0x00041068
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

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x06000D92 RID: 3474 RVA: 0x00042EF1 File Offset: 0x000410F1
		// (set) Token: 0x06000D93 RID: 3475 RVA: 0x00042EF9 File Offset: 0x000410F9
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

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x06000D94 RID: 3476 RVA: 0x00042F02 File Offset: 0x00041102
		// (set) Token: 0x06000D95 RID: 3477 RVA: 0x00042F0A File Offset: 0x0004110A
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

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x06000D96 RID: 3478 RVA: 0x00042F13 File Offset: 0x00041113
		// (set) Token: 0x06000D97 RID: 3479 RVA: 0x00042F1B File Offset: 0x0004111B
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

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06000D98 RID: 3480 RVA: 0x00042F24 File Offset: 0x00041124
		// (set) Token: 0x06000D99 RID: 3481 RVA: 0x00042F2C File Offset: 0x0004112C
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

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x06000D9A RID: 3482 RVA: 0x00042F35 File Offset: 0x00041135
		// (set) Token: 0x06000D9B RID: 3483 RVA: 0x00042F3D File Offset: 0x0004113D
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

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x06000D9C RID: 3484 RVA: 0x00042F46 File Offset: 0x00041146
		// (set) Token: 0x06000D9D RID: 3485 RVA: 0x00042F4E File Offset: 0x0004114E
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

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x06000D9E RID: 3486 RVA: 0x00042F66 File Offset: 0x00041166
		// (set) Token: 0x06000D9F RID: 3487 RVA: 0x00042F6E File Offset: 0x0004116E
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

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x06000DA0 RID: 3488 RVA: 0x00042F86 File Offset: 0x00041186
		// (set) Token: 0x06000DA1 RID: 3489 RVA: 0x00042F8E File Offset: 0x0004118E
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

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x06000DA2 RID: 3490 RVA: 0x00042F97 File Offset: 0x00041197
		// (set) Token: 0x06000DA3 RID: 3491 RVA: 0x00042F9F File Offset: 0x0004119F
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

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x06000DA4 RID: 3492 RVA: 0x00042FDB File Offset: 0x000411DB
		// (set) Token: 0x06000DA5 RID: 3493 RVA: 0x00042FE3 File Offset: 0x000411E3
		public ICombatant Combatant
		{
			get
			{
				return this.mCombatant;
			}
			set
			{
				this.mCombatant = value;
			}
		}

		// Token: 0x06000DA6 RID: 3494 RVA: 0x00042FEC File Offset: 0x000411EC
		public BasicWalkRunStrafe()
		{
			this._Category = 2;
			this._Priority = 7f;
			this._ActionAlias = "Run";
			this._Form = -1;
		}

		// Token: 0x06000DA7 RID: 3495 RVA: 0x000430D0 File Offset: 0x000412D0
		public BasicWalkRunStrafe(MotionController rController)
			: base(rController)
		{
			this._Category = 2;
			this._Priority = 7f;
			this._ActionAlias = "Run";
			this._Form = -1;
		}

		// Token: 0x06000DA8 RID: 3496 RVA: 0x000431B2 File Offset: 0x000413B2
		public override void Awake()
		{
			base.Awake();
			this.SmoothingSamples = this._SmoothingSamples;
			this.mCombatant = this.mMotionController.gameObject.GetComponent<ICombatant>();
		}

		// Token: 0x06000DA9 RID: 3497 RVA: 0x000431DC File Offset: 0x000413DC
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
			if (this.mMotionController.State.InputMagnitudeTrend.Value < 0.49f)
			{
				return false;
			}
			bool flag = !this._RequireTarget && this._ActivationAlias.Length == 0;
			bool flag2 = this._RequireTarget && this.mCombatant != null && this.mCombatant.IsTargetLocked;
			bool flag3 = this._ActivationAlias.Length > 0 && this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsPressed(this._ActivationAlias);
			return (flag || flag2 || flag3) && (this.mActorStances == null || this.mActorStances.Count <= 0 || this.mActorStances.Contains(this.mMotionController.Stance));
		}

		// Token: 0x06000DAA RID: 3498 RVA: 0x000432C8 File Offset: 0x000414C8
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
			bool flag = !this._RequireTarget && this._ActivationAlias.Length == 0;
			bool flag2 = this._RequireTarget && this.mCombatant != null && this.mCombatant.IsTargetLocked;
			bool flag3 = this._ActivationAlias.Length > 0 && this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsPressed(this._ActivationAlias);
			if (!flag && !flag2 && !flag3)
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
			return this.mActorStances == null || this.mActorStances.Count <= 0 || this.mActorStances.Contains(this.mMotionController.Stance);
		}

		// Token: 0x06000DAB RID: 3499 RVA: 0x000433D4 File Offset: 0x000415D4
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			this.mMotionController.ForcedInput.x = this.mInputX.Average;
			this.mMotionController.ForcedInput.y = this.mInputY.Average;
			return true;
		}

		// Token: 0x06000DAC RID: 3500 RVA: 0x00043410 File Offset: 0x00041610
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mIdleTime = 0f;
			this.mLinkRotation = false;
			this.mInputX.Clear(0f);
			this.mInputY.Clear(0f);
			this.mInputMagnitude.Clear(0f);
			this.mMotionController.MaxSpeed = 5.668f;
			this.mActiveForm = ((this._Form >= 0) ? this._Form : this.mMotionController.CurrentForm);
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, this.PHASE_START, this.mActiveForm, 0, true);
			if (this._RotateWithCamera && this.mMotionController.CameraRig is BaseCameraRig)
			{
				BaseCameraRig baseCameraRig = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Remove(baseCameraRig.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
				BaseCameraRig baseCameraRig2 = (BaseCameraRig)this.mMotionController.CameraRig;
				baseCameraRig2.OnPostLateUpdate = (CameraUpdateEvent)Delegate.Combine(baseCameraRig2.OnPostLateUpdate, new CameraUpdateEvent(this.OnCameraUpdated));
			}
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000DAD RID: 3501 RVA: 0x0004353C File Offset: 0x0004173C
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

		// Token: 0x06000DAE RID: 3502 RVA: 0x000435A4 File Offset: 0x000417A4
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
			if (this.mMotionController._InputSource != null)
			{
				num = rMovement.magnitude;
				rMovement.x = this.mMotionController.State.InputX;
				rMovement.y = 0f;
				rMovement.z = this.mMotionController.State.InputY;
				rMovement = rMovement.normalized * num;
			}
		}

		// Token: 0x06000DAF RID: 3503 RVA: 0x00043688 File Offset: 0x00041888
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mMovement = Vector3.zero;
			this.mRotation = Quaternion.identity;
			this.SmoothInput();
			if (this._RequireTarget && this.mCombatant != null && this.mCombatant.IsTargetLocked)
			{
				if (!this.mCombatant.ForceActorRotation)
				{
					Vector3 normalized = (this.mCombatant.Target.position - this.mMotionController._Transform.position).normalized;
					this.RotateToDirection(normalized, this._RotationSpeed, rDeltaTime, ref this.mRotation);
				}
			}
			else if (this._RotateWithCamera && this.mMotionController._CameraTransform != null)
			{
				this.RotateToDirection(this.mMotionController._CameraTransform.forward, this._RotationSpeed, rDeltaTime, ref this.mRotation);
			}
			else if (!this._RotateWithCamera && this._RotateWithInput)
			{
				this.RotateUsingInput(this._RotationSpeed, rDeltaTime, ref this.mRotation);
			}
			if (this._Form <= 0 && this.mActiveForm != this.mMotionController.CurrentForm)
			{
				this.mActiveForm = this.mMotionController.CurrentForm;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, this.PHASE_START, this.mActiveForm, 0, true);
			}
		}

		// Token: 0x06000DB0 RID: 3504 RVA: 0x000437D8 File Offset: 0x000419D8
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

		// Token: 0x06000DB1 RID: 3505 RVA: 0x000438CC File Offset: 0x00041ACC
		private void RotateUsingInput(float rSpeed, float rDeltaTime, ref Quaternion rRotation)
		{
			if (this.mMotionController._InputSource == null)
			{
				return;
			}
			float num = 0f;
			float num2 = 0.1f;
			if (this.mMotionController._InputSource.IsViewingActivated)
			{
				num = this.mMotionController._InputSource.ViewX * rSpeed * rDeltaTime;
			}
			this.mYawTarget += num;
			num = ((num2 <= 0f) ? this.mYawTarget : Mathf.SmoothDampAngle(this.mYaw, this.mYawTarget, ref this.mYawVelocity, num2)) - this.mYaw;
			this.mYaw += num;
			if (num != 0f)
			{
				rRotation = Quaternion.Euler(0f, num, 0f);
			}
		}

		// Token: 0x06000DB2 RID: 3506 RVA: 0x00043984 File Offset: 0x00041B84
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

		// Token: 0x06000DB3 RID: 3507 RVA: 0x00043A04 File Offset: 0x00041C04
		protected virtual void OnCameraUpdated(float rDeltaTime, int rUpdateIndex, BaseCameraRig rCamera)
		{
			if (!this._RotateWithCamera)
			{
				return;
			}
			if (this._RequireTarget && this.mCombatant != null && this.mCombatant.IsTargetLocked)
			{
				return;
			}
			if (this.mMotionController._InputSource != null && this.mMotionController._InputSource.ViewX == 0f)
			{
				return;
			}
			Quaternion quaternion = QuaternionExt.FromToRotation(this.mMotionController._Transform.up, Vector3.up);
			Vector3 vector = quaternion * this.mMotionController._Transform.forward;
			Vector3 vector2 = quaternion * this.mMotionController._CameraTransform.forward;
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

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06000DB4 RID: 3508 RVA: 0x00043B4E File Offset: 0x00041D4E
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x06000DB5 RID: 3509 RVA: 0x00043B54 File Offset: 0x00041D54
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

		// Token: 0x06000DB6 RID: 3510 RVA: 0x00043BA9 File Offset: 0x00041DA9
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == this.STATE_Empty || rStateID == this.STATE_UnarmedBlendTree;
		}

		// Token: 0x06000DB7 RID: 3511 RVA: 0x00043BC2 File Offset: 0x00041DC2
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

		// Token: 0x06000DB8 RID: 3512 RVA: 0x00043BF4 File Offset: 0x00041DF4
		public override void LoadAnimatorData()
		{
			string layerName = this.mMotionController.Animator.GetLayerName(this.mMotionLayer._AnimatorLayerIndex);
			this.TRANS_AnyState_UnarmedBlendTree = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".BasicWalkRunStrafe-SM.Unarmed BlendTree");
			this.TRANS_EntryState_UnarmedBlendTree = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".BasicWalkRunStrafe-SM.Unarmed BlendTree");
			this.STATE_Empty = this.mMotionController.AddAnimatorName(layerName + ".Empty");
			this.STATE_UnarmedBlendTree = this.mMotionController.AddAnimatorName(layerName + ".BasicWalkRunStrafe-SM.Unarmed BlendTree");
		}

		// Token: 0x0400077D RID: 1917
		public int PHASE_UNKNOWN;

		// Token: 0x0400077E RID: 1918
		public int PHASE_START = 3100;

		// Token: 0x0400077F RID: 1919
		public int PHASE_STOP = 3105;

		// Token: 0x04000780 RID: 1920
		public bool _RequireTarget = true;

		// Token: 0x04000781 RID: 1921
		public string _ActivationAlias = "";

		// Token: 0x04000782 RID: 1922
		public string _ActorStances = "";

		// Token: 0x04000783 RID: 1923
		public bool _DefaultToRun;

		// Token: 0x04000784 RID: 1924
		public float _WalkSpeed;

		// Token: 0x04000785 RID: 1925
		public float _RunSpeed;

		// Token: 0x04000786 RID: 1926
		private bool mStartInMove;

		// Token: 0x04000787 RID: 1927
		private bool mStartInWalk;

		// Token: 0x04000788 RID: 1928
		private bool mStartInRun;

		// Token: 0x04000789 RID: 1929
		public bool _RotateWithInput;

		// Token: 0x0400078A RID: 1930
		public bool _RotateWithCamera = true;

		// Token: 0x0400078B RID: 1931
		public float _RotationSpeed = 360f;

		// Token: 0x0400078C RID: 1932
		public int _SmoothingSamples = 10;

		// Token: 0x0400078D RID: 1933
		protected ICombatant mCombatant;

		// Token: 0x0400078E RID: 1934
		[SerializeField]
		protected List<int> mActorStances = new List<int>();

		// Token: 0x0400078F RID: 1935
		protected bool mLinkRotation;

		// Token: 0x04000790 RID: 1936
		protected float mYaw;

		// Token: 0x04000791 RID: 1937
		protected float mYawTarget;

		// Token: 0x04000792 RID: 1938
		protected float mYawVelocity;

		// Token: 0x04000793 RID: 1939
		protected FloatValue mInputX = new FloatValue(0f, 10);

		// Token: 0x04000794 RID: 1940
		protected FloatValue mInputY = new FloatValue(0f, 10);

		// Token: 0x04000795 RID: 1941
		protected FloatValue mInputMagnitude = new FloatValue(0f, 15);

		// Token: 0x04000796 RID: 1942
		protected float mIdleTime;

		// Token: 0x04000797 RID: 1943
		protected bool mIsRotationLocked;

		// Token: 0x04000798 RID: 1944
		protected int mActiveForm;

		// Token: 0x04000799 RID: 1945
		public int STATE_Empty = -1;

		// Token: 0x0400079A RID: 1946
		public int STATE_UnarmedBlendTree = -1;

		// Token: 0x0400079B RID: 1947
		public int TRANS_AnyState_UnarmedBlendTree = -1;

		// Token: 0x0400079C RID: 1948
		public int TRANS_EntryState_UnarmedBlendTree = -1;
	}
}
