using System;
using com.ootii.Actors.AnimationControllers;
using UnityEngine;

namespace com.ootii.Actors.LifeCores
{
	// Token: 0x020000AB RID: 171
	public interface IInteractableCore : ILifeCore
	{
		// Token: 0x17000280 RID: 640
		// (get) Token: 0x0600097D RID: 2429
		// (set) Token: 0x0600097E RID: 2430
		bool IsEnabled { get; set; }

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x0600097F RID: 2431
		// (set) Token: 0x06000980 RID: 2432
		int Form { get; set; }

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000981 RID: 2433
		// (set) Token: 0x06000982 RID: 2434
		bool ForcePosition { get; set; }

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06000983 RID: 2435
		// (set) Token: 0x06000984 RID: 2436
		bool ForceRotation { get; set; }

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000985 RID: 2437
		// (set) Token: 0x06000986 RID: 2438
		float TargetDistance { get; set; }

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000987 RID: 2439
		// (set) Token: 0x06000988 RID: 2440
		Transform TargetLocation { get; set; }

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x06000989 RID: 2441
		// (set) Token: 0x0600098A RID: 2442
		bool UseRaycast { get; set; }

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x0600098B RID: 2443
		// (set) Token: 0x0600098C RID: 2444
		Collider RaycastCollider { get; set; }

		// Token: 0x0600098D RID: 2445
		bool TestActivator(Transform rTransform);

		// Token: 0x0600098E RID: 2446
		void StartFocus();

		// Token: 0x0600098F RID: 2447
		void StopFocus();

		// Token: 0x06000990 RID: 2448
		void OnActivated(BasicInteraction rMotion);
	}
}
