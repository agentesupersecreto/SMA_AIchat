using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000068 RID: 104
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class DeslizableHelpBotonAttribute : DynamicUIElementAttribute
	{
		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600030E RID: 782 RVA: 0x000076E0 File Offset: 0x000058E0
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.deslizableHelpBoton;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600030F RID: 783 RVA: 0x000076E4 File Offset: 0x000058E4
		// (set) Token: 0x06000310 RID: 784 RVA: 0x000076EC File Offset: 0x000058EC
		public int decimalesDibujar { get; set; } = 2;

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000311 RID: 785 RVA: 0x000076F5 File Offset: 0x000058F5
		// (set) Token: 0x06000312 RID: 786 RVA: 0x000076FD File Offset: 0x000058FD
		public bool wholeNumbers { get; set; }
	}
}
