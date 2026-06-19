using System;
using com.ootii.Helpers;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x02000111 RID: 273
	[MotionDescription("This motion is a simple pose used when the avatar starts to slide down a ramp.")]
	public class Slide : MotionControllerMotion
	{
		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x06001025 RID: 4133 RVA: 0x00055D2F File Offset: 0x00053F2F
		// (set) Token: 0x06001026 RID: 4134 RVA: 0x00055D37 File Offset: 0x00053F37
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

		// Token: 0x06001027 RID: 4135 RVA: 0x00055D40 File Offset: 0x00053F40
		public Slide()
		{
			this._Priority = 6f;
			this.mIsStartable = true;
		}

		// Token: 0x06001028 RID: 4136 RVA: 0x00055D65 File Offset: 0x00053F65
		public Slide(MotionController rController)
			: base(rController)
		{
			this._Priority = 6f;
			this.mIsStartable = true;
		}

		// Token: 0x06001029 RID: 4137 RVA: 0x00055D8C File Offset: 0x00053F8C
		public override bool TestActivate()
		{
			return this.mIsStartable && this.mMotionController.IsGrounded && this.mMotionController.State.InputMagnitudeTrend.Value <= 0f && this.mActorController.State.GroundSurfaceAngle >= this.mActorController.MinSlopeAngle;
		}

		// Token: 0x0600102A RID: 4138 RVA: 0x00055DF0 File Offset: 0x00053FF0
		public override bool TestUpdate()
		{
			return this.mIsActivatedFrame || (this.mMotionController.IsGrounded && this.mMotionController.State.InputMagnitudeTrend.Value <= 0f);
		}

		// Token: 0x0600102B RID: 4139 RVA: 0x00055E2A File Offset: 0x0005402A
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 700, true);
			return base.Activate(rPrevMotion);
		}

		// Token: 0x0600102C RID: 4140 RVA: 0x00055E4F File Offset: 0x0005404F
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rVelocityDelta, ref Quaternion rRotationDelta)
		{
			rVelocityDelta = Vector3.zero;
			rRotationDelta = Quaternion.identity;
		}

		// Token: 0x0600102D RID: 4141 RVA: 0x00055E68 File Offset: 0x00054068
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			bool flag = true;
			if (this.mActorController.State.GroundSurfaceAngle < this.mActorController.MinSlopeAngle)
			{
				flag = false;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 705, true);
			}
			if (this.mMotionLayer._AnimatorStateID == Slide.STATE_IdlePose)
			{
				flag = false;
				this.Deactivate();
			}
			if (flag && this._RotationSpeed > 0f)
			{
				Vector3 vector = Vector3.down;
				Vector3 groundSurfaceNormal = this.mActorController.State.GroundSurfaceNormal;
				Vector3.OrthoNormalize(ref groundSurfaceNormal, ref vector);
				Vector3 up = this.mActorController._Transform.up;
				vector -= up;
				vector.Normalize();
				float horizontalAngle = NumberHelper.GetHorizontalAngle(this.mMotionController._Transform.forward, vector);
				if (Mathf.Abs(horizontalAngle) > 0.01f)
				{
					float num = horizontalAngle * this._RotationSpeed * Time.deltaTime;
					this.mAngularVelocity.y = num;
				}
			}
		}

		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x0600102E RID: 4142 RVA: 0x00055F68 File Offset: 0x00054168
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				return animatorStateID == Slide.STATE_Slide || animatorStateID == Slide.STATE_IdlePose;
			}
		}

		// Token: 0x0600102F RID: 4143 RVA: 0x00055F96 File Offset: 0x00054196
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == Slide.STATE_Slide || rStateID == Slide.STATE_IdlePose;
		}

		// Token: 0x06001030 RID: 4144 RVA: 0x00055FB0 File Offset: 0x000541B0
		public override void LoadAnimatorData()
		{
			Slide.TRANS_EntryState_Slide = this.mMotionController.AddAnimatorName("Entry -> Base Layer.Slide-SM.Slide");
			Slide.TRANS_AnyState_Slide = this.mMotionController.AddAnimatorName("AnyState -> Base Layer.Slide-SM.Slide");
			Slide.STATE_Slide = this.mMotionController.AddAnimatorName("Base Layer.Slide-SM.Slide");
			Slide.TRANS_Slide_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Slide-SM.Slide -> Base Layer.Slide-SM.IdlePose");
			Slide.STATE_IdlePose = this.mMotionController.AddAnimatorName("Base Layer.Slide-SM.IdlePose");
		}

		// Token: 0x04000ACD RID: 2765
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000ACE RID: 2766
		public const int PHASE_START = 700;

		// Token: 0x04000ACF RID: 2767
		public const int PHASE_END = 705;

		// Token: 0x04000AD0 RID: 2768
		public float _RotationSpeed = 180f;

		// Token: 0x04000AD1 RID: 2769
		public static int TRANS_EntryState_Slide = -1;

		// Token: 0x04000AD2 RID: 2770
		public static int TRANS_AnyState_Slide = -1;

		// Token: 0x04000AD3 RID: 2771
		public static int STATE_Slide = -1;

		// Token: 0x04000AD4 RID: 2772
		public static int TRANS_Slide_IdlePose = -1;

		// Token: 0x04000AD5 RID: 2773
		public static int STATE_IdlePose = -1;
	}
}
