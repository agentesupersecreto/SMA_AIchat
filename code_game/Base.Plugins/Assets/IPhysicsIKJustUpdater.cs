using System;

namespace Assets
{
	// Token: 0x020000DD RID: 221
	public interface IPhysicsIKJustUpdater
	{
		// Token: 0x14000015 RID: 21
		// (add) Token: 0x06000625 RID: 1573
		// (remove) Token: 0x06000626 RID: 1574
		event Action<IPhysicsIKJustUpdater> physicsIKJustUpdating;

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000627 RID: 1575
		// (remove) Token: 0x06000628 RID: 1576
		event Action<IPhysicsIKJustUpdater> physicsIKJustUpdated;
	}
}
