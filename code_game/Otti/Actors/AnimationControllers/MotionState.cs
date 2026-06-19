using System;
using com.ootii.Geometry;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000DD RID: 221
	public struct MotionState
	{
		// Token: 0x06000B19 RID: 2841 RVA: 0x00034BEC File Offset: 0x00032DEC
		public static void Shift(ref MotionState rCurrent, ref MotionState rPrev)
		{
			AnimatorLayerState[] animatorStates = rPrev.AnimatorStates;
			rPrev = rCurrent;
			rPrev.AnimatorStates = animatorStates;
			if (rPrev.AnimatorStates != null)
			{
				int num = animatorStates.Length;
				for (int i = 0; i < num; i++)
				{
					rPrev.AnimatorStates[i].SetTime = rCurrent.AnimatorStates[i].SetTime;
					rPrev.AnimatorStates[i].MotionPhase = rCurrent.AnimatorStates[i].MotionPhase;
					rPrev.AnimatorStates[i].MotionForm = rCurrent.AnimatorStates[i].MotionForm;
					rPrev.AnimatorStates[i].MotionParameter = rCurrent.AnimatorStates[i].MotionParameter;
					rPrev.AnimatorStates[i].AutoClearMotionPhase = rCurrent.AnimatorStates[i].AutoClearMotionPhase;
					rPrev.AnimatorStates[i].AutoClearMotionPhaseReady = rCurrent.AnimatorStates[i].AutoClearMotionPhaseReady;
					rPrev.AnimatorStates[i].AutoClearActiveTransitionID = rCurrent.AnimatorStates[i].AutoClearActiveTransitionID;
					rPrev.AnimatorStates[i].StateInfo = rCurrent.AnimatorStates[i].StateInfo;
					rPrev.AnimatorStates[i].TransitionInfo = rCurrent.AnimatorStates[i].TransitionInfo;
				}
			}
		}

		// Token: 0x040005D7 RID: 1495
		public AnimatorLayerState[] AnimatorStates;

		// Token: 0x040005D8 RID: 1496
		public bool IsForwardPathBlocked;

		// Token: 0x040005D9 RID: 1497
		public Vector3 ForwardPathBlockNormal;

		// Token: 0x040005DA RID: 1498
		public bool IsGrounded;

		// Token: 0x040005DB RID: 1499
		public Vector3 GroundLaunchVelocity;

		// Token: 0x040005DC RID: 1500
		public float InputX;

		// Token: 0x040005DD RID: 1501
		public float InputY;

		// Token: 0x040005DE RID: 1502
		public FloatValue InputMagnitudeTrend;

		// Token: 0x040005DF RID: 1503
		public Vector3 InputForward;

		// Token: 0x040005E0 RID: 1504
		public float InputFromAvatarAngle;

		// Token: 0x040005E1 RID: 1505
		public float InputFromCameraAngle;
	}
}
