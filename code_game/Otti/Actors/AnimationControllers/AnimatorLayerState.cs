using System;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000DA RID: 218
	public struct AnimatorLayerState
	{
		// Token: 0x040005B9 RID: 1465
		public AnimatorStateInfo StateInfo;

		// Token: 0x040005BA RID: 1466
		public AnimatorTransitionInfo TransitionInfo;

		// Token: 0x040005BB RID: 1467
		public int MotionPhase;

		// Token: 0x040005BC RID: 1468
		public int MotionForm;

		// Token: 0x040005BD RID: 1469
		public int MotionParameter;

		// Token: 0x040005BE RID: 1470
		public bool AutoClearMotionPhase;

		// Token: 0x040005BF RID: 1471
		public bool AutoClearMotionPhaseReady;

		// Token: 0x040005C0 RID: 1472
		public int AutoClearActiveTransitionID;

		// Token: 0x040005C1 RID: 1473
		public float SetTime;
	}
}
