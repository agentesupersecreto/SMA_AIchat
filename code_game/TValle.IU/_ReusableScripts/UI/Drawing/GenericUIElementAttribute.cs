using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000059 RID: 89
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public class GenericUIElementAttribute : DynamicUIElementAttribute
	{
		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060002EE RID: 750 RVA: 0x0000761D File Offset: 0x0000581D
		public override UIElementoDinamico tipo
		{
			get
			{
				return this.tipoDeElemento;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060002EF RID: 751 RVA: 0x00007625 File Offset: 0x00005825
		// (set) Token: 0x060002F0 RID: 752 RVA: 0x0000762D File Offset: 0x0000582D
		public UIElementoDinamico tipoDeElemento { get; set; }
	}
}
