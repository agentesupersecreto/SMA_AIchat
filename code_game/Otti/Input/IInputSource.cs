using System;
using UnityEngine;

namespace com.ootii.Input
{
	// Token: 0x0200002B RID: 43
	public interface IInputSource
	{
		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001E8 RID: 488
		// (set) Token: 0x060001E9 RID: 489
		bool IsEnabled { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001EA RID: 490
		// (set) Token: 0x060001EB RID: 491
		float InputFromCameraAngle { get; set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001EC RID: 492
		// (set) Token: 0x060001ED RID: 493
		float InputFromAvatarAngle { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001EE RID: 494
		float MovementX { get; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001EF RID: 495
		float MovementY { get; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001F0 RID: 496
		float MovementSqr { get; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001F1 RID: 497
		float ViewX { get; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001F2 RID: 498
		float ViewY { get; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001F3 RID: 499
		bool IsViewingActivated { get; }

		// Token: 0x060001F4 RID: 500
		bool IsJustPressed(KeyCode rKey);

		// Token: 0x060001F5 RID: 501
		bool IsJustPressed(int rKey);

		// Token: 0x060001F6 RID: 502
		bool IsJustPressed(string rAction);

		// Token: 0x060001F7 RID: 503
		bool IsPressed(KeyCode rKey);

		// Token: 0x060001F8 RID: 504
		bool IsPressed(int rKey);

		// Token: 0x060001F9 RID: 505
		bool IsPressed(string rAction);

		// Token: 0x060001FA RID: 506
		bool IsJustReleased(KeyCode rKey);

		// Token: 0x060001FB RID: 507
		bool IsJustReleased(int rKey);

		// Token: 0x060001FC RID: 508
		bool IsJustReleased(string rAction);

		// Token: 0x060001FD RID: 509
		bool IsReleased(KeyCode rKey);

		// Token: 0x060001FE RID: 510
		bool IsReleased(int rKey);

		// Token: 0x060001FF RID: 511
		bool IsReleased(string rAction);

		// Token: 0x06000200 RID: 512
		float GetValue(int rKey);

		// Token: 0x06000201 RID: 513
		float GetValue(string rAction);
	}
}
