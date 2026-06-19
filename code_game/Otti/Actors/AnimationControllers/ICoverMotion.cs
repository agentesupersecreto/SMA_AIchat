using System;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x02000104 RID: 260
	public interface ICoverMotion : IMotionControllerMotion
	{
		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x06000F1A RID: 3866
		bool IsExiting { get; }

		// Token: 0x06000F1B RID: 3867
		void ExitCover(bool rExtrapolatePosition = false, bool rUseCameraRotation = false);

		// Token: 0x06000F1C RID: 3868
		void ExitCover(Vector3 rPosition, Quaternion rRotation);
	}
}
