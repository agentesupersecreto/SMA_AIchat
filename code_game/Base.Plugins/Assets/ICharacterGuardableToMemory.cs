using System;

namespace Assets
{
	// Token: 0x020000B7 RID: 183
	public interface ICharacterGuardableToMemory
	{
		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000543 RID: 1347
		bool doSaveOnlyWhenActive { get; }

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000544 RID: 1348
		bool doLoadOnlyWhenActive { get; }

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000545 RID: 1349
		// (remove) Token: 0x06000546 RID: 1350
		event ICharacterGuardableToMemory.LoadHandler memoryLoading;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000547 RID: 1351
		// (remove) Token: 0x06000548 RID: 1352
		event ICharacterGuardableToMemory.LoadHandler memoryOnLoad;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000549 RID: 1353
		// (remove) Token: 0x0600054A RID: 1354
		event ICharacterGuardableToMemory.LoadHandler memoryLoaded;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x0600054B RID: 1355
		// (remove) Token: 0x0600054C RID: 1356
		event ICharacterGuardableToMemory.SaveHandler memorySaving;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x0600054D RID: 1357
		// (remove) Token: 0x0600054E RID: 1358
		event ICharacterGuardableToMemory.SaveHandler memoryOnSave;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x0600054F RID: 1359
		// (remove) Token: 0x06000550 RID: 1360
		event ICharacterGuardableToMemory.SaveHandler memorySaved;

		// Token: 0x06000551 RID: 1361
		void DoLoadFromMemory(object fromMemory);

		// Token: 0x06000552 RID: 1362
		void DoSaveToMemory(object toMemory);

		// Token: 0x020001C7 RID: 455
		// (Invoke) Token: 0x06000C51 RID: 3153
		public delegate void LoadHandler(object fromMemory, ICharacterGuardableToMemory character);

		// Token: 0x020001C8 RID: 456
		// (Invoke) Token: 0x06000C55 RID: 3157
		public delegate void SaveHandler(object toMemory, ICharacterGuardableToMemory character);
	}
}
