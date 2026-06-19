using System;
using TMPro;

namespace Assets.Base.Plugins.Runtime.UI
{
	// Token: 0x02000180 RID: 384
	public interface IFontAttribute
	{
		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000B75 RID: 2933
		int fontSize { get; }

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000B76 RID: 2934
		FontStyles fontStyle { get; }

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000B77 RID: 2935
		float fontSizeMod { get; }

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06000B78 RID: 2936
		TextAlignmentOptions alignment { get; }

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000B79 RID: 2937
		bool fontSizeByUser { get; }

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06000B7A RID: 2938
		bool fontStyleByUser { get; }

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000B7B RID: 2939
		bool fontSizeModByUser { get; }

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000B7C RID: 2940
		bool alignmentByUser { get; }

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000B7D RID: 2941
		ColorEnum color { get; }

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06000B7E RID: 2942
		bool colorByUser { get; }
	}
}
