using System;

namespace Assets
{
	// Token: 0x020000CE RID: 206
	public interface IComponentAwakeable
	{
		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000605 RID: 1541
		bool isAwaken { get; }

		// Token: 0x06000606 RID: 1542
		void ManualAwake();
	}
}
