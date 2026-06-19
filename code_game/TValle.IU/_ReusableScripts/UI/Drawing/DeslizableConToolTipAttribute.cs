using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000074 RID: 116
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class DeslizableConToolTipAttribute : DynamicUIElementAttribute
	{
		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000346 RID: 838 RVA: 0x00007A41 File Offset: 0x00005C41
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.deslizableConToolTip;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000347 RID: 839 RVA: 0x00007A45 File Offset: 0x00005C45
		// (set) Token: 0x06000348 RID: 840 RVA: 0x00007A4D File Offset: 0x00005C4D
		public int decimalesDibujar { get; set; } = 2;

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000349 RID: 841 RVA: 0x00007A56 File Offset: 0x00005C56
		// (set) Token: 0x0600034A RID: 842 RVA: 0x00007A5E File Offset: 0x00005C5E
		public bool wholeNumbers { get; set; }
	}
}
