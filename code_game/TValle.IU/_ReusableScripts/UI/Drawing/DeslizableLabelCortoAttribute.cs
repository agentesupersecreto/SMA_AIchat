using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000076 RID: 118
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class DeslizableLabelCortoAttribute : DynamicUIElementAttribute
	{
		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000350 RID: 848 RVA: 0x00007A93 File Offset: 0x00005C93
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.deslizableLabelCorto;
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000351 RID: 849 RVA: 0x00007A97 File Offset: 0x00005C97
		// (set) Token: 0x06000352 RID: 850 RVA: 0x00007A9F File Offset: 0x00005C9F
		public int decimalesDibujar { get; set; } = 2;

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000353 RID: 851 RVA: 0x00007AA8 File Offset: 0x00005CA8
		// (set) Token: 0x06000354 RID: 852 RVA: 0x00007AB0 File Offset: 0x00005CB0
		public bool wholeNumbers { get; set; }
	}
}
