using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200007E RID: 126
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class FavoritableGenericPortraitAttribute : DynamicUIElementAttribute
	{
		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000364 RID: 868 RVA: 0x00007B1C File Offset: 0x00005D1C
		// (set) Token: 0x06000365 RID: 869 RVA: 0x00007B24 File Offset: 0x00005D24
		public bool imageIsDiskAsset { get; set; }

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000366 RID: 870 RVA: 0x00007B2D File Offset: 0x00005D2D
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.favoritableGenericPortrait;
			}
		}
	}
}
