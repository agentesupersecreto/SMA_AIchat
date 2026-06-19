using System;

namespace Assets
{
	// Token: 0x020000CA RID: 202
	public interface IComponentEnabable
	{
		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060005F1 RID: 1521
		bool isActiveAndEnabled { get; }

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x060005F2 RID: 1522
		// (remove) Token: 0x060005F3 RID: 1523
		event Action<object> onEnabled;

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x060005F4 RID: 1524
		// (remove) Token: 0x060005F5 RID: 1525
		event Action<object> onDisabled;
	}
}
