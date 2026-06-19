using System;
using com.ootii.Helpers;
using com.ootii.Timing;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x02000112 RID: 274
	[MotionName("Sneak (old)")]
	[MotionDescription("A forward motion that looks like the avatar is sneaking. The motion is slower than a walk and has the actor strafe instead of turn.")]
	public class Sneak : MotionControllerMotion
	{
		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x06001032 RID: 4146 RVA: 0x00056046 File Offset: 0x00054246
		// (set) Token: 0x06001033 RID: 4147 RVA: 0x0005604E File Offset: 0x0005424E
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
					this._RotateWithView = false;
				}
			}
		}

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x06001034 RID: 4148 RVA: 0x00056066 File Offset: 0x00054266
		// (set) Token: 0x06001035 RID: 4149 RVA: 0x0005606E File Offset: 0x0005426E
		public bool RotateWithView
		{
			get
			{
				return this._RotateWithView;
			}
			set
			{
				this._RotateWithView = value;
				if (this._RotateWithView)
				{
					this._RotateWithInput = false;
				}
			}
		}

		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x06001036 RID: 4150 RVA: 0x00056086 File Offset: 0x00054286
		// (set) Token: 0x06001037 RID: 4151 RVA: 0x0005608E File Offset: 0x0005428E
		public float RotationSpeed
		{
			get
			{
				return this._RotationSpeed;
			}
			set
			{
				this._RotationSpeed = value;
				this.mDegreesPer60FPSTick = this._RotationSpeed / 60f;
			}
		}

		// Token: 0x06001038 RID: 4152 RVA: 0x000560AC File Offset: 0x000542AC
		public Sneak()
		{
			this._Priority = 6f;
			this._ActionAlias = "ChangeStance";
			this.mIsStartable = true;
		}

		// Token: 0x06001039 RID: 4153 RVA: 0x000560FC File Offset: 0x000542FC
		public Sneak(MotionController rController)
			: base(rController)
		{
			this._Priority = 6f;
			this._ActionAlias = "ChangeStance";
			this.mIsStartable = true;
		}

		// Token: 0x0600103A RID: 4154 RVA: 0x0005614A File Offset: 0x0005434A
		public override void Awake()
		{
			base.Awake();
			this.mDegreesPer60FPSTick = this._RotationSpeed / 60f;
		}

		// Token: 0x0600103B RID: 4155 RVA: 0x00056164 File Offset: 0x00054364
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
			if (this.mActorController.State.Stance == 4)
			{
				return true;
			}
			if (this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsEnabled && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias))
			{
				if (this.mActorController.State.Stance != 4)
				{
					this.mActorController.State.Stance = 4;
					return true;
				}
				this.mActorController.State.Stance = 0;
			}
			return false;
		}

		// Token: 0x0600103C RID: 4156 RVA: 0x00056210 File Offset: 0x00054410
		public override bool TestUpdate()
		{
			return this.mIsActivatedFrame || (this.mMotionController.IsGrounded && (!this.mHasEnteredState || this.IsInSneakState) && this.mActorController.State.Stance == 4);
		}

		// Token: 0x0600103D RID: 4157 RVA: 0x0005625E File Offset: 0x0005445E
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mHasEnteredState = false;
			this.mActorController.State.Stance = 4;
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 600, true);
			return base.Activate(rPrevMotion);
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x0005629B File Offset: 0x0005449B
		public override void Deactivate()
		{
			if (this.mActorController.State.Stance == 4)
			{
				this.mActorController.State.Stance = 0;
			}
			base.Deactivate();
		}

		// Token: 0x0600103F RID: 4159 RVA: 0x000562C7 File Offset: 0x000544C7
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rVelocityDelta, ref Quaternion rRotationDelta)
		{
			rRotationDelta = Quaternion.identity;
		}

		// Token: 0x06001040 RID: 4160 RVA: 0x000562D8 File Offset: 0x000544D8
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			int animatorStateID = this.mMotionLayer._AnimatorStateID;
			if (animatorStateID == Sneak.STATE_SneakIdle)
			{
				if (this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsEnabled && this.mMotionController.InputSource.IsJustPressed(this._ActionAlias))
				{
					this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 610, true);
				}
			}
			else if (animatorStateID == Sneak.STATE_IdlePose)
			{
				this.Deactivate();
				if (this.mActorController.State.Stance == 4)
				{
					this.mActorController.State.Stance = 0;
				}
			}
			if (this._RotateWithInput)
			{
				this.mRotation = Quaternion.identity;
				this.GetRotationVelocityWithInput(rDeltaTime, ref this.mRotation);
			}
			else if (this._RotateWithView)
			{
				this.mAngularVelocity = Vector3.zero;
				this.GetRotationVelocityWithView(rDeltaTime, ref this.mAngularVelocity);
			}
			this.mUseTrendData = true;
			if (!this.mHasEnteredState && this.IsInSneakState)
			{
				this.mHasEnteredState = true;
			}
		}

		// Token: 0x06001041 RID: 4161 RVA: 0x000563E0 File Offset: 0x000545E0
		private void GetRotationVelocityWithView(float rDeltaTime, ref Vector3 rRotationalVelocity)
		{
			if (this.mMotionController._CameraTransform == null)
			{
				return;
			}
			float num = 0f;
			float smoothedDeltaTime = TimeManager.SmoothedDeltaTime;
			float horizontalAngle = NumberHelper.GetHorizontalAngle(this.mMotionController._Transform.forward, this.mMotionController._CameraTransform.forward);
			if (horizontalAngle > 0f)
			{
				if (this._RotationSpeed == 0f)
				{
					num = horizontalAngle / smoothedDeltaTime;
				}
				else
				{
					if (this._RotationSpeed < 0f)
					{
						num = this.mMotionController._RotationSpeed;
					}
					else
					{
						num = this._RotationSpeed;
					}
					if (num * smoothedDeltaTime > horizontalAngle)
					{
						num = horizontalAngle / smoothedDeltaTime;
					}
				}
			}
			else if (horizontalAngle < 0f)
			{
				if (this._RotationSpeed == 0f)
				{
					num = horizontalAngle / smoothedDeltaTime;
				}
				else
				{
					if (this._RotationSpeed < 0f)
					{
						num = -this.mMotionController._RotationSpeed;
					}
					else
					{
						num = -this._RotationSpeed;
					}
					if (num * smoothedDeltaTime < horizontalAngle)
					{
						num = horizontalAngle / smoothedDeltaTime;
					}
				}
			}
			rRotationalVelocity = this.mMotionController._Transform.up * num;
		}

		// Token: 0x06001042 RID: 4162 RVA: 0x000564E4 File Offset: 0x000546E4
		private void GetRotationVelocityWithInput(float rDeltaTime, ref Quaternion rRotation)
		{
			if (this.mMotionController._InputSource == null)
			{
				return;
			}
			if (this.mMotionController._InputSource.IsViewingActivated)
			{
				float viewX = this.mMotionController._InputSource.ViewX;
				rRotation = Quaternion.Euler(0f, viewX * this.mDegreesPer60FPSTick, 0f);
			}
		}

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x06001043 RID: 4163 RVA: 0x00056540 File Offset: 0x00054740
		public bool IsInSneakState
		{
			get
			{
				if (this.IsInMotionState)
				{
					return true;
				}
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorTransitionID == Sneak.TRANS_AnyState_SneakForward || animatorTransitionID == Sneak.TRANS_EntryState_SneakForward || animatorTransitionID == Sneak.TRANS_AnyState_SneakIdle || animatorTransitionID == Sneak.TRANS_EntryState_SneakIdle;
			}
		}

		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x06001044 RID: 4164 RVA: 0x00056586 File Offset: 0x00054786
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000487 RID: 1159
		// (get) Token: 0x06001045 RID: 4165 RVA: 0x0005658C File Offset: 0x0005478C
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				return animatorStateID == Sneak.STATE_SneakForward || animatorStateID == Sneak.STATE_SneakBackward || animatorStateID == Sneak.STATE_SneakIdle || animatorStateID == Sneak.STATE_SneakLeft || animatorStateID == Sneak.STATE_SneakRight || animatorStateID == Sneak.STATE_IdlePose || animatorTransitionID == Sneak.TRANS_AnyState_SneakIdle || animatorTransitionID == Sneak.TRANS_EntryState_SneakIdle || animatorTransitionID == Sneak.TRANS_AnyState_SneakForward || animatorTransitionID == Sneak.TRANS_EntryState_SneakForward || animatorTransitionID == Sneak.TRANS_SneakForward_SneakBackward || animatorTransitionID == Sneak.TRANS_SneakForward_SneakIdle || animatorTransitionID == Sneak.TRANS_SneakForward_SneakBackward || animatorTransitionID == Sneak.TRANS_SneakForward_SneakLeft || animatorTransitionID == Sneak.TRANS_SneakForward_SneakRight || animatorTransitionID == Sneak.TRANS_SneakBackward_SneakForward || animatorTransitionID == Sneak.TRANS_SneakBackward_SneakIdle || animatorTransitionID == Sneak.TRANS_SneakBackward_SneakLeft || animatorTransitionID == Sneak.TRANS_SneakBackward_SneakRight || animatorTransitionID == Sneak.TRANS_SneakIdle_SneakBackward || animatorTransitionID == Sneak.TRANS_SneakIdle_SneakForward || animatorTransitionID == Sneak.TRANS_SneakIdle_SneakBackward || animatorTransitionID == Sneak.TRANS_SneakIdle_SneakLeft || animatorTransitionID == Sneak.TRANS_SneakIdle_SneakRight || animatorTransitionID == Sneak.TRANS_SneakIdle_IdlePose || animatorTransitionID == Sneak.TRANS_SneakLeft_SneakBackward || animatorTransitionID == Sneak.TRANS_SneakLeft_SneakForward || animatorTransitionID == Sneak.TRANS_SneakLeft_SneakRight || animatorTransitionID == Sneak.TRANS_SneakLeft_SneakIdle || animatorTransitionID == Sneak.TRANS_SneakRight_SneakForward || animatorTransitionID == Sneak.TRANS_SneakRight_SneakBackward || animatorTransitionID == Sneak.TRANS_SneakRight_SneakLeft || animatorTransitionID == Sneak.TRANS_SneakRight_SneakIdle;
			}
		}

		// Token: 0x06001046 RID: 4166 RVA: 0x000566FC File Offset: 0x000548FC
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == Sneak.STATE_SneakForward || rStateID == Sneak.STATE_SneakBackward || rStateID == Sneak.STATE_SneakIdle || rStateID == Sneak.STATE_SneakLeft || rStateID == Sneak.STATE_SneakRight || rStateID == Sneak.STATE_IdlePose;
		}

		// Token: 0x06001047 RID: 4167 RVA: 0x0005673C File Offset: 0x0005493C
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			return rStateID == Sneak.STATE_SneakForward || rStateID == Sneak.STATE_SneakBackward || rStateID == Sneak.STATE_SneakIdle || rStateID == Sneak.STATE_SneakLeft || rStateID == Sneak.STATE_SneakRight || rStateID == Sneak.STATE_IdlePose || rTransitionID == Sneak.TRANS_AnyState_SneakIdle || rTransitionID == Sneak.TRANS_EntryState_SneakIdle || rTransitionID == Sneak.TRANS_AnyState_SneakForward || rTransitionID == Sneak.TRANS_EntryState_SneakForward || rTransitionID == Sneak.TRANS_SneakForward_SneakBackward || rTransitionID == Sneak.TRANS_SneakForward_SneakIdle || rTransitionID == Sneak.TRANS_SneakForward_SneakBackward || rTransitionID == Sneak.TRANS_SneakForward_SneakLeft || rTransitionID == Sneak.TRANS_SneakForward_SneakRight || rTransitionID == Sneak.TRANS_SneakBackward_SneakForward || rTransitionID == Sneak.TRANS_SneakBackward_SneakIdle || rTransitionID == Sneak.TRANS_SneakBackward_SneakLeft || rTransitionID == Sneak.TRANS_SneakBackward_SneakRight || rTransitionID == Sneak.TRANS_SneakIdle_SneakBackward || rTransitionID == Sneak.TRANS_SneakIdle_SneakForward || rTransitionID == Sneak.TRANS_SneakIdle_SneakBackward || rTransitionID == Sneak.TRANS_SneakIdle_SneakLeft || rTransitionID == Sneak.TRANS_SneakIdle_SneakRight || rTransitionID == Sneak.TRANS_SneakIdle_IdlePose || rTransitionID == Sneak.TRANS_SneakLeft_SneakBackward || rTransitionID == Sneak.TRANS_SneakLeft_SneakForward || rTransitionID == Sneak.TRANS_SneakLeft_SneakRight || rTransitionID == Sneak.TRANS_SneakLeft_SneakIdle || rTransitionID == Sneak.TRANS_SneakRight_SneakForward || rTransitionID == Sneak.TRANS_SneakRight_SneakBackward || rTransitionID == Sneak.TRANS_SneakRight_SneakLeft || rTransitionID == Sneak.TRANS_SneakRight_SneakIdle;
		}

		// Token: 0x06001048 RID: 4168 RVA: 0x00056894 File Offset: 0x00054A94
		public override void LoadAnimatorData()
		{
			Sneak.TRANS_AnyState_SneakIdle = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Sneak-SM.SneakIdle");
			Sneak.TRANS_EntryState_SneakIdle = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Sneak-SM.SneakIdle");
			Sneak.TRANS_AnyState_SneakForward = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Sneak-SM.SneakForward");
			Sneak.TRANS_EntryState_SneakForward = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Sneak-SM.SneakForward");
			Sneak.STATE_SneakForward = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakForward");
			Sneak.TRANS_SneakForward_SneakBackward = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakForward -> Base Layer.Sneak-SM.SneakBackward");
			Sneak.TRANS_SneakForward_SneakIdle = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakForward -> Base Layer.Sneak-SM.SneakIdle");
			Sneak.TRANS_SneakForward_SneakBackward = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakForward -> Base Layer.Sneak-SM.SneakBackward");
			Sneak.TRANS_SneakForward_SneakLeft = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakForward -> Base Layer.Sneak-SM.SneakLeft");
			Sneak.TRANS_SneakForward_SneakRight = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakForward -> Base Layer.Sneak-SM.SneakRight");
			Sneak.STATE_SneakBackward = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakBackward");
			Sneak.TRANS_SneakBackward_SneakForward = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakBackward -> Base Layer.Sneak-SM.SneakForward");
			Sneak.TRANS_SneakBackward_SneakIdle = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakBackward -> Base Layer.Sneak-SM.SneakIdle");
			Sneak.TRANS_SneakBackward_SneakLeft = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakBackward -> Base Layer.Sneak-SM.SneakLeft");
			Sneak.TRANS_SneakBackward_SneakRight = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakBackward -> Base Layer.Sneak-SM.SneakRight");
			Sneak.STATE_SneakIdle = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakIdle");
			Sneak.TRANS_SneakIdle_SneakBackward = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakIdle -> Base Layer.Sneak-SM.SneakBackward");
			Sneak.TRANS_SneakIdle_SneakForward = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakIdle -> Base Layer.Sneak-SM.SneakForward");
			Sneak.TRANS_SneakIdle_SneakBackward = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakIdle -> Base Layer.Sneak-SM.SneakBackward");
			Sneak.TRANS_SneakIdle_SneakLeft = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakIdle -> Base Layer.Sneak-SM.SneakLeft");
			Sneak.TRANS_SneakIdle_SneakRight = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakIdle -> Base Layer.Sneak-SM.SneakRight");
			Sneak.TRANS_SneakIdle_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakIdle -> Base Layer.Sneak-SM.IdlePose");
			Sneak.STATE_SneakLeft = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakLeft");
			Sneak.TRANS_SneakLeft_SneakBackward = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakLeft -> Base Layer.Sneak-SM.SneakBackward");
			Sneak.TRANS_SneakLeft_SneakForward = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakLeft -> Base Layer.Sneak-SM.SneakForward");
			Sneak.TRANS_SneakLeft_SneakRight = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakLeft -> Base Layer.Sneak-SM.SneakRight");
			Sneak.TRANS_SneakLeft_SneakIdle = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakLeft -> Base Layer.Sneak-SM.SneakIdle");
			Sneak.STATE_SneakRight = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakRight");
			Sneak.TRANS_SneakRight_SneakForward = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakRight -> Base Layer.Sneak-SM.SneakForward");
			Sneak.TRANS_SneakRight_SneakBackward = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakRight -> Base Layer.Sneak-SM.SneakBackward");
			Sneak.TRANS_SneakRight_SneakLeft = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakRight -> Base Layer.Sneak-SM.SneakLeft");
			Sneak.TRANS_SneakRight_SneakIdle = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.SneakRight -> Base Layer.Sneak-SM.SneakIdle");
			Sneak.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Sneak-SM.IdlePose");
		}

		// Token: 0x04000AD6 RID: 2774
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000AD7 RID: 2775
		public const int PHASE_START = 600;

		// Token: 0x04000AD8 RID: 2776
		public const int PHASE_END = 610;

		// Token: 0x04000AD9 RID: 2777
		public bool _RotateWithInput = true;

		// Token: 0x04000ADA RID: 2778
		public bool _RotateWithView;

		// Token: 0x04000ADB RID: 2779
		public float _RotationSpeed = 120f;

		// Token: 0x04000ADC RID: 2780
		protected float mDegreesPer60FPSTick = 1f;

		// Token: 0x04000ADD RID: 2781
		private bool mHasEnteredState;

		// Token: 0x04000ADE RID: 2782
		public static int STATE_SneakForward = -1;

		// Token: 0x04000ADF RID: 2783
		public static int STATE_SneakBackward = -1;

		// Token: 0x04000AE0 RID: 2784
		public static int STATE_SneakIdle = -1;

		// Token: 0x04000AE1 RID: 2785
		public static int STATE_SneakLeft = -1;

		// Token: 0x04000AE2 RID: 2786
		public static int STATE_SneakRight = -1;

		// Token: 0x04000AE3 RID: 2787
		public static int STATE_IdlePose = -1;

		// Token: 0x04000AE4 RID: 2788
		public static int TRANS_AnyState_SneakIdle = -1;

		// Token: 0x04000AE5 RID: 2789
		public static int TRANS_EntryState_SneakIdle = -1;

		// Token: 0x04000AE6 RID: 2790
		public static int TRANS_AnyState_SneakForward = -1;

		// Token: 0x04000AE7 RID: 2791
		public static int TRANS_EntryState_SneakForward = -1;

		// Token: 0x04000AE8 RID: 2792
		public static int TRANS_SneakForward_SneakBackward = -1;

		// Token: 0x04000AE9 RID: 2793
		public static int TRANS_SneakForward_SneakIdle = -1;

		// Token: 0x04000AEA RID: 2794
		public static int TRANS_SneakForward_SneakLeft = -1;

		// Token: 0x04000AEB RID: 2795
		public static int TRANS_SneakForward_SneakRight = -1;

		// Token: 0x04000AEC RID: 2796
		public static int TRANS_SneakBackward_SneakForward = -1;

		// Token: 0x04000AED RID: 2797
		public static int TRANS_SneakBackward_SneakIdle = -1;

		// Token: 0x04000AEE RID: 2798
		public static int TRANS_SneakBackward_SneakLeft = -1;

		// Token: 0x04000AEF RID: 2799
		public static int TRANS_SneakBackward_SneakRight = -1;

		// Token: 0x04000AF0 RID: 2800
		public static int TRANS_SneakIdle_SneakBackward = -1;

		// Token: 0x04000AF1 RID: 2801
		public static int TRANS_SneakIdle_SneakForward = -1;

		// Token: 0x04000AF2 RID: 2802
		public static int TRANS_SneakIdle_SneakLeft = -1;

		// Token: 0x04000AF3 RID: 2803
		public static int TRANS_SneakIdle_SneakRight = -1;

		// Token: 0x04000AF4 RID: 2804
		public static int TRANS_SneakIdle_IdlePose = -1;

		// Token: 0x04000AF5 RID: 2805
		public static int TRANS_SneakLeft_SneakBackward = -1;

		// Token: 0x04000AF6 RID: 2806
		public static int TRANS_SneakLeft_SneakForward = -1;

		// Token: 0x04000AF7 RID: 2807
		public static int TRANS_SneakLeft_SneakRight = -1;

		// Token: 0x04000AF8 RID: 2808
		public static int TRANS_SneakLeft_SneakIdle = -1;

		// Token: 0x04000AF9 RID: 2809
		public static int TRANS_SneakRight_SneakForward = -1;

		// Token: 0x04000AFA RID: 2810
		public static int TRANS_SneakRight_SneakBackward = -1;

		// Token: 0x04000AFB RID: 2811
		public static int TRANS_SneakRight_SneakLeft = -1;

		// Token: 0x04000AFC RID: 2812
		public static int TRANS_SneakRight_SneakIdle = -1;
	}
}
