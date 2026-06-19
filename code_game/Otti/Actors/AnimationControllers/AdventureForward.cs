using System;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000ED RID: 237
	[MotionName("Adventure Forward")]
	[MotionDescription("A forward walk/run blend that allows the avatar to rotate towards the camera. Best when used with the Adventure Camera.")]
	[MotionTypeTags("old")]
	public class AdventureForward : MotionControllerMotion
	{
		// Token: 0x06000C6A RID: 3178 RVA: 0x0003B1E6 File Offset: 0x000393E6
		public AdventureForward()
		{
			this._Priority = 1f;
			this.mIsStartable = true;
		}

		// Token: 0x06000C6B RID: 3179 RVA: 0x0003B200 File Offset: 0x00039400
		public AdventureForward(MotionController rController)
			: base(rController)
		{
			this._Priority = 1f;
			this.mIsStartable = true;
		}

		// Token: 0x06000C6C RID: 3180 RVA: 0x0003B21C File Offset: 0x0003941C
		public override void LoadAnimatorData()
		{
			string text = "Base Layer.";
			this.mMotionController.AddAnimatorName("Entry -> " + text + "AdventureForward-SM.Forward");
			this.mMotionController.AddAnimatorName("Entry -> " + text + "AdventureForward-SM.IdleToLeft90");
			this.mMotionController.AddAnimatorName("Entry -> " + text + "AdventureForward-SM.IdleToLeft135");
			this.mMotionController.AddAnimatorName("Entry -> " + text + "AdventureForward-SM.IdleToLeft180");
			this.mMotionController.AddAnimatorName("Entry -> " + text + "AdventureForward-SM.IdleToRight90");
			this.mMotionController.AddAnimatorName("Entry -> " + text + "AdventureForward-SM.IdleToRight135");
			this.mMotionController.AddAnimatorName("Entry -> " + text + "AdventureForward-SM.IdleToRight180");
			this.mMotionController.AddAnimatorName("Entry -> " + text + "AdventureForward-SM.IdleRotateLeft90");
			this.mMotionController.AddAnimatorName("Entry -> " + text + "AdventureForward-SM.IdleRotateLeft135");
			this.mMotionController.AddAnimatorName("Entry -> " + text + "AdventureForward-SM.IdleRotateRight90");
			this.mMotionController.AddAnimatorName("Entry -> " + text + "AdventureForward-SM.IdleRotateRight135");
			this.mMotionController.AddAnimatorName("Entry -> " + text + "AdventureForward-SM.IdleRotate180");
			this.mMotionController.AddAnimatorName("AnyState -> " + text + "AdventureForward-SM.Forward");
			this.mMotionController.AddAnimatorName("AnyState -> " + text + "AdventureForward-SM.IdleToLeft90");
			this.mMotionController.AddAnimatorName("AnyState -> " + text + "AdventureForward-SM.IdleToLeft135");
			this.mMotionController.AddAnimatorName("AnyState -> " + text + "AdventureForward-SM.IdleToLeft180");
			this.mMotionController.AddAnimatorName("AnyState -> " + text + "AdventureForward-SM.IdleToRight90");
			this.mMotionController.AddAnimatorName("AnyState -> " + text + "AdventureForward-SM.IdleToRight135");
			this.mMotionController.AddAnimatorName("AnyState -> " + text + "AdventureForward-SM.IdleToRight180");
			this.mMotionController.AddAnimatorName("AnyState -> " + text + "AdventureForward-SM.IdleRotateLeft90");
			this.mMotionController.AddAnimatorName("AnyState -> " + text + "AdventureForward-SM.IdleRotateLeft135");
			this.mMotionController.AddAnimatorName("AnyState -> " + text + "AdventureForward-SM.IdleRotateRight90");
			this.mMotionController.AddAnimatorName("AnyState -> " + text + "AdventureForward-SM.IdleRotateRight135");
			this.mMotionController.AddAnimatorName("AnyState -> " + text + "AdventureForward-SM.IdleRotate180");
			this.mMotionController.AddAnimatorName(text + "Idle-SM.Idle_Casual -> " + text + "AdventureForward-SM.Forward");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.IdleToLeft90");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.IdleToLeft135");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.IdleToLeft180");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.IdleToRight90");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.IdleToRight135");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.IdleToRight180");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.IdleRotateLeft90");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.IdleRotateLeft135");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.IdleRotateRight90");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.IdleRotateRight135");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.IdleRotate180");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.Forward");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.Run");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.Run -> " + text + "Idle-SM.Idle_Casual");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.Forward -> " + text + "Idle-SM.Idle_Casual");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.Run -> " + text + "AdventureForward-SM.RunLeft135");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.RunLeft135");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.RunLeft135 -> " + text + "AdventureForward-SM.Run");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.Run -> " + text + "AdventureForward-SM.RunLeft180");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.RunLeft180");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.RunLeft180 -> " + text + "AdventureForward-SM.Run");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.Run -> " + text + "AdventureForward-SM.RunRight135");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.RunRight135");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.RunRight135 -> " + text + "AdventureForward-SM.Run");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.Run -> " + text + "AdventureForward-SM.RunRight180");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.RunRight180");
			this.mMotionController.AddAnimatorName(text + "AdventureForward-SM.RunRight180 -> " + text + "AdventureForward-SM.Run");
		}

		// Token: 0x06000C6D RID: 3181 RVA: 0x0003B798 File Offset: 0x00039998
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
			MotionState state = this.mMotionController.State;
			return state.InputMagnitudeTrend.Value >= 0.03f;
		}

		// Token: 0x06000C6E RID: 3182 RVA: 0x0003B7E0 File Offset: 0x000399E0
		public override bool TestUpdate()
		{
			if (this.mIsActivatedFrame)
			{
				return true;
			}
			if (!this.IsInRunState && this.mMotionController.GetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex) != 400)
			{
				return false;
			}
			if (!this.mMotionController.IsGrounded)
			{
				return false;
			}
			MotionState state = this.mMotionController.State;
			return state.InputMagnitudeTrend.Average != 0f;
		}

		// Token: 0x06000C6F RID: 3183 RVA: 0x0003B84F File Offset: 0x00039A4F
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			if (!this.IsInRunState)
			{
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, 400, true);
			}
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000C70 RID: 3184 RVA: 0x0003B87C File Offset: 0x00039A7C
		public override void Deactivate()
		{
			base.Deactivate();
		}

		// Token: 0x06000C71 RID: 3185 RVA: 0x0003B884 File Offset: 0x00039A84
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rVelocityDelta, ref Quaternion rRotationDelta)
		{
			rVelocityDelta.x = 0f;
			if (rVelocityDelta.z < 0f)
			{
				rVelocityDelta.z = 0f;
			}
			if (!this.IsInPivotState)
			{
				rRotationDelta = Quaternion.identity;
			}
		}

		// Token: 0x06000C72 RID: 3186 RVA: 0x0003B8C0 File Offset: 0x00039AC0
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			if (!this.TestUpdate())
			{
				this.Deactivate();
				return;
			}
			if (this.IsInRunState)
			{
				float num = this.mMotionController.State.InputFromAvatarAngle * this.mMotionController.RotationSpeed;
				if (Mathf.Abs(this.mMotionController.State.InputFromAvatarAngle) > 10f)
				{
					num /= 90f;
				}
				else if (Mathf.Abs(num * Time.deltaTime) > Mathf.Abs(this.mMotionController.State.InputFromAvatarAngle))
				{
					num = this.mMotionController.State.InputFromAvatarAngle / Time.deltaTime;
				}
				this.mAngularVelocity.y = num;
			}
			string text = "Base Layer.";
			string animatorStateName = this.mMotionController.GetAnimatorStateName(this.mMotionLayer.AnimatorLayerIndex);
			if (animatorStateName == text + "AdventureForward-SM.Run" || animatorStateName == text + "AdventureForward-SM.RunLeft135" || animatorStateName == text + "AdventureForward-SM.RunLeft180" || animatorStateName == text + "AdventureForward-SM.RunRight135" || animatorStateName == text + "AdventureForward-SM.RunRight180")
			{
				this.mUseTrendData = true;
				return;
			}
			this.mUseTrendData = false;
		}

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x06000C73 RID: 3187 RVA: 0x0003B9FC File Offset: 0x00039BFC
		public bool IsInRunState
		{
			get
			{
				string animatorStateName = this.mMotionController.GetAnimatorStateName(this.mMotionLayer.AnimatorLayerIndex);
				string animatorStateTransitionName = this.mMotionController.GetAnimatorStateTransitionName(this.mMotionLayer.AnimatorLayerIndex);
				return animatorStateName.Length != 0 && (animatorStateName.IndexOf("AdventureForward-SM") >= 0 || animatorStateTransitionName.IndexOf("AdventureForward-SM") >= 0);
			}
		}

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x06000C74 RID: 3188 RVA: 0x0003BA60 File Offset: 0x00039C60
		public bool IsInPivotState
		{
			get
			{
				string text = "Base Layer.";
				string animatorStateName = this.mMotionController.GetAnimatorStateName(this.mMotionLayer.AnimatorLayerIndex);
				string animatorStateTransitionName = this.mMotionController.GetAnimatorStateTransitionName(this.mMotionLayer.AnimatorLayerIndex);
				return animatorStateTransitionName == text + "AdventureForward-SM.Run -> " + text + "AdventureForward-SM.RunLeft135" || animatorStateName == text + "AdventureForward-SM.RunLeft135" || animatorStateTransitionName == text + "AdventureForward-SM.RunLeft135 -> " + text + "AdventureForward-SM.Run" || animatorStateTransitionName == text + "AdventureForward-SM.Run -> " + text + "AdventureForward-SM.RunLeft180" || animatorStateName == text + "AdventureForward-SM.RunLeft180" || animatorStateTransitionName == text + "AdventureForward-SM.RunLeft180 -> " + text + "AdventureForward-SM.Run" || animatorStateTransitionName == text + "AdventureForward-SM.Run -> " + text + "AdventureForward-SM.RunRight135" || animatorStateName == text + "AdventureForward-SM.RunRight135" || animatorStateTransitionName == text + "AdventureForward-SM.RunRight135 -> " + text + "AdventureForward-SM.Run" || animatorStateTransitionName == text + "AdventureForward-SM.Run -> " + text + "AdventureForward-SM.RunRight180" || animatorStateName == text + "AdventureForward-SM.RunRight180" || animatorStateTransitionName == text + "AdventureForward-SM.RunRight180 -> " + text + "AdventureForward-SM.Run" || animatorStateTransitionName == "Entry -> " + text + "AdventureForward-SM.IdleToLeft90" || animatorStateTransitionName == "Entry -> " + text + "AdventureForward-SM.IdleToLeft135" || animatorStateTransitionName == "Entry -> " + text + "AdventureForward-SM.IdleToLeft180" || animatorStateTransitionName == "Entry -> " + text + "AdventureForward-SM.IdleToRight90" || animatorStateTransitionName == "Entry -> " + text + "AdventureForward-SM.IdleToRight135" || animatorStateTransitionName == "Entry -> " + text + "AdventureForward-SM.IdleToRight180" || animatorStateTransitionName == "AnyState -> " + text + "AdventureForward-SM.IdleToLeft90" || animatorStateTransitionName == "AnyState -> " + text + "AdventureForward-SM.IdleToLeft135" || animatorStateTransitionName == "AnyState -> " + text + "AdventureForward-SM.IdleToLeft180" || animatorStateTransitionName == "AnyState -> " + text + "AdventureForward-SM.IdleToRight90" || animatorStateTransitionName == "AnyState -> " + text + "AdventureForward-SM.IdleToRight135" || animatorStateTransitionName == "AnyState -> " + text + "AdventureForward-SM.IdleToRight180" || animatorStateName == text + "AdventureForward-SM.IdleToRight90" || animatorStateName == text + "AdventureForward-SM.IdleToRight135" || animatorStateName == text + "AdventureForward-SM.IdleToRight180" || animatorStateName == text + "AdventureForward-SM.IdleToLeft90" || animatorStateName == text + "AdventureForward-SM.IdleToLeft135" || animatorStateName == text + "AdventureForward-SM.IdleToLeft180" || animatorStateName == text + "AdventureForward-SM.IdleRotateRight90" || animatorStateName == text + "AdventureForward-SM.IdleRotateRight135" || animatorStateName == text + "AdventureForward-SM.IdleRotateLeft90" || animatorStateName == text + "AdventureForward-SM.IdleRotateLeft135" || animatorStateName == text + "AdventureForward-SM.IdleRotate180" || animatorStateTransitionName == "Entry -> " + text + "AdventureForward-SM.IdleRotateLeft90" || animatorStateTransitionName == "Entry -> " + text + "AdventureForward-SM.IdleRotateLeft135" || animatorStateTransitionName == "Entry -> " + text + "AdventureForward-SM.IdleRotateRight90" || animatorStateTransitionName == "Entry -> " + text + "AdventureForward-SM.IdleRotateRight135" || animatorStateTransitionName == "Entry -> " + text + "AdventureForward-SM.IdleRotate180" || animatorStateTransitionName == "AnyState -> " + text + "AdventureForward-SM.IdleRotateLeft90" || animatorStateTransitionName == "AnyState -> " + text + "AdventureForward-SM.IdleRotateLeft135" || animatorStateTransitionName == "AnyState -> " + text + "AdventureForward-SM.IdleRotateRight90" || animatorStateTransitionName == "AnyState -> " + text + "AdventureForward-SM.IdleRotateRight135" || animatorStateTransitionName == "AnyState -> " + text + "AdventureForward-SM.IdleRotate180";
			}
		}

		// Token: 0x04000689 RID: 1673
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x0400068A RID: 1674
		public const int PHASE_START = 400;
	}
}
