using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000082 RID: 130
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class AnalogeCalibratorAttribute : DynamicUIElementAttribute
	{
		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000372 RID: 882 RVA: 0x00007B7F File Offset: 0x00005D7F
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.analogueCal;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000373 RID: 883 RVA: 0x00007B82 File Offset: 0x00005D82
		// (set) Token: 0x06000374 RID: 884 RVA: 0x00007B8A File Offset: 0x00005D8A
		public int decimalesDibujar { get; set; } = 2;
	}
}
