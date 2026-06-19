using System;

namespace Assets.Base.Plugins.Runtime.UI
{
	// Token: 0x02000182 RID: 386
	public interface IPanelAttribute
	{
		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06000B89 RID: 2953
		PanelBackgroundType backgroundType { get; }

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06000B8A RID: 2954
		bool backgroundTypeByUser { get; }

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06000B8B RID: 2955
		PanelBackgroundColor backgroundColor { get; }

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000B8C RID: 2956
		bool backgroundColorByUser { get; }

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000B8D RID: 2957
		float backgroundAlpha { get; }

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000B8E RID: 2958
		bool backgroundAlphaByUser { get; }
	}
}
