using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000081 RID: 129
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class OfficePortraitAttribute : DynamicUIElementAttribute
	{
		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600036E RID: 878 RVA: 0x00007B62 File Offset: 0x00005D62
		// (set) Token: 0x0600036F RID: 879 RVA: 0x00007B6A File Offset: 0x00005D6A
		public bool imageIsDiskAsset { get; set; }

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000370 RID: 880 RVA: 0x00007B73 File Offset: 0x00005D73
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.officePortrait;
			}
		}
	}
}
