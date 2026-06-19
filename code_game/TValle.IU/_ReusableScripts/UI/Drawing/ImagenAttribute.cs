using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200006B RID: 107
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class ImagenAttribute : LayoutedElementAttribute
	{
		// Token: 0x17000112 RID: 274
		// (get) Token: 0x0600031E RID: 798 RVA: 0x00007771 File Offset: 0x00005971
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.imagen;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x0600031F RID: 799 RVA: 0x00007775 File Offset: 0x00005975
		// (set) Token: 0x06000320 RID: 800 RVA: 0x0000777D File Offset: 0x0000597D
		public int ImageWidth { get; set; } = 90;

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000321 RID: 801 RVA: 0x00007786 File Offset: 0x00005986
		// (set) Token: 0x06000322 RID: 802 RVA: 0x0000778E File Offset: 0x0000598E
		public int ImageHeight { get; set; } = 160;
	}
}
