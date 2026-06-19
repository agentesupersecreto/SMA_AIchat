using System;

namespace Assets
{
	// Token: 0x0200010E RID: 270
	public interface IBufferDeMaxValueListiner
	{
		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060007AF RID: 1967
		string name { get; }

		// Token: 0x060007B0 RID: 1968
		void OnEnqueue();

		// Token: 0x060007B1 RID: 1969
		bool OnMaxValue();
	}
}
