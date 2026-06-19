using System;
using com.ootii.Actors;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x02000083 RID: 131
	public interface IBaseCameraAnchor
	{
		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x060006BE RID: 1726
		// (set) Token: 0x060006BF RID: 1727
		bool IsFollowingEnabled { get; set; }

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x060006C0 RID: 1728
		Transform Transform { get; }

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x060006C1 RID: 1729
		// (set) Token: 0x060006C2 RID: 1730
		Transform Root { get; set; }

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x060006C3 RID: 1731
		// (set) Token: 0x060006C4 RID: 1732
		Vector3 RootOffset { get; set; }

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x060006C5 RID: 1733
		// (set) Token: 0x060006C6 RID: 1734
		ControllerLateUpdateDelegate OnAnchorPostLateUpdate { get; set; }

		// Token: 0x060006C7 RID: 1735
		void ClearTarget(bool rFollowRoot = false);

		// Token: 0x060006C8 RID: 1736
		void ClearTarget(float rSpeed = 0f, float rLerp = 0f);

		// Token: 0x060006C9 RID: 1737
		void SetTargetPosition(Transform rTarget, Vector3 rPosition, float rSpeed, float rLerp = 0f, bool rClear = true);
	}
}
