using System;
using Assets._ReusableScripts;
using Assets._ReusableScripts.Globales.Updater;

namespace Assets.PhysicsAndBonesScripts
{
	// Token: 0x02000017 RID: 23
	public abstract class ChainStretched : AplicableBehaviour
	{
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000067 RID: 103 RVA: 0x000026F0 File Offset: 0x000008F0
		public sealed override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.yieldFixedUpdate1);
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000068 RID: 104 RVA: 0x000026F9 File Offset: 0x000008F9
		public sealed override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.yieldFixedUpdate2);
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00002702 File Offset: 0x00000902
		public sealed override GlobalUpdater.UpdateType? updateEvent6
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.beforeFixedUpdates3);
			}
		}
	}
}
