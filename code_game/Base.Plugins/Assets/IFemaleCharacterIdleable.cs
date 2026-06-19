using System;

namespace Assets
{
	// Token: 0x020000B2 RID: 178
	public interface IFemaleCharacterIdleable : ICharacterIdleable
	{
		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600051F RID: 1311
		bool enAutoInteraccion { get; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000520 RID: 1312
		bool enAutoInteraccionCoital { get; }

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000521 RID: 1313
		bool enAutoInteraccionCoitalHead { get; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000522 RID: 1314
		bool enAutoInteraccionCoitalHips { get; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000523 RID: 1315
		bool enAutoInteraccionCoitalHands { get; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000524 RID: 1316
		bool enAutoInteraccionMassage { get; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000525 RID: 1317
		bool headEsIdle { get; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000526 RID: 1318
		bool pelvisEsIdle { get; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000527 RID: 1319
		bool handsEsIdle { get; }
	}
}
