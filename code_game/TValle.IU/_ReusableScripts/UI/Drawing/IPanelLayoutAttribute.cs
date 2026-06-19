using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200004A RID: 74
	public interface IPanelLayoutAttribute : IElementLayoutAttribute, IBaseLayoutAttribute
	{
		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000281 RID: 641
		bool? controlChildWidth { get; }

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000282 RID: 642
		bool? controlChildHeight { get; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000283 RID: 643
		bool? childForceExpandWidth { get; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000284 RID: 644
		bool? childForceExpandHeight { get; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000285 RID: 645
		int posX { get; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000286 RID: 646
		int posY { get; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000287 RID: 647
		bool posXByUser { get; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000288 RID: 648
		bool posYByUser { get; }
	}
}
