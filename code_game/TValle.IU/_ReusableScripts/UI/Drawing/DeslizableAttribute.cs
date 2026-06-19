using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000069 RID: 105
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class DeslizableAttribute : DynamicUIElementAttribute
	{
		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000314 RID: 788 RVA: 0x00007715 File Offset: 0x00005915
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.deslizable;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000315 RID: 789 RVA: 0x00007718 File Offset: 0x00005918
		// (set) Token: 0x06000316 RID: 790 RVA: 0x00007720 File Offset: 0x00005920
		public int decimalesDibujar { get; set; } = 2;

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000317 RID: 791 RVA: 0x00007729 File Offset: 0x00005929
		// (set) Token: 0x06000318 RID: 792 RVA: 0x00007731 File Offset: 0x00005931
		public bool wholeNumbers { get; set; }
	}
}
