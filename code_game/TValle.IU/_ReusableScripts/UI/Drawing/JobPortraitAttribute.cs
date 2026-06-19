using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000080 RID: 128
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class JobPortraitAttribute : DynamicUIElementAttribute
	{
		// Token: 0x1700013A RID: 314
		// (get) Token: 0x0600036A RID: 874 RVA: 0x00007B45 File Offset: 0x00005D45
		// (set) Token: 0x0600036B RID: 875 RVA: 0x00007B4D File Offset: 0x00005D4D
		public bool imageIsDiskAsset { get; set; }

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x0600036C RID: 876 RVA: 0x00007B56 File Offset: 0x00005D56
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.jobPortrait;
			}
		}
	}
}
