using System;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x02000084 RID: 132
	public interface IBaseCameraRig
	{
		// Token: 0x170001AD RID: 429
		// (get) Token: 0x060006CA RID: 1738
		Transform Transform { get; }

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x060006CB RID: 1739
		// (set) Token: 0x060006CC RID: 1740
		Transform Anchor { get; set; }

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x060006CD RID: 1741
		// (set) Token: 0x060006CE RID: 1742
		int Mode { get; set; }

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x060006CF RID: 1743
		// (set) Token: 0x060006D0 RID: 1744
		bool LockMode { get; set; }

		// Token: 0x060006D1 RID: 1745
		void EnableMode(int rMode, bool rEnable);

		// Token: 0x060006D2 RID: 1746
		void ClearTargetYawPitch();

		// Token: 0x060006D3 RID: 1747
		void SetTargetYawPitch(float rYaw, float rPitch, float rSpeed = -1f, bool rAutoClearTarget = true);

		// Token: 0x060006D4 RID: 1748
		void ClearTargetForward();

		// Token: 0x060006D5 RID: 1749
		void SetTargetForward(Vector3 rForward, float rSpeed = -1f, bool rAutoClearTarget = true);

		// Token: 0x060006D6 RID: 1750
		void ExtrapolateAnchorPosition(out Vector3 rPosition, out Quaternion rRotation);

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x060006D7 RID: 1751
		// (set) Token: 0x060006D8 RID: 1752
		bool IsInternalUpdateEnabled { get; set; }

		// Token: 0x060006D9 RID: 1753
		void RigLateUpdate(float rDeltaTime, int rUpdateIndex);
	}
}
