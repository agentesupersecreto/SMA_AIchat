using System;

namespace Assets
{
	// Token: 0x020000CD RID: 205
	public interface IComponentStartable
	{
		// Token: 0x060005FD RID: 1533
		void ManualStart();

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060005FE RID: 1534
		bool isStared { get; }

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x060005FF RID: 1535
		// (remove) Token: 0x06000600 RID: 1536
		event CustomMonobehaviourEventHandler staring;

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x06000601 RID: 1537
		// (remove) Token: 0x06000602 RID: 1538
		event CustomMonobehaviourEventHandler justStared;

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x06000603 RID: 1539
		// (remove) Token: 0x06000604 RID: 1540
		event CustomMonobehaviourEventHandler stared;
	}
}
