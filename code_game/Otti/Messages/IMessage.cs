using System;

namespace com.ootii.Messages
{
	// Token: 0x02000021 RID: 33
	public interface IMessage
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001AA RID: 426
		// (set) Token: 0x060001AB RID: 427
		string Type { get; set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001AC RID: 428
		// (set) Token: 0x060001AD RID: 429
		object Sender { get; set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001AE RID: 430
		// (set) Token: 0x060001AF RID: 431
		object Recipient { get; set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001B0 RID: 432
		// (set) Token: 0x060001B1 RID: 433
		float Delay { get; set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001B2 RID: 434
		// (set) Token: 0x060001B3 RID: 435
		int ID { get; set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001B4 RID: 436
		// (set) Token: 0x060001B5 RID: 437
		object Data { get; set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001B6 RID: 438
		// (set) Token: 0x060001B7 RID: 439
		bool IsSent { get; set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001B8 RID: 440
		// (set) Token: 0x060001B9 RID: 441
		bool IsHandled { get; set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001BA RID: 442
		// (set) Token: 0x060001BB RID: 443
		int FrameIndex { get; set; }

		// Token: 0x060001BC RID: 444
		void Clear();

		// Token: 0x060001BD RID: 445
		void Release();
	}
}
