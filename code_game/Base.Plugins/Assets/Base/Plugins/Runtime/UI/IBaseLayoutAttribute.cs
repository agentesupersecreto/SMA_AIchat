using System;

namespace Assets.Base.Plugins.Runtime.UI
{
	// Token: 0x0200017F RID: 383
	public interface IBaseLayoutAttribute
	{
		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000B63 RID: 2915
		float scaleMod { get; }

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000B64 RID: 2916
		bool scaleModByUser { get; }

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000B65 RID: 2917
		float heightMod { get; }

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000B66 RID: 2918
		float widthMod { get; }

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000B67 RID: 2919
		bool heightModByUser { get; }

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000B68 RID: 2920
		bool widthModByUser { get; }

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000B69 RID: 2921
		int height { get; }

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000B6A RID: 2922
		int width { get; }

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000B6B RID: 2923
		bool heightByUser { get; }

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x06000B6C RID: 2924
		bool widthByUser { get; }

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06000B6D RID: 2925
		int leftPadding { get; }

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000B6E RID: 2926
		int rightPadding { get; }

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000B6F RID: 2927
		int topPadding { get; }

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000B70 RID: 2928
		int bottomPadding { get; }

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000B71 RID: 2929
		bool leftPaddingByUser { get; }

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000B72 RID: 2930
		bool rightPaddingByUser { get; }

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000B73 RID: 2931
		bool topPaddingByUser { get; }

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000B74 RID: 2932
		bool bottomPaddingByUser { get; }
	}
}
