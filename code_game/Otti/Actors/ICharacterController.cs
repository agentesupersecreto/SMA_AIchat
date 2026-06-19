using System;
using UnityEngine;

namespace com.ootii.Actors
{
	// Token: 0x0200009A RID: 154
	public interface ICharacterController
	{
		// Token: 0x1700024C RID: 588
		// (get) Token: 0x0600089C RID: 2204
		ActorState State { get; }

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x0600089D RID: 2205
		GameObject gameObject { get; }

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x0600089E RID: 2206
		// (set) Token: 0x0600089F RID: 2207
		Quaternion Yaw { get; set; }

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x060008A0 RID: 2208
		// (set) Token: 0x060008A1 RID: 2209
		Quaternion Tilt { get; set; }

		// Token: 0x060008A2 RID: 2210
		void SetRotation(Quaternion rRotation);

		// Token: 0x060008A3 RID: 2211
		void SetRotation(Quaternion rYaw, Quaternion rTilt);

		// Token: 0x060008A4 RID: 2212
		void SetPosition(Vector3 rPosition);

		// Token: 0x060008A5 RID: 2213
		bool IsIgnoringCollision(Collider rCollider);

		// Token: 0x060008A6 RID: 2214
		void ClearIgnoreCollisions();

		// Token: 0x060008A7 RID: 2215
		void IgnoreCollision(Collider rCollider, bool rIgnore = true);

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x060008A8 RID: 2216
		// (set) Token: 0x060008A9 RID: 2217
		ControllerLateUpdateDelegate OnControllerPreLateUpdate { get; set; }

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x060008AA RID: 2218
		// (set) Token: 0x060008AB RID: 2219
		ControllerLateUpdateDelegate OnControllerPostLateUpdate { get; set; }

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x060008AC RID: 2220
		// (set) Token: 0x060008AD RID: 2221
		ControllerMoveDelegate OnPreControllerMove { get; set; }
	}
}
