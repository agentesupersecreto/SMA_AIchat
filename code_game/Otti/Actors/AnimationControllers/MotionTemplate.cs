using System;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x0200010B RID: 267
	[MotionName("Motion Template")]
	[MotionDescription("Starting point for your own custom motions.")]
	public abstract class MotionTemplate : MotionControllerMotion
	{
		// Token: 0x06000FB2 RID: 4018 RVA: 0x00052CD6 File Offset: 0x00050ED6
		public MotionTemplate()
		{
			this._Priority = 10f;
		}

		// Token: 0x06000FB3 RID: 4019 RVA: 0x00052CE9 File Offset: 0x00050EE9
		public MotionTemplate(MotionController rController)
			: base(rController)
		{
			this._Priority = 10f;
		}

		// Token: 0x06000FB4 RID: 4020 RVA: 0x00052CFD File Offset: 0x00050EFD
		public override void Initialize()
		{
		}

		// Token: 0x06000FB5 RID: 4021 RVA: 0x00052CFF File Offset: 0x00050EFF
		public override bool TestActivate()
		{
			bool mIsStartable = this.mIsStartable;
			return false;
		}

		// Token: 0x06000FB6 RID: 4022 RVA: 0x00052D09 File Offset: 0x00050F09
		public override bool TestUpdate()
		{
			bool mIsAnimatorActive = this.mIsAnimatorActive;
			return true;
		}

		// Token: 0x06000FB7 RID: 4023 RVA: 0x00052D13 File Offset: 0x00050F13
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			return true;
		}

		// Token: 0x06000FB8 RID: 4024 RVA: 0x00052D16 File Offset: 0x00050F16
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer._AnimatorLayerIndex, 0, true);
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000FB9 RID: 4025 RVA: 0x00052D37 File Offset: 0x00050F37
		public override void Deactivate()
		{
			base.Deactivate();
		}

		// Token: 0x06000FBA RID: 4026 RVA: 0x00052D3F File Offset: 0x00050F3F
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rVelocityDelta, ref Quaternion rRotationDelta)
		{
		}

		// Token: 0x06000FBB RID: 4027 RVA: 0x00052D41 File Offset: 0x00050F41
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
		}

		// Token: 0x04000A17 RID: 2583
		public const int PHASE_UNKNOWN = 0;

		// Token: 0x04000A18 RID: 2584
		public const int PHASE_START = 0;
	}
}
