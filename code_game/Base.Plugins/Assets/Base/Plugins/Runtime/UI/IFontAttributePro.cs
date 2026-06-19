using System;
using TMPro;

namespace Assets.Base.Plugins.Runtime.UI
{
	// Token: 0x02000181 RID: 385
	[Obsolete("ahora todos son TMP", true)]
	public interface IFontAttributePro
	{
		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000B7F RID: 2943
		int fontSize { get; }

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000B80 RID: 2944
		FontStyles fontStyle { get; }

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000B81 RID: 2945
		float fontSizeMod { get; }

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000B82 RID: 2946
		TextAlignmentOptions alignment { get; }

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000B83 RID: 2947
		bool fontSizeByUser { get; }

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06000B84 RID: 2948
		bool fontStyleByUser { get; }

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06000B85 RID: 2949
		bool fontSizeModByUser { get; }

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06000B86 RID: 2950
		bool alignmentByUser { get; }

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06000B87 RID: 2951
		ColorEnum color { get; }

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06000B88 RID: 2952
		bool colorByUser { get; }
	}
}
