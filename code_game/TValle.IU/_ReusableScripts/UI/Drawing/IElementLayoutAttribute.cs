using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200004B RID: 75
	public interface IElementLayoutAttribute : IBaseLayoutAttribute
	{
		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000289 RID: 649
		float? flexibleWidth { get; }

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x0600028A RID: 650
		float? flexibleHeight { get; }

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x0600028B RID: 651
		bool unlockFlexibleIfHeightWasSet { get; }

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x0600028C RID: 652
		bool unlockFlexibleIfWidthWasSet { get; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x0600028D RID: 653
		bool unlockParentFlexibleIfHeightWasSet { get; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x0600028E RID: 654
		bool unlockParentFlexibleIfWidthWasSet { get; }
	}
}
